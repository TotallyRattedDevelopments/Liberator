using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Liberator.Driver.Enums;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        #region Handler

        /// <summary>
        /// Handles all caught exceptions
        /// </summary>
        /// <param name="ex">Exception which caused the method to be called</param>
        protected internal void HandleErrors(Exception ex)
        {
            Enum.TryParse(Preferences.BaseSettings.DebugLevel.ToString(), out _debugLevel);

            if (_debugLevel == EnumConsoleDebugLevel.Message || _debugLevel == EnumConsoleDebugLevel.StackTrace) { Console.Out.WriteLine(ex.Message); }
            if (_debugLevel == EnumConsoleDebugLevel.StackTrace) { Console.Out.WriteLine(ex.StackTrace); }

            if (ex.GetType() == typeof(LiberatorOSException))
            {
                Assert.Inconclusive("Browser/OS Incompatibility" + "\n\r");
                KillTestProcesses();
            }

            if (ex.GetType() == typeof(XPathLookupException)) { HandleXPathLookupException(); }
            if (ex.GetType() == typeof(NoSuchElementException)) { HandleNoSuchElementException(); }
            if (ex.GetType() == typeof(NotFoundException)) { HandleNoSuchElementException(); }
            if (ex.GetType() == typeof(StaleElementReferenceException)) { HandleStaleElementReferenceException(); }
            if (ex.GetType() == typeof(InvalidElementStateException)) { HandleInvalidElementStateException(); }
            if (ex.GetType() == typeof(InvalidSelectorException)) { HandleInvalidSelectorException(); }
            if (ex.GetType() == typeof(ElementNotVisibleException)) { HandleElementNotVisibleException(); }
            if (ex.GetType() == typeof(WebDriverTimeoutException))
            {
                HandleTimeouts(ex);
            }
            if (ex.GetType() == typeof(DriverServiceNotFoundException))
            {
                if (EqualityComparer<TWebDriver>.Default.Equals(Driver, default(TWebDriver))) { HandleNullDriverException(ex); }
                if (Driver != null) { HandleDriverServiceException(ex); }
            }
            if (ex.GetType() == typeof(WebDriverException))
            {
                if (EqualityComparer<TWebDriver>.Default.Equals(Driver, default(TWebDriver))) { HandleNullDriverException(ex); }
                if (Driver != null) { HandleGenericDriverException(ex); }
            }
        }

        #endregion

        #region Private Methods

        private void HandleElementNotVisibleException()
        {
            KillTestProcesses();
            Console.Out.WriteLine("The element {0} is not currently visible", Element.ToString());
            Assert.Fail("Required element is not visible. Test Fails.");
        }

        private void HandleInvalidSelectorException()
        {
            KillTestProcesses();
            Console.Out.WriteLine("The selector used is invalid. Please review and try again.");
            Assert.Fail("Selector provided to Selenium is invalid. Test Fails.");
        }

        private void HandleInvalidElementStateException()
        {
            KillTestProcesses();
            Console.Out.WriteLine("An action performed on the element {0} has reported an invalid state", Element.ToString());
            Assert.Fail("An action has caused an error. Test Fails.");
        }

        private void HandleStaleElementReferenceException()
        {
            KillTestProcesses();
            Console.Out.WriteLine("The reference to the WebElement {0} is no longer valid", Element.ToString());
            Console.Out.WriteLine("This may be because the page is reloading or the element reference has changed");
            Assert.Inconclusive("Element has become stale. Consider revising code. Test is inconclusive.");
        }

        private void HandleNoSuchElementException()
        {
            KillTestProcesses();
            Console.Out.WriteLine("The element being searched for has not been found on the current page");
            Console.Out.WriteLine("Current Page: {0}", Driver.Url);
            Console.Out.WriteLine("Target Element: {0}", Element.ToString());
            Assert.Fail("Expected element is not found on page. Test Fails.");
        }

        private void HandleXPathLookupException()
        {
            KillTestProcesses();
            Console.Out.WriteLine("The XPath Locator for a WebElement has resulted in an error.");
            Console.Out.WriteLine("Current Page: {0}", Driver.Url);
            Console.Out.WriteLine("Target Element: {0}", Element.ToString());
            Assert.Inconclusive("There has been an error with an XPath locator. Test is inconclusive.");
        }

        private void HandleNullDriverException(Exception ex)
        {
            KillTestProcesses();
            Console.Out.WriteLine("Driver is currently null and cannot complete the current action");
            Console.Out.WriteLine("Error was generated by {0}. Target of the code was {1}", ex.Source, ex.TargetSite.ToString());
            Assert.Inconclusive("Driver is null. Cannot complete. Test is inconclusive.");
        }

        private void HandleGenericDriverException(Exception ex)
        {
            KillTestProcesses();
            Console.Out.WriteLine("RatDriver is currently instantiated, but has encountered a exception.");
            Console.Out.WriteLine("Please debug your code. If correct, please contact us with a bug report.");
            Console.Out.WriteLine("Error was generated by {0}. Target of the code was {1}", ex.Source, ex.TargetSite.ToString());
            Assert.Inconclusive("Driver has thrown an exception. Test is inconclusive.");
        }

        private void HandleTimeouts(Exception ex)
        {
            KillTestProcesses();
            Console.Out.WriteLine("RatDriver has encountered a Timeout and cannot continue with the test.");
            Console.Out.WriteLine("The locator for the WebElement involved in the timeout is: {0}", "");
            Console.Out.WriteLine("Timeout was generated by {0}. Target of the code was {1}", ex.Source, ex.TargetSite.ToString());
            Assert.Fail("Timeout limit has been reached. Test fails.");
        }

        private void HandleDriverServiceException(Exception ex)
        {
            KillTestProcesses();
            Console.Out.WriteLine("The Driver Service is currently instantiated, but has generated an exception.");
            Console.Out.WriteLine("Please debug your code. If correct, please contact us with a bug report.");
            Console.Out.WriteLine("Error was generated by {0}. Target of the code was {1}", ex.Source, ex.TargetSite.ToString());
            Assert.Inconclusive("Driver service has thrown an exception. Test is inconclusive.");
        }

        private void HandleAlertException(Exception ex)
        {
            KillTestProcesses();
            bool alertHandling = Preferences.BaseSettings.AlertHandling;
            Console.Out.WriteLine("An unanticipated alert has been displayed by the browser, {0}", Driver.GetType().ToString());
            Console.Out.WriteLine("Current configuration settings indicate that Alert Handling is set to {0}", alertHandling.ToString());
            if (alertHandling)
            {
                Console.Out.WriteLine("Please debug your code. If correct, please contact us with a bug report.");
            }
            Console.Out.WriteLine("Error was generated by {0}. Target of the code was {1}", ex.Source, ex.TargetSite.ToString());
            Assert.Inconclusive("An unknown error has caused the test to fail. Test is inconclusive.");
        }

        #endregion
    }

    internal class LiberatorOSException : Exception
    {
        public LiberatorOSException()
        {
        }

        public LiberatorOSException(string message)
            : base(message)
        {
            Console.Out.WriteLine(message);
        }

        public LiberatorOSException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
