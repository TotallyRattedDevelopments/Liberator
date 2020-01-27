package org.liberator.ratdriver.preferences;

import com.sun.javafx.PlatformUtil;
import org.openqa.selenium.PageLoadStrategy;
import org.openqa.selenium.UnexpectedAlertBehaviour;
import org.openqa.selenium.firefox.FirefoxDriverLogLevel;

import static org.openqa.selenium.PageLoadStrategy.*;
import static org.openqa.selenium.UnexpectedAlertBehaviour.*;

public class FirefoxPreferences extends BasePreferences {
    
    public FirefoxPreferences()
    {
        if (PlatformUtil.isMac()) {
            FirefoxDriverLocation = "src/main/resources/drivers/mac/geckodriver";
            FirefoxLocation = "/Applications/Firefox.app";
        } else if (PlatformUtil.isWindows()) {
            FirefoxDriverLocation = "src/main/resources/drivers/win/geckodriver.exe";
            FirefoxLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\firefox.exe";
        } else if (PlatformUtil.isLinux()){
            FirefoxDriverLocation = "/usr/local/bin/geckodriver";
            FirefoxLocation = "usr/bin/firefox";
        }

        LogLevel = FirefoxDriverLogLevel.DEBUG;
        ProfileDirectory = "\\BrowserDrivers\\Profiles";
        CleanProfile = false;
        UseLegacyImplementation = false;

        AcceptUntrustedCertificates = null;
        AlwaysLoadNoFocusLibrary = null;
        AssumeUntrustedCertificateIssuer = null;
        DeleteAfterUse = false;
        EnableNativeEvents = false;
        Port = "4444";

        ConnectToRunningBrowser = "False";
        HideCommandPromptWindow = "False";
        SuppressInitialDiagnosticInformation = "False";

        PageLoadStrategy = EAGER;
        UnexpectedAlertBehaviour = ACCEPT;
    }

    /**
     * Gets or sets the logging level of the Firefox driver.
     */
    public FirefoxDriverLogLevel LogLevel;

    /**
     * Gets the directory containing the profile.
     */
    public String ProfileDirectory;

    /**
     * Cleans this Firefox profile.
     */
    public Boolean CleanProfile;

    /**
     * Gets or sets a value indicating whether to use the legacy driver implementation.
     */
    public Boolean UseLegacyImplementation;

    /**
     * Gets or sets a value indicating whether Firefox should accept SSL certificates
     * which have expired, signed by an unknown authority or are generally untrusted.
     * Set to true by default.
     */
    public Boolean AcceptUntrustedCertificates;

    /**
     * Gets or sets a value indicating whether to always load the library for allowing
     * Firefox to execute commands without its window having focus.
     */
    public Boolean AlwaysLoadNoFocusLibrary;

    /**
     * Gets or sets a value indicating whether Firefox assume untrusted SSL certificates
     * come from an untrusted issuer or are self-signed. Set to true by default.
     */
    public Boolean AssumeUntrustedCertificateIssuer;

    /**
     * Gets or sets a value indicating whether to delete this profile after use with the OpenQA.Selenium.Firefox.FirefoxDriver.
     */
    public Boolean DeleteAfterUse;

    /**
     * Gets or sets a value indicating whether native events are enabled.
     */
    public Boolean EnableNativeEvents;

    /**
     * Gets or sets the port on which the profile connects to the WebDriver extension.
     */
    public String Port;

    /**
     * Comma separated list of proxy preferences in the format {name}={value}|{type}
     */
    public String ProxyPreferences = null;

    /**
     * Gets or sets the port used by the driver executable to communicate with the browser.
     */
    public String CommunicationPort = null;

    /**
     * Gets or sets a value indicating whether to connect to an already-running instance of Firefox.
     */
    public String ConnectToRunningBrowser;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public String HideCommandPromptWindow;

    /**
     * Gets or sets the value of the IP address of the host adapter on which the service should listen for connections.
     */
    public String Host = null;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public String SuppressInitialDiagnosticInformation;

    /**
     * Comma separated list of preferences in the format {name}={value}|{type}
     */
    public String Preferences = null;


    public PageLoadStrategy PageLoadStrategy;

    public UnexpectedAlertBehaviour UnexpectedAlertBehaviour = null;
}
