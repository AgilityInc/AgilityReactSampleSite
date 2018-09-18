using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.Extensions;
using Website.ViewModels;
using Agility.Web;
using Agility.Web.Extensions;

namespace Website.Controllers
{
    public class ModulesController : Controller
    {
        public ActionResult FrontendComponent(AgilityContentItem module)
        {
            string componentName = null;
            try
            {
                componentName = module["ComponentName"] as string;
            } catch
            {
                throw new ApplicationException("Module does not implement a field called 'ComponentName', cannot execute React component.");
            }

            //convert the module data to a dynamic object, then convert to front-end props
            var viewModel = module.ToFrontendProps();

            return new ReactActionResult($"Components.{componentName}", viewModel);
        }

        public ActionResult Jumbotron(Module_Jumbotron module)
        {
            
            var viewModel = module.ToFrontendProps();
            return new ReactActionResult("Components.Module_Jumbotron", viewModel);
        }

        public ActionResult FeaturedContent(Module_FeaturedContent module)
        {
            
            var viewModel = new
            {
                items = module.FeaturedContent.SortByIDs(module.FeaturedContentSortIDs).Select(a => a.ToFrontendProps()).ToList()
            };

            return new ReactActionResult("Components.Module_FeaturedContent", viewModel);
        }

        
    }
}