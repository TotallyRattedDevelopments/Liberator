using Liberator.Driver.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace Liberator.Driver
{
    public partial class RatDriver<TWebDriver> : IRatDriver<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {

        #region Instance Variables

        internal EnumConsoleDebugLevel _debugLevel;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the unique Id of the RatDriver instance
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The current WebDriver instance
        /// </summary>
        public TWebDriver Driver { get; set; }

        /// <summary>
        /// Text name for the driver
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// The current WebElement under scrutiny
        /// </summary>
        public IWebElement Element { get; protected internal set; }

        /// <summary>
        /// The locator for a WebElement under scrutiny
        /// </summary>
        public By Locator { get; protected internal set; }

        /// <summary>
        /// A list of Elements returned to the user by a query
        /// </summary>
        public IEnumerable<IWebElement> Elements { get; protected internal set; }

        /// <summary>
        /// A list of Locators returned to the user by a query
        /// </summary>
        public List<By> Locators { get; protected internal set; }

        /// <summary>
        /// The last exception thrown by the driver
        /// </summary>
        public Exception LastException { get; protected internal set; }

        /// <summary>
        /// The currently selected Firefiox Profile
        /// </summary>
        public FirefoxProfile FireFoxProfile { get; set; }

        /// <summary>
        /// The last page opened by this incarnation of the driver
        /// </summary>
        public IWebElement LastPage { get; set; }

        /// <summary>
        /// The current collection of windows by handle
        /// </summary>
        public Dictionary<string, string> WindowHandles { get; set; }

        /// <summary>
        /// A system reference to hWnd property
        /// </summary>
        public IntPtr hWindow { get; set; }




        #endregion
    }
}
