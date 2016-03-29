using System.Web;
using System.Web.Optimization;

namespace IEJPApps
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularui").Include(
                      "~/Scripts/angular-ui-router.js",
                      "~/Scripts/ui-bootstrap/ui-bootstrap-tpls-1.2.5.min.js",
                      "~/Scripts/angular-translate/angular-translate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/App/app.js",
                      "~/App/app-services/*.js",
                      "~/App/account/*.js",
                      "~/App/pages/*.js",
                      "~/App/home/*.js",
                      "~/App/projects/*.js",
                      "~/App/employees/*.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}