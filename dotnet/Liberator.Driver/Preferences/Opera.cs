namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Preferences for the Opera Driver
    /// </summary>
    public static class Opera
    {
        static Opera()
        {
            LeaveBrowserRunning = "false";
            AndroidDebugBridgePort = "-1";
            EnableVerboseLogging = "false";
            HideCommandPromptWindow = "true";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "true";
        }

        /// <summary>
        /// Gets or sets the address of a Opera debugger server to connect to. Should be of the form "{hostname|IP address}:port".
        /// </summary>
        public static string DebuggerAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Opera should be left running after the OperaDriver instance is exited. Defaults to false.
        /// </summary>
        public static string LeaveBrowserRunning { get; set; }

        /// <summary>
        /// Gets or sets the directory in which to store minidump files.
        /// </summary>
        public static string MinidumpPath { get; set; }

        /// <summary>
        /// Gets or sets the port on which the Android Debug Bridge is listening for commands.
        /// </summary>
        public static string AndroidDebugBridgePort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable verbose logging for the OperaDriver executable. Defaults to false.
        /// </summary>
        public static string EnableVerboseLogging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public static string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the location of the log file written to by the OperaDriver executable.
        /// </summary>
        public static string LogPath { get; set; }

        /// <summary>
        /// Gets or sets the port of the service.
        /// </summary>
        public static string Port { get; set; }

        /// <summary>
        /// Gets or sets the address of a server to contact for reserving a port.
        /// </summary>
        public static string PortServerAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is
        /// suppressed when starting the driver server executable. Defaults to false, meaning
        /// diagnostic information should be shown by the driver server executable.
        /// </summary>
        public static string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Gets or sets the base URL path prefix for commands (e.g., "wd/url").
        /// </summary>
        public static string UrlPathPrefix { get; set; }
    }

    /// <summary>
    /// Settings file for dependency injection
    /// </summary>
    public class OperaSettings : BasePreferences
    {
        /// <summary>
        /// Contructor with default settings
        /// </summary>
        public OperaSettings()
        {
            LeaveBrowserRunning = "false";
            AndroidDebugBridgePort = "-1";
            EnableVerboseLogging = "false";
            HideCommandPromptWindow = "true";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "true";
        }

        /// <summary>
        /// Gets or sets the address of a Opera debugger server to connect to. Should be of the form "{hostname|IP address}:port".
        /// </summary>
        public string DebuggerAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Opera should be left running after the OperaDriver instance is exited. Defaults to false.
        /// </summary>
        public string LeaveBrowserRunning { get; set; }

        /// <summary>
        /// Gets or sets the directory in which to store minidump files.
        /// </summary>
        public string MinidumpPath { get; set; }

        /// <summary>
        /// Gets or sets the port on which the Android Debug Bridge is listening for commands.
        /// </summary>
        public string AndroidDebugBridgePort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable verbose logging for the OperaDriver executable. Defaults to false.
        /// </summary>
        public string EnableVerboseLogging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the location of the log file written to by the OperaDriver executable.
        /// </summary>
        public string LogPath { get; set; }

        /// <summary>
        /// Gets or sets the port of the service.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets the address of a server to contact for reserving a port.
        /// </summary>
        public string PortServerAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is
        /// suppressed when starting the driver server executable. Defaults to false, meaning
        /// diagnostic information should be shown by the driver server executable.
        /// </summary>
        public string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Gets or sets the base URL path prefix for commands (e.g., "wd/url").
        /// </summary>
        public string UrlPathPrefix { get; set; }
    }
}
