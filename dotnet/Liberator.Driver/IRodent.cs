using Liberator.Driver.Enums;
using Liberator.Driver.Ionic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Liberator.Driver
{
    /// <summary>
    /// Base interface for RatDriver, also used in multithreaded testing
    /// </summary>
    public interface IRodent
    {
        #region IRodent Properties

        /// <summary>
        /// Gets the unique Id of the RatDriver instance
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Text name for the driver
        /// </summary>
        string DriverName { get; set; }

        /// <summary>
        /// The current WebElement under scrutiny
        /// </summary>
        IWebElement Element { get; }

        /// <summary>
        /// The locator for a WebElement under scrutiny
        /// </summary>
        By Locator { get; }

        /// <summary>
        /// A list of Elements returned to the user by a query
        /// </summary>
        IEnumerable<IWebElement> Elements { get; }

        /// <summary>
        /// A list of Locators returned to the user by a query
        /// </summary>
        List<By> Locators { get; }

        /// <summary>
        /// The last exception thrown by the driver
        /// </summary>
        Exception LastException { get; }

        /// <summary>
        /// The current collection of windows by handle
        /// </summary>
        Dictionary<string, string> WindowHandles { get; set; }


        #endregion

        #region RatDriver Actions

        /// <summary>
        /// Moves the virtual cursor position to a WebElement which acts as a menu and hovers
        /// </summary>
        /// <param name="element">The WebElement acting as a menu</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void HoverOverMenu(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor position to a WebElement which acts as a menu and hovers
        /// </summary>
        /// <param name="locator">The locator for the WebElement acting as a menu</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void HoverOverMenu(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement acting as a menu and continues to hover
        /// </summary>
        /// <param name="element">The WebElement acting as a menu</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickAndHoverOverMenu(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement acting as a menu and continues to hover
        /// </summary>
        /// <param name="locator">The locator for the WebElement acting as a menu</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickAndHoverOverMenu(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement acting as a menu and continues to hold
        /// </summary>
        /// <param name="element">The WebElement acting as a menu</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickAndHoldMenu(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement acting as a menu and continues to hold
        /// </summary>
        /// <param name="locator">The locator for the WebElement acting as a menu</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickAndHoldMenu(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on an element and displays a contextual menu
        /// </summary>
        /// <param name="element">The WebElement which is the target of the contextual menu click</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickContextualMenu(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on an element and displays a contextual menu
        /// </summary>
        /// <param name="locator">The locator for the WebElement which is the target of the contextual menu click</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickContextualMenu(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Double clicks on a WebElement
        /// </summary>
        /// <param name="element">The WebElement on which a double click is required</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void DoubleClick(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Double clicks on a WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement which is the target of a double click</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void DoubleClick(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Drags a WebElement over a target WebElement and drops it
        /// </summary>
        /// <param name="source">The Web Element being dragged</param>
        /// <param name="target">The target WebElement for the action</param>
        /// <param name="waitForSource">Whether to wait for the source element to reach a known condition</param>
        /// <param name="waitForTarget">Whether to wait for the target element to reach a known condition</param>
        void DragAndDrop(IWebElement source, IWebElement target, [Optional, DefaultParameterValue(true)] bool waitForSource, [Optional, DefaultParameterValue(true)] bool waitForTarget);

        /// <summary>
        /// Drags a WebElement over a target WebElement and drops it
        /// </summary>
        /// <param name="source">The locator for the Web Element being dragged</param>
        /// <param name="target">The locator for the target WebElement for the action</param>
        /// <param name="waitForSource">Whether to wait for the source element to reach a known condition</param>
        /// <param name="waitForTarget">Whether to wait for the target element to reach a known condition</param>
        void DragAndDrop(By source, By target, [Optional, DefaultParameterValue(true)] bool waitForSource, [Optional, DefaultParameterValue(true)] bool waitForTarget);

        /// <summary>
        /// Drags a WebElement and drops it at an offset position
        /// </summary>
        /// <param name="element">The WebElement being dragged</param>
        /// <param name="xOffset">The x coordinate of the offset position</param>
        /// <param name="yOffset">The y coordinate of the offset position</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void DragAndDropToOffset(IWebElement element, int xOffset, int yOffset, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Drags a WebElement and drops it at an offset position
        /// </summary>
        /// <param name="locator">The locator for the WebElement being dragged</param>
        /// <param name="xOffset">The x coordinate of the offset position</param>
        /// <param name="yOffset">The y coordinate of the offset position</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void DragAndDropToOffset(By locator, int xOffset, int yOffset, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor to a WebElement and presses a key
        /// </summary>
        /// <param name="element">The WebElement on which the key is to be pressed</param>
        /// <param name="key">The key to be pressed</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void KeyDownOnElement(IWebElement element, string key, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor to a WebElement and presses a key
        /// </summary>
        /// <param name="locator">The locator for the WebElement on which the key is to be pressed</param>
        /// <param name="key">The key to be pressed</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void KeyDownOnElement(By locator, string key, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Releases a depressed key which a WebElement is selected
        /// </summary>
        /// <param name="element">The target WebElement for the key release</param>
        /// <param name="key">The key to be released</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void KeyUpOnElement(IWebElement element, string key, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Releases a depressed key which a WebElement is selected
        /// </summary>
        /// <param name="locator">The locator for the target WebElement for the key release</param>
        /// <param name="key">The key to be released</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void KeyUpOnElement(By locator, string key, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor by an offset from a WebElement
        /// </summary>
        /// <param name="element">The WebElement from which the cursor will move</param>
        /// <param name="xOffset">The x coordinate offset for the movement</param>
        /// <param name="yOffset">The y coordinate offset for the movement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void MoveByOffset(IWebElement element, int xOffset, int yOffset, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor by an offset from a WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement from which the cursor will move</param>
        /// <param name="xOffset">The x coordinate offset for the movement</param>
        /// <param name="yOffset">The y coordinate offset for the movement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void MoveByOffset(By locator, int xOffset, int yOffset, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor by an offset from a WebElement
        /// </summary>
        /// <param name="element">The WebElement from which the cursor will move</param>
        /// <param name="xOffset">The x coordinate offset for the movement</param>
        /// <param name="yOffset">The y coordinate offset for the movement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void MoveToElementWithOffset(IWebElement element, int xOffset, int yOffset, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Moves the virtual cursor by an offset from a WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement from which the cursor will move</param>
        /// <param name="xOffset">The x coordinate offset for the movement</param>
        /// <param name="yOffset">The y coordinate offset for the movement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void MoveToElementWithOffset(By locator, int xOffset, int yOffset, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Releases the mouse button over a WebElement
        /// </summary>
        /// <param name="element">The WebElement over which to release the mouse button</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ReleaseMouseButton(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Releases the mouse button over a WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement over which to release the mouse button</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ReleaseMouseButton(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Sends a sequence of keystrokes to the WebElement specified
        /// </summary>
        /// <param name="element">The WebElement that receives the keystrokes</param>
        /// <param name="text">The keystrokes that are to be sent to the WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SendValueToField(IWebElement element, string text, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Sends a sequence of keystrokes to the WebElement specified
        /// </summary>
        /// <param name="locator">The locator for the WebElement that receives the keystrokes</param>
        /// <param name="text">The keystrokes that are to be sent to the WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SendValueToField(By locator, string text, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Selects an item from a dropdown by text value
        /// </summary>
        /// <param name="element">The dropdown menu</param>
        /// <param name="item">The itemn to choose</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SelectItemFromDropdown(IWebElement element, string item, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Selects an item from a dropdown by text value
        /// </summary>
        /// <param name="locator">The locator for the dropdown menu</param>
        /// <param name="item">The itemn to choose</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SelectItemFromDropdown(By locator, string item, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Selects an item from a dropdown by row number
        /// </summary>
        /// <param name="element">The dropdown menu</param>
        /// <param name="row">The row number to choose</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SelectRowFromDropdown(IWebElement element, int row, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Selects an item from a dropdown by text value
        /// </summary>
        /// <param name="locator">The locator for the dropdown menu</param>
        /// <param name="row">The row number to choose</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SelectRowFromDropdown(By locator, int row, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Selects an item from a dropdown by text value
        /// </summary>
        /// <param name="element">The dropdown menu</param>
        /// <param name="value">The value to choose</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SelectValueFromDropdown(IWebElement element, string value, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Selects an item from a dropdown by text value
        /// </summary>
        /// <param name="locator">The locator for the dropdown menu</param>
        /// <param name="value">The value to choose</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void SelectValueFromDropdown(By locator, string value, [Optional, DefaultParameterValue(true)] bool wait);

        #endregion

        //#region RatDriver Touch Actions

        ///// <summary>
        ///// Double taps on the WebElement
        ///// </summary>
        ///// <param name="element">The WebElement that receives the double tap</param>
        //void DoubleTap(IWebElement element);

        ///// <summary>
        ///// Double taps on the WebElement
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement that receives the double tap</param>
        //void DoubleTap(By locator);

        ///// <summary>
        ///// Presses down on the screen at a given location
        ///// </summary>
        ///// <param name="element">The WebElement that should be on screen which the press event occurs</param>
        ///// <param name="x">The x coordinate for the downward press</param>
        ///// <param name="y">The y coordinate for the downward press</param>
        //void PressDown(IWebElement element, int x, int y);

        ///// <summary>
        ///// Presses down on the screen at a given location
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement that should be on screen which the press event occurs</param>
        ///// <param name="x">The x coordinate for the downward press</param>
        ///// <param name="y">The y coordinate for the downward press</param>
        //void PressDown(By locator, int x, int y);

        ///// <summary>
        ///// Flicks the screen starting at a WebElement
        ///// </summary>
        ///// <param name="element">The WebElement which is at the start of the flick</param>
        ///// <param name="x">The offset movement on the x axis relative to the viewport</param>
        ///// <param name="y">The offset movement on the y axis relative to the viewport</param>
        ///// <param name="speed">The flick speed in pixrls per second</param>
        //void FlickScreen(IWebElement element, int x, int y, int speed);

        ///// <summary>
        ///// Flicks the screen starting at a WebElement
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement which is at the start of the flick</param>
        ///// <param name="x">The offset movement on the x axis relative to the viewport</param>
        ///// <param name="y">The offset movement on the y axis relative to the viewport</param>
        ///// <param name="speed">The flick speed in pixrls per second</param>
        //void FlickScreen(By locator, int x, int y, int speed);

        ///// <summary>
        ///// Flicks the screen at a set speed in two dimensions
        ///// </summary>
        ///// <param name="element">The WebElement which must be displayed before the flick occurs</param>
        ///// <param name="speedX">The horizontal speed in pixels per second</param>
        ///// <param name="speedY">The vertical speed in pixels per second</param>
        //void FlickScreen(IWebElement element, int speedX, int speedY);

        ///// <summary>
        ///// Flicks the screen at a set speed in two dimensions
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement which must be displayed before the flick occurs</param>
        ///// <param name="speedX">The horizontal speed in pixels per second</param>
        ///// <param name="speedY">The vertical speed in pixels per second</param>
        //void FlickScreen(By locator, int speedX, int speedY);

        ///// <summary>
        ///// Presses and holds on a specified WebElement
        ///// </summary>
        ///// <param name="element">The WebElement to receive the Long Press event</param>
        //void LongPress(IWebElement element);

        ///// <summary>
        ///// Presses and holds on a specified WebElement
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement to receive the Long Press event</param>
        //void LongPress(By locator);

        ///// <summary>
        ///// Moves to a specified point on the screen
        ///// </summary>
        ///// <param name="element">The WebElement which must be displayed before the movement occurs</param>
        ///// <param name="x">The x coordinate for the movement</param>
        ///// <param name="y">The y coordinate for the movement</param>
        //void Move(IWebElement element, int x, int y);

        ///// <summary>
        ///// Moves to a specified point on the screen
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement which must be displayed before the movement occurs</param>
        ///// <param name="x">The x coordinate for the movement</param>
        ///// <param name="y">The y coordinate for the movement</param>
        //void Move(By locator, int x, int y);

        ///// <summary>
        ///// Scrolls the screen to a given offset
        ///// </summary>
        ///// <param name="element">The WebElement that must be present before the scroll is attempted</param>
        ///// <param name="x">The x coordinate for the movement</param>
        ///// <param name="y">The y coordinate for the movement</param>
        //void ScrollToOffset(IWebElement element, int x, int y);

        ///// <summary>
        ///// Scrolls the screen to a given offset
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement that must be present before the scroll is attempted</param>
        ///// <param name="x">The x coordinate for the movement</param>
        ///// <param name="y">The y coordinate for the movement</param>
        //void ScrollToOffset(By locator, int x, int y);

        ///// <summary>
        ///// Scrolls the screen from the given element
        ///// </summary>
        ///// <param name="element">The WebElement that is to receive the scroll</param>
        ///// <param name="x">The x coordinate for the movement</param>
        ///// <param name="y">The y coordinate for the movement</param>
        //void ScrollElement(IWebElement element, int x, int y);

        ///// <summary>
        ///// Scrolls the screen from the given element
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement that is to receive the scroll</param>
        ///// <param name="x">The x coordinate for the movement</param>
        ///// <param name="y">The y coordinate for the movement</param>
        //void ScrollElement(By locator, int x, int y);

        ///// <summary>
        ///// Taps once on a WebElement
        ///// </summary>
        ///// <param name="element">The WebElement that receives the single tap</param>
        //void SingleTap(IWebElement element);

        ///// <summary>
        ///// Taps once on a WebElement
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement that receives the single tap</param>
        //void SingleTap(By locator);

        ///// <summary>
        ///// Releases a press on the screen at a set location
        ///// </summary>
        ///// <param name="element">The WebElement which must be on screen before the release occurs</param>
        ///// <param name="x">The x coordinate of the release</param>
        ///// <param name="y">The y coordinate of the release</param>
        //void ReleasePress(IWebElement element, int x, int y);

        ///// <summary>
        ///// Releases a press on the screen at a set location
        ///// </summary>
        ///// <param name="locator">The locator for the WebElement which must be on screen before the release occurs</param>
        ///// <param name="x">The x coordinate of the release</param>
        ///// <param name="y">The y coordinate of the release</param>
        //void ReleasePress(By locator, int x, int y);

        //#endregion

        #region RatDriver Management

        /// <summary>
        /// Gets a reference to the encapsulated IWebDriver
        /// </summary>
        /// <returns>The encapsulated IWebDriver</returns>
        IWebDriver ReturnEncapsulatedDriver();

        /// <summary>
        /// Checks if a cookie exists
        /// </summary>
        /// <param name="cookieName">The name of the cookie to check for</param>
        /// <returns>A boolean value indicating whether the cookie exists</returns>
        bool CheckCookieExists(string cookieName);

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        void AddCookie(string name, string value);

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        void AddCookie(string name, string value, string path);

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        void AddCookie(string name, string value, string path, DateTime expiry);

        /// <summary>
        /// Adds a cookie to the browser
        /// </summary>
        /// <param name="name">The name of the cookie to add</param>
        /// <param name="value">The value set within the cookie</param>
        /// <param name="domain">The domain for which the cookie is being added</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        void AddCookie(string name, string value, string domain, string path, DateTime expiry);

        /// <summary>
        /// Adds a predefined cookie to the current broowser session
        /// </summary>
        /// <param name="cookie">The cookie to be added</param>
        void AddCookie(Cookie cookie);

        /// <summary>
        /// Gets a list of cookies currently saved by the browser
        /// </summary>
        /// <returns>The list of cookies</returns>
        IEnumerable<Cookie> GetCookies();

        /// <summary>
        /// Deletes all cookies currently found in the browser
        /// </summary>
        void DeleteAllCookies();

        /// <summary>
        /// Deletes a cookie, given a copy of that cookie
        /// </summary>
        /// <param name="cookie">The definition of the cookie to be deleted</param>
        void DeleteCookie(Cookie cookie);

        /// <summary>
        /// Deletes a named cookie
        /// </summary>
        /// <param name="cookie">The name of the cookie</param>
        void DeleteCookieNamed(string cookie);

        /// <summary>
        /// Gets a cookie from the browser
        /// </summary>
        /// <param name="cookie">The name of the cookie to find</param>
        /// <returns>The named cookie</returns>
        Cookie GetCookieNamed(string cookie);

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        void ReplaceCookie(string name, string value);

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        void ReplaceCookie(string name, string value, string path);

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        void ReplaceCookie(string name, string value, string path, DateTime expiry);

        /// <summary>
        /// Deletes and then replaces a named cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value to set within the cookie</param>
        /// <param name="domain">The domain for which the cookie is being added</param>
        /// <param name="path">The path of the cookie</param>
        /// <param name="expiry">The date and time at which the cookie expires</param>
        void ReplaceCookie(string name, string value, string domain, string path, DateTime expiry);

        /// <summary>
        /// Gets a list of available log types
        /// </summary>
        /// <returns>The list of log types</returns>
        IEnumerable<string> GetAvailableLogTypes();

        /// <summary>
        /// Gets the available log entries for a particular log type
        /// </summary>
        /// <param name="logKind">The type of log to consult</param>
        /// <returns>The list of log entries</returns>
        IEnumerable<LogEntry> GetAvailableLogEntries(string logKind);

        /// <summary>
        /// Sets the implicit wait via a method.
        /// </summary>
        /// <param name="minutes">The number of minutes in the  implicit wait</param>
        /// <param name="seconds">The number of seconds in the  implicit wait</param>
        /// <param name="milliseconds">The number of milliseconds in the  implicit wait</param>
        void SetImplicitWait(int minutes, int seconds, int milliseconds);

        /// <summary>
        /// Sets the page load timeout via a method.
        /// </summary>
        /// <param name="minutes">The number of minutes in the  page load timeout</param>
        /// <param name="seconds">The number of seconds in the  page load timeout</param>
        /// <param name="milliseconds">The number of milliseconds in the page load timeout</param>
        void SetPageLoadTimeout(int minutes, int seconds, int milliseconds);

        /// <summary>
        /// Sets the script timeout via a method.
        /// </summary>
        /// <param name="minutes">The number of minutes in the script timeout</param>
        /// <param name="seconds">The number of seconds in the script timeout</param>
        /// <param name="milliseconds">The number of milliseconds in the script timeout</param>
        void SetScriptTimeout(int minutes, int seconds, int milliseconds);

        /// <summary>
        /// Maximises the current window
        /// </summary>
        void MaximiseView();

        /// <summary>
        /// Gets the current window position
        /// </summary>
        /// <returns>A tuple containing the x and y coordinates of the top left corner of the window</returns>
        Tuple<int, int> GetWindowPosition();

        /// <summary>
        /// Gets the current window size
        /// </summary>
        /// <returns>A tuple containing the width and height of the current window</returns>
        Tuple<int, int> GetWindowSize();

        /// <summary>
        /// Resizes the browser window to the assigned width and height
        /// </summary>
        /// <param name="width">The width to assign to the browser</param>
        /// <param name="height">The height to assign to the browser</param>
        void ResizeBrowserWindow(int width, int height);

        /// <summary>
        /// Presses the back button of the browser
        /// </summary>
        void PressBackButton();

        /// <summary>
        /// Presses the forward button of the browser
        /// </summary>
        void PressForwardButton();

        /// <summary>
        /// Navigates to a particular website by URL
        /// </summary>
        /// <param name="url">The URL of the website to load in the browser</param>
        void NavigateToPage(string url);

        /// <summary>
        /// Navigates to a particular website by URI
        /// </summary>
        /// <param name="url">The URI object of the website to load in the browser</param>
        void NavigateToPage(Uri url);

        /// <summary>
        /// Refreshes the currently selected browser
        /// </summary>
        void RefreshBrowser();

        /// <summary>
        /// Checks the entire html source for the page for a piece of text
        /// </summary>
        /// <param name="text">The text to search the page for</param>
        bool CheckPageSourceForText(string text);

        /// <summary>
        /// Gets the source code for the page
        /// </summary>
        /// <returns>The Page Source</returns>
        string GetPageSource();

        /// <summary>
        /// Closes the browser pages and quits the driver
        /// </summary>
        void ClosePagesAndQuitDriver();

        /// <summary>
        /// Checks if a window is open, using its window handle
        /// </summary>
        /// <param name="window">The window handle to query</param>
        /// <returns>A true/false value</returns>
        bool IsWindowOpen(string window);

        /// <summary>
        /// Switches to the currently active WebElement
        /// </summary>
        void SwitchToActiveWebElement();

        /// <summary>
        /// Switches to the currently active Alert Dialog
        /// </summary>
        void SwitchToAlertDialog();

        /// <summary>
        /// Switches to the original frame or window
        /// </summary>
        void SwitchToDefaultContent();

        /// <summary>
        /// Switches to a numbered frame by index
        /// </summary>
        /// <param name="frameIndex">The index number for the frame</param>
        void SwitchToFrame(int frameIndex);

        /// <summary>
        /// Switches to the frame identified by the WebElement
        /// </summary>
        /// <param name="frameElement">A WebElement representing the frame to activate</param>
        void SwitchToFrame(IWebElement frameElement);

        /// <summary>
        /// Switches to the frame identified by the WebElement
        /// </summary>
        /// <param name="frameLocator">The locator for the WebElement representing the frame to activate</param>
        void SwitchToFrame(By frameLocator);

        /// <summary>
        /// Switches to the frame identified by the WebElement
        /// </summary>
        /// <param name="frameName">The name of the frame to activate</param>
        void SwitchToFrame(string frameName);

        /// <summary>
        /// Switches to the parent frame of a selected WebElement
        /// </summary>
        void SwitchToParentFrame();

        /// <summary>
        /// Switches to a window, given the name of that window
        /// </summary>
        /// <param name="windowName">The name of the window to switch to</param>
        void SwitchToWindow(string windowName);

        /// <summary>
        /// Gets the title of the currently active browser
        /// </summary>
        /// <returns>The name of the currently active window</returns>
        string GetBrowserWindowTitle();

        /// <summary>
        /// Gets the URL in the currently active browser window
        /// </summary>
        /// <returns>The URL for the browser</returns>
        string GetBrowserWindowUrl();

        /// <summary>
        /// Gets the Window Handle for the currently selected page
        /// </summary>
        /// <returns>A window handle representing a unique reference to a page</returns>
        string GetCurrentWindowHandle();

        /// <summary>
        /// Gets a list of WindowHandles for all windows under the control of the current driver session
        /// </summary>
        /// <returns>A collection of WindowHandles</returns>
        IEnumerable<string> GetAllWindowHandles();

        /// <summary>
        /// Opens a new window using the send keys command
        /// </summary>
        void OpenNewView();

        /// <summary>
        /// Closes the currently selected window
        /// </summary>
        void CloseView();

        #endregion

        #region Ratdriver Methods

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="element">The element for which to wait</param>
        void WaitForElementToLoad(IWebElement element);

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        void WaitForElementToLoad(By locator);

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="element">The element for which to wait</param>
        /// <param name="seconds">Maximum number of seconds to wait</param>
        void WaitForElementToLoad(IWebElement element, int seconds);

        /// <summary>
        /// Waits for an element to be loaded
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        /// <param name="seconds">Maximum number of seconds to wait</param>
        void WaitForElementToLoad(By locator, int seconds);

        /// <summary>
        /// Waits for a page to load
        /// </summary>
        /// <param name="element">An element from the previous page. If omitted, the code will wait for the body of the page to be viosible</param>
        void WaitForPageToLoad(IWebElement element);

        /// <summary>
        /// Waits for an element to disappear from the DOM
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        void WaitForInvisibilityOfElement(By locator);

        /// <summary>
        /// Waits for an element containing text to disappear from the DOM
        /// </summary>
        /// <param name="locator">The locator for the element for which to wait</param>
        /// <param name="text">The text that should be found in the element</param>
        void WaitForInvisibilityOfElementWithText(By locator, string text);

        /// <summary>
        /// Clicks on a WebElement
        /// </summary>
        /// <param name="element">The WebElement on which to click</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickLink(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement
        /// </summary>
        /// <param name="element">The WebElement on which to click</param>
        /// <param name="clock">A clock that may be used to set custom timeouts</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickLink(IWebElement element, RatClock clock, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement on which to click</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickLink(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement on which to click</param>
        /// <param name="clock">A clock that may be used to set custom timeouts</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        void ClickLink(By locator, RatClock clock, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Clicks on a link and waits for a new page to be loaded
        /// </summary>
        /// <param name="element">The element on which to click</param>
        void ClickLinkAndWait(IWebElement element);

        /// <summary>
        /// Clicks on a link and waits for a new page to be loaded
        /// </summary>
        /// <param name="locator">The element on which to click</param>
        void ClickLinkAndWait(By locator);

        /// <summary>
        /// Clicks on a link and waits for a new page to be loaded that contains a specified URL or part URL
        /// </summary>
        /// <param name="element">The element on which to click</param>
        /// <param name="url">The partial URL to be waited for</param>
        void ClickLinkAndWaitForUrl(IWebElement element, string url);

        /// <summary>
        /// Clicks on a link and waits for a new page to be loaded that contains a specified URL or part URL
        /// </summary>
        /// <param name="locator">The locator for the element on which to click</param>
        /// <param name="url">The partial URL to be waited for</param>
        void ClickLinkAndWaitForUrl(By locator, string url);

        /// <summary>
        /// Gets the text of a WebElement
        /// </summary>
        /// <param name="element">The WebElement from which to retrieve text</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The text of the WebElement</returns>
        string GetElementText(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Gets the text of a WebElement
        /// </summary>
        /// <param name="element">The WebElement from which to retrieve text</param>
        /// <param name="clock">A clock that may be used to set custom timeouts</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The text of the WebElement</returns>
        string GetElementText(IWebElement element, RatClock clock, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Gets the text of a WebElement
        /// </summary>
        /// <param name="locator">The WebElement from which to retrieve text</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The text of the WebElement</returns>
        string GetElementText(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Gets the text of a WebElement
        /// </summary>
        /// <param name="locator">The WebElement from which to retrieve text</param>
        /// <param name="clock">A clock that may be used to set custom timeouts</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The text of the WebElement</returns>
        string GetElementText(By locator, RatClock clock, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Retrieves the text value from the selected option in a dropdown menu.
        /// </summary>
        /// <param name="locator">The locator for the element that represents the dropdown menu.</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the cliackability of the element</param>
        /// <returns>The text of the WebElement</returns>
        string GetSelectedTextFromDropdown(By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Retrieves the text value from the selected option in a dropdown menu.
        /// </summary>
        /// <param name="element">The element that represents the dropdown menu.</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the cliackability of the element</param>
        /// <returns>The text of the WebElement</returns>
        string GetSelectedTextFromDropdown(IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Checks the browser for the presence of a particular WebElement
        /// </summary>
        /// <param name="element">The WebElement whose presence is tested</param>
        /// <returns>True if the WebElement is present; false if the WebElement is not present</returns>
        bool ElementExists(IWebElement element);

        /// <summary>
        /// Checks the browser for the presence of a particular WebElement
        /// </summary>
        /// <param name="locator">The locator for the WebElement whose presence is tested</param>
        /// <returns>True if the WebElement is present; false if the WebElement is not present</returns>
        bool ElementExists(By locator);

        /// <summary>
        /// Gets an attribute of a WebElement and returns it as text
        /// </summary>
        /// <param name="element">The WebElement whose attributes are to be tested</param>
        /// <param name="attribute">The attribute value to retrieve</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>True if the WebElement is present; false if the WebElement is not present</returns>
        string GetElementAttribute(IWebElement element, string attribute, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Gets an attribute of a WebElement and returns it as text
        /// </summary>
        /// <param name="element">The WebElement whose attributes are to be tested</param>
        /// <param name="attribute">The attribute value to retrieve</param>
        /// <param name="clock">A clock that may be used to set custom timeouts</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The attribute to retrieve</returns>
        string GetElementAttribute(IWebElement element, string attribute, RatClock clock, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Gets an attribute of a WebElement and returns it as text
        /// </summary>
        /// <param name="locator">The locator for the WebElement whose attributes are to be tested</param>
        /// <param name="attribute">The attribute value to retrieve</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The attribute to retrieve</returns>
        string GetElementAttribute(By locator, string attribute, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Gets an attribute of a WebElement and returns it as text
        /// </summary>
        /// <param name="locator">The locator for the WebElement whose attributes are to be tested</param>
        /// <param name="attribute">The attribute value to retrieve</param>
        /// <param name="clock">A clock that may be used to set custom timeouts</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>The attribute to retrieve</returns>
        string GetElementAttribute(By locator, string attribute, RatClock clock, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds an element with a unique CSS Selector
        /// </summary>
        /// <param name="cssSelector">The CSS Selector to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElements that has the CSS Selector</returns>
        IWebElement FindElementByCssSelector(string cssSelector, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements that share a CSS Selector
        /// </summary>
        /// <param name="cssSelector">The CSS Selector to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of WebElements that share the CSS Selector</returns>
        IEnumerable<IWebElement> FindElementsByCssSelector(string cssSelector, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a CSS Selector
        /// </summary>
        /// <param name="cssSelector">The CSS Selector to search for</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByCssSelector(string cssSelector, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a CSS Selector
        /// </summary>
        /// <param name="cssSelector">The CSS Selector to search for</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByCssSelector(string cssSelector, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement that has a Class Name
        /// </summary>
        /// <param name="className">The Class Name to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElement described by the Class Name</returns>
        IWebElement FindElementByClassName(string className, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements that share a Class Name
        /// </summary>
        /// <param name="className">The Class Name to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindElementsByClassName(string className, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a Class Name
        /// </summary>
        /// <param name="className">The Class Name to search for</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByClassName(string className, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a Class Name
        /// </summary>
        /// <param name="cssSelector">The Class Name to search for</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByClassName(string cssSelector, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement whose id is as specified
        /// </summary>
        /// <param name="id">The id to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElement with the specified id</returns>
        IWebElement FindElementById(string id, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement whose link text is as specified
        /// </summary>
        /// <param name="linkText">The text to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElement with the specified Link Text</returns>
        IWebElement FindElementByLinkText(string linkText, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements that whose link text is as specified
        /// </summary>
        /// <param name="linkText">The text to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindElementsByLinkText(string linkText, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement whose link text is as specified
        /// </summary>
        /// <param name="linkText">The text to search for</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByLinkText(string linkText, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement whose link text is as specified
        /// </summary>
        /// <param name="linkText">The text to search for</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByLinkText(string linkText, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement by name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElements</returns>
        IWebElement FindElementByName(string name, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements that share a name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindElementsByName(string name, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByName(string name, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByName(string name, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement whose link text is matched in part
        /// </summary>
        /// <param name="linkText">The text to find in whole or in part</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElement</returns>
        IWebElement FindElementByPartialLinkText(string linkText, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements whose link text is matched in part
        /// </summary>
        /// <param name="linkText">The text to find in whole or in part</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindElementsByPartialLinkText(string linkText, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement whose link text is matched in part
        /// </summary>
        /// <param name="linkText">The text to find in whole or in part</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByPartialLinkText(string linkText, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement whose link text is matched in part
        /// </summary>
        /// <param name="linkText">The text to find in whole or in part</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByPartialLinkText(string linkText, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement that possesses a tag
        /// </summary>
        /// <param name="tagName">The tag to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElement</returns>
        IWebElement FindElementByTag(string tagName, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements that share a tag
        /// </summary>
        /// <param name="tagName">The tage to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindElementsByTag(string tagName, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a tag
        /// </summary>
        /// <param name="tagName">The tage to search for</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByTag(string tagName, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share a tag
        /// </summary>
        /// <param name="tagName">The tag to search for</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByTag(string tagName, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebEements by its xpath
        /// </summary>
        /// <param name="xpath">The xpath to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A WebElement</returns>
        IWebElement FindElementByXPath(string xpath, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a list of elements that share an xpath
        /// </summary>
        /// <param name="xpath">The xpath to search for</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindElementsByXPath(string xpath, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share an xpath
        /// </summary>
        /// <param name="xpath">The xpath to search for</param>
        /// <param name="element">The parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByXPath(string xpath, IWebElement element, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds the child elements of a given WebElement that share an xpath
        /// </summary>
        /// <param name="xpath">The xpath to search for</param>
        /// <param name="locator">The locator for the parent WebElement</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A collection of child WebElements</returns>
        IEnumerable<IWebElement> FindSubElementsByXPath(string xpath, By locator, [Optional, DefaultParameterValue(true)] bool wait);

        /// <summary>
        /// Finds a WebElement identified by an attribite value from a collection of WebElements sharing a parent
        /// </summary>
        /// <param name="parentElement">The parent element for the process</param>
        /// <param name="type">The type of locator to use to fetch the collection</param>
        /// <param name="locator">The locator value for items in the collection</param>
        /// <param name="attribute">The HTML attribute to use to find the unique item</param>
        /// <param name="value">The value of the attribute of the unique item</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A web element identified by a locator type and an attribute value</returns>
        IWebElement ExtractElementFromCollectionByAttribute(IWebElement parentElement, EnumLocatorType type, string locator, string attribute, string value, [Optional, DefaultParameterValue(true)] bool wait);


        /// <summary>
        /// Finds a WebElement identified by an attribite value from a collection of WebElements sharing a parent
        /// </summary>
        /// <param name="parentLocator">The locator for the parent element for the process</param>
        /// <param name="type">The type of locator to use to fetch the collection</param>
        /// <param name="locator">The locator value for items in the collection</param>
        /// <param name="attribute">The HTML attribute to use to find the unique item</param>
        /// <param name="value">The value of the attribute of the unique item</param>
        /// <param name="wait">(Optional parameter) Whether to wait for the element to reach a known state</param>
        /// <returns>A web element identified by a locator type and an attribute value</returns>
        IWebElement ExtractElementFromCollectionByAttribute(By parentLocator, EnumLocatorType type, string locator, string attribute, string value, [Optional, DefaultParameterValue(true)] bool wait);

        #endregion

        #region Additional Methods

        /// <summary>
        /// Takes a screenshot of the active web page
        /// </summary>
        /// <param name="path">The path and name under which to save the image</param>
        void TakeScreenshot(string path);

        /// <summary>
        /// Returns a JavaScript Executor to the end user for custom JavaScript
        /// </summary>
        /// <returns>A JavaScript Executor</returns>
        IJavaScriptExecutor Scripts();

        /// <summary>
        /// Executes a JavaScript statement passed as a string
        /// </summary>
        /// <param name="script">The JavaScript to be executed</param>
        void ExecuteJavaScript(string script);

        /// <summary>
        /// Executes a JavaScript statement passed as a string
        /// </summary>
        /// <param name="script">The JavaScript to be executed</param>
        /// <param name="parameters">The parameters for the passed JavaScript</param>
        void ExecuteJavaScript(string script, params object[] parameters);

        /// <summary>
        /// Executes a JavaScript statement passed as a string
        /// </summary>
        /// <param name="script">The JavaScript to be executed</param>
        void ExecuteAsyncJavaScript(string script);

        /// <summary>
        /// Executes a JavaScript statement passed as a string
        /// </summary>
        /// <param name="script">The JavaScript to be executed</param>
        /// <param name="parameters">The parameters for the passed JavaScript</param>
        void ExecuteAsyncJavaScript(string script, params object[] parameters);

        #endregion

        #region Wait Methods

        /// <summary>
        /// Waits for an alert style duialog to be displayed
        /// </summary>
        /// <returns>True if the wait terminates with an alert being found</returns>
        bool WaitForAlertToBePresent();

        /// <summary>
        /// Checks for the state of an alert to be as expected
        /// </summary>
        /// <param name="state">True if the alert is to be displayed</param>
        /// <returns>True if the wait terminates with the alert in the correct state</returns>
        bool WaitForAlertToBeInState(bool state);

        /// <summary>
        /// Waits for an element to reach a clickable state
        /// </summary>
        /// <param name="element">The IWebElement representing the object</param>
        /// <returns>True if the wait is terminated by the element becoming clickable</returns>
        bool WaitForElementToBeClickable(IWebElement element);

        /// <summary>
        /// Waits for an element to reach a clickable state
        /// </summary>
        /// <param name="locator">The locator for the IWebElement representing the object</param>
        /// <returns>True if the wait is terminated by the element becoming clickable</returns>
        bool WaitForElementToBeClickable(By locator);

        /// <summary>
        /// Waits for an element to exist in the DOM
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to exist</returns>
        bool WaitForElementToExist(By locator);

        /// <summary>
        /// Waits for an element to have a selected status
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to be selected</returns>
        bool WaitForElementToBeSelected(By locator);

        /// <summary>
        /// Waits for an element to have a selected status
        /// </summary>
        /// <param name="element">The IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to be selected</returns>
        bool WaitForElementToBeSelected(IWebElement element);

        /// <summary>
        /// Waits for an element to have a visble attribute of true
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to await</param>
        /// <returns>True if the wait is terminated by the element being found to be visible</returns>
        bool WaitForElementToBeVisible(By locator);

        /// <summary>
        /// Waits for the selection of an element to reach a certain state
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <param name="state">The selection state to check for</param>
        /// <returns>True if the wait is terminated by the element being found to be in a given selection state.</returns>
        bool WaitForElementSelectionStateToBe(By locator, bool state);

        /// <summary>
        /// Waits for the selection of an element to reach a certain state
        /// </summary>
        /// <param name="element">The IWebElement to await</param>
        /// <param name="state">The selection state to check for</param>
        /// <returns>True if the wait is terminated by the element being found to be in a given selection state.</returns>
        bool WaitForElementSelectionStateToBe(IWebElement element, bool state);

        /// <summary>
        /// Waits for a given element containing text to be invisible
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <returns>True if the elements is invisible, false if the wait expires.</returns>
        bool WaitForElementInvisibility(By locator);

        /// <summary>
        /// Waits for a given element containing text to be invisible or to be removed from the DOM
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the elements with given text is invisible, false if the wait expires</returns>
        bool WaitForElementInvisibilityWithText(By locator, String text);

        /// <summary>
        /// Checks if any elements on the page match the locator
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to be used</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the elements found by a locator are present, false if the wait expires or no elements are found.</returns>
        bool WaitForPresenceOfAllElementsLocatedBy(By locator, String text);

        /// <summary>
        /// Waits for a given element to go stale
        /// </summary>
        /// <param name="element">The IWebElement to check</param>
        /// <returns>True if the element becomes stale, false if the wait expires.</returns>
        bool WaitForStalenessOf(IWebElement element);

        /// <summary>
        /// Waits until specified text is found within a given element
        /// </summary>
        /// <param name="element">The IWebElement to check</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        bool WaitForTextToBePresentInElement(IWebElement element, String text);

        /// <summary>
        /// Waits until specified text is found within a given element
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to check</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        bool WaitForTextToBePresentInElement(By locator, string text);

        /// <summary>
        /// Waits until specified text is found within a given element's value attribute
        /// </summary>
        /// <param name="locator">The locator for the IWebElement to check</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        bool WaitForTextToBePresentInElementValue(By locator, String text);

        /// <summary>
        /// Waits until a given string is found in the value attribute of the given element
        /// </summary>
        /// <param name="element">The element to observe</param>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the element contains the given text, false if the wait expires.</returns>
        bool WaitForTextToBePresentInElementValue(IWebElement element, string text);

        /// <summary>
        /// Pauses execution until the title of the page title contains a given string
        /// </summary>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the title contains the given text, false if the wait expires.</returns>
        bool WaitForTitleToContain(string text);

        /// <summary>
        /// Pauses execution until the title of the page title matches a given string
        /// </summary>
        /// <param name="text">The text to be used in comparison</param>
        /// <returns>True if the title matches the given text, false if the wait expires.</returns>
        bool WaitForTitleToBe(string text);

        /// <summary>
        /// Pauses execution until the url contains a given string
        /// </summary>
        /// <param name="text">The text to use in comparison.</param>
        /// <returns>True if the URL contains the given text, false if the wait expires.</returns>
        bool WaitForUrlToContain(string text);

        /// <summary>
        /// Pauses execution until the url matches a given string
        /// </summary>
        /// <param name="text">The text to use in comparison.</param>
        /// <returns>True if the URL matches the given text, false if the wait expires.</returns>
        bool WaitForUrlToMatch(string text);

        /// <summary>
        /// Pauses execution until the url matches a given string
        /// </summary>
        /// <param name="text">The text to use in comparison.</param>
        /// <returns>True if the URL matches the given text, false if the wait expires.</returns>
        bool WaitForUrlToBe(string text);

        /// <summary>
        /// Waits for all of the element identified by the locator to be visible
        /// </summary>
        /// <param name="locator">The locator to use to find elements</param>
        /// <returns>True if all elements located are visible, false if the wait expires.</returns>
        bool WaitForVisibilityOfAllElementsLocatedBy(By locator);

        #endregion

        #region Ionic

        /// <summary>
        /// Expands a ShadowRoot tree using a chain of locators
        /// <para>A limitation in Selenium requires the use of only IDs or CSS Selectors.</para>
        /// </summary>
        /// <param name="shadowLocators">A collection of locators for shadow root elements.</param>
        /// <returns>The final opened shadow root item.</returns>
        IWebElement ExpandShadowRootTree(List<ShadowLocator> shadowLocators);

        /// <summary>
        /// Expands a ShadowRoot tree using a chain of locators
        /// <para>A limitation in Selenium requires the use of only IDs or CSS Selectors.</para>
        /// </summary>
        /// <param name="rootLocator"></param>
        /// <param name="shadowLocators">A collection of locators for shadow root elements.</param>
        /// <returns>The final opened shadow root item.</returns>
        IWebElement ExpandShadowRootTree(By rootLocator, List<ShadowLocator> shadowLocators);

        /// <summary>
        /// Expands a ShadowRoot tree using a chain of locators
        /// <para>A limitation in Selenium requires the use of only IDs or CSS Selectors.</para>
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="shadowLocators">A collection of locators for shadow root elements.</param>
        /// <returns>The final opened shadow root item.</returns>
        IWebElement ExpandShadowRootTree(IWebElement rootElement, List<ShadowLocator> shadowLocators);

        /// <summary>
        /// Expands a shadow root element
        /// </summary>
        /// <param name="elementToOpen">The shadow root element to expand</param>
        /// <returns>An IWebElement representing the expanded root.</returns>
        IWebElement ExpandShadowRoot(IWebElement elementToOpen);

        /// <summary>
        /// Expands a shadow root element
        /// </summary>
        /// <param name="locatorToOpen">Thelocator for the shadow root element to expand</param>
        /// <returns>An IWebElement representing the expanded root.</returns>
        IWebElement ExpandShadowRoot(By locatorToOpen);

        /// <summary>
        /// Expands a shadow root element
        /// <para>NB: A limitation in Selenium requires the use of only IDs or CSS Selectors</para>
        /// </summary>
        /// <param name="shadowLocator">An object representing a locator for a shadow root element.</param>
        /// <returns>An IWebElement representing the expanded root.</returns>
        IWebElement ExpandShadowRoot(ShadowLocator shadowLocator);

        #endregion
    }
}
