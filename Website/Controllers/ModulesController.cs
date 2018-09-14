using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.Extensions;
using Website.ViewModels;
using Agility.Web;

namespace Website.Controllers
{
    public class ModulesController : Controller
    {
        
        public ActionResult Jumbotron(Module_Jumbotron module)
        {
            
            var viewModel = module.ToReactProps();
            return new ReactActionResult("Components.Module_Jumbotron", viewModel);
        }

        public ActionResult FeaturedContent(Module_FeaturedContent module)
        {
            
            var viewModel = new
            {
                items = module.FeaturedContent.SortByIDs(module.FeaturedContentSortIDs).Select(a => a.ToReactProps()).ToList()
            };

            return new ReactActionResult("Components.Module_FeaturedContent", viewModel);
        }
    }
}