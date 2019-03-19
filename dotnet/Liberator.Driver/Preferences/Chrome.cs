namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Preferences for ChromeDriver
    /// </summary>
    public static class Chrome
    {
        static Chrome()
        {
            // Driver Pre-sets
            BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            LeaveBrowserRunning = "False";
            MinidumpPath = @"\Outputs\";

            // Driver Performance Pre-Sets
            BufferUsageReportingInterval = "0,0,0,1,0";
            IsCollectingNetworkEvents = "True";
            IsCollectingPageEvents = "True";

            // Tracing
            TracingCategories = "devtools.timeline";

            CapabilityList = "";

            // Driver Service Pre-Sets
            AndroidDebugBridgePort = "5037";
            EnableVerboseLogging = "true";
            HideCommandPromptWindow = "false";
            LogPath = "/Logs/";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "false";

            // Mobile Emulation Pre-Sets
            EnableTouchEvents = "True";
            Height = "360";
            PixelRatio = "3";
            UserAgent = "";
            Width = "640";
        }

        /// <summary>
        /// Gets or sets the location of the Chrome browser's binary executable file.
        /// </summary>
        public static string BinaryLocation { get; set; }

        /// <summary>
        /// Gets or sets the address of a Chrome debugger server to connect to. Should be of the form "{hostname|IP address}:port".
        /// </summary>
        public static string DebuggerAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Chrome should be left running after the ChromeDriver instance is exited. Defaults to false.
        /// </summary>
        public static string LeaveBrowserRunning { get; set; }

        /// <summary>
        /// Gets or sets the directory in which to store minidump files.
        /// </summary>
        public static string MinidumpPath { get; set; }

        /// <summary>
        /// Gets or sets the interval between Chrome DevTools trace buffer usage events. Defaults to 1000 milliseconds.
        /// </summary>
        public static string BufferUsageReportingInterval { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Chrome will collect events from the Network domain. Defaults to true.
        /// </summary>
        public static string IsCollectingNetworkEvents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Chrome will collect events from the Page domain. Defaults to true.
        /// </summary>
        public static string IsCollectingPageEvents { get; set; }

        /// <summary>
        /// List of browser capabilities in the format {name}={value}|{type}
        /// </summary>
        public static string CapabilityList { get; set; }

        /// <summary>
        /// Gets a comma-separated list of the categories for which tracing is enabled.
        /// </summary>
        public static string TracingCategories { get; set; }

        /// <summary>
        /// Comma separated list of extension locations
        /// </summary>
        public static string ExtensionsList { get; set; }

        /// <summary>
        /// Comma separated list of local state preferences in the format {name}={value}|{type}
        /// </summary>
        public static string LocalStatePreferences { get; set; }

        /// <summary>
        /// Comma separated list of user profile preferences in the format {name}={value}|{type}
        /// </summary>
        public static string UserProfilePreferences { get; set; }

        /// <summary>
        /// Gets or sets the port on which the Android Debug Bridge is listening for commands.
        /// </summary>
        public static string AndroidDebugBridgePort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
        /// </summary>
        public static string EnableVerboseLogging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public static string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the location of the log file written to by the ChromeDriver executable.
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
        /// Gets or sets the comma-delimited list of IP addresses that are approved to connect
        /// to this instance of the Chrome driver. Defaults to an empty string, which means
        /// only the local loopback address can connect.
        /// </summary>
        public static string WhitelistedIPAddresses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether touch events should be enabled by the browser when emulating a mobile device. Defaults to true.
        /// </summary>
        public static string EnableTouchEvents { get; set; }

        /// <summary>
        /// Gets or sets the height in pixels to be used by the browser when emulating a mobile device.
        /// </summary>
        public static string Height { get; set; }

        /// <summary>
        /// Gets or sets the pixel ratio to be used by the browser when emulating a mobile device.
        /// </summary>
        public static string PixelRatio { get; set; }

        /// <summary>
        /// Gets or sets the user agent string to be used by the browser when emulating a mobile device.
        /// </summary>
        public static string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the width in pixels to be used by the browser when emulating a mobile device.
        /// </summary>
        public static string Width { get; set; }
    }
}
