using Liberator.Driver.Enums;
using Liberator.Driver.Preferences;
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

        #endregion

        #region Constructors

        /// <summary>
        /// Loads preset values for the driver and service from the app.config file
        /// </summary>
        public EdgeDriverControl()
        {
            Options = new EdgeOptions();
        }

        /// <summary>
        /// Allows the specification of Edge Driver settings
        /// </summary>
        /// <param name="edgeSettings">The settings file to be used.</param>
        public EdgeDriverControl(EdgeSettings edgeSettings)
        {
            Options = new EdgeOptions();

            if (edgeSettings != null)
            {
                Edge.HideCommandPromptWindow = edgeSettings.HideCommandPromptWindow;
                Edge.Host = edgeSettings.Host;
                Edge.Package = edgeSettings.Package;
                Edge.Port = edgeSettings.Port;
                Edge.SuppressInitialDiagnosticInformation = edgeSettings.SuppressInitialDiagnosticInformation;
                Edge.UseVerboseLogging = edgeSettings.UseVerboseLogging;
            }
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
                SetEdgeDriverService();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Driver = new EdgeDriver(Directory.GetParent(Preferences.BaseSettings.EdgeDriverLocation).FullName, Options, Preferences.BaseSettings.Timeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
        /// Sets the Chrome Driver Service setting from the app.config file
        /// </summary>
        private void SetEdgeDriverService()
        {
            try
            {

                bool.TryParse(Preferences.Edge.HideCommandPromptWindow, out bool command);
                int.TryParse(Preferences.Edge.Port, out int port);
                bool.TryParse(Preferences.Edge.SuppressInitialDiagnosticInformation, out bool sidi);
                bool.TryParse(Preferences.Edge.UseVerboseLogging, out bool verbose);
                
                string driverLocation = Directory.GetParent(Preferences.BaseSettings.EdgeDriverLocation).FullName;

                string host = Preferences.Edge.Host;
                string package = Preferences.Edge.Package;

                EdgeDriverService service = EdgeDriverService.CreateDefaultService(driverLocation);
                service.HideCommandPromptWindow = command;
                service.Host = host ?? null;
                service.Package = package ?? null;
                service.Port = Convert.ToInt32(port);
                service.SuppressInitialDiagnosticInformation = sidi;
                service.UseVerboseLogging = verbose;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
