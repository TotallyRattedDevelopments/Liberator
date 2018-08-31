using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Liberator.Driver.BrowserControl
{
    internal class EdgeDriverControl : IBrowserControl
    {
        #region Public Properties
        
        /// <summary>
        /// Holds the instantiated Edge Driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Holds the preset values for Edge Options
        /// </summary>
        public EdgeOptions Options { get; set; }

        /// <summary>
        /// The Edge driver service
        /// </summary>
        public EdgeDriverService Service { get; set; }

        /// <summary>
        /// The maximum amount of time to wait between commands
        /// </summary>
        public TimeSpan CommandTimeout { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Loads preset values for the driver and service from the app.config file
        /// </summary>
        public EdgeDriverControl()
        {
            string timeout = Preferences.Preferences.GetPreferenceSetting("Timeout");
            if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
            var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the Edge Driver with the preset values from app.config
        /// </summary>
        /// <returns>An instance of the Edge Driver</returns>
        public IWebDriver StartDriver()
        {
            try
            {
                Process[] webdrivers = Process.GetProcessesByName("MicrosoftWebDriver");
                foreach (Process driver in webdrivers) { driver.Kill(); }
                SetEdgeOptions();
                SetEdgeDriverService();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Driver = new EdgeDriver(Preferences.Preferences.GetPreferenceSetting("Edge_DriverPath"), Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start Edge driver.");
                        Console.WriteLine("Please investigate the changes you have made to your config file.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        break;
                }
                return null;
            }
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Sets the Chrome Options from the app.config file
        /// </summary>
        private void SetEdgeOptions()
        {
            try
            {
                EdgePageLoadStrategy epls = EdgePageLoadStrategy.Default;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("Edge_PageLoadStrategy"), out epls);
                EdgeOptions options = new EdgeOptions()
                {
                    PageLoadStrategy = (PageLoadStrategy)epls
                };
                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not configure the Edge Driver Options settings.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the Chrome Driver Service setting from the app.config file
        /// </summary>
        private void SetEdgeDriverService()
        {
            try
            {
                bool command = false;
                Int32 port = 4444;
                bool sidi = false;
                bool verbose = false;

                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Edge_HideCommandPromptWindow"), out command);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("Edge_Port"), out port);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Edge_SuppressInitialDiagnosticInformation"), out sidi);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Edge_UseVerboseLogging"), out verbose);


                string driverLocation = Preferences.Preferences.GetPreferenceSetting("Edge_DriverPath");
                string path = null;

                if (driverLocation != "" || driverLocation != null) { path = Preferences.Preferences.DriverPath; }
                else { path = driverLocation; }

                string host = Preferences.Preferences.GetPreferenceSetting("Edge_Host");
                string package = Preferences.Preferences.GetPreferenceSetting("Edge_Package");

                EdgeDriverService service = EdgeDriverService.CreateDefaultService(path);
                service.HideCommandPromptWindow = command;
                if (host.Contains(@"\")) { service.Host = host; }
                if (host.Contains(@"\")) { service.Package = package; }
                service.Port = Convert.ToInt32(port);
                service.SuppressInitialDiagnosticInformation = sidi;
                service.UseVerboseLogging = verbose;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not configure the Edge Driver Service settings.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        break;
                }
            }
        }

        #endregion
    }
}
