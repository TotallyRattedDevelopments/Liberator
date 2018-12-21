using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        private bool WaitForAlertToBePresent()
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout)
                    .Until(ExpectedConditions.AlertIsPresent());
                if (wait == null) { throw new Exception("Could not confirm alert was displayed."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForAlertToBeInState(bool state)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout)
                    .Until(ExpectedConditions.AlertState(state));
                if (wait != state) { throw new Exception("Could not confirm alert state."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementToBeClickable(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout)
                    .Until(ExpectedConditions.ElementToBeClickable(element));
                if (wait == null) { throw new Exception("Could not confirm clickability of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementToBeClickable(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout)
                    .Until(ExpectedConditions.ElementToBeClickable(locator));
                if (wait == null) { throw new Exception("Could not confirm clickability of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementToExist(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.ElementExists(locator));
                if (wait == null) { throw new Exception("Could not confirm existence of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementToBeSelected(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.ElementToBeSelected(locator));
                if (wait == false) { throw new Exception("Could not confirm selection of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementToBeSelected(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.ElementToBeSelected(element));
                if (wait == false) { throw new Exception("Could not confirm selection of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementToBeVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.ElementIsVisible(locator));
                if (wait == null) { throw new Exception("Could not confirm visibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementSelectionStateToBe(By locator, bool state)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.ElementSelectionStateToBe(locator, state));
                if (wait == false) { throw new Exception("Could not confirm selection state of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementSelectionStateToBe(IWebElement element, bool state)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.ElementSelectionStateToBe(element, state));
                if (wait == false) { throw new Exception("Could not confirm selection state of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementInvisibility(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                if (wait == false) { throw new Exception("Could not confirm invisibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForElementInvisibilityWithText(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
                if (wait == false) { throw new Exception("Could not confirm invisibility of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForPresenceOfAllElementsLocatedBy(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                if (wait.Count == 0) { throw new Exception("Could not confirm presence of the elements required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForStalenessOf(IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.StalenessOf(element));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForTextToBePresentInElement(IWebElement element, String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.TextToBePresentInElement(element, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForTextToBePresentInElement(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForTextToBePresentInElementValue(By locator, String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.TextToBePresentInElementValue(locator, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForTextToBePresentInElementValue(IWebElement element, String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForTitleToContain(String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.TitleContains(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForTitleToBe(String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.TitleIs(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForUrlToContain(String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.UrlContains(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForUrlToMatch(String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.UrlMatches(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForUrlToBe(String text)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.UrlToBe(text));
                if (wait == false) { throw new Exception("Could not confirm staleness of the element required."); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WaitForVisibilityOfAllElementsLocatedBy(By locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, _timeout).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
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
