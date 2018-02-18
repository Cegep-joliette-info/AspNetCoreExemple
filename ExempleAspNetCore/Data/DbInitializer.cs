using ExempleAspNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExempleAspNetCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.Migrate();

            _Initialize(context, userManager, roleManager).Wait();
        }


        private static async Task _Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            #region SeedUsersAndGroups
            if (!userManager.Users.Any() && !roleManager.Roles.Any())
            {
                // Admin
                string AdminEmail = "admin@edusite.com";
                string AdminRole = "Admin";

                await userManager.CreateAsync(new ApplicationUser
                {
                    Email = AdminEmail,
                    UserName = AdminEmail
                }, "admin");

                await roleManager.CreateAsync(new IdentityRole(AdminRole));

                await userManager.AddToRoleAsync(userManager.FindByEmailAsync(AdminEmail).Result, AdminRole);

                // Student
                string StudentEmail = "student@edusite.com";

                await userManager.CreateAsync(new ApplicationUser
                {
                    Email = StudentEmail,
                    UserName = StudentEmail
                }, "student");
            }
            #endregion
        }
    }
}
