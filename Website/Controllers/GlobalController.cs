using Agility.UGC.API.WCF;
using Agility.UGC.API.WCF.AgilityUGC;
using Agility.Web;
using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using React.Web.Mvc;
using Website.Extensions;
using Website.ViewModels;
using Agility.Web.Objects;

namespace Website.Controllers
{
    public class GlobalController : Controller
    {
        

        public ActionResult GlobalHeader()
        {

            var header = new AgilityContentRepository<GlobalHeader>("GlobalHeader").Item("");

            var viewModel = new GlobalHeaderViewModel();
            viewModel.GlobalHeader = header.ToFrontendProps();
            viewModel.Menu = new List<Link>();

            if (SiteMap.Provider.RootNode != null)
            {
                foreach(AgilitySiteMapNode node in SiteMap.Provider.RootNode.ChildNodes)
                {
                    if(node.IsVisibleInMenu())
                    {
                        viewModel.Menu.Add(new Link() { Url = node.Url.Replace("~", ""), Title = node.Title, Target = node.Target });
                    }
                }
            }

            return new ReactActionResult("Components.Global_Header", viewModel);
        }

        public ActionResult GlobalFooter()
        {
            var footer = new AgilityContentRepository<GlobalFooter>("GlobalFooter").Item("");
            return PartialView("~/Views/Shared/Footer.cshtml", footer);
        }

        

    }
}
