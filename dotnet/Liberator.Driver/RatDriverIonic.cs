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
        /// Expands a ShadowRoot tree using a chain of locators
        /// <para>A limitation in Selenium requires the use of only IDs or CSS Selectors.</para>
        /// </summary>
        /// <param name="shadowLocators">A collection of locators for shadow root elements.</param>
        /// <returns>The final opened shadow root item.</returns>
        public IWebElement ExpandShadowRootTree(List<ShadowLocator> shadowLocators)
        {
            try
            {
                IWebElement shadowRoot = Driver.FindElement(shadowLocators[0].SeleniumLocator);
                IWebElement expandedElement = ExpandShadowRoot(shadowRoot);

                for (int i = 1; i < shadowLocators.Count; i++)
                {
                    IWebElement webElement = shadowRoot.FindElement(shadowLocators[i].SeleniumLocator);
                    shadowRoot = webElement;
                }
                return shadowRoot;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not expand the tree .");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Expands a shadow root element
        /// </summary>
        /// <param name="elementToOpen">The shadow root element to expand</param>
        /// <returns>An IWebElement representing the expanded root.</returns>
        public IWebElement ExpandShadowRoot(IWebElement elementToOpen)
        {
            try
            {
                return (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].shadowRoot", elementToOpen);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not expand the {0} element passed.", elementToOpen.TagName);
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Expands a shadow root element
        /// <para>NB: A limitation in Selenium requires the use of only IDs or CSS Selectors</para>
        /// </summary>
        /// <param name="shadowLocator">An object representing a locator for a shadow root element.</param>
        /// <returns></returns>
        public IWebElement ExpandShadowRoot(ShadowLocator shadowLocator)
        {
            try
            {
                return (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].shadowRoot", shadowLocator.Locator);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not expand the {0} element passed.", shadowLocator.Locator);
                HandleErrors(ex);
                return null;
            }
        }

    }
}
