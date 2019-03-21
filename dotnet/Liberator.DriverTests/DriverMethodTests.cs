using Liberator.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using Liberator.Driver.Enums;

namespace Liberator.DriverTests
{
    [TestFixture]
    public class DriverMethodTests
    {
        [Test]
        [Category("Firefox")]
        public void Firefox_ClickLinkWithClock()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(devLink, clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_ClickLinkWithClock()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(devLink, clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_ClickLinkWithClock()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(devLink, clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ClickLinkWithClock()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(devLink, clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_ClickLinkWithClock()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(devLink, clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }


        [Test]
        [Category("Firefox")]
        public void Firefox_ClickLinkAndWaitForPage()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWaitForUrl(devLink, "developments", true);
            ratDriver.ClosePagesAndQuitDriver();
        }


        [Test]
        [Category("Chrome")]
        public void Chrome_ClickLinkAndWaitForPage()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWaitForUrl(devLink, "developments", true);
            ratDriver.ClosePagesAndQuitDriver();
        }


        [Test]
        [Category("Edge")]
        public void Edge_ClickLinkAndWaitForPage()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWaitForUrl(devLink, "developments", true);
            ratDriver.ClosePagesAndQuitDriver();
        }


        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ClickLinkAndWaitForPage()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWaitForUrl(devLink, "developments", true);
            ratDriver.ClosePagesAndQuitDriver();
        }


        [Test]
        [Category("Opera")]
        public void Opera_ClickLinkAndWaitForPage()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWaitForUrl(devLink, "developments", true);
            ratDriver.ClosePagesAndQuitDriver();
        }


        [Test]
        [Category("Firefox")]
        public void Firefox_ClickLinkWithClockBy()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_ClickLinkWithClockBy()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_ClickLinkWithClockBy()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ClickLinkWithClockBy()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_ClickLinkWithClockBy()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            ratDriver.ClickLink(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetElementTextWithClock()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            Assert.IsTrue(text.Contains("Developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetElementTextWithClock()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            Assert.IsTrue(text.Contains("Developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetElementTextWithClock()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            Assert.IsTrue(text.Contains("Developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetElementTextWithClock()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            Assert.IsTrue(text.Contains("Developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetElementTextWithClock()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            RatClock clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.LinkText("Developments"), clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            Assert.IsTrue(text.Contains("Developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetElementAttribute()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            Assert.IsTrue(ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride").Contains("carousel"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetElementAttribute()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            Assert.IsTrue(ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride").Contains("carousel"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetElementAttribute()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            Assert.IsTrue(ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride").Contains("carousel"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetElementAttribute()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            Assert.IsTrue(ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride").Contains("carousel"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetElementAttribute()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            Assert.IsTrue(ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride").Contains("carousel"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetElementAttributeWithClock()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            var element = ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride", clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetElementAttributeWithClock()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            var element = ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride", clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetElementAttributeWithClock()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            var element = ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride", clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetElementAttributeWithClock()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            var element = ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride", clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetElementAttributeWithClock()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var clock = new RatClock();
            var targetTime = clock.LaterBy(new TimeSpan(0, 0, 0, 30, 0));
            var text = ratDriver.GetElementText(By.Id("carousel-example"));
            var element = ratDriver.GetElementAttribute(ratDriver.FindElementById("carousel-example"), "data-ride", clock);
            Assert.IsTrue(clock.IsNowBefore(targetTime));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindByClassName()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByClassName("carousel-inner");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindByClassName()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByClassName("carousel-inner");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindByClassName()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByClassName("carousel-inner");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindByClassName()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByClassName("carousel-inner");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindByClassName()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByClassName("carousel-inner");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindElementsByClassName()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByClassName("menutext");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindElementsByClassName()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByClassName("menutext");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindElementsByClassName()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByClassName("menutext");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindElementsByClassName()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByClassName("menutext");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindElementsByClassName()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByClassName("menutext");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByClassName()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByCssSelector(".nav.navbar-nav.navbar-right");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByClassName()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByCssSelector(".nav.navbar-nav.navbar-right");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByClassName()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByCssSelector(".nav.navbar-nav.navbar-right");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByClassName()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByCssSelector(".nav.navbar-nav.navbar-right");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByClassName()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByCssSelector(".nav.navbar-nav.navbar-right");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByClassNameLocator()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", By.ClassName("container"));
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByClassNameLocator()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", By.ClassName("container"));
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByClassNameLocator()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", By.ClassName("container"));
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByClassNameLocator()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", By.ClassName("container"));
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByClassNameLocator()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByClassName("menutext", By.ClassName("container"));
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindById()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementById("home");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindById()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementById("home");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindById()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementById("home");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindById()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementById("home");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindById()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementById("home");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindByLinkText()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindByLinkText()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindByLinkText()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindByLinkText()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindByLinkText()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByLinkText("Developments");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindElementsByLinkText()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByLinkText("Read Details");
            Assert.IsTrue(elements.Count() == 6);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindElementsByLinkText()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByLinkText("Read Details");
            Assert.IsTrue(elements.Count() == 6);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindElementsByLinkText()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByLinkText("Read Details");
            Assert.IsTrue(elements.Count() == 6);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindElementsByLinkText()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByLinkText("Read Details");
            Assert.IsTrue(elements.Count() == 6);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindElementsByLinkText()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByLinkText("Read Details");
            Assert.IsTrue(elements.Count() == 6);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByLinkText()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByLinkText()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByLinkText()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByLinkText()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByLinkText()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByLinkTextLocator()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByLinkTextLocator()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByLinkTextLocator()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByLinkTextLocator()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByLinkTextLocator()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindElementByTagName()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByTag("body");
            Assert.IsNotNull(element);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindElementByTagName()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByTag("body");
            Assert.IsNotNull(element);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindElementByTagName()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByTag("body");
            Assert.IsNotNull(element);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindElementByTagName()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByTag("body");
            Assert.IsNotNull(element);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindElementByTagName()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByTag("body");
            Assert.IsNotNull(element);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindElementsByTagName()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByTag("section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindElementsByTagName()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByTag("section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindElementsByTagName()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByTag("section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindElementsByTagName()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByTag("section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindElementsByTagName()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByTag("section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByTagName()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByTagName()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByTagName()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByTagName()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByTagName()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementById("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByTagNameLocator()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByTagNameLocator()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByTagNameLocator()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByTagNameLocator()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByTagNameLocator()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.Id("just-intro");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByTag("a", parent);
            Assert.IsTrue(elements.Count() == 3);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindElementByXPath()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByXPath(".//*[@id='carousel-example']");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindElementByXPath()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByXPath(".//*[@id='carousel-example']");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindElementByXPath()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByXPath(".//*[@id='carousel-example']");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindElementByXPath()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByXPath(".//*[@id='carousel-example']");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindElementByXPath()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement element = ratDriver.FindElementByXPath(".//*[@id='carousel-example']");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindElementsByXPath()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByXPath(".//section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindElementsByXPath()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByXPath(".//section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindElementsByXPath()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByXPath(".//section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindElementsByXPath()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByXPath(".//section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindElementsByXPath()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IEnumerable<IWebElement> elements = ratDriver.FindElementsByXPath(".//section");
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByXPath()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByXPath()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByXPath()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByXPath()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByXPath()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_FindSubElementsByXPathLocator()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_FindSubElementsByXPathLocator()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_FindSubElementsByXPathLocator()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_FindSubElementsByXPathLocator()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_FindSubElementsByXPathLocator()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IEnumerable<IWebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent);
            Assert.IsTrue(elements.Count() == 5);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_ExtractElementFromCollectionByAttributeLocator()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_ExtractElementFromCollectionByAttributeLocator()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_ExtractElementFromCollectionByAttributeLocator()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ExtractElementFromCollectionByAttributeLocator()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_ExtractElementFromCollectionByAttributeLocator()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            By parent = By.XPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_ExtractElementFromCollectionByAttribute()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_ExtractElementFromCollectionByAttribute()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_ExtractElementFromCollectionByAttribute()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ExtractElementFromCollectionByAttribute()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_ExtractElementFromCollectionByAttribute()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            IWebElement parent = ratDriver.FindElementByXPath("html/body");
            IWebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, EnumLocatorType.XPath, ".//section", "class", "note-sec");
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            ratDriver.ClosePagesAndQuitDriver();
        }

    }
}
