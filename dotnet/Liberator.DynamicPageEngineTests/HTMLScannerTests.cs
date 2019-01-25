using Liberator.DynamicPageEngine.Entities;
using Liberator.DynamicPageEngine.Scan;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Liberator.DynamicPageEngineTests
{
    [TestFixture]
    public class HTMLScannerTests
    {
        HTMLScanner HTMLScanner;

        string htmlPage;

        List<PageObjectEntry> pageObjects;


        public HTMLScannerTests()
        {
            HTMLScanner = new HTMLScanner();
            htmlPage = null;
            string filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"HTML\index.html");

            using (FileStream fileStream = File.OpenRead(filePath))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                htmlPage = streamReader.ReadToEnd();
            }

            pageObjects = HTMLScanner.ScanHtmlPage(htmlPage);
        }

        [Test]
        [Category("HTML Scanner")]
        public void GetBodyOfPage()
        {
            Assert.That(HTMLScanner.Body.Equals(htmlPage), Is.False);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_Count()
        {
            Assert.That(pageObjects.Count == 78, Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_FirstChild_CssSelector()
        {
            Assert.That(pageObjects[0].CssSelector == ".navbar.navbar-inverse.navbar-fixed-top", Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_FirstChild_Id()
        {
            Assert.That(pageObjects[0].Id == null, Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_FirstChild_Link()
        {
            Assert.That(pageObjects[0].Link == "", Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_FirstChild_TagName()
        {
            Assert.That(pageObjects[0].TagName == "div", Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_FirstChild_XPath()
        {
            Assert.That(pageObjects[0].XPath == "/html[1]/body[1]/div[1]", Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_CorrectCount()
        {
            Assert.That(pageObjects.Count == 78, Is.True);
        }
    }
}
