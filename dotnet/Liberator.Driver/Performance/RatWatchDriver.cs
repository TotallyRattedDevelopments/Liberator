using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;

namespace Liberator.Driver.Performance
{
    /// <summary>
    /// Performance enabled web driver
    /// </summary>
    /// <typeparam name="TWebDriver">The type of web driver to use</typeparam>
    public class  RatWatchDriver<TWebDriver> : IDisposable
        where TWebDriver : IWebDriver, IDisposable, new()
    {
        /// <summary>
        /// Holds an instance of the driver
        /// </summary>
        public TWebDriver Driver;

        /// <summary>
        /// Allows a WebDriver to register for events
        /// </summary>
        public EventFiringWebDriver FiringDriver;

        /// <summary>
        /// Enhances the passed WebDriver with event handlers
        /// </summary>
        /// <param name="driver">A copy of a WebDriver instance</param>
        public RatWatchDriver(TWebDriver driver)
        {
            Driver = driver;
            FiringDriver = new EventFiringWebDriver(driver);
            FiringDriver.ElementClicked += FiringDriver_ElementClicked;
            FiringDriver.ElementClicking += FiringDriver_ElementClicking;
            FiringDriver.ElementValueChanged += FiringDriver_ElementValueChanged;
            FiringDriver.ElementValueChanging += FiringDriver_ElementValueChanging;
            FiringDriver.ExceptionThrown += FiringDriver_ExceptionThrown;
            FiringDriver.FindElementCompleted += FiringDriver_FindElementCompleted;
            FiringDriver.FindingElement += FiringDriver_FindingElement;
            FiringDriver.Navigated += FiringDriver_Navigated;
            FiringDriver.NavigatedBack += FiringDriver_NavigatedBack;
            FiringDriver.NavigatedForward += FiringDriver_NavigatedForward;
            FiringDriver.Navigating += FiringDriver_Navigating;
            FiringDriver.NavigatingBack += FiringDriver_NavigatingBack;
            FiringDriver.NavigatingForward += FiringDriver_NavigatingForward;
            FiringDriver.ScriptExecuted += FiringDriver_ScriptExecuted;
            FiringDriver.ScriptExecuting += FiringDriver_ScriptExecuting;
        }

        /// <summary>
        /// Handles the script executing event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver script event</param>
        public virtual void FiringDriver_ScriptExecuting(object sender, WebDriverScriptEventArgs e)
        {

        }

        /// <summary>
        /// Handles the script executed event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver script event</param>
        public virtual void FiringDriver_ScriptExecuted(object sender, WebDriverScriptEventArgs e)
        {
        }

        /// <summary>
        /// Handles the navigating forward event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver navigation event</param>
        public virtual void FiringDriver_NavigatingForward(object sender, WebDriverNavigationEventArgs e)
        {
        }

        /// <summary>
        /// Handles the navigating back event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver navigating back event</param>
        public virtual void FiringDriver_NavigatingBack(object sender, WebDriverNavigationEventArgs e)
        {
        }

        /// <summary>
        /// Handles the navigating event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver navigating event</param>
        public virtual void FiringDriver_Navigating(object sender, WebDriverNavigationEventArgs e)
        {
        }

        /// <summary>
        /// Handles the navigated forward event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver navigated forward event</param>
        public virtual void FiringDriver_NavigatedForward(object sender, WebDriverNavigationEventArgs e)
        {
        }

        /// <summary>
        /// Handles the navigated back event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver navigated back event</param>
        public virtual void FiringDriver_NavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {
        }

        /// <summary>
        /// Handles the navigated event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver navigated event</param>
        public virtual void FiringDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
        }

        /// <summary>
        /// Handles the find element event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver finding element event</param>
        public virtual void FiringDriver_FindingElement(object sender, FindElementEventArgs e)
        {
        }

        /// <summary>
        /// Handles the find element completed event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver found element event</param>
        public virtual void FiringDriver_FindElementCompleted(object sender, FindElementEventArgs e)
        {
        }

        /// <summary>
        /// Handles the exception thrown event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver exception thrown event</param>
        public virtual void FiringDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
        }

        /// <summary>
        /// Handles the element value changing event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">Arguments for the web driver element value changing event</param>
        public virtual void FiringDriver_ElementValueChanging(object sender, WebElementEventArgs e)
        {
        }

        /// <summary>
        /// Handles the element value changed event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">The arguments for the element value changes event</param>
        public virtual void FiringDriver_ElementValueChanged(object sender, WebElementEventArgs e)
        {
        }

        /// <summary>
        /// Handles the element clicking event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">The arguments for the element clicking event</param>
        public virtual void FiringDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
        }

        /// <summary>
        /// Handles the element clicked event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">The arguments for the element clicked event</param>
        public virtual void FiringDriver_ElementClicked(object sender, WebElementEventArgs e)
        {

        }

        /// <summary>
        /// Provides a method for disposing of the instance
        /// </summary>
        /// <param name="disposing">Whether the method is disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
            }
            // free native resources
        }

        /// <summary>
        /// Disposes of the instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}