using System.Data.Entity;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using IEJPApps.Models;
using IEJPApps.Models.Infrastructure;
using IEJPApps.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace IEJPApps
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext, ApplicationDbContext>(new TransientLifetimeManager());

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new TransientLifetimeManager());
            container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(new TransientLifetimeManager());

            container.RegisterType<ApplicationUserManager>(new TransientLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<ApplicationSignInManager>(new TransientLifetimeManager());
            container.RegisterType<ApplicationRoleManager>(new TransientLifetimeManager());

            container.RegisterType<ICookieService, CookieService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITimeService, TimeService>(new ContainerControlledLifetimeManager());
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}