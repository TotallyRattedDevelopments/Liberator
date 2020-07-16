package org.liberator.ratdriver.control;

import org.liberator.ratdriver.ErrorHandler;
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
import org.openqa.selenium.logging.LogType;
import org.openqa.selenium.logging.LoggingPreferences;
import org.openqa.selenium.remote.BrowserType;
import org.openqa.selenium.remote.CapabilityType;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.io.File;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;

public class ChromeControl extends RemoteControl {

    /**
     * Holds the instantiated ChromeSettings Driver
     */
    public WebDriver driver = null;

    /**
     *
     */
    public Proxy proxy = null;

    //public TouchActions touchActions = null;

    //region Public Properties
    /**
     * Holds the preset values for ChromeSettings Options
     */
    private ChromeOptions chromeOptions;

    /**
     * The ChromeSettings driver service
     */
    private ChromeDriverService chromeDriverService = null;

    /**
     *
     */
    @SuppressWarnings("CanBeFinal")
    private DesiredCapabilities desiredCapabilities = DesiredCapabilities.chrome();

    /**
     * The preferences for Chrome via RatDriver
     */
    private ChromePreferences chromePreferences;

    /**
     * Constructor for ChromeControl
     *
     * @param chromePreferences The preferences for Chrome
     */
    public ChromeControl(ChromePreferences chromePreferences) {
        chromeOptions = new ChromeOptions();
        this.chromePreferences = chromePreferences;

        setImportedPreferences(chromePreferences);
    }

    /**
     * Sets the preferences for the test
     *
     * @param chromePreferences The requested preferences for the test
     */
    private void setImportedPreferences(ChromePreferences chromePreferences) {
        try {
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
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "ChromeControl",
                    "setImportedPreferences",
                    "Unable to import preferences."
            );
        }
    }

    //endregion

    /**
     * Starts a web driver
     *
     * @return A web driver instance
     */
    public WebDriver startDriver() {
        try {
            setOptions();
            setService();
            setProxy();

            if (ChromeSettings.IsCollectingNetworkEvents) {
                //NB: Whilst Desired Capabilities are deprecated, ChromeDriver have not provided an alternative
                //TODO: Find alternative for this code smell due to ChromeDriver
                desiredCapabilities.setCapability(ChromeOptions.CAPABILITY, chromeOptions);
                driver = new ChromeDriver(chromeDriverService, desiredCapabilities);
            } else {
                driver = new ChromeDriver(chromeDriverService, chromeOptions);
            }
            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "ChromeControl",
                    "startDriver",
                    "Unable to instantiate driver."
            );
            return null;
        }
    }

    /**
     * Starts a web driver
     *
     * @param driverSettings Preference injection object
     * @return A web driver instance
     */
    public WebDriver startDriver(BasePreferences driverSettings) {
        try {
            if (!driverSettings.equals(chromePreferences)) {
                chromePreferences = (ChromePreferences) driverSettings;
                setImportedPreferences(chromePreferences);
            }

            startDriver();

            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "ChromeControl",
                    "startDriver",
                    "Could not instantiate Chrome Driver with provided settings."
            );
            return null;
        }
    }

    public void setProxy() {
        try {
            if (BaseSettings.proxyType != null) {
                proxy = new Proxy();

                setProxyAutoConfigUrl();
                setProxyType();
                setAutoDetect();
                setFtpProxy();
                setHttpProxy();
                setNoProxy();
                setSocks();
                setSslProxy();
            }
            System.out.println("\nProxy settings added as requested.");
        } catch (Exception ex) {
            System.out.println("\nCould not set up the proxy with current settings.");
        }
    }

    private void setProxyAutoConfigUrl() {
        try {
            if (BaseSettings.proxyAutoconfigUrl != null && BaseSettings.proxyAutoconfigUrl.length() > 0) {
                proxy.setProxyAutoconfigUrl(BaseSettings.proxyAutoconfigUrl);
                System.out.format("\nSet auto-config URL to: %s", BaseSettings.proxyAutoconfigUrl);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set auto-config URL to: %s", BaseSettings.proxyAutoconfigUrl);
        }
    }

    private void setProxyType() {
        try {
            if (BaseSettings.proxyType != null) {
                proxy.setProxyType(BaseSettings.proxyType);
                System.out.format("\nSet proxy type to: %s", BaseSettings.proxyType.name());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set proxy type to: %s", BaseSettings.proxyType.name());
        }
    }

    private void setAutoDetect() {
        try {
            if (BaseSettings.autodetect) {
                proxy.setAutodetect(true);
            } else {
                proxy.setAutodetect(false);
            }
            System.out.format("\nSet proxy autodetect to: %s", BaseSettings.proxyType.name());
        } catch (Exception e) {
            System.out.format("\nCould not set proxy autodetect to: %s", BaseSettings.proxyType.name());
        }
    }

    private void setFtpProxy() {
        try {
            if (BaseSettings.ftpProxy != null) {
                proxy.setFtpProxy(BaseSettings.ftpProxy);
                System.out.format("\nSet ftp proxy to: %s", BaseSettings.ftpProxy);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set ftp proxy to: %s", BaseSettings.ftpProxy);
        }
    }

    private void setNoProxy() {
        try {
            if (BaseSettings.noProxy != null) {
                proxy.setNoProxy(BaseSettings.noProxy);
                System.out.format("\net 'no proxy' to: %s", BaseSettings.noProxy);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set 'no proxy' to: %s", BaseSettings.noProxy);
        }
    }

    private void setHttpProxy() {
        try {
            if (BaseSettings.httpProxy != null) {
                proxy.setHttpProxy(BaseSettings.httpProxy);
                System.out.format("\nSet http proxy to: %s", BaseSettings.httpProxy);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set http proxy to: %s", BaseSettings.httpProxy);
        }
    }

    private void setSocks() {
        try {
            if (BaseSettings.socksProxy != null) {
                proxy.setSocksProxy(BaseSettings.socksProxy);
                proxy.setSocksVersion(BaseSettings.socksVersion);
                proxy.setSocksUsername(BaseSettings.socksUsername);
                proxy.setSocksPassword(BaseSettings.socksPassword);

                System.out.format("\nSet socks proxy to: %s", BaseSettings.socksProxy);
                System.out.format("\nSet socks proxy version to: %s", BaseSettings.socksVersion);
                System.out.format("\nSet socks proxy username to: %s", BaseSettings.socksUsername);
                System.out.format("\nSet socks proxy password to: %s", BaseSettings.socksPassword);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set socks proxy.");
        }
    }

    private void setSslProxy() {
        try {
            if (BaseSettings.sslProxy != null) {
                proxy.setHttpProxy(BaseSettings.sslProxy);
                System.out.format("\nSet SSL proxy to: %s", BaseSettings.sslProxy);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set SSL proxy to: %s", BaseSettings.sslProxy);
        }
    }

    private void setService() {
        try {
            ChromeDriverService.Builder builder = new ChromeDriverService.Builder();

            setExecutableForDriver(builder);
            setDriverPort(builder);
            setLogFile(builder);
            setWhitelist(builder);
            setVerboseLogging(builder);
            setSilentRunning(builder);

            chromeDriverService = builder.build();

            System.out.println("\nChrome Driver Service built as requested.");
        } catch (Exception ex) {
            System.out.println("\nUnable to build the Chrome Driver Service as requested.");
            System.out.println("\nPlease review any required changes to settings on your system.");
        }
    }

    private void setOptions() {
        try {
            Platform platform = Platform.getCurrent();
            chromeOptions = new ChromeOptions();
            chromeOptions.setCapability("browserName", BrowserType.CHROME);
            chromeOptions.setCapability("platform", platform);

            chromeOptions.setExperimentalOption("w3c", false);

            setChromeBinaryLocation();
            setLeaveBrowserRunning();
            setDebuggerAddress();
            setMinidumpPath();
            addMobileEmulationPreferences();
            addPerformanceLoggingPrefs();
            //addAdditionalCapabilities();
            addExtensions();
            addLocalStatePreferences();
            addUserProfilePreferences();

        } catch (Exception ex) {
            System.out.println("\nUnable to load driver options settings.");
        }
    }

    private void setMinidumpPath() {
        try {
            if (!ChromeSettings.MinidumpPath.isEmpty() && !ChromeSettings.MinidumpPath.contains("/")) {
                chromeOptions.setCapability("minidumpPath", ChromeSettings.MinidumpPath);
                System.out.format("\nSet the minidump path to: %s", ChromeSettings.MinidumpPath);
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set the minidump path");
        }
    }

    private void setDebuggerAddress() {
        try {
            if (ChromeSettings.DebuggerAddress != null && !ChromeSettings.DebuggerAddress.isEmpty())
                chromeOptions.setCapability("debuggerAddress", ChromeSettings.DebuggerAddress);
            System.out.format("\nSet the debugger address to: %s", ChromeSettings.DebuggerAddress);
        } catch (Exception e) {
            System.out.println("\nUnable to set the debugger address.");
        }
    }

    private void setLeaveBrowserRunning() {
        try {
            if (ChromeSettings.LeaveBrowserRunning.contains("true")) {
                chromeOptions.setCapability("detach", true);
                System.out.println("\nSet the driver to leave Chrome running.");
            } else {
                chromeOptions.setCapability("detach", false);
                System.out.println("\nSet the driver to close Chrome.");
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set detachment value.");
        }
    }

    private void setChromeBinaryLocation() {
        try {
            chromeOptions.setCapability("binary", ChromeSettings.BinaryLocation);
            System.out.format("\nSet the binary location to: %s", ChromeSettings.DebuggerAddress);
        } catch (Exception e) {
            System.out.println("\nUnable to set the location of the Chrome binary");
        }
    }

    private void addUserProfilePreferences() {
        String name;
        Object objValue;

        try {
            String preferenceList = ChromeSettings.UserProfilePreferences;

            if (preferenceList != null && preferenceList.contains(",")) {
                String[] list = preferenceList.split(",");

                for (String preference : list) {
                    String[] setting = preference.split("=");
                    name = setting[0];
                    objValue = setting[1].split("\\|")[0];
                    chromeOptions.setCapability(name, objValue);
                    System.out.format("\nSet profile preference '%s' to '%s'.", name, objValue.toString());
                }
            }
        } catch (Exception ex) {
            System.out.println("\nCould not successfully add the local state preferences required.");
        }
    }

    private void addLocalStatePreferences() {
        String name;
        Object objValue;

        try {
            String preferenceList = ChromeSettings.LocalStatePreferences;

            if (preferenceList != null && preferenceList.contains(",")) {
                String[] list = preferenceList.split(",");

                for (String preference : list) {
                    String[] setting = preference.split("=");
                    name = setting[0];
                    objValue = setting[1].split("\\|")[0];
                    chromeOptions.setCapability(name, objValue);
                    System.out.format("\nSet local state preference '%s' to '%s'.", name, objValue.toString());
                }
            }
        } catch (Exception ex) {
            System.out.println("\nCould not successfully add the local state preferences required.");
        }
    }

    private void addExtensions() {
        try {
            if (ChromeSettings.ExtensionsList != null && !ChromeSettings.ExtensionsList.isEmpty()) {
                String[] extensions;
                if (ChromeSettings.ExtensionsList.contains(",")) {
                    extensions = ChromeSettings.ExtensionsList.split(",");
                } else {
                    extensions = new String[1];
                    extensions[0] = ChromeSettings.ExtensionsList;
                }
                chromeOptions.setCapability("extensions", extensions);
                System.out.format("\nAdded extensions: %s", ChromeSettings.ExtensionsList);
            }
        } catch (Exception ex) {
            System.out.println("\nCould not successfully compile the required extensions required.");
        }
    }

    private void addMobileEmulationPreferences() {
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
                chromeOptions.setExperimentalOption("mobileEmulation", mobileEmulation);
                System.out.println("\nSet mobile emulation as requested.");
            }
        } catch (Exception ex) {
            System.out.println("\nCould not set the mobile emulation preferences for Chrome Driver.");
        }
    }

    private void addPerformanceLoggingPrefs() {
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
                chromeOptions.setExperimentalOption("perfLoggingPrefs", perfLoggingPrefs);
                System.out.println("S\net performance logging preferences as requested.");
            }
        } catch (Exception ex) {
            System.out.println("\nCould not set the performance logging preferences for Chrome Driver.");
        }
    }

    private void setExecutableForDriver(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.ChromeDriverLocation != null && !ChromeSettings.ChromeDriverLocation.isEmpty()) {
                System.setProperty("webdriver.chrome.driver", ChromeSettings.ChromeDriverLocation);
                builder.usingDriverExecutable(new File(ChromeSettings.ChromeDriverLocation));
                System.out.format("\nSet the chrome driver location to: %s", ChromeSettings.LogPath);
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set the driver executable value");
        }
    }

    private void setDriverPort(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.Port != 4444) {
                builder.usingAnyFreePort();
            } else {
                builder.usingPort(ChromeSettings.Port);
                System.out.format("\nSet the driver port to: %s", ChromeSettings.LogPath);
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set the driver port.");
        }
    }

    private void setLogFile(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.LogPath != null && !ChromeSettings.LogPath.isEmpty()) {
                builder.withLogFile(new File(ChromeSettings.LogPath));
                System.out.format("\nSet the log file location to: %s", ChromeSettings.LogPath);
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set the log file location.");
        }
    }

    private void setWhitelist(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.WhitelistedIPAddresses != null && !ChromeSettings.WhitelistedIPAddresses.isEmpty()) {
                builder.withWhitelistedIps(ChromeSettings.WhitelistedIPAddresses);
                System.out.format("\nIPs added to the White List: %s", ChromeSettings.WhitelistedIPAddresses);
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set the Whitelisted IP Addresses.");
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
                System.out.println("\nEngaged verbose logging.");
            } else {
                builder.withVerbose(false);
                System.out.println("\nDisengaged verbose logging.");
            }
        } catch (Exception e) {
            System.out.println("\nUnable to set the Verbose Logging value");
        }
    }

    private void setSilentRunning(ChromeDriverService.Builder builder) {
        try {
            if (ChromeSettings.SuppressInitialDiagnosticInformation != null && ChromeSettings.SuppressInitialDiagnosticInformation.toLowerCase().contains("true")) {
                builder.withSilent(true);
                System.out.println("\nEngaged silent running.");
            } else {
                builder.withSilent(false);
                System.out.println("\nDisengaged silent running.");
            }
        } catch (Exception e) {
            System.out.println("\nUnable to engage silent running.");
        }
    }
}