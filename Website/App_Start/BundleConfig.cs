
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
					"~/Content/css/bootstrap.css",
                    "~/Content/css/bootstrap-theme.css",
					"~/Content/css/font-awesome.min.css",
					"~/Content/css/site.css"
					)
				);


			bundles.Add(new ScriptBundle("~/bundles/core")
				.Include("~/Scripts/jquery-1.10.2.js",
						"~/Scripts/bootstrap.js",
						"~/Scripts/Agility.js",
						"~/Scripts/Agility.UGC.API.js",
						"~/Scripts/Agility.CMS.API.js")    
			);

            bundles.Add(new BabelBundle("~/bundles/react")
                    .IncludeDirectory("~/Scripts/React", "*.jsx")
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