package org.liberator.ratdriver.control;

import lombok.Getter;
import lombok.Setter;
import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.OperaPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.FirefoxSettings;
import org.liberator.ratdriver.settings.IESettings;
import org.liberator.ratdriver.settings.OperaSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.opera.OperaDriver;
import org.openqa.selenium.opera.OperaDriverService;
import org.openqa.selenium.opera.OperaOptions;

import java.io.File;
import java.util.Arrays;

import static org.openqa.selenium.remote.CapabilityType.*;

public class OperaControl extends BrowserControl {

    //region Public Properties

    /**
     * Holds the preset values for Opera Options
     */
    @Getter
    @Setter
    public OperaOptions Options;

    /**
     * The Internet Explorer driver service
     */
    @Getter
    @Setter
    public OperaDriverService Service;

    /**
     * Holds the instantiated Opera Driver
     */
    @Getter
    @Setter
    public WebDriver Driver;

    /**
     * The maximum amount of time to wait between commands
     */
    @Getter
    @Setter
    public Integer CommandTimeout;

    private OperaDriverService.Builder Builder;

    //endregion

    //region Constructor

    /**
     *
     */
    public OperaControl() {

    }

    /**
     * Constructor allowing for the setting of preferences on-the-fly
     *
     * @param operaPreferences Preset preferences for the test run
     */
    public OperaControl(OperaPreferences operaPreferences) {
        if (operaPreferences != null) {
            setImportedPreferences(operaPreferences);
        }
    }

    private void setImportedPreferences(OperaPreferences operaPreferences) {
        OperaSettings.Timeout = operaPreferences.Timeout;
        OperaSettings.AsyncJavaScript = operaPreferences.AsyncJavaScript;
        OperaSettings.DebugLevel = operaPreferences.DebugLevel;
        OperaSettings.ImplicitWait = operaPreferences.ImplicitWait;
        OperaSettings.PageLoad = operaPreferences.PageLoad;
        OperaSettings.AlertHandling = operaPreferences.AlertHandling;
        OperaSettings.InternalTimers = operaPreferences.InternalTimers;
        OperaSettings.MenuHoverTime = operaPreferences.MenuHoverTime;
        OperaSettings.Sleep = operaPreferences.Sleep;

        OperaSettings.AndroidDebugBridgePort = operaPreferences.AndroidDebugBridgePort;
        OperaSettings.DebuggerAddress = operaPreferences.DebuggerAddress;
        OperaSettings.EnableVerboseLogging = operaPreferences.EnableVerboseLogging;
        OperaSettings.HideCommandPromptWindow = operaPreferences.HideCommandPromptWindow;
        OperaSettings.LeaveBrowserRunning = operaPreferences.LeaveBrowserRunning;
        OperaSettings.LogPath = operaPreferences.LogPath;
        OperaSettings.MinidumpPath = operaPreferences.MinidumpPath;
        OperaSettings.Port = operaPreferences.Port;
        OperaSettings.PortServerAddress = operaPreferences.PortServerAddress;
        OperaSettings.SuppressInitialDiagnosticInformation = operaPreferences.SuppressInitialDiagnosticInformation;
        OperaSettings.UrlPathPrefix = operaPreferences.UrlPathPrefix;
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
            System.setProperty("webdriver.opera.driver", BaseSettings.OperaDriverLocation);

            SetOperaOptions();
            SetOperaDriverService();

            if (Service != null && Options != null) {
                Driver = new OperaDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new OperaDriver(Service);
            } else if (Options != null) {
                Driver = new OperaDriver(Options);
            }
            return Driver;
        } catch (Exception ex) {
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
            setImportedPreferences((OperaPreferences) driverSettings);
            System.setProperty("webdriver.opera.driver", FirefoxSettings.OperaDriverLocation);

            SetOperaOptions();
            SetOperaDriverService();

            if (Service != null && Options != null) {
                Driver = new OperaDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new OperaDriver(Service);
            } else if (Options != null) {
                Driver = new OperaDriver(Options);
            }
            return Driver;
        } catch (Exception ex) {
            return null;
        }
    }


    private void SetOperaOptions() {
        try {
            Options = new OperaOptions();
            Options.setBinary(BaseSettings.OperaLocation);
            Options.addArguments("--remote-debugging-port=9222");
            Options.addArguments("start-maximized");
            setAcceptInsecureCertificates();
            setSSLCertificates();
            setPageLoadStrategy();
            setTakesScreenshot();
            setUnexpectedAlertBehaviour();
            setUnhandledPromptBehaviour();
        } catch (Exception ex) {
            switch (BaseSettings.DebugLevel) {
                case Human:
                    System.out.println("Could not set the opera diver options.");
                    System.out.println("Please investigate the changes you have made to your config file.");
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

    private void setAcceptInsecureCertificates() {
        try {
            if (OperaSettings.AcceptInsecureCertificates != null) {
                Options.setCapability(ACCEPT_INSECURE_CERTS, OperaSettings.AcceptInsecureCertificates);
                System.out.format("Set accept insecure certificates to: %s", OperaSettings.AcceptInsecureCertificates.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set accept insecure certificates to: %s", OperaSettings.AcceptInsecureCertificates.toString());
            System.out.println();

        }
    }

    private void setSSLCertificates() {
        try {
            if (OperaSettings.AcceptSSLCertificates != null) {
                Options.setCapability(ACCEPT_SSL_CERTS, OperaSettings.AcceptSSLCertificates);
                System.out.format("Set accept SSL certificates to: %s", OperaSettings.AcceptSSLCertificates.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set accept SSL certificates to: %s", OperaSettings.AcceptSSLCertificates.toString());
            System.out.println();

        }
    }

    private void setPageLoadStrategy() {
        try {
            if (OperaSettings.PageLoadStrategy != null) {
                Options.setCapability(PAGE_LOAD_STRATEGY, OperaSettings.PageLoadStrategy);
                System.out.format("Set page load strategy to: %s", OperaSettings.PageLoadStrategy);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set page load strategy to: %s", OperaSettings.PageLoadStrategy);
            System.out.println();

        }
    }

    private void setTakesScreenshot() {
        try {
            if (OperaSettings.TakesScreenshot != null) {
                Options.setCapability(TAKES_SCREENSHOT, OperaSettings.TakesScreenshot);
                System.out.format("Set Takes Screenshot to: %s", OperaSettings.TakesScreenshot.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set Takes Screenshot to: %s", OperaSettings.TakesScreenshot.toString());
            System.out.println();

        }
    }

    private void setUnexpectedAlertBehaviour() {
        try {
            if (OperaSettings.UnexpectedAlertBehaviour != null) {
                Options.setCapability(UNEXPECTED_ALERT_BEHAVIOUR, OperaSettings.UnexpectedAlertBehaviour);
                System.out.format("Set Unexpected Alert Behaviour to: %s", OperaSettings.UnexpectedAlertBehaviour);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set Unexpected Alert Behaviour to: %s", OperaSettings.UnexpectedAlertBehaviour);
            System.out.println();

        }
    }

    private void setUnhandledPromptBehaviour() {
        try {
            if (OperaSettings.UnhandledPromptBehaviour != null) {
                Options.setCapability(UNHANDLED_PROMPT_BEHAVIOUR, OperaSettings.UnhandledPromptBehaviour);
                System.out.format("Set Unhandled Prompt Behaviour to: %s", OperaSettings.UnhandledPromptBehaviour);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set Unhandled Prompt Behaviour to: %s", OperaSettings.UnhandledPromptBehaviour);
            System.out.println();

        }
    }


    private void SetOperaDriverService() {
        try {
            Builder = new OperaDriverService.Builder();
            //setDriverExecutable();
            setSilentRunning();
            setVerboseLogging();
            setPort();
            Service = Builder.build();
        } catch (Exception ex) {
            switch (BaseSettings.DebugLevel) {
                case Human:
                    System.out.println("Could not start the opera driver service.");
                    System.out.println("Please investigate the changes you have made to your config file.");
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

    private void setDriverExecutable() {
        try {
            if (BaseSettings.OperaDriverLocation != null && BaseSettings.OperaDriverLocation.length() > 0) {
                Builder.usingDriverExecutable(new File(BaseSettings.OperaDriverLocation));
                System.out.format("Set the driver executable using the location: %s", BaseSettings.OperaDriverLocation);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set the driver executable using the location: %s", BaseSettings.OperaDriverLocation);
            System.out.println();
        }
    }

    private void setSilentRunning() {
        try {
            if (OperaSettings.SuppressInitialDiagnosticInformation != null) {
                Builder.withSilent(OperaSettings.SuppressInitialDiagnosticInformation);
                System.out.format("Set silent running to: %s", OperaSettings.SuppressInitialDiagnosticInformation);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set silent running to: %s", OperaSettings.SuppressInitialDiagnosticInformation);
            System.out.println();
        }
    }

    private void setVerboseLogging() {
        try {
            if (OperaSettings.EnableVerboseLogging != null) {
                Builder.withVerbose(OperaSettings.EnableVerboseLogging);
                System.out.format("Set verbose logging to: %s", OperaSettings.EnableVerboseLogging.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set verbose logging to: %s", OperaSettings.EnableVerboseLogging.toString());
            System.out.println();
        }
    }

    private void setPort() {
        try {
            if (OperaSettings.Port != null && OperaSettings.Port > 0) {
                Builder.usingPort(OperaSettings.Port);
                System.out.format("Set port to: %s", OperaSettings.Port.toString());
                System.out.println();
            } else {
                Builder.usingAnyFreePort();
                System.out.println("Using any free port, as no specific port was chosen.");
            }
        } catch (Exception ex) {
            System.out.format("Could not set port to: %s", OperaSettings.Port.toString());
            System.out.println();
        }
    }
}
