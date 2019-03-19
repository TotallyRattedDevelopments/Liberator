using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Diagnostics;
using System.IO;

namespace Liberator.Driver.BrowserControl
{
    internal class InternetExplorerDriverControl : IBrowserControl
    {
        #region Public Properties

        /// <summary>
        /// Holds the preset values for Internet Explorer Options
        /// </summary>
        public InternetExplorerOptions Options { get; set; }

        /// <summary>
        /// The Internet Explorer driver service
        /// </summary>
        public InternetExplorerDriverService Service { get; set; }

        /// <summary>
        /// Holds the instantiated Internet Explorer Driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        ///// <summary>
        ///// The proxy settings for Internet Explorer
        ///// </summary>
        //public Proxy IEProxy { get; set; }

        /// <summary>
        /// The maximum sleep intervall
        /// </summary>
        public TimeSpan SleepInterval { get; set; }

        /// <summary>
        /// The maximum time to wait for the browser to load
        /// </summary>
        public TimeSpan BrowserTimeout { get; set; }

        /// <summary>
        /// The maximum amount of time to wait between commands
        /// </summary>
        public TimeSpan CommandTimeout { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Loads the settings from the app.config file
        /// </summary>
        public InternetExplorerDriverControl()
        {
            //SetInternetExplorerProxy();
            SetInternetExplorerOptions();
            SetInternetExplorerDriverService();
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  Starts the Internet Explorer Driver with the preset values from app.config
        /// </summary>
        /// <returns>An instance of the Internet Explorer driver</returns>
        public IWebDriver StartDriver()
        {
            try
            {
                Process[] iedrivers = Process.GetProcessesByName("IEDriverServer");
                foreach (Process driver in iedrivers) { driver.Kill(); }
                //SetInternetExplorerProxy();
                SetInternetExplorerOptions();
                SetInternetExplorerDriverService();
                //Driver = new InternetExplorerDriver(Service, Options, Preferences.BaseSettings.Timeout);
                Driver = new InternetExplorerDriver(Service);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start internet explorer driver.");
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
        /// Sets the Internet Explorer Options from the app.config file
        /// </summary>
        private void SetInternetExplorerOptions()
        {
            try
            {

                InternetExplorerElementScrollBehavior scroll = InternetExplorerElementScrollBehavior.Bottom;
                Enum.TryParse(Preferences.InternetExplorer.ScrollBehavior, out scroll);

                Boolean.TryParse(Preferences.InternetExplorer.EnableFullPageScreenshot, out bool screenshot);
                Boolean.TryParse(Preferences.InternetExplorer.EnableNativeEvents, out bool native);
                Boolean.TryParse(Preferences.InternetExplorer.EnablePersistentHover, out bool hover);
                Boolean.TryParse(Preferences.InternetExplorer.EnsureCleanSession, out bool cleanSession);
                Boolean.TryParse(Preferences.InternetExplorer.ForceCreateProcessApi, out bool forceCreate);
                Boolean.TryParse(Preferences.InternetExplorer.ForceShellWindowsApi, out bool forceShell);
                Boolean.TryParse(Preferences.InternetExplorer.IgnoreZoomLevel, out bool ignoreZoom);
                Boolean.TryParse(Preferences.InternetExplorer.IntroduceInstability, out bool instability);
                Boolean.TryParse(Preferences.InternetExplorer.RequireWindowFocus, out bool requireFocus);
                Boolean.TryParse(Preferences.InternetExplorer.UsePerProcessProxy, out bool perProcess);

                string cmdLine = Preferences.InternetExplorer.CommandLineArguments;
                string url = Preferences.InternetExplorer.InitialBrowserUrl;

                InternetExplorerOptions options = new InternetExplorerOptions
                {
                    BrowserAttachTimeout = Preferences.BaseSettings.Timeout
                };

                options.BrowserCommandLineArguments = cmdLine ?? null;

                options.ElementScrollBehavior = scroll;
//              options.EnableFullPageScreenshot = screenshot;
                options.EnableNativeEvents = native;
                options.EnablePersistentHover = hover;
                options.EnsureCleanSession = cleanSession;
                options.FileUploadDialogTimeout = Preferences.InternetExplorer.FileUploadTimeout;
                options.ForceCreateProcessApi = forceCreate;
                options.ForceShellWindowsApi = forceShell;
                options.IgnoreZoomLevel = ignoreZoom;
                options.InitialBrowserUrl = url;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = instability;
//              options.Proxy = IEProxy;
                options.RequireWindowFocus = requireFocus;
//              options.UnexpectedAlertBehavior = alert;
                options.UsePerProcessProxy = perProcess;

                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the internet explorer driver options settings.");
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
        /// Sets the Internet Explorer Driver Service setting from the app.config file
        /// </summary>
        private void SetInternetExplorerDriverService()
        {
            try
            {
                InternetExplorerDriverLogLevel logLevel = InternetExplorerDriverLogLevel.Debug;
                Enum.TryParse(Preferences.InternetExplorer.LoggingLevel, out logLevel);

                bool.TryParse(Preferences.InternetExplorer.HideCommandPromptWindow, out bool hidePrompt);
                int.TryParse(Preferences.InternetExplorer.Port, out int port);
                bool.TryParse(Preferences.InternetExplorer.SuppressInitialDiagnosticInformation, out bool sidi);

                string ieHost = Preferences.InternetExplorer.Host;
                string extract = Preferences.InternetExplorer.LibraryExtractionPath;
                string log = Preferences.InternetExplorer.LibraryExtractionPath;
                string whitelist = Preferences.InternetExplorer.WhitelistedIPAddresses;

                InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(Directory.GetParent(Preferences.BaseSettings.InternetExplorerDriverLocation).FullName);
                service.HideCommandPromptWindow = hidePrompt;
                service.Host = ieHost ?? null;
                service.LibraryExtractionPath = extract ?? null;
                service.LogFile = log ?? null;
                service.LoggingLevel = logLevel;
                service.Port = port;
                service.SuppressInitialDiagnosticInformation = sidi;
                service.WhitelistedIPAddresses = whitelist ?? null;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the internet explorer driver service settings.");
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

        ///// <summary>
        ///// Sets the Proxy settings for Internet Explorer from the app.config file
        ///// </summary>
        //private void SetInternetExplorerProxy()
        //{
        //    Proxy proxy = new Proxy()
        //    {
        //        FtpProxy = Preferences.Preferences.GetPreferenceSetting("IE_FtpProxy"),
        //        HttpProxy = Preferences.Preferences.GetPreferenceSetting("IE_HttpProxy"),
        //        IsAutoDetect = Convert.ToBoolean(Preferences.Preferences.GetPreferenceSetting("IE_IsAutoDetect")),
        //        Kind = (ProxyKind)Enum.Parse(typeof(ProxyKind), Preferences.Preferences.GetPreferenceSetting("IE_ProxyKind")),
        //        NoProxy = Preferences.Preferences.GetPreferenceSetting("IE_NoProxy"),
        //        ProxyAutoConfigUrl = Preferences.Preferences.GetPreferenceSetting("IE_ProxyAutoConfigUrl"),
        //        SocksPassword = Preferences.Preferences.GetPreferenceSetting("IE_SocksPassword"),
        //        SocksProxy = Preferences.Preferences.GetPreferenceSetting("IE_SocksProxy"),
        //        SocksUserName = Preferences.Preferences.GetPreferenceSetting("IE_SocksUserName"),
        //        SslProxy = Preferences.Preferences.GetPreferenceSetting("IE_SslProxy")
        //    };
        //    IEProxy = proxy;
        //}

        #endregion
    }
}