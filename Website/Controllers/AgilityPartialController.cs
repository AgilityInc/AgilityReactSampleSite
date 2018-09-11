using Agility.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class AgilityPartialController : Controller
    {
        // GET: AgilityPartial
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderPartialPage(string path)
        {
            return new AgilityViewActionResult(path);
        }


        
    }
}