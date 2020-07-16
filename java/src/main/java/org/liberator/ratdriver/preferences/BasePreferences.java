package org.liberator.ratdriver.preferences;

import org.liberator.ratdriver.enums.ConsoleDebugLevel;

/**
 * Injector for a base settings class
 */
@SuppressWarnings({"CanBeFinal", "unused"})
public abstract class BasePreferences {
    /**
     * Standard timeout
     */
    public Integer Timeout;

    /**
     * The length of time to sleep
     */
    public Integer Sleep;

    /**
     * Implicit wait value for WebDriver
     */
    public Integer ImplicitWait;

    /**
     * The amount of time to keep a hover active
     */
    public Integer MenuHoverTime;

    /**
     * Page Load wait time
     */
    public Integer PageLoad;

    /**
     * Asynchronous JavaScript wait time
     */
    public Integer AsyncJavaScript;

    /**
     * Whether to allow RatDriver to handle alerts
     */
    public Boolean AlertHandling;

    /**
     * Whether to use internal timers
     */
    public Boolean InternalTimers;

    /**
     * Location of Chrome Driver. Defaults to the supplied version.
     */
    public String ChromeDriverLocation;

    /**
     * Location of the Microsoft Web Driver. Defaults to the supplied version.
     */
    public String EdgeDriverLocation;

    /**
     * Location of the Firefox Driver. Defaults to the supplied version.
     */
    public String FirefoxDriverLocation;

    /**
     * Location of the IEDriverServer executable. Defaults to the supplied version.
     */
    public String InternetExplorerDriverLocation;

    /**
     * Location of the Opera Driver. Defaults to the supplied version.
     */
    public String OperaDriverLocation;

    /**
     * Location of the Chrome application
     */
    public String ChromeLocation;

    /**
     * Locations of the Firefox application
     */
    public String FirefoxLocation;

    /**
     * Location of the Opera application
     */
    public String OperaLocation;

    /**
     * The debug level to use for the test run
     */
    public ConsoleDebugLevel DebugLevel;

    public BasePreferences()
    {
        Timeout = 30;
        Sleep = 30;
        ImplicitWait = 30;
        MenuHoverTime = 30;
        PageLoad = 30;
        AsyncJavaScript = 30;

        AlertHandling = true;
        InternalTimers = true;

        DebugLevel = null;
    }
}
