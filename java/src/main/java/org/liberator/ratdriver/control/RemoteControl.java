package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.openqa.selenium.Proxy;
import org.openqa.selenium.WebDriver;

public class RemoteControl extends BrowserControl {

    public WebDriver startDriver() {
        return null;
    }

    public WebDriver startDriver(BasePreferences preferences) {
        return null;
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
        } catch (Exception ex) {
            System.out.println("Could not set up the proxy with current settings.");
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
                System.out.format("\nSet 'no proxy' to: %s", BaseSettings.noProxy);
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
            System.out.format("\nCould not set socks proxy to.");
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
}
