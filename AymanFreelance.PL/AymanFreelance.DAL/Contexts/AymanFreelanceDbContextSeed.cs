using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;
//using Exam.DAL.Interfaces;
//using Exam.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AymanFreelance.DAL.Contexts
{
    public class AymanFreelanceDbContextSeed
    {
        public static async Task SeedAsync(AymanFreelanceDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,  ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.CountryTBLs.Any())
                {
                    var Countries = File.ReadAllText("../AymanFreelance.DAL/Contexts/SeedData/Country.json");
                    var CountryCollection = JsonSerializer.Deserialize<List<CountryTBL>>(Countries);
                    for (int i = 0; i < CountryCollection?.Count; i++)
                    {
                        context.CountryTBLs.Add(CountryCollection[i]);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.GenderTBLs.Any())
                {
                    var Genders = File.ReadAllText("../AymanFreelance.DAL/Contexts/SeedData/Gender.json");
                    var GenderCollection = JsonSerializer.Deserialize<List<GenderTBL>>(Genders);
                    for (int i = 0; i < GenderCollection?.Count; i++)
                    {
                        context.GenderTBLs.Add(GenderCollection[i]);
                    }
                    await context.SaveChangesAsync();
                }
                //if (!context.UserTypeTBLs.Any())
                //{
                //    var UserType = File.ReadAllText("../AymanFreelance.DAL/Contexts/SeedData/UserType.json");
                //    var UserTypeCollection = JsonSerializer.Deserialize<List<UserTypeTBL>>(UserType);
                //    for (int i = 0; i < UserTypeCollection?.Count; i++)
                //    {
                //        context.UserTypeTBLs.Add(UserTypeCollection[i]);
                //    }
                //    await context.SaveChangesAsync();
                //}
                if (!context.ProfessionTBLs.Any())
                {
                    var Jobs = File.ReadAllText("../AymanFreelance.DAL/Contexts/SeedData/Profession.json");
                    var Job = Jobs.Split(',').ToList();
                    //var Job = JsonSerializer.Deserialize<List<Job>>(jobsArr);

                    for (int i = 0; i < Job?.Count; i++)
                    {
                        context.ProfessionTBLs.Add(new ProfessionTBL { Name = Job[i].Split("\"")[1] });
                    }
                    await context.SaveChangesAsync();
                }
                if (!roleManager.Roles.Any())
                {
                    var role1 = new AppRole
                    {
                        Name = "Admin"
                    };
                    var role2 = new AppRole
                    {
                        Name = "Freelancer"
                    };
                    var role3 = new AppRole
                    {
                        Name = "SponsorClient"
                    };

                    await roleManager.CreateAsync(role1);
                    await roleManager.CreateAsync(role2);
                    await roleManager.CreateAsync(role3);
                }

                if (!userManager.Users.Any())
                {
                    var user1 = new AppUser
                    {
                        NormalizedUserName = "AymanElbatata".ToUpper(),
                        Email = "Ayman.Fathy.Elbatata@gmail.com",
                        UserName = "Ayman.Elbatata",
                        FirstName = "Ayman",
                        LastName = "Elbatata",
                        IsActivated = true,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumber = "201284878483",
                        CountryTBLId = 51,
                        GenderTBLId = 1,
                        ProfessionTBLId = 10,
                        Description = "publishing, and web development. Its purpose is to permit a page layout to be designed, independently of the copy that will subsequently populate it, or to demonstrate various fonts of a typeface without meaningful text that could be distracting. Lorem ipsum is typically a corrupted version of De finibus bonorum et malorum"
                    };
                    var user2 = new AppUser
                    {
                        NormalizedUserName = "AymanFathy".ToUpper(),
                        Email = "Ayman_Elbatata@outlook.com",
                        UserName = "Ayman.Fathy",
                        FirstName = "Ayman",
                        LastName = "Fathy",
                        IsActivated = true,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumber = "201554820255",
                        CountryTBLId = 50,
                        GenderTBLId = 2,
                        ProfessionTBLId = 20,
                        Description = "graphic design, publishing, and web development. Its purpose is to permit a page layout to be designed, independently of the copy that will subsequently populate it, or to demonstrate various fonts of a typeface without meaningful text that could be distracting. Lorem ipsum is typically a corrupted version of De finibus bonorum et malorum"
                    };

                    var user3 = new AppUser
                    {
                        NormalizedUserName = "AymanBatata".ToUpper(),
                        Email = "Ayman_Elbatata@inbox.lt",
                        UserName = "Ayman.Batata",
                        FirstName = "Ayman",
                        LastName = "Fathy",
                        IsActivated = true,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        PhoneNumber = "201006983906",
                        CountryTBLId = 183,
                        GenderTBLId = 3,
                        ProfessionTBLId = 30,
                        Description = "Lorem ipsum is a dummy or placeholder text commonly. Its purpose is to permit a page layout to be designed, independently of the copy that will subsequently populate it, or to demonstrate various fonts of a typeface without meaningful text that could be distracting. Lorem ipsum is typically a corrupted version of De finibus bonorum et malorum"
                    };


                    await userManager.CreateAsync(user1, "Aym@8999");
                    await userManager.CreateAsync(user2, "Aym@8999");
                    await userManager.CreateAsync(user3, "Aym@8999");

                    await userManager.AddToRoleAsync(user1, "Admin");
                    await userManager.AddToRoleAsync(user2, "Freelancer");
                    await userManager.AddToRoleAsync(user3, "SponsorClient");
                    await context.SaveChangesAsync();


                    if (!context.ProjectTBLs.Any())
                    {
                        var Freelancer = await userManager.FindByEmailAsync("Ayman_Elbatata@outlook.com");
                        var ProjectOwner = await userManager.FindByEmailAsync("Ayman_Elbatata@inbox.lt");

                        var Projects = File.ReadAllText("../AymanFreelance.DAL/Contexts/SeedData/Project.json");
                        var ProjectCollection = JsonSerializer.Deserialize<List<ProjectTBL>>(Projects);
                        for (int i = 0; i < ProjectCollection?.Count; i++)
                        {
                            ProjectCollection[i].HashCode = "PRJ" + Guid.NewGuid().ToString("N").Substring(0, 7);
                            ProjectCollection[i].ProjectOwnerTBLId = ProjectOwner.Id;
                            //ProjectCollection[i].ProjectFreelancerTBLId = Freelancer.Id;
                            context.ProjectTBLs.Add(ProjectCollection[i]);
                        }
                        await context.SaveChangesAsync();
                    }

                    if (!context.FreelancerRatingTBLs.Any())
                    {
                        var Freelancer = await userManager.FindByEmailAsync("Ayman_Elbatata@outlook.com");
                        var ProjectOwner = await userManager.FindByEmailAsync("Ayman_Elbatata@inbox.lt");
                        for (int i = 1; i < 5; i++)
                        {
                            context.FreelancerRatingTBLs.Add(new FreelancerRatingTBL { AppUserWhoRatedId = ProjectOwner.Id, AppUserWhoIsRatedId = Freelancer.Id, Stars = i, ProjectTBLId = i, ReviewSubject = "Good Work: " + i, ReviewComment = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book." + i, IsHelpful = (i == 2 || i == 4) ? true : false });
                        }
                        await context.SaveChangesAsync();
                    }
                    if (!context.ProjectApplicationTBLs.Any())
                    {
                        var Freelancer = await userManager.FindByEmailAsync("Ayman_Elbatata@outlook.com");
                        for (int i = 1; i < 2; i++)
                        {
                            context.ProjectApplicationTBLs.Add(new ProjectApplicationTBL { AppUserWhoWroteId = Freelancer.Id, ProjectTBLId = i, DaysOfDelivery = i, PaymentInAdvance = 50 + (i * 5), Cost = 300 + (i*10), Message = "to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.." + i,  });
                        }
                        await context.SaveChangesAsync();
                    }

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AymanFreelanceDbContext>();
                logger.LogError(ex.Message);
            }
        }



    }
}
