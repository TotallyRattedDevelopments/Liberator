using Liberator.DynamicPageEngine.Entities;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Liberator.DynamicPageEngine.Output
{
    /// <summary>
    /// Class used to write Page Object Collections to XML files.
    /// </summary>
    public class XMLWriter : IWriter
    {
        /// <summary>
        /// The name of the page.
        /// </summary>
        string PageName;

        /// <summary>
        /// The element tree that represents the XML document.
        /// </summary>
        XElement Tree;

        /// <summary>
        /// Creates and XML document from a collection of page objects.
        /// </summary>
        /// <param name="pageObjectEntries">A collection of page objects.</param>
        /// <param name="nameSpace">The namespace for the XML document.</param>
        /// <param name="page">The name of the page to assign.</param>
        /// <returns>An XML document.</returns>
        public XElement CreateDocument(List<PageObjectEntry> pageObjectEntries, string nameSpace, string page)
        {
            XNamespace xNamespace = nameSpace;
            PageName = page;
            XElement xmlTree = new XElement(xNamespace + "page", new XAttribute("name", page));
            XElement pageObjects = new XElement(xNamespace + "pageObjects");
            

            foreach (PageObjectEntry pageObjectEntry in pageObjectEntries)
            {
                XElement idElement = new XElement(xNamespace + "id", pageObjectEntry.Id);
                XElement linkElement = new XElement(xNamespace + "link", pageObjectEntry.Link);
                XElement tagElement = new XElement(xNamespace + "tagName", pageObjectEntry.TagName);
                XElement nameAttributeElement = new XElement(xNamespace + "nameAttribute", pageObjectEntry.NameAttribute);
                XElement objectNameElement = new XElement(xNamespace + "objectName", pageObjectEntry.ObjectName);
                XElement cssElement = new XElement(xNamespace + "cssSelector", pageObjectEntry.CssSelector);
                XElement xPathElement = new XElement(xNamespace + "xPath", pageObjectEntry.XPath);


                XElement pageElement =
                    new XElement(
                        xNamespace + "pageObject", 
                        idElement, 
                        linkElement,
                        tagElement,
                        nameAttributeElement,
                        objectNameElement,
                        cssElement,
                        xPathElement
                        );

                pageObjects.Add( pageElement );
            }
            xmlTree.Add(pageObjects);
            Tree = xmlTree;
            return xmlTree;
        }

        /// <summary>
        /// Saves the output of the document to the passed filepath
        /// </summary>
        /// <param name="filePath">The file path to use when saving the document</param>
        public void OuputDocument(string filePath, string fileName)
        {
            Tree.Save(filePath + "\\" + fileName + "_" + PageName + ".xml");
        }

    }
}
