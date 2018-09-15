using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Website.Startup))]

namespace Website
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            var physicalFileSystem = new PhysicalFileSystem(Path.Combine(root, "wwwroot"));

            //Map requests from the root to wwwroot (i.e. /index.html -> /wwwroot/index.html)
            var options = new FileServerOptions
            {
                RequestPath = PathString.Empty,
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = false;
            app.UseFileServer(options);

            //Map requests from wwwroot to wwwroot (i.e. wwwroot/index.html -> /wwwroot/index.html)
            //This is only required is you want to use the built-in ASP.NET bundling for something
            var options2 = new FileServerOptions
            {
                RequestPath = PathString.FromUriComponent("/wwwroot"),
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };

            options2.StaticFileOptions.FileSystem = physicalFileSystem;
            options2.StaticFileOptions.ServeUnknownFileTypes = false;
            app.UseFileServer(options2);
        }
    }
}