package org.liberator.ratdriver.control;

import org.liberator.ratdriver.ErrorHandler;
import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.EdgePreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.EdgeSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.edge.EdgeDriverService;
import org.openqa.selenium.edge.EdgeOptions;

import java.io.File;

import static org.openqa.selenium.remote.CapabilityType.*;

public class EdgeControl extends RemoteControl {

    //region Public Properties


    public WebDriver driver = null;


    private EdgeOptions options;


    public EdgeDriverService service = null;


    public EdgeDriverService.Builder builder;

    //endregion


    //region Constructors


    public EdgeControl(EdgePreferences edgePreferences) {
        options = new EdgeOptions();
        setImportedPreferences(edgePreferences);
    }

    private void setImportedPreferences(EdgePreferences edgePreferences) {
        try {
            if (edgePreferences != null) {

                EdgeSettings.Timeout = edgePreferences.Timeout;
                EdgeSettings.AsyncJavaScript = edgePreferences.AsyncJavaScript;
                EdgeSettings.DebugLevel = edgePreferences.DebugLevel;
                EdgeSettings.ImplicitWait = edgePreferences.ImplicitWait;
                EdgeSettings.PageLoad = edgePreferences.PageLoad;
                EdgeSettings.AlertHandling = edgePreferences.AlertHandling;
                EdgeSettings.InternalTimers = edgePreferences.InternalTimers;
                EdgeSettings.MenuHoverTime = edgePreferences.MenuHoverTime;
                EdgeSettings.Sleep = edgePreferences.Sleep;

                EdgeSettings.HideCommandPromptWindow = edgePreferences.HideCommandPromptWindow;
                EdgeSettings.Host = edgePreferences.Host;
                EdgeSettings.Package = edgePreferences.Package;
                EdgeSettings.Port = edgePreferences.Port;
                EdgeSettings.SuppressInitialDiagnosticInformation = edgePreferences.SuppressInitialDiagnosticInformation;
                EdgeSettings.UseVerboseLogging = edgePreferences.UseVerboseLogging;
            }
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "EdgeControl",
                    "setImportedPreferences",
                    "Unable to import preferences."
            );
        }
    }

    //endregion

    //region Public Methods

    /**
     * Starts a web driver
     *
     * @return A web driver instance
     */
    public WebDriver startDriver() {
        try {
            System.setProperty("webdriver.edge.driver", BaseSettings.EdgeDriverLocation);

            setEdgeOptions();
            setEdgeDriverService();

            if (service != null && options != null) {
                driver = new EdgeDriver(service, options);
            } else if (options == null && service != null) {
                driver = new EdgeDriver(service);
            } else if (options != null) {
                driver = new EdgeDriver(options);
            }

            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "EdgeControl",
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
            System.setProperty("webdriver.edge.driver", BaseSettings.EdgeDriverLocation);
            setImportedPreferences((EdgePreferences) driverSettings);
            startDriver();
            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "EdgeControl",
                    "startDriver",
                    "Unable to instantiate driver."
            );
            return null;
        }
    }

    private void setEdgeOptions() {
        try {
            options = new EdgeOptions();
            setPageLoadStrategy();
            setAcceptInsecureCertificates();
            setSSLCertificates();
            setTakesScreenshot();
            setUnexpectedAlertBehaviour();
            setUnhandledPromptBehaviour();
            System.out.println("Options set for Edge Driver.");
        } catch (Exception ex) {
            System.out.println("Could not set the options of the Edge Driver.");
        }
    }

    private void setPageLoadStrategy() {
        try {
            if (EdgeSettings.PageLoadStrategy != null) {
                options.setPageLoadStrategy(String.valueOf(EdgeSettings.PageLoadStrategy));
                System.out.format("\nSet the page load strategy to: %s", EdgeSettings.PageLoadStrategy);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set the page load strategy to: %s", EdgeSettings.PageLoadStrategy);
        }
    }

    private void setAcceptInsecureCertificates() {
        try {
            if (EdgeSettings.AcceptInsecureCertificates != null) {
                options.setCapability(ACCEPT_INSECURE_CERTS, EdgeSettings.AcceptInsecureCertificates);
                System.out.format("\nSet accept insecure certificates to: %s", EdgeSettings.AcceptInsecureCertificates.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set accept insecure certificates to: %s", EdgeSettings.AcceptInsecureCertificates.toString());

        }
    }

    private void setSSLCertificates() {
        try {
            if (EdgeSettings.AcceptSSLCertificates != null) {
                options.setCapability(ACCEPT_SSL_CERTS, EdgeSettings.AcceptSSLCertificates);
                System.out.format("\nSet accept SSL certificates to: %s", EdgeSettings.AcceptSSLCertificates.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set accept SSL certificates to: %s", EdgeSettings.AcceptSSLCertificates.toString());

        }
    }

    private void setTakesScreenshot() {
        try {
            if (EdgeSettings.TakesScreenshot != null) {
                options.setCapability(TAKES_SCREENSHOT, EdgeSettings.TakesScreenshot);
                System.out.format("\nSet Takes Screenshot to: %s", EdgeSettings.TakesScreenshot.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set Takes Screenshot to: %s", EdgeSettings.TakesScreenshot.toString());

        }
    }

    private void setUnexpectedAlertBehaviour() {
        try {
            if (EdgeSettings.UnexpectedAlertBehaviour != null) {
                options.setCapability(UNEXPECTED_ALERT_BEHAVIOUR, EdgeSettings.UnexpectedAlertBehaviour);
                System.out.format("\nSet Unexpected Alert Behaviour to: %s", EdgeSettings.UnexpectedAlertBehaviour);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set Unexpected Alert Behaviour to: %s", EdgeSettings.UnexpectedAlertBehaviour);

        }
    }

    private void setUnhandledPromptBehaviour() {
        try {
            if (EdgeSettings.UnhandledPromptBehaviour != null) {
                options.setCapability(UNHANDLED_PROMPT_BEHAVIOUR, EdgeSettings.UnhandledPromptBehaviour);
                System.out.format("\nSet Unhandled Prompt Behaviour to: %s", EdgeSettings.UnhandledPromptBehaviour);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set Unhandled Prompt Behaviour to: %s", EdgeSettings.UnhandledPromptBehaviour);

        }
    }

    private void setEdgeDriverService() {
        try {
            builder = new EdgeDriverService.Builder();
            setDriverExecutable();
            setDriverPort();
            service = builder.build();
            System.out.println("Created the Edge Driver Service.");
        } catch (Exception ex){
            System.out.println("Unable to create the Edge Driver Service.");
        }
    }

    private void setDriverExecutable() {
        try {
            builder.usingDriverExecutable(new File(EdgeSettings.EdgeDriverLocation));
            System.out.format("\nSet the driver executable to: %s", EdgeSettings.EdgeDriverLocation);
        } catch (Exception e) {
            System.out.format("\nUnable to set the driver executable to: %s", EdgeSettings.EdgeDriverLocation);
        }
    }

    private void setDriverPort() {
        try {
            if (EdgeSettings.Port != null && EdgeSettings.Port > 0){
                builder.usingPort(EdgeSettings.Port);
                System.out.format("\nSet port to: %s", EdgeSettings.Port.toString());
            } else if(EdgeSettings.Port != null) {
                builder.usingAnyFreePort();
                System.out.println("Using any free port, as no specific port was chosen.");
            }
        } catch (Exception e) {
            System.out.format("\nCould not set the port to: %s", EdgeSettings.Port.toString());
        }
    }

    //endregion
}
