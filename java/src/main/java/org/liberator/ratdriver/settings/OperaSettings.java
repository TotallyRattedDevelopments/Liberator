package org.liberator.ratdriver.settings;

public class OperaSettings extends BaseSettings {

        public OperaSettings()
        {
            LeaveBrowserRunning = "false";
            AndroidDebugBridgePort = "-1";
            EnableVerboseLogging = "false";
            HideCommandPromptWindow = "true";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "true";
        }

        /**
         * Gets or sets the address of a Opera debugger server to connect to. Should be of the form "{hostname|IP address}:port".
         */
        public static String DebuggerAddress = null;

        /**
         * Gets or sets a value indicating whether Opera should be left running after the OperaDriver instance is exited. Defaults to false.
         */
        public static String LeaveBrowserRunning = null;

        /**
         * Gets or sets the directory in which to store minidump files.
         */
        public static String MinidumpPath = null;

        /**
         * Gets or sets the port on which the Android Debug Bridge is listening for commands.
         */
        public static String AndroidDebugBridgePort = null;

        /**
         * Gets or sets a value indicating whether to enable verbose logging for the OperaDriver executable. Defaults to false.
         */
        public static String EnableVerboseLogging = null;

        /**
         * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
         */
        public static String HideCommandPromptWindow = null;

        /**
         * Gets or sets the location of the log file written to by the OperaDriver executable.
         */
        public static String LogPath = null;

        /**
         * Gets or sets the port of the service.
         */
        public static String Port = null;

        /**
         * Gets or sets the address of a server to contact for reserving a port.
         */
        public static String PortServerAddress = null;

        /**
         * Gets or sets a value indicating whether the initial diagnostic information is
         * suppressed when starting the driver server executable. Defaults to false, meaning
         * diagnostic information should be shown by the driver server executable.
         */
        public static String SuppressInitialDiagnosticInformation = null;

        /**
         * Gets or sets the base URL path prefix for commands (e.g., "wd/url").
         */
        public static String UrlPathPrefix = null;
}
