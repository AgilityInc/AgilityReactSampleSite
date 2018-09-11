using Agility.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class GlobalHeaderViewModel
    {
        public GlobalHeader GlobalHeader { get; set; }
        public List<Link> Menu { get; set; }
    }

    public class Link
    {
        public string Url { get; set; }
        public string Target { get; set; }
        public string Title { get; set; }
    }
}