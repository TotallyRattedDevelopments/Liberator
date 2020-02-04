package org.liberator.ratdriver.preferences;

import org.openqa.selenium.PageLoadStrategy;

public class EdgePreferences extends BasePreferences{

    public EdgePreferences() {
        HideCommandPromptWindow = null;
        Port = null;
        SuppressInitialDiagnosticInformation = null;
        UseVerboseLogging = null;
    }

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public Boolean HideCommandPromptWindow;

    /**
     * Gets or sets the port of the service.
     */
    public Integer Port;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public Boolean SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
     */
    public Boolean UseVerboseLogging;

    /**
     * Gets or sets the value of the host adapter on which the Edge driver service should listen for connections
     */
    public String Host = null;

    /**
     * Gets or sets the value of the package the Edge driver service will launch and automate.
     */
    public String Package = null;

    public PageLoadStrategy PageLoadStrategy = org.openqa.selenium.PageLoadStrategy.NORMAL;

    /**
     * Whether to accept insecure certificates
     */
    public static Boolean AcceptInsecureCertificates;

    /**
     * Whether to accept SSL certificates
     */
    public static Boolean AcceptSSLCertificates;

    /**
     * Whether the driver should take screenshots
     */
    public static Boolean TakesScreenshot;

    /**
     * The unexpected alert behaviour
     */
    public static String UnexpectedAlertBehaviour;

    /**
     * The unhandled prompt behaviour
     */
    public static String UnhandledPromptBehaviour;
}
