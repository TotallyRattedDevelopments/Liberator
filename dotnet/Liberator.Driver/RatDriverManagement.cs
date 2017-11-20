using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        /// <summary>
        /// Gets a reference to the encapsulated IWebDriver
        /// </summary>
        /// <returns>The encapsulated IWebDriver</returns>
        public IWebDriver ReturnEncapsulatedDriver()
        {
            return Driver;
        }

        /// <summary>
        /// Checks if a cookie exists
        /// </summary>
        /// <param name="cookieName">The name of the cookie to check for</param>
        /// <returns>A boolean value indicating whether the cookie exists</returns>
        public bool CheckCookieExists(string cookieName)
        {
            try
            {
                GetCookieNamed(cookieName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        public void AddCookie(string name, string value)
        {
            try
            {
                if (typeof(TWebDriver) != typeof(PhantomJSDriver) && typeof(TWebDriver) != typeof(InternetExplorerDriver))
                {
                    _driver.Manage().Cookies.AddCookie(new Cookie(name, value));
                }
                else if (typeof(TWebDriver) == typeof(InternetExplorerDriver))
                {
                    string script = "document.cookie='" + name + "=" + value + "'";
                    _driver.ExecuteJavaScript(script);
                }
                else
                {
                    ICookieJar cookieJar = Driver.Manage().Cookies;
                    cookieJar.AddCookie(new Cookie(name, value));
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        public void AddCookie(string name, string value, string path)
        {
            try
            {
                _driver.Manage().Cookies.AddCookie(new Cookie(name, value, path));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        public void AddCookie(string name, string value, string path, DateTime expiry)
        {
            try
            {
                _driver.Manage().Cookies.AddCookie(new Cookie(name, value, path, expiry));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        /// <param name="domain">The domain for which the cookie is being added</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        public void AddCookie(string name, string value, string domain, string path, DateTime expiry)
        {
            try
            {
                _driver.Manage().Cookies.AddCookie(new Cookie(name, value, domain, path, expiry));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(InvalidCookieDomainException))
                {
                    Console.WriteLine("An attempt was made to set the {0} cookie for the domain {1}, which is not currently loaded.", name, domain);
                }
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Adds a predefined cookie to the current browser session
        /// </summary>
        /// <param name="cookie">The cookie to be added</param>
        public void AddCookie(Cookie cookie)
        {
            try
            {
                _driver.Manage().Cookies.AddCookie(cookie);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(InvalidCookieDomainException))
                {
                    Console.WriteLine("An attempt was made to set the {0} cookie for the domain {1}, which is not currently loaded.", cookie.Name, cookie.Domain);
                }
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", cookie.Name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Gets a list of cookies currently saved by the browser
        /// </summary>
        /// <returns>The list of cookies</returns>
        public IEnumerable<Cookie> GetCookies()
        {
            try
            {
                return _driver.Manage().Cookies.AllCookies;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to acquire the collection of cookies from the browser.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Deletes all cookies currently found in the browser
        /// </summary>
        public void DeleteAllCookies()
        {
            try
            {
                _driver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to delete cookies from the browser.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Deletes a cookie, given a copy of that cookie
        /// </summary>
        /// <param name="cookie">The definition of the cookie to be deleted</param>
        public void DeleteCookie(Cookie cookie)
        {
            try
            {
                _driver.Manage().Cookies.DeleteCookie(cookie);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to delete cookie {0} from the browser.", cookie.Name);
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Deletes a named cookie
        /// </summary>
        /// <param name="cookie">The name of the cookie</param>
        public void DeleteCookieNamed(string cookie)
        {
            try
            {
                _driver.Manage().Cookies.DeleteCookieNamed(cookie);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Unable to delete the '{0}' cookie.", cookie);
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Gets a cookie from the browser
        /// </summary>
        /// <param name="cookie">The name of the cookie to find</param>
        /// <returns>The named cookie</returns>
        public Cookie GetCookieNamed(string cookie)
        {
            try
            {
                return _driver.Manage().Cookies.GetCookieNamed(cookie);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get the '{0}' cookie.", cookie);
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        public void ReplaceCookie(string name, string value)
        {
            try
            {
                DeleteCookieNamed(name);
                AddCookie(name, value);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        public void ReplaceCookie(string name, string value, string path)
        {
            try
            {
                DeleteCookieNamed(name);
                AddCookie(name, value, path);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        public void ReplaceCookie(string name, string value, string path, DateTime expiry)
        {
            try
            {
                DeleteCookieNamed(name);
                AddCookie(name, value, path, expiry);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        /// <param name="domain">The domain for which the cookie is being added</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        public void ReplaceCookie(string name, string value, string domain, string path, DateTime expiry)
        {
            try
            {
                DeleteCookieNamed(name);
                AddCookie(name, value, domain, path, expiry);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(InvalidCookieDomainException))
                {
                    Console.WriteLine("An attempt was made to set the {0} cookie for the domain {1}, which is not currently loaded.", name, domain);
                }
                if (ex.GetType() == typeof(UnableToSetCookieException))
                {
                    Console.WriteLine("Unable to set the cookie {0} as requested", name);
                    if (Driver.Url == null) { Console.WriteLine("The driver is not currently set with a URL"); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Gets a list of available log types
        /// </summary>
        /// <returns>The list of log types</returns>
        public IEnumerable<string> GetAvailableLogTypes()
        {
            try
            {
                if (Driver.GetType() == typeof(FirefoxDriver) || Driver.GetType() == typeof(EdgeDriver) || Driver.GetType() == typeof(InternetExplorerDriver))
                {
                    Console.WriteLine("Logs are not currently available for Firefox, IE or Edge");
                    return null;
                }
                return _driver.Manage().Logs.AvailableLogTypes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to retrieve the current list of available log types for the {0} browser.", Driver.GetType().Name);
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Gets the available log entries for a particular log type
        /// </summary>
        /// <param name="logKind">The type of log to consult</param>
        /// <returns>The list of log entries</returns>
        public IEnumerable<LogEntry> GetAvailableLogEntries(string logKind)
        {
            try
            {
                return _driver.Manage().Logs.GetLog(logKind);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get the log entries of '{0}' type from the {1} browser.", logKind, Driver.GetType().Name);
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Sets the implicit wait via a method.
        /// </summary>
        /// <param name="minutes">The number of minutes in the  implicit wait</param>
        /// <param name="seconds">The number of seconds in the  implicit wait</param>
        /// <param name="milliseconds">The number of milliseconds in the  implicit wait</param>
        public void SetImplicitWait(int minutes, int seconds, int milliseconds)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, minutes, seconds, milliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to set the implicit wait property.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Sets the page load timeout via a method.
        /// </summary>
        /// <param name="minutes">The number of minutes in the  page load timeout</param>
        /// <param name="seconds">The number of seconds in the  page load timeout</param>
        /// <param name="milliseconds">The number of milliseconds in the page load timeout</param>
        public void SetPageLoadTimeout(int minutes, int seconds, int milliseconds)
        {
            try
            {
                _driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, minutes, seconds, milliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to set the page load timeout property.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Sets the script timeout via a method.
        /// </summary>
        /// <param name="minutes">The number of minutes in the script timeout</param>
        /// <param name="seconds">The number of seconds in the script timeout</param>
        /// <param name="milliseconds">The number of milliseconds in the script timeout</param>
        public void SetScriptTimeout(int minutes, int seconds, int milliseconds)
        {
            try
            {
                _driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, minutes, seconds, milliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to set the asynchronous java script property.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Maximises the current window
        /// </summary>
        public void MaximiseView()
        {
            try
            {
                _driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                if (Driver.GetType() == typeof(FirefoxDriver))
                {
                    Console.WriteLine("Firefox 54 has introduces an issue which causes incorrect error messages on maximise.");
                }
                else
                {
                    Console.WriteLine("Unable to Maximise Window.");
                    if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                    HandleErrors(ex);
                }
            }
        }

        /// <summary>
        /// Gets the current window position
        /// </summary>
        /// <returns>A tuple containing the x and y coordinates of the top left corner of the window</returns>
        public Tuple<int, int> GetWindowPosition()
        {
            try
            {
                int x = _driver.Manage().Window.Position.X;
                int y = _driver.Manage().Window.Position.Y;
                return new Tuple<int, int>(x, y);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get current window position.");
                if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Gets the current window size
        /// </summary>
        /// <returns>A tuple containing the width and height of the current window</returns>
        public Tuple<int, int> GetWindowSize()
        {
            try
            {
                int x = _driver.Manage().Window.Size.Width;
                int y = _driver.Manage().Window.Size.Height;
                return new Tuple<int, int>(x, y);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get current window size.");
                if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Resizes the browser window to the assigned width and height
        /// </summary>
        /// <param name="width">The width to assign to the browser</param>
        /// <param name="height">The height to assign to the browser</param>
        public void ResizeBrowserWindow(int width, int height)
        {
            try
            {
                Driver.Manage().Window.Size = new Size(width, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get set the current window size.");
                if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Presses the back button of the browser
        /// </summary>
        public void PressBackButton()
        {
            try
            {
                _lastPage = _driver.FindElement(By.TagName("html"));
                _driver.Navigate().Back();
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.StalenessOf(_lastPage));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to press the back button.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Presses the forward button of the browser
        /// </summary>
        public void PressForwardButton()
        {
            try
            {
                _lastPage = _driver.FindElement(By.TagName("html"));
                _driver.Navigate().Forward();
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.StalenessOf(_lastPage));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to press the forward button.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Navigates to a particular website by URL
        /// </summary>
        /// <param name="url">The URL of the website to load in the browser</param>
        public void NavigateToPage(string url)
        {
            try
            {
                IWebElement currentPage = Driver.FindElement(By.TagName("html"));
                _driver.Navigate().GoToUrl(url);
                WaitForPageToLoad(currentPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to navigate to the page '{0}'.", url);
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Navigates to a particular website by URI
        /// </summary>
        /// <param name="url">The URI object of the website to load in the browser</param>
        public void NavigateToPage(Uri url)
        {
            try
            {
                IWebElement currentPage = Driver.FindElement(By.TagName("html"));
                _driver.Navigate().GoToUrl(url);
                WaitForPageToLoad(currentPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to navigate to the page '{0}'.", url.ToString());
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Refreshes the currently selected browser
        /// </summary>
        public void RefreshBrowser()
        {
            try
            {
                _driver.Navigate().Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to refresh the browser.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Checks the entire html source for the page for a piece of text
        /// </summary>
        /// <param name="text">The text to search the page for</param>
        /// <returns>Whether the page contains the text</returns>
        public bool CheckPageSourceForText(string text)
        {
            try
            {
                return _driver.PageSource.Contains(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to find the text '{0}' in the source code of the page.", text);
                HandleErrors(ex);
                return false;
            }
        }

        /// <summary>
        /// Gets the source code for the page
        /// </summary>
        /// <returns>The Page Source</returns>
        public string GetPageSource()
        {
            try
            {
                return _driver.PageSource;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get the source code of the page.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Closes the browser pages and quits the driver
        /// </summary>
        public void ClosePagesAndQuitDriver()
        {
            try
            {
                if (Driver.GetType() != typeof(OperaDriver))
                {
                    foreach (string handle in Driver.WindowHandles)
                    {
                        _driver.SwitchTo().Window(handle);
                        _driver.Close();
                    } 
                }
                _driver.Quit();
                KillDrivers();
            }
            catch (Exception ex)
            {
                if (Driver.GetType() == typeof(FirefoxDriver))
                {
                    Console.WriteLine("Error message due to a anomaly in either geckodriver or firefox pertaining to closing the driver");
                }
                else
                {
                    Console.WriteLine("Unable to close all associated browser windows. Please review test code and browser status.");
                    HandleErrors(ex);
                }

            }
        }

        /// <summary>
        /// Checks if a window is open, using its window handle
        /// </summary>
        /// <param name="window">The window handle to query</param>
        /// <returns>A true/false value</returns>
        public bool IsWindowOpen(string window)
        {
            try
            {
                return Driver.WindowHandles.Contains(window);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Switches to the currently active WebElement
        /// </summary>
        public void SwitchToActiveWebElement()
        {
            try
            {
                _driver.SwitchTo().ActiveElement();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to switch to the active element");
                if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to the currently active Alert Dialog
        /// </summary>
        public void SwitchToAlertDialog()
        {
            try
            {
                _driver.SwitchTo().Alert();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoAlertPresentException))
                {
                    Console.WriteLine("Unable to switch to an alert dialog as one is not present on on the current page.");
                }
                if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to the original frame or window
        /// </summary>
        public void SwitchToDefaultContent()
        {
            try
            {
                _driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to switch the focus of the driver back to the default content.");
                if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to a numbered frame by index
        /// </summary>
        /// <param name="frameIndex">The index number for the frame</param>
        public void SwitchToFrame(int frameIndex)
        {
            try
            {
                _driver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoSuchFrameException))
                {
                    Console.WriteLine("Unable to switch to the requested frame, as there is no frame with an index of {0}", frameIndex);
                    if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to the frame identified by the WebElement
        /// </summary>
        /// <param name="frameElement">A WebElement representing the frame to activate</param>
        public void SwitchToFrame(IWebElement frameElement)
        {
            Element = frameElement;
            try
            {
                _driver.SwitchTo().Frame(Element);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoSuchFrameException))
                {
                    Console.WriteLine("Unable to switch to the requested frame, as there is no frame with the passed description");
                    if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to the frame identified by the WebElement
        /// </summary>
        /// <param name="frameLocator">The locator for the WebElement representing the frame to activate</param>
        public void SwitchToFrame(By frameLocator)
        {
            Locator = frameLocator;
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocator));
                Element = _driver.FindElement(frameLocator);
                _driver.SwitchTo().Frame(Element);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoSuchFrameException))
                {
                    Console.WriteLine("Unable to switch to the requested frame, as there is no frame with the description {0}", frameLocator);
                    if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to the frame identified by the WebElement
        /// </summary>
        /// <param name="frameName">The name of the frame to activate</param>
        public void SwitchToFrame(string frameName)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Name(frameName)));
                _driver.SwitchTo().Frame(frameName);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoSuchFrameException))
                {
                    Console.WriteLine("Unable to switch to the requested frame, as there is no frame with the name {0}", frameName);
                    if (_driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Switches to the parent frame of a selected WebElement
        /// </summary>
        public void SwitchToParentFrame()
        {
            try
            {
                _driver.SwitchTo().ParentFrame();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NoSuchFrameException))
                {
                    Console.WriteLine("Cannot switch to a parent frame as the current frame does not have a parent");
                }
                HandleErrors(ex);
            }
        }



        private void KillDrivers()
        {
            Process[] processList = Process.GetProcesses();
            foreach (Process item in processList)
            {
                if (item.ProcessName.Contains("geckodriver") ||
                    item.ProcessName.Contains("chromedriver") ||
                    item.ProcessName.Contains("MicrosoftWebDriver") ||
                    item.ProcessName.Contains("opera") ||
                    item.ProcessName.Contains("phantomjs") ||
                    item.ProcessName.Contains("IEDriverServer") ||
                    item.ProcessName.Contains("iexplore.exe"))
                {
                    item.Kill();
                }
            }
        }
    }
}
