using System.Web;
using System.Web.Optimization;

namespace Transformation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
          
            bundles.Add(new ScriptBundle("~/Content/Scripts").Include(
                      "~/Content/Scripts/bootstrap.js",
                      "~/Content/Scripts/respond.js",
                      "~/Content/Scripts/functions.js",
                      "~/Content/Scripts/jquery.js",
                      "~/Content/Scripts/plugins.js",
                      "~/Content/Scripts/respond.js",
                      "~/Content/Scripts/star-rating.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/bs-rating.css",
                      "~/Content/css/calendar.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/dark.css",
                      "~/Content/css/et-line.css",
                      "~/Content/css/font-icons.css",
                      "~/Content/css/fonts.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/onepage.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/Site.css",
                      "~/Content/css/style.css"
                      ));
        }
    }
}
