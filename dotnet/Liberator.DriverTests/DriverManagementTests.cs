using Liberator.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Liberator.DriverTests
{
    [TestFixture]
    public class DriverManagementTests
    {
        [Test]
        [Category("Firefox")]
        public void InstantiateFirefoxDriver()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void InstantiateFirefoxDriver_WithProfile()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>("Automation");
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void InstantiateChromeDriver()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void InstantiateEdgeDriver()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InstantiateInternetExplorerDriver()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }
        
        [Test]
        [Category("Opera")]
        public void InstantiateOperaDriver()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_ClickLink()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_ClickLink()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_ClickLink()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ClickLink()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.Driver != null);
            Thread.Sleep(500);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().ToLower().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_ClickLink()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.Driver != null);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetText()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetElementText(By.CssSelector(".col-md-12>h1"));
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetText()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetElementText(By.CssSelector(".col-md-12>h1"));
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetText()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetElementText(By.CssSelector(".col-md-12>h1"));
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetText()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".row.text-center.pad-row"));
            var str = ratDriver.GetElementText(By.CssSelector(".row.text-center.pad-row"));
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetText()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetElementText(By.CssSelector(".col-md-12>h1"));
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_CheckPageSourceForText()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12"));
            var str = ratDriver.GetPageSource();
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_CheckPageSourceForText()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetPageSource();
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Edge")]
        public void Edge_CheckPageSourceForText()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetPageSource();
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_CheckPageSourceForText()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetPageSource();
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Opera")]
        public void Opera_CheckPageSourceForText()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            ratDriver.WaitForElementToLoad(By.CssSelector(".col-md-12>h1"));
            var str = ratDriver.GetPageSource();
            ratDriver.ClosePagesAndQuitDriver();
            Assert.That(str.Contains("Totally Ratted Developments"));
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_CookieTests()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            ratDriver.WaitForElementToLoad(ratDriver.FindElementByCssSelector(".navbar-brand.tradewinds"));

            ratDriver.AddCookie("ratCookie", "ratData");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratData"));
            ratDriver.ReplaceCookie("ratCookie", "ratUpdate");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratCookie"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratUpdate"));
            ratDriver.DeleteCookieNamed("ratCookie");

            ratDriver.AddCookie("ratMuffin", "caramel", "/");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("caramel"));
            ratDriver.ReplaceCookie("ratMuffin", "blueberry");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratMuffin"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("blueberry"));
            ratDriver.DeleteCookieNamed("ratMuffin");

            ratDriver.AddCookie("ratBagel", "cheese", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("cheese"));
            ratDriver.ReplaceCookie("ratBagel", "ham");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratBagel"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("ham"));
            ratDriver.DeleteCookieNamed("ratBagel");

            ratDriver.AddCookie("ratCrumpet", "jam", "totallyratted.com", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("jam"));
            ratDriver.ReplaceCookie("ratCrumpet", "honey");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratCrumpet"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("honey"));
            ratDriver.DeleteCookieNamed("ratCrumpet");

            ratDriver.DeleteAllCookies();
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_CookieTests()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            ratDriver.WaitForElementToLoad(ratDriver.FindElementByCssSelector(".navbar-brand.tradewinds"));

            ratDriver.AddCookie("ratCookie", "ratData");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratData"));
            ratDriver.ReplaceCookie("ratCookie", "ratUpdate");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratUpdate"));
            ratDriver.DeleteCookieNamed("ratCookie");

            ratDriver.AddCookie("ratMuffin", "caramel", "/");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("caramel"));
            ratDriver.ReplaceCookie("ratMuffin", "blueberry");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratMuffin"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("blueberry"));
            ratDriver.DeleteCookieNamed("ratMuffin");

            ratDriver.AddCookie("ratBagel", "cheese", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("cheese"));
            ratDriver.ReplaceCookie("ratBagel", "ham");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratBagel"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("ham"));
            ratDriver.DeleteCookieNamed("ratBagel");

            ratDriver.AddCookie("ratCrumpet", "jam", "totallyratted.com", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("jam"));
            ratDriver.ReplaceCookie("ratCrumpet", "honey");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratCrumpet"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("honey"));
            ratDriver.DeleteCookieNamed("ratCrumpet");

            ratDriver.DeleteAllCookies();
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_CookieTests()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            ratDriver.WaitForElementToLoad(ratDriver.FindElementByCssSelector(".navbar-brand.tradewinds"));

            ratDriver.AddCookie("ratCookie", "ratData");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratData"));
            ratDriver.ReplaceCookie("ratCookie", "ratUpdate");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratUpdate"));
            ratDriver.DeleteCookieNamed("ratCookie");

            ratDriver.AddCookie("ratMuffin", "caramel", "/");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("caramel"));
            ratDriver.ReplaceCookie("ratMuffin", "blueberry");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratMuffin"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("blueberry"));
            ratDriver.DeleteCookieNamed("ratMuffin");

            ratDriver.AddCookie("ratBagel", "cheese", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("cheese"));
            ratDriver.ReplaceCookie("ratBagel", "ham");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratBagel"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("ham"));
            ratDriver.DeleteCookieNamed("ratBagel");

            ratDriver.AddCookie("ratCrumpet", "jam", "totallyratted.com", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("jam"));
            ratDriver.ReplaceCookie("ratCrumpet", "honey");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratCrumpet"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("honey"));
            ratDriver.DeleteCookieNamed("ratCrumpet");

            ratDriver.DeleteAllCookies();
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_CookieTests()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            ratDriver.WaitForElementToLoad(ratDriver.FindElementByCssSelector(".navbar-brand.tradewinds"));

            ratDriver.AddCookie("ratCookie", "ratData");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratData"));
            ratDriver.ReplaceCookie("ratCookie", "ratUpdate");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratUpdate"));
            ratDriver.DeleteCookieNamed("ratCookie");

            ratDriver.AddCookie("ratMuffin", "caramel", "/");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("caramel"));
            ratDriver.ReplaceCookie("ratMuffin", "blueberry");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratMuffin"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("blueberry"));
            ratDriver.DeleteCookieNamed("ratMuffin");

            ratDriver.AddCookie("ratBagel", "cheese", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("cheese"));
            ratDriver.ReplaceCookie("ratBagel", "ham");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratBagel"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("ham"));
            ratDriver.DeleteCookieNamed("ratBagel");

            ratDriver.AddCookie("ratCrumpet", "jam", "totallyratted.com", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("jam"));
            ratDriver.ReplaceCookie("ratCrumpet", "honey");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratCrumpet"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("honey"));
            ratDriver.DeleteCookieNamed("ratCrumpet");

            ratDriver.DeleteAllCookies();
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_CookieTests()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            ratDriver.WaitForElementToLoad(ratDriver.FindElementByCssSelector(".navbar-brand.tradewinds"));

            ratDriver.AddCookie("ratCookie", "ratData");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratData"));
            ratDriver.ReplaceCookie("ratCookie", "ratUpdate");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratCookie").Value.Contains("ratUpdate"));
            ratDriver.DeleteCookieNamed("ratCookie");

            ratDriver.AddCookie("ratMuffin", "caramel", "/");
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("caramel"));
            ratDriver.ReplaceCookie("ratMuffin", "blueberry");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratMuffin"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratMuffin").Value.Contains("blueberry"));
            ratDriver.DeleteCookieNamed("ratMuffin");

            ratDriver.AddCookie("ratBagel", "cheese", "/", DateTime.Now.AddDays(1));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("cheese"));
            ratDriver.ReplaceCookie("ratBagel", "ham");
            Assert.IsTrue(ratDriver.CheckCookieExists("ratBagel"));
            Assert.IsTrue(ratDriver.GetCookieNamed("ratBagel").Value.Contains("ham"));
            ratDriver.DeleteCookieNamed("ratBagel");

            //ratDriver.AddCookie("ratCrumpet", "jam", "totallyratted", "/", DateTime.Now.AddDays(1));
            //Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("jam"));
            //ratDriver.ReplaceCookie("ratCrumpet", "honey");
            //Assert.IsTrue(ratDriver.CheckCookieExists("ratCrumpet"));
            //Assert.IsTrue(ratDriver.GetCookieNamed("ratCrumpet").Value.Contains("honey"));
            //ratDriver.DeleteCookieNamed("ratCrumpet");

            ratDriver.DeleteAllCookies();
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetAvailableLogTypes()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            List<string> logTypes = ratDriver.GetAvailableLogTypes().ToList();
            Assert.IsTrue(logTypes[0] == "browser");
            Assert.IsTrue(logTypes[1] == "driver");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetAvailableLogTypes()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsNull(ratDriver.GetAvailableLogTypes());
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetAvailableLogTypes()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsNull(ratDriver.GetAvailableLogTypes());
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetAvailableLogTypes()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsNull(ratDriver.GetAvailableLogTypes());
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetAvailableLogTypes()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            List<string> logTypes = ratDriver.GetAvailableLogTypes().ToList();
            Assert.IsTrue(logTypes[0] == "browser");
            Assert.IsTrue(logTypes[1] == "driver");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetBrowserLogEntries()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var logEntries = ratDriver.GetAvailableLogEntries("browser");
            Assert.IsNotNull(logEntries);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetDriverLogEntries()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            var logEntries = ratDriver.GetAvailableLogEntries("driver");
            Assert.IsNotNull(logEntries);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_SetImplicitWait()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.SetImplicitWait(0, 5, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_SetImplicitWait()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.SetImplicitWait(0, 5, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_SetImplicitWait()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.SetImplicitWait(0, 5, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_SetImplicitWait()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.SetImplicitWait(0, 5, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_SetImplicitWait()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.SetImplicitWait(0, 5, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_SetPageLoadTimeout()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.SetPageLoadTimeout(0, 30, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_SetPageLoadTimeout()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.SetPageLoadTimeout(0, 30, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_SetPageLoadTimeout()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.SetPageLoadTimeout(0, 30, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_SetPageLoadTimeout()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.SetPageLoadTimeout(0, 30, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_SetPageLoadTimeout()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.SetPageLoadTimeout(0, 30, 0);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetWindowPosition()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowPosition();
            Assert.IsTrue(position.Item1 >= -10);
            Assert.IsTrue(position.Item2 >= -10);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetWindowPosition()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowPosition();
            Assert.IsTrue(position.Item1 >= 0);
            Assert.IsTrue(position.Item2 >= 0);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetWindowPosition()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowPosition();
            Assert.IsTrue(position.Item1 >= -20);
            Assert.IsTrue(position.Item2 >= -20);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetWindowPosition()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowPosition();
            Assert.IsTrue(position.Item1 >= -20);
            Assert.IsTrue(position.Item2 >= -20);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetWindowPosition()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowPosition();
            Assert.IsTrue(position.Item1 >= -20);
            Assert.IsTrue(position.Item2 >= -20);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetWindowSize()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowSize();
            Assert.IsTrue(position.Item1 >= 0);
            Assert.IsTrue(position.Item2 >= 0);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetWindowSize()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowSize();
            Assert.IsTrue(position.Item1 >= 0);
            Assert.IsTrue(position.Item2 >= 0);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetWindowSize()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowSize();
            Assert.IsTrue(position.Item1 >= 0);
            Assert.IsTrue(position.Item2 >= 0);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetWindowSize()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowSize();
            Assert.IsTrue(position.Item1 >= 0);
            Assert.IsTrue(position.Item2 >= 0);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetWindowSize()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Tuple<int, int> position = ratDriver.GetWindowSize();
            Assert.IsTrue(position.Item1 >= 0);
            Assert.IsTrue(position.Item2 >= 0);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_ResizeWindow()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ResizeBrowserWindow(640, 480);
            Tuple<int, int> size = ratDriver.GetWindowSize();
            Assert.IsTrue(size.Item1 == 640);
            Assert.IsTrue(size.Item2 == 480);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_ResizeWindow()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ResizeBrowserWindow(640, 480);
            Tuple<int, int> size = ratDriver.GetWindowSize();
            Assert.IsTrue(size.Item1 == 640);
            Assert.IsTrue(size.Item2 == 480);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_ResizeWindow()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ResizeBrowserWindow(640, 480);
            Tuple<int, int> size = ratDriver.GetWindowSize();
            Assert.IsTrue(size.Item1 == 639 || size.Item1 == 640);
            Assert.IsTrue(size.Item2 == 479 || size.Item2 == 480);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_ResizeWindow()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ResizeBrowserWindow(640, 480);
            Tuple<int, int> size = ratDriver.GetWindowSize();
            Assert.IsTrue(size.Item1 == 640);
            Assert.IsTrue(size.Item2 == 480);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_ResizeWindow()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.ResizeBrowserWindow(640, 480);
            Tuple<int, int> size = ratDriver.GetWindowSize();
            Assert.IsTrue(size.Item1 == 640);
            Assert.IsTrue(size.Item2 == 480);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_BrowserButtons()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressBackButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressForwardButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_BrowserButtons()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressBackButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressForwardButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_BrowserButtons()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressBackButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressForwardButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_BrowserButtons()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Thread.Sleep(250);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressBackButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressForwardButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_BrowserButtons()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.FindElementByPartialLinkText("Developments");
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressBackButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.PressForwardButton();
            devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_NavigateUsingUri()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            Uri url = new Uri("http://www.totallyratted.com");
            ratDriver.NavigateToPage(url);
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_NavigateUsingUri()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            Uri url = new Uri("http://www.totallyratted.com");
            ratDriver.NavigateToPage(url);
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_NavigateUsingUri()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            Uri url = new Uri("http://www.totallyratted.com");
            ratDriver.NavigateToPage(url);
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_NavigateUsingUri()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            Uri url = new Uri("http://www.totallyratted.com");
            ratDriver.NavigateToPage(url);
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_NavigateUsingUri()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            Uri url = new Uri("http://www.totallyratted.com");
            ratDriver.NavigateToPage(url);
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            Assert.IsFalse(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetPageSource()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetPageSource().Length >= 256);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetPageSource()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetPageSource().Length >= 256);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetPageSource()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetPageSource().Length >= 256);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetPageSource()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetPageSource().Length >= 256);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetPageSource()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var devLink = ratDriver.Driver.FindElement(By.LinkText("Developments"));
            Assert.IsTrue(ratDriver.ElementExists(devLink));
            Assert.IsTrue(ratDriver.GetPageSource().Length >= 256);
            ratDriver.ClosePagesAndQuitDriver();
        }
        
        [Test]
        [Category("Firefox")]
        public void Firefox_SwitchToWindow()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            //var pageOne = ratDriver.FindElementByTag("body");
            var window = ratDriver.Driver.CurrentWindowHandle;
            ratDriver.OpenNewView();
            ratDriver.NavigateToPage("http://www.google.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("google"));
            ratDriver.SwitchToWindow(window);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("ratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }
        
        [Test]
        [Category("Chrome")]
        public void Chrome_SwitchToWindow()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            //var pageOne = ratDriver.FindElementByTag("body");
            var window = ratDriver.Driver.CurrentWindowHandle;
            ratDriver.OpenNewView();
            ratDriver.NavigateToPage("http://www.google.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("google"));
            ratDriver.SwitchToWindow(window);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("ratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Ignore("Currently not allowing a java script open window command")]
        [Test]
        [Category("Edge")]
        public void Edge_SwitchToWindow()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var window = ratDriver.Driver.CurrentWindowHandle;
            ratDriver.OpenNewView();
            ratDriver.NavigateToPage("http://www.google.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("google"));
            ratDriver.SwitchToWindow(window);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("ratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }
        
        [Ignore("Currently not allowing a java script open window command")]
        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_SwitchToWindow()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var window = ratDriver.Driver.CurrentWindowHandle;
            ratDriver.OpenNewView();
            ratDriver.NavigateToPage("http://www.google.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("google"));
            ratDriver.SwitchToWindow(window);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("ratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }
        
        [Test]
        [Category("Opera")]
        public void Opera_SwitchToWindow()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var window = ratDriver.Driver.CurrentWindowHandle;
            ratDriver.OpenNewView();
            ratDriver.NavigateToPage("http://www.google.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("google"));
            ratDriver.SwitchToWindow(window);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("ratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetBrowserWindowTitle()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetBrowserWindowTitle();
            Assert.IsTrue(title.Contains("Totally Ratted Limited"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetBrowserWindowTitle()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetBrowserWindowTitle();
            Assert.IsTrue(title.Contains("Totally Ratted Limited"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetBrowserWindowTitle()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetBrowserWindowTitle();
            Assert.IsTrue(title.Contains("Totally Ratted Limited"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetBrowserWindowTitle()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetBrowserWindowTitle();
            Assert.IsTrue(title.Contains("Totally Ratted Limited"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetBrowserWindowTitle()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetBrowserWindowTitle();
            Assert.IsTrue(title.Contains("Totally Ratted Limited"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Firefox")]
        public void Firefox_GetAllWindowHandles()
        {
            RatDriver<FirefoxDriver> ratDriver = new RatDriver<FirefoxDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetAllWindowHandles();
            Assert.IsNotNull(title);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_GetAllWindowHandles()
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetAllWindowHandles();
            Assert.IsNotNull(title);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Edge")]
        public void Edge_GetAllWindowHandles()
        {
            RatDriver<EdgeDriver> ratDriver = new RatDriver<EdgeDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetAllWindowHandles();
            Assert.IsNotNull(title);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("InternetExplorer")]
        public void InternetExplorer_GetAllWindowHandles()
        {
            RatDriver<InternetExplorerDriver> ratDriver = new RatDriver<InternetExplorerDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetAllWindowHandles();
            Assert.IsNotNull(title);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Opera")]
        public void Opera_GetAllWindowHandles()
        {
            RatDriver<OperaDriver> ratDriver = new RatDriver<OperaDriver>();
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            ratDriver.MaximiseView();
            var title = ratDriver.GetAllWindowHandles();
            Assert.IsNotNull(title);
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [Category("Chrome")]
        public void Chrome_EnableEmulationMode()
        {
            string userAgent = "Mozilla/5.0 (Linux; U; Android 4.3; en-us; SM-N900T Build/JSS15J) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30";
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>(360, 640, userAgent, 3.0d, true);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
        }
    }
}
