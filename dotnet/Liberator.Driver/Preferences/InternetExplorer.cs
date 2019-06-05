using System;

namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Preferences for Internet Explorer Driver Server
    /// </summary>
    public static class InternetExplorer
    {
        static InternetExplorer()
        {
            EnableFullPageScreenshot = "True";
            EnableNativeEvents = "True";
            EnablePersistentHover = "True";
            EnsureCleanSession = "False";
            ForceCreateProcessApi = "False";
            ForceShellWindowsApi = "False";
            IgnoreZoomLevel = "True";
            InitialBrowserUrl = "http://www.totallyratted.com";
            IntroduceInstability = "True";
            PageLoadStrategy = "Eager";
            RequireWindowFocus = "False";
            UnexpectedAlertBehavior = "Default";
            UsePerProcessProxy = "False";

            HideCommandPromptWindow = "True";
            LoggingLevel = "Debug";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "False";
            IsAutoDetect = "False";

            FileUploadTimeout = new TimeSpan(0, 0, 0, 30, 0);
        }

        /// <summary>
        /// Gets or sets the command line arguments used in launching Internet Explorer when the Windows CreateProcess API is used. This property only has an effect when the OpenQA.Selenium.IE.InternetExplorerOptions.ForceCreateProcessApi is true.
        /// </summary>
        public static string CommandLineArguments { get; set; }

        /// <summary>
        /// Gets or sets the value for describing how elements are scrolled into view in the IE driver. Defaults to scrolling the element to the top of the viewport.
        /// </summary>
        public static string ScrollBehavior { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string EnableFullPageScreenshot { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use native events in interacting with elements.
        /// </summary>
        public static string EnableNativeEvents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable persistently sending WM_MOUSEMOVE messages to the IE window during a mouse hover.
        /// </summary>
        public static string EnablePersistentHover { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear the Internet Explorer cache before launching the browser. When set to true, clears the system cache for all instances of Internet Explorer, even those already running when the driven instance is launched. Defaults to false.
        /// </summary>
        public static string EnsureCleanSession { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force the use of the Windows CreateProcess API when launching Internet Explorer. The default value is false.
        /// </summary>
        public static string ForceCreateProcessApi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force the use of the Windows ShellWindows API when attaching to Internet Explorer. The default value is false.
        /// </summary>
        public static string ForceShellWindowsApi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore the zoom level of Internet Explorer .
        /// </summary>
        public static string IgnoreZoomLevel { get; set; }

        /// <summary>
        /// Gets or sets the initial URL displayed when IE is launched. If not set, the browser launches with the internal startup page for the WebDriver server.
        /// </summary>
        public static string InitialBrowserUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore the settings of the Internet Explorer Protected Mode.
        /// </summary>
        public static string IntroduceInstability { get; set; }

        /// <summary>
        /// Gets or sets the value for describing how the browser is to wait for pages to load in the browser. Defaults to OpenQA.Selenium.PageLoadStrategy.Default.
        /// </summary>
        public static string PageLoadStrategy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to require the browser window to have focus before interacting with elements.
        /// </summary>
        public static string RequireWindowFocus { get; set; }

        /// <summary>
        /// Gets or sets the value for describing how unexpected alerts are to be handled in the browser. Defaults to OpenQA.Selenium.UnhandledPromptBehavior.Default.
        /// </summary>
        public static string UnexpectedAlertBehavior { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the supplied OpenQA.Selenium.Proxy settings on a per-process basis, not updating the system installed proxy setting. This property is only valid when setting a OpenQA.Selenium.Proxy, where the OpenQA.Selenium.Proxy.Kind property is either OpenQA.Selenium.ProxyKind.Direct, OpenQA.Selenium.ProxyKind.System, or OpenQA.Selenium.ProxyKind.Manual, and is otherwise ignored. Defaults to false.
        /// </summary>
        public static string UsePerProcessProxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public static string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the value of the host adapter on which the IEDriverServer should listen for connections.
        /// </summary>
        public static string Host { get; set; }

        /// <summary>
        /// Gets or sets the path to which the supporting library of the IEDriverServer.exe is extracted. Defaults to the temp directory if this property is not set.
        /// </summary>
        public static string LibraryExtractionPath { get; set; }

        /// <summary>
        /// Gets or sets the location of the log file written to by the IEDriverServer.
        /// </summary>
        public static string LogFile { get; set; }

        /// <summary>
        /// Gets or sets the logging level used by the IEDriverServer.
        /// </summary>
        public static string LoggingLevel { get; set; }

        /// <summary>
        /// Gets or sets the port of the service.
        /// </summary>
        public static string Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is suppressed when starting the driver server executable. Defaults to false, meaning diagnostic information should be shown by the driver server executable.
        /// </summary>
        public static string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Gets or sets the comma-delimited list of IP addresses that are approved to connect to this instance of the IEDriverServer. Defaults to an empty string, which means only the local loopback address can connect.
        /// </summary>
        public static string WhitelistedIPAddresses { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the FTP protocol.
        /// </summary>
        public static string FtpProxy { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the HTTP protocol.
        /// </summary>
        public static string HttpProxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the proxy uses automatic detection.
        /// </summary>
        public static string IsAutoDetect { get; set; }

        /// <summary>
        /// Gets or sets the type of proxy.
        /// </summary>
        public static string ProxyKind { get; set; }

        /// <summary>
        /// Gets or sets the value for bypass proxy addresses.
        /// </summary>
        public static string NoProxy { get; set; }

        /// <summary>
        /// Gets or sets the URL used for proxy automatic configuration.
        /// </summary>
        public static string ProxyAutoConfigUrl { get; set; }

        /// <summary>
        /// Gets or sets the value of password for the SOCKS proxy.
        /// </summary>
        public static string SocksPassword { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the SOCKS protocol.
        /// </summary>
        public static string SocksProxy { get; set; }

        /// <summary>
        /// Gets or sets the value of username for the SOCKS proxy.
        /// </summary>
        public static string SocksUserName { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the SSL protocol.
        /// </summary>
        public static string SslProxy { get; set; }

        /// <summary>
        /// Gets or sets the amount of time the driver will attempt to look for the file selection dialog when attempting to upload a file.
        /// </summary>
        public static TimeSpan FileUploadTimeout { get; set; }
    }

    /// <summary>
    /// Settings file for dependency injection
    /// </summary>
    public class InternetExplorerSettings : BasePreferences
    {
        /// <summary>
        /// Contructor with default settings
        /// </summary>
        public InternetExplorerSettings()
        {
            EnableFullPageScreenshot = "True";
            EnableNativeEvents = "True";
            EnablePersistentHover = "True";
            EnsureCleanSession = "False";
            ForceCreateProcessApi = "False";
            ForceShellWindowsApi = "False";
            IgnoreZoomLevel = "True";
            InitialBrowserUrl = "http://www.totallyratted.com";
            IntroduceInstability = "True";
            PageLoadStrategy = "Eager";
            RequireWindowFocus = "False";
            UnexpectedAlertBehavior = "Default";
            UsePerProcessProxy = "False";

            HideCommandPromptWindow = "True";
            LoggingLevel = "Debug";
            Port = "4444";
            SuppressInitialDiagnosticInformation = "False";
            IsAutoDetect = "False";

            FileUploadTimeout = new TimeSpan(0, 0, 0, 30, 0);
        }

        /// <summary>
        /// Gets or sets the command line arguments used in launching Internet Explorer when the Windows CreateProcess API is used. This property only has an effect when the OpenQA.Selenium.IE.InternetExplorerOptions.ForceCreateProcessApi is true.
        /// </summary>
        public string CommandLineArguments { get; set; }

        /// <summary>
        /// Gets or sets the value for describing how elements are scrolled into view in the IE driver. Defaults to scrolling the element to the top of the viewport.
        /// </summary>
        public string ScrollBehavior { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EnableFullPageScreenshot { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use native events in interacting with elements.
        /// </summary>
        public string EnableNativeEvents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable persistently sending WM_MOUSEMOVE messages to the IE window during a mouse hover.
        /// </summary>
        public string EnablePersistentHover { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear the Internet Explorer cache before launching the browser. When set to true, clears the system cache for all instances of Internet Explorer, even those already running when the driven instance is launched. Defaults to false.
        /// </summary>
        public string EnsureCleanSession { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force the use of the Windows CreateProcess API when launching Internet Explorer. The default value is false.
        /// </summary>
        public string ForceCreateProcessApi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force the use of the Windows ShellWindows API when attaching to Internet Explorer. The default value is false.
        /// </summary>
        public string ForceShellWindowsApi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore the zoom level of Internet Explorer .
        /// </summary>
        public string IgnoreZoomLevel { get; set; }

        /// <summary>
        /// Gets or sets the initial URL displayed when IE is launched. If not set, the browser launches with the internal startup page for the WebDriver server.
        /// </summary>
        public string InitialBrowserUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore the settings of the Internet Explorer Protected Mode.
        /// </summary>
        public string IntroduceInstability { get; set; }

        /// <summary>
        /// Gets or sets the value for describing how the browser is to wait for pages to load in the browser. Defaults to OpenQA.Selenium.PageLoadStrategy.Default.
        /// </summary>
        public string PageLoadStrategy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to require the browser window to have focus before interacting with elements.
        /// </summary>
        public string RequireWindowFocus { get; set; }

        /// <summary>
        /// Gets or sets the value for describing how unexpected alerts are to be handled in the browser. Defaults to OpenQA.Selenium.UnhandledPromptBehavior.Default.
        /// </summary>
        public string UnexpectedAlertBehavior { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the supplied OpenQA.Selenium.Proxy settings on a per-process basis, not updating the system installed proxy setting. This property is only valid when setting a OpenQA.Selenium.Proxy, where the OpenQA.Selenium.Proxy.Kind property is either OpenQA.Selenium.ProxyKind.Direct, OpenQA.Selenium.ProxyKind.System, or OpenQA.Selenium.ProxyKind.Manual, and is otherwise ignored. Defaults to false.
        /// </summary>
        public string UsePerProcessProxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command prompt window of the service should be hidden.
        /// </summary>
        public string HideCommandPromptWindow { get; set; }

        /// <summary>
        /// Gets or sets the value of the host adapter on which the IEDriverServer should listen for connections.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the path to which the supporting library of the IEDriverServer.exe is extracted. Defaults to the temp directory if this property is not set.
        /// </summary>
        public string LibraryExtractionPath { get; set; }

        /// <summary>
        /// Gets or sets the location of the log file written to by the IEDriverServer.
        /// </summary>
        public string LogFile { get; set; }

        /// <summary>
        /// Gets or sets the logging level used by the IEDriverServer.
        /// </summary>
        public string LoggingLevel { get; set; }

        /// <summary>
        /// Gets or sets the port of the service.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial diagnostic information is suppressed when starting the driver server executable. Defaults to false, meaning diagnostic information should be shown by the driver server executable.
        /// </summary>
        public string SuppressInitialDiagnosticInformation { get; set; }

        /// <summary>
        /// Gets or sets the comma-delimited list of IP addresses that are approved to connect to this instance of the IEDriverServer. Defaults to an empty string, which means only the local loopback address can connect.
        /// </summary>
        public string WhitelistedIPAddresses { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the FTP protocol.
        /// </summary>
        public string FtpProxy { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the HTTP protocol.
        /// </summary>
        public string HttpProxy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the proxy uses automatic detection.
        /// </summary>
        public string IsAutoDetect { get; set; }

        /// <summary>
        /// Gets or sets the type of proxy.
        /// </summary>
        public string ProxyKind { get; set; }

        /// <summary>
        /// Gets or sets the value for bypass proxy addresses.
        /// </summary>
        public string NoProxy { get; set; }

        /// <summary>
        /// Gets or sets the URL used for proxy automatic configuration.
        /// </summary>
        public string ProxyAutoConfigUrl { get; set; }

        /// <summary>
        /// Gets or sets the value of password for the SOCKS proxy.
        /// </summary>
        public string SocksPassword { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the SOCKS protocol.
        /// </summary>
        public string SocksProxy { get; set; }

        /// <summary>
        /// Gets or sets the value of username for the SOCKS proxy.
        /// </summary>
        public string SocksUserName { get; set; }

        /// <summary>
        /// Gets or sets the value of the proxy for the SSL protocol.
        /// </summary>
        public string SslProxy { get; set; }

        /// <summary>
        /// Gets or sets the amount of time the driver will attempt to look for the file selection dialog when attempting to upload a file.
        /// </summary>
        public TimeSpan FileUploadTimeout { get; set; }
    }
}
