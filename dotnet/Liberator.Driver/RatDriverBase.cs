using Liberator.Driver.BrowserControl;
using Liberator.Driver.Enums;
using Liberator.Driver.Performance;
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
        /// <param name="performanceTimings">Whether to obtain performance timings for the browser.</param>
        public RatDriver([Optional, DefaultParameterValue(false)]bool performanceTimings)
        {
            if (performanceTimings) { InitialiseRatWatch(performanceTimings); }

            EstablishDriverSettings();
            string driverType = typeof(TWebDriver).Name;
            GetPidsOfExistingBrowsersAndDrivers(driverType);
            string type = "Liberator.Driver.BrowserControl." + driverType + "Control";
            IBrowserControl controller = (IBrowserControl)Activator.CreateInstance(Type.GetType(type));
            Driver = (TWebDriver)controller.StartDriver();

            if (performanceTimings) { RatTimerCollection.StopTimer(EnumTiming.Instantiation); }

            WaitForPageToLoad(null);
            WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            ExtractProcessIdsForCurrentBrowserAndDriver(driverType);
        }

        /// <summary>
        /// Creates an anstance of Firefox with a specified profile
        /// </summary>
        /// <param name="profileName">The name of the profile to load</param>
        /// <param name="performanceTimings">Whether to obtain performance timings for the browser.</param>
        public RatDriver(string profileName, [Optional, DefaultParameterValue(false)]bool performanceTimings)
        {
            if (performanceTimings) { InitialiseRatWatch(performanceTimings); }

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
            
            if (performanceTimings) { RatTimerCollection.StopTimer(EnumTiming.Instantiation); }
        }

        /// <summary>
        /// Creates a firefox instance using a profile directory path
        /// </summary>
        /// <param name="profileDirectory">The path of the profile directory</param>
        /// <param name="cleanDirectory">Whether to clean the directory</param>
        /// <param name="performanceTimings">Whether to obtain performance timings for the browser.</param>
        public RatDriver(string profileDirectory, bool cleanDirectory, [Optional, DefaultParameterValue(false)]bool performanceTimings)
        {
            if (performanceTimings) { InitialiseRatWatch(performanceTimings); }

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

            if (performanceTimings) { RatTimerCollection.StopTimer(EnumTiming.Instantiation); }
        }

        /// <summary>
        /// Creates a chrome driver instance in modile emulation mode
        /// </summary>
        /// <param name="type">Which type of phone to emulate</param>
        /// <param name="touch">(Optional Parameter) Whether touch actions are enabled</param>
        /// <param name="performanceTimings">Whether to obtain performance timings for the browser.</param>
        public RatDriver(EnumPhoneType type, [Optional, DefaultParameterValue(false)] bool touch, [Optional, DefaultParameterValue(false)]bool performanceTimings)
        {
            if (performanceTimings) { InitialiseRatWatch(performanceTimings); }

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

            if (performanceTimings) { RatTimerCollection.StopTimer(EnumTiming.Instantiation); }
        }

        /// <summary>
        /// Creates a chrome driver instance in modile emulation mode
        /// </summary>
        /// <param name="height">The height of the screen</param>
        /// <param name="width">The width of the screen</param>
        /// <param name="userAgent">The user agent returned by the device</param>
        /// <param name="pixelRatio">The pixel ratio of the screen</param>
        /// <param name="touch">(Optional Parameter) Whether touch actions are enabled</param>
        /// <param name="performanceTimings">Whether to obtain performance timings for the browser.</param>
        public RatDriver(Int64 height, Int64 width, string userAgent, double pixelRatio,
            [Optional, DefaultParameterValue(false)] bool touch, [Optional, DefaultParameterValue(false)]bool performanceTimings)
        {
            if (performanceTimings) { InitialiseRatWatch(performanceTimings); }

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

            if (performanceTimings) { RatTimerCollection.StopTimer(EnumTiming.Instantiation); }
        }

        #endregion

        #region Private Methods

        private void GetWebDriverSettings()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Waits for a page to load
        /// </summary>
        /// <param name="element">An element from the previous page. If omitted, the code will wait for the body of the page to be viosible</param>
        public void WaitForPageToLoad(IWebElement element)
        {
            if (RecordPerformance) { RatTimerCollection.StartTimer(); }

            if (element == null)
            {
                var load = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(Liberator.ExpectedConditions.ElementIsVisible(By.TagName("body")));
            }
            else if (typeof(TWebDriver) != typeof(OperaDriver))
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(
                    Liberator.ExpectedConditions.StalenessOf(element));
            }
            else
            {
                //TODO: Investigate the Opera Driver with respect to DOM staleness
                Console.WriteLine("Opera does not currently seem to report staleness of the DOM. Under investigation");
            }

            if (RecordPerformance) { RatTimerCollection.StopTimer(EnumTiming.PageLoad); }
        }
        #endregion



        /// <summary>
        /// Gets the Process IDs for existing browsers and web drivers
        /// </summary>
        /// <param name="driverType">Type of driver being used.</param>
        public void GetPidsOfExistingBrowsersAndDrivers(string driverType)
        {
            GetProcessIds(out _originalPids);
        }

        /// <summary>
        /// Extracts the Process IDs for the current browser and web driver.
        /// </summary>
        /// <param name="driverType">Type of driver being used.</param>
        private void ExtractProcessIdsForCurrentBrowserAndDriver(string driverType)
        {
            GetProcessIds(out _postTestPids);
            _browserDriverPids = _postTestPids.Except(_originalPids).ToList();
            var browserName = BrowserProcessName(driverType);
            var driverName = DriverProcessName(driverType);
        }

        /// <summary>
        /// Gets the Process IDs for all running executables.
        /// </summary>
        /// <param name="pids">A list of Process IDs</param>
        private void GetProcessIds(out List<int> pids)
        {
            Process[] _processes = Process.GetProcesses();
            pids = _processes.Select(d => d.Id).ToList();
        }

        /// <summary>
        /// Initialises driver settings.
        /// </summary>
        private void EstablishDriverSettings()
        {
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

        /// <summary>
        /// Initialises the RatWatch for performance gathering
        /// </summary>
        /// <param name="performanceTimings">Whether to collect timings</param>
        private void InitialiseRatWatch(bool performanceTimings)
        {
            RatTimerCollection = new RatWatch();
            RatTimerCollection.StartTimer();
            RecordPerformance = performanceTimings;
        }

    }
}