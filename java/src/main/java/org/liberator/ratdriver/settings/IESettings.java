package org.liberator.ratdriver.settings;

import java.time.*;
import org.openqa.selenium.ie.ElementScrollBehavior;
import org.openqa.selenium.PageLoadStrategy;

import static org.openqa.selenium.PageLoadStrategy.EAGER;
import static org.openqa.selenium.UnexpectedAlertBehaviour.*;
import static org.openqa.selenium.ie.InternetExplorerDriverLogLevel.*;
import org.openqa.selenium.UnexpectedAlertBehaviour;
import org.openqa.selenium.ie.InternetExplorerDriverLogLevel;

@SuppressWarnings("unused")
public class IESettings extends BaseSettings {

    public IESettings() {
        EnableFullPageScreenshot = null;
        EnableNativeEvents = false;
        EnablePersistentHover = true;
        EnsureCleanSession = true;
        ForceCreateProcessApi = false;
        ForceShellWindowsApi = null;
        IgnoreZoomLevel = true;
        InitialBrowserUrl = "http://www.totallyratted.com";
        IntroduceInstability = false;
        PageLoadStrategy = EAGER;
        RequireWindowFocus = true;
        UnexpectedAlertBehavior = ACCEPT;
        UsePerProcessProxy = null;

        HideCommandPromptWindow = true;
        LoggingLevel = ERROR;
        Port = null;
        SuppressInitialDiagnosticInformation = true;
        IsAutoDetect = null;

        ScrollBehavior = ElementScrollBehavior.BOTTOM;
        AttachTimeout = Duration.ofSeconds(30);
        FileUploadTimeout = Duration.ofSeconds(30);
    }

    /**
     * Gets or sets the command line arguments used in launching Internet Explorer when the Windows
     * CreateProcess API is used. This property only has an effect when the
     * OpenQA.Selenium.IE.InternetExplorerOptions.ForceCreateProcessApi is true.
     */
    public static String CommandLineArguments;

    /**
     * Gets or sets the value for describing how elements are scrolled into view in the IE driver.
     * Defaults to scrolling the element to the top of the viewport.
     */
    public static ElementScrollBehavior ScrollBehavior;

    /**
     *
     */
    public static Boolean EnableFullPageScreenshot;

    /**
     * Gets or sets a value indicating whether to use native events in interacting with elements.
     */
    public static Boolean EnableNativeEvents;

    /**
     * Gets or sets a value indicating whether to enable persistently sending WM_MOUSEMOVE messages
     * to the IE window during a mouse hover.
     */
    public static Boolean EnablePersistentHover = null;

    /**
     * Gets or sets a value indicating whether to clear the Internet Explorer cache before launching the browser.
     * When set to true, clears the system cache for all instances of Internet Explorer, even those already
     * running when the driven instance is launched. Defaults to false.
     */
    public static Boolean EnsureCleanSession;

    /**
     * Gets or sets a value indicating whether to force the use of the Windows CreateProcess API when launching
     * Internet Explorer. The default value is false.
     */
    public static Boolean ForceCreateProcessApi;

    /**
     * Gets or sets a value indicating whether to force the use of the Windows ShellWindows API when attaching to
     * Internet Explorer. The default value is false.
     */
    public static Boolean ForceShellWindowsApi;

    /**
     * Gets or sets a value indicating whether to ignore the zoom level of Internet Explorer.
     */
    public static Boolean IgnoreZoomLevel;

    /**
     * Gets or sets the initial URL displayed when IE is launched. If not set, the browser launches with the internal startup page for the WebDriver server.
     */
    public static String InitialBrowserUrl;

    /**
     * Gets or sets a value indicating whether to ignore the settings of the Internet Explorer Protected Mode.
     */
    public static Boolean IntroduceInstability;

    /**
     * Gets or sets the value for describing how the browser is to wait for pages to load in the browser. Defaults to OpenQA.Selenium.PageLoadStrategy.Default.
     */
    public static PageLoadStrategy PageLoadStrategy;

    /**
     * Gets or sets a value indicating whether to require the browser window to have focus before interacting with elements.
     */
    public static Boolean RequireWindowFocus;

    /**
     * Gets or sets the value for describing how unexpected alerts are to be handled in the browser. Defaults to OpenQA.Selenium.UnhandledPromptBehavior.Default.
     */
    public static UnexpectedAlertBehaviour UnexpectedAlertBehavior;

    /**
     * Gets or sets a value indicating whether to use the supplied OpenQA.Selenium.Proxy settings on a per-process
     * basis, not updating the system installed proxy setting. This property is only valid when setting an
     * OpenQA.Selenium.Proxy, where the OpenQA.Selenium.Proxy.Kind property is either OpenQA.Selenium.ProxyKind.Direct,
     * OpenQA.Selenium.ProxyKind.System, or OpenQA.Selenium.ProxyKind.Manual, and is otherwise ignored. Defaults to false.
     */
    public static String UsePerProcessProxy;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public static Boolean HideCommandPromptWindow;

    /**
     * Gets or sets the value of the host adapter on which the IEDriverServer should listen for connections.
     */
    public static String Host;

    /**
     * Gets or sets the path to which the supporting library of the IEDriverServer.exe is extracted. Defaults to the temp directory if this property is not set.
     */
    public static String LibraryExtractionPath;

    /**
     * Gets or sets the location of the log file written to by the IEDriverServer.
     */
    public static String LogFile;

    /**
     * Gets or sets the logging level used by the IEDriverServer.
     */
    public static InternetExplorerDriverLogLevel LoggingLevel;

    /**
     * Gets or sets the port of the service.
     */
    public static Integer Port;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is suppressed when starting the
     * driver server executable. Defaults to false, meaning diagnostic information should be shown by the
     * driver server executable.
     */
    public static Boolean SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets the comma-delimited list of IP addresses that are approved to connect to this instance of the
     * IEDriverServer. Defaults to an empty String, which means only the local loopback address can connect.
     */
    public static String WhitelistedIPAddresses;

    /**
     * Gets or sets the value of the proxy for the FTP protocol.
     */
    public static String FtpProxy;

    /**
     * Gets or sets the value of the proxy for the HTTP protocol.
     */
    public static String HttpProxy;

    /**
     * Gets or sets a value indicating whether the proxy uses automatic detection.
     */
    public static Boolean IsAutoDetect;

    /**
     * Gets or sets the type of proxy.
     */
    public static String ProxyKind;

    /**
     * Gets or sets the value for bypass proxy addresses.
     */
    public static String NoProxy;

    /**
     * Gets or sets the URL used for proxy automatic configuration.
     */
    public static String ProxyAutoConfigUrl;

    /**
     * Gets or sets the value of password for the SOCKS proxy.
     */
    public static String SocksPassword;

    /**
     * Gets or sets the value of the proxy for the SOCKS protocol.
     */
    public static String SocksProxy;

    /**
     * Gets or sets the value of username for the SOCKS proxy.
     */
    public static String SocksUserName;

    /**
     * Gets or sets the value of the proxy for the SSL protocol.
     */
    public static String SslProxy;

    /**
     * Gets or sets the amount of time the driver will attempt to look for the file selection
     * dialog when attempting to upload a file.
     */
    public static Duration FileUploadTimeout;

    /**
     *
     */
    public static Duration AttachTimeout;
}
