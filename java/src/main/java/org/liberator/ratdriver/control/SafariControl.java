package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.SafariPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.SafariSettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.safari.SafariDriver;
import org.openqa.selenium.safari.SafariDriverService;
import org.openqa.selenium.safari.SafariOptions;

import java.io.File;

public class SafariControl extends BrowserControl {

    public SafariOptions Options;

    public SafariDriverService.Builder Builder;

    public SafariDriverService Service;

    public SafariControl() {
    }

    public SafariControl(BasePreferences preferences) {
    }

    public WebDriver StartDriver() {
        try {
            System.setProperty("webdriver.safari.driver", BaseSettings.SafariDriverLocation);

            setSafariOptions();
            setSafariService();

            if (Service != null && Options != null) {
                Driver = new SafariDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new SafariDriver(Service);
            } else if (Options != null) {
                Driver = new SafariDriver(Options);
            }

            System.out.println("Started safari driver.");
            return Driver;
        } catch (Exception ex) {
            System.out.println("Could not start safari driver.");
            return null;
        }
    }

    public WebDriver StartDriver(BasePreferences preferences) {
        try {
            System.setProperty("webdriver.safari.driver", BaseSettings.SafariDriverLocation);
            setImportedPreferences((SafariPreferences) preferences);

            setSafariOptions();
            setSafariService();

            if (Service != null && Options != null) {
                Driver = new SafariDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new SafariDriver(Service);
            } else if (Options != null) {
                Driver = new SafariDriver(Options);
            }

            System.out.println("Started safari driver.");
            return Driver;
        } catch (Exception ex) {
            System.out.println("Could not start safari driver.");
            return null;
        }
    }

    private void setImportedPreferences(SafariPreferences preferences){
        if (preferences != null){

        }
    }

    private void setSafariOptions() {
        try {
            Options = new SafariOptions();
            setAutomaticInspection();
            setAutomaticProfiling();
            setTechnologyPreview();
        } catch (Exception ex) {
            System.out.println();
        }
    }

    private void setSafariService() {
        try {
            Builder = new SafariDriverService.Builder();
            if (BaseSettings.SafariDriverLocation != null || SafariSettings.Port > 0) {
                setDriverExecutable();
                setDriverPort();
                Service = Builder.build();
                System.out.println("Built Safari Driver Service");
            }
        } catch (Exception ex) {
            System.out.println("Could not build Safari Driver Service");
        }
    }

    private void setDriverExecutable() {
        try {
            if (BaseSettings.SafariDriverLocation != null && BaseSettings.SafariDriverLocation.length() > 0) {
                Builder.usingDriverExecutable(new File(BaseSettings.SafariDriverLocation));
                System.out.format("Added the driver executable at: %s", BaseSettings.SafariDriverLocation);
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not add the driver executable at: %s", BaseSettings.SafariDriverLocation);
            System.out.println();
        }
    }

    private void setDriverPort() {
        try {
            if (SafariSettings.Port != null && SafariSettings.Port > 0) {
                Builder.usingPort(SafariSettings.Port);
                System.out.format("Added port %s to the driver.", SafariSettings.Port.toString());
            } else {
                Builder.usingAnyFreePort();
                System.out.println("Used any free port for driver service.");
            }
            System.out.println();
        } catch (Exception ex) {
            System.out.println("Could not assign port to driver.");
        }
    }

    private void setAutomaticInspection() {
        try {
            if (SafariSettings.AutomaticInspection != null) {
                Options.setAutomaticInspection(SafariSettings.AutomaticInspection);
                System.out.format("Set automatic inspection to: %s", SafariSettings.AutomaticInspection.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set automatic inspection to: %s", SafariSettings.AutomaticInspection.toString());
            System.out.println();
        }
    }

    private void setAutomaticProfiling() {
        try {
            if (SafariSettings.AutomaticProfiling != null) {
                Options.setAutomaticProfiling(SafariSettings.AutomaticProfiling);
                System.out.format("Set automatic profiling to: %s", SafariSettings.AutomaticProfiling.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set automatic profiling to: %s", SafariSettings.AutomaticProfiling.toString());
            System.out.println();
        }
    }

    private void setTechnologyPreview() {
        try {
            if (SafariSettings.TechnologyPreview != null) {
                Options.setAutomaticProfiling(SafariSettings.TechnologyPreview);
                System.out.format("Set technology preview to: %s", SafariSettings.TechnologyPreview.toString());
                System.out.println();
            }
        } catch (Exception ex) {
            System.out.format("Could not set technology preview to: %s", SafariSettings.TechnologyPreview.toString());
            System.out.println();
        }
    }
}
