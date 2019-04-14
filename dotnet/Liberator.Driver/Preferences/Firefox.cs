namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Preferences for FirefoxDriver
    /// </summary>
    public static class Firefox
    {
        static Firefox()
        {
            LogLevel = "Trace";
            ProfileDirectory = @"\BrowserDrivers\Profiles";
            CleanProfile = "False";
            UseLegacyImplementation = "False";

            AcceptUntrustedCertificates = "True";
            AlwaysLoadNoFocusLibrary = "True";
            AssumeUntrustedCertificateIssuer = "True";
            DeleteAfterUse = "False";
            EnableNativeEvents = "False";
            Port = "4444";

            ConnectToRunningBrowser = "False";
            HideCommandPromptWindow = "False";
            SuppressInitialDiagnosticInformation = "False";
        }

        /// <summary>
        /// Gets or sets the logging level of the Firefox driver.
        /// </summary>
        public static string LogLevel { get; set; }

        /// <summary>
        /// Gets the directory containing the profile.
        /// </summary>
        public static string ProfileDirectory { get; set; }

        /// <summary>
        /// Cleans this Firefox profile.
        /// </summary>
        public static string CleanProfile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the legacy driver implementation.
        /// </summary>
        public static string UseLegacyImplementation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Firefox should accept SSL certificates
        /// which have expired, signed by an unknown authority or are generally untrusted.
        /// Set to true by default.
        /// </summary>
        public static string AcceptUntrustedCertificates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to always load the library for allowing
        /// Firefox to execute commands without its window having focus.
        /// </summary>
        public static string AlwaysLoadNoFocusLibrary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Firefox assume untrusted SSL certificates
        /// come from an untrusted issuer or are self-signed. Set to true by default.
        /// </summary>
        public static string AssumeUntrustedCertificateIssuer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to delete this profile after use with the OpenQA.Selenium.Firefox.FirefoxDriver.
        /// </summary>
        public static string DeleteAfterUse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether native events are enabled.
        /// </summary>
        public static string EnableNativeEvents { get; set; }

        /// <summary>
        /// Gets or sets the port on which the profile connects to the WebDriver extension.
        /// </summary>
        public static string Port { get; set; }

        /// <summary>
        /// Comma separated list of proxy preferences in the format {name}={value}|{type}
        /// </summary>
        public static string ProxyPreferences { get; set; }

        /// <summary>
        /// Gets or sets the port used by the driver executable to communicate with the browser.
        /// </summary>
        public static string CommunicationPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to connect to an already-running instance of Firefox.
        /// </summary>
        public static string ConnectToRunningBrowser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public static string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the value of the IP address of the host adapter on which the service should listen for connections.
        /// </summary>
        public static string Host { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is
        /// suppressed when starting the driver server executable. Defaults to false, meaning
        /// diagnostic information should be shown by the driver server executable.
        /// </summary>
        public static string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Comma separated list of preferences in the format {name}={value}|{type}
        /// </summary>
        public static string Preferences { get; set; }
    }

    /// <summary>
    /// Settings file for dependency injection
    /// </summary>
    public class FirefoxSettings
    {
        /// <summary>
        /// Contructor with default settings
        /// </summary>
        public FirefoxSettings()
        {
            LogLevel = "Trace";
            ProfileDirectory = @"\BrowserDrivers\Profiles";
            CleanProfile = "False";
            UseLegacyImplementation = "False";

            AcceptUntrustedCertificates = "True";
            AlwaysLoadNoFocusLibrary = "True";
            AssumeUntrustedCertificateIssuer = "True";
            DeleteAfterUse = "False";
            EnableNativeEvents = "False";
            Port = "4444";

            ConnectToRunningBrowser = "False";
            HideCommandPromptWindow = "False";
            SuppressInitialDiagnosticInformation = "False";
        }

        /// <summary>
        /// Gets or sets the logging level of the Firefox driver.
        /// </summary>
        public string LogLevel { get; set; }

        /// <summary>
        /// Gets the directory containing the profile.
        /// </summary>
        public string ProfileDirectory { get; set; }

        /// <summary>
        /// Cleans this Firefox profile.
        /// </summary>
        public string CleanProfile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the legacy driver implementation.
        /// </summary>
        public string UseLegacyImplementation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Firefox should accept SSL certificates
        /// which have expired, signed by an unknown authority or are generally untrusted.
        /// Set to true by default.
        /// </summary>
        public string AcceptUntrustedCertificates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to always load the library for allowing
        /// Firefox to execute commands without its window having focus.
        /// </summary>
        public string AlwaysLoadNoFocusLibrary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Firefox assume untrusted SSL certificates
        /// come from an untrusted issuer or are self-signed. Set to true by default.
        /// </summary>
        public string AssumeUntrustedCertificateIssuer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to delete this profile after use with the OpenQA.Selenium.Firefox.FirefoxDriver.
        /// </summary>
        public string DeleteAfterUse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether native events are enabled.
        /// </summary>
        public string EnableNativeEvents { get; set; }

        /// <summary>
        /// Gets or sets the port on which the profile connects to the WebDriver extension.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Comma separated list of proxy preferences in the format {name}={value}|{type}
        /// </summary>
        public string ProxyPreferences { get; set; }

        /// <summary>
        /// Gets or sets the port used by the driver executable to communicate with the browser.
        /// </summary>
        public string CommunicationPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to connect to an already-running instance of Firefox.
        /// </summary>
        public string ConnectToRunningBrowser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the value of the IP address of the host adapter on which the service should listen for connections.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is
        /// suppressed when starting the driver server executable. Defaults to false, meaning
        /// diagnostic information should be shown by the driver server executable.
        /// </summary>
        public string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Comma separated list of preferences in the format {name}={value}|{type}
        /// </summary>
        public string Preferences { get; set; }
    }

}
