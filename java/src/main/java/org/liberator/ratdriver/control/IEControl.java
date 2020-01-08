package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.IEPreferences;
import org.liberator.ratdriver.settings.IESettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.ie.InternetExplorerDriverService;
import org.openqa.selenium.ie.InternetExplorerOptions;

public class IEControl extends BrowserControl {

//region Public Properties

    /**
     * Holds the preset values for Internet Explorer Options
     */
    public InternetExplorerOptions Options = null;

    /**
     * The Internet Explorer driver service
     */
    public InternetExplorerDriverService Service = null;

    /**
     * Holds the instantiated Internet Explorer Driver
     */
    public WebDriver Driver = null;


    /**
     * The maximum sleep interval
     */
    public Integer SleepInterval = null;

    /**
     * The maximum time to wait for the browser to load
     */
    public Integer BrowserTimeout = null;

    /**
     * The maximum amount of time to wait between commands
     */
    public Integer CommandTimeout = null;

    //endregion

    //region Constructor


    /**
     *
     */
    public IEControl() {
    }


    /**
     * Allows the specification of Internet Explorer Driver settings
     * @param iePreferences The settings file to be used.
     */
    public IEControl(IEPreferences iePreferences) {

        if (iePreferences != null) {
            IESettings.CommandLineArguments = iePreferences.CommandLineArguments;
            IESettings.EnableFullPageScreenshot = iePreferences.EnableFullPageScreenshot;
            IESettings.EnableNativeEvents = iePreferences.EnableNativeEvents;
            IESettings.EnablePersistentHover = iePreferences.EnablePersistentHover;
            IESettings.EnsureCleanSession = iePreferences.EnsureCleanSession;
            IESettings.FileUploadTimeout = iePreferences.FileUploadTimeout;
            IESettings.ForceCreateProcessApi = iePreferences.ForceCreateProcessApi;
            IESettings.ForceShellWindowsApi = iePreferences.ForceShellWindowsApi;
            IESettings.FtpProxy = iePreferences.FtpProxy;
            IESettings.HideCommandPromptWindow = iePreferences.HideCommandPromptWindow;
            IESettings.Host = iePreferences.Host;
            IESettings.HttpProxy = iePreferences.HttpProxy;
            IESettings.IgnoreZoomLevel = iePreferences.IgnoreZoomLevel;
            IESettings.InitialBrowserUrl = iePreferences.InitialBrowserUrl;
            IESettings.IntroduceInstability = iePreferences.IntroduceInstability;
            IESettings.IsAutoDetect = iePreferences.IsAutoDetect;
            IESettings.LibraryExtractionPath = iePreferences.LibraryExtractionPath;
            IESettings.LogFile = iePreferences.LogFile;
            IESettings.LoggingLevel = iePreferences.LoggingLevel;
            IESettings.NoProxy = iePreferences.NoProxy;
            IESettings.PageLoadStrategy = iePreferences.PageLoadStrategy;
            IESettings.Port = iePreferences.Port;
            IESettings.ProxyAutoConfigUrl = iePreferences.ProxyAutoConfigUrl;
            IESettings.ProxyKind = iePreferences.ProxyKind;
            IESettings.RequireWindowFocus = iePreferences.RequireWindowFocus;
            IESettings.ScrollBehavior = iePreferences.ScrollBehavior;
            IESettings.SocksPassword = iePreferences.SocksPassword;
            IESettings.SocksProxy = iePreferences.SocksProxy;
            IESettings.SocksUserName = iePreferences.SocksUserName;
            IESettings.SslProxy = iePreferences.SslProxy;
            IESettings.SuppressInitialDiagnosticInformation = iePreferences.SuppressInitialDiagnosticInformation;
            IESettings.UnexpectedAlertBehavior = iePreferences.UnexpectedAlertBehavior;
            IESettings.UsePerProcessProxy = iePreferences.UsePerProcessProxy;
            IESettings.WhitelistedIPAddresses = iePreferences.WhitelistedIPAddresses;
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
