using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IEJPApps.Services;
using IEJPApps.Services.Interfaces;

namespace IEJPApps
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ServiceConfig.RegisterServices(new StandardKernel());
            //ServiceLocator.Initialize();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //var cookieService = ServiceLocator.Get<ICookieService>();
            ICookieService cookieService = new CookieService();
            cookieService.Load();

            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cookieService.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cookieService.Language);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //CookieService.Save();
        }
    }
}