package org.liberator.ratdriver.control;

import lombok.Getter;
import lombok.Setter;
import org.liberator.ratdriver.ErrorHandler;
import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.OperaPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.FirefoxSettings;
import org.liberator.ratdriver.settings.OperaSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.opera.OperaDriver;
import org.openqa.selenium.opera.OperaDriverService;
import org.openqa.selenium.opera.OperaOptions;

import java.util.Arrays;

import static org.openqa.selenium.remote.CapabilityType.*;

public class OperaControl extends RemoteControl {

    //region Public Properties

    /**
     * Holds the preset values for Opera Options
     */
    @Getter
    @Setter
    public OperaOptions operaOptions;

    /**
     * The Internet Explorer driver service
     */
    @Getter
    @Setter
    public OperaDriverService operaDriverService;

    /**
     * Holds the instantiated Opera Driver
     */
    @Getter
    @Setter
    public WebDriver driver;

    /**
     * The maximum amount of time to wait between commands
     */
    @Getter
    @Setter
    public Integer commandTimeout;

    private OperaDriverService.Builder builder;

    //endregion

    //region Constructor

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
        try {
            if (operaPreferences != null) {
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
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "OperaControl",
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
            System.setProperty("webdriver.opera.driver", BaseSettings.OperaDriverLocation);

            setOperaOptions();
            setOperaDriverService();
            setProxy();

            if (operaDriverService != null && operaOptions != null) {
                driver = new OperaDriver(operaDriverService, operaOptions);
            } else if (operaOptions == null && operaDriverService != null) {
                driver = new OperaDriver(operaDriverService);
            } else if (operaOptions != null) {
                driver = new OperaDriver(operaOptions);
            }
            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "OperaControl",
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
            setImportedPreferences((OperaPreferences) driverSettings);
            System.setProperty("webdriver.opera.driver", FirefoxSettings.OperaDriverLocation);

            startDriver();

            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "OperaControl",
                    "startDriver",
                    "Unable to instantiate driver."
            );
            return null;
        }
    }


    private void setOperaOptions() {
        try {
            operaOptions = new OperaOptions();
            operaOptions.setBinary(BaseSettings.OperaLocation);
            operaOptions.addArguments("--remote-debugging-port=9222");
            operaOptions.addArguments("start-maximized");
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
                operaOptions.setCapability(ACCEPT_INSECURE_CERTS, OperaSettings.AcceptInsecureCertificates);
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
                operaOptions.setCapability(ACCEPT_SSL_CERTS, OperaSettings.AcceptSSLCertificates);
                System.out.format("\nSet accept SSL certificates to: %s", OperaSettings.AcceptSSLCertificates.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set accept SSL certificates to: %s", OperaSettings.AcceptSSLCertificates.toString());

        }
    }

    private void setPageLoadStrategy() {
        try {
            if (OperaSettings.PageLoadStrategy != null) {
                operaOptions.setCapability(PAGE_LOAD_STRATEGY, OperaSettings.PageLoadStrategy);
                System.out.format("\nSet page load strategy to: %s", OperaSettings.PageLoadStrategy);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set page load strategy to: %s", OperaSettings.PageLoadStrategy);

        }
    }

    private void setTakesScreenshot() {
        try {
            if (OperaSettings.TakesScreenshot != null) {
                operaOptions.setCapability(TAKES_SCREENSHOT, OperaSettings.TakesScreenshot);
                System.out.format("\nSet Takes Screenshot to: %s", OperaSettings.TakesScreenshot.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set Takes Screenshot to: %s", OperaSettings.TakesScreenshot.toString());

        }
    }

    private void setUnexpectedAlertBehaviour() {
        try {
            if (OperaSettings.UnexpectedAlertBehaviour != null) {
                operaOptions.setCapability(UNEXPECTED_ALERT_BEHAVIOUR, OperaSettings.UnexpectedAlertBehaviour);
                System.out.format("\nSet Unexpected Alert Behaviour to: %s", OperaSettings.UnexpectedAlertBehaviour);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set Unexpected Alert Behaviour to: %s", OperaSettings.UnexpectedAlertBehaviour);

        }
    }

    private void setUnhandledPromptBehaviour() {
        try {
            if (OperaSettings.UnhandledPromptBehaviour != null) {
                operaOptions.setCapability(UNHANDLED_PROMPT_BEHAVIOUR, OperaSettings.UnhandledPromptBehaviour);
                System.out.format("\nSet Unhandled Prompt Behaviour to: %s", OperaSettings.UnhandledPromptBehaviour);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set Unhandled Prompt Behaviour to: %s", OperaSettings.UnhandledPromptBehaviour);

        }
    }


    private void setOperaDriverService() {
        try {
            builder = new OperaDriverService.Builder();
            setSilentRunning();
            setVerboseLogging();
            setPort();
            operaDriverService = builder.build();
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

    private void setSilentRunning() {
        try {
            if (OperaSettings.SuppressInitialDiagnosticInformation != null) {
                builder.withSilent(OperaSettings.SuppressInitialDiagnosticInformation);
                System.out.format("\nSet silent running to: %s", OperaSettings.SuppressInitialDiagnosticInformation);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set silent running to: %s", OperaSettings.SuppressInitialDiagnosticInformation);
        }
    }

    private void setVerboseLogging() {
        try {
            if (OperaSettings.EnableVerboseLogging != null) {
                builder.withVerbose(OperaSettings.EnableVerboseLogging);
                System.out.format("\nSet verbose logging to: %s", OperaSettings.EnableVerboseLogging.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set verbose logging to: %s", OperaSettings.EnableVerboseLogging.toString());
        }
    }

    private void setPort() {
        try {
            if (OperaSettings.Port != null && OperaSettings.Port > 0) {
                builder.usingPort(OperaSettings.Port);
                System.out.format("\nSet port to: %s", OperaSettings.Port.toString());
            } else {
                builder.usingAnyFreePort();
                System.out.println("Using any free port, as no specific port was chosen.");
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set port to: %s", OperaSettings.Port.toString());
        }
    }
}
