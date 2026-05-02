using AutoMapper;
using AymanFreelance.BLL.Interfaces;
using AymanFreelance.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AymanFreelance.PL.Controllers
{
    [Authorize(Roles = "Freelancer")]
    public class FreelancerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper Mapper;
        private readonly IConfiguration configuration;

        public FreelancerController(IUnitOfWork unitOfWork, IMapper Mapper, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.Mapper = Mapper;
            this.configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var getCurrentUser = await unitOfWork.UserManager.FindByIdAsync(userId);
            var model = new FreelancerDashboardVM
            {
                Name = getCurrentUser.UserName,
                Email = getCurrentUser.Email,
                Photo = getCurrentUser.PersonalImage,
                ProjectTBL_VM = unitOfWork.ProjectTBLRepository.GetAllCustomized(p => !p.IsDeleted && p.ProjectFreelancerTBLId == userId).Select(p => Mapper.Map<ProjectTBL_VM>(p)).OrderByDescending(a => a.DateOfStartWork).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var model = new UserTBL_VM();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var getCurrentUser = await unitOfWork.UserManager.FindByIdAsync(userId);

            model = Mapper.Map(getCurrentUser, model);
            model.Phone = getCurrentUser.PhoneNumber;

            model.CountryOptions = unitOfWork.CountryTBLRepository.GetAllCustomized(
                       filter: a => a.IsDeleted == false)
           .Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name, Selected = (c.ID == model.CountryTBLId) }).ToList();

            model.GenderOptions = unitOfWork.GenderTBLRepository.GetAllCustomized(
                        filter: a => a.IsDeleted == false)
                .Select(g => new SelectListItem { Value = g.ID.ToString(), Text = g.Name, Selected = (g.ID == model.GenderTBLId) }).ToList();

            model.ProfessionOptions = unitOfWork.ProfessionTBLRepository.GetAllCustomized(
                        filter: a => a.IsDeleted == false)
            .Select(g => new SelectListItem { Value = g.ID.ToString(), Text = g.Name, Selected = (g.ID == model.ProfessionTBLId) }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserTBL_VM model, IFormFile personalImageFile, IFormFile idImageFile)
        {
            if (!ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                var getCurrentUser = await unitOfWork.UserManager.FindByIdAsync(userId);
                getCurrentUser.FirstName = model.FirstName;
                getCurrentUser.LastName = model.LastName;
                getCurrentUser.Address = model.Address;
                getCurrentUser.PhoneNumber = model.Phone;
                getCurrentUser.Description = model.Description;
                getCurrentUser.CountryTBLId = model.CountryTBLId;
                getCurrentUser.GenderTBLId = model.GenderTBLId;
                getCurrentUser.ProfessionTBLId = model.ProfessionTBLId;

                if (personalImageFile != null && personalImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Freelancer");

                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid() + Path.GetExtension(personalImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await personalImageFile.CopyToAsync(stream);

                    getCurrentUser.PersonalImage = fileName;
                }

                if (idImageFile != null && idImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Freelancer");

                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid() + Path.GetExtension(idImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await idImageFile.CopyToAsync(stream);

                    getCurrentUser.PassportOrNationalIdImage = fileName;
                }

                var result = await unitOfWork.UserManager.UpdateAsync(getCurrentUser);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

    }
}
