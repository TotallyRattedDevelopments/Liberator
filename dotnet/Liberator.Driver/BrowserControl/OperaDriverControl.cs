using Liberator.Driver.Enums;
using Liberator.Driver.Preferences;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using System;
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
                Driver = new OperaDriver(Directory.GetParent(BaseSettings.OperaDriverLocation).FullName, Options, BaseSettings.Timeout);
                return Driver;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
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
                bool.TryParse(Opera.LeaveBrowserRunning, out bool running);

                OperaOptions options = new OperaOptions()
                {
                    BinaryLocation = BaseSettings.OperaLocation,
                    DebuggerAddress = Opera.DebuggerAddress ?? null,
                    LeaveBrowserRunning = running,
                    MinidumpPath = Opera.MinidumpPath ?? null
                };
                Options = options;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not set the opera diver options.");
                        Console.Out.WriteLine("Please investigate the changes you have made to your config file.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.Out.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.Out.WriteLine(ex.Message);
                        Console.Out.WriteLine(ex.StackTrace);
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

                int.TryParse(Opera.AndroidDebugBridgePort, out android);
                bool.TryParse(Opera.EnableVerboseLogging, out bool verbose);
                bool.TryParse(Opera.HideCommandPromptWindow, out bool hidePrompt);
                int.TryParse(Opera.Port, out int port);
                bool.TryParse(Opera.SuppressInitialDiagnosticInformation, out bool sidi);

                string operaLocation = BaseSettings.OperaDriverLocation;

                string logPath = Opera.LogPath;
                string portServer = Opera.PortServerAddress;
                string prefix = Opera.UrlPathPrefix;

                OperaDriverService service = OperaDriverService.CreateDefaultService(operaLocation);
                service.AndroidDebugBridgePort = android >= 0 ? android : -1;
                service.EnableVerboseLogging = verbose;
                service.HideCommandPromptWindow = hidePrompt;
                service.Port = port;
                service.PortServerAddress = portServer ?? null;
                service.SuppressInitialDiagnosticInformation = sidi;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not start the opera driver service.");
                        Console.Out.WriteLine("Please investigate the changes you have made to your config file.");
                        break;
                    case EnumConsoleDebugLevel.NotSpecified:
                    case EnumConsoleDebugLevel.Message:
                        Console.Out.WriteLine(ex.Message);
                        break;
                    case EnumConsoleDebugLevel.StackTrace:
                        Console.Out.WriteLine(ex.Message);
                        Console.Out.WriteLine(ex.StackTrace);
                        break;
                }
            }
        }

        #endregion
    }
}
