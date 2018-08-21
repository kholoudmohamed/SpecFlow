using SpecFlow.BaseFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace SpecFlow.Utilities
{
    public class GetData
    {
        // Data.xml file doc
        public static XDocument Doc => XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["XmlDataFilePath"]);

        // App.Config file data
        public static string BaseAddress => ConfigurationManager.AppSettings["BaseURL"];

        // Get URL using tag from Data.xml file
        public static string UrlOf(Pages pageName)
        {
            var doc = Doc.Descendants("pageInfo");
            var xElements = doc as IList<XElement> ?? doc.ToList();
            return
                xElements.Where(c => c.Attribute("tag").Value.Equals(pageName.ToString()))
                    .Select(s => s.Attribute("url").Value)
                    .FirstOrDefault();
        }

        // Get header of page from Data.xml file
        public static string ExpectedHeader()
        {
            try
            {
                var expected = Doc.Descendants("pageInfo").Where(c => c.Attribute("url").Value.Equals(CurrentRelativeUrl)).Select(s => s.Attribute("header").Value).FirstOrDefault() ??
                          Doc.Descendants("pageInfo").Where(c => c.Attribute("url").Value.Equals(CurrentRelativeUrl.Substring(0, CurrentRelativeUrl.LastIndexOf('/')))).Select(s => s.Attribute("header").Value).FirstOrDefault();
                return expected;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Relative Current URL
        public static string CurrentRelativeUrl => Driver.Browser.Url.Split(new string[] { "aamlive.com" }, StringSplitOptions.None).Last();
    }
}
