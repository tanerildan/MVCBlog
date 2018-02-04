using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BLOG.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new StyleBundle("~/bundlesLogin/styles").IncludeDirectory("~/LoginTemplate/css", "*.css", true));
            bundles.Add(new StyleBundle("~/bundlesRegister/styles").IncludeDirectory("~/RegisterTemplate/css", "*.css", true));
            bundles.Add(new StyleBundle("~/bundlesAdmin/styles").IncludeDirectory("~/Areas/Dashboard/css", "*.css", true));
            bundles.Add(new StyleBundle("~/bundlesSite/styles").IncludeDirectory("~/SiteTemplate/css", "*.css", true));
           

          
            bundles.Add(new ScriptBundle("~/bundlesLogin/scripts").IncludeDirectory("~/LoginTemplate/js", "*.js", true));
            bundles.Add(new StyleBundle("~/bundlesRegister/scripts").IncludeDirectory("~/RegisterTemplate/js", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundlesAdmin/scripts").IncludeDirectory("~/Areas/Dashboard/js", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundlesSite/scripts").IncludeDirectory("~/SiteTemplate/js", "*.js", true));
           

            BundleTable.EnableOptimizations = true;
        }
    }
}