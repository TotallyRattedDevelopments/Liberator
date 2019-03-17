using Liberator.Driver.BrowserControl;
using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Liberator.Driver
{
    /// <summary>
    /// Base class for the RatDriver emulation layer
    /// </summary>
    /// <typeparam name="TWebDriver">The type of web driver to create</typeparam>
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        #region Internal Variables

        TimeSpan _timeout;
        TimeSpan _sleepInterval;
        Actions _action;

        List<int> _originalPids;
        List<int> _postTestPids;
        List<int> _browserDriverPids;

        int _browserPid = 0;
        int _driverPid = 0;

        #endregion

        #region Constructor & Helpers

        /// <summary>
        /// Base constructor for RatDriver
        /// </summary>
        public RatDriver()
        {
            EstablishDriverSettings();
            string driverType = typeof(TWebDriver).Name;
            
            GetPidsOfExistingBrowsersAndDrivers(driverType);
            string type = "Liberator.Driver.BrowserControl." + driverType + "Control";
            IBrowserControl controller = (IBrowserControl)Activator.CreateInstance(Type.GetType(type));
            Driver = (TWebDriver)controller.StartDriver();
            WaitForPageToLoad(null);
            WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            ExtractProcessIdsForCurrentBrowserAndDriver(driverType);
        }

        /// <summary>
        /// Creates an anstance of Firefox with a specified profile
        /// </summary>
        /// <param name="profileName">The name of the profile to load</param>
        public RatDriver(string profileName)
        {
            string driverType = typeof(TWebDriver).Name;

            if (typeof(TWebDriver) == typeof(FirefoxDriver))
            {
                EstablishDriverSettings();
                FirefoxDriverControl controller = new FirefoxDriverControl();
                Driver = (TWebDriver)controller.StartDriverSavedProfile(profileName);
                WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            }
            else
            {
                Console.WriteLine("{0} does not currently allow the loading of profiles.", driverType);
                Console.WriteLine("Please switch to Firefox if named profile loading is required");
            }
        }

        /// <summary>
        /// Creates a firefox instance using a profile directory path
        /// </summary>
        /// <param name="profileDirectory">The path of the profile directory</param>
        /// <param name="cleanDirectory">Whether to clean the directory</param>
        public RatDriver(string profileDirectory, bool cleanDirectory)
        {
            string driverType = typeof(TWebDriver).Name;

            if (typeof(TWebDriver) == typeof(FirefoxDriver))
            {
                EstablishDriverSettings();
                FirefoxDriverControl controller = new FirefoxDriverControl();
                Driver = (TWebDriver)controller.StartDriverLoadProfileFromDisk(profileDirectory, cleanDirectory);
                WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            }
            else
            {
                Console.WriteLine("{0} does not currently allow the loading of profiles.", driverType);
                Console.WriteLine("Please switch to Firefox if named profile loading is required");
            }
        }

        /// <summary>
        /// Creates a chrome driver instance in modile emulation mode
        /// </summary>
        /// <param name="type">Which type of phone to emulate</param>
        /// <param name="touch">(Optional Parameter) Whether touch actions are enabled</param>
        public RatDriver(EnumPhoneType type, [Optional, DefaultParameterValue(false)] bool touch)
        {
            string driverType = typeof(TWebDriver).Name;

            if (typeof(TWebDriver) == typeof(ChromeDriver))
            {
                EstablishDriverSettings();
                ChromeDriverControl controller = new ChromeDriverControl();
                Driver = (TWebDriver)controller.StartMobileDriver(type, touch);
                WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            }
            else
            {
                Console.WriteLine("{0} does not currently allow the loading of profiles.", driverType);
                Console.WriteLine("Please switch to Chrome if mobile emulation is required");
            }
        }

        /// <summary>
        /// Creates a chrome driver instance in modile emulation mode
        /// </summary>
        /// <param name="height">The height of the screen</param>
        /// <param name="width">The width of the screen</param>
        /// <param name="userAgent">The user agent returned by the device</param>
        /// <param name="pixelRatio">The pixel ratio of the screen</param>
        /// <param name="touch">(Optional Parameter) Whether touch actions are enabled</param>
        public RatDriver(Int64 height, Int64 width, string userAgent, double pixelRatio, [Optional, DefaultParameterValue(false)] bool touch)
        {
            string driverType = typeof(TWebDriver).Name;

            if (typeof(TWebDriver) == typeof(ChromeDriver))
            {
                EstablishDriverSettings();
                ChromeDriverControl controller = new ChromeDriverControl();
                Driver = (TWebDriver)controller.StartMobileDriver(height, width, userAgent, pixelRatio, touch);
                WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            }
            else
            {
                Console.WriteLine("{0} does not currently allow the loading of profiles.", driverType);
                Console.WriteLine("Please switch to Chrome if mobile emulation is required");
            }
        }

        #endregion

        #region Private Methods

        private void GetWebDriverSettings()
        {
            var si = Preferences.BaseSettings.KVList["Sleep"].Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            _sleepInterval = new TimeSpan(Convert.ToInt32(si[0]),
                                                    Convert.ToInt32(si[1]),
                                                    Convert.ToInt32(si[2]),
                                                    Convert.ToInt32(si[3]),
                                                    Convert.ToInt32(si[4]));

            var to = Preferences.BaseSettings.KVList["Timeout"].Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            _timeout = new TimeSpan(Convert.ToInt32(to[0]),
                                                    Convert.ToInt32(to[1]),
                                                    Convert.ToInt32(to[2]),
                                                    Convert.ToInt32(to[3]),
                                                    Convert.ToInt32(to[4]));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Waits for a page to load
        /// </summary>
        /// <param name="element">An element from the previous page. If omitted, the code will wait for the body of the page to be viosible</param>
        public void WaitForPageToLoad(IWebElement element)
        {
            if (element == null)
            {
                var load = new WebDriverWait(Driver, _timeout)
                    .Until(Liberator.ExpectedConditions.ElementIsVisible(By.TagName("body")));
            }
            else if (typeof(TWebDriver) != typeof(OperaDriver))
            {
                var wait = new WebDriverWait(Driver, _timeout)
                    .Until(
                    Liberator.ExpectedConditions.StalenessOf(element));
            }
            else
            {
                //TODO: Investigate the Opera Driver with respect to DOM staleness
                Console.WriteLine("Opera does not currently seem to report staleness of the DOM. Under investigation");
            }
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverType"></param>
        public void GetPidsOfExistingBrowsersAndDrivers(string driverType)
        {
            GetProcessIds(out _originalPids);
        }


        private void ExtractProcessIdsForCurrentBrowserAndDriver(string driverType)
        {
            GetProcessIds(out _postTestPids);
            _browserDriverPids = _postTestPids.Except(_originalPids).ToList();
            var browserName = BrowserProcessName(driverType);
            var driverName = DriverProcessName(driverType);
        }


        private void GetProcessIds(out List<int> pids)
        {
            Process[] _processes = Process.GetProcesses();
            pids = _processes.Select(d => d.Id).ToList();
        }

        private void EstablishDriverSettings()
        {
            Preferences.BaseSettings.GetPreferences();
            Id = Guid.NewGuid();
            WindowHandles = new Dictionary<string, string>();
            GetWebDriverSettings();
        }

        /// <summary>
        /// Returne the name of the process used by the prowser
        /// </summary>
        /// <returns>The name of the browser process</returns>
        private string BrowserProcessName(string driverType)
        {
            switch (driverType.ToLower())
            {
                case "chromedriver":
                    return "chrome";
                case "edgedriver":
                    return "microsoftedge";
                case "firefoxdriver":
                    return "firefox";
                case "internetexplorerdriver":
                    return "iexplorer";
                case "operadriver":
                    return "opera";

            }
            return null;
        }

        /// <summary>
        /// Returne the name of the process used by the prowser
        /// </summary>
        /// <returns>The name of the browser process</returns>
        private string DriverProcessName(string driverType)
        {
            switch (driverType.ToLower())
            {
                case "chromedriver":
                    return "chromedriver";
                case "edgedriver":
                    return "msdriver";
                case "firefoxdriver":
                    return "geckodriver";
                case "internetexplorerdriver":
                    return "iedriver";
                case "operadriver":
                    return "operadriver";
            }
            return null;
        }
        
    }
}