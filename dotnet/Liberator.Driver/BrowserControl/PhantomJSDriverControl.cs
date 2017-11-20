using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Diagnostics;
using System.Linq;

namespace Liberator.Driver.BrowserControl
{
    internal class PhantomJSDriverControl : IBrowserControl
    {
        #region Public Properties

        /// <summary>
        /// Holds the preset values for Phantom JS driver options
        /// </summary>
        public PhantomJSOptions Options { get; set; }

        /// <summary>
        /// The Phantom JS driver service
        /// </summary>
        public PhantomJSDriverService Service { get; set; }

        /// <summary>
        /// Holds the instantiated Phantom JS Driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// The maximum amount of time to wait between commands
        /// </summary>
        public TimeSpan CommandTimeout { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Loads the settings from the app.config file
        /// </summary>
        public PhantomJSDriverControl()
        {
            SetPhantomJSOptions();
            SetPhantomJSDriverService();
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  Starts the Phantom JS Driver with the preset values from app.config
        /// </summary>
        /// <returns>An instance of the Phantom JS driver</returns>
        public IWebDriver StartDriver()
        {
            try
            {

                string timeout = Preferences.Preferences.GetPreferenceSetting("Timeout");
                if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
                var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));

                Process[] phantomjsdrivers = Process.GetProcessesByName("phantomjs");
                foreach (Process driver in phantomjsdrivers) { driver.Kill(); }

                SetPhantomJSOptions();
                SetPhantomJSDriverService();
                Driver = new PhantomJSDriver(Service, Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start the phantomjs driver.");
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

        #region Private Method

        /// <summary>
        /// Sets the Phantom JS Options from the app.config file
        /// </summary>
        private void SetPhantomJSOptions()
        {
            try
            {
                LogLevel logLevel = LogLevel.All;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_LogLevel"), out logLevel);

                string logType = Preferences.Preferences.GetPreferenceSetting("PhantomJs_LogType");

                PhantomJSOptions options = new PhantomJSOptions();
                if (logType.Length > 1) { options.SetLoggingPreference(logType, logLevel); }

                var capabilityList = Preferences.Preferences.GetPreferenceSetting("PhantomJs_CapabilityList");
                if (capabilityList.Contains(","))
                {
                    var list = capabilityList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string item in list)
                    {
                        string[] setting = item.Split(new string[] { "=", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        string name = setting[0];
                        Type valueType = Type.GetType(setting[2]);
                        var objValue = Convert.ChangeType(setting[1], valueType);
                        options.AddAdditionalCapability(name, objValue);
                    } 
                }
                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the phantomjs driver otions.");
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
        /// Sets the Phantom JS Driver Service setting from the app.config file
        /// </summary>
        private void SetPhantomJSDriverService()
        {
            try
            {
                bool diskCache = true;
                bool hidePrompt = true;
                bool ignoreSsl = false;
                bool loadImages = true;
                Int32 localQuota = 0;
                bool localToRemote = true;
                Int32 maxCache = 0;
                Int32 port = 6666;
                bool sidi = false;
                bool webSecurity = false;

                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_DiskCache"), out diskCache);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_HideCommandPromptWindow"), out hidePrompt);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_IgnoreSslErrors"), out ignoreSsl);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_LoadImages"), out loadImages);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_LocalStorageQuota"), out localQuota);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_LocalToRemoteUrlAccess"), out localToRemote);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_MaxDiskCacheSize"), out maxCache);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_Port"), out port);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_SuppressInitialDiagnosticInformation"), out sidi);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("PhantomJs_WebSecurity"), out webSecurity);



                string phantomLocation = Preferences.Preferences.GetPreferenceSetting("PhantomJs_GhostDriverPath");
                string path = null;

                if (phantomLocation != "" || phantomLocation != null)
                { path = Preferences.Preferences.DriverPath; }
                else { path = AppDomain.CurrentDomain.BaseDirectory + phantomLocation; }

                string configFile = Preferences.Preferences.GetPreferenceSetting("PhantomJs_ConfigFile");
                string cookiesFile = Preferences.Preferences.GetPreferenceSetting("PhantomJs_CookiesFile");
                string gridHub = Preferences.Preferences.GetPreferenceSetting("PhantomJs_GridHubUrl");
                string ipAddress = Preferences.Preferences.GetPreferenceSetting("PhantomJs_IPAddress");
                string local = Preferences.Preferences.GetPreferenceSetting("PhantomJs_LocalStoragePath");
                string logFile = Preferences.Preferences.GetPreferenceSetting("PhantomJS_LogFile");
                string encode = Preferences.Preferences.GetPreferenceSetting("PhantomJs_OutputEncoding");
                string proxy = Preferences.Preferences.GetPreferenceSetting("PhantomJs_Proxy");
                string auth = Preferences.Preferences.GetPreferenceSetting("PhantomJs_ProxyAuthentication");
                string type = Preferences.Preferences.GetPreferenceSetting("PhantomJs_ProxyType");
                string script = Preferences.Preferences.GetPreferenceSetting("PhantomJs_ScriptEncoding");
                string sslCert = Preferences.Preferences.GetPreferenceSetting("PhantomJs_SslCertificatesPath");
                string sslProtocol = Preferences.Preferences.GetPreferenceSetting("PhantomJs_SslProtocol");

                PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService(path, "phantomjs.exe");
                if (configFile.Length > 1) { service.ConfigFile = configFile; }
                if (cookiesFile.Length > 1) { service.CookiesFile = cookiesFile; }
                service.DiskCache = diskCache;
                if (gridHub.Length > 1) { service.GridHubUrl = gridHub; }
                service.HideCommandPromptWindow = hidePrompt;
                service.IgnoreSslErrors = ignoreSsl;
                if (ipAddress.Contains(".")) { service.IPAddress = ipAddress; }
                service.LoadImages = loadImages;
                if (local.Length > 1) service.LocalStoragePath = local;
                service.LocalStorageQuota = localQuota;
                service.LocalToRemoteUrlAccess = localToRemote;
                if (logFile.Length > 1) { service.LogFile = logFile; }
                service.MaxDiskCacheSize = maxCache;
                if (encode.Length > 1) { service.OutputEncoding = encode; }
                service.Port = port;
                if (proxy.Length > 1) { service.Proxy = proxy; }
                if (auth.Length > 1) { service.ProxyAuthentication = auth; }
                if (type.Length > 1) { service.ProxyType = type; }
                if (script.Length > 1) { service.ScriptEncoding = script; }
                if (sslCert.Length > 1) { service.SslCertificatesPath = sslCert; }
                if (sslProtocol.Length > 1) { service.SslProtocol = sslProtocol; }
                service.SuppressInitialDiagnosticInformation = sidi;
                service.WebSecurity = webSecurity;

                var argumentList = Preferences.Preferences.GetPreferenceSetting("PhantomJs_ArgumentList");
                var list = argumentList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in list)
                {
                    service.AddArgument(item);
                }

                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start the phantomjs driver service.");
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
