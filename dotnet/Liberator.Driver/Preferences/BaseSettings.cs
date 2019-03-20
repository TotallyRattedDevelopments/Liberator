using Liberator.Driver.Enums;
using System;
using System.IO;
using System.Reflection;

namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Base settings for RAT Driver
    /// </summary>
    public static class BaseSettings
    {
        /// <summary>
        /// Standard timeout
        /// </summary>
        public static TimeSpan Timeout { get; set; }

        /// <summary>
        /// The length of time to sleep
        /// </summary>
        public static TimeSpan Sleep { get; set; }

        /// <summary>
        /// Implicit wait value for WebDriver
        /// </summary>
        public static TimeSpan ImplicitWait { get; set; }

        /// <summary>
        /// The amount of time to keep a hover active
        /// </summary>
        public static TimeSpan MenuHoverTime { get; set; }

        /// <summary>
        /// Page Load wait time
        /// </summary>
        public static TimeSpan PageLoad { get; set; }

        /// <summary>
        /// Asynchronous JavaScript wait time
        /// </summary>
        public static TimeSpan AsyncJavaScript { get; set; }

        /// <summary>
        /// Whether to allow RatDriver to handle alerts
        /// </summary>
        public static bool AlertHandling { get; set; }

        /// <summary>
        /// Whether to use internal timers
        /// </summary>
        public static bool InternalTimers { get; set; }

        /// <summary>
        /// Location of Chrome Driver. Defaults to the supplied version.
        /// </summary>
        public static string ChromeDriverLocation { get; set; }

        /// <summary>
        /// Location of the Microsoft Web Driver. Defaults to the supplied version.
        /// </summary>
        public static string EdgeDriverLocation { get; set; }

        /// <summary>
        /// Location of the Firefox Driver. Defaults to the supplied version.
        /// </summary>
        public static string FirefoxDriverLocation { get; set; }

        /// <summary>
        /// Location of the IEDriverServer executable. Defaults to the supplied version.
        /// </summary>
        public static string InternetExplorerDriverLocation { get; set; }

        /// <summary>
        /// Location of the Opera Driver. Defaults to the supplied version.
        /// </summary>
        public static string OperaDriverLocation { get; set; }

        /// <summary>
        /// Location of the Chrome application
        /// </summary>
        public static string ChromeLocation { get; set; }

        /// <summary>
        /// Locations of the Firefox application
        /// </summary>
        public static string FirefoxLocation { get; set; }

        /// <summary>
        /// Location of the Opera application
        /// </summary>
        public static string OperaLocation { get; set; }

        /// <summary>
        /// The debug level to use for the test run
        /// </summary>
        public static EnumConsoleDebugLevel DebugLevel { get; set; }



        static internal Assembly _assembly;
        static internal string _libraryLoc;

        static BaseSettings()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _libraryLoc = Assembly.GetExecutingAssembly().FullName.Split(',')[0];

            FindDrivers();
            FindApplications();

            Timeout = new TimeSpan(0, 0, 0, 30, 0);
            Sleep = new TimeSpan(0, 0, 0, 20, 0);
            ImplicitWait = new TimeSpan(0, 0, 0, 10, 0);
            MenuHoverTime = new TimeSpan(0, 0, 0, 10, 0);
            PageLoad = new TimeSpan(0, 0, 0, 30, 0);
            AsyncJavaScript = new TimeSpan(0, 0, 0, 10, 0);

            AlertHandling = true;
            InternalTimers = true;
        }

#if NET461 || NET462 || NET47 || NET471 || NET472
        static private void FindDrivers()
        {
            string grandfatherDirectory = GetGrandfatherDirectory();
            ChromeDriverLocation = FindExecutables(grandfatherDirectory, "chromedriver.exe");
            EdgeDriverLocation = FindExecutables(grandfatherDirectory, "MicrosoftWebDriver.exe");
            FirefoxDriverLocation = FindExecutables(grandfatherDirectory, "geckodriver.exe");
            InternetExplorerDriverLocation = FindExecutables(grandfatherDirectory, "IEDriverServer.exe");
            OperaDriverLocation = FindExecutables(grandfatherDirectory, "operadriver.exe");
        }
#endif

#if  NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2 || NETSTANDARD2_0
        static private void FindDrivers()
        {
            ChromeDriverLocation = FindExecutables(@".\BrowserDrivers\", "chromedriver.exe");
            EdgeDriverLocation = FindExecutables(@".\BrowserDrivers\", "MicrosoftWebDriver.exe");
            FirefoxDriverLocation = FindExecutables(@".\BrowserDrivers\", "geckodriver.exe");
            InternetExplorerDriverLocation = FindExecutables(@".\BrowserDrivers\", "IEDriverServer.exe");
            OperaDriverLocation = FindExecutables(@".\BrowserDrivers\", "operadriver.exe");
        }
#endif

        static private void FindApplications()
        {
            ChromeLocation = FindExecutables(@"C:\Program Files (x86)\Google\Chrome\Application", "chrome.exe");
            FirefoxLocation = FindExecutables(@"C:\Program Files (x86)\Mozilla Firefox", "firefox.exe");
            OperaLocation = FindExecutables(@"C:\Program Files\Opera", "opera.exe");
        }

        /// <summary>
        /// Gets the grandfather directory for the current test assembly
        /// </summary>
        /// <returns>The grandfather directory</returns>
        static private string GetGrandfatherDirectory()
        {
            return Directory.GetParent(Path.GetFullPath(Path.Combine(Path.GetFullPath(_assembly.Location), @"..\..\"))).FullName;
        }

        /// <summary>
        /// Finds all files with a specified name in a specified directory.
        /// </summary>
        /// <param name="pathToSearch">Path to search for files.</param>
        /// <param name="fileToFind">File name to find.</param>
        /// <returns>An array of file paths that fit the search parameters.</returns>
        static private string FindExecutables(string pathToSearch, string fileToFind)
        {
            try
            {
                return Directory.GetFiles(pathToSearch, fileToFind, SearchOption.AllDirectories)[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
