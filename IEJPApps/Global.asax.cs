using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //CultureInfo ci = new CultureInfo("fr"); // TODO: Allow switching languages

            //System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }
    }
}
