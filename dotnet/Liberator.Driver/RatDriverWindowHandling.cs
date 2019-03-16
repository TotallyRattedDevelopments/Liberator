using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        #region Window Handlers

        /// <summary>
        /// Gets the Window Handle for the currently selected page
        /// </summary>
        /// <returns>A window handle representing a unique reference to a page</returns>
        public string GetCurrentWindowHandle()
        {
            try
            {
                var handle = Driver.CurrentWindowHandle;
                return handle;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot retrieve current window handle.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Switches to a window, given the name of that window
        /// </summary>
        /// <param name="windowName">The name of the window to switch to</param>
        public void SwitchToWindow(string windowName)
        {
            try
            {
                Driver.SwitchTo().Window(windowName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.GetType() == typeof(NoSuchWindowException))
                {
                    Console.WriteLine("Cannot switch to a window named {0}, as none are currently loaded with that name.", windowName);
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Gets the title of the currently active browser
        /// </summary>
        /// <returns>The name of the currently active window</returns>
        public string GetBrowserWindowTitle()
        {
            try
            {
                return Driver.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Unable to get the title of the browser that is in focus");
                if (Driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Gets the URL in the currently active browser window
        /// </summary>
        /// <returns>The URL for the browser</returns>
        public string GetBrowserWindowUrl()
        {
            try
            {
                return Driver.Url;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Gets a list of WindowHandles for all windows under the control of the current driver session
        /// </summary>
        /// <returns>A collection of WindowHandles</returns>
        public IEnumerable<string> GetAllWindowHandles()
        {
            try
            {
                return Driver.WindowHandles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Unable to get the title of the browser that is in focus");
                if (Driver.WindowHandles.Count == 0) { Console.WriteLine("No window is currently attached to the driver."); }
                HandleErrors(ex);
                return null;
            }
        }

        #endregion

        #region Window Control

        /// <summary>
        /// Opens a new window using the send keys command
        /// </summary>
        public void OpenNewView()
        {
            try
            {
                LastPage = FindElementByTag("body");
                Driver.ExecuteJavaScript("window.open();");
                Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                WindowHandles.Add(Driver.CurrentWindowHandle, Driver.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to open a new window.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Closes the currently selected window
        /// </summary>
        public void CloseView()
        {
            try
            {
                var winHandle = Driver.CurrentWindowHandle;
                LastPage = FindElementByTag("body");
                Driver.Close();
                Driver.SwitchTo().Window(WindowHandles.Last().Value);
                WindowHandles.Remove(winHandle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to close the current window.");
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Terminates the browser process attached to the current web driver
        /// </summary>
        public void TerminateBrowserProcess()
        {
            try
            {
                Process.GetProcessById(_browserPid).Kill();
            }
            catch (Exception)
            {
                Console.WriteLine("Error encountered when terminating the browser process.");
            }
        }

        /// <summary>
        /// Terminates the driver process attached to the current web driver
        /// </summary>
        public void TerminateDriverProcess()
        {
            try
            {
                Process.GetProcessById(_driverPid).Kill();
            }
            catch (Exception)
            {
                Console.WriteLine("Error encountered when terminating the driver process.");
            }
        }

        #endregion
    }
}
