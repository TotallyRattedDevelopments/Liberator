package org.liberator.ratdriver.settings;

import com.sun.javafx.PlatformUtil;

/**
 * Preferences for ChromeDriver
 */
public class ChromeSettings extends BaseSettings {

    /**
     * Gets or sets the location of the Chrome browser's binary executable file.
     */
    public static String BinaryLocation = null;

    /**
     * Gets or sets the address of a Chrome debugger server to connect to. Should be of the form "{hostname|IP address}:port".
     */
    public static String DebuggerAddress = null;

    /**
     * Gets or sets a value indicating whether Chrome should be left running after the ChromeDriver instance is exited. Defaults to false.
     */
    public static String LeaveBrowserRunning;

    /**
     * Gets or sets the directory in which to store minidump files.
     */
    public static String MinidumpPath = null;

    /**
     * Gets or sets the interval between Chrome DevTools trace buffer usage events. Defaults to 1000 milliseconds.
     */
    public static Integer BufferUsageReportingInterval;

    /**
     * Gets or sets a value indicating whether Chrome will collect events from the Network domain. Defaults to true.
     */
    public static Boolean IsCollectingNetworkEvents;

    /**
     * Gets or sets a value indicating whether Chrome will collect events from the Page domain. Defaults to true.
     */
    public static Boolean IsCollectingPageEvents;

    /**
     * List of browser capabilities in the format {name}={value}|{type}
     */
    public static String CapabilityList = null;

    /**
     * Gets a comma-separated list of the categories for which tracing is enabled.
     */
    public static String TracingCategories;

    /**
     * Comma separated list of extension locations
     */
    public static String ExtensionsList = null;

    /**
     * Comma separated list of local state preferences in the format {name}={value}|{type}
     */
    public static String LocalStatePreferences = null;

    /**
     * Comma separated list of user profile preferences in the format {name}={value}|{type}
     */
    public static String UserProfilePreferences = null;

    /**
     * Gets or sets the port on which the Android Debug Bridge is listening for commands.
     */
    public static String AndroidDebugBridgePort;

    /**
     * Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
     */
    public static String EnableVerboseLogging;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public static String HideCommandPromptWindow;

    /**
     * Gets or sets the location of the log file written to by the ChromeDriver executable.
     */
    public static String LogPath = null;

    /**
     * Gets or sets the port of the service.
     */
    public static int Port = -1;

    /**
     * Gets or sets the address of a server to contact for reserving a port.
     */
    public static String PortServerAddress = null;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public static String SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets the comma-delimited list of IP addresses that are approved to connect
     * to this instance of the Chrome driver. Defaults to an empty String, which means
     * only the local loopback address can connect.
     */
    public static String WhitelistedIPAddresses = null;

    /**
     * Gets or sets a value indicating whether touch events should be enabled by the browser when emulating a mobile device. Defaults to true.
     */
    public static String EnableTouchEvents;

    /**
     * Gets or sets the height in pixels to be used by the browser when emulating a mobile device.
     */
    public static String Height;

    /**
     * Gets or sets the pixel ratio to be used by the browser when emulating a mobile device.
     */
    public static String PixelRatio;

    /**
     * Gets or sets the user agent String to be used by the browser when emulating a mobile device.
     */
    public static String UserAgent;

    /**
     * Gets or sets the width in pixels to be used by the browser when emulating a mobile device.
     */
    public static String Width;

    static {
        // Driver Pre-sets
        if (PlatformUtil.isMac()) {
            ChromeDriverLocation = "src/main/resources/drivers/chromedriver";
            BinaryLocation = "/Applications/Google Chrome.app";
            MinidumpPath = "/";
        } else if (PlatformUtil.isWindows()) {
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


        // Driver Service Pre-Sets
        AndroidDebugBridgePort = "5037";
        EnableVerboseLogging = "false";
        HideCommandPromptWindow = "false";
        //LogPath = "/Users/kevmccarthy/Projects/Liberator/java/src/test/resources/logs";
        SuppressInitialDiagnosticInformation = "false";

        // Mobile Emulation Pre-Sets
        EnableTouchEvents = "false";
        Height = "";
        PixelRatio = "3";
        UserAgent = "";
        Width = "";
    }
}
