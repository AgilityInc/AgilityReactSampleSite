
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
            
            //legacy global bundle
			bundles.Add(new StyleBundle("~/bundles/vendor-css")
				.Include(
                    "~/wwwroot/dist/css/bootstrap.css",
                    "~/wwwroot/dist/css/bootstrap-theme.css",
                    "~/wwwroot/dist/css/site.css"
                    )
				);

            //styles from webpack...
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                    "~/wwwroot/dist/styles.css"
                    )
                );

            //legacy vendor bundle
            bundles.Add(new ScriptBundle("~/bundles/vendor")
                .Include("~/wwwroot/dist/vendor/jquery-1.10.2.js",
                        "~/wwwroot/dist/vendor/bootstrap.js",
                        "~/wwwroot/dist/vendor/Agility.js",
                        "~/wwwroot/dist/vendor/Agility.UGC.API.js",
                        "~/wwwroot/dist/vendor/Agility.CMS.API.js")
            );

            //js from webpack...
            bundles.Add(new ScriptBundle("~/bundles/client")
                .Include("~/wwwroot/dist/client.js"));


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