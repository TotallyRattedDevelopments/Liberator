package org.liberator.ratdriver.control;

import org.liberator.ratdriver.ErrorHandler;
import org.liberator.ratdriver.preferences.BasePreferences;
import org.liberator.ratdriver.preferences.IEPreferences;
import org.liberator.ratdriver.settings.BaseSettings;
import org.liberator.ratdriver.settings.IESettings;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.ie.InternetExplorerDriverService;
import org.openqa.selenium.ie.InternetExplorerOptions;

import java.io.File;

public class IEControl extends RemoteControl {

//region Public Properties

    /**
     * Holds the preset values for Internet Explorer Options
     */
    public InternetExplorerOptions internetExplorerOptions;

    /**
     * The Internet Explorer driver service
     */
    public InternetExplorerDriverService internetExplorerDriverService;

    /**
     * The builder for the IE Driver Service
     */
    public InternetExplorerDriverService.Builder builder;

    public WebDriver driver;

    //endregion

    //region Constructor



    /**
     * Allows the specification of Internet Explorer Driver settings
     *
     * @param iePreferences The settings file to be used.
     */
    public IEControl(IEPreferences iePreferences) {
        setImportedPreferences(iePreferences);
    }

    /**
     * Sets the imported preferences as standard settings
     * @param iePreferences The settings file to be used.
     */
    private void setImportedPreferences(IEPreferences iePreferences) {
        try {
            if (iePreferences != null) {

                IESettings.Timeout = iePreferences.Timeout;
                IESettings.AsyncJavaScript = iePreferences.AsyncJavaScript;
                IESettings.DebugLevel = iePreferences.DebugLevel;
                IESettings.ImplicitWait = iePreferences.ImplicitWait;
                IESettings.PageLoad = iePreferences.PageLoad;
                IESettings.AlertHandling = iePreferences.AlertHandling;
                IESettings.InternalTimers = iePreferences.InternalTimers;
                IESettings.MenuHoverTime = iePreferences.MenuHoverTime;
                IESettings.Sleep = iePreferences.Sleep;

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
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "IEControl",
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
            System.setProperty("webdriver.ie.driver", BaseSettings.InternetExplorerDriverLocation);

            setOptions();
            setService();
            setProxy();

            if (internetExplorerDriverService != null && internetExplorerOptions != null) {
                driver = new InternetExplorerDriver(internetExplorerDriverService, internetExplorerOptions);
            } else if (internetExplorerOptions == null && internetExplorerDriverService != null) {
                driver = new InternetExplorerDriver(internetExplorerDriverService);
            } else if (internetExplorerOptions != null) {
                driver = new InternetExplorerDriver(internetExplorerOptions);
            }

            System.out.println("Starting IE Driver.");
            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "IEControl",
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
            System.setProperty("webdriver.ie.driver", BaseSettings.InternetExplorerDriverLocation);

            setImportedPreferences((IEPreferences) driverSettings);
            startDriver();

            return driver;
        } catch (Exception exception) {
            ErrorHandler.HandleErrors(
                    driver,
                    exception,
                    "IEControl",
                    "startDriver",
                    "Unable to instantiate driver."
            );
            return null;
        }
    }

    private void setOptions() {
        try {
            internetExplorerOptions = new InternetExplorerOptions();
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
                internetExplorerOptions.setPageLoadStrategy(IESettings.PageLoadStrategy);
                System.out.format("\nSet page load strategy to: %s", IESettings.PageLoadStrategy.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set page load strategy to: %s", IESettings.PageLoadStrategy.toString());
        }
    }

    private void setUnhandledPromptBehaviour() {
        try {
            if (IESettings.UnexpectedAlertBehavior != null) {
                internetExplorerOptions.setUnhandledPromptBehaviour(IESettings.UnexpectedAlertBehavior);
                System.out.format("\nSet unhandled prompt behaviour to: %s", IESettings.UnexpectedAlertBehavior.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set unhandled prompt behaviour to: %s", IESettings.UnexpectedAlertBehavior.toString());
        }
    }

    private void addCommandSwitches() {
        try {
            if (IESettings.CommandLineArguments != null && IESettings.CommandLineArguments.length() > 0) {
                internetExplorerOptions.addCommandSwitches(IESettings.CommandLineArguments);
                System.out.format("\nSet command line arguments to: %s", IESettings.CommandLineArguments);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set command line arguments to: %s", IESettings.CommandLineArguments);
        }
    }

    private void setEnsureCleanSession() {
        try {
            if (IESettings.EnsureCleanSession != null) {
                internetExplorerOptions.destructivelyEnsureCleanSession();
                System.out.format("\nSet ensure clean session to: %s", IESettings.EnsureCleanSession.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set ensure clean session to: %s", IESettings.EnsureCleanSession.toString());
        }
    }

    private void setDisableNativeEvents() {
        try {
            if (IESettings.EnableNativeEvents != null && !IESettings.EnableNativeEvents) {
                internetExplorerOptions.disableNativeEvents();
                System.out.format("\nSet native events to: %s", IESettings.EnableNativeEvents.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set native events to: %s", IESettings.EnableNativeEvents.toString());
        }
    }

    private void setScrollBehaviour() {
        try {
            if (IESettings.ScrollBehavior != null && IESettings.ScrollBehavior.toString().length() > 0) {
                internetExplorerOptions.elementScrollTo(IESettings.ScrollBehavior);
                System.out.format("\nSet element scroll behaviour to: %s", IESettings.ScrollBehavior.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set element scroll behaviour to: %s", IESettings.ScrollBehavior.toString());
        }
    }

    private void setPersistentHovering() {
        try {
            if (IESettings.EnablePersistentHover != null && IESettings.EnablePersistentHover) {
                internetExplorerOptions.enablePersistentHovering();
                System.out.format("\nSet persistent hovering to: %s", IESettings.EnablePersistentHover.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set persistent hovering to: %s", IESettings.EnablePersistentHover.toString());
        }
    }

    private void setIgnoreZoom() {
        try {
            if (IESettings.IgnoreZoomLevel != null && IESettings.IgnoreZoomLevel) {
                internetExplorerOptions.ignoreZoomSettings();
                System.out.format("\nSet ignore zoom to: %s", IESettings.IgnoreZoomLevel.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set ignore zoom to: %s", IESettings.IgnoreZoomLevel.toString());
        }
    }

    private void setIntroduceFlakiness() {
        try {
            if (IESettings.IntroduceInstability != null && IESettings.IntroduceInstability) {
                internetExplorerOptions.introduceFlakinessByIgnoringSecurityDomains();
                System.out.format("\nSet introduce flakiness by ignoring security domains to: %s", IESettings.IntroduceInstability.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set introduce flakiness by ignoring security domains to: %s", IESettings.IntroduceInstability.toString());
        }
    }

    private void setRequireFocus() {
        try {
            if (IESettings.RequireWindowFocus != null && IESettings.RequireWindowFocus) {
                internetExplorerOptions.requireWindowFocus();
                System.out.format("\nSet require window focus to: %s", IESettings.RequireWindowFocus.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set require window focus to: %s", IESettings.RequireWindowFocus.toString());
        }
    }

    private void setFullPageScreenshot() {
        try {
            if (IESettings.EnableFullPageScreenshot != null && IESettings.EnableFullPageScreenshot) {
                internetExplorerOptions.takeFullPageScreenshot();
                System.out.format("\nSet enable full page screenshot to: %s", IESettings.EnableFullPageScreenshot.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set enable full page screenshot to: %s", IESettings.EnableFullPageScreenshot.toString());
        }
    }

    private void setCreateProcessApi() {
        try {
            if (IESettings.ForceCreateProcessApi != null && IESettings.ForceCreateProcessApi) {
                internetExplorerOptions.useCreateProcessApiToLaunchIe();
                System.out.format("\nSet create process API to launch IE to: %s", IESettings.ForceCreateProcessApi.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set create process API to launch IE to: %s", IESettings.ForceCreateProcessApi.toString());
        }
    }

    private void setShellWindowsApi() {
        try {
            if (IESettings.ForceShellWindowsApi != null && IESettings.ForceShellWindowsApi) {
                internetExplorerOptions.useShellWindowsApiToAttachToIe();
                System.out.format("\nSet use shell windows API to attach to IE to: %s", IESettings.ForceShellWindowsApi.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set use shell windows API to attach to IE to: %s", IESettings.ForceShellWindowsApi.toString());
        }
    }

    private void setUploadDialogTimeout() {
        try {
            if (IESettings.FileUploadTimeout != null && IESettings.FileUploadTimeout.getSeconds() > 0) {
                internetExplorerOptions.waitForUploadDialogUpTo(IESettings.FileUploadTimeout);
                System.out.format("\nSet file upload timeout to: %s seconds" , IESettings.FileUploadTimeout.getSeconds());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set create process API to launch IE to: %s seconds", IESettings.FileUploadTimeout.getSeconds());
        }
    }

    private void setAttachTimeout() {
        try {
            if (IESettings.AttachTimeout != null && IESettings.AttachTimeout.getSeconds() > 0) {
                internetExplorerOptions.withAttachTimeout(IESettings.AttachTimeout);
                System.out.format("\nSet the attach timeout to: %s", IESettings.AttachTimeout.getSeconds());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set the attach timeout to: %s", IESettings.AttachTimeout.getSeconds());
        }
    }

    private void setInitialBrowserUrl() {
        try {
            if (IESettings.InitialBrowserUrl != null && IESettings.InitialBrowserUrl.length() > 0) {
                internetExplorerOptions.withInitialBrowserUrl(IESettings.InitialBrowserUrl);
                System.out.format("\nSet the initial browser URL to: %s", IESettings.InitialBrowserUrl);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set the initial browser URL to: %s", IESettings.InitialBrowserUrl);
        }
    }

    private void setService() {
        try {
            builder = new InternetExplorerDriverService.Builder();
            if (IESettings.SuppressInitialDiagnosticInformation != null || IESettings.Host != null ||
            IESettings.LibraryExtractionPath != null || IESettings.LoggingLevel != null) {
                setSilentRunning();
                setHost();
                setExtractPath();
                setLoggingLevel();
                internetExplorerDriverService = builder.build();
            }
        } catch (Exception ex){
            System.out.println("Could not set the Internet Explorer Driver Service.");
        }
    }

    private void setSilentRunning() {
        try {
            if (IESettings.SuppressInitialDiagnosticInformation != null){
                builder.withSilent(IESettings.SuppressInitialDiagnosticInformation);
                System.out.format("\nSet silent running to: %s", IESettings.SuppressInitialDiagnosticInformation.toString());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set silent running to: %s", IESettings.SuppressInitialDiagnosticInformation.toString());
        }
    }

    private void setHost() {
        try {
            if (IESettings.Host != null && IESettings.Host.length() > 0){
                builder.withHost(IESettings.Host);
                System.out.format("\nSet host to: %s", IESettings.Host);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set host to: %s", IESettings.Host);
        }
    }

    private void setExtractPath() {
        try {
            if (IESettings.LibraryExtractionPath != null && IESettings.LibraryExtractionPath.length() > 0){
                builder.withExtractPath(new File(IESettings.LibraryExtractionPath));
                System.out.format("\nSet library extraction path to: %s", IESettings.LibraryExtractionPath);
            }
        } catch (Exception e) {
            System.out.format("\nCould not set library extraction path to: %s", IESettings.LibraryExtractionPath);
        }
    }

    private void setLoggingLevel() {
        try {
            if (IESettings.LoggingLevel != null){
                builder.withLogLevel(IESettings.LoggingLevel);
                System.out.format("\nSet logging level to: %s", IESettings.LoggingLevel.name());
            }
        } catch (Exception e) {
            System.out.format("\nCould not set logging level to: %s", IESettings.LoggingLevel.name());
        }

    }
}
