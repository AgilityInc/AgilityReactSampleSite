using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Extensions
{
    public static class SiteMapNodeExtensions
    {
        public static bool IsVisibleInMenu(this SiteMapNode node)
        {
            return node["MenuVisible"] == null || Boolean.Parse(node["MenuVisible"]);
        }

        public static bool IsVisibleInSitemap(this SiteMapNode node)
        {
            return node["SitemapVisible"] == null || Boolean.Parse(node["SitemapVisible"]);
        }
    }
}