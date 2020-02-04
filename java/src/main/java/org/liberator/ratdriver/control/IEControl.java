package org.liberator.ratdriver.control;

import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.IEPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.IESettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.edge.EdgeDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.ie.InternetExplorerDriverService;
import org.openqa.selenium.ie.InternetExplorerOptions;

import java.io.File;

public class IEControl extends BrowserControl {

//region Public Properties

    /**
     * Holds the preset values for Internet Explorer Options
     */
    public InternetExplorerOptions Options = null;

    /**
     * The Internet Explorer driver service
     */
    public InternetExplorerDriverService Service = null;

    public InternetExplorerDriverService.Builder Builder;

    /**
     * Holds the instantiated Internet Explorer Driver
     */
    public WebDriver Driver = null;


    /**
     * The maximum sleep interval
     */
    public Integer SleepInterval = null;

    /**
     * The maximum time to wait for the browser to load
     */
    public Integer BrowserTimeout = null;

    /**
     * The maximum amount of time to wait between commands
     */
    public Integer CommandTimeout = null;

    //endregion

    //region Constructor


    /**
     *
     */
    public IEControl() {
    }


    /**
     * Allows the specification of Internet Explorer Driver settings
     *
     * @param iePreferences The settings file to be used.
     */
    public IEControl(IEPreferences iePreferences) {
        setImportedPreferences(iePreferences);
    }

    private void setImportedPreferences(IEPreferences iePreferences) {
        if (iePreferences != null) {
            IESettings.CommandLineArguments = iePreferences.CommandLineArguments;
            IESettings.EnableFullPageScreenshot = iePreferences.EnableFullPageScreenshot;
            IESettings.EnableNativeEvents = iePreferences.EnableNativeEvents;
            IESettings.EnablePersistentHover = iePreferences.EnablePersistentHover;
            IESettings.EnsureCleanSession = iePreferences.EnsureCleanSession;
            IESettings.FileUploadTimeout = iePreferences.FileUploadTimeout;
            IESettings.ForceCreateProcessApi = iePreferences.ForceCreateProcessApi;
            IESettings.ForceShellWindowsApi = iePreferences.ForceShellWindowsApi;
            IESettings.FtpProxy = iePreferences.FtpProxy;
            IESettings.HideCommandPromptWindow = iePreferences.HideCommandPromptWindow;
            IESettings.Host = iePreferences.Host;
            IESettings.HttpProxy = iePreferences.HttpProxy;
            IESettings.IgnoreZoomLevel = iePreferences.IgnoreZoomLevel;
            IESettings.InitialBrowserUrl = iePreferences.InitialBrowserUrl;
            IESettings.IntroduceInstability = iePreferences.IntroduceInstability;
            IESettings.IsAutoDetect = iePreferences.IsAutoDetect;
            IESettings.LibraryExtractionPath = iePreferences.LibraryExtractionPath;
            IESettings.LogFile = iePreferences.LogFile;
            IESettings.LoggingLevel = iePreferences.LoggingLevel;
            IESettings.NoProxy = iePreferences.NoProxy;
            IESettings.PageLoadStrategy = iePreferences.PageLoadStrategy;
            IESettings.Port = iePreferences.Port;
            IESettings.ProxyAutoConfigUrl = iePreferences.ProxyAutoConfigUrl;
            IESettings.ProxyKind = iePreferences.ProxyKind;
            IESettings.RequireWindowFocus = iePreferences.RequireWindowFocus;
            IESettings.ScrollBehavior = iePreferences.ScrollBehavior;
            IESettings.SocksPassword = iePreferences.SocksPassword;
            IESettings.SocksProxy = iePreferences.SocksProxy;
            IESettings.SocksUserName = iePreferences.SocksUserName;
            IESettings.SslProxy = iePreferences.SslProxy;
            IESettings.SuppressInitialDiagnosticInformation = iePreferences.SuppressInitialDiagnosticInformation;
            IESettings.UnexpectedAlertBehavior = iePreferences.UnexpectedAlertBehavior;
            IESettings.UsePerProcessProxy = iePreferences.UsePerProcessProxy;
            IESettings.WhitelistedIPAddresses = iePreferences.WhitelistedIPAddresses;
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
            System.setProperty("webdriver.ie.driver", BaseSettings.InternetExplorerDriverLocation);

            setOptions();
            setService();

            if (Service != null && Options != null) {
                Driver = new InternetExplorerDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new InternetExplorerDriver(Service);
            } else if (Options != null) {
                Driver = new InternetExplorerDriver(Options);
            }

            System.out.println("Starting IE Driver.");
            return Driver;
        } catch (Exception ex) {
            System.out.println("Unable to start IE Driver.");
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
            System.setProperty("webdriver.ie.driver", BaseSettings.InternetExplorerDriverLocation);

            setImportedPreferences((IEPreferences) driverSettings);
            setOptions();
            setService();

            if (Service != null && Options != null) {
                Driver = new InternetExplorerDriver(Service, Options);
            } else if (Options == null && Service != null) {
                Driver = new InternetExplorerDriver(Service);
            } else if (Options != null) {
                Driver = new InternetExplorerDriver(Options);
            }

            System.out.println("Starting IE Driver.");
            return Driver;
        } catch (Exception ex) {
            System.out.println("Unable to start IE Driver.");
            return null;
        }
    }

    private void setOptions() {
        try {
            Options = new InternetExplorerOptions();
            setPageLoadStrategy();
            setUnhandledPromptBehaviour();
            addCommandSwitches();
            setEnsureCleanSession();
            setDisableNativeEvents();
            setScrollBehaviour();
            setPersistentHovering();
            setIgnoreZoom();
            setIntroduceFlakiness();
            setRequireFocus();
            setFullPageScreenshot();
            setCreateProcessApi();
            setShellWindowsApi();
            setUploadDialogTimeout();
            setAttachTimeout();
            setInitialBrowserUrl();
        } catch (Exception ex) {
            System.out.println("Unable to set the options for IE Driver.");
        }
    }

    private void setPageLoadStrategy() {
        try {
            if (IESettings.PageLoadStrategy != null) {
                Options.setPageLoadStrategy(IESettings.PageLoadStrategy);
                System.out.format("Set page load strategy to: %s", IESettings.PageLoadStrategy.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set page load strategy to: %s", IESettings.PageLoadStrategy.toString());
            System.out.println();
        }
    }

    private void setUnhandledPromptBehaviour() {
        try {
            if (IESettings.UnexpectedAlertBehavior != null) {
                Options.setUnhandledPromptBehaviour(IESettings.UnexpectedAlertBehavior);
                System.out.format("Set unhandled prompt behaviour to: %s", IESettings.UnexpectedAlertBehavior.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set unhandled prompt behaviour to: %s", IESettings.UnexpectedAlertBehavior.toString());
            System.out.println();
        }
    }

    private void addCommandSwitches() {
        try {
            if (IESettings.CommandLineArguments != null && IESettings.CommandLineArguments.length() > 0) {
                Options.addCommandSwitches(IESettings.CommandLineArguments);
                System.out.format("Set command line arguments to: %s", IESettings.CommandLineArguments.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set command line arguments to: %s", IESettings.CommandLineArguments.toString());
            System.out.println();
        }
    }

    private void setEnsureCleanSession() {
        try {
            if (IESettings.EnsureCleanSession != null) {
                Options.destructivelyEnsureCleanSession();
                System.out.format("Set ensure clean session to: %s", IESettings.EnsureCleanSession.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set ensure clean session to: %s", IESettings.EnsureCleanSession.toString());
            System.out.println();
        }
    }

    private void setDisableNativeEvents() {
        try {
            if (IESettings.EnableNativeEvents != null && !IESettings.EnableNativeEvents) {
                Options.disableNativeEvents();
                System.out.format("Set native events to: %s", IESettings.EnableNativeEvents.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set native events to: %s", IESettings.EnableNativeEvents.toString());
            System.out.println();
        }
    }

    private void setScrollBehaviour() {
        try {
            if (IESettings.ScrollBehavior != null && IESettings.ScrollBehavior.toString().length() > 0) {
                Options.elementScrollTo(IESettings.ScrollBehavior);
                System.out.format("Set element scroll behaviour to: %s", IESettings.ScrollBehavior.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set element scroll behaviour to: %s", IESettings.ScrollBehavior.toString());
            System.out.println();
        }
    }

    private void setPersistentHovering() {
        try {
            if (IESettings.EnablePersistentHover != null && IESettings.EnablePersistentHover) {
                Options.enablePersistentHovering();
                System.out.format("Set persistent hovering to: %s", IESettings.EnablePersistentHover.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set persistent hovering to: %s", IESettings.EnablePersistentHover.toString());
            System.out.println();
        }
    }

    private void setIgnoreZoom() {
        try {
            if (IESettings.IgnoreZoomLevel != null && IESettings.IgnoreZoomLevel) {
                Options.ignoreZoomSettings();
                System.out.format("Set ignore zoom to: %s", IESettings.IgnoreZoomLevel.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set ignore zoom to: %s", IESettings.IgnoreZoomLevel.toString());
            System.out.println();
        }
    }

    private void setIntroduceFlakiness() {
        try {
            if (IESettings.IntroduceInstability != null && IESettings.IntroduceInstability) {
                Options.introduceFlakinessByIgnoringSecurityDomains();
                System.out.format("Set introduce flakiness by ignoring security domains to: %s", IESettings.IntroduceInstability.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set introduce flakiness by ignoring security domains to: %s", IESettings.IntroduceInstability.toString());
            System.out.println();
        }
    }

    private void setRequireFocus() {
        try {
            if (IESettings.RequireWindowFocus != null && IESettings.RequireWindowFocus) {
                Options.requireWindowFocus();
                System.out.format("Set require window focus to: %s", IESettings.RequireWindowFocus.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set require window focus to: %s", IESettings.RequireWindowFocus.toString());
            System.out.println();
        }
    }

    private void setFullPageScreenshot() {
        try {
            if (IESettings.EnableFullPageScreenshot != null && IESettings.EnableFullPageScreenshot) {
                Options.takeFullPageScreenshot();
                System.out.format("Set enable full page screenshot to: %s", IESettings.EnableFullPageScreenshot.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set enable full page screenshot to: %s", IESettings.EnableFullPageScreenshot.toString());
            System.out.println();
        }
    }

    private void setCreateProcessApi() {
        try {
            if (IESettings.ForceCreateProcessApi != null && IESettings.ForceCreateProcessApi) {
                Options.useCreateProcessApiToLaunchIe();
                System.out.format("Set create process API to launch IE to: %s", IESettings.ForceCreateProcessApi.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set create process API to launch IE to: %s", IESettings.ForceCreateProcessApi.toString());
            System.out.println();
        }
    }

    private void setShellWindowsApi() {
        try {
            if (IESettings.ForceShellWindowsApi != null && IESettings.ForceShellWindowsApi) {
                Options.useShellWindowsApiToAttachToIe();
                System.out.format("Set use shell windows API to attach to IE to: %s", IESettings.ForceShellWindowsApi.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set use shell windows API to attach to IE to: %s", IESettings.ForceShellWindowsApi.toString());
            System.out.println();
        }
    }

    private void setUploadDialogTimeout() {
        try {
            if (IESettings.FileUploadTimeout != null && IESettings.FileUploadTimeout.getSeconds() > 0) {
                Options.waitForUploadDialogUpTo(IESettings.FileUploadTimeout);
                System.out.format("Set file upload timeout to: %s seconds" , IESettings.FileUploadTimeout.getSeconds());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set create process API to launch IE to: %s seconds", IESettings.FileUploadTimeout.getSeconds());
            System.out.println();
        }
    }

    private void setAttachTimeout() {
        try {
            if (IESettings.AttachTimeout != null && IESettings.AttachTimeout.getSeconds() > 0) {
                Options.withAttachTimeout(IESettings.AttachTimeout);
                System.out.format("Set the attach timeout to: %s", IESettings.AttachTimeout.getSeconds());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set the attach timeout to: %s", IESettings.AttachTimeout.getSeconds());
            System.out.println();
        }
    }

    private void setInitialBrowserUrl() {
        try {
            if (IESettings.InitialBrowserUrl != null && IESettings.InitialBrowserUrl.length() > 0) {
                Options.withInitialBrowserUrl(IESettings.InitialBrowserUrl);
                System.out.format("Set the initial browser URL to: %s", IESettings.InitialBrowserUrl);
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set the initial browser URL to: %s", IESettings.InitialBrowserUrl);
            System.out.println();
        }
    }

    private void setService() {
        try {
            Builder = new InternetExplorerDriverService.Builder();
            if (IESettings.SuppressInitialDiagnosticInformation != null || IESettings.Host != null ||
            IESettings.LibraryExtractionPath != null || IESettings.LoggingLevel != null) {
                setSilentRunning();
                setHost();
                setExtractPath();
                setLoggingLevel();
                Service = Builder.build();
            }
        } catch (Exception ex){
            System.out.println("Could not set the Internet Explorer Driver Service.");
        }
    }

    private void setSilentRunning() {
        try {
            if (IESettings.SuppressInitialDiagnosticInformation != null){
                Builder.withSilent(IESettings.SuppressInitialDiagnosticInformation);
                System.out.format("Set silent running to: %s", IESettings.SuppressInitialDiagnosticInformation.toString());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set silent running to: %s", IESettings.SuppressInitialDiagnosticInformation.toString());
            System.out.println();
        }
    }

    private void setHost() {
        try {
            if (IESettings.Host != null && IESettings.Host.length() > 0){
                Builder.withHost(IESettings.Host);
                System.out.format("Set host to: %s", IESettings.Host);
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set host to: %s", IESettings.Host);
            System.out.println();
        }
    }

    private void setExtractPath() {
        try {
            if (IESettings.LibraryExtractionPath != null && IESettings.LibraryExtractionPath.length() > 0){
                Builder.withExtractPath(new File(IESettings.LibraryExtractionPath));
                System.out.format("Set library extraction path to: %s", IESettings.LibraryExtractionPath);
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set library extraction path to: %s", IESettings.LibraryExtractionPath);
            System.out.println();
        }
    }

    private void setLoggingLevel() {
        try {
            if (IESettings.LoggingLevel != null){
                Builder.withLogLevel(IESettings.LoggingLevel);
                System.out.format("Set logging level to: %s", IESettings.LoggingLevel.name());
                System.out.println();
            }
        } catch (Exception e) {
            System.out.format("Could not set logging level to: %s", IESettings.LoggingLevel.name());
            System.out.println();
        }

    }
}
