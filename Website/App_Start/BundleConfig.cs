
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace Website.App_Start
{
	public class BundleConfig
	{
		internal static void RegisterBundles(BundleCollection bundles)
		{


			bundles.Add(new StyleBundle("~/bundles/css")
				.Include(
                    "~/wwwroot/css/bootstrap.css",
                    "~/wwwroot/css/bootstrap-theme.css",
                    "~/wwwroot/css/font-awesome.min.css",
                    "~/wwwroot/css/site.css"
                    )
				);


			bundles.Add(new ScriptBundle("~/bundles/vendor")
				.Include("~/wwwroot/js/vendor/jquery-1.10.2.js",
                        "~/wwwroot/js/vendor/bootstrap.js",
                        "~/wwwroot/js/vendor/Agility.js",
                        "~/wwwroot/js/vendor/Agility.UGC.API.js",
                        "~/wwwroot/js/vendor/Agility.CMS.API.js")    
			);

            bundles.Add(new BabelBundle("~/bundles/components")
                    .IncludeDirectory("~/wwwroot/js/components", "*.jsx")
            );


            if (string.Equals(ConfigurationManager.AppSettings["EnableMinification"], "true", StringComparison.CurrentCultureIgnoreCase))
			{
				BundleTable.EnableOptimizations = true;
			}
			else
			{
				BundleTable.EnableOptimizations = false;
			}

		}
	}
}