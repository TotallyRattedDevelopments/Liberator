using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Diagnostics;

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

            string timeout = Preferences.Preferences.GetPreferenceSetting("Timeout");
            if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
            var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));


            var sleepInterval = Preferences.Preferences.GetPreferenceSetting("Sleep");
            if (!sleepInterval.Contains(@"\")) { sleepInterval = "0,0,0,10,0"; }
            var si = sleepInterval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            SleepInterval = new TimeSpan(Convert.ToInt32(si[0]), Convert.ToInt32(si[1]), Convert.ToInt32(si[2]), Convert.ToInt32(si[3]), Convert.ToInt32(si[4]));

            var browserTime = Preferences.Preferences.GetPreferenceSetting("Timeout");
            if (!sleepInterval.Contains(@"\")) { sleepInterval = "0,0,0,10,0"; }
            var bto = browserTime.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            BrowserTimeout = new TimeSpan(Convert.ToInt32(bto[0]), Convert.ToInt32(bto[1]), Convert.ToInt32(bto[2]), Convert.ToInt32(bto[3]), Convert.ToInt32(bto[4]));

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
                Driver = new InternetExplorerDriver(Service, Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
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
                bool screenshot = true;
                bool native = true;
                bool hover = true;
                bool cleanSession = true;
                bool forceCreate = false;
                bool forceShell = false;
                bool ignoreZoom = false;
                bool instability = true;
                bool requireFocus = false;
                bool perProcess = false;

                InternetExplorerElementScrollBehavior scroll = InternetExplorerElementScrollBehavior.Bottom;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_ScrollBehavior"), out scroll);
                InternetExplorerPageLoadStrategy strategy = InternetExplorerPageLoadStrategy.Default;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_PageLoadStrategy"), out strategy);
                InternetExplorerUnexpectedAlertBehavior alert = InternetExplorerUnexpectedAlertBehavior.Dismiss;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_UnexpectedAlertBehavior"), out alert);

                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_EnableFullPageScreenshot"), out screenshot);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_EnableNativeEvents"), out native);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_EnablePersistentHover"), out hover);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_EnsureCleanSession"), out cleanSession);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_ForceCreateProcessApi"), out forceCreate);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_ForceShellWindowsApi"), out forceShell);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_IgnoreZoomLevel"), out ignoreZoom);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_IntroduceInstability"), out instability);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_RequireWindowFocus"), out requireFocus);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_UsePerProcessProxy"), out perProcess);

                string cmdLine = Preferences.Preferences.GetPreferenceSetting("IE_CommandLineArguments");
                string url = Preferences.Preferences.GetPreferenceSetting("IE_InitialBrowserUrl");

                InternetExplorerOptions options = new InternetExplorerOptions();
                options.BrowserAttachTimeout = BrowserTimeout;
                if (cmdLine.Length > 1) { options.BrowserCommandLineArguments = cmdLine; }
                options.ElementScrollBehavior = scroll;
                options.EnableFullPageScreenshot = screenshot;
                options.EnableNativeEvents = native;
                options.EnablePersistentHover = hover;
                options.EnsureCleanSession = cleanSession;
                options.FileUploadDialogTimeout = BrowserTimeout;
                options.ForceCreateProcessApi = forceCreate;
                options.ForceShellWindowsApi = forceShell;
                options.IgnoreZoomLevel = ignoreZoom;
                if (url.Contains(@"/")) { options.InitialBrowserUrl = url; }
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = instability;
                options.PageLoadStrategy = strategy;
                //options.Proxy = IEProxy;
                options.RequireWindowFocus = requireFocus;
                options.UnexpectedAlertBehavior = alert;
                options.UsePerProcessProxy = perProcess;

                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
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
                bool hidePrompt = true;
                Int32 port = 4444;
                bool sidi = false;

                InternetExplorerDriverLogLevel logLevel = InternetExplorerDriverLogLevel.Debug;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_LoggingLevel"), out logLevel);

                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_HideCommandPromptWindow"), out hidePrompt);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_Port"), out port);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("IE_SuppressInitialDiagnosticInformation"), out sidi);

                string ieHost = Preferences.Preferences.GetPreferenceSetting("IE_Host");
                string extract = Preferences.Preferences.GetPreferenceSetting("IE_LibraryExtractionPath");
                string log = Preferences.Preferences.GetPreferenceSetting("IE_LogFile");
                string whitelist = Preferences.Preferences.GetPreferenceSetting("IE_WhitelistedIPAddresses");

                InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(Preferences.Preferences.DriverPath);
                service.HideCommandPromptWindow = hidePrompt;
                if (ieHost.Length > 1) { service.Host = ieHost; }
                if (extract.Length > 1) { service.LibraryExtractionPath = extract; }
                if (log.Length > 1) { service.LogFile = log; }
                service.LoggingLevel = logLevel;
                service.Port = port;
                service.SuppressInitialDiagnosticInformation = sidi;
                if (whitelist.Length > 1) { service.WhitelistedIPAddresses = whitelist; }
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
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