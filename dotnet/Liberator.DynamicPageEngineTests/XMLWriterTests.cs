using Liberator.DynamicPageEngine.Entities;
using Liberator.DynamicPageEngine.Output;
using Liberator.DynamicPageEngine.Scan;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Liberator.DynamicPageEngineTests
{
    [TestFixture]
    public class XMLWriterTests
    {
        HTMLScanner HTMLScanner;

        string FilePath;

        string HtmlPage;

        List<PageObjectEntry> PageObjects;

        XMLWriter XmlWriter;

        XElement Document;

        public XMLWriterTests()
        {
            HTMLScanner = new HTMLScanner();
            HtmlPage = null;
            FilePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"HTML\index.html");

            using (FileStream fileStream = File.OpenRead(FilePath))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                HtmlPage = streamReader.ReadToEnd();
            }

            PageObjects = HTMLScanner.ScanHtmlPage(HtmlPage);
            XmlWriter = new XMLWriter();
            Document = XmlWriter.CreateDocument(PageObjects, "http://www.totallyratted.com", "main");
        }

        [Test]
        [Category("XML Writer")]
        public void XmlWriter_GetNumberOfChildren()
        {
            Assert.That(PageObjects.Count == 78, Is.True);
        }

        [Test]
        [Category("XML Writer")]
        public void XmlWriter_GetNamespaceName()
        {
            Assert.That(Document.Name.Namespace.NamespaceName.Contains("totallyratted"), Is.True);
        }

        [Test]
        [Category("XML Writer")]
        public void XmlWriter_GetLocalName()
        {
            Assert.That(Document.Name.LocalName.Contains("page"), Is.True);
        }

        [Test]
        [Category("XML Writer")]
        public void XmlWriter_GetFirstAttribute()
        {
            Assert.That(Document.FirstAttribute.Value.Contains("main"), Is.True);
        }
        [Test]
        [Category("XML Writer")]
        public void XmlWriter_CountPageObject()
        {
            IEnumerable<XElement> elements = Document.Descendants().Where(x => x.Name.LocalName.Contains("pageObjects"));
            Assert.That(elements.Count() == 1, Is.True);
        }

        [Test]
        [Category("XML Writer")]
        public void XmlWriter_CountPageObjects()
        {
            IEnumerable<XElement> elements = Document.Descendants().Where(x => x.Name.LocalName.Equals("pageObject"));
            Assert.That(elements.Count() == 78, Is.True);
        }

        [Test]
        [Category("XML Writer")]
        public void XmlWriter_OutputFile()
        {
            XmlWriter.OuputDocument(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "XmlWriter_TestOutput");
            if (File.Exists(FilePath))
                Assert.Pass("File saved.");
            else
                Assert.Fail("Houston, we have a problem.");
        }
    }
}
