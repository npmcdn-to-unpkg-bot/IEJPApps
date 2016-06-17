using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IEJPApps.Services;

namespace IEJPApps
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var cookieService = DependencyResolver.Current.GetService<ICookieService>();

            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cookieService.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cookieService.Language);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }
    }
}