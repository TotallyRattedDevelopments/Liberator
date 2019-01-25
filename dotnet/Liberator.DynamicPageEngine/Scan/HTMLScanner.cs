using HtmlAgilityPack;
using Liberator.DynamicPageEngine.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace Liberator.DynamicPageEngine.Scan
{
    /// <summary>
    /// Used to scan an html page to retrieve the page objects that Selenium can use for identification
    /// </summary>
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
        /// Populates a PageObjectEntry with the data from the scanned HTML nodes.
        /// </summary>
        /// <param name="htmlNode">The node to add to the PageObject collection.</param>
        void PopulatePageObject(HtmlNode htmlNode)
        {
            PageObjects.Add(
                   new PageObjectEntry()
                   {
                       ClassNames = GetClassesAsList(htmlNode),
                       CssSelector = GetCssSelector(htmlNode),
                       Id = htmlNode.Id != "" ? htmlNode.Id : null,
                       Link = GetHref(htmlNode),
                       NameAttribute = htmlNode.Attributes.Contains("name") ? htmlNode.Attributes["name"].Value : null,
                       ObjectName = GetObjectName(htmlNode),
                       TagName = htmlNode.Name != "" ? htmlNode.Name : null,
                       XPath = htmlNode.XPath != "" ? htmlNode.XPath : null
                   });
        }

        /// <summary>
        /// Creates a custom object name from available data.
        /// </summary>
        /// <param name="htmlNode">The node for which a name is required.</param>
        /// <returns>A name to use for the object.</returns>
        string GetObjectName(HtmlNode htmlNode)
        {
            if (htmlNode.Id != "")
                return htmlNode.Id;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string nodeTitle = textInfo.ToTitleCase(htmlNode.Name) + "_";

            switch (htmlNode.Name)
            {
                case "a":
                    return htmlNode.Attributes.Contains("href") ?
                        "Link_" + CalculateNameBasedOnSource(htmlNode.Attributes["href"].Value)
                        : "Link_" + ConvertClassIntoName(htmlNode);
                case "applet":
                    return nodeTitle + htmlNode.Attributes["code"].Value.Replace(".", "");
                case "area":
                    return htmlNode.Attributes["alt"].ValueLength > 0 ?
                        nodeTitle + htmlNode.Attributes["alt"].Value :
                        nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["href"].Value);
                case "audio":
                case "script":
                case "embed":
                    return nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["src"].Value);
                case "button":
                case "textarea":
                    return htmlNode.Attributes.Contains("name") ?
                        nodeTitle + htmlNode.Attributes["name"].Value :
                        nodeTitle + ConvertClassIntoName(htmlNode);
                case "data":
                    return nodeTitle + htmlNode.Attributes["value"].Value + htmlNode.InnerText;
                case "div":
                    return htmlNode.Attributes.Contains("target") ?
                        nodeTitle + htmlNode.Attributes["target"].Value :
                        nodeTitle + ConvertClassIntoName(htmlNode);
                case "fieldset":
                case "map":
                    return nodeTitle + htmlNode.Attributes["name"].Value;
                case "frame":
                case "iframe":
                case "input":
                    return htmlNode.Attributes.Contains("name") ?
                        nodeTitle + htmlNode.Attributes["name"].Value :
                        nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["src"].Value);
                case "h1":
                case "h2":
                case "h3":
                case "h4":
                case "h5":
                case "h6":
                    return htmlNode.Attributes.Contains("title") ?
                        nodeTitle + htmlNode.Attributes["title"].Value :
                        nodeTitle + htmlNode.InnerText.Replace(" ", "");
                case "img":
                    return htmlNode.Attributes.Contains("src") ?
                        nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["src"].Value) :
                        nodeTitle + htmlNode.Attributes["alt"].Value;
                case "li":
                case "option":
                    return htmlNode.Attributes.Contains("value") ?
                        nodeTitle + htmlNode.Attributes["value"].Value :
                        nodeTitle + htmlNode.InnerText.Replace(" ", "");
                case "meter":
                case "nav":
                    return htmlNode.Attributes.Contains("title") ?
                        nodeTitle + htmlNode.Attributes["title"].Value :
                        nodeTitle + htmlNode.Attributes["alt"].Value;
                case "object":
                    return htmlNode.Attributes.Contains("name") ?
                        nodeTitle + htmlNode.Attributes["name"].Value :
                        nodeTitle + htmlNode.Attributes["data"].Value.Replace("/", "").Replace(".", "");
                case "optgroup":
                    return htmlNode.Attributes.Contains("label") ?
                        nodeTitle + htmlNode.Attributes["label"].Value.Replace(" ", "") :
                        nodeTitle + htmlNode.Attributes["title"].Value;
                case "picture":
                case "progress":
                case "ruby":
                case "section":
                case "span":
                case "template":
                    return htmlNode.Attributes.Contains("title") ?
                        nodeTitle + htmlNode.Attributes["title"].Value :
                        nodeTitle + ConvertClassIntoName(htmlNode);
                case "select":
                    return htmlNode.Attributes.Contains("name") ?
                        nodeTitle + htmlNode.Attributes["name"].Value :
                        nodeTitle + htmlNode.Attributes["title"].Value;
                case "source":
                    return htmlNode.Attributes.Contains("src") ?
                        nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["src"].Value) :
                        nodeTitle + htmlNode.Attributes["title"].Value;
                case "track":
                    return htmlNode.Attributes.Contains("src") ?
                        nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["src"].Value) :
                        nodeTitle + htmlNode.Attributes["label"].Value;
                case "video":
                    return htmlNode.Attributes.Contains("src") ?
                        nodeTitle + CalculateNameBasedOnSource(htmlNode.Attributes["src"].Value) :
                        nodeTitle + ConvertClassIntoName(htmlNode);
                case "ul":
                case "ol":
                    return nodeTitle + ConvertClassIntoName(htmlNode);
            }
            return null;
        }

        /// <summary>
        /// Calculates the name to apply to an object using the class attribute.
        /// </summary>
        /// <param name="htmlNode">The node for which a name is required.</param>
        /// <returns>A name calculated from the class attributes for a page object.</returns>
        string ConvertClassIntoName(HtmlNode htmlNode)
        {
            if (htmlNode.Attributes.Contains("class"))
            {
                string className = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(htmlNode.Attributes["class"].Value);
                string returnName = Regex.Replace(className, @"-", "", RegexOptions.Compiled);
                returnName = Regex.Replace(returnName, @"\s", "_", RegexOptions.Compiled);
                return returnName;
            }
            return null;
        }

        /// <summary>
        /// Retrieves a list of page objects.
        /// </summary>
        /// <returns>A list of Page Object Entries.</returns>
        List<PageObjectEntry> GetObjectsWithIdentifyingAttributes()
        {
            PageObjects = new List<PageObjectEntry>();
            GetPageObjects();
            return PageObjects;
        }

        /// <summary>
        /// Calculates a name for an object based on a URL.
        /// </summary>
        /// <param name="sourceUrl">The URL to use in naming the object.</param>
        /// <returns>The name for the object</returns>
        string CalculateNameBasedOnSource(string sourceUrl)
        {
            string outputName = Regex.Replace(sourceUrl, "com|https{0,1}://|www", "", RegexOptions.Compiled);
            outputName = Regex.Replace(outputName, "html{0,1}|php|js|jpg|gif|svw|mp3|m4a|mov", "", RegexOptions.Compiled);

            outputName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                Regex.Replace(outputName, @"\.", "", RegexOptions.Compiled)
                );

            outputName = Regex.Replace(outputName, @"\/|_|#", "_", RegexOptions.Compiled);
            outputName = Regex.Replace(outputName, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);
            outputName = outputName.Trim(Convert.ToChar("_"));
            return outputName;
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
