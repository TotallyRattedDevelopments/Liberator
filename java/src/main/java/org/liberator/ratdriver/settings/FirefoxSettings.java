package org.liberator.ratdriver.settings;

public class FirefoxSettings extends BaseSettings {

    public FirefoxSettings()
    {
        LogLevel = "Trace";
        ProfileDirectory = "\\BrowserDrivers\\Profiles";
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

    /**
     * Gets or sets the logging level of the Firefox driver.
     */
    public static String LogLevel = null;


    /**
     * Gets the directory containing the profile.
     */
    public static String ProfileDirectory = null;

    /**
     * Cleans this Firefox profile.
     */
    public static String CleanProfile = null;

    /**
     * Gets or sets a value indicating whether to use the legacy driver implementation.
     */
    public static String UseLegacyImplementation = null;

    /**
     * Gets or sets a value indicating whether Firefox should accept SSL certificates
     * which have expired, signed by an unknown authority or are generally untrusted.
     * Set to true by default.
     */
    public static String AcceptUntrustedCertificates = null;

    /**
     * Gets or sets a value indicating whether to always load the library for allowing
     * Firefox to execute commands without its window having focus.
     */
    public static String AlwaysLoadNoFocusLibrary = null;

    /**
     * Gets or sets a value indicating whether Firefox assume untrusted SSL certificates
     * come from an untrusted issuer or are self-signed. Set to true by default.
     */
    public static String AssumeUntrustedCertificateIssuer = null;

    /**
     * Gets or sets a value indicating whether to delete this profile after use with the OpenQA.Selenium.Firefox.FirefoxDriver.
     */
    public static String DeleteAfterUse = null;

    /**
     * Gets or sets a value indicating whether native events are enabled.
     */
    public static String EnableNativeEvents = null;

    /**
     * Gets or sets the port on which the profile connects to the WebDriver extension.
     */
    public static String Port = null;

    /**
     * Comma separated list of proxy preferences in the format {name}={value}|{type}
     */
    public static String ProxyPreferences = null;

    /**
     * Gets or sets the port used by the driver executable to communicate with the browser.
     */
    public static String CommunicationPort = null;

    /**
     * Gets or sets a value indicating whether to connect to an already-running instance of Firefox.
     */
    public static String ConnectToRunningBrowser = null;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public static String HideCommandPromptWindow = null;

    /**
     * Gets or sets the value of the IP address of the host adapter on which the service should listen for connections.
     */
    public static String Host = null;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public static String SuppressInitialDiagnosticInformation = null;

    /**
     * Comma separated list of preferences in the format {name}={value}|{type}
     */
    public static String Preferences = null;
}
