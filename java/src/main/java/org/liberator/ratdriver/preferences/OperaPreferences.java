package org.liberator.ratdriver.preferences;

@SuppressWarnings({"CanBeFinal", "unused"})
public class OperaPreferences extends BasePreferences {

    public OperaPreferences()
    {
        LeaveBrowserRunning = false;
        AndroidDebugBridgePort = -1;
        EnableVerboseLogging = false;
        HideCommandPromptWindow = true;
        Port = 4444;
        SuppressInitialDiagnosticInformation = true;

        DebuggerAddress = null;
        MinidumpPath = null;
        LogPath = null;
        PortServerAddress = null;
        UnexpectedAlertBehaviour = null;
        UrlPathPrefix = null;
        AcceptInsecureCertificates = null;
        AcceptSSLCertificates = null;
        PageLoadStrategy = null;
        TakesScreenshot = null;
        UnhandledPromptBehaviour = null;
    }

    /**
     * Gets or sets the address of a Opera debugger server to connect to. Should be of the form "{hostname|IP address}:port".
     */
    public String DebuggerAddress;

    /**
     * Gets or sets a value indicating whether Opera should be left running after the OperaDriver instance is exited. Defaults to false.
     */
    public Boolean LeaveBrowserRunning;

    /**
     * Gets or sets the directory in which to store minidump files.
     */
    public String MinidumpPath;

    /**
     * Gets or sets the port on which the Android Debug Bridge is listening for commands.
     */
    public Integer AndroidDebugBridgePort;

    /**
     * Gets or sets a value indicating whether to enable verbose logging for the OperaDriver executable. Defaults to false.
     */
    public Boolean EnableVerboseLogging;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public Boolean HideCommandPromptWindow;

    /**
     * Gets or sets the location of the log file written to by the OperaDriver executable.
     */
    public String LogPath;

    /**
     * Gets or sets the port of the service.
     */
    public Integer Port;

    /**
     * Gets or sets the address of a server to contact for reserving a port.
     */
    public String PortServerAddress;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public Boolean SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets the base URL path prefix for commands (e.g., "wd/url").
     */
    public String UrlPathPrefix;

    /**
     * Whether to accept insecure certificates
     */
    public Boolean AcceptInsecureCertificates;

    /**
     * Whether to accept SSL certificates
     */
    public Boolean AcceptSSLCertificates;

    /**
     * The page load strategy for the driver
     */
    public String PageLoadStrategy;

    /**
     * Whether the driver should take screenshots
     */
    public Boolean TakesScreenshot;

    /**
     * The unexpected alert behaviour
     */
    public String UnexpectedAlertBehaviour;

    /**
     * The unhandled prompt behaviour
     */
    public String UnhandledPromptBehaviour;
}
