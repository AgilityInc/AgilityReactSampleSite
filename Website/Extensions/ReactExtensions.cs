using Agility.Web;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Website.Extensions
{
    public static class ReactExtensions
    {
        public static List<string> PropsToIgnore = new List<string>()
        {
            "CreatedDate",
            "ModifiedDate",
            "ReleaseDate",
            "PullDate",
            "State",
            "LanguageCode",
            "VersionID",
            "ContentID",
            "EnablePersonalization",
            "Tags",
            "Row",
            "ContentReferenceName",
            "Item"
        };

        public static string DefaultKeyProperty = "ContentID";

        public static bool IsValueALink(object value, out object linkObj)
        {
            linkObj = null;
            if (value is String)
            {
                //test for anchor tag
                String str = value as string;
                if (str.Contains("<a href"))
                {
                    var link = new
                    {
                        title = Data.UrlEval(str, "title"),
                        url = Data.UrlEval(str, "url"),
                        target = Data.UrlEval(str, "target")
                    };

                    linkObj = link;
                    return true;
                }
            }

            return false;
        }

        public static object ToReactProps(this object o)
        {
            var result = new ExpandoObject() as IDictionary<string, Object>;

            Type oType = o.GetType();
            string key = null;

            foreach(PropertyInfo propertyInfo in oType.GetProperties())
            {
                if(propertyInfo.CanRead)
                {
                    string propName = propertyInfo.Name;

                    if (propertyInfo.Name.Equals(DefaultKeyProperty))
                    {
                        key = propertyInfo.GetValue(o).ToString();
                    }

                    //skip the props to ignore
                    if (PropsToIgnore.Contains(propertyInfo.Name))
                    {
                        continue;
                    }

                    var value = propertyInfo.GetValue(o);

                    object linkObj = null;

                    //test for anchor tag
                    if (IsValueALink(value, out linkObj))
                    {
                        //split link filed into its own object
                        result.Add(propName, linkObj);      
                    }
                    else
                    {
                        //standard value
                        result.Add(propName, value);
                    }
                    
                }
            }

            if (!string.IsNullOrEmpty(key))
            {
                result.Add("Key", key);
            }

            return result;
        }
    }
}