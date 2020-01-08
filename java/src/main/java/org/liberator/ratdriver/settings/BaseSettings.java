package org.liberator.ratdriver.settings;

import org.liberator.ratdriver.enums.ConsoleDebugLevel;

/**
 * Base settings for RAT Driver
 */
public class BaseSettings {

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
    public static String ChromeDriverLocation = null;

    /**
     * Location of the Microsoft Web Driver. Defaults to the supplied version.
     */
    public static String EdgeDriverLocation = null;

    /**
     * Location of the Firefox Driver. Defaults to the supplied version.
     */
    public static String FirefoxDriverLocation = null;

    /**
     * Location of the IEDriverServer executable. Defaults to the supplied version.
     */
    public static String InternetExplorerDriverLocation = null;

    /**
     * Location of the Opera Driver. Defaults to the supplied version.
     */
    public static String OperaDriverLocation = null;

    /**
     * Location of the Chrome application
     */
    public static String ChromeLocation = null;

    /**
     * Locations of the Firefox application
     */
    public static String FirefoxLocation = null;

    /**
     * Location of the Opera application
     */
    public static String OperaLocation = null;

    /**
     * The debug level to use for the test run
     */
    public static ConsoleDebugLevel DebugLevel = null;
}
