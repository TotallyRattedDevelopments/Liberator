package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.FirefoxPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.ChromeSettings;
import org.liberator.ratdriver.settings.FirefoxSettings;
import org.openqa.selenium.Proxy;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.*;

import java.io.File;
import java.util.Arrays;

public class FirefoxControl extends BrowserControl {

    //region Public Properties

    /**
     * Holds a firefox profile
     */
    private FirefoxProfile Profile = null;

    /**
     * Holds the preset values for Firefox Options
     */
    private FirefoxOptions Options = null;

    /**
     * The Firefox driver service
     */
    private GeckoDriverService Service = null;

    /**
     * Holds the proxy settings for connection to the Firefox driver
     */
    public Proxy ProxySettings = null;

    /**
     * WebDriver
     */
    public WebDriver Driver = null;

    //endregion

    //region Constructors

    /**
     * Default constructor
     */
    public FirefoxControl() {
    }


    /**
     * Allows the specification of Firefox Driver preferences
     *
     * @param firefoxPreferences The preferences file to be used.
     */
    public FirefoxControl(FirefoxPreferences firefoxPreferences) {
        if (firefoxPreferences != null) {

            FirefoxSettings.Timeout = firefoxPreferences.Timeout;
            FirefoxSettings.AsyncJavaScript = firefoxPreferences.AsyncJavaScript;
            FirefoxSettings.DebugLevel = firefoxPreferences.DebugLevel;
            FirefoxSettings.ImplicitWait = firefoxPreferences.ImplicitWait;
            FirefoxSettings.PageLoad = firefoxPreferences.PageLoad;
            FirefoxSettings.AlertHandling = firefoxPreferences.AlertHandling;
            FirefoxSettings.InternalTimers = firefoxPreferences.InternalTimers;
            FirefoxSettings.MenuHoverTime = firefoxPreferences.MenuHoverTime;
            FirefoxSettings.Sleep = firefoxPreferences.Sleep;

            FirefoxSettings.AcceptUntrustedCertificates = firefoxPreferences.AcceptUntrustedCertificates;
            FirefoxSettings.AlwaysLoadNoFocusLibrary = firefoxPreferences.AlwaysLoadNoFocusLibrary;
            FirefoxSettings.AssumeUntrustedCertificateIssuer = firefoxPreferences.AssumeUntrustedCertificateIssuer;
            FirefoxSettings.CleanProfile = firefoxPreferences.CleanProfile;
            FirefoxSettings.CommunicationPort = firefoxPreferences.ConnectToRunningBrowser;
            FirefoxSettings.ConnectToRunningBrowser = firefoxPreferences.ConnectToRunningBrowser;
            FirefoxSettings.DeleteAfterUse = firefoxPreferences.DeleteAfterUse;
            FirefoxSettings.EnableNativeEvents = firefoxPreferences.EnableNativeEvents;
            FirefoxSettings.HideCommandPromptWindow = firefoxPreferences.HideCommandPromptWindow;
            FirefoxSettings.Host = firefoxPreferences.Host;
            FirefoxSettings.LogLevel = firefoxPreferences.LogLevel;
            FirefoxSettings.Port = firefoxPreferences.Port;
            FirefoxSettings.Preferences = firefoxPreferences.Preferences;
            FirefoxSettings.ProfileDirectory = firefoxPreferences.ProfileDirectory;
            FirefoxSettings.ProxyPreferences = firefoxPreferences.ProxyPreferences;
            FirefoxSettings.SuppressInitialDiagnosticInformation = firefoxPreferences.SuppressInitialDiagnosticInformation;
            FirefoxSettings.UseLegacyImplementation = firefoxPreferences.UseLegacyImplementation;
            FirefoxSettings.PageLoadStrategy = firefoxPreferences.PageLoadStrategy;
        }
    }

    //endregion


    /**
     * Starts a web driver
     *
     * @return A web driver instance
     */
    public WebDriver StartDriver() {
        try {
            System.setProperty("webdriver.gecko.driver", FirefoxSettings.FirefoxDriverLocation);
            setOptions();
            setFirefoxProfile(Options);
            setDriverService();
            addPreferencesToFirefoxProfile();
            setProxy();

            if (Service != null && Options != null) {
                Driver = new FirefoxDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new FirefoxDriver(Service);
            } else if (Options != null) {
                Driver = new FirefoxDriver(Options);
            }

            return Driver;
        } catch (Exception e) {
            System.out.println("Could not start the Firefox Driver.");
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
            System.setProperty("webdriver.gecko.driver", FirefoxSettings.FirefoxDriverLocation);

            setOptions();
            setFirefoxProfile(Options);
            setDriverService();
            addPreferencesToFirefoxProfile();
            setProxy();

            if (Service != null && Options != null) {
                Driver = new FirefoxDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new FirefoxDriver(Service);
            } else if (Options != null) {
                Driver = new FirefoxDriver(Options);
            }

            return Driver;
        } catch (Exception e) {
            System.out.println("Could not start the Firefox Driver.");
            return null;
        }
    }


    /**
     * Sets the options for the firefox driver
     */
    private void setOptions() {
        try {
            if (FirefoxSettings.AcceptUntrustedCertificates != null ||
                    FirefoxSettings.LogLevel != null ||
                    FirefoxSettings.PageLoadStrategy != null ||
                    FirefoxSettings.UnexpectedAlertBehaviour != null) {
                FirefoxOptions options = new FirefoxOptions();

                setAcceptInsecureCertificates(options);
                setLogLevel(options);
                setPageLoadStrategy(options);
                setUnexpectedAlertBehaviour(options);

                Options = options;
            } else {
                Options = null;
            }
        } catch (Exception ex) {
            switch (FirefoxSettings.DebugLevel) {
                case Human:
                    System.out.println("Could not set the Firefox option settings.");
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
            Options = null;
        }
    }

    /**
     * Sets the setUnhandledPromptBehaviour property in firefox options
     *
     * @param options The Options object
     */
    private void setUnexpectedAlertBehaviour(FirefoxOptions options) {
        try {
            if (FirefoxSettings.UnexpectedAlertBehaviour != null) {
                options.setUnhandledPromptBehaviour(FirefoxSettings.UnexpectedAlertBehaviour);
                System.out.format("The alert behaviour was set to: %s", FirefoxSettings.UnexpectedAlertBehaviour.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.println("Could not set the unexpected alert behaviour.");
            System.out.format("Intended behaviour was: %s", FirefoxSettings.UnexpectedAlertBehaviour.toString());
        }
    }

    /**
     * @param options The Options object
     */
    private void setPageLoadStrategy(FirefoxOptions options) {
        try {
            if (FirefoxSettings.PageLoadStrategy != null) {
                options.setPageLoadStrategy(FirefoxSettings.PageLoadStrategy);
                System.out.format("The page load strategy was set to: %s", FirefoxSettings.PageLoadStrategy.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.println("Could not set the page load strategy");
            System.out.format("Intended strategy was: %s", FirefoxSettings.PageLoadStrategy.toString());
        }
    }

    /**
     * @param options The Options object
     */
    private void setLogLevel(FirefoxOptions options) {
        try {
            if (FirefoxSettings.LogLevel != null) {
                options.setLogLevel(FirefoxSettings.LogLevel);
                System.out.format("The log level was set to: %s", FirefoxSettings.LogLevel.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.println("Could not set the Log Level.");
            System.out.format("The log level was set to: %s", FirefoxSettings.LogLevel.toString());
        }
    }

    /**
     * @param options The Options object
     */
    @Deprecated
    private void setLegacyImplementation(FirefoxOptions options) {
        try {
            if (FirefoxSettings.UseLegacyImplementation != null) {
                options.setLegacy(FirefoxSettings.UseLegacyImplementation);
                System.out.format("Set use legacy implementation to: %s", FirefoxSettings.UseLegacyImplementation.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.println("Could not set the legacy implementation.");
            System.out.format("The property was set to: %s", FirefoxSettings.UseLegacyImplementation.toString());
        }
    }

    /**
     * @param options The Options object
     */
    private void setFirefoxProfile(FirefoxOptions options) {
        try {
            if (FirefoxSettings.ProfileDirectory != null) {
                Profile = new FirefoxProfile(new File(FirefoxSettings.ProfileDirectory));
                options.setProfile(Profile);
            } else {
                createBasicProfile();
            }
        } catch (Exception e) {
            System.out.println("Could not add the profile to the FirefoxOptions.");
        }
    }

    /**
     * @param options The Options object
     */
    private void setAcceptInsecureCertificates(FirefoxOptions options) {
        try {
            if (FirefoxSettings.AcceptUntrustedCertificates != null) {
                options.setAcceptInsecureCerts(FirefoxSettings.AcceptUntrustedCertificates);
                System.out.format("Set the acceptance of untrusted certificates to: %s", FirefoxSettings.AcceptUntrustedCertificates.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.println("Could not set the acceptance of untrusted certificates");
            System.out.format("The property could not be set to: %s", FirefoxSettings.AcceptUntrustedCertificates.toString());
        }
    }

    /**
     * Creates a basic profile for use with firefox driver
     */
    private void createBasicProfile() {
        try {
            if (FirefoxSettings.AcceptUntrustedCertificates != null ||
                    FirefoxSettings.AlwaysLoadNoFocusLibrary != null ||
                    FirefoxSettings.AssumeUntrustedCertificateIssuer != null) {

                FirefoxProfile profile = new FirefoxProfile();

                setAcceptUntrustedCertificates(profile);
                setAlwaysLoadNoFocusLibrary(profile);
                setAssumeUntrustedIssuer(profile);

                Profile = profile;
                Options.setProfile(profile);
            } else {
                Profile = null;
            }
        } catch (Exception ex) {
            switch (FirefoxSettings.DebugLevel) {
                case Human:
                    System.out.println("Could not create the Firefox profile specified in the config file.");
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
            Profile = null;
        }
    }

    private void setAssumeUntrustedIssuer(FirefoxProfile profile) {
        try {
            if (FirefoxSettings.AssumeUntrustedCertificateIssuer != null) {
                profile.setAssumeUntrustedCertificateIssuer(FirefoxSettings.AssumeUntrustedCertificateIssuer);
            }
        } catch (Exception e) {
            System.out.println("Could not set the AssumeUntrustedCertificateIssuer profile preference.");
            System.out.format("The property was set to: %s", FirefoxSettings.AssumeUntrustedCertificateIssuer.toString());
        }
    }

    /**
     * Sets the AlwaysLoadNoFocusLibrary value for the firefox profile
     *
     * @param profile The Firefox Profile
     */
    private void setAlwaysLoadNoFocusLibrary(FirefoxProfile profile) {
        try {
            if (FirefoxSettings.AlwaysLoadNoFocusLibrary != null) {
                profile.setAlwaysLoadNoFocusLib(FirefoxSettings.AlwaysLoadNoFocusLibrary);
            }
        } catch (Exception e) {
            System.out.println("Could not set the AlwaysLoadNoFocusLibrary profile preference.");
            System.out.format("The property was set to: %s", FirefoxSettings.AlwaysLoadNoFocusLibrary.toString());
        }
    }


    /**
     * Sets the AcceptUntrustedCertificates value for the firefox profile
     *
     * @param profile The Firefox Profile
     */
    private void setAcceptUntrustedCertificates(FirefoxProfile profile) {
        try {
            if (FirefoxSettings.AcceptUntrustedCertificates != null) {
                profile.setAcceptUntrustedCertificates(FirefoxSettings.AcceptUntrustedCertificates);
            }
        } catch (Exception e) {
            System.out.println("Could not set the Accept Untrusted Certificates profile preference.");
            System.out.format("The property was set to: %s", FirefoxSettings.AcceptUntrustedCertificates.toString());
        }
    }

    /**
     * Sets up the gecko driver service for use with Selenium
     */
    private void setDriverService() {
        try {
            if (FirefoxSettings.FirefoxLocation != null || FirefoxSettings.FirefoxDriverLocation != null || FirefoxSettings.Port != null) {
                GeckoDriverService.Builder builder = new GeckoDriverService.Builder();

                setServiceFirefoxBinary(builder);
                setServiceDriverExecutable(builder);
                setServiceCommunicationPort(builder);

                Service = builder.build();
            }
        } catch (Exception ex) {
            switch (FirefoxSettings.DebugLevel) {
                case Human:
                    System.out.println("Could not set the Firefox driver service settings.");
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
            Service = null;
        }
    }

    /**
     * Sets the communication for the service builder
     *
     * @param builder Builder object passed from Service instantiation
     */
    private void setServiceCommunicationPort(GeckoDriverService.Builder builder) {
        try {
            if (FirefoxSettings.CommunicationPort != null) {
                builder.usingPort(Integer.parseInt(FirefoxSettings.CommunicationPort));
            } else {
                builder.usingAnyFreePort();
            }
        } catch (NumberFormatException e) {
            System.out.println("Could not set the communication port for the service.");
        }
    }

    /**
     * Add the driver executable to the service builder
     *
     * @param builder Builder object passed from Service instantiation
     */
    private void setServiceDriverExecutable(GeckoDriverService.Builder builder) {
        try {
            if (FirefoxSettings.FirefoxDriverLocation != null) {
                File driverFile = new File(FirefoxSettings.FirefoxDriverLocation);
                builder.usingDriverExecutable(driverFile);
            }
        } catch (Exception e) {
            System.out.println("Could not add the driver executable to the service.");
        }
    }

    /**
     * Adds the firefox binary to the service builder
     *
     * @param builder Builder object passed from Service instantiation
     */
    private void setServiceFirefoxBinary(GeckoDriverService.Builder builder) {
        try {
            if (FirefoxSettings.FirefoxLocation != null) {
                org.openqa.selenium.firefox.FirefoxBinary firefoxBinary = new FirefoxBinary(new File(FirefoxSettings.FirefoxLocation));
                builder.usingFirefoxBinary(firefoxBinary);
            }
        } catch (Exception e) {
            System.out.println("Could not add the firefox binary to the service.");
        }
    }

    /**
     * Adds preferences to the firefox options
     * Stated in the form {setting}={value}|{type}
     */
    private void addPreferencesToFirefoxProfile() {
        try {
            String firefoxPrefs = FirefoxSettings.Preferences;

            if (firefoxPrefs != null && firefoxPrefs.contains(",")) {
                String[] list = firefoxPrefs.split(",");

                for (String pref : list) {
                    String[] setting = pref.split("=");
                    String[] valuePair = setting[1].split("\\|");

                    switch (valuePair[1].toLowerCase()) {
                        case "integer":
                            int intValue = Integer.parseInt(valuePair[0]);
                            Profile.setPreference(setting[0], intValue);
                            break;
                        case "string":
                            Profile.setPreference(setting[0], valuePair[0]);
                            break;
                        case "boolean":
                            boolean boolValue = Boolean.parseBoolean(valuePair[0]);
                            Profile.setPreference(setting[0], boolValue);
                            break;
                    }
                }
            }
        } catch (Exception ex) {
            switch (FirefoxSettings.DebugLevel) {
                case Human:
                    System.out.println("Could not add the listed preferences to Firefox.");
                    System.out.println("Please reset the config file to its default settings.");
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
            }
        } catch (Exception e) {
            System.out.format("Could not set proxy type to: %s", BaseSettings.proxyType.name());
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
        } catch (Exception e) {
            System.out.format("Could not set proxy autodetect to: %s", BaseSettings.proxyType.name());
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
}
