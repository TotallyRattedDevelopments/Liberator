using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Liberator.Driver.BrowserControl
{
    internal class FirefoxDriverControl : IBrowserControl
    {
        #region Public Properties

        /// <summary>
        /// The path to the Firefox binary
        /// </summary>
        public string BinaryPath { get; set; }

        /// <summary>
        /// The maximum time to wait for the browser to load
        /// </summary>
        public TimeSpan BrowserLoadTimeout { get; set; }

        /// <summary>
        /// The maximum amount of time to wait between commands
        /// </summary>
        public TimeSpan CommandTimeout { get; set; }

        /// <summary>
        /// The Firefox binary
        /// </summary>
        public FirefoxBinary FirefoxBinary { get; set; }

        /// <summary>
        /// Holds a firefox profile
        /// </summary>
        public FirefoxProfile Profile { get; set; }

        ///// <summary>
        ///// Allows the sending of messages to a remote server
        ///// </summary>
        //public ICommandExecutor CommandExecutor { get; set; }

        /// <summary>
        /// Holds the preset values for Firefox Options
        /// </summary>
        public FirefoxOptions Options { get; set; }

        /// <summary>
        /// The Firefox driver service
        /// </summary>
        public FirefoxDriverService Service { get; set; }

        /// <summary>
        /// Holds the proxy settings for connection to the Firefox driver
        /// </summary>
        public Proxy ProxySettings { get; set; }

        /// <summary>
        /// IWebDriver
        /// </summary>
        public IWebDriver Driver { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Loads all settings into memory for the Firefox Driver from the app.config file
        /// </summary>
        public FirefoxDriverControl()
        {
            try
            {
                string timeout = Preferences.Preferences.GetPreferenceSetting("Timeout");
                if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
                var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the Firefox Driver with the preset values from app.config
        /// </summary>
        /// <returns>An instance of the Firefox Driver</returns>
        public IWebDriver StartDriver()
        {
            try
            {
                Process[] chromedrivers = Process.GetProcessesByName("geckodriver");
                foreach (Process driver in chromedrivers) { driver.Kill(); }
                SetOptions();
                SetDriverService();
                CreateBasicProfile();
                AddPreferencesToFirefoxProfile();
                SetProxyPreferences();
                Options.Profile = Profile;
                Driver = new FirefoxDriver();
                //Driver = new FirefoxDriver(Service, Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start the Firefox driver.");
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

        /// <summary>
        /// Starting the Firefox Driver with a specified profile from the profile manager.
        /// This requires that the profile has been loaded into the Profile Manager of the local machine.
        /// </summary>
        /// <param name="profileName">The name of the firefox profile to load</param>
        /// <returns>An initialised Firefox Driver</returns>
        public IWebDriver StartDriverSavedProfile(string profileName)
        {
            try
            {
                Process[] chromedrivers = Process.GetProcessesByName("geckodriver");
                foreach (Process driver in chromedrivers) { driver.Kill(); }
                SetOptions();
                SetDriverService();
                var profileManager = new FirefoxProfileManager();
                FirefoxProfile profile = profileManager.GetProfile("Automation");
                Profile = profile;
                Options.Profile = Profile;
                Driver = new FirefoxDriver(Service, Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start the Firefox driver with the configured profile.");
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

        /// <summary>
        /// Starting the Firefox Driver with a specified profile
        /// </summary>
        /// <param name="profileDirectory">The directory in which to find the firefox profile</param>
        /// <param name="cleanDirectory">Whether to delete the source on clean</param>
        /// <returns>An initialised Firefox Driver</returns>
        public IWebDriver StartDriverLoadProfileFromDisk(string profileDirectory, bool cleanDirectory)
        {
            try
            {
                string setDirectory = Preferences.Preferences.GetPreferenceSetting("Firefox_ProfileDirectory");
                profileDirectory = (profileDirectory == "") ? setDirectory : profileDirectory;

                if (profileDirectory.Contains(@"\"))
                {

                    Process[] chromedrivers = Process.GetProcessesByName("geckodriver");
                    foreach (Process driver in chromedrivers) { driver.Kill(); }

                    SetOptions();
                    SetDriverService();
                    FirefoxProfile profile = new FirefoxProfile(profileDirectory, cleanDirectory);
                    Profile = profile;
                    Options.Profile = Profile;
                    Driver = new FirefoxDriver(Service, Options, CommandTimeout);
                    return Driver;
                }
                else
                {
                    throw new Exception("No profile has been set in the config file or the method call");
                }
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start the Firefox driver with the configured profile.");
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

        ///// <summary>
        ///// Initialises a command server for use in sending commands to Firefox
        ///// </summary>
        ///// <param name="profile">The Firefox profile to attach to the command server</param>
        ///// <returns>An Executor for sending commands</returns>
        //public ICommandExecutor InitialiseCommandExecturor(FirefoxProfile profile)
        //{
        //    try
        //    {
        //        var host = Preferences.Preferences.GetPreferenceSetting["FirefoxHost");
        //        CommandExecutor = new FirefoxDriverCommandExecutor(FirefoxBinary, profile, host, CommandTimeout);
        //        return CommandExecutor;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Sends a command to Firefox via a CommandServer
        ///// </summary>
        ///// <param name="name">Name of the command to use</param>
        ///// <param name="jsonParameters">A JSON string of parameters for the command</param>
        ///// <returns>Returns the results of actions by the browser</returns>
        //public WebDriverResult SendCommandToFirefox(string name, string jsonParameters)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        Command command = new Command(name, jsonParameters);
        //        response = CommandExecutor.Execute(command);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return response.Status;
        //}

        /// <summary>
        /// Adds an extension to the current Firefox profile by name
        /// </summary>
        /// <param name="extensionName">The name of extension</param>
        public void AddExtension(string extensionName)
        {
            try
            {
                FirefoxExtension extension = new FirefoxExtension(extensionName);
                extension.Install(Profile.ProfileDirectory);
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not add the Firefox extension.");
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

        #region Private Constructor Methods
        /// <summary>
        /// Sets the basic settings, including timeouts, in the Firefox Driver
        /// </summary>
        private void SetBaseSettings()
        {
            try
            {
                string[] timeout = new string[5];
                BinaryPath = Preferences.Preferences.GetPreferenceSetting("Firefox_BinaryPath");
                var load = Preferences.Preferences.GetPreferenceSetting("Firefox_LoadTimeout");
                if (load.Contains(","))
                {
                    timeout = load.Split(new string[] { "," }, StringSplitOptions.None);
                }
                {
                    timeout = new string[5] { "0", "0", "0", "10", "0" };
                }
                BrowserLoadTimeout = new TimeSpan(0, 0, Convert.ToInt32(timeout[0]), Convert.ToInt32(timeout[1]), Convert.ToInt32(timeout[2]));
            }
            catch (Exception ex)
            {
                BinaryPath = null;
                BrowserLoadTimeout = new TimeSpan(0, 0, 0, 30, 0);

                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the Firefox path and timeout settings.");
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
        /// Sets the Firefox Options from the app.config file
        /// </summary>
        private void SetOptions()
        {
            try
            {
                FirefoxDriverLogLevel logLevel = FirefoxDriverLogLevel.Default;
                Enum.TryParse(Preferences.Preferences.GetPreferenceSetting("Edge_PageLoadStrategy"), out logLevel);
                bool cleanProfile = false;
                bool legacy = false;

                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_CleanProfile"), out cleanProfile);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_UseLegacyImplementation"), out legacy);

                string executable = Preferences.Preferences.GetPreferenceSetting("Firefox_ExecutableLocation");
                string profile = Preferences.Preferences.GetPreferenceSetting("Firefox_ProfileDirectory");
                string path = null;

                if (executable != "" || executable != null) { path = Preferences.Preferences.DriverPath; }
                else { path = executable; }

                FirefoxOptions options = new FirefoxOptions();
                if (executable.Contains(@"\")) { options.BrowserExecutableLocation = executable; }
                options.LogLevel = logLevel;
                if (profile.Contains(@"\")) { options.Profile = new FirefoxProfile(profile, cleanProfile); }
                options.UseLegacyImplementation = legacy;

                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the Firefox option settings.");
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
                Options = null;
            }
        }

        /// <summary>
        /// Loads the basic firefox profile settings from the app.config file
        /// </summary>
        private void CreateBasicProfile()
        {
            try
            {
                bool trust = true;
                bool noFocus = false;
                bool assume = false;
                bool delete = false;
                bool native = true;
                Int32 port = 4444;

                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_AcceptUntrustedCertificates"), out trust);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_AlwaysLoadNoFocusLibrary"), out noFocus);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_AssumeUntrustedCertificateIssuer"), out assume);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_DeleteAfterUse"), out delete);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_EnableNativeEvents"), out native);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_Port"), out port);


                FirefoxProfile profile = new FirefoxProfile()
                {
                    AcceptUntrustedCertificates = trust,
                    AlwaysLoadNoFocusLibrary = noFocus,
                    AssumeUntrustedCertificateIssuer = assume,
                    DeleteAfterUse = delete,
                    EnableNativeEvents = native,
                    Port = port
                };
                Profile = profile;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not create the Firefox profile specified in the config file.");
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
                Profile = null;
            }

        }

        /// <summary>
        /// Sets the proxy preferences for Firefox from the app.config file
        /// </summary>
        private void SetProxyPreferences()
        {
            try
            {
                Dictionary<string, object> proxySettings = new Dictionary<string, object>();

                string firfoxPrefs = Preferences.Preferences.GetPreferenceSetting("Firefox_ProxyPreferences");

                if (firfoxPrefs.Contains(","))
                {
                    string[] proxyPrefs = firfoxPrefs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var pref in proxyPrefs)
                    {
                        string[] setting = pref.Split(new string[] { "=", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        proxySettings.Add(setting[0], setting[1]);
                    }
                    Proxy proxy = new Proxy(proxySettings);
                    ProxySettings = proxy;
                }
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the Firefox proxy settings.");
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
                ProxySettings = null;
            }
        }

        /// <summary>
        /// Sets the Firefox Driver Service setting from the app.config file
        /// </summary>
        private void SetDriverService()
        {
            try
            {
                Int32 browserComm = 4444;
                bool connect = false;
                bool hideCommand = true;
                Int32 port = 4444;
                bool sidi = false;

                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_CommunicationPort"), out browserComm);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_ConnectToRunningBrowser"), out connect);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_HideCommandPromptWindow"), out hideCommand);
                Int32.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_Port"), out port);
                Boolean.TryParse(Preferences.Preferences.GetPreferenceSetting("Firefox_SuppressInitialDiagnosticInformation"), out sidi);


                string driverLocation = Preferences.Preferences.GetPreferenceSetting("Firefox_DriverPath");
                string path = null;

                if (driverLocation != "" || driverLocation != null) { path = Preferences.Preferences.DriverPath; }
                else { path = driverLocation; }

                string binaryPath = Preferences.Preferences.GetPreferenceSetting("Firefox_BinaryPath");
                string host = Preferences.Preferences.GetPreferenceSetting("Firefox_Host");

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);
                service.BrowserCommunicationPort = browserComm;
                service.ConnectToRunningBrowser = connect;
                if (binaryPath.Contains(@"|")) { service.FirefoxBinaryPath = binaryPath; }
                service.HideCommandPromptWindow = hideCommand;
                if (host.Contains(@"\")) { service.Host = host; }
                service.Port = port;
                service.SuppressInitialDiagnosticInformation = sidi;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not set the Firefox driver service settings.");
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
                Service = null;
            }
        }

        /// <summary>
        /// Adds the list of preferences to the Firefox profile from the app.config file
        /// </summary>
        private void AddPreferencesToFirefoxProfile()
        {
            try
            {
                var firefoxPrefs = Preferences.Preferences.GetPreferenceSetting("Firefox_Preferences");

                if (firefoxPrefs.Contains(","))
                {
                    var list = firefoxPrefs.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string pref in list)
                    {
                        string[] setting = pref.Split(new[] { "=", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        Profile.SetPreference(setting[0], Convert.ToBoolean(setting[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                switch (Preferences.Preferences.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not add the listed preferences to Firefox.");
                        Console.WriteLine("Please reset the config file to its default settings.");
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
