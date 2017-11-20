using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Liberator.Driver
{
    public class PackRat
    {
        #region Accessors

        /// <summary>
        /// The collection of driver instances under control of PackRat
        /// </summary>
        public Dictionary<Guid, IRodent> DriverInstances { get; set; }

        /// <summary>
        /// The Driver currently receiving commands
        /// </summary>
        public IRodent CurrentDriver { get; set; }

        /// <summary>
        /// Shows a particular window
        /// </summary>
        /// <param name="hWnd">The hWnd</param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion

        public PackRat()
        {
            DriverInstances = new Dictionary<Guid, IRodent>();
        }

        #region Public Method

        public IRodent CreateDriverInstance(EnumDriverType type)
        {
            switch (type)
            {
                case EnumDriverType.NotSpecified:
                case EnumDriverType.FirefoxDriver:
                    CurrentDriver = new RatDriver<FirefoxDriver>();
                    break;
                case EnumDriverType.ChromeDriver:
                    CurrentDriver = new RatDriver<ChromeDriver>();
                    break;
                case EnumDriverType.EdgeDriver:
                    CurrentDriver = new RatDriver<EdgeDriver>();
                    break;
                case EnumDriverType.PhantomJSDriver:
                    CurrentDriver = new RatDriver<PhantomJSDriver>();
                    break;
                case EnumDriverType.InternetExplorerDriver:
                    CurrentDriver = new RatDriver<InternetExplorerDriver>();
                    break;
                case EnumDriverType.OperaDriver:
                    CurrentDriver = new RatDriver<OperaDriver>();
                    break;
            }
            DriverInstances.Add(CurrentDriver.Id, CurrentDriver);
            return CurrentDriver;
        }

        public bool SwitchToInstance(Guid id)
        {
            try
            {
                CurrentDriver = DriverInstances.Where(i => i.Key == id).First().Value;
                
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot switch to an instance with the Id: {0}", id);
                return false;
            }
        }

        public bool CloseDriverInstance(Guid id)
        {
            try
            {
                SwitchToInstance(id);
                CurrentDriver.FindElementByClassName("body");
                CurrentDriver.ClosePagesAndQuitDriver();
                DriverInstances.Remove(id);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to close the driver instance with the Id: {0}", id);
                return false;
            }
        }

        #endregion
    }
}
