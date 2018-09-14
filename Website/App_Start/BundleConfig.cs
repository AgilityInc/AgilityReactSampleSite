
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
                    "~/wwwroot/dist/css/bootstrap.css",
                    "~/wwwroot/dist/css/bootstrap-theme.css",
                    "~/wwwroot/dist/css/font-awesome.min.css",
                    "~/wwwroot/dist/css/site.css"
                    )
				);


            bundles.Add(new ScriptBundle("~/bundles/vendor.js")
                .Include("~/wwwroot/dist/vendor/jquery-1.10.2.js",
                        "~/wwwroot/dist/vendor/bootstrap.js",
                        "~/wwwroot/dist/vendor/Agility.js",
                        "~/wwwroot/dist/vendor/Agility.UGC.API.js",
                        "~/wwwroot/dist/vendor/Agility.CMS.API.js")
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