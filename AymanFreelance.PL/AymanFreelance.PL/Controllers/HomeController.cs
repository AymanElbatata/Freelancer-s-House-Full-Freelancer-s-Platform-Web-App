using AutoMapper;
using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;
using AymanFreelance.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AymanFreelance.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper Mapper;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IMapper Mapper)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.Mapper = Mapper;

        }

        public IActionResult Index()
        {
            var data = new Index_VM();
            var projects = unitOfWork.ProjectTBLRepository.GetAllCustomized(
                filter: a => a.IsDeleted == false, includes: new Expression<Func<ProjectTBL, object>>[]
                        {
                                         p => p.ProjectOwnerTBL,
                                         p => p.ProjectFreelancerTBL
                        }).Take(9);
            data.ProductTBL_VM = Mapper.Map<List<ProjectTBL_VM>>(projects.OrderByDescending(a => a.CreationDate));
            return View(data);
        }


        public async Task<IActionResult> Search(string? MainSearchWord)
        {
            var data = new Search_VM();
            var users = GetAllConfirmedFreelancersAndClients().Result.Where(u => u.UserName.Contains(MainSearchWord) || u.Email.Contains(MainSearchWord)).ToList();
                 
            if (users != null) {                        
                foreach (var item in users)
                {
                    if (item.Role == "Freelancer")
                    {
                        item.FreelancerRatingTBL_VM =  GetAllRatingsForFreelancerByUserId(item.ID);
                        data.Freelancers_VM.Add(item);
                    }
                    else if (item.Role == "SponsorClient")
                    {
                        data.Clients_VM.Add(item);
                    }
                }
            }
            var projects = unitOfWork.ProjectTBLRepository.GetAllCustomized(
            filter: a => a.IsDeleted == false && (a.HashCode.Contains(MainSearchWord) || a.Name.Contains(MainSearchWord)|| a.Description.Contains(MainSearchWord)), includes: new Expression<Func<ProjectTBL, object>>[]
                    {
                                             p => p.ProjectOwnerTBL
                    });
            data.ProjectTBL_VM = Mapper.Map<List<ProjectTBL_VM>>(projects.OrderByDescending(a => a.CreationDate));

            return View(data);
        }


        public async Task<IActionResult> Freelancers()
        {
            var data = new Search_VM();
            var users = await GetAllConfirmedFreelancersAndClients();

            if (users != null)
            {
                foreach (var item in users)
                {
                    if (item.Role == "Freelancer")
                    {
                        item.FreelancerRatingTBL_VM = GetAllRatingsForFreelancerByUserId(item.ID);

                        data.Freelancers_VM.Add(item);
                    }
                }
            }

            return View(data);
        }

        public async Task<IActionResult> Clients()
        {
            var data = new Search_VM();
            var users = await GetAllConfirmedFreelancersAndClients();

            if (users != null)
            {
                foreach (var item in users)
                {
                    if (item.Role == "SponsorClient")
                    {
                        data.Clients_VM.Add(item);
                    }
                }
            }
            return View(data);
        }

        public IActionResult Projects()
        {
            var data = new Search_VM();

            var projects = unitOfWork.ProjectTBLRepository.GetAllCustomized(
                   filter: a => a.IsDeleted == false && a.DateOfDelivery == null, includes: new Expression<Func<ProjectTBL, object>>[]
                   {
                                  p => p.ProjectOwnerTBL,
                                  p => p.ProjectFreelancerTBL
                   });
            data.ProjectTBL_VM = Mapper.Map<List<ProjectTBL_VM>>(projects.OrderByDescending(a => a.CreationDate));

            return View(data);
        }

        public IActionResult WhoisProject(int? ProjectId)
        {
            if (ProjectId == 0 || !unitOfWork.ProjectTBLRepository.GetAllCustomized(
                filter: a => a.IsDeleted == false && a.ID == ProjectId).Any())
                return RedirectToAction("Index", "Home");

            var data = new WhoisProject_VM();
            var project = unitOfWork.ProjectTBLRepository.GetAllCustomized(
                 filter: a => a.IsDeleted == false && a.ID == ProjectId, includes: new Expression<Func<ProjectTBL, object>>[]
            {
                                                             p => p.ProjectOwnerTBL,
                                                             p => p.ProjectFreelancerTBL

            }).FirstOrDefault();
            data.ProjectTBL_VM = Mapper.Map<ProjectTBL_VM>(project);

            var Applications = unitOfWork.ProjectApplicationTBLRepository.GetAllCustomized(
                 filter: a => a.IsDeleted == false && a.ProjectTBLId == ProjectId, includes: new Expression<Func<ProjectApplicationTBL, object>>[]
            {
                                                             p => p.AppUserWhoWrote,

            });

            data.ProjectApplicationTBL_VM = Mapper.Map<List<ProjectApplicationTBL_VM>>(Applications.OrderByDescending(a => a.CreationDate));

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                var HasAppliedBefore = unitOfWork.ProjectApplicationTBLRepository.GetAllCustomized(
                         filter: a => a.IsDeleted == false && a.ProjectTBLId == ProjectId && a.AppUserWhoWroteId == userId).Any();
                data.HasAppliedBefore = HasAppliedBefore;
            }

            return View(data);
        }

        public IActionResult FreelancerSubmitNewOfferforProject(int? ProjectId, int? Cost, int? PaymentInAdvance, int? DaysOfDelivery, string? Message)
        {
            if (ProjectId == 0 || !unitOfWork.ProjectTBLRepository.GetAllCustomized(
                filter: a => a.IsDeleted == false && a.ID == ProjectId).Any())
                return RedirectToAction("Index", "Home");

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            unitOfWork.ProjectApplicationTBLRepository.Add(new ProjectApplicationTBL
            {
                AppUserWhoWroteId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString(),
                ProjectTBLId = ProjectId,
                DaysOfDelivery = DaysOfDelivery,
                PaymentInAdvance = PaymentInAdvance,
                Cost = Cost,
                Message = Message
            });

            return RedirectToAction("WhoisProject", "Home", new { ProjectId = ProjectId });

        }
        public IActionResult WhoisFreelancerClient(string? UserName)
        {
            if (UserName == null || !unitOfWork.UserManager.Users.Where(a => a.IsDeleted == false && a.UserName == UserName).Any())
                return RedirectToAction("Index", "Home");

            var data = new WhoisFreelancerClient_VM();
            var User = GetAllConfirmedFreelancersAndClients().Result.FirstOrDefault(a=>a.UserName == UserName);
            if (User.Role == "Freelancer")
            {
                User.FreelancerRatingTBL_VM = GetAllRatingsForFreelancerByUserId(User.ID);
            }
            data.UserTBL_VM = Mapper.Map<UserTBL_VM>(User);

            return View(data);
        }


        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ConditionsofUse()
        {
            return View();
        }

        public IActionResult PrivacyNotice()
        {
            return View();
        }

        public IActionResult HelpPage()
        {
            return View();
        }

        private async Task<List<UserTBL_VM>> GetAllConfirmedFreelancersAndClients()
        {
           List<UserTBL_VM> UserList = new List<UserTBL_VM>();
           var users = unitOfWork.UserManager.Users.Include(u => u.CountryTBL).Include(u => u.ProfessionTBL).Where(a => a.IsActivated == true && a.IsDeleted == false && a.EmailConfirmed == true);
            if (users != null)
            {
                foreach (var item in users)
                {
                    var roles = await unitOfWork.UserManager.GetRolesAsync(item);
                    var role = roles.FirstOrDefault(); // لأنه كل يوزر له رول واحد بس

                    var user = new UserTBL_VM
                    {
                        ID = item.Id,
                        UserName = item.UserName,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Phone = item.PhoneNumber,
                        CountryTBL = item.CountryTBL,
                        GenderTBL = item.GenderTBL,
                        ProfessionTBL = item.ProfessionTBL,
                        CountryTBLId = item.CountryTBLId,
                        GenderTBLId = item.GenderTBLId,
                        ProfessionTBLId = item.ProfessionTBLId,
                        PersonalImage = item.PersonalImage,
                        Role = role
                    };
                    UserList.Add(user);
                }
            } 
            return UserList;
        }

        private List<FreelancerRatingTBL_VM> GetAllRatingsForFreelancerByUserId(string UserId)
        {
            List<FreelancerRatingTBL_VM> RatingList = new List<FreelancerRatingTBL_VM>();
            RatingList = Mapper.Map<List<FreelancerRatingTBL_VM>>(unitOfWork.FreelancerRatingTBLRepository.GetAllCustomized(
                       filter: a => a.IsDeleted == false && a.AppUserWhoIsRatedId == UserId));
            return RatingList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
