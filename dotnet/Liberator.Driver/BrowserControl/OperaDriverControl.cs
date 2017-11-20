using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Liberator.Driver.BrowserControl
{
    internal class OperaDriverControl : IBrowserControl
    {
        #region Public Properties

        /// <summary>
        /// Holds the preset values for Opera Options
        /// </summary>
        public OperaOptions Options { get; set; }

        /// <summary>
        /// The Internet Explorer driver service
        /// </summary>
        public OperaDriverService Service { get; set; }

        /// <summary>
        /// Holds the instantiated Opera Driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// The maximum amount of time to wait between commands
        /// </summary>
        public TimeSpan CommandTimeout { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Loads the settings from the app.config file
        /// </summary>
        public OperaDriverControl()
        {
            string timeout = Preferences.Preferences.GetPreferenceSetting("Timeout");
            if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
            var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  Starts the Opera Driver with the preset values from app.config
        /// </summary>
        /// <returns>An instance of the Opera driver</returns>
        public IWebDriver StartDriver()
        {
            try
            {
                Process[] chromedrivers = Process.GetProcessesByName("operadriver");
                foreach (Process driver in chromedrivers) { driver.Kill(); }
                SetOperaOptions();
                //SetOperaDriverService();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Driver = new OperaDriver(Path.GetDirectoryName(assembly.Location) + Preferences.Preferences.GetPreferenceSetting("DriverPath"), Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the Opera Options from the app.config file
        /// </summary>
        private void SetOperaOptions()
        {
            try
            {
                bool running = false;
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Opera_LeaveBrowserRunning"), out running);

                OperaOptions options = new OperaOptions()
                {
                    BinaryLocation = Preferences.Preferences.GetPreferenceSetting("Opera_BinaryLocation"),
                    DebuggerAddress = Preferences.Preferences.GetPreferenceSetting("Opera_DebuggerAddress"),
                    LeaveBrowserRunning = running,
                    MinidumpPath = Preferences.Preferences.GetPreferenceSetting("Opera_MinidumpPath")
                };
                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the opera diver options.");
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
            }
        }

        /// <summary>
        /// Sets the Opera Driver Service setting from the app.config file
        /// </summary>
        private void SetOperaDriverService()
        {
            try
            {
                Int32 android = -1;
                bool verbose = true;
                bool hidePrompt = true;
                Int32 port = 4444;
                bool sidi = false;

                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("Opera_AndroidDebugBridgePort"), out android);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Opera_EnableVerboseLogging"), out verbose);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Opera_HideCommandPromptWindow"), out hidePrompt);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("Opera_Port"), out port);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Opera_SuppressInitialDiagnosticInformation"), out sidi);

                string operaLocation = Preferences.Preferences.GetPreferenceSetting("Opera_DriverPath");
                string path = null;

                if (operaLocation != "" || operaLocation != null) { path = Preferences.Preferences.DriverPath; }
                else { path = operaLocation; }

                string logPath = Preferences.Preferences.GetPreferenceSetting("Opera_LogPath");
                string portServer = Preferences.Preferences.GetPreferenceSetting("Opera_PortServerAddress");
                string prefix = Preferences.Preferences.GetPreferenceSetting("Opera_UrlPathPrefix");

                OperaDriverService service = OperaDriverService.CreateDefaultService(path);
                service.AndroidDebugBridgePort = android;
                service.EnableVerboseLogging = verbose;
                service.HideCommandPromptWindow = hidePrompt;
                if (logPath.Length > 1) { service.LogPath = logPath; }
                service.Port = port;
                if (portServer.Length > 1) { service.PortServerAddress = portServer; }
                service.SuppressInitialDiagnosticInformation = sidi;
                if (prefix.Length > 1) { service.UrlPathPrefix = prefix; }
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start the opera driver service.");
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
            }
        }

        #endregion
    }
}
