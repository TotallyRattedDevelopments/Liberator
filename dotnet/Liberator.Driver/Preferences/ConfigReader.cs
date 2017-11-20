using System;
using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Provides a reader for configuration files
    /// </summary>
    public class ConfigReader : IDisposable
    {
        private string _filePath;
        private ExeConfigurationFileMap _fileMap;
        private Configuration _config;
        private AppSettingsSection _appSettings;

        #region Accessors

        /// <summary>
        /// The file path of the configuration file
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        /// <summary>
        /// Represents a file mapping for the configuration file
        /// </summary>
        public ExeConfigurationFileMap FileMap
        {
            get { return _fileMap; }
            set { _fileMap = value; }
        }

        /// <summary>
        /// Represents the configuration file being interpreted
        /// </summary>
        public Configuration Config
        {
            get { return _config; }
            set { _config = value; }
        }

        /// <summary>
        /// Contains the AppSettings element of the configuration file
        /// </summary>
        public AppSettingsSection AppSettings
        {
            get { return _appSettings; }
            set { _appSettings = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor for the config reader
        /// </summary>
        public ConfigReader()
        {

        }

        /// <summary>
        /// Constructor for the config reader
        /// </summary>
        /// <param name="filePath">Path of the config file</param>
        public ConfigReader(string filePath)
        {
            _filePath = filePath;
            _fileMap = new ExeConfigurationFileMap { ExeConfigFilename = _filePath };
        }

        /// <summary>
        /// Disposes of the instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the instance
        /// </summary>
        /// <param name="disposing">Whether the object is disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            bool disposed = false;
            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            if (disposed) { return; }
            if (disposing) { handle.Dispose(); }
            disposed = true;
        }



        #endregion

        #region Public Methods

        /// <summary>
        /// Get a setting from the configuration file
        /// </summary>
        /// <param name="setting">The name of the setting</param>
        /// <returns>The setting from the configuration file</returns>
        public string GetSetting(string setting)
        {
            GetConfiguration();

            if (_config.HasFile)
            {
                _appSettings = _config.AppSettings;
                KeyValueConfigurationElement element = _appSettings.Settings[setting];
                return element.Value;
            }
            return null;
        }

        /// <summary>
        /// Gets the file map and maps the config file and extracts the app settings section
        /// </summary>
        public void GetAppSettings()
        {
            _fileMap = new ExeConfigurationFileMap { ExeConfigFilename = _filePath };
            _config = ConfigurationManager.OpenMappedExeConfiguration(_fileMap, ConfigurationUserLevel.None);
            _appSettings = _config.AppSettings;
        }

        /// <summary>
        /// Gets the file map and maps the config file
        /// </summary>
        public void GetConfiguration()
        {
            _fileMap = new ExeConfigurationFileMap { ExeConfigFilename = _filePath };
            _config = ConfigurationManager.OpenMappedExeConfiguration(_fileMap, ConfigurationUserLevel.None);
        }

        #endregion
    }
}
