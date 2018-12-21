using HtmlAgilityPack;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace Liberator.DynamicPageEngine.Scan
{
    public static class HTMLScanner
    {
        public static IWebElement CurrentWebElement { get; set; }
        public static IWebElement PageElement { get; set; }

        public static IXPathNavigable CurrentXmlElement { get; set; }
        public static IXPathNavigable PageDocument { get; set; }

        static HtmlDocument HtmlDocument { get; set; }

        public static IXPathNavigable Body(this IWebDriver webDriver)
        {
            PageElement = webDriver.FindElement(By.TagName("body"));

            CurrentWebElement = null;
            CurrentXmlElement = null;

            HtmlDocument = new HtmlDocument();
            HtmlDocument.LoadHtml(webDriver.PageSource);

            PageDocument = HtmlDocument.DocumentNode.SelectSingleNode("//body");
            return PageDocument;
        }

        public static IEnumerable<IXPathNavigable> FindElementsByTag(this IXPathNavigable body, string tag)
        {
            return ((HtmlNode)body).Descendants(tag);
        }

        public static void Extract(this IEnumerable<IXPathNavigable> elements)
        {
            XmlDocument xmlDocument = InitialiseXmlDocument();

            foreach (IXPathNavigable element in elements)
            {
            }
        }

        private static XmlDocument InitialiseXmlDocument()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmlDocument.DocumentElement;
            xmlDocument.InsertBefore(xmlDeclaration, root);
            PageDocument = xmlDocument;
            return xmlDocument;
        }
    }
}
/* 
        XmlElement element1 = doc.CreateElement( string.Empty, "body", string.Empty );
        doc.AppendChild( element1 );
        doc.Save( "D:\\document.xml" );

     */
