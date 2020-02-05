package org.liberator.ratdriver.settings;

import com.sun.javafx.PlatformUtil;
import org.openqa.selenium.PageLoadStrategy;
import org.openqa.selenium.UnexpectedAlertBehaviour;
import org.openqa.selenium.firefox.FirefoxDriverLogLevel;

import static org.openqa.selenium.PageLoadStrategy.*;
import static org.openqa.selenium.UnexpectedAlertBehaviour.*;

public class FirefoxSettings extends BaseSettings {

    /**
     * Gets or sets the logging level of the Firefox driver.
     */
    public static FirefoxDriverLogLevel LogLevel;


    /**
     * Gets the directory containing the profile.
     */
    public static String ProfileDirectory;

    /**
     * Cleans this Firefox profile.
     */
    public static Boolean CleanProfile;

    /**
     * Gets or sets a value indicating whether to use the legacy driver implementation.
     */
    public static Boolean UseLegacyImplementation;

    /**
     * Gets or sets a value indicating whether Firefox should accept SSL certificates
     * which have expired, signed by an unknown authority or are generally untrusted.
     * Set to true by default.
     */
    public static Boolean AcceptUntrustedCertificates;

    /**
     * Gets or sets a value indicating whether to always load the library for allowing
     * Firefox to execute commands without its window having focus.
     */
    public static Boolean AlwaysLoadNoFocusLibrary;

    /**
     * Gets or sets a value indicating whether Firefox assume untrusted SSL certificates
     * come from an untrusted issuer or are self-signed. Set to true by default.
     */
    public static Boolean AssumeUntrustedCertificateIssuer;

    /**
     * Gets or sets a value indicating whether to delete this profile after use with the OpenQA.Selenium.Firefox.FirefoxDriver.
     */
    public static Boolean DeleteAfterUse;

    /**
     * Gets or sets a value indicating whether native events are enabled.
     */
    public static Boolean EnableNativeEvents;

    /**
     * Gets or sets the port on which the profile connects to the WebDriver extension.
     */
    public static String Port;

    /**
     * Comma separated list of proxy preferences in the format {name}={value}|{type}
     */
    public static String ProxyPreferences;

    /**
     * Gets or sets the port used by the driver executable to communicate with the browser.
     */
    public static String CommunicationPort;

    /**
     * Gets or sets a value indicating whether to connect to an already-running instance of Firefox.
     */
    public static String ConnectToRunningBrowser;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public static String HideCommandPromptWindow;

    /**
     * Gets or sets the value of the IP address of the host adapter on which the service should listen for connections.
     */
    public static String Host;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public static String SuppressInitialDiagnosticInformation;

    /**
     * Comma separated list of preferences in the format {name}={value}|{type}
     */
    public static String Preferences;


    public static PageLoadStrategy PageLoadStrategy;


    public static UnexpectedAlertBehaviour UnexpectedAlertBehaviour;


    static
    {
        LogLevel = FirefoxDriverLogLevel.INFO;
        ProfileDirectory = null;
        CleanProfile = null;
        UseLegacyImplementation = true;

        AcceptUntrustedCertificates = true;
        AlwaysLoadNoFocusLibrary = true;
        AssumeUntrustedCertificateIssuer = true;
        DeleteAfterUse = null;
        EnableNativeEvents = null;
        Port = "4444";

        ConnectToRunningBrowser = null;
        HideCommandPromptWindow = null;
        SuppressInitialDiagnosticInformation = null;

        UnexpectedAlertBehaviour = ACCEPT;
        PageLoadStrategy = EAGER;
    }
}
