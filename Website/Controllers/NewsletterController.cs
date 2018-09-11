using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class NewsletterController : Controller
    {


        public ActionResult NewsletterSignupModal(Module_NewsletterSignupModal module)
        {
            return PartialView(module);
        }

    }
}
