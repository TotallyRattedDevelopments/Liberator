using Liberator.DynamicPageEngine.Entities;
using Liberator.DynamicPageEngine.Scan;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Liberator.DynamicPageEngineTests
{
    [TestFixture]
    public class PageIterationTests
    {
        HTMLScanner HTMLScanner;

        public PageIterationTests()
        {
            HTMLScanner = new HTMLScanner();
        }

        [Test]
        [Category("HTML Scanner")]
        public void GetBodyOfPage()
        {
            string htmlPage = null;
            string filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"HTML\index.html");

            using (FileStream fileStream = File.OpenRead(filePath))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                htmlPage = streamReader.ReadToEnd();
            }

            HTMLScanner.ScanHtmlPage(htmlPage);
            Assert.That(HTMLScanner.PageDocument.Equals(htmlPage), Is.False);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetListOfChildNodes()
        {
            string htmlPage = null;
            string filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"HTML\index.html");

            using (FileStream fileStream = File.OpenRead(filePath))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                htmlPage = streamReader.ReadToEnd();
            }

            HTMLScanner.ScanHtmlPage(htmlPage);
            Assert.That(HTMLScanner.GetListOfNodesByTag("section").Count == 5, Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_Count()
        {
            string htmlPage = null;
            string filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"HTML\index.html");

            using (FileStream fileStream = File.OpenRead(filePath))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                htmlPage = streamReader.ReadToEnd();
            }

            HTMLScanner.ScanHtmlPage(htmlPage);
            List<PageObjectEntry> pageObjects = HTMLScanner.GetPageObjects(new string[] {"a"});
            Assert.That(pageObjects.Count == 16, Is.True);
        }


        [Test]
        [Category("HTML Scanner")]
        public void GetLinks_FirstChild()
        {
            string htmlPage = null;
            string filePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"HTML\index.html");

            using (FileStream fileStream = File.OpenRead(filePath))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                htmlPage = streamReader.ReadToEnd();
            }

            HTMLScanner.ScanHtmlPage(htmlPage);

            List<PageObjectEntry> pageObjects = HTMLScanner.GetPageObjects(new string[] { "a" });

            Assert.That(pageObjects[0].CssSelector == ".navbar-brand.tradewinds", Is.True);
            Assert.That(pageObjects[0].Id == null, Is.True);
            Assert.That(pageObjects[0].Link == "index.html", Is.True);
            Assert.That(pageObjects[0].TagName == "a", Is.True);
            Assert.That(pageObjects[0].XPath == "/html[1]/body[1]/div[1]/div[1]/div[1]/a[1]", Is.True);
        }


    }
}
