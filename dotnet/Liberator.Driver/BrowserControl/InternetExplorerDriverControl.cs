using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Diagnostics;
using System.IO;
using Liberator.Driver.Preferences;

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

        /// <summary>
        /// Allows the specification of Internet Explorer Driver settings
        /// </summary>
        /// <param name="internetExplorerSettings">The settings file to be used.</param>
        public InternetExplorerDriverControl(InternetExplorerSettings internetExplorerSettings)
        {
            //SetInternetExplorerProxy();
            SetInternetExplorerOptions();
            SetInternetExplorerDriverService();

            if (internetExplorerSettings != null)
            {
                InternetExplorer.CommandLineArguments = internetExplorerSettings.CommandLineArguments;
                InternetExplorer.EnableFullPageScreenshot = internetExplorerSettings.EnableFullPageScreenshot;
                InternetExplorer.EnableNativeEvents = internetExplorerSettings.EnableNativeEvents;
                InternetExplorer.EnablePersistentHover = internetExplorerSettings.EnablePersistentHover;
                InternetExplorer.EnsureCleanSession = internetExplorerSettings.EnsureCleanSession;
                InternetExplorer.FileUploadTimeout = internetExplorerSettings.FileUploadTimeout;
                InternetExplorer.ForceCreateProcessApi = internetExplorerSettings.ForceCreateProcessApi;
                InternetExplorer.ForceShellWindowsApi = internetExplorerSettings.ForceShellWindowsApi;
                InternetExplorer.FtpProxy = internetExplorerSettings.FtpProxy;
                InternetExplorer.HideCommandPromptWindow = internetExplorerSettings.HideCommandPromptWindow;
                InternetExplorer.Host = internetExplorerSettings.Host;
                InternetExplorer.HttpProxy = internetExplorerSettings.HttpProxy;
                InternetExplorer.IgnoreZoomLevel = internetExplorerSettings.IgnoreZoomLevel;
                InternetExplorer.InitialBrowserUrl = internetExplorerSettings.InitialBrowserUrl;
                InternetExplorer.IntroduceInstability = internetExplorerSettings.IntroduceInstability;
                InternetExplorer.IsAutoDetect = internetExplorerSettings.IsAutoDetect;
                InternetExplorer.LibraryExtractionPath = internetExplorerSettings.LibraryExtractionPath;
                InternetExplorer.LogFile = internetExplorerSettings.LogFile;
                InternetExplorer.LoggingLevel = internetExplorerSettings.LoggingLevel;
                InternetExplorer.NoProxy = internetExplorerSettings.NoProxy;
                InternetExplorer.PageLoadStrategy = internetExplorerSettings.PageLoadStrategy;
                InternetExplorer.Port = internetExplorerSettings.Port;
                InternetExplorer.ProxyAutoConfigUrl = internetExplorerSettings.ProxyAutoConfigUrl;
                InternetExplorer.ProxyKind = internetExplorerSettings.ProxyKind;
                InternetExplorer.RequireWindowFocus = internetExplorerSettings.RequireWindowFocus;
                InternetExplorer.ScrollBehavior = internetExplorerSettings.ScrollBehavior;
                InternetExplorer.SocksPassword = internetExplorerSettings.SocksPassword;
                InternetExplorer.SocksProxy = internetExplorerSettings.SocksProxy;
                InternetExplorer.SocksUserName = internetExplorerSettings.SocksUserName;
                InternetExplorer.SslProxy = internetExplorerSettings.SslProxy;
                InternetExplorer.SuppressInitialDiagnosticInformation = internetExplorerSettings.SuppressInitialDiagnosticInformation;
                InternetExplorer.UnexpectedAlertBehavior = internetExplorerSettings.UnexpectedAlertBehavior;
                InternetExplorer.UsePerProcessProxy = internetExplorerSettings.UsePerProcessProxy;
                InternetExplorer.WhitelistedIPAddresses = internetExplorerSettings.WhitelistedIPAddresses;
            }
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
                //SetInternetExplorerProxy();
                SetInternetExplorerOptions();
                SetInternetExplorerDriverService();
                Driver = new InternetExplorerDriver(Service, Options, Preferences.BaseSettings.Timeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not start internet explorer driver.");
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

                bool.TryParse(InternetExplorer.EnableFullPageScreenshot, out bool screenshot);
                bool.TryParse(InternetExplorer.EnableNativeEvents, out bool native);
                bool.TryParse(InternetExplorer.EnablePersistentHover, out bool hover);
                bool.TryParse(InternetExplorer.EnsureCleanSession, out bool cleanSession);
                bool.TryParse(InternetExplorer.ForceCreateProcessApi, out bool forceCreate);
                bool.TryParse(InternetExplorer.ForceShellWindowsApi, out bool forceShell);
                bool.TryParse(InternetExplorer.IgnoreZoomLevel, out bool ignoreZoom);
                bool.TryParse(InternetExplorer.IntroduceInstability, out bool instability);
                bool.TryParse(InternetExplorer.RequireWindowFocus, out bool requireFocus);
                bool.TryParse(InternetExplorer.UsePerProcessProxy, out bool perProcess);

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
                        Console.Out.WriteLine("Could not set the internet explorer driver options settings.");
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
                        Console.Out.WriteLine("Could not set the internet explorer driver service settings.");
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