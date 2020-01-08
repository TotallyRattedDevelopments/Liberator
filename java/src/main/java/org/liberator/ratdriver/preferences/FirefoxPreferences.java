package org.liberator.ratdriver.preferences;

public class FirefoxPreferences extends BasePreferences {
    
    public FirefoxPreferences()
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
    public String LogLevel;

    /**
     * Gets the directory containing the profile.
     */
    public String ProfileDirectory;

    /**
     * Cleans this Firefox profile.
     */
    public String CleanProfile;

    /**
     * Gets or sets a value indicating whether to use the legacy driver implementation.
     */
    public String UseLegacyImplementation;

    /**
     * Gets or sets a value indicating whether Firefox should accept SSL certificates
     * which have expired, signed by an unknown authority or are generally untrusted.
     * Set to true by default.
     */
    public String AcceptUntrustedCertificates;

    /**
     * Gets or sets a value indicating whether to always load the library for allowing
     * Firefox to execute commands without its window having focus.
     */
    public String AlwaysLoadNoFocusLibrary;

    /**
     * Gets or sets a value indicating whether Firefox assume untrusted SSL certificates
     * come from an untrusted issuer or are self-signed. Set to true by default.
     */
    public String AssumeUntrustedCertificateIssuer;

    /**
     * Gets or sets a value indicating whether to delete this profile after use with the OpenQA.Selenium.Firefox.FirefoxDriver.
     */
    public String DeleteAfterUse;

    /**
     * Gets or sets a value indicating whether native events are enabled.
     */
    public String EnableNativeEvents;

    /**
     * Gets or sets the port on which the profile connects to the WebDriver extension.
     */
    public String Port;

    /**
     * Comma separated list of proxy preferences in the format {name}={value}|{type}
     */
    public String ProxyPreferences = null;

    /**
     * Gets or sets the port used by the driver executable to communicate with the browser.
     */
    public String CommunicationPort = null;

    /**
     * Gets or sets a value indicating whether to connect to an already-running instance of Firefox.
     */
    public String ConnectToRunningBrowser;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public String HideCommandPromptWindow;

    /**
     * Gets or sets the value of the IP address of the host adapter on which the service should listen for connections.
     */
    public String Host = null;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public String SuppressInitialDiagnosticInformation;

    /**
     * Comma separated list of preferences in the format {name}={value}|{type}
     */
    public String Preferences = null;
}
