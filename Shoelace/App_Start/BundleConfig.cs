using System.Web;
using System.Web.Optimization;

namespace Shoelace
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BUNDLE:   ~/bundles/jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //BUNDLE:   ~/bundles/jqueryui
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            //BUNDLE:   ~/bundles/jqueryval
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            //BUNDLE:   ~/bundles/knockout
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/knockout.mapping-latest.js"));

            //BUNDLE:   ~/bundles/ajaxlogin
            bundles.Add(new ScriptBundle("~/bundles/ajaxlogin").Include(
                "~/Scripts/app/ajaxlogin.js"));



            //JEH: This is what I want to replace with something else....
            //BUNDLE:   ~/bundles/todo
            bundles.Add(new ScriptBundle("~/bundles/todo").Include(
                "~/Scripts/app/todo.bindings.js",
                "~/Scripts/app/todo.datacontext.js",
                "~/Scripts/app/todo.model.js",
                "~/Scripts/app/todo.viewmodel.js"));

            //BUNDLE:   ~/bundles/bootstrap/js
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap/js/bootstrap.js")
                );

            //BUNDLE:   ~/bundles/modernizr
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //BUNDLE:   ~/bundles/bootstrap/css
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Scripts/bootstrap/css/bootstrap.min.css",
                "~/Scripts/bootstrap/css/bootstrap-responsive.min.css"));

            //BUNDLE:   ~/Content/css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Styles.css"));

            //BUNDLE:   ~/Content/themes/base/css
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            Add_AppScripts(bundles);
            Add_TopnavScripts(bundles);
        }
        private static void Add_AppScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                "~/Scripts/app/app.js")
                );
        }
        private static void Add_TopnavScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Shared/TopNav").Include(
                "~/Scripts/app/Views/Shared/navbartop.viewmodel.js")
                );
        }


    }
}