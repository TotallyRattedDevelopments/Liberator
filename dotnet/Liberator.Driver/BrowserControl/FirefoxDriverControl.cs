using Liberator.Driver.Enums;
using Liberator.Driver.Preferences;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
        /// Default constructor
        /// </summary>
        public FirefoxDriverControl()
        {
        }

        /// <summary>
        /// Allows the specification of Firefox Driver settings
        /// </summary>
        /// <param name="firefoxSettings">The settings file to be used.</param>
        public FirefoxDriverControl(FirefoxSettings firefoxSettings)
        {
            if (firefoxSettings != null)
            {
                Firefox.AcceptUntrustedCertificates = firefoxSettings.AcceptUntrustedCertificates;
                Firefox.AlwaysLoadNoFocusLibrary = firefoxSettings.AlwaysLoadNoFocusLibrary;
                Firefox.AssumeUntrustedCertificateIssuer = firefoxSettings.AssumeUntrustedCertificateIssuer;
                Firefox.CleanProfile = firefoxSettings.CleanProfile;
                Firefox.CommunicationPort = firefoxSettings.ConnectToRunningBrowser;
                Firefox.ConnectToRunningBrowser = firefoxSettings.ConnectToRunningBrowser;
                Firefox.DeleteAfterUse = firefoxSettings.DeleteAfterUse;
                Firefox.EnableNativeEvents = firefoxSettings.EnableNativeEvents;
                Firefox.HideCommandPromptWindow = firefoxSettings.HideCommandPromptWindow;
                Firefox.Host = firefoxSettings.Host;
                Firefox.LogLevel = firefoxSettings.LogLevel;
                Firefox.Port = firefoxSettings.Port;
                Firefox.Preferences = firefoxSettings.Preferences;
                Firefox.ProfileDirectory = firefoxSettings.ProfileDirectory;
                Firefox.ProxyPreferences = firefoxSettings.ProxyPreferences;
                Firefox.SuppressInitialDiagnosticInformation = firefoxSettings.SuppressInitialDiagnosticInformation;
                Firefox.UseLegacyImplementation = firefoxSettings.UseLegacyImplementation;
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
                Driver = new FirefoxDriver(Service);
                //Driver = new FirefoxDriver(Service, Options, CommandTimeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
                FirefoxProfile profile = profileManager.GetProfile(profileName);
                Profile = profile;
                Options.Profile = Profile;
                Driver = new FirefoxDriver(Service);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
                string setDirectory = Preferences.Firefox.ProfileDirectory;
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
                switch (Preferences.BaseSettings.DebugLevel)
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
                switch (Preferences.BaseSettings.DebugLevel)
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
                BinaryPath = Preferences.BaseSettings.FirefoxLocation;
                BrowserLoadTimeout = Preferences.BaseSettings.Timeout;
            }
            catch (Exception ex)
            {
                BinaryPath = null;
                BrowserLoadTimeout = new TimeSpan(0, 0, 0, 30, 0);

                switch (Preferences.BaseSettings.DebugLevel)
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
                Enum.TryParse(Preferences.Firefox.LogLevel, out logLevel);

                bool.TryParse(Preferences.Firefox.CleanProfile, out bool cleanProfile);
                bool.TryParse(Preferences.Firefox.UseLegacyImplementation, out bool legacy);

                string executable = Preferences.BaseSettings.FirefoxLocation;
                string profile = Preferences.Firefox.ProfileDirectory;

                FirefoxOptions options = new FirefoxOptions
                {
                    BrowserExecutableLocation = executable,
                    LogLevel = logLevel
                };
                if (profile.Contains(@"\")) { options.Profile = new FirefoxProfile(profile, cleanProfile); }
                options.UseLegacyImplementation = legacy;

                Options = options;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
                bool.TryParse(Preferences.Firefox.AcceptUntrustedCertificates, out bool trust);
                bool.TryParse(Preferences.Firefox.AlwaysLoadNoFocusLibrary, out bool noFocus);
                bool.TryParse(Preferences.Firefox.AssumeUntrustedCertificateIssuer, out bool assume);
                bool.TryParse(Preferences.Firefox.DeleteAfterUse, out bool delete);
                bool.TryParse(Preferences.Firefox.EnableNativeEvents, out bool native);
                int.TryParse(Preferences.Firefox.Port, out int port);
                
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
                switch (Preferences.BaseSettings.DebugLevel)
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

                string firfoxPrefs = Preferences.Firefox.ProxyPreferences;

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
                switch (Preferences.BaseSettings.DebugLevel)
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

                int.TryParse(Preferences.Firefox.CommunicationPort, out int browserComm);
                bool.TryParse(Preferences.Firefox.ConnectToRunningBrowser, out bool connect);
                bool.TryParse(Preferences.Firefox.HideCommandPromptWindow, out bool hideCommand);
                int.TryParse(Preferences.Firefox.Host, out int port);
                bool.TryParse(Preferences.Firefox.SuppressInitialDiagnosticInformation, out bool sidi);
                
                string driverLocation = Directory.GetParent(Preferences.BaseSettings.FirefoxDriverLocation).FullName;

                string binaryPath = Preferences.BaseSettings.FirefoxLocation;
                string host = Preferences.Firefox.Host;

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverLocation);
                service.BrowserCommunicationPort = browserComm;
                service.ConnectToRunningBrowser = connect;
                service.FirefoxBinaryPath = binaryPath;
                service.HideCommandPromptWindow = hideCommand;
                //service.Host = host;
                //service.Port = port;
                service.SuppressInitialDiagnosticInformation = sidi;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
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
                var firefoxPrefs = Preferences.Firefox.Preferences;

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
                switch (Preferences.BaseSettings.DebugLevel)
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
