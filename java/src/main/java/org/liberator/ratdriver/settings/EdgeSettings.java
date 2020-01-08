package org.liberator.ratdriver.settings;

public class EdgeSettings extends BaseSettings {

    public EdgeSettings()
    {
        HideCommandPromptWindow = "False";
        Port = "4444";
        SuppressInitialDiagnosticInformation = "False";
        UseVerboseLogging = "True";
    }

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public static String HideCommandPromptWindow = null;

    /**
     * Gets or sets the port of the service.
     */
    public static String Port = null;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is
     * suppressed when starting the driver server executable. Defaults to false, meaning
     * diagnostic information should be shown by the driver server executable.
     */
    public static String SuppressInitialDiagnosticInformation = null;

    /**
     * Gets or sets a value indicating whether to enable verbose logging for the ChromeDriver executable. Defaults to false.
     */
    public static String UseVerboseLogging = null;

    /**
     * Gets or sets the value of the host adapter on which the Edge driver service should listen for connections
     */
    public static String Host = null;

    /**
     * Gets or sets the value of the package the Edge driver service will launch and automate.
     */
    public static String Package = null;
}
