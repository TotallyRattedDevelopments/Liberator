package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.FirefoxPreferences;
import org.liberator.ratdriver.settings.FirefoxSettings;
import org.openqa.selenium.Proxy;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxOptions;
import org.openqa.selenium.firefox.FirefoxProfile;
import org.openqa.selenium.firefox.GeckoDriverService;

public class FirefoxControl extends BrowserControl {
    
    //region Public Properties

    /**
     * The path to the Firefox binary
     */
    public String BinaryPath = null;

    /**
     * The maximum time to wait for the browser to load
     */
    public Integer BrowserLoadTimeout = null;

    /**
     * The maximum amount of time to wait between commands
     */
    public Integer CommandTimeout = null;

    /**
     * The Firefox binary
     */
    public org.openqa.selenium.firefox.FirefoxBinary FirefoxBinary = null;

    /**
     * Holds a firefox profile
     */
    public FirefoxProfile Profile = null;

    /**
     * Holds the preset values for Firefox Options
     */
    public FirefoxOptions Options = null;

    /**
     * The Firefox driver service
     */
    public GeckoDriverService Service = null;

    /**
     * Holds the proxy settings for connection to the Firefox driver
     */
    public Proxy ProxySettings = null;

    /**
     * WebDriver
     */
    public WebDriver Driver = null;

        //endregion

        //region Constructor


    /**
     * Default constructor
     */
    public FirefoxControl()
    {
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="firefoxPreferences"></param>

    /**
     * Allows the specification of Firefox Driver preferences
     * @param firefoxPreferences The preferences file to be used.
     */
    public FirefoxControl(FirefoxPreferences firefoxPreferences)
    {
        if (firefoxPreferences != null)
        {
            FirefoxSettings.AcceptUntrustedCertificates = firefoxPreferences.AcceptUntrustedCertificates;
            FirefoxSettings.AlwaysLoadNoFocusLibrary = firefoxPreferences.AlwaysLoadNoFocusLibrary;
            FirefoxSettings.AssumeUntrustedCertificateIssuer = firefoxPreferences.AssumeUntrustedCertificateIssuer;
            FirefoxSettings.CleanProfile = firefoxPreferences.CleanProfile;
            FirefoxSettings.CommunicationPort = firefoxPreferences.ConnectToRunningBrowser;
            FirefoxSettings.ConnectToRunningBrowser = firefoxPreferences.ConnectToRunningBrowser;
            FirefoxSettings.DeleteAfterUse = firefoxPreferences.DeleteAfterUse;
            FirefoxSettings.EnableNativeEvents = firefoxPreferences.EnableNativeEvents;
            FirefoxSettings.HideCommandPromptWindow = firefoxPreferences.HideCommandPromptWindow;
            FirefoxSettings.Host = firefoxPreferences.Host;
            FirefoxSettings.LogLevel = firefoxPreferences.LogLevel;
            FirefoxSettings.Port = firefoxPreferences.Port;
            FirefoxSettings.Preferences = firefoxPreferences.Preferences;
            FirefoxSettings.ProfileDirectory = firefoxPreferences.ProfileDirectory;
            FirefoxSettings.ProxyPreferences = firefoxPreferences.ProxyPreferences;
            FirefoxSettings.SuppressInitialDiagnosticInformation = firefoxPreferences.SuppressInitialDiagnosticInformation;
            FirefoxSettings.UseLegacyImplementation = firefoxPreferences.UseLegacyImplementation;
        }
    }

        //endregion
    
    
    /**
     * Starts a web driver
     *
     * @return A web driver instance
     */
    @Override
    public WebDriver StartDriver() {
        return null;
    }

    /**
     * Starts a web driver
     *
     * @param driverSettings Preference injection object
     * @return A web driver instance
     */
    @Override
    public WebDriver StartDriver(BasePreferences driverSettings) {
        return null;
    }
}
