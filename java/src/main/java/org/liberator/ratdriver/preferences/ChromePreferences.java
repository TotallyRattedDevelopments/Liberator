package org.liberator.ratdriver.preferences;

import com.sun.javafx.PlatformUtil;

/**
 * Settings file for dependency injection
 */
public class ChromePreferences extends BasePreferences {
    /**
     * Gets or sets the location of the Chrome browser's binary executable file.
     */
    public String BinaryLocation;

    /**
     * Gets or sets the address of a Chrome debugger server to connect to. Should be of the form "{hostname|IP address}:port".
     */
    public String DebuggerAddress = null;

    /**
     * Gets or sets a value indicating whether Chrome should be left running after the ChromeDriver instance is exited. Defaults to false.
     */
    public String LeaveBrowserRunning;

    /**
     * Gets or sets the directory in which to store minidump files.
     */
    public String MinidumpPath;

    /**
     * Gets or sets the interval between Chrome DevTools trace buffer usage events. Defaults to 1000 milliseconds.
     */
    public Integer BufferUsageReportingInterval;

    /**
     * Gets or sets a value indicating whether Chrome will collect events from the Network domain. Defaults to true.
     */
    public Boolean IsCollectingNetworkEvents;

    /**
     * Gets or sets a value indicating whether Chrome will collect events from the Page domain. Defaults to true.
     */
    public Boolean IsCollectingPageEvents;

    /**
     * List of browser capabilities in the format {name}={value}|{type}
     */
    public String CapabilityList;

    /**
     * Gets a comma-separated list of the categories for which tracing is enabled.
     */
    public String TracingCategories;

    /**
     * Comma separated list of extension locations
     */
    public String ExtensionsList = null;

    /**
     * Comma separated list of local state preferences in the format {name}={value}|{type}
     */
    public String LocalStatePreferences = null;

    /**
     * Comma separated list of user profile preferences in the format {name}={value}|{type}
     */
    public String UserProfilePreferences = null;

    /**
     * Gets or sets the port on which the Android Debug Bridge is listening for commands.
     */
    public String AndroidDebugBridgePort;

    /**
     * Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
     */
    public String EnableVerboseLogging;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public String HideCommandPromptWindow;

    /**
     * Gets or sets the location of the log file written to by the ChromeDriver executable.
     */
    public String LogPath;

    /**
     * Gets or sets the port of the service.
     */
    public int Port;

    /**
     * Gets or sets the address of a server to contact for reserving a port.
     */
    public String PortServerAddress = null;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public String SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets the comma-delimited list of IP addresses that are approved to connect
     * to this instance of the Chrome driver. Defaults to an empty String, which means
     * only the local loopback address can connect.
     */
    public String WhitelistedIPAddresses = null;

    /**
     * Gets or sets a value indicating whether touch events should be enabled by the browser when emulating a mobile device. Defaults to true.
     */
    public String EnableTouchEvents;

    /**
     * Gets or sets the height in pixels to be used by the browser when emulating a mobile device.
     */
    public String Height;

    /**
     * Gets or sets the pixel ratio to be used by the browser when emulating a mobile device.
     */
    public String PixelRatio;

    /**
     * Gets or sets the user agent String to be used by the browser when emulating a mobile device.
     */
    public String UserAgent;

    /**
     * Gets or sets the width in pixels to be used by the browser when emulating a mobile device.
     */
    public String Width;

    public ChromePreferences()
    {
        // Driver Pre-sets
        if (PlatformUtil.isMac()) {
            ChromeDriverLocation = "src/main/resources/drivers/mac/chromedriver";
            BinaryLocation = "/Applications/Google Chrome.app";
            MinidumpPath = "/";
        } else if (PlatformUtil.isWindows()) {
            ChromeDriverLocation = "src/main/resources/drivers/win/chromedriver.exe";
            BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
            MinidumpPath = "\\Outputs\\";
        } else if (PlatformUtil.isLinux()){
            BinaryLocation = "/";
            MinidumpPath = "/";
        }

        LeaveBrowserRunning = "false";

        // Driver Performance Pre-Sets
        BufferUsageReportingInterval = 1000;
        IsCollectingNetworkEvents = false;
        IsCollectingPageEvents = false;

        // Tracing
        TracingCategories = "dbrowser,devtools.timeline,devtools";

        CapabilityList = "";

        // Driver Service Pre-Sets
        AndroidDebugBridgePort = "5037";
        EnableVerboseLogging = "false";
        HideCommandPromptWindow = "false";
        //LogPath = "/Logs/";
        Port = 4444;
        SuppressInitialDiagnosticInformation = "false";

        // Mobile Emulation Pre-Sets
        EnableTouchEvents = "True";
        Height = "360";
        PixelRatio = "3";
        UserAgent = "";
        Width = "640";
    }
}
