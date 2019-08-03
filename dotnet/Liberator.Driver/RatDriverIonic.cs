using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        /// <summary>
        /// Delegate method used for finding elements within a Shadow Root
        /// </summary>
        /// <param name="locator">The locator for the subelement within the shadow root to find</param>
        /// <returns>A WebElement within a shadow root</returns>
        public delegate IWebElement WebElementFinder(By locator);

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
        /// </summary>
        /// <param name="locatorToOpen">Thelocator for the shadow root element to expand</param>
        /// <returns>An IWebElement representing the expanded root.</returns>
        public IWebElement ExpandShadowRoot(By locatorToOpen)
        {
            try
            {
                IWebElement elementToOpen = Driver.FindElement(locatorToOpen);
                return (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].shadowRoot", elementToOpen);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not expand the element passed.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Finds a subelement beneath a shadow root element.
        /// </summary>
        /// <param name="shadowRootElement">The shadow root element to expand.</param>
        /// <param name="subElementLocator">A locator for a subelement witin the shadow root.</param>
        /// <returns>An IWebElement that is a subelement of the Shadow Root.</returns>
        public IWebElement FindSubElementInShadowRoot(IWebElement shadowRootElement, By subElementLocator)
        {
            try
            {
                IWebElement shadowRoot = ExpandShadowRoot(shadowRootElement);
                IWebElement subElement = FindSubElement(shadowRootElement, subElementLocator);
                return subElement;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not find the element passed.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Finds a subelement beneath a shadow root element.
        /// </summary>
        /// <param name="shadowRootElement">The shadow root element to expand.</param>
        /// <param name="subElementLocator">A locator for a subelement witin the shadow root.</param>
        /// <returns>An IWebElement that is a subelement of the Shadow Root.</returns>
        public IEnumerable<IWebElement> FindSubElementsInShadowRoot(IWebElement shadowRootElement, By subElementLocator)
        {
            try
            {
                IWebElement shadowRoot = ExpandShadowRoot(shadowRootElement);
                IEnumerable<IWebElement> subElements = FindSubElements(shadowRootElement, subElementLocator);
                return subElements;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not find the element requested.");
                HandleErrors(ex);
                return null;
            }
        }

        /// <summary>
        /// Finds a subelement within a shadow root element that is identified by the value of an attribute
        /// </summary>
        /// <param name="shadowRootElement">The shadow root element to expand.</param>
        /// <param name="subElementLocator">A locator for a subelement witin the shadow root.</param>
        /// <param name="attributeName">The name of the attribute to use for a uniqueness check.</param>
        /// <param name="attributeValue">The unique value of the attribute to use.</param>
        /// <returns>An IWebElement that has been identified by battribute.</returns>
        public IWebElement FindSubElementInShadowRootByAttribute(IWebElement shadowRootElement, By subElementLocator, string attributeName, string attributeValue)
        {
            try
            {
                IWebElement shadowRoot = ExpandShadowRoot(shadowRootElement);
                IEnumerable<IWebElement> subElements = FindSubElements(shadowRootElement, subElementLocator);
                return subElements.Where(a => a.GetAttribute(attributeName).Contains(attributeValue)).First();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not find the element requested.");
                HandleErrors(ex);
                return null;
            }
        }

    }
}
