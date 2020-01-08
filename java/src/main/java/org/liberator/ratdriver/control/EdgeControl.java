package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.EdgePreferences;
import org.liberator.ratdriver.settings.EdgeSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.edge.EdgeDriverService;
import org.openqa.selenium.edge.EdgeOptions;

public class EdgeControl extends BrowserControl {

    //region Public Properties

    /// <summary>
    /// Holds the instantiated Edge Driver
    /// </summary>
    public WebDriver Driver = null;

    /// <summary>
    /// Holds the preset values for Edge Options
    /// </summary>
    private EdgeOptions Options;

    /// <summary>
    /// The Edge driver service
    /// </summary>
    public EdgeDriverService Service = null;

    //endregion


    //region Constructors

    /// <summary>
    /// Loads preset values for the driver and service from the app.config file
    /// </summary>
    public EdgeControl() {
        Options = new EdgeOptions();
    }

    /// <summary>
    /// Allows the specification of Edge Driver settings
    /// </summary>
    /// <param name="edgeSettings">The settings file to be used.</param>
    public EdgeControl(EdgePreferences edgePreferences) {
        Options = new EdgeOptions();

        if (edgePreferences != null) {
            EdgeSettings.HideCommandPromptWindow = edgePreferences.HideCommandPromptWindow;
            EdgeSettings.Host = edgePreferences.Host;
            EdgeSettings.Package = edgePreferences.Package;
            EdgeSettings.Port = edgePreferences.Port;
            EdgeSettings.SuppressInitialDiagnosticInformation = edgePreferences.SuppressInitialDiagnosticInformation;
            EdgeSettings.UseVerboseLogging = edgePreferences.UseVerboseLogging;
        }
    }

    //endregion

    //region Public Methods

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

    //endregion
}
