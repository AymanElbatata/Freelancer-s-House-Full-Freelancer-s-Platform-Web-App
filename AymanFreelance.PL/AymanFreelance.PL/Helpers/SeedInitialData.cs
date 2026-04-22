using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.PL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AymanFreelance.PL.Helpers
{
    public class SeedInitialData
    {
        public static async void SeedData(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<AymanFreelanceDbContext>();
                    await context.Database.MigrateAsync();

                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

                    await AymanFreelanceDbContextSeed.SeedAsync(context, userManager, roleManager, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex.Message);
                }

            }
        }
    }
}
