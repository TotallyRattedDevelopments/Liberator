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

        Guid _id;
        TWebDriver _driver;
        string _driverName;
        IWebElement _element;
        By _locator;
        IEnumerable<IWebElement> _elements;
        List<By> _locators;
        FirefoxProfile _firefoxProfile;
        Exception _lastException;
        IWebElement _lastPage;
        //TouchActions _touch;
        Dictionary<string, string> _windowHandles;
        IntPtr _currentWindow;
        EnumConsoleDebugLevel _debugLevel;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the unique Id of the RatDriver instance
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// The current WebDriver instance
        /// </summary>
        public TWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
        
        /// <summary>
        /// Text name for the driver
        /// </summary>
        public string DriverName
        {
            get { return _driverName; }
            set { _driverName = value; }
        }

        /// <summary>
        /// The current WebElement under scrutiny
        /// </summary>
        public IWebElement Element
        {
            get { return _element; }
            protected internal set { _element = value; }
        }

        /// <summary>
        /// The locator for a WebElement under scrutiny
        /// </summary>
        public By Locator
        {
            get { return _locator; }
            protected internal set { _locator = value; }
        }

        /// <summary>
        /// A list of Elements returned to the user by a query
        /// </summary>
        public IEnumerable<IWebElement> Elements
        {
            get { return _elements; }
            protected internal set { _elements = value; }
        }

        /// <summary>
        /// A list of Locators returned to the user by a query
        /// </summary>
        public List<By> Locators
        {
            get { return _locators; }
            protected internal set { _locators = value; }
        }

        /// <summary>
        /// The last exception thrown by the driver
        /// </summary>
        public Exception LastException
        {
            get { return _lastException; }
            protected internal set { _lastException = value; }
        }

        /// <summary>
        /// The currently selected Firefiox Profile
        /// </summary>
        public FirefoxProfile FireFoxProfile
        {
            get { return _firefoxProfile; }
            set { _firefoxProfile = value; }
        }

        /// <summary>
        /// The last page opened by this incarnation of the driver
        /// </summary>
        public IWebElement LastPage
        {
            get { return _lastPage; }
            set { _lastPage = value; }
        }

        //public TouchActions Touch
        //{
        //    get { return _touch; }
        //    set { _touch = value; }
        //}

            /// <summary>
            /// The current collection of windows by handle
            /// </summary>
        public Dictionary<string, string> WindowHandles
        {
            get { return _windowHandles; }
            set { _windowHandles = value; }
        }

        /// <summary>
        /// A system reference to hWnd property
        /// </summary>
        public IntPtr hWindow
        {
            get { return _currentWindow; }
            set { _currentWindow = value; }
        }
        


        #endregion
    }
}
