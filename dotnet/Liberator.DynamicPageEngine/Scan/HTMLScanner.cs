using HtmlAgilityPack;
using Liberator.DynamicPageEngine.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml.XPath;

namespace Liberator.DynamicPageEngine.Scan
{
    public class HTMLScanner
    {
        /// <summary>
        /// The body of the page being scanned
        /// </summary>
        public IXPathNavigable PageBody { get; set; }

        /// <summary>
        /// A list of Page Objects for use in other objects
        /// </summary>
        public List<PageObjectEntry> PageObjects { get; set; }

        /// <summary>
        /// The body of the HTML document under consideration
        /// </summary>
        public IXPathNavigable Body { get; set; }

        /// <summary>
        /// The HTML document under consideration
        /// </summary>
        public HtmlDocument HtmlDocument { get; set; }

        /// <summary>
        /// The collection of nodes currently under consideration
        /// </summary>
        public HtmlNodeCollection Nodes { get; set; }

        /// <summary>
        /// Scans an HTML page, populates the instance variables and outputs a list of PageObjects.
        /// </summary>
        /// <param name="htmlDocument">The HTML document under consideration.</param>
        /// <returns>A list of page object entries.</returns>
        public List<PageObjectEntry> ScanHtmlPage(string htmlDocument)
        {
            HtmlDocument = new HtmlDocument();
            HtmlDocument.LoadHtml(htmlDocument);
            Body = GetBody();
            GetObjectsWithIdentifyingAttributes();
            return PageObjects;
        }

        /// <summary>
        /// Obtains a collection of Page Object Entries given the tag name applied.
        /// </summary>
        /// <returns>A list of Page Object Entries that represent HTML Nodes.</returns>
        List<PageObjectEntry> GetPageObjects()
        {
            IEnumerable<HtmlNode> htmlNodes = HtmlDocument.DocumentNode.SelectSingleNode("//body").Descendants();
            if (htmlNodes != null)
            {
                foreach (HtmlNode htmlNode in htmlNodes)
                {
                    if (htmlNode.Id != "" ||
                        htmlNode.Name.Contains("frame") ||
                        htmlNode.Name.Contains("form") ||
                        htmlNode.Name.Contains("input") ||
                        htmlNode.Attributes.Contains("name") ||
                        htmlNode.Attributes.Contains("target") ||
                        htmlNode.Attributes.Contains("class") ||
                        htmlNode.Attributes.Contains("href") ||
                        htmlNode.Attributes.Contains("src")
                        )
                    {
                        PopulatePageObject(htmlNode);
                    }

                }
            }
            return PageObjects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlNode"></param>
        void PopulatePageObject(HtmlNode htmlNode)
        {
            PageObjects.Add(
                   new PageObjectEntry()
                   {
                       ClassName = GetClassesAsList(htmlNode),
                       CssSelector = GetCssSelector(htmlNode),
                       Id = htmlNode.Id != "" ? htmlNode.Id : null,
                       Link = GetHref(htmlNode),
                       NameAttribute = htmlNode.Attributes.Contains("name") ? htmlNode.Attributes["name"].Value : null,
                       ObjectName = GetObjectName(htmlNode),
                       TagName = htmlNode.Name != "" ? htmlNode.Name : null,
                       XPath = htmlNode.XPath != "" ? htmlNode.XPath : null
                   });
        }

        string GetObjectName(HtmlNode htmlNode)
        {
            if (htmlNode.Id != "") { return htmlNode.Id; }

            switch (htmlNode.Name)
            {
                case "a":
                    return htmlNode.Id != "" ? htmlNode.Id : "";
                case "applet":
                    return htmlNode.Attributes["code"].Value.Replace(".", "");
                case "area":
                    return htmlNode.Attributes["alt"].ValueLength > 0 ?
                        htmlNode.Attributes["alt"].Value :
                        htmlNode.Attributes["href"].Value.Replace(".", "");
                case "audio":
                case "script":
                case "embed":
                    return htmlNode.Attributes["src"].Value.Replace("/", "").Replace(".", "");
                case "button":
                case "textarea":
                    return htmlNode.Attributes.Contains("name") ?
                        htmlNode.Attributes["name"].Value : null;
                case "data":
                    return htmlNode.Attributes["value"].Value + htmlNode.InnerText;
                case "div":
                    return htmlNode.Attributes.Contains("target") ?
                        htmlNode.Attributes["target"].Value : null;
                case "fieldset":
                case "map":
                    return htmlNode.Attributes["name"].Value;
                case "frame":
                case "iframe":
                case "input":
                    return htmlNode.Attributes.Contains("name") ?
                        htmlNode.Attributes["name"].Value :
                        htmlNode.Attributes["src"].Value.Replace("/", "").Replace(".", "");
                case "h1":
                case "h2":
                case "h3":
                case "h4":
                case "h5":
                case "h6":
                    return htmlNode.Attributes.Contains("title") ?
                        htmlNode.Attributes["title"].Value :
                        htmlNode.InnerText.Replace(" ", "");
                case "img":
                    return htmlNode.Attributes.Contains("src") ?
                        htmlNode.Attributes["src"].Value.Replace("/", "").Replace(".", "") :
                        htmlNode.Attributes["alt"].Value;
                case "li":
                case "option":
                    return htmlNode.Attributes.Contains("value") ?
                        htmlNode.Attributes["value"].Value :
                        htmlNode.InnerText.Replace(" ", "");
                case "meter":
                case "nav":
                    return htmlNode.Attributes.Contains("title") ?
                        htmlNode.Attributes["title"].Value :
                        htmlNode.Attributes["alt"].Value;
                case "object":
                    return htmlNode.Attributes.Contains("name") ?
                        htmlNode.Attributes["name"].Value :
                        htmlNode.Attributes["data"].Value.Replace("/", "").Replace(".", "");
                case "optgroup":
                    return htmlNode.Attributes.Contains("label") ?
                        htmlNode.Attributes["label"].Value.Replace(" ", "") :
                        htmlNode.Attributes["title"].Value;
                case "picture":
                case "progress":
                case "ruby":
                case "section":
                case "span":
                case "template":
                    return htmlNode.Attributes.Contains("title") ?
                        htmlNode.Attributes["title"].Value : null;
                case "select":
                    return htmlNode.Attributes.Contains("name") ?
                        htmlNode.Attributes["name"].Value :
                        htmlNode.Attributes["title"].Value;
                case "source":
                    return htmlNode.Attributes.Contains("src") ?
                        htmlNode.Attributes["src"].Value.Replace("/", "").Replace(".", "") :
                        htmlNode.Attributes["title"].Value;
                case "track":
                    return htmlNode.Attributes.Contains("src") ?
                        htmlNode.Attributes["src"].Value.Replace("/", "").Replace(".", "") :
                        htmlNode.Attributes["label"].Value;
                case "video":
                    return htmlNode.Attributes.Contains("src") ?
                        htmlNode.Attributes["src"].Value.Replace("/", "").Replace(".", "") : null;
            }
            return null;
        }

        List<PageObjectEntry> GetObjectsWithIdentifyingAttributes()
        {
            PageObjects = new List<PageObjectEntry>();
            GetPageObjects();
            return PageObjects;
        }

        /// <summary>
        /// Gets the HREF of a hyperlink.
        /// </summary>
        /// <param name="htmlNode">The hyperlink to investigate.</param>
        /// <returns>The HREF of node.</returns>
        string GetHref(HtmlNode htmlNode)
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
        string GetCssSelector(HtmlNode htmlNode)
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

        /// <summary>
        /// Gets the body of the page under investigation.
        /// </summary>
        /// <returns>The body of the page under investigation.</returns>
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
    }
}
