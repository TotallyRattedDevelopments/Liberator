package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.openqa.selenium.Proxy;
import org.openqa.selenium.WebDriver;

public abstract class BrowserControl {


    Proxy proxy;

    /**
     * Starts a web driver
     * @return A web driver instance
     */
    public abstract WebDriver startDriver();


    /**
     * Starts a web driver
     * @param driverSettings Preference injection object
     * @return A web driver instance
     */
    public abstract WebDriver startDriver(BasePreferences driverSettings);
}
