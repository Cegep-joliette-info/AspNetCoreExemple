using System;
using ExempleAspNetCore.Data;
using ExempleAspNetCore.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExempleAspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
                UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                DbInitializer.Initialize(context, userManager, roleManager);
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
