﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Liberator.Driver.Enums;
using Liberator.Driver.Preferences;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Liberator.Driver.BrowserControl
{
    internal class ChromeDriverControl : IBrowserControl
    {
        #region Public Properties

        /// <summary>
        /// Holds the preset values for Chrome Options
        /// </summary>
        public ChromeOptions Options { get; set; }

        /// <summary>
        /// The Chrome driver service
        /// </summary>
        public ChromeDriverService Service { get; set; }

        /// <summary>
        /// The performance logging preferences for Chrome
        /// </summary>
        public ChromePerformanceLoggingPreferences LoggingPreferences { get; set; }

        /// <summary>
        /// Holds the instantiated Chrome Driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TouchActions Touch { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Sets all defaults
        /// </summary>
        public ChromeDriverControl()
        {
            Options = new ChromeOptions();
        }

        /// <summary>
        /// Allows the specification of Chrome Driver settings
        /// </summary>
        /// <param name="chromeSettings">The settings file to be used.</param>
        public ChromeDriverControl(ChromeSettings chromeSettings)
        {
            Options = new ChromeOptions();

            if (chromeSettings != null)
            {
                Chrome.AndroidDebugBridgePort = chromeSettings.AndroidDebugBridgePort;
                Chrome.BinaryLocation = chromeSettings.BinaryLocation;
                Chrome.BufferUsageReportingInterval = chromeSettings.BufferUsageReportingInterval;
                Chrome.CapabilityList = chromeSettings.CapabilityList;
                Chrome.DebuggerAddress = chromeSettings.DebuggerAddress;
                Chrome.EnableTouchEvents = chromeSettings.EnableTouchEvents;
                Chrome.EnableVerboseLogging = chromeSettings.EnableVerboseLogging;
                Chrome.ExtensionsList = chromeSettings.ExtensionsList;
                Chrome.Height = chromeSettings.Height;
                Chrome.HideCommandPromptWindow = chromeSettings.HideCommandPromptWindow;
                Chrome.IsCollectingNetworkEvents = chromeSettings.IsCollectingNetworkEvents;
                Chrome.IsCollectingPageEvents = chromeSettings.IsCollectingPageEvents;
                Chrome.LeaveBrowserRunning = chromeSettings.LeaveBrowserRunning;
                Chrome.LocalStatePreferences = chromeSettings.LocalStatePreferences;
                Chrome.LogPath = chromeSettings.LogPath;
                Chrome.MinidumpPath = chromeSettings.MinidumpPath;
                Chrome.PixelRatio = chromeSettings.PixelRatio;
                Chrome.Port = chromeSettings.Port;
                Chrome.PortServerAddress = chromeSettings.PortServerAddress;
                Chrome.SuppressInitialDiagnosticInformation = chromeSettings.SuppressInitialDiagnosticInformation;
                Chrome.TracingCategories = chromeSettings.TracingCategories;
                Chrome.UserAgent = chromeSettings.UserAgent;
                Chrome.UserProfilePreferences = chromeSettings.UserProfilePreferences;
                Chrome.WhitelistedIPAddresses = chromeSettings.WhitelistedIPAddresses;
                Chrome.Width = chromeSettings.Width;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the Chrome Driver with the preset values from app.config
        /// </summary>
        /// <returns>An instance of the Chrome Driver</returns>
        public IWebDriver StartDriver()
        {
            try
            {
                SetOptions();
                SetDriverService();
                AddAdditionalCapabilities();
                //SetChromePerformanceLoggingPreferences();
                //Options.SetLoggingPreference("performance", LogLevel.All);
                Driver = new ChromeDriver(Directory.GetParent(BaseSettings.ChromeDriverLocation).FullName, Options, BaseSettings.Timeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not start chrome driver.");
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

        /// <summary>
        /// Starts a Chrome Mobile Emuation driver
        /// </summary>
        /// <param name="phoneType">The type of device to emulate</param>
        /// <param name="touch">Whether to respond to toucn events</param>
        /// <returns>An instance of the Chrome Driver set to emulate a particular device</returns>
        public IWebDriver StartMobileDriver(EnumPhoneType phoneType, bool touch)
        {
            try
            {
                SetOptions();
                PhoneTypes.TryGetValue(phoneType, out string phoneName);
                Options.EnableMobileEmulation(phoneName);
                SetMobileDriverService();
                AddAdditionalCapabilities();
                Driver = new ChromeDriver(Service, Options, BaseSettings.Timeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not start the chrome driver's mobile emulation functionality.");
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

        /// <summary>
        /// Starts a specific mobile emulation using  hights and widths
        /// </summary>
        /// <param name="height">The height of the screen</param>
        /// <param name="width">The width of the screen</param>
        /// <param name="userAgent">The user agent returned by the device</param>
        /// <param name="pixelRatio">The pixel ratio of the screen</param>
        /// <param name="touch">Whether to emulate a touch screen</param>
        /// <returns>A web driver</returns>
        public IWebDriver StartMobileDriver(Int64 height, Int64 width, string userAgent, double pixelRatio, [Optional, DefaultParameterValue(false)]bool touch)
        {
            try
            {
                SetMobileDriverService();
                SetOptions();
                AddAdditionalCapabilities();
                AmendMobileEmulationForChrome(touch, height, width, userAgent, pixelRatio);
                Driver = new ChromeDriver(Service, Options, BaseSettings.Timeout);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Could not start the chrome driver's mobile emulation functionality.");
                        Console.Out.WriteLine("Please investigate the vales you have passed to the method.");
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

        /// <summary>
        /// Sets the mobile emulation settings for the Chrome Driver
        /// </summary>
        /// <param name="phoneType">The type of device to emulate</param>
        /// <param name="touchEvents">Whether to respond to toucn events</param>
        public void SetMobileEmulationOptions(EnumPhoneType phoneType, bool touchEvents)
        {
            SetOptions();
            Options.EnableMobileEmulation(SetChromeMobileEmulationDeviceSettings(phoneType, touchEvents));
            AddAdditionalCapabilities();
        }

        /// <summary>
        /// Adds an additional capability to the Chrome Driver
        /// </summary>
        /// <param name="name">the name of the capabilitty to add</param>
        /// <param name="value">The value to set for the capability</param>
        public void AddAdditionalCapability(string name, object value)
        {
            try
            {
                Options.AddAdditionalCapability(name, value);
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to add the capability {0} | Value: {1}", name, value);
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
        /// Adds an extension to the Chrome Driver
        /// </summary>
        /// <param name="options">The Chrome Options object</param>
        /// <param name="extensionPath">The path to the extension</param>
        /// <returns>The CHrome Options object</returns>
        public ChromeOptions AddExtension(ChromeOptions options, string extensionPath)
        {
            try
            {
                options.AddExtension(extensionPath);
                return options;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to add the extension {0}", extensionPath);
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

        ///// <summary>
        ///// Adds a tracing category to Chrome's logging preferences
        ///// </summary>
        ///// <param name="category">The category of logging to add</param>
        //public void AddTracingCategoryToLoggingPreferences(string category)
        //{
        //    try
        //    {
        //        LoggingAddTracingCategory(category);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Out.WriteLine(ex.Message);
        //    }
        //}

        #endregion

        #region Private Constructor Methods

        /// <summary>
        /// Sets the Chrome Options from the app.config file
        /// </summary>
        private void SetOptions()
        {
            try
            {
                bool.TryParse(Chrome.LeaveBrowserRunning, out bool leaveRunning);
                string debug = Chrome.DebuggerAddress;
                string minidump = Chrome.MinidumpPath;

                // SetChromePerformanceLoggingPreferences();

                ChromeOptions options = new ChromeOptions()
                {
                    BinaryLocation = BaseSettings.ChromeLocation
                };
                if (debug != null && debug.Contains(@"\")) { options.DebuggerAddress = Chrome.DebuggerAddress; }
                options.LeaveBrowserRunning = leaveRunning;
                if (minidump != null && minidump.Contains(@"\")) { options.MinidumpPath = minidump; }
                //options.PerformanceLoggingPreferences = LoggingPreferences

                AddAdditionalCapabilities();
                AddExtensions();
                AddLocalStatePreferences();
                AddUserProfilePreferences();
                Options = options;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to load driver options settings from the config file.");
                        Console.Out.WriteLine("Please reset Liberator.Driver.Dll.Config to its default settings.");
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
        /// Sets the Chrome Driver Service setting from the app.config file
        /// </summary>
        private void SetDriverService()
        {
            try
            {

                int.TryParse(Chrome.AndroidDebugBridgePort, out int android);
                bool.TryParse(Chrome.EnableVerboseLogging, out bool verbose);
                bool.TryParse(Chrome.HideCommandPromptWindow, out bool command);
                int.TryParse(Chrome.Port, out int port);
                bool.TryParse(Chrome.SuppressInitialDiagnosticInformation, out bool sidi);


                string logPath = Chrome.LogPath;
                string portServer = Chrome.PortServerAddress;
                string whitelist = Chrome.WhitelistedIPAddresses;

                ChromeDriverService service = ChromeDriverService.CreateDefaultService(Directory.GetParent(BaseSettings.ChromeDriverLocation).FullName);
                service.AndroidDebugBridgePort = android;
                service.EnableVerboseLogging = verbose;
                service.HideCommandPromptWindow = command;
                if (logPath != null && logPath.Contains(@"\")) { service.LogPath = logPath; }
                service.Port = port;
                if (portServer != null && portServer.Contains(@"\")) { service.PortServerAddress = portServer; }
                service.SuppressInitialDiagnosticInformation = sidi;
                if (whitelist != null && whitelist.Contains(".")) { service.WhitelistedIPAddresses = whitelist; }
                Service = service;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Driver was unable to load the settings for the mobile driver service.");
                        Console.Out.WriteLine("Please reset Liberator.Driver.Dll.Config to its default settings.");
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
        /// Sets the Chrome Mobile Driver Service setting from the app.config file
        /// </summary>
        private void SetMobileDriverService()
        {
            try
            {
                string portServer, whitelist;

                int.TryParse(Chrome.AndroidDebugBridgePort, out int android);
                bool.TryParse(Chrome.EnableVerboseLogging, out bool verbose);
                bool.TryParse(Chrome.HideCommandPromptWindow, out bool prompt);
                int.TryParse(Chrome.Port, out int port);
                bool.TryParse(Chrome.SuppressInitialDiagnosticInformation, out bool sidi);

                portServer = Chrome.PortServerAddress;
                whitelist = Chrome.WhitelistedIPAddresses;

                ChromeDriverService service = ChromeDriverService.CreateDefaultService(Directory.GetParent(BaseSettings.ChromeDriverLocation).FullName);
                service.AndroidDebugBridgePort = android;
                service.EnableVerboseLogging = verbose;
                service.HideCommandPromptWindow = prompt;
                service.LogPath = "";
                service.Port = port;
                service.PortServerAddress = portServer;
                service.SuppressInitialDiagnosticInformation = sidi;
                service.WhitelistedIPAddresses = whitelist;
                Service = service;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Driver was unable to load the settings for the mobile driver service.");
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
        /// Adds a series of additional capabilities to the Chrome Options object from the app.config file
        /// </summary>
        private void AddAdditionalCapabilities()
        {
            try
            {
                var capabilityList = Chrome.CapabilityList;

                if (capabilityList != null && capabilityList.Contains(","))
                {
                    var list = capabilityList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string item in list)
                    {
                        string[] setting = item.Split(new string[] { "=", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        string name = setting[0];
                        Type valueType = Type.GetType(setting[2]);
                        var objValue = Convert.ChangeType(setting[1], valueType);
                        Options.AddAdditionalCapability(name, objValue);
                    }
                }
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Driver was unable to load the capabilities from the config file.");
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
        ///// Loads the Performance Logging Preferences for Chrome from the app.config file
        ///// </summary>
        //private void SetChromePerformanceLoggingPreferences()
        //{
        //    ChromePerformanceLoggingPreferences prefs = new ChromePerformanceLoggingPreferences();
        //    var buri = KVList["ChromePerformance_BufferUsageReportingInterval"].Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //    prefs.BufferUsageReportingInterval = new TimeSpan(Convert.ToInt32(buri[0]), Convert.ToInt32(buri[1]), Convert.ToInt32(buri[2]), Convert.ToInt32(buri[3]), Convert.ToInt32(buri[4]));
        //    prefs.IsCollectingNetworkEvents = Convert.ToBoolean(KVList["ChromePerformance_IsCollectingNetworkEvents"].Value);
        //    prefs.IsCollectingPageEvents = Convert.ToBoolean(KVList["ChromePerformance_IsCollectingPageEvents"].Value);
        //    prefs.IsCollectingTimelineEvents = Convert.ToBoolean(KVList["ChromePerformance_IsCollectingTimelineEvents"].Value);
        //    LoggingPreferences = prefs;
        //}

        ///// <summary>
        ///// Adds a tracing category to the logging preferences for Chrome from the app.config file
        ///// </summary>
        //public void AddTracingCategoriesToLoggingPreferences()
        //{
        //    try
        //    {
        //        var categories = KVList["Chrome_TracingCategories"].Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //        LoggingAddTracingCategories(categories);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Out.WriteLine(ex.Message);
        //    }
        //}

        public void AmendMobileEmulationForChrome(bool touchEvent, Int64 height, Int64 width, string userAgent, double pixelRatio)
        {
            try
            {

                bool.TryParse(Chrome.EnableTouchEvents, out bool touch);
                long.TryParse(Chrome.Height, out long h);
                long.TryParse(Chrome.Width, out long w);
                double.TryParse(Chrome.PixelRatio, out double pixel);

                ChromeMobileEmulationDeviceSettings settings = new ChromeMobileEmulationDeviceSettings()
                {
                    EnableTouchEvents = touch,
                    Height = h,
                    PixelRatio = pixel,
                    UserAgent = userAgent,
                    Width = w
                };
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Driver was unable to load the mobile emulation settings.");
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
        /// Adds an extension to the Chrome Options object from the app.config
        /// </summary>
        private void AddExtensions()
        {
            try
            {
                var extensionList = Chrome.ExtensionsList;

                if (extensionList != null && extensionList.Contains(","))
                {
                    var list = extensionList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    Options.AddExtensions(list);
                }
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to add the extensions specified in the config file");
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
        /// Add the Local State Preferences from the app.config file
        /// </summary>
        private void AddLocalStatePreferences()
        {
            string name = "";
            object objValue = new object();
            try
            {
                var preferenceList = Chrome.LocalStatePreferences;


                if (preferenceList != null && preferenceList.Contains(","))
                {
                    var list = preferenceList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string preference in list)
                    {
                        string[] setting = preference.Split(new string[] { "=", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        name = setting[0];
                        Type valueType = Type.GetType(setting[2]);
                        objValue = Convert.ChangeType(setting[1], valueType);
                        Options.AddLocalStatePreference(name, objValue);
                    }
                }
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to add the local state settings specified in the config file");
                        Console.Out.WriteLine("Setting: {0} | Value: {1}", name, objValue.ToString());
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
        /// Adds the User Profile Preferences from the app.config file
        /// </summary>
        private void AddUserProfilePreferences()
        {
            object objValue = new object();
            string name = "";
            try
            {
                var preferenceList = Chrome.UserProfilePreferences;

                if (preferenceList != null && preferenceList.Contains(","))
                {
                    var list = preferenceList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string preference in list)
                    {
                        string[] setting = preference.Split(new string[] { "=", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        name = setting[0];
                        Type valueType = Type.GetType(setting[2]);
                        objValue = Convert.ChangeType(setting[1], valueType);
                        Options.AddUserProfilePreference(name, objValue);
                    }

                }
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to add the user profile settings specified in the config file");
                        Console.Out.WriteLine("Setting: {0} | Value: {1}", name, objValue.ToString());
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
        /// Sets the mobile emulation settings for Chrome from the app.config file
        /// </summary>
        /// <returns>The Chrome Mobile Emulation Device Settings</returns>
        private ChromeMobileEmulationDeviceSettings SetDefaultChromeMobileEmulationDeviceSettings()
        {
            try
            {
                string userAgent;

                bool.TryParse(Chrome.EnableTouchEvents, out bool touch);
                long.TryParse(Chrome.Height, out long height);
                double.TryParse(Chrome.PixelRatio, out double ratio);
                long.TryParse(Chrome.Width, out long width);

                ChromeMobileEmulationDeviceSettings settings = new ChromeMobileEmulationDeviceSettings();

                userAgent = Chrome.UserAgent;

                settings.EnableTouchEvents = touch;
                settings.Height = height;
                settings.PixelRatio = ratio;
                if (userAgent.Length > 1) { settings.UserAgent = userAgent; }
                settings.Width = width;


                return settings;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Driver was unable to load the mobile emulation settings.");
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
                };
                return null;
            }
        }

        /// <summary>
        /// Sets the mobile emulation settings for Chrome
        /// </summary>
        /// <param name="phoneType">The type of device to emulate</param>
        /// <param name="touchEvents">Whether to respond to touch events</param>
        /// <returns>The Chrome Mobile Emulation Device Settings</returns>
        private ChromeMobileEmulationDeviceSettings SetChromeMobileEmulationDeviceSettings(EnumPhoneType phoneType, bool touchEvents)
        {
            try
            {
                ChromeMobileEmulationDeviceSettings settings = new ChromeMobileEmulationDeviceSettings()
                {
                    EnableTouchEvents = touchEvents,
                    UserAgent = phoneType.ToString(),
                };
                return settings;
            }
            catch (Exception ex)
            {
                switch (BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.Out.WriteLine("Unable to set Chrome Mobile Emulation settings.");
                        Console.Out.WriteLine("Device Type: " + phoneType.ToString() + "| Touch Events: " + touchEvents.ToString());
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

        private Dictionary<EnumPhoneType, string> PhoneTypes = new Dictionary<EnumPhoneType, string>()
        {
            { EnumPhoneType.AmazonKindleFireHDX, "Kindle Fire HDX" },
            {EnumPhoneType.AppleiPad, "iPad" },
            {EnumPhoneType.AppleiPadMini, "iPad Mini" },
            {EnumPhoneType.AppleiPadPro, "iPad Pro" },
            {EnumPhoneType.AppleiPhone4, "iPhone 4" },
            {EnumPhoneType.AppleiPhone5, "iPhone 5" },
            {EnumPhoneType.AppleiPhone6, "iPhone 6" },
            {EnumPhoneType.AppleiPhone6Plus, "iPhone 6 Plus" },
            {EnumPhoneType.BlackBerryPlayBook, "Blackberry PlayBook" },
            {EnumPhoneType.BlackBeryZ30, "BlackBerry Z30" },
            {EnumPhoneType.GoogleNexus10, "Nexus 10" },
            {EnumPhoneType.GoogleNexus4, "Nexus 4" },
            {EnumPhoneType.GoogleNexus5, "Nexus 5" },
            {EnumPhoneType.GoogleNexus6, "Nexus 6" },
            {EnumPhoneType.GoogleNexus7, "Nexus 7" },
            {EnumPhoneType.LGOptimusL70, "LG Optimus L70" },
            {EnumPhoneType.MicrosoftLumia550, "Microsoft Lumia 550" },
            {EnumPhoneType.MicrosoftLumia950, "Microsoft Lumia 950" },
            {EnumPhoneType.Nexus5X, "Nexus 5X" },
            {EnumPhoneType.Nexus6P, "Nexus 6P" },
            {EnumPhoneType.NokiaLumia520, "Nokia Lumia 520" },
            {EnumPhoneType.NokiaN9, "Nokia N9" },
            {EnumPhoneType.SamsungGalaxyNote2, "Galaxy Note II" },
            {EnumPhoneType.SamsungGalaxyNote3, "Galaxy Note 3" },
            {EnumPhoneType.SamsungGalaxyS3, "Galaxy S III" },
            {EnumPhoneType.SamsungGalaxyS5, "Galaxy S5" }
        };
    }
}
