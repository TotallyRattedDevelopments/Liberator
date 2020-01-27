package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.FirefoxPreferences;
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
    @Override
    public WebDriver StartDriver() {
        try {
            System.setProperty("webdriver.gecko.driver", FirefoxSettings.FirefoxDriverLocation);
            setOptions();
            setFirefoxProfile(Options);
            setDriverService();
            addPreferencesToFirefoxProfile();
            //setFirefoxProxy();

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
    @Override
    public WebDriver StartDriver(BasePreferences driverSettings) {
        try {
            System.setProperty("webdriver.gecko.driver", FirefoxSettings.FirefoxDriverLocation);

            setOptions();
            setFirefoxProfile(Options);
            setDriverService();
            addPreferencesToFirefoxProfile();
            //setFirefoxProxy();

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

    //TODO: Finish proxy loading code
    private void setFirefoxProxy(){
        try {
            Proxy proxy = new Proxy();
            proxy.setProxyType(Proxy.ProxyType.AUTODETECT);
            proxy.setProxyAutoconfigUrl(FirefoxSettings.ProxyPreferences);

            Options.setProxy(proxy);
        } catch (Exception e){
            System.out.println("Could not set the proxy for firefox.");
        }
    }
}
