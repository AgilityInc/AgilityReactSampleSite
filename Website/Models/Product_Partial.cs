using Agility.Web;
using Agility.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public partial class Product
    {

        /// <summary>
        /// Returns the dynamic page url for a show
        /// </summary>
        /// <returns>Url for the current show</returns>
        public Uri Url(string url)
        {
            DynamicPageItem d = Data.GetDynamicPageItem(url, ReferenceName, Row);
            return new Uri(
                VirtualPathUtility.ToAbsolute(
                    String.Format("{0}/{1}", url.Substring(0, url.LastIndexOf('/')), d.Name).ToLowerInvariant()
                ), UriKind.Relative
            );
        }

    }
}