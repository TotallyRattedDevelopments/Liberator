using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Liberator.Driver.Preferences;
using Liberator.Driver.Enums;

namespace Liberator.Driver.Preferences
{
    static internal class Preferences
    {
        static internal KeyValueConfigurationCollection _kvList;
        static internal ConfigReader _reader;
        static internal AppSettingsSection _appSettings;

        static internal string DriverPath { get; set; }
        static internal EnumConsoleDebugLevel DebugLevel { get; set; }

        static Preferences()
        {
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
            Assembly assembly = Assembly.GetExecutingAssembly();
            _reader = new ConfigReader(Path.GetDirectoryName(assembly.Location) + @"\Liberator.Driver.dll.config");
            _reader.GetAppSettings();
            _appSettings = _reader.AppSettings;
            _kvList = _appSettings.Settings;
            DriverPath = Path.GetDirectoryName(assembly.Location) + _kvList["DriverPath"].Value;
            return _reader;
        }
    }
}
