using Liberator.Driver;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberator.DriverTests
{
    [TestFixture]
    public class InstanceTests
    {
        [Test]
        [Category("Multi Instance Tests")]
        [Ignore("Experimental testing of threading concepts.")]
        public void TwinDriverControl()
        {
            IRodent chrome = new RatDriver<ChromeDriver>();
            var winChrome = chrome.WindowHandles.Last().Value;
            IRodent firefox = new RatDriver<FirefoxDriver>();
            var winFirefox = firefox.WindowHandles.Last().Value;

            chrome.Activate();
            chrome.SwitchToWindow(winChrome);
            chrome.NavigateToPage("www.totallyratted.com");

            firefox.Activate();
            firefox.SwitchToWindow(winFirefox);
            firefox.NavigateToPage("www.google.co.uk");

            chrome.Activate();
            chrome.SwitchToWindow(winChrome);
            chrome.ClosePagesAndQuitDriver();

            firefox.Activate();
            firefox.ClosePagesAndQuitDriver();
        }
    }
}
