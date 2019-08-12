using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="element">The element for which to wait</param>
        public void WaitForElementToLoad(IWebElement element)
        {
            Element = element;
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions
                    .ElementToBeClickable(element));
            }
            catch (Exception ex)
            {
                if (_debugLevel == EnumConsoleDebugLevel.Human)
                {
                    Console.Out.WriteLine("Unable to complete wait for element correctly.");
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        public void WaitForElementToLoad(By locator)
        {
            Locator = locator;
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(locator)));
            }
            catch (Exception ex)
            {
                if (_debugLevel == EnumConsoleDebugLevel.Human)
                {
                    Console.Out.WriteLine("Unable to complete wait for element correctly.");
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="element">The element for which to wait</param>
        /// <param name="seconds">Maximum number of seconds to wait</param>
        public void WaitForElementToLoad(IWebElement element, int seconds)
        {
            Element = element;
            try
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, seconds, 0);
                var wait = new WebDriverWait(Driver, timeSpan)
                    .Until(ExpectedConditions
                    .ElementToBeClickable(element));
            }
            catch (Exception ex)
            {
                if (_debugLevel == EnumConsoleDebugLevel.Human)
                {
                    Console.Out.WriteLine("Unable to complete wait for element correctly.");
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        /// <param name="seconds">Maximum number of seconds to wait</param>
        public void WaitForElementToLoad(By locator, int seconds)
        {
            Locator = locator;
            try
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, seconds, 0);
                var wait = new WebDriverWait(this.Driver, timeSpan)
                    .Until(ExpectedConditions
                    .ElementToBeClickable(Driver.FindElement(locator)));
            }
            catch (Exception ex)
            {
                if (_debugLevel == EnumConsoleDebugLevel.Human)
                {
                    Console.Out.WriteLine("Unable to complete wait for element correctly.");
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Waits for an element to disappear from the DOM
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        public void WaitForInvisibilityOfElement(By locator)
        {
            Locator = locator;
            try
            {
                bool wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions
                    .InvisibilityOfElementLocated(locator));
                if (wait) { throw new TimeoutException("Item has not disappeared as required by the test code."); }
            }
            catch (Exception ex)
            {
                if (_debugLevel == EnumConsoleDebugLevel.Human)
                {
                    Console.Out.WriteLine("Unable to complete wait for element correctly.");
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Waits for an element containing text to disappear from the DOM
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        /// <param name="text">The text that should be found in the element</param>
        public void WaitForInvisibilityOfElementWithText(By locator, string text)
        {
            Locator = locator;
            try
            {
                bool wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions
                    .InvisibilityOfElementWithText(locator, text));
                if (wait) { throw new TimeoutException("The invisibility of the element conatining the text specified cannot be ascertained."); }
            }
            catch (Exception ex)
            {
                if (_debugLevel == EnumConsoleDebugLevel.Human)
                {
                    Console.Out.WriteLine("Unable to complete wait for element correctly.");
                }
                HandleErrors(ex);
            }
        }

        /// <summary>
        /// Waits for an alert style duialog to be displayed
        /// </summary>
        /// <returns>True if the wait terminates with an alert being found</returns>
        public bool WaitForAlertToBePresent()
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions.AlertIsPresent());
                if (wait == null) { throw new Exception("Could not confirm alert was displayed."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks for the state of an alert to be as expected
        /// </summary>
        /// <param name="state">True if the alert is to be displayed</param>
        /// <returns>True if the wait terminates with the alert in the correct state</returns>
        public bool WaitForAlertToBeInState(bool state)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions.AlertState(state));
                if (wait != state) { throw new Exception("Could not confirm alert state."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to reach a clickable state
        /// </summary>
        /// <param name="element">The IWebElement representing the object</param>
        /// <returns>True if the wait is terminated by the element becoming clickable</returns>
        public bool WaitForElementToBeClickable(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions.ElementToBeClickable(element));
                if (wait == null) { throw new Exception("Could not confirm clickability of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to reach a clickable state
        /// </summary>
        /// <param name="locator">The locator for the IWebElement representing the object</param>
        /// <returns>True if the wait is terminated by the element becoming clickable</returns>
        public bool WaitForElementToBeClickable(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout)
                    .Until(ExpectedConditions.ElementToBeClickable(locator));
                if (wait == null) { throw new Exception("Could not confirm clickability of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to exist in the DOM
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to exist</returns>
        public bool WaitForElementToExist(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementExists(locator));
                if (wait == null) { throw new Exception("Could not confirm existence of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to have a selected status
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to be selected</returns>
        public bool WaitForElementToBeSelected(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementToBeSelected(locator));
                if (wait == false) { throw new Exception("Could not confirm selection of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to have a selected status
        /// </summary>
        /// <param name="element">The IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to be selected</returns>
        public bool WaitForElementToBeSelected(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementToBeSelected(element));
                if (wait == false) { throw new Exception("Could not confirm selection of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to have a visble attribute of true
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to be visible</returns>
        public bool WaitForElementToBeVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementIsVisible(locator));
                if (wait == null) { throw new Exception("Could not confirm visibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for the selection of an element to reach a certain state
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <param name="state">The selection state to check for</param>
        /// <returns>True if the wait is terminated by the element being found to be in a given selection state.</returns>
        public bool WaitForElementSelectionStateToBe(By locator, bool state)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementSelectionStateToBe(locator, state));
                if (wait == false) { throw new Exception("Could not confirm selection state of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for the selection of an element to reach a certain state
        /// </summary>
        /// <param name="element">The IWebElement to await</param>
        /// <param name="state">The selection state to check for</param>
        /// <returns>True if the wait is terminated by the element being found to be in a given selection state.</returns>
        public bool WaitForElementSelectionStateToBe(IWebElement element, bool state)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.ElementSelectionStateToBe(element, state));
                if (wait == false) { throw new Exception("Could not confirm selection state of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for a given element containing text to be invisible
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <returns>True if the elements is invisible, false if the wait expires.</returns>
        public bool WaitForElementInvisibility(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                if (wait == false) { throw new Exception("Could not confirm invisibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for a given element containing text to be invisible or to be removed from the DOM
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the elements with given text is invisible, false if the wait expires</returns>
        public bool WaitForElementInvisibilityWithText(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
                if (wait == false) { throw new Exception("Could not confirm invisibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if any elements on the page match the locator
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the elements found by a locator are present, false if the wait expires or no elements are found.</returns>
        public bool WaitForPresenceOfAllElementsLocatedBy(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                if (wait.Count == 0) { throw new Exception("Could not confirm presence of the elements required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for a given element to go stale
        /// </summary>
        /// <param name="element">The IWebElement to check</param>
        /// <returns>True if the element becomes stale, false if the wait expires.</returns>
        public bool WaitForStalenessOf(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.StalenessOf(element));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits until specified text is found within a given element
        /// </summary>
        /// <param name="element">The IWebElement to check</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        public bool WaitForTextToBePresentInElement(IWebElement element, String text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.TextToBePresentInElement(element, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits until specified text is found within a given element
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to check</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        public bool WaitForTextToBePresentInElement(By locator, string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits until specified text is found within a given element's value attribute
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to check</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        public bool WaitForTextToBePresentInElementValue(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.TextToBePresentInElementValue(locator, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits until a given string is found in the value attribute of the given element
        /// </summary>
        /// <param name="element">The element to observe</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        public bool WaitForTextToBePresentInElementValue(IWebElement element, string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Pauses execution until the title of the page title contains a given string
        /// </summary>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the title contains the given text, false if the wait expires.</returns>
        public bool WaitForTitleToContain(string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.TitleContains(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Pauses execution until the title of the page title matches a given string
        /// </summary>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the title matches the given text, false if the wait expires.</returns>
        public bool WaitForTitleToBe(string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.TitleIs(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Pauses execution until the url contains a given string
        /// </summary>
        /// <param name="text">The text to use in comparison.</param>
        /// <returns>True if the URL contains the given text, false if the wait expires.</returns>
        public bool WaitForUrlToContain(string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.UrlContains(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Pauses execution until the url matches a given string
        /// </summary>
        /// <param name="text">The text to use in comparison.</param>
        /// <returns>True if the URL matches the given text, false if the wait expires.</returns>
        public bool WaitForUrlToMatch(string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.UrlMatches(text));
                if (wait == false) { throw new Exception("URL does not appear within the timeout period."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Pauses execution until the url matches a given string
        /// </summary>
        /// <param name="text">The text to use in comparison.</param>
        /// <returns>True if the URL matches the given text, false if the wait expires.</returns>
        public bool WaitForUrlToBe(string text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.UrlToBe(text));
                if (wait == false) { throw new Exception("URL does not appear within the timeout period."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for all of the element identified by the locator to be visible
        /// </summary>
        /// <param name="locator">The locator to use to find elements</param>
        /// <returns>True if all elements located are visible, false if the wait expires.</returns>
        public bool WaitForVisibilityOfAllElementsLocatedBy(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                if (wait.Count == 0) { throw new Exception("Could not confirm the visibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
