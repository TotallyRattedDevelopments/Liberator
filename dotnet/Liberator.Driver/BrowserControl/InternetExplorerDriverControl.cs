﻿using Liberator.Driver.Enums;
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

            string timeout = Preferences.BaseSettings.GetPreferenceSetting("Timeout");
            if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
            var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));


            var sleepInterval = Preferences.BaseSettings.GetPreferenceSetting("Sleep");
            if (!sleepInterval.Contains(@"\")) { sleepInterval = "0,0,0,10,0"; }
            var si = sleepInterval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            SleepInterval = new TimeSpan(Convert.ToInt32(si[0]), Convert.ToInt32(si[1]), Convert.ToInt32(si[2]), Convert.ToInt32(si[3]), Convert.ToInt32(si[4]));

            var browserTime = Preferences.BaseSettings.GetPreferenceSetting("Timeout");
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
                Enum.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_ScrollBehavior"), out scroll);

                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_EnableFullPageScreenshot"), out bool screenshot);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_EnableNativeEvents"), out bool native);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_EnablePersistentHover"), out bool hover);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_EnsureCleanSession"), out bool cleanSession);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_ForceCreateProcessApi"), out bool forceCreate);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_ForceShellWindowsApi"), out bool forceShell);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_IgnoreZoomLevel"), out bool ignoreZoom);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_IntroduceInstability"), out bool instability);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_RequireWindowFocus"), out bool requireFocus);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_UsePerProcessProxy"), out bool perProcess);

                string cmdLine = Preferences.BaseSettings.GetPreferenceSetting("IE_CommandLineArguments");
                string url = Preferences.BaseSettings.GetPreferenceSetting("IE_InitialBrowserUrl");

                InternetExplorerOptions options = new InternetExplorerOptions
                {
                    BrowserAttachTimeout = BrowserTimeout
                };

                if (cmdLine.Length > 1) { options.BrowserCommandLineArguments = cmdLine; }

                options.ElementScrollBehavior = scroll;
//              options.EnableFullPageScreenshot = screenshot;
                options.EnableNativeEvents = native;
                options.EnablePersistentHover = hover;
                options.EnsureCleanSession = cleanSession;
                options.FileUploadDialogTimeout = BrowserTimeout;
                options.ForceCreateProcessApi = forceCreate;
                options.ForceShellWindowsApi = forceShell;
                options.IgnoreZoomLevel = ignoreZoom;
                if (url.Contains(@"/")) { options.InitialBrowserUrl = url; }
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
                Enum.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_LoggingLevel"), out logLevel);

                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_HideCommandPromptWindow"), out bool hidePrompt);
                Int32.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_Port"), out int port);
                Boolean.TryParse(Preferences.BaseSettings.GetPreferenceSetting("IE_SuppressInitialDiagnosticInformation"), out bool sidi);

                string ieHost = Preferences.BaseSettings.GetPreferenceSetting("IE_Host");
                string extract = Preferences.BaseSettings.GetPreferenceSetting("IE_LibraryExtractionPath");
                string log = Preferences.BaseSettings.GetPreferenceSetting("IE_LogFile");
                string whitelist = Preferences.BaseSettings.GetPreferenceSetting("IE_WhitelistedIPAddresses");

                InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(Directory.GetParent(Preferences.BaseSettings.InternetExplorerDriverLocation).FullName);
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