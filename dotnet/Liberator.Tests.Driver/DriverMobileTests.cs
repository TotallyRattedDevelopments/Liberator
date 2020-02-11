using Liberator.Driver;
using Liberator.Driver.Enums;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Liberator.DriverTests
{
    [TestFixture]
    public class DriverMobileTests
    {
        [Test]
        [TestCase(EnumPhoneType.AmazonKindleFireHDX, true)]
        [TestCase(EnumPhoneType.AppleiPad, true)]
        [TestCase(EnumPhoneType.AppleiPadMini, true)]
        [TestCase(EnumPhoneType.AppleiPadPro, true)]
        [TestCase(EnumPhoneType.AppleiPhone4, true)]
        [TestCase(EnumPhoneType.AppleiPhone5, true)]
        [TestCase(EnumPhoneType.AppleiPhone6, true)]
        [TestCase(EnumPhoneType.AppleiPhone6Plus, true)]
        [TestCase(EnumPhoneType.BlackBerryPlayBook, true)]
        [TestCase(EnumPhoneType .BlackBeryZ30, true)]
        [TestCase(EnumPhoneType.GoogleNexus10, true)]
        [TestCase(EnumPhoneType.GoogleNexus4, true)]
        [TestCase(EnumPhoneType.GoogleNexus5, true)]
        [TestCase(EnumPhoneType.GoogleNexus6, true)]
        [TestCase(EnumPhoneType.GoogleNexus7, true)]
        [TestCase(EnumPhoneType.LGOptimusL70, true)]
        [TestCase(EnumPhoneType.MicrosoftLumia550, true)]
        [TestCase(EnumPhoneType.MicrosoftLumia950, true)]
        [TestCase(EnumPhoneType.Nexus5X, true)]
        [TestCase(EnumPhoneType.Nexus6P, true)]
        [TestCase(EnumPhoneType.NokiaLumia520, true)]
        [TestCase(EnumPhoneType.NokiaN9, true)]
        [TestCase(EnumPhoneType.SamsungGalaxyNote2, true)]
        [TestCase(EnumPhoneType.SamsungGalaxyNote3, true)]
        [TestCase(EnumPhoneType.SamsungGalaxyS3, true)]
        [TestCase(EnumPhoneType.SamsungGalaxyS5, true)]
        [Category("MobileEmulation")]
        public void Chrome_MobileDriver(EnumPhoneType phone, bool touch)
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>(phone, touch);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [TestCase(EnumPhoneType.AppleiPhone6Plus, true)]
        [Category("MobileNavigation")]
        public void Chrome_MobileDriver_ClickLink(EnumPhoneType phone, bool touch)
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>(phone, touch);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));

            var devLink = ratDriver.FindElementByXPath(".//*[@id='just-intro']/div/div/div[1]/a");
            Assert.IsTrue(ratDriver.ElementExists(devLink));

            ratDriver.ClickLinkAndWait(devLink);
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }

        [Test]
        [TestCase(EnumPhoneType.AppleiPhone6Plus, true)]
        [Category("MobileNavigation")]
        public void Chrome_MobileDriver_ClickMenu(EnumPhoneType phone, bool touch)
        {
            RatDriver<ChromeDriver> ratDriver = new RatDriver<ChromeDriver>(phone, touch);
            ratDriver.NavigateToPage("http://www.totallyratted.com");
            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("totallyratted"));

            var buttonLink = ratDriver.FindElementByXPath("html/body/div[1]/div/div[1]/button");
            Assert.IsTrue(ratDriver.ElementExists(buttonLink));

            ratDriver.ClickLink(buttonLink);

            var devLink = ratDriver.FindElementByXPath("html/body/div[1]/div/div[2]/ul/li[2]/a");
            ratDriver.ClickLinkAndWait(devLink);

            Assert.IsTrue(ratDriver.GetBrowserWindowUrl().Contains("developments"));
            ratDriver.ClosePagesAndQuitDriver();
        }
    }
}
