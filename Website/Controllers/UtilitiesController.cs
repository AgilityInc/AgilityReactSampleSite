using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class UtilitiesController : Controller
    {
        

        public ActionResult GetTourPopoverHTML(string referenceName)
        {
            //use filename (without .html) as reference nam

            string path = string.Format("~/Views/Tour/{0}.html", referenceName);

            return new FilePathResult(path, "text/html");
        }

    }
}
