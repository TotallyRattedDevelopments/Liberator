using Liberator.Driver.Ionic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        /// <summary>
        /// Allows navigation to elements within shadow roots by passing a series of FindBy locators
        /// </summary>
        /// <param name="shadowLocators">A list of shadow locators in order to navigate to an element.</param>
        /// <returns>An object representing the target of the list of shadow locators.</returns>
        public IWebElement NavigateToShadowRoot(List<ShadowLocator> shadowLocators)
        {
            try
            {
                IWebDriver driver = ReturnEncapsulatedDriver();
                IWebElement element = driver.FindElement(shadowLocators[0].FindBy);

                for (int i = 1; i < shadowLocators.Count; i++)
                {
                    shadowLocators[i].Ancestor = element;
                    IWebElement shadowRoot = element.FindElement(shadowLocators[i].FindBy);
                    element = ExpandRootElement(shadowRoot);
                    shadowLocators[i + 1].Child = element;
                    Console.Out.WriteLine("Found locator: {0}", shadowLocators[i].FindBy.ToString());
                }
                return element;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not navigate to the next shadow root element.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Allows a user to access the root element beneath a shadow root tag
        /// </summary>
        /// <param name="rootLocator">The locator for a root element.</param>
        /// <returns>An IWebElement representing the root</returns>
        public IWebElement MoveToShadowRootAndExpand(By rootLocator)
        {
            try
            {
                IWebElement element = Driver.FindElement(rootLocator);
                return (IWebElement)((IJavaScriptExecutor)ReturnEncapsulatedDriver()).ExecuteAsyncScript("return arguments[0].shadowRoot", element);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not expand the element: {0}", rootLocator.ToString());
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Expands a shadow root element
        /// </summary>
        /// <param name="element">The shadow root element to expand</param>
        /// <returns>An IWebElement representing the expanded root.</returns>
        public IWebElement ExpandRootElement(IWebElement element)
        {
            try
            {

                return (IWebElement)((IJavaScriptExecutor)ReturnEncapsulatedDriver()).ExecuteAsyncScript("return arguments[0].shadowRoot", element);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not expand the {0} element passed.", element.TagName);
                HandleErrors(ex);
                return null;
            }
        }

    }
}
