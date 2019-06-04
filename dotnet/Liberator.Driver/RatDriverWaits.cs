using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
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
        private bool WaitForElementToExist(By locator)
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

        public bool WaitForTextToBePresentInElement(By locator, String text)
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

        public bool WaitForTextToBePresentInElementValue(IWebElement element, String text)
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

        public bool WaitForTitleToContain(String text)
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

        public bool WaitForTitleToBe(String text)
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

        public bool WaitForUrlToContain(String text)
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

        public bool WaitForUrlToMatch(String text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.UrlMatches(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WaitForUrlToBe(String text)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.UrlToBe(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WaitForVisibilityOfAllElementsLocatedBy(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, Preferences.BaseSettings.Timeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                if (wait.Count == 0) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
