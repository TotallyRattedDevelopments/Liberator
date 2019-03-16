using Liberator.Driver.Enums;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Liberator.Driver.Preferences
{
    static internal class Preferences
    {
        static internal KeyValueConfigurationCollection _kvList;
        static internal ConfigReader _reader;
        static internal AppSettingsSection _appSettings;

        static internal string DriverPath { get; set; }
        static internal EnumConsoleDebugLevel DebugLevel { get; set; }

        static internal string _chromeDriverLocation;
        static internal string _edgeDriverLocation;
        static internal string _firefoxDriverLocation;
        static internal string _internetExplorerDriverLocation;
        static internal string _operaDriverLocation;
        static internal Assembly _assembly;
        static internal string _libraryLoc;

        static Preferences()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _libraryLoc = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            FindDrivers();
            KVList = new KeyValueConfigurationCollection();
            GetDriverReader();
        }

        public static void GetPreferences()
        {
            GetDriverReader();
        }

        public static string GetPreferenceSetting(string setting)
        {
            try
            {
                GetPreferences();
                return KVList[setting].Value;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot retrieve setting {0} as requested", setting);
                return null;
            }
        }

        static internal KeyValueConfigurationCollection KVList
        {
            get { return _kvList; }
            set { _kvList = value; }
        }

        static private ConfigReader GetDriverReader()
        {
            _reader = new ConfigReader(Path.GetDirectoryName(_assembly.Location) + @"\" + _libraryLoc + ".dll.config");
            _reader.GetAppSettings();
            _appSettings = _reader.AppSettings;
            _kvList = _appSettings.Settings;
            DriverPath = _chromeDriverLocation;
            return _reader;
        }

        static private void FindDrivers()
        {
            string grandfatherDirectory = GetGrandfatherDirectory();
            _chromeDriverLocation = FindDriverFiles(grandfatherDirectory, "chromedriver.exe");
            _edgeDriverLocation = FindDriverFiles(grandfatherDirectory, "MicrosoftWebDriver.exe");
            _firefoxDriverLocation = FindDriverFiles(grandfatherDirectory, "geckodriver.exe");
            _internetExplorerDriverLocation = FindDriverFiles(grandfatherDirectory, "IEDriverServer.exe");
            _operaDriverLocation = FindDriverFiles(grandfatherDirectory, "operadriver.exe");
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
        static private string FindDriverFiles(string pathToSearch, string fileToFind)
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
