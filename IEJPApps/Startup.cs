﻿using IEJPApps.Infrastructure;
using IEJPApps.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IEJPApps.Startup))]
namespace IEJPApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Diagnostics.Trace.WriteLine("MVC Version: {0}", typeof(System.Web.Mvc.Controller).Assembly.GetName().Version.ToString());
            ConfigureAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);

            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            CreateUserRole(roleManager, UserRoles.Admin);
            CreateUserRole(roleManager, UserRoles.Employee);

            CreateSuperUser(userManager, roleManager);
        }

        private static void CreateUserRole(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole
                {
                    Name = role
                });
            }
        }

        private static void CreateSuperUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string superUserName = "admin@iejp.com";
            const string superUserPaswd = "Admin1!";

            var userExists = userManager.FindByName(superUserName);
            if (userExists == null)
            {
                // Here we create a Admin super user who will maintain the website
                var user = new ApplicationUser
                {
                    UserName = superUserName,
                    Email = superUserName
                };

                if (userManager.Create(user, superUserPaswd).Succeeded)
                {
                    userManager.AddToRole(user.Id, UserRoles.Admin);
                }
            }
        }
    }
}