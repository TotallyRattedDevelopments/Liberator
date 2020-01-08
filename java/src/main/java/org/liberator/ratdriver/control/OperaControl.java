package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.OperaPreferences;
import org.liberator.ratdriver.settings.OperaSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.opera.OperaDriverService;
import org.openqa.selenium.opera.OperaOptions;

public class OperaControl extends BrowserControl {

    //region Public Properties

    /**
     * Holds the preset values for Opera Options
     */
    public OperaOptions Options = null;

    /**
     * The Internet Explorer driver service
     */
    public OperaDriverService Service = null;

    /**
     * Holds the instantiated Opera Driver
     */
    public WebDriver Driver = null;

    /**
     * The maximum amount of time to wait between commands
     */
    public Integer CommandTimeout = null;

    //endregion

    //region Constructor

    /**
     *
     */
    public OperaControl() {

    }

    /// <summary>
    /// Allows the specification of Opera Driver settings
    /// </summary>
    /// <param name="operaSettings">The settings file to be used.</param>
    public OperaControl(OperaPreferences operaPreferences) {
        if (operaPreferences != null) {
            OperaSettings.AndroidDebugBridgePort = operaPreferences.AndroidDebugBridgePort;
            OperaSettings.DebuggerAddress = operaPreferences.DebuggerAddress;
            OperaSettings.EnableVerboseLogging = operaPreferences.EnableVerboseLogging;
            OperaSettings.HideCommandPromptWindow = operaPreferences.HideCommandPromptWindow;
            OperaSettings.LeaveBrowserRunning = operaPreferences.LeaveBrowserRunning;
            OperaSettings.LogPath = operaPreferences.LogPath;
            OperaSettings.MinidumpPath = operaPreferences.MinidumpPath;
            OperaSettings.Port = operaPreferences.Port;
            OperaSettings.PortServerAddress = operaPreferences.PortServerAddress;
            OperaSettings.SuppressInitialDiagnosticInformation = operaPreferences.SuppressInitialDiagnosticInformation;
            OperaSettings.UrlPathPrefix = operaPreferences.UrlPathPrefix;
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
