package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.ChromePreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.ChromeSettings;
import org.openqa.selenium.Platform;
import org.openqa.selenium.Proxy;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeDriverService;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.interactions.touch.TouchActions;
import org.openqa.selenium.logging.LogType;
import org.openqa.selenium.logging.LoggingPreferences;
import org.openqa.selenium.remote.BrowserType;
import org.openqa.selenium.remote.CapabilityType;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.io.File;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;

public class ChromeControl extends BrowserControl {

    /**
     * Constructor for ChromeControl
     *
     * @param chromePreferences The preferences for Chrome
     */
    public ChromeControl(ChromePreferences chromePreferences) {
        Options = new ChromeOptions();
        Preferences = chromePreferences;

        setImportedPreferences(chromePreferences);
    }

    private void setImportedPreferences(ChromePreferences chromePreferences) {
        if (chromePreferences != null) {

            ChromeSettings.Timeout = chromePreferences.Timeout;
            ChromeSettings.AsyncJavaScript = chromePreferences.AsyncJavaScript;
            ChromeSettings.DebugLevel = chromePreferences.DebugLevel;
            ChromeSettings.ImplicitWait = chromePreferences.ImplicitWait;
            ChromeSettings.PageLoad = chromePreferences.PageLoad;
            ChromeSettings.AlertHandling = chromePreferences.AlertHandling;
            ChromeSettings.InternalTimers = chromePreferences.InternalTimers;
            ChromeSettings.MenuHoverTime = chromePreferences.MenuHoverTime;
            ChromeSettings.Sleep = chromePreferences.Sleep;

            ChromeSettings.AndroidDebugBridgePort = chromePreferences.AndroidDebugBridgePort;
            ChromeSettings.BinaryLocation = chromePreferences.BinaryLocation;
            ChromeSettings.BufferUsageReportingInterval = chromePreferences.BufferUsageReportingInterval;
            ChromeSettings.CapabilityList = chromePreferences.CapabilityList;
            ChromeSettings.DebuggerAddress = chromePreferences.DebuggerAddress;
            ChromeSettings.EnableTouchEvents = chromePreferences.EnableTouchEvents;
            ChromeSettings.EnableVerboseLogging = chromePreferences.EnableVerboseLogging;
            ChromeSettings.ExtensionsList = chromePreferences.ExtensionsList;
            ChromeSettings.Height = chromePreferences.Height;
            ChromeSettings.HideCommandPromptWindow = chromePreferences.HideCommandPromptWindow;
            ChromeSettings.IsCollectingNetworkEvents = chromePreferences.IsCollectingNetworkEvents;
            ChromeSettings.IsCollectingPageEvents = chromePreferences.IsCollectingPageEvents;
            ChromeSettings.LeaveBrowserRunning = chromePreferences.LeaveBrowserRunning;
            ChromeSettings.LocalStatePreferences = chromePreferences.LocalStatePreferences;
            ChromeSettings.LogPath = chromePreferences.LogPath;
            ChromeSettings.MinidumpPath = chromePreferences.MinidumpPath;
            ChromeSettings.PixelRatio = chromePreferences.PixelRatio;
            ChromeSettings.Port = chromePreferences.Port;
            ChromeSettings.PortServerAddress = chromePreferences.PortServerAddress;
            ChromeSettings.SuppressInitialDiagnosticInformation = chromePreferences.SuppressInitialDiagnosticInformation;
            ChromeSettings.TracingCategories = chromePreferences.TracingCategories;
            ChromeSettings.UserAgent = chromePreferences.UserAgent;
            ChromeSettings.UserProfilePreferences = chromePreferences.UserProfilePreferences;
            ChromeSettings.WhitelistedIPAddresses = chromePreferences.WhitelistedIPAddresses;
            ChromeSettings.Width = chromePreferences.Width;
        }
    }

    //region Public Properties

    /**
     * Holds the preset values for ChromeSettings Options
     */
    private ChromeOptions Options;

    /**
     * The ChromeSettings driver service
     */
    private ChromeDriverService Service = null;

    /**
     *
     */
    private DesiredCapabilities desiredCapabilities = DesiredCapabilities.chrome();

    /**
     * The preferences for Chrome via RatDriver
     */
    private ChromePreferences Preferences;

    /**
     * Holds the instantiated ChromeSettings Driver
     */
    public WebDriver Driver = null;



    /**
     *
     */
    public TouchActions Touch = null;

    //endregion

    /**
     * Starts a web driver
     *
     * @return A web driver instance
     */
    public WebDriver StartDriver() {
        try {
            SetOptions();
            SetService();
            setProxy();

            if (ChromeSettings.IsCollectingNetworkEvents) {
                //NB: Whilst Desired Capabilities are deprecated, ChromeDriver have not provided an alternative
                //TODO: Find alternative for this code smell due to ChromeDriver
                desiredCapabilities.setCapability(ChromeOptions.CAPABILITY, Options);
                Driver = new ChromeDriver(Service, desiredCapabilities);
            } else {
                Driver = new ChromeDriver(Service, Options);
            }
            return Driver;
        } catch (Exception ex) {
            System.out.println("Unable to instantiate driver.");
            return null;
        }
    }

    /**
     * Starts a web driver
     *
     * @param driverSettings Preference injection object
     * @return A web driver instance
     */
    public WebDriver StartDriver(BasePreferences driverSettings) {
        try {
            if (!driverSettings.equals(Preferences)) {
                Preferences = (ChromePreferences) driverSettings;
                setImportedPreferences(Preferences);
            }

            SetOptions();
            SetService();
            setProxy();

            return Driver;
        } catch (Exception ex) {
            System.out.println("Could not instantiate Chrome Driver with provided settings.");
            return null;
        }
    }

    public void setProxy(){
        try {
            if (BaseSettings.proxyType != null) {
                Proxy = new Proxy();
                setProxyAutoConfigUrl();
                setProxyType();
                setAutoDetect();
                setFtpProxy();
                setHttpProxy();
                setNoProxy();
                setSocks();
                setSslProxy();
            }
        } catch (Exception ex){
            System.out.println("Could not set up the proxy with current settings.");
        }
    }

    private void setProxyAutoConfigUrl() {
        try {
            if (BaseSettings.proxyAutoconfigUrl != null && BaseSettings.proxyAutoconfigUrl.length() > 0) {
                Proxy.setProxyAutoconfigUrl(BaseSettings.proxyAutoconfigUrl);
                System.out.format("Set auto-config URL to: %s", BaseSettings.proxyAutoconfigUrl);
            }
        } catch (Exception e) {
            System.out.format("Could not set auto-config URL to: %s", BaseSettings.proxyAutoconfigUrl);
        }
    }

    private void setProxyType() {
        try {
            if (BaseSettings.proxyType != null) {
                Proxy.setProxyType(BaseSettings.proxyType);
                System.out.format("Set proxy type to: %s", BaseSettings.proxyType.name());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set proxy type to: %s", BaseSettings.proxyType.name());
            System.out.println();
        }
    }

    private void setAutoDetect() {
        try {
            if (BaseSettings.autodetect) {
                Proxy.setAutodetect(true);
            } else {
                Proxy.setAutodetect(false);
            }
            System.out.format("Set proxy autodetect to: %s", BaseSettings.proxyType.name());
            System.out.println();
        } catch (Exception e) {
            System.out.format("Could not set proxy autodetect to: %s", BaseSettings.proxyType.name());
            System.out.println();
        }
    }

    private void setFtpProxy() {
        try {
            if (BaseSettings.ftpProxy != null) {
                Proxy.setFtpProxy(BaseSettings.ftpProxy);
                System.out.format("Set ftp proxy to: %s", BaseSettings.ftpProxy);
            }
        } catch (Exception e) {
            System.out.format("Could not set ftp proxy to: %s", BaseSettings.ftpProxy);
        }
    }

    private void setNoProxy() {
        try {
            if (BaseSettings.noProxy != null) {
                Proxy.setNoProxy(BaseSettings.noProxy);
                System.out.format("Set 'no proxy' to: %s", BaseSettings.noProxy);
            }
        } catch (Exception e) {
            System.out.format("Could not set 'no proxy' to: %s", BaseSettings.noProxy);
        }
    }

    private void setHttpProxy() {
        try {
            if (BaseSettings.httpProxy != null) {
                Proxy.setHttpProxy(BaseSettings.httpProxy);
                System.out.format("Set http proxy to: %s", BaseSettings.httpProxy);
            }
        } catch (Exception e) {
            System.out.format("Could not set http proxy to: %s", BaseSettings.httpProxy);
        }
    }

    private void setSocks() {
        try {
            if (BaseSettings.socksProxy != null) {
                Proxy.setSocksProxy(BaseSettings.socksProxy);
                Proxy.setSocksVersion(BaseSettings.socksVersion);
                Proxy.setSocksUsername(BaseSettings.socksUsername);
                Proxy.setSocksPassword(BaseSettings.socksPassword);

                System.out.format("Set socks proxy to: %s", BaseSettings.socksProxy);
                System.out.format("Set socks proxy version to: %s", BaseSettings.socksVersion);
                System.out.format("Set socks proxy username to: %s", BaseSettings.socksUsername);
                System.out.format("Set socks proxy password to: %s", BaseSettings.socksPassword);
            }
        } catch (Exception e) {
            System.out.format("Could not set socks proxy to.");
        }
    }

    private void setSslProxy() {
        try {
            if (BaseSettings.sslProxy != null) {
                Proxy.setHttpProxy(BaseSettings.sslProxy);
                System.out.format("Set SSL proxy to: %s", BaseSettings.sslProxy);
            }
        } catch (Exception e) {
            System.out.format("Could not set SSL proxy to: %s", BaseSettings.sslProxy);
        }
    }

    private void SetService() {
        try {
            ChromeDriverService.Builder builder = new ChromeDriverService.Builder();

            setExecutableForDriver(builder);
            setDriverPort(builder);
            setLogFile(builder);
            setWhitelist(builder);
            setVerboseLogging(builder);
            setSilentRunning(builder);

            Service = builder.build();

        } catch (Exception ex) {
            System.out.println("Unable to build the Chrome Driver Service as requested.");
            System.out.println("Please review any required changes to settings on your system.");
        }
    }

    private void SetOptions() {
        try {
            Platform platform = Platform.getCurrent();
            Options = new ChromeOptions();
            Options.setCapability("browserName", BrowserType.CHROME);
            Options.setCapability("platform", platform);

            Options.setExperimentalOption("w3c", false);

            setChromeBinaryLocation();
            setLeaveBrowserRunning();
            setDebuggerAddress();
            setMinidumpPath();
            AddMobileEmulationPreferences();
            AddPerformanceLoggingPrefs();
            AddAdditionalCapabilities();
            AddExtensions();
            AddLocalStatePreferences();
            AddUserProfilePreferences();

        } catch (Exception ex) {
            switch (ChromeSettings.DebugLevel) {
                case Human:
                    System.out.println("Unable to load driver options settings from the config file.");
                    System.out.println("Please reset Liberator Driver Configs to its default settings.");
                    break;
                case NotSpecified:
                case Message:
                    System.out.println(ex.getMessage());
                    break;
                case StackTrace:
                    System.out.println(ex.getMessage());
                    System.out.println(Arrays.toString(ex.getStackTrace()));
                    break;
            }
        }
    }

    private void setMinidumpPath() {
        try {
            if (!ChromeSettings.MinidumpPath.isEmpty() && !ChromeSettings.MinidumpPath.contains("/")) {
                Options.setCapability(ChromeSettings.MinidumpPath, "minidumpPath");
            }
        } catch (Exception e) {
            System.out.println("Unable to set the minidump path");
        }
    }

    private void setDebuggerAddress() {
        try {
            if (ChromeSettings.DebuggerAddress != null && !ChromeSettings.DebuggerAddress.isEmpty())
                Options.setCapability("debuggerAddress", ChromeSettings.DebuggerAddress);
        } catch (Exception e) {
            System.out.println("Unable to set the debugger address.");
        }
    }

    private void setLeaveBrowserRunning() {
        try {
            if (ChromeSettings.LeaveBrowserRunning.contains("true")) {
                Options.setCapability("detach", true);
            } else {
                Options.setCapability("detach", false);
            }
        } catch (Exception e) {
            System.out.println("Unable to set detachment value.");
        }
    }

    private void setChromeBinaryLocation() {
        try {
            Options.setCapability("binary", ChromeSettings.BinaryLocation);
        } catch (Exception e) {
            System.out.println("Unable to set the location of the Chrome binary");
        }
    }

    private void AddUserProfilePreferences() {
        String name;
        Object objValue;

        try {
            String preferenceList = ChromeSettings.UserProfilePreferences;

            if (preferenceList != null && preferenceList.contains(",")) {
                String[] list = preferenceList.split(",");

                for (String preference : list) {
                    String[] setting = preference.split("=");
                    name = setting[0];
                    objValue = setting[1].split("|")[0];
                    Options.setCapability(name, objValue);
                }
            }
        } catch (Exception ex) {
            System.out.println("Could not successfully add the local state preferences required.");
        }
    }

    private void AddLocalStatePreferences() {
        String name;
        Object objValue;

        try {
            String preferenceList = ChromeSettings.LocalStatePreferences;

            if (preferenceList != null && preferenceList.contains(",")) {
                String[] list = preferenceList.split(",");

                for (String preference : list) {
                    String[] setting = preference.split("=");
                    name = setting[0];
                    objValue = setting[1].split("|")[0];
                    Options.setCapability(name, objValue);
                }
            }
        } catch (Exception ex) {
            System.out.println("Could not successfully add the local state preferences required.");
        }
    }

    private void AddExtensions() {
        try {
            if (ChromeSettings.ExtensionsList != null && !ChromeSettings.ExtensionsList.isEmpty()) {
                String[] extensions;
                if (ChromeSettings.ExtensionsList.contains(",")) {
                    extensions = ChromeSettings.ExtensionsList.split(",");
                } else {
                    extensions = new String[1];
                    extensions[0] = ChromeSettings.ExtensionsList;
                }
                Options.setCapability("extensions", extensions);
            }
        } catch (Exception ex) {
            System.out.println("Could not successfully compile the required extensions required.");
        }
    }

    private void AddAdditionalCapabilities() {

    }

    private void AddMobileEmulationPreferences() {
        try {
            if (ChromeSettings.Height != null && !ChromeSettings.Height.isEmpty() && !ChromeSettings.Width.isEmpty()) {
                Map<String, Object> deviceMetrics = new HashMap<>();
                deviceMetrics.put("width", ChromeSettings.Width);
                deviceMetrics.put("height", ChromeSettings.Height);

                if (!ChromeSettings.PixelRatio.isEmpty()) {
                    deviceMetrics.put("pixelRatio", ChromeSettings.PixelRatio);
                } else {
                    deviceMetrics.put("pixelRatio", 3.0);
                }

                Map<String, Object> mobileEmulation = new HashMap<>();
                mobileEmulation.put("deviceMetrics", deviceMetrics);

                if (!ChromeSettings.UserAgent.isEmpty()) {
                    mobileEmulation.put("userAgent", ChromeSettings.UserAgent);
                }
                Options.setExperimentalOption("mobileEmulation", mobileEmulation);
            }
        } catch (Exception ex) {
            System.out.println("Could not set the mobile emulation preferences for Chrome Driver.");
        }
    }

    private void AddPerformanceLoggingPrefs() {
        try {
            if (ChromeSettings.IsCollectingNetworkEvents) {
                LoggingPreferences loggingPreferences = new LoggingPreferences();
                loggingPreferences.enable(LogType.PERFORMANCE, Level.ALL);
                desiredCapabilities.setCapability(CapabilityType.LOGGING_PREFS, loggingPreferences);

                Map<String, Object> perfLoggingPrefs = new HashMap<>();
                perfLoggingPrefs.put("enableNetwork", ChromeSettings.IsCollectingNetworkEvents);
                perfLoggingPrefs.put("enablePage", ChromeSettings.IsCollectingPageEvents);
                perfLoggingPrefs.put("traceCategories", ChromeSettings.TracingCategories);
                perfLoggingPrefs.put("bufferUsageReportingInterval", ChromeSettings.BufferUsageReportingInterval);
                Options.setExperimentalOption("perfLoggingPrefs", perfLoggingPrefs);
            }
        } catch (Exception ex) {
            System.out.println("Could not set the performance logging preferences for Chrome Driver.");
        }
    }

    private void setExecutableForDriver(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.ChromeDriverLocation != null && !ChromeSettings.ChromeDriverLocation.isEmpty()) {
                System.setProperty("webdriver.chrome.driver", ChromeSettings.ChromeDriverLocation);
                builder.usingDriverExecutable(new File(ChromeSettings.ChromeDriverLocation));
            }
        } catch (Exception e) {
            System.out.println("Unable to set the driver executable value");
        }
    }

    private void setDriverPort(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.Port != 4444) {
                builder.usingAnyFreePort();
            } else {
                builder.usingPort(ChromeSettings.Port);
            }
        } catch (Exception e) {
            System.out.println("Unable to set the driver port.");
        }
    }

    private void setLogFile(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.LogPath != null && !ChromeSettings.LogPath.isEmpty()) {
                builder.withLogFile(new File(ChromeSettings.LogPath));
            }
        } catch (Exception e) {
            System.out.println("Unable to set the log file location.");
        }
    }

    private void setWhitelist(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.WhitelistedIPAddresses != null && !ChromeSettings.WhitelistedIPAddresses.isEmpty()) {
                builder.withWhitelistedIps(ChromeSettings.WhitelistedIPAddresses);
            }
        } catch (Exception e) {
            System.out.println("Unable to set the Whitelisted IP Addresses.");
        }
    }

    private void setVerboseLogging(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.EnableVerboseLogging != null && ChromeSettings.EnableVerboseLogging.toLowerCase().contains("true")) {
                if (!ChromeSettings.LogPath.isEmpty()) {
                    System.setProperty("webdriver.chrome.logfile", ChromeSettings.LogPath);
                    System.setProperty("webdriver.chrome.verboseLogging", "true");
                }
                builder.withVerbose(true);
            } else {
                builder.withVerbose(false);
            }
        } catch (Exception e) {
            System.out.println("Unable to set the Verbose Logging value");
        }
    }

    private void setSilentRunning(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.SuppressInitialDiagnosticInformation != null && ChromeSettings.SuppressInitialDiagnosticInformation.toLowerCase().contains("true")) {
                builder.withSilent(true);
            } else {
                builder.withSilent(false);
            }
        } catch (Exception e) {
            System.out.println("Unable to engage silent running.");
        }
    }
}