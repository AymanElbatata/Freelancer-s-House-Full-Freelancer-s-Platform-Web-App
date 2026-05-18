using AutoMapper;
using AymanFreelance.BLL.Interfaces;
using AymanFreelance.BLL.Repositories;
using AymanFreelance.DAL.Entities;
using AymanFreelance.PL.DTO;
using AymanFreelance.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AymanFreelance.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper Mapper;
        private readonly IConfiguration configuration;

        public AdminController(IUnitOfWork unitOfWork, IMapper Mapper, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.Mapper = Mapper;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboard_VM();
            model.UserTBL_VM = await GetUserViewModels();

            var Admin = unitOfWork.UserManager.GetUsersInRoleAsync("Admin").Result.Where(a=>!a.IsDeleted).ToList();
            var freelancers = unitOfWork.UserManager.GetUsersInRoleAsync("Freelancer").Result.Where(a => !a.IsDeleted).ToList();
            var SponsorClient =  unitOfWork.UserManager.GetUsersInRoleAsync("SponsorClient").Result.Where(a => !a.IsDeleted).ToList();

            model.TotalAdmins = Admin.Count(x => !x.IsDeleted);
            model.TotalFreelancers = freelancers.Count(x => !x.IsDeleted);
            model.TotalClients = SponsorClient.Count(x => !x.IsDeleted);
            var projects = unitOfWork.ProjectTBLRepository.GetAllCustomized(
                     filter: x =>
                         !x.IsDeleted,
                     includes: new Expression<Func<ProjectTBL, object>>[]
                     {
                                    x => x.ProjectOwnerTBL,
                                    x => x.ProjectFreelancerTBL
                     })
                     .OrderByDescending(x => x.CreationDate)
                     .ToList();
            model.ProjectTBL_VM = Mapper.Map<List<ProjectTBL_VM>>(projects);

            model.TotalProjects = projects.Count();
            model.TotalActiveProjects = projects.Count(x => x.DateOfDelivery > DateTime.Now);
            model.TotalCompletedProjects = projects.Count(x => x.DateOfDelivery <= DateTime.Now);

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetUserById(string id)
        {
            try
            {
                var user = await unitOfWork.UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                var roles = await unitOfWork.UserManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault() ?? "";

                return Json(new
                {
                    success = true,
                    user = new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        email = user.Email,
                        phoneNumber = user.PhoneNumber,
                        roleName = roleName
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Id))
                {
                    return Json(new { success = false, message = "Invalid user data" });
                }

                var user = await unitOfWork.UserManager.FindByIdAsync(request.Id);
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                // Update user properties
                user.UserName = request.UserName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;

                // Update user in database
                var updateResult = await unitOfWork.UserManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    return Json(new { success = false, message = string.Join(", ", updateResult.Errors.Select(e => e.Description)) });
                }

                // Update role if changed
                var currentRoles = await unitOfWork.UserManager.GetRolesAsync(user);
                var currentRole = currentRoles.FirstOrDefault();

                if (currentRole != request.RoleName)
                {
                    // Remove current role
                    if (!string.IsNullOrEmpty(currentRole))
                    {
                        await unitOfWork.UserManager.RemoveFromRoleAsync(user, currentRole);
                    }

                    // Add new role
                    await unitOfWork.UserManager.AddToRoleAsync(user, request.RoleName);
                }

                return Json(new { success = true, message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteUser(string id)
        {
            // Your delete logic here
            var user = await unitOfWork.UserManager.FindByIdAsync(id);
            user.IsDeleted = true;
            await unitOfWork.UserManager.UpdateAsync(user);

            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteProject(int id)
        {
            var project = unitOfWork.ProjectTBLRepository.GetById(id);
            project.IsDeleted = true;
            unitOfWork.ProjectTBLRepository.Update(project);
            // Your delete logic here
            return Json(new { success = true });
        }


        private async Task<List<UserTBL_VM>> GetUserViewModels()
        {
            var users = unitOfWork.UserManager.Users.ToList();
            var userViewModels = new List<UserTBL_VM>();

            foreach (var user in users)
            {
                var roles = await unitOfWork.UserManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault() ?? "Client"; // Default role

                var userVM = new UserTBL_VM
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName, 
                    LastName = user.LastName,
                    Phone = user.PhoneNumber,
                    RoleName = roleName,
                    IsDeleted = user.IsDeleted                                                   
                };

                userViewModels.Add(userVM);
            }

            return userViewModels;
        }

    }
}
