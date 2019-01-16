using HtmlAgilityPack;
using Liberator.DynamicPageEngine.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace Liberator.DynamicPageEngine.Scan
{
    public class HTMLScanner
    {

        public IXPathNavigable CurrentWebElement { get; set; }


        public IXPathNavigable PageBody { get; set; }


        public IXPathNavigable CurrentXmlElement { get; set; }


        public List<PageObjectEntry> PageObjects { get; set; }


        public IXPathNavigable PageDocument { get; set; }


        public HtmlDocument HtmlDocument { get; set; }


        public HtmlNodeCollection Nodes { get; set; }


        public void ScanHtmlPage(string htmlDocument)
        {
            HtmlDocument = new HtmlDocument();
            HtmlDocument.LoadHtml(htmlDocument);
            PageDocument = GetBody();
        }


        public HtmlNodeCollection GetListOfNodesByTag(string tag)
        {
            try
            {
                Nodes = HtmlDocument.DocumentNode.SelectNodes("//" + tag);
                return Nodes;
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Could not find {0} element. Error found: {1}", tag, e.Message));
            }
            return null;
        }

        /// <summary>
        /// Obtains a collection of Page Object Entries given the tag name applied.
        /// </summary>
        /// <param name="tags">A list of HTML tags to search for.</param>
        /// <returns>A list of Page Object Entries that represent HTML Nodes.</returns>
        public List<PageObjectEntry> GetPageObjects(string[] tags)
        {
            PageObjects = new List<PageObjectEntry>();

            for (int n = 0; n < tags.Length; n++)
            {
                HtmlNodeCollection htmlNodes = HtmlDocument.DocumentNode.SelectNodes("//" + tags[n]);
                foreach (HtmlNode htmlNode in htmlNodes)
                {
                    IEnumerable<string> classes = new List<string>();
                    
                    PageObjects.Add(
                        new PageObjectEntry()
                        {
                            ClassName = GetClassesAsList(htmlNode),
                            CssSelector = GetCssSelector(htmlNode),
                            Id = htmlNode.Id != "" ? htmlNode.Id : null,
                            Link = GetHref(htmlNode),
                            TagName = htmlNode.Name != "" ? htmlNode.Name : null,
                            XPath = htmlNode.XPath != "" ? htmlNode.XPath : null
                        });
                }
            }
            return PageObjects;
        }
       
        string GetHref (HtmlNode htmlNode)
        {
            string href = string.Empty;
            if (htmlNode.Name == "a")
            {
                if (htmlNode.Attributes.Contains("href"))
                {
                    href = htmlNode.Attributes["href"].Value;
                }
            }
            return href;
        }

        /// <summary>
        /// Calculates the CSS Selector for a node, or returns null if the node has no classes.
        /// </summary>
        /// <param name="htmlNode">The HTML node for which a CSS Selector is to be obtained.</param>
        /// <returns>The CSS Selector as a string.</returns>
        string GetCssSelector (HtmlNode htmlNode)
        {
            string cssSelector = string.Empty;
            if (htmlNode.Attributes.Contains("class"))
            {
                IEnumerable<string> cssClasses = htmlNode.GetClasses();
                foreach (string cssClass in cssClasses)
                {
                    cssSelector += "." + cssClass;
                }
            }
            return cssSelector;
        }

        /// <summary>
        /// Obtains a list of classes for a given node, or returns null if the node has no classes.
        /// </summary>
        /// <param name="htmlNode">The HTML node for which a list of classes is to be obtained.</param>
        /// <returns>A enumerable collection of class names.</returns>
        IEnumerable<string> GetClassesAsList(HtmlNode htmlNode)
        {
            if (htmlNode.Attributes.Contains("class"))
            {
                var classes = htmlNode.GetClasses();
                return classes;
            }
            return null;
        }

        IXPathNavigable GetBody()
        {
            try
            {
                PageBody = HtmlDocument.DocumentNode.SelectSingleNode("//body");
                return PageBody;
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Could not find body element. Error found: {0}", e.Message));
            }
            return null;
        }


        XmlDocument InitialiseXmlDocument()
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
