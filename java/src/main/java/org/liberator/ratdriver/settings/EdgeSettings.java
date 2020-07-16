package org.liberator.ratdriver.settings;

import org.openqa.selenium.PageLoadStrategy;

@SuppressWarnings("unused")
public class EdgeSettings extends BaseSettings {

    public EdgeSettings()
    {
        HideCommandPromptWindow = null;
        Port = 4444;
        SuppressInitialDiagnosticInformation = null;
        UseVerboseLogging = null;
    }

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public static Boolean HideCommandPromptWindow;

    /**
     * Gets or sets the port of the service.
     */
    public static Integer Port;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public static Boolean SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
     */
    public static Boolean UseVerboseLogging;

    /**
     * Gets or sets the value of the host adapter on which the Edge driver service should listen for connections
     */
    public static String Host;

    /**
     * Gets or sets the value of the package the Edge driver service will launch and automate.
     */
    public static String Package;

    public static PageLoadStrategy PageLoadStrategy;

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
