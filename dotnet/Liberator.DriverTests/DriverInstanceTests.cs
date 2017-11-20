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
    public class DriverInstanceTests
    {
        [Category("PackRat")]
        [Test]
        public void CreateNewInstance()
        {
            PackRat packrat = new PackRat();
            IRodent rodent = packrat.CreateDriverInstance(EnumDriverType.ChromeDriver);
            Thread.Sleep(2000);
            Assert.IsInstanceOf(typeof(RatDriver<ChromeDriver>), rodent);
            packrat.CloseDriverInstance(rodent.Id);
        }

        [Category("PackRat")]
        [Test]
        public void CreateTwoInstances()
        {
            PackRat packrat = new PackRat();

            IRodent rodent = packrat.CreateDriverInstance(EnumDriverType.ChromeDriver);
            Thread.Sleep(2000);
            string rodentHandle = rodent.GetCurrentWindowHandle();

            IRodent gopher = packrat.CreateDriverInstance(EnumDriverType.FirefoxDriver);
            Thread.Sleep(2000);
            string gopherHandle = gopher.GetCurrentWindowHandle();


            rodent.SwitchToWindow(rodentHandle);
            rodent.NavigateToPage("http://www.totallyratted.com");

            gopher.SwitchToWindow(gopherHandle);
            gopher.NavigateToPage("http://www.google.com");

            rodent.SwitchToWindow(rodentHandle);
            rodent.ClosePagesAndQuitDriver();

            gopher.SwitchToWindow(gopherHandle);
            gopher.ClosePagesAndQuitDriver();
        }

    }
}
