using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Liberator.Driver.BrowserControl
{
    internal class RemoteDriverControl : IBrowserControl
    {
        #region Public Properties

        /// <summary>
        /// Holds the instantiated Phantom JS Driver
        /// </summary>
        public IWebDriver Driver { get; set; }


        /// <summary>
        /// The maximum amount of time to wait between commands
        /// </summary>
        public TimeSpan CommandTimeout { get; set; }


        public DriverOptions Options { get; set; }
        
        #endregion

        #region Constructor & Public Methods

        /// <summary>
        /// The constructor
        /// </summary>
        public RemoteDriverControl()
        {
            string timeout = Preferences.BaseSettings.GetPreferenceSetting("Timeout");
            if (!timeout.Contains(",")) { timeout = "0,0,0,10,0"; }
            var to = timeout.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            CommandTimeout = new TimeSpan(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), Convert.ToInt32(to[2]), Convert.ToInt32(to[3]), Convert.ToInt32(to[4]));
        }


        /// <summary>
        /// Starts the Remote Web Driver
        /// </summary>
        /// <returns>The instantiated Remote WebDriver</returns>
        public IWebDriver StartDriver()
        {
            try
            {
                Uri remoteAddress = null;
                string address = Preferences.BaseSettings.GetPreferenceSetting("Remote_DefaultRemoteAddress");
                //SetPlatform(PlatformType.Windows);
                if (address.Length > 1) { remoteAddress = new Uri(address); }
                Driver = new RemoteWebDriver(remoteAddress, Options);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start chrome driver.");
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
                Driver = null;
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverType"></param>
        /// <returns></returns>
        public IWebDriver StartRemoteDriver(EnumRemoteDriver driverType)
        {
            try
            {
                Uri remoteAddress = null;
                string address = Preferences.BaseSettings.GetPreferenceSetting("Remote_DefaultRemoteAddress");
                if (address.Length > 1) { remoteAddress = new Uri(address); }
                Driver = new RemoteWebDriver(remoteAddress, Options);
                return Driver;
            }
            catch (Exception ex)
            {
                switch (Preferences.BaseSettings.DebugLevel)
                {
                    case EnumConsoleDebugLevel.Human:
                        Console.WriteLine("Could not start chrome driver.");
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
                Driver = null;
                return null;
            }
        }

        #endregion

        #region Private Methods
        


        ///// <summary>
        ///// Sets the platform on which to run the tests
        ///// </summary>
        ///// <param name="type">The platform type</param>
        //private void SetPlatform(PlatformType type)
        //{
        //    try
        //    {
        //        DesiredCapabilities.Platform = new Platform(type);

        //    }
        //    catch (Exception ex)
        //    {
        //        switch (Preferences.Preferences.DebugLevel)
        //        {
        //            case EnumConsoleDebugLevel.Human:
        //                Console.WriteLine("Could set the browser platform.");
        //                break;
        //            case EnumConsoleDebugLevel.NotSpecified:
        //            case EnumConsoleDebugLevel.Message:
        //                Console.WriteLine(ex.Message);
        //                break;
        //            case EnumConsoleDebugLevel.StackTrace:
        //                Console.WriteLine(ex.Message);
        //                Console.WriteLine(ex.StackTrace);
        //                break;
        //        }
        //    }
        //}

        #endregion
    }
}