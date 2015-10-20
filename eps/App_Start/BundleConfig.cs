using System.Web;
using System.Web.Optimization;

namespace EPS
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Scripts/jquery-ui-1.11.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/SignData").Include(
                      "~/Scripts/SignbyCard.js"));

            //bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            //           "~/Scripts/angular.js",
            //           "~/Scripts/angular-messages.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/angularApp").Include(
            //           "~/Scripts/App/app.module.js",
            //           "~/Scripts/App/vCheckList.controller.js",
            //           "~/Scripts/App/vCheckList.service.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryuicss").Include(
                     "~/Content/jquery-ui.css"));
        }
    }
}
