package org.liberator.ratdriver.preferences;

import org.openqa.selenium.UnexpectedAlertBehaviour;
import org.openqa.selenium.ie.InternetExplorerDriverLogLevel;
import org.openqa.selenium.ie.ElementScrollBehavior;
import org.openqa.selenium.PageLoadStrategy;

import java.time.Duration;

@SuppressWarnings({"CanBeFinal", "unused"})
public class IEPreferences extends BasePreferences {

    public IEPreferences()
    {
        EnableFullPageScreenshot = null;
        EnableNativeEvents = null;
        EnablePersistentHover = null;
        EnsureCleanSession = null;
        ForceCreateProcessApi = null;
        ForceShellWindowsApi = null;
        IgnoreZoomLevel = null;
        InitialBrowserUrl = "http://www.totallyratted.com";
        IntroduceInstability = null;
        PageLoadStrategy = org.openqa.selenium.PageLoadStrategy.EAGER;
        RequireWindowFocus = null;
        UnexpectedAlertBehavior = UnexpectedAlertBehaviour.ACCEPT;
        UsePerProcessProxy = null;

        HideCommandPromptWindow = null;
        LoggingLevel = InternetExplorerDriverLogLevel.INFO;
        Port = null;
        SuppressInitialDiagnosticInformation = null;
        IsAutoDetect = null;

        FileUploadTimeout = Duration.ofSeconds(30);
        AttachTimeout = Duration.ofSeconds(30);

        Host = null;
        LibraryExtractionPath = null;
        LogFile = null;

        WhitelistedIPAddresses = null;
        FtpProxy = null;
        HttpProxy = null;

        ProxyKind = null;
        CommandLineArguments = null;
    }

    /**
     * Gets or sets the command line arguments used in launching Internet Explorer when the Windows CreateProcess API is used.
     * This property only has an effect when the OpenQA.Selenium.IE.InternetExplorerOptions.ForceCreateProcessApi is true.
     */
    public String CommandLineArguments;

    /**
     * Gets or sets the value for describing how elements are scrolled into view in the IE driver. Defaults to scrolling the element to the top of the viewport.
     */
    public ElementScrollBehavior ScrollBehavior;

    /**
     *
     */
    public Boolean EnableFullPageScreenshot;

    /**
     * Gets or sets a value indicating whether to use native events in interacting with elements.
     */
    public Boolean EnableNativeEvents;

    /**
     * Gets or sets a value indicating whether to enable persistently sending WM_MOUSEMOVE messages to the IE window during a mouse hover.
     */
    public Boolean EnablePersistentHover;

    /**
     * Gets or sets a value indicating whether to clear the Internet Explorer cache before launching the browser.
     * When set to true, clears the system cache for all instances of Internet Explorer, even those already running
     * when the driven instance is launched. Defaults to false.
     */
    public Boolean EnsureCleanSession;

    /**
     * Gets or sets a value indicating whether to force the use of the Windows CreateProcess API when launching Internet Explorer. The default value is false.
     */
    public Boolean ForceCreateProcessApi;

    /**
     * Gets or sets a value indicating whether to force the use of the Windows ShellWindows API when attaching to Internet Explorer. The default value is false.
     */
    public Boolean ForceShellWindowsApi;

    /**
     * Gets or sets a value indicating whether to ignore the zoom level of Internet Explorer.
     */
    public Boolean IgnoreZoomLevel;

    /**
     * Gets or sets the initial URL displayed when IE is launched. If not set, the browser launches with the internal startup page for the WebDriver server.
     */
    public String InitialBrowserUrl;

    /**
     * Gets or sets a value indicating whether to ignore the settings of the Internet Explorer Protected Mode.
     */
    public Boolean IntroduceInstability;

    /**
     * Gets or sets the value for describing how the browser is to wait for pages to load in the browser. Defaults to OpenQA.Selenium.PageLoadStrategy.Default
     */
    public PageLoadStrategy PageLoadStrategy;

    /**
     * Gets or sets a value indicating whether to require the browser window to have focus before interacting with elements.
     */
    public Boolean RequireWindowFocus;

    /**
     * Gets or sets the value for describing how unexpected alerts are to be handled in the browser. Defaults to OpenQA.Selenium.UnhandledPromptBehavior.Default
     */
    public UnexpectedAlertBehaviour UnexpectedAlertBehavior;

    /**
     * Gets or sets a value indicating whether to use the supplied OpenQA.Selenium.Proxy settings on a
     * per-process basis, not updating the system installed proxy setting. This property is only valid
     * when setting a OpenQA.Selenium.Proxy, where the OpenQA.Selenium.Proxy.Kind property is either
     * OpenQA.Selenium.ProxyKind.Direct, OpenQA.Selenium.ProxyKind.System, or OpenQA.Selenium.ProxyKind.Manual,
     * and is otherwise ignored. Defaults to false.
     */
    public String UsePerProcessProxy;

    /**
     * Gets or sets a value indicating whether the command prompt window of the service should be hidden.
     */
    public Boolean HideCommandPromptWindow;

    /**
     * Gets or sets the value of the host adapter on which the IEDriverServer should listen for connections.
     */
    public String Host;

    /**
     * Gets or sets the path to which the supporting library of the IEDriverServer.exe is extracted. Defaults to the temp directory if this property is not set.
     */
    public String LibraryExtractionPath;

    /**
     * Gets or sets the location of the log file written to by the IEDriverServer.
     */
    public String LogFile;

    /**
     * Gets or sets the logging level used by the IEDriverServer.
     */
    public InternetExplorerDriverLogLevel LoggingLevel;

    /**
     * Gets or sets the port of the service.
     */
    public Integer Port;

    /**
     * Gets or sets a value indicating whether the initial diagnostic information is suppressed when starting the driver
     * server executable. Defaults to false, meaning diagnostic information should be shown by the driver server executable.
     */
    public Boolean SuppressInitialDiagnosticInformation;

    /**
     * Gets or sets the comma-delimited list of IP addresses that are approved to connect to this instance of the
     * IEDriverServer. Defaults to an empty String, which means only the local loopback address can connect.
     */
    public String WhitelistedIPAddresses;

    /**
     * Gets or sets the value of the proxy for the FTP protocol.
     */
    public String FtpProxy;

    /**
     * Gets or sets the value of the proxy for the HTTP protocol.
     */
    public String HttpProxy;

    /**
     * Gets or sets a value indicating whether the proxy uses automatic detection.
     */
    public Boolean IsAutoDetect;

    /**
     * Gets or sets the type of proxy.
     */
    public String ProxyKind;

    /**
     * Gets or sets the value for bypass proxy addresses.
     */
    public String NoProxy;

    /**
     * Gets or sets the URL used for proxy automatic configuration.
     */
    public String ProxyAutoConfigUrl;

    /**
     * Gets or sets the value of password for the SOCKS proxy.
     */
    public String SocksPassword;

    /**
     * Gets or sets the value of the proxy for the SOCKS protocol.
     */
    public String SocksProxy;

    /**
     * Gets or sets the value of username for the SOCKS proxy.
     */
    public String SocksUserName;

    /**
     * Gets or sets the value of the proxy for the SSL protocol.
     */
    public String SslProxy;

    /**
     * Gets or sets the amount of time the driver will attempt to look for the file selection dialog when attempting to upload a file.
     */
    public Duration FileUploadTimeout;

    /**
     *
     */
    public Duration AttachTimeout;
}
