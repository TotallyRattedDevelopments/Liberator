package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.EdgePreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.ChromeSettings;
import org.liberator.ratdriver.settings.EdgeSettings;
import org.liberator.ratdriver.settings.FirefoxSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.edge.EdgeDriverService;
import org.openqa.selenium.edge.EdgeOptions;

import java.io.File;

import static org.openqa.selenium.remote.CapabilityType.*;

public class EdgeControl extends BrowserControl {

    //region Public Properties


    public WebDriver Driver = null;


    private EdgeOptions Options;


    public EdgeDriverService Service = null;


    public EdgeDriverService.Builder Builder;

    //endregion


    //region Constructors


    public EdgeControl() {
        Options = new EdgeOptions();
    }


    public EdgeControl(EdgePreferences edgePreferences) {
        Options = new EdgeOptions();
        setImportedPreferences(edgePreferences);
    }

    private void setImportedPreferences(EdgePreferences edgePreferences) {
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
    }

    //endregion

    //region Public Methods

    /**
     * Starts a web driver
     *
     * @return A web driver instance
     */
    @Override
    public WebDriver StartDriver() {
        try {
            System.setProperty("webdriver.edge.driver", BaseSettings.EdgeDriverLocation);

            setEdgeOptions();
            setEdgeDriverService();

            if (Service != null && Options != null) {
                Driver = new EdgeDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new EdgeDriver(Service);
            } else if (Options != null) {
                Driver = new EdgeDriver(Options);
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
            System.setProperty("webdriver.edge.driver", BaseSettings.EdgeDriverLocation);
            setImportedPreferences((EdgePreferences) driverSettings);

            setEdgeOptions();
            setEdgeDriverService();

            if (Service != null && Options != null) {
                Driver = new EdgeDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new EdgeDriver(Service);
            } else if (Options != null) {
                Driver = new EdgeDriver(Options);
            }

            return Driver;
        } catch (Exception ex) {
            return null;
        }
    }

    private void setEdgeOptions() {
        try {
            Options = new EdgeOptions();
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
                Options.setPageLoadStrategy(String.valueOf(EdgeSettings.PageLoadStrategy));
                System.out.format("Set the page load strategy to: %s", EdgeSettings.PageLoadStrategy);
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set the page load strategy to: %s", EdgeSettings.PageLoadStrategy);
            System.out.println();
        }
    }

    private void setAcceptInsecureCertificates() {
        try {
            if (EdgeSettings.AcceptInsecureCertificates != null) {
                Options.setCapability(ACCEPT_INSECURE_CERTS, EdgeSettings.AcceptInsecureCertificates);
                System.out.format("Set accept insecure certificates to: %s", EdgeSettings.AcceptInsecureCertificates.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set accept insecure certificates to: %s", EdgeSettings.AcceptInsecureCertificates.toString());
            System.out.println();

        }
    }

    private void setSSLCertificates() {
        try {
            if (EdgeSettings.AcceptSSLCertificates != null) {
                Options.setCapability(ACCEPT_SSL_CERTS, EdgeSettings.AcceptSSLCertificates);
                System.out.format("Set accept SSL certificates to: %s", EdgeSettings.AcceptSSLCertificates.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set accept SSL certificates to: %s", EdgeSettings.AcceptSSLCertificates.toString());
            System.out.println();

        }
    }

    private void setTakesScreenshot() {
        try {
            if (EdgeSettings.TakesScreenshot != null) {
                Options.setCapability(TAKES_SCREENSHOT, EdgeSettings.TakesScreenshot);
                System.out.format("Set Takes Screenshot to: %s", EdgeSettings.TakesScreenshot.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set Takes Screenshot to: %s", EdgeSettings.TakesScreenshot.toString());
            System.out.println();

        }
    }

    private void setUnexpectedAlertBehaviour() {
        try {
            if (EdgeSettings.UnexpectedAlertBehaviour != null) {
                Options.setCapability(UNEXPECTED_ALERT_BEHAVIOUR, EdgeSettings.UnexpectedAlertBehaviour);
                System.out.format("Set Unexpected Alert Behaviour to: %s", EdgeSettings.UnexpectedAlertBehaviour);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set Unexpected Alert Behaviour to: %s", EdgeSettings.UnexpectedAlertBehaviour);
            System.out.println();

        }
    }

    private void setUnhandledPromptBehaviour() {
        try {
            if (EdgeSettings.UnhandledPromptBehaviour != null) {
                Options.setCapability(UNHANDLED_PROMPT_BEHAVIOUR, EdgeSettings.UnhandledPromptBehaviour);
                System.out.format("Set Unhandled Prompt Behaviour to: %s", EdgeSettings.UnhandledPromptBehaviour);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set Unhandled Prompt Behaviour to: %s", EdgeSettings.UnhandledPromptBehaviour);
            System.out.println();

        }
    }

    private void setEdgeDriverService() {
        try {
            Builder = new EdgeDriverService.Builder();
            setDriverExecutable();
            setDriverPort();
            Service = Builder.build();
            System.out.println("Created the Edge Driver Service.");
        } catch (Exception ex){
            System.out.println("Unable to create the Edge Driver Service.");
        }
    }

    private void setDriverExecutable() {
        try {
            Builder.usingDriverExecutable(new File(EdgeSettings.EdgeDriverLocation));
            System.out.format("Set the driver executable to: %s", EdgeSettings.EdgeDriverLocation);
            System.out.println();
        } catch (Exception e) {
            System.out.format("Unable to set the driver executable to: %s", EdgeSettings.EdgeDriverLocation);
            System.out.println();
        }
    }

    private void setDriverPort() {
        try {
            if (EdgeSettings.Port != null && EdgeSettings.Port > 0){
                Builder.usingPort(EdgeSettings.Port);
                System.out.format("Set port to: %s", EdgeSettings.Port.toString());
                System.out.println();
            } else if(EdgeSettings.Port != null) {
                Builder.usingAnyFreePort();
                System.out.println("Using any free port, as no specific port was chosen.");
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set the port to: %s", EdgeSettings.Port.toString());
            System.out.println();
        }
    }

    //endregion
}
