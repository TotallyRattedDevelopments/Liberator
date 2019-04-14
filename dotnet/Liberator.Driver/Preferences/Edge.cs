namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Preferences for EdgeDriver
    /// </summary>
    public static class Edge
    {
        static Edge()
        {
            HideCommandPromptWindow = "False";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "False";
            UseVerboseLogging = "True";
        }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public static string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the port of the service.
        /// </summary>
        public static string Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is
        /// suppressed when starting the driver server executable. Defaults to false, meaning
        /// diagnostic information should be shown by the driver server executable.
        /// </summary>
        public static string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
        /// </summary>
        public static string UseVerboseLogging { get; set; }

        /// <summary>
        /// Gets or sets the value of the host adapter on which the Edge driver service should listen for connections
        /// </summary>
        public static string Host { get; set; }

        /// <summary>
        /// Gets or sets the value of the package the Edge driver service will launch and automate.
        /// </summary>
        public static string Package { get; set; }
    }

    /// <summary>
    /// Settings file for dependency injection
    /// </summary>
    public class EdgeSettings
    {
        /// <summary>
        /// Contructor with default settings
        /// </summary>
        public EdgeSettings()
        {
            HideCommandPromptWindow = "False";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "False";
            UseVerboseLogging = "True";
        }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the port of the service.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is
        /// suppressed when starting the driver server executable. Defaults to false, meaning
        /// diagnostic information should be shown by the driver server executable.
        /// </summary>
        public string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
        /// </summary>
        public string UseVerboseLogging { get; set; }

        /// <summary>
        /// Gets or sets the value of the host adapter on which the Edge driver service should listen for connections
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the value of the package the Edge driver service will launch and automate.
        /// </summary>
        public string Package { get; set; }
    }
}
