package org.liberator.ratdriver.control;

import org.liberator.ratdriver.ErrorHandler;
import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.SafariPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.SafariSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.safari.SafariDriver;
import org.openqa.selenium.safari.SafariDriverService;
import org.openqa.selenium.safari.SafariOptions;

import java.io.File;

public class SafariControl extends RemoteControl {

    public SafariOptions safariOptions;

    public SafariDriverService.Builder builder;

    public SafariDriverService safariDriverService;

    public WebDriver driver;

    public SafariControl(BasePreferences preferences) {
        setImportedPreferences((SafariPreferences) preferences);
    }

    public WebDriver startDriver() {
        try {
            System.setProperty("webdriver.safari.driver", BaseSettings.SafariDriverLocation);

            setSafariOptions();
            setSafariService();
            setProxy();

            if (safariDriverService != null && safariOptions != null) {
                driver = new SafariDriver(safariDriverService, safariOptions);
            } else if (safariOptions == null && safariDriverService != null) {
                driver = new SafariDriver(safariDriverService);
            } else if (safariOptions != null) {
                driver = new SafariDriver(safariOptions);
            }

            System.out.println("Started safari driver.");
            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "SafariControl",
                    "startDriver",
                    "Unable to instantiate driver."
            );
            return null;
        }
    }

    public WebDriver startDriver(BasePreferences preferences) {
        try {
            System.setProperty("webdriver.safari.driver", BaseSettings.SafariDriverLocation);
            setImportedPreferences((SafariPreferences) preferences);
            startDriver();
            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "SafariControl",
                    "startDriver",
                    "Unable to instantiate driver."
            );
            return null;
        }
    }

    private void setImportedPreferences(SafariPreferences safariPreferences) {
        try {
            if (safariPreferences != null) {
                SafariSettings.Timeout = safariPreferences.Timeout;
                SafariSettings.AsyncJavaScript = safariPreferences.AsyncJavaScript;
                SafariSettings.DebugLevel = safariPreferences.DebugLevel;
                SafariSettings.ImplicitWait = safariPreferences.ImplicitWait;
                SafariSettings.PageLoad = safariPreferences.PageLoad;
                SafariSettings.AlertHandling = safariPreferences.AlertHandling;
                SafariSettings.InternalTimers = safariPreferences.InternalTimers;
                SafariSettings.MenuHoverTime = safariPreferences.MenuHoverTime;
                SafariSettings.Sleep = safariPreferences.Sleep;

                SafariSettings.Port = safariPreferences.Port;
                SafariSettings.TechnologyPreview = safariPreferences.TechnologyPreview;
                SafariSettings.AutomaticInspection = safariPreferences.AutomaticInspection;
                SafariSettings.AutomaticProfiling = safariPreferences.AutomaticProfiling;
            }
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "SafariControl",
                    "setImportedPreferences",
                    "Unable to instantiate driver."
            );
        }
    }

    private void setSafariOptions() {
        try {
            safariOptions = new SafariOptions();
            setAutomaticInspection();
            setAutomaticProfiling();
            setTechnologyPreview();
        } catch (Exception ex) {
            System.out.println();
        }
    }

    private void setSafariService() {
        try {
            builder = new SafariDriverService.Builder();
            if (BaseSettings.SafariDriverLocation != null || SafariSettings.Port > 0) {
                setDriverExecutable();
                setDriverPort();
                safariDriverService = builder.build();
                System.out.println("Built Safari Driver Service");
            }
        } catch (Exception ex) {
            System.out.println("Could not build Safari Driver Service");
        }
    }

    private void setDriverExecutable() {
        try {
            if (BaseSettings.SafariDriverLocation != null && BaseSettings.SafariDriverLocation.length() > 0) {
                builder.usingDriverExecutable(new File(BaseSettings.SafariDriverLocation));
                System.out.format("\nAdded the driver executable at: %s", BaseSettings.SafariDriverLocation);
            }
        } catch (Exception ex) {
            System.out.format("\nCould not add the driver executable at: %s", BaseSettings.SafariDriverLocation);
        }
    }

    private void setDriverPort() {
        try {
            if (SafariSettings.Port != null && SafariSettings.Port > 0) {
                builder.usingPort(SafariSettings.Port);
                System.out.format("\nAdded port %s to the driver.", SafariSettings.Port.toString());
            } else {
                builder.usingAnyFreePort();
                System.out.println("\nUsed any free port for driver service.");
            }
            System.out.println();
        } catch (Exception ex) {
            System.out.println("\nCould not assign port to driver.");
        }
    }

    private void setAutomaticInspection() {
        try {
            if (SafariSettings.AutomaticInspection != null) {
                safariOptions.setAutomaticInspection(SafariSettings.AutomaticInspection);
                System.out.format("\nSet automatic inspection to: %s", SafariSettings.AutomaticInspection.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set automatic inspection to: %s", SafariSettings.AutomaticInspection.toString());
        }
    }

    private void setAutomaticProfiling() {
        try {
            if (SafariSettings.AutomaticProfiling != null) {
                safariOptions.setAutomaticProfiling(SafariSettings.AutomaticProfiling);
                System.out.format("\nSet automatic profiling to: %s", SafariSettings.AutomaticProfiling.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set automatic profiling to: %s", SafariSettings.AutomaticProfiling.toString());
        }
    }

    private void setTechnologyPreview() {
        try {
            if (SafariSettings.TechnologyPreview != null) {
                safariOptions.setAutomaticProfiling(SafariSettings.TechnologyPreview);
                System.out.format("\nSet technology preview to: %s", SafariSettings.TechnologyPreview.toString());
            }
        } catch (Exception ex) {
            System.out.format("\nCould not set technology preview to: %s", SafariSettings.TechnologyPreview.toString());
        }
    }
}
