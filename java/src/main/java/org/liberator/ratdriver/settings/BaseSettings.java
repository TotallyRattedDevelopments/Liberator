package org.liberator.ratdriver.settings;

import com.sun.javafx.PlatformUtil;
import javafx.application.Application;
import org.liberator.ratdriver.enums.ConsoleDebugLevel;

/**
 * Base settings for RAT Driver
 */
public class BaseSettings {

    static {

        // Driver Pre-sets
        if (PlatformUtil.isMac()) {
            ChromeDriverLocation = "src/main/resources/drivers/mac/chromedriver";
            FirefoxDriverLocation = "src/main/resources/drivers/mac/geckodriver";
            OperaDriverLocation = "src/main/resources/drivers/mac/operadriver";
            SafariDriverLocation = "/usr/bin/safaridriver";
            FirefoxLocation = "/Applications/Firefox.app/Contents/MacOS/firefox";
            OperaLocation = "/Applications/Opera.app/Contents/MacOS/Opera";
            SafariLocation = "/Applications/Safari.app";
        } else if (PlatformUtil.isWindows()) {
            ChromeDriverLocation = "src/main/resources/drivers/win/chromedriver.exe";
            FirefoxDriverLocation = "src/main/resources/drivers/win/geckodriver.exe";
            OperaDriverLocation = "src/main/resources/drivers/win/operadriver.exe";
            SafariDriverLocation = null;
            FirefoxLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\firefox.exe";
            SafariLocation = null;
        } else if (PlatformUtil.isLinux()){
            ChromeDriverLocation = "/usr/local/bin/chromedriver";
            FirefoxDriverLocation = "/usr/local/bin/geckodriver";
            OperaDriverLocation = "/usr/local/bin/operadriver";
            SafariDriverLocation = null;
            FirefoxLocation = "usr/bin/firefox";
            SafariLocation = null;
        }


    }
    /**
     * Standard timeout
     */
    public static Integer Timeout = 30;

    /**
     * The length of time to sleep
     */
    public static Integer Sleep = null;

    /**
     * Implicit wait value for WebDriver
     */
    public static Integer ImplicitWait = null;

    /**
     * The amount of time to keep a hover active
     */
    public static Integer MenuHoverTime = null;

    /**
     * Page Load wait time
     */
    public static Integer PageLoad = null;

    /**
     * Asynchronous JavaScript wait time
     */
    public static Integer AsyncJavaScript = null;

    /**
     * Whether to allow RatDriver to handle alerts
     */
    public static Boolean AlertHandling = null;

    /**
     * Whether to use internal timers
     */
    public static Boolean InternalTimers = null;

    /**
     * Location of Chrome Driver. Defaults to the supplied version.
     */
    public static String ChromeDriverLocation;

    /**
     * Location of the Microsoft Web Driver. Defaults to the supplied version.
     */
    public static String EdgeDriverLocation;

    /**
     * Location of the Firefox Driver. Defaults to the supplied version.
     */
    public static String FirefoxDriverLocation;

    /**
     * Location of the IEDriverServer executable. Defaults to the supplied version.
     */
    public static String InternetExplorerDriverLocation;

    /**
     * Location of the Opera Driver. Defaults to the supplied version.
     */
    public static String OperaDriverLocation;

    public static String SafariDriverLocation;

    /**
     * Location of the Chrome application
     */
    public static String ChromeLocation;

    /**
     * Locations of the Firefox application
     */
    public static String FirefoxLocation;

    /**
     * Location of the Opera application
     */
    public static String OperaLocation;

    public static String SafariLocation;

    /**
     * The debug level to use for the test run
     */
    public static ConsoleDebugLevel DebugLevel = null;
}
