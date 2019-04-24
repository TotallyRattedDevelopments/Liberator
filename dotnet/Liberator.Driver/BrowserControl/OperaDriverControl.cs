using Liberator.Driver.Enums;
using Liberator.Driver.Preferences;
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

        }

        /// <summary>
        /// Allows the specification of Opera Driver settings
        /// </summary>
        /// <param name="operaSettings">The settings file to be used.</param>
        public OperaDriverControl(OperaSettings operaSettings)
        {
            if (operaSettings != null)
            {
                Opera.AndroidDebugBridgePort = operaSettings.AndroidDebugBridgePort;
                Opera.DebuggerAddress = operaSettings.DebuggerAddress;
                Opera.EnableVerboseLogging = operaSettings.EnableVerboseLogging;
                Opera.HideCommandPromptWindow = operaSettings.HideCommandPromptWindow;
                Opera.LeaveBrowserRunning = operaSettings.LeaveBrowserRunning;
                Opera.LogPath = operaSettings.LogPath;
                Opera.MinidumpPath = operaSettings.MinidumpPath;
                Opera.Port = operaSettings.Port;
                Opera.PortServerAddress = operaSettings.PortServerAddress;
                Opera.SuppressInitialDiagnosticInformation = operaSettings.SuppressInitialDiagnosticInformation;
                Opera.UrlPathPrefix = operaSettings.UrlPathPrefix;
            }
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
                SetOperaOptions();
                //SetOperaDriverService();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Driver = new OperaDriver(Directory.GetParent(Preferences.BaseSettings.OperaDriverLocation).FullName, Options, Preferences.BaseSettings.Timeout);
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
                bool.TryParse(Preferences.Opera.LeaveBrowserRunning, out bool running);

                OperaOptions options = new OperaOptions()
                {
                    BinaryLocation = Preferences.BaseSettings.OperaLocation,
                    DebuggerAddress = Preferences.Opera.DebuggerAddress ?? null,
                    LeaveBrowserRunning = running,
                    MinidumpPath = Preferences.Opera.MinidumpPath ?? null
                };
                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
                int android = -1;

                int.TryParse(Preferences.Opera.AndroidDebugBridgePort, out android);
                bool.TryParse(Preferences.Opera.EnableVerboseLogging, out bool verbose);
                bool.TryParse(Preferences.Opera.HideCommandPromptWindow, out bool hidePrompt);
                int.TryParse(Preferences.Opera.Port, out int port);
                bool.TryParse(Preferences.Opera.SuppressInitialDiagnosticInformation, out bool sidi);

                string operaLocation = Preferences.BaseSettings.OperaDriverLocation;

                string logPath = Preferences.Opera.LogPath;
                string portServer = Preferences.Opera.PortServerAddress;
                string prefix = Preferences.Opera.UrlPathPrefix;

                OperaDriverService service = OperaDriverService.CreateDefaultService(operaLocation);
                service.AndroidDebugBridgePort = android >= 0 ? android : -1 ;
                service.EnableVerboseLogging = verbose;
                service.HideCommandPromptWindow = hidePrompt;
                service.Port = port;
                service.PortServerAddress = portServer ?? null;
                service.SuppressInitialDiagnosticInformation = sidi;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
