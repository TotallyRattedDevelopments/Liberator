package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.openqa.selenium.WebDriver;

public abstract class BrowserControl {

    /**
     * Driver implementation under test
     */
    WebDriver Driver;

    /**
     * Starts a web driver
     * @return A web driver instance
     */
    public abstract WebDriver StartDriver();


    /**
     * Starts a web driver
     * @param driverSettings Preference injection object
     * @return A web driver instance
     */
    public abstract WebDriver StartDriver(BasePreferences driverSettings);
}
