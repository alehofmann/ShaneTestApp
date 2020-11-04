using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ShaneSampleApp
{
    public static class ExtensionMethods
    {
        public static string TryGetElementValue(this XElement parentElement, string elementName, string defaultValue = "NOT_FOUND")
        {
            var returnElement = parentElement.Element(elementName);

            if (returnElement != null)
            {
                return returnElement.Value;
            }

            return defaultValue;
        }
    }
}