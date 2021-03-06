using Newtonsoft.Json.Serialization;
using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Website.ReactConfig), "Configure")]

namespace Website
{
	public static class ReactConfig
	{
		public static void Configure()
		{
            // If you want to use server-side rendering of React components, 
            // add all the necessary JavaScript files here. This includes 
            // your components as well as all of their dependencies.
            // See http://reactjs.net/ for more information. Example:
            //ReactSiteConfiguration.Configuration
            //	.AddScript("~/Scripts/First.jsx")
            //	.AddScript("~/Scripts/Second.jsx");

            // If you use an external build too (for example, Babel, Webpack,
            // Browserify or Gulp), you can improve performance by disabling 
            // ReactJS.NET's version of Babel and loading the pre-transpiled 
            // scripts. Example:
            ReactSiteConfiguration.Configuration
                .SetLoadBabel(false)
                .AddScriptWithoutTransform("~/wwwroot/dist/server.js");

            //We are adding our own via webpack
            ReactSiteConfiguration.Configuration.LoadReact = false;

            //Tell the react config to use camelcase for property names
            ReactSiteConfiguration.Configuration.SetJsonSerializerSettings(new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            //ReactSiteConfiguration.Configuration
            //    .AddScript("~/wwwroot/js/components/Module_Jumbotron.jsx")
            //    .AddScript("~/wwwroot/js/components/Module_FeaturedContent.jsx")
            //    .AddScript("~/wwwroot/js/components/Global_Header.jsx");

            //ReactSiteConfiguration.Configuration.DisableServerSideRendering();
        }
	}
}