using Agility.Web;
using Agility.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Website.Extensions
{
    public static class AgilityContentItemExtensions
    {
        public static bool IsAnchorTag(string value)
        {
            //test for anchor tag
            return value.StartsWith("<a href") && value.EndsWith("</a>");
        }

        public static dynamic ToDynamic(this AgilityContentItem ci)
        {
            var dynamicObj = new ExpandoObject() as IDictionary<string, Object>;
            DataColumnCollection columns = ci.Row.Table.Columns;
            
            //write each column into our dynamic obj
            foreach (var col in columns)
            {
                string colName = col.ToString();
                var objValue = ci[colName];

                //specific cases with a string
                if (objValue is string)
                {
                    //have to test whether this is an attachment
                    //TODO: need a more performant way to do this
                    var attachment = ci.GetAttachment(colName);

                    if (attachment != null)
                    {
                        objValue = attachment;
                    }
                    //test whether this is a UrlField
                    else if (IsAnchorTag(objValue as string))
                    {
                        objValue = ci.ParseUrl(colName);
                    }
                }

                dynamicObj.Add(colName, objValue);
            }

            return dynamicObj;
        }
    }
}