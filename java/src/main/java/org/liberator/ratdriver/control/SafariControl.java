package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.SafariPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.OperaSettings;
import org.liberator.ratdriver.settings.SafariSettings;
import org.openqa.selenium.Proxy;
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
        setImportedPreferences((SafariPreferences) preferences);
    }

    public WebDriver StartDriver() {
        try {
            System.setProperty("webdriver.safari.driver", BaseSettings.SafariDriverLocation);

            setSafariOptions();
            setSafariService();
            setProxy();

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
            setProxy();

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

    private void setImportedPreferences(SafariPreferences safariPreferences){
        if (safariPreferences != null){
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
