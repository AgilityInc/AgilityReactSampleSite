using Agility.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Website
{
	public static class Helpers
	{
		private const string PageTitleKey = "Page-Title";

		public static IHtmlString SetPageTitle(this HtmlHelper<dynamic> helper, string title, bool onlyIfEmpty = false)
		{
			if (!helper.ViewContext.HttpContext.Items.Contains(PageTitleKey))
			{
				helper.ViewContext.HttpContext.Items[PageTitleKey] = string.Empty;
			}

			if (!onlyIfEmpty || string.IsNullOrEmpty((string)helper.ViewContext.HttpContext.Items[PageTitleKey]))
			{
				//build the page title by appending the current Agility Page 

				helper.ViewContext.HttpContext.Items[PageTitleKey] = title;
			}

			return new MvcHtmlString(string.Empty);
		}

		public static IHtmlString GetPageTitle(this HtmlHelper<dynamic> helper)
		{
			string title = helper.ViewContext.HttpContext.Items[PageTitleKey] as string;
			if (!string.IsNullOrEmpty(title))
			{
				title = title.Replace("<br/>", " - ");
			}
			return new MvcHtmlString(title);
		}

        public static IHtmlString SDMSyndicatedHeaderFooterScript(this HtmlHelper<dynamic> helper)
        {
            var langCode = AgilityContext.LanguageCode;
            string url = string.Empty;

            //shoppers or pharmaprix?
            //english of french?

            switch (langCode)
            {
                case "en-qc":
                    url = "http://www1.pharmaprix.ca/en/syndicatedheader/navigation/syndicatedoutput";
                    break;
                
                case "fr-qc":
                    url = "http://www1.pharmaprix.ca/fr/syndicatedheader/navigation/syndicatedoutput";
                    break;

                case "en-ca":
                    url = "http://www1.shoppersdrugmart.ca/en/syndicatedheader/navigation/syndicatedoutput";
                    break;
                
                case "fr-ca":
                    url = "http://www1.shoppersdrugmart.ca/fr/syndicatedheader/navigation/syndicatedoutput";
                    break;

                default:
                    break;
            }

            if (!string.IsNullOrEmpty(url))
            {
                return new MvcHtmlString(string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", url));
            }

            return null;
        }

        public static IHtmlString GetTwitterName(this HtmlHelper helper)
        {
            try
            {
                var lang = AgilityContext.LanguageCode;
                var shoppersCode = lang.Substring(lang.Length - 2, 2);

                string twitterVia = "ShopprsDrugMart"; //shoppers twitter username

                if (string.Compare(shoppersCode, "qc", true) == 0)
                {
                    //is pharmaprix
                    twitterVia = "PharmaprixQC";
                }

                return new MvcHtmlString(twitterVia);
            }
            catch (Exception)
            {
                return new MvcHtmlString("");
            }
        }

        private const string HttpMetaKey = "MetaTags";

        public static void SetHttpMetaVariable(string name, string value)
        {

            Dictionary<string, string> metaDictionary = HttpContext.Current.Items[HttpMetaKey] as Dictionary<string, string>;
            if (metaDictionary == null)
            {
                metaDictionary = new Dictionary<string, string>();
                HttpContext.Current.Items[HttpMetaKey] = metaDictionary;

            }

            metaDictionary[name] = value;
        }

        public static IHtmlString GetHttpMetaVariables(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> ogDictionary = HttpContext.Current.Items[HttpMetaKey] as Dictionary<string, string>;
            if (ogDictionary != null)
            {
                foreach (string key in ogDictionary.Keys)
                {
                    string val = ogDictionary[key];
                    if (string.IsNullOrWhiteSpace(val)) continue;
                    sb.Append(string.Format("<meta name=\"{0}\" content=\"{1}\" />", key, val.Replace("\"", "'")));
                }
            }


            return new MvcHtmlString(sb.ToString());
        }

        
	}
}