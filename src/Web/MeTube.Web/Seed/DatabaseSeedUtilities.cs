using MeTube.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Web.Seed
{
    public static class DatabaseSeedUtilities
    {
        public static void SeedRoles(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                using (var metubeDbContext = serviceScope.ServiceProvider.GetRequiredService<MeTubeDbContext>())
                {
                    metubeDbContext.Database.Migrate();

                    if (metubeDbContext.Roles.ToList().Count == 0)
                    {
                        IdentityRole adminRole = new IdentityRole();
                        adminRole.Name = "Admin";
                        adminRole.NormalizedName = adminRole.Name.ToUpper();

                        IdentityRole userRole = new IdentityRole();
                        userRole.Name = "User";
                        userRole.NormalizedName = userRole.Name.ToUpper();

                        metubeDbContext.Add(adminRole);
                        metubeDbContext.Add(userRole);

                        metubeDbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
