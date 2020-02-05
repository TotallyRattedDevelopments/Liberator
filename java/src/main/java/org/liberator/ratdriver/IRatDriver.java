package org.liberator.ratdriver;

import org.liberator.ratdriver.entities.*;
import org.liberator.ratdriver.enums.ElementRelationships;
import org.liberator.ratdriver.enums.LocatorType;
import org.openqa.selenium.*;
import org.openqa.selenium.logging.LogEntry;

import java.util.*;

public interface IRatDriver extends IRodent {

    //region IRodent Properties

    /**
     * Gets the unique Id of the RatDriver instance
     */
    UUID Id = null;

    /**
     * Text name for the driver
     */
    String DriverName = null;

    /**
     * The current WebElement under scrutiny
     */
    WebElement Element = null;

    /**
     * The locator for a WebElement under scrutiny
     */
    By Locator = null;

    /**
     * A list of Elements returned to the user by a query
     */
    List<WebElement> Elements = null;

    /**
     * A list of Locators returned to the user by a query
     */
    List<By> Locators = null;

    /**
     * The last exception thrown by the driver
     */
    Exception LastException = null;

    /**
     * The current collection of windows by handle
     */
    Dictionary<String, String> WindowHandles = null;

    //endregion

    //region RatDriver Actions

    /**
     * Moves the virtual cursor position to a WebElement which acts as a menu and hovers
     * @param element The WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void HoverOverMenu(WebElement element, Boolean wait);

    /**
     * Moves the virtual cursor position to a WebElement which acts as a menu and hovers
     * @param locator The locator for the WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void HoverOverMenu(By locator, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hover
     * @param element The WebElement acting as a menu<
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickAndHoverOverMenu(WebElement element, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hover
     * @param locator The locator for the WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickAndHoverOverMenu(By locator, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hold
     * @param element The WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickAndHoldMenu(WebElement element, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hold
     * @param locator The locator for the WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickAndHoldMenu(By locator, Boolean wait);

    /**
     * Clicks on an element and displays a contextual menu
     * @param element The WebElement which is the target of the contextual menu click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickContextualMenu(WebElement element, Boolean wait);

    /**
     * Clicks on an element and displays a contextual menu
     * @param locator The locator for the WebElement which is the target of the contextual menu click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickContextualMenu(By locator, Boolean wait);

    /**
     * Double clicks on a WebElement
     * @param element The WebElement on which a double click is required
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void DoubleClick(WebElement element, Boolean wait);

    /**
     * Double clicks on a WebElement
     * @param locator The locator for the WebElement which is the target of a double click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void DoubleClick(By locator, Boolean wait);

    /**
     * Drags a WebElement over a target WebElement and drops it
     * @param source The Web Element being dragged
     * @param target The target WebElement for the action
     * @param waitForSource Whether to wait for the source element to reach a known condition
     * @param waitForTarget Whether to wait for the target element to reach a known condition
     */
    void DragAndDrop(WebElement source, WebElement target, Boolean waitForSource, Boolean waitForTarget);

    /**
     * Drags a WebElement over a target WebElement and drops it
     * @param source The locator for the Web Element being dragged
     * @param target The locator for the target WebElement for the action
     * @param waitForSource Whether to wait for the source element to reach a known condition
     * @param waitForTarget Whether to wait for the target element to reach a known condition
     */
    void DragAndDrop(By source, By target, Boolean waitForSource, Boolean waitForTarget);

    /**
     * Drags a WebElement and drops it at an offset position
     * @param element The WebElement being dragged
     * @param xOffset The x coordinate of the offset position
     * @param yOffset The y coordinate of the offset position
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void DragAndDropToOffset(WebElement element, int xOffset, int yOffset, Boolean wait);

    /**
     * Drags a WebElement and drops it at an offset position
     * @param locator The locator for the WebElement being dragged
     * @param xOffset The x coordinate of the offset position
     * @param yOffset The y coordinate of the offset position
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void DragAndDropToOffset(By locator, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor to a WebElement and presses a key
     * @param element The WebElement on which the key is to be pressed
     * @param key The key to be pressed
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void KeyDownOnElement(WebElement element, Keys key, Boolean wait);

    /**
     * Moves the virtual cursor to a WebElement and presses a key
     * @param locator The locator for the WebElement on which the key is to be pressed
     * @param key The key to be pressed
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void KeyDownOnElement(By locator, Keys key, Boolean wait);

    /**
     * Releases a depressed key which a WebElement is selected
     * @param element The target WebElement for the key release
     * @param key The key to be released
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void KeyUpOnElement(WebElement element, Keys key, Boolean wait);

    /**
     * Releases a depressed key which a WebElement is selected
     * @param locator The locator for the target WebElement for the key release
     * @param key The key to be released
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void KeyUpOnElement(By locator, Keys key, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param element The WebElement from which the cursor will move
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void MoveByOffset(WebElement element, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param locator The locator for the WebElement from which the cursor will move
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void MoveByOffset(By locator, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param element The WebElement from which the cursor will move<
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void MoveToElementWithOffset(WebElement element, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param locator The locator for the WebElement from which the cursor will move
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void MoveToElementWithOffset(By locator, int xOffset, int yOffset, Boolean wait);

    /**
     * Releases the mouse button over a WebElement
     * @param element The WebElement over which to release the mouse button
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ReleaseMouseButton(WebElement element, Boolean wait);

    /**
     * Releases the mouse button over a WebElement
     * @param locator The locator for the WebElement over which to release the mouse button
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ReleaseMouseButton(By locator, Boolean wait);

    /**
     * Sends a sequence of keystrokes to the WebElement specified
     * @param element The WebElement that receives the keystrokes
     * @param text The keystrokes that are to be sent to the WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SendValueToField(WebElement element, Keys text, Boolean wait);

    /**
     * Sends a sequence of keystrokes to the WebElement specified
     * @param locator The locator for the WebElement that receives the keystrokes
     * @param text The keystrokes that are to be sent to the WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SendValueToField(By locator, Keys text, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param element The dropdown menu
     * @param item The item to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SelectItemFromDropdown(WebElement element, String item, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param locator The locator for the dropdown menu
     * @param item The item to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SelectItemFromDropdown(By locator, String item, Boolean wait);

    /**
     * Selects an item from a dropdown by row number
     * @param element The dropdown menu
     * @param row The row number to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SelectRowFromDropdown(WebElement element, int row, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param locator The locator for the dropdown menu
     * @param row The row number to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SelectRowFromDropdown(By locator, int row, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param element The dropdown menu
     * @param value The value to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state<
     */
    void SelectValueFromDropdown(WebElement element, String value, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param locator The locator for the dropdown menu
     * @param value The value to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void SelectValueFromDropdown(By locator, String value, Boolean wait);

    //endregion

    //region RatDriverManagement

    /**
     * Gets a reference to the encapsulated WebDriver
     * @return The encapsulated IWebDriver
     */
    WebDriver ReturnEncapsulatedDriver();

    /**
     * Checks if a cookie exists
     * @param cookieName The name of the cookie to check for
     * @return A Boolean value indicating whether the cookie exists
     */
    Boolean DoesCookieExist(String cookieName);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     */
    void AddCookie(String name, String value);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     * @param path The path of the cookie
     */
    void AddCookie(String name, String value, String path);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void AddCookie(String name, String value, String path, Date expiry);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     * @param domain The domain for which the cookie is being added
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void AddCookie(String name, String value, String domain, String path, Date expiry);

    /**
     * Adds a predefined cookie to the current browser session
     * @param cookie The cookie to be added
     */
    void AddCookie(Cookie cookie);

    /**
     * Gets a list of cookies currently saved by the browser
     * @return The list of cookies
     */
    Set<Cookie> GetCookies();

    /**
     * Deletes all cookies currently found in the browser
     */
    void DeleteAllCookies();

    /**
     * Deletes a cookie, given a copy of that cookie
     * @param cookie The definition of the cookie to be deleted
     */
    void DeleteCookie(Cookie cookie);

    /**
     * Deletes a named cookie
     * @param cookie The name of the cookie
     */
    void DeleteCookieNamed(String cookie);

    /**
     * Gets a cookie from the browser
     * @param cookie The name of the cookie to find
     * @return The named cookie
     */
    Cookie GetCookieNamed(String cookie);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     */
    void ReplaceCookie(String name, String value);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     * @param path The path of the cookie
     */
    void ReplaceCookie(String name, String value, String path);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void ReplaceCookie(String name, String value, String path, Date expiry);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     * @param domain The domain for which the cookie is being added
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void ReplaceCookie(String name, String value, String domain, String path, Date expiry);

    /**
     * Gets a list of available log types
     * @return The list of log types
     */
    Set<String> GetAvailableLogTypes();

    /**
     * Gets the available log entries for a particular log type
     * @param logKind The type of log to consult
     * @return The list of log entries
     */
    List<LogEntry> GetAvailableLogEntries(String logKind);

    /**
     * Sets the implicit wait via a method.
     * @param minutes The number of minutes in the  implicit wait
     * @param seconds The number of seconds in the  implicit wait
     * @param milliseconds The number of milliseconds in the  implicit wait
     */
    void SetImplicitWait(int minutes, int seconds, int milliseconds);

    /**
     * Sets the page load timeout via a method.
     * @param minutes The number of minutes in the  page load timeout
     * @param seconds The number of seconds in the  page load timeout
     * @param milliseconds The number of milliseconds in the page load timeout
     */
    void SetPageLoadTimeout(int minutes, int seconds, int milliseconds);

    /**
     * Sets the script timeout via a method.
     * @param minutes The number of minutes in the script timeout
     * @param seconds The number of seconds in the script timeout
     * @param milliseconds The number of milliseconds in the script timeout
     */
    void SetScriptTimeout(int minutes, int seconds, int milliseconds);

    /**
     * Maximises the current window
     */
    void MaximiseView();

    /**
     * Gets the current window position
     * @return An object containing the x and y coordinates of the top left corner of the window
     */
    Point GetWindowPosition();

    /**
     * Gets the current window size
     * @return An object containing the width and height of the current window
     */
    Dimension GetWindowSize();

    /**
     * Resize the browser window to the assigned width and height
     * @param width The width to assign to the browser
     * @param height The height to assign to the browser
     */
    void ResizeBrowserWindow(int width, int height);

    /**
     *Presses the back button of the browser
     */
    void PressBackButton();

    /**
     * Presses the forward button of the browser
     */
    void PressForwardButton();

    /**
     * Navigates to a particular website by URL
     * @param url The URL of the website to load in the browser
     */
    void NavigateToPage(String url);

    /**
     * Refreshes the currently selected browser
     */
    void RefreshBrowser();

    /**
     * Checks the entire html source for the page for a piece of text
     * @param text The text to search the page for
     * @return True if the page contains the text
     */
    Boolean CheckPageSourceForText(String text);

    /**
     * Gets the source code for the page
     * @return The Page Source
     */
    String GetPageSource();

    /**
     * Closes the browser pages and quits the driver
     */
    void ClosePagesAndQuitDriver();

    /**
     * Checks if a window is open, using its window handle
     * @param window The window handle to query
     * @return A true/false value
     */
    Boolean IsWindowOpen(String window);

    /**
     * Switches to the currently active WebElement
     */
    void SwitchToActiveWebElement();

    /**
     * Switches to the currently active Alert Dialog
     */
    void SwitchToAlertDialog();

    /**
     * Switches to the original frame or window
     */
    void SwitchToDefaultContent();

    /**
     * Switches to a numbered frame by index
     * @param frameIndex The index number for the frame
     */
    void SwitchToFrame(int frameIndex);

    /**
     * Switches to the frame identified by the WebElement
     * @param frameElement A WebElement representing the frame to activate
     */
    void SwitchToFrame(WebElement frameElement);

    /**
     * Switches to the frame identified by the WebElement
     * @param frameLocator The locator for the WebElement representing the frame to activate
     */
    void SwitchToFrame(By frameLocator);

    /**
     * Switches to the frame identified by the WebElement
     * @param frameName The name of the frame to activate
     */
    void SwitchToFrame(String frameName);

    /**
     * Switches to the parent frame of a selected WebElement
     */
    void SwitchToParentFrame();

    /**
     * Switches to a window, given the name of that window
     * @param windowName The name of the window to switch to
     */
    void SwitchToWindow(String windowName);

    /**
     * Gets the title of the currently active browser
     * @return The name of the currently active window
     */
    String GetBrowserWindowTitle();

    /**
     * Gets the URL in the currently active browser window
     * @return The URL for the browser
     */
    String GetBrowserWindowUrl();

    /**
     * Gets the Window Handle for the currently selected page
     * @return A window handle representing a unique reference to a page
     */
    String GetCurrentWindowHandle();


    /**
     * Gets a list of WindowHandles for all windows under the control of the current driver session
     * @return A collection of WindowHandles
     */
    Set<String> GetAllWindowHandles();

    /**
     * Opens a new window using the send keys command
     */
    void OpenNewView();

    /**
     * Closes the currently selected window
     */
    void CloseView();

    //endregion

    //region RatDriver Methods

    /**
     * Waits for an element to be loaded
     * @param element The element for which to wait
     */
    void WaitForElementToLoad(WebElement element);

    /**
     * Waits for an element to be loaded
     * @param locator The locator for the element for which to wait
     */
    void WaitForElementToLoad(By locator);

    /**
     * Waits for an element to be loaded
     * @param element The element for which to wait
     * @param seconds Maximum number of seconds to wait
     */
    void WaitForElementToLoad(WebElement element, int seconds);

    /**
     * Waits for an element to be loaded
     * @param locator The locator for the element for which to wait
     * @param seconds Maximum number of seconds to wait
     */
    void WaitForElementToLoad(By locator, int seconds);

    /**
     * Waits for a page to load
     * @param element An element from the previous page. If omitted, the code will wait for the body of the page to be visible
     */
    void WaitForPageToLoad(WebElement element);

    /**
     * Waits for an element to disappear from the DOM
     * @param locator The locator for the element for which to wait
     */
    void WaitForInvisibilityOfElement(By locator);

    /**
     * Waits for an element containing text to disappear from the DOM
     * @param locator The locator for the element for which to wait
     * @param text The text that should be found in the element
     */
    void WaitForInvisibilityOfElementWithText(By locator, String text);

    /**
     * Clicks on a WebElement
     * @param element The WebElement on which to click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickLink(WebElement element, Boolean wait);

    /**
     * Clicks on a WebElement
     * @param locator The locator for the WebElement on which to click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void ClickLink(By locator, Boolean wait);

    /**
     * Clicks on a link and waits for a new page to be loaded
     * @param element The element on which to click
     */
    void ClickLinkAndWait(WebElement element);

    /**
     * Clicks on a link and waits for a new page to be loaded
     * @param locator The element on which to click
     */
    void ClickLinkAndWait(By locator);

    /**
     * Clicks on a link and waits for a new page to be loaded that contains a specified URL or part URL
     * @param element The element on which to click
     * @param url The partial URL to be waited for
     */
    void ClickLinkAndWaitForUrl(WebElement element, String url);

    /**
     * Clicks on a link and waits for a new page to be loaded that contains a specified URL or part URL
     * @param locator The locator for the element on which to click
     * @param url The partial URL to be waited for
     */
    void ClickLinkAndWaitForUrl(By locator, String url);

    /**
     * Gets the text of a WebElement
     * @param element The WebElement from which to retrieve text
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return The text of the WebElement
     */
    String GetElementText(WebElement element, Boolean wait);

    /**
     * Gets the text of a WebElement
     * @param locator The WebElement from which to retrieve text
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return The text of the WebElement
     */
    String GetElementText(By locator, Boolean wait);

    /**
     * Checks the browser for the presence of a particular WebElement
     * @param element The WebElement whose presence is tested
     * @return True if the WebElement is present; false if the WebElement is not present
     */
    Boolean ElementExists(WebElement element);

    /**
     * Checks the browser for the presence of a particular WebElement
     * @param locator The locator for the WebElement whose presence is tested
     * @return True if the WebElement is present; false if the WebElement is not present
     */
    Boolean ElementExists(By locator);

    /**
     * Gets an attribute of a WebElement and returns it as text
     * @param element The WebElement whose attributes are to be tested
     * @param attribute The attribute value to retrieve
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return True if the WebElement is present; false if the WebElement is not present
     */
    String GetElementAttribute(WebElement element, String attribute, Boolean wait);

    /**
     * Gets an attribute of a WebElement and returns it as text
     * @param locator The locator for the WebElement whose attributes are to be tested
     * @param attribute The attribute value to retrieve
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return The attribute to retrieve
     */
    String GetElementAttribute(By locator, String attribute, Boolean wait);

    /**
     * Finds an element with a unique CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElements that has the CSS Selector
     */
    WebElement FindElementByCssSelector(String cssSelector, Boolean wait);

    /**
     * Finds a list of elements that share a CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of WebElements that share the CSS Selector
     */
    List<WebElement> FindElementsByCssSelector(String cssSelector, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByCssSelector(String cssSelector, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByCssSelector(String cssSelector, By locator, Boolean wait);

    /**
     * Finds a WebElement that has a Class Name
     * @param className The Class Name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement described by the Class Name
     */
    WebElement FindElementByClassName(String className, Boolean wait);

    /**
     * Finds a list of elements that share a Class Name
     * @param className The Class Name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindElementsByClassName(String className, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a Class Name
     * @param className The Class Name to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state<
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByClassName(String className, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a Class Name
     * @param cssSelector The Class Name to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByClassName(String cssSelector, By locator, Boolean wait);

    /**
     * Finds a WebElement whose id is as specified
     * @param id The id to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement with the specified id
     */
    WebElement FindElementById(String id, Boolean wait);

    /**
     * Finds a WebElement whose link text is as specified
     * @param linkText The text to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement with the specified Link Text
     */
    WebElement FindElementByLinkText(String linkText, Boolean wait);

    /**
     * Finds a list of elements that whose link text is as specified
     * @param linkText The text to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindElementsByLinkText(String linkText, Boolean wait);


    /**
     * Finds the child elements of a given WebElement whose link text is as specified
     * @param linkText The text to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByLinkText(String linkText, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement whose link text is as specified
     * @param linkText The text to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByLinkText(String linkText, By locator, Boolean wait);

    /**
     * Finds a WebElement by name
     * @param name The name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement FindElementByName(String name, Boolean wait);

    /**
     * Finds a list of elements that share a name
     * @param name The name to search for
     * @param wait (Optional parameA collection of child WebElementster) Whether to wait for the element to reach a known state
     * @return A collection of WebElements
     */
    List<WebElement> FindElementsByName(String name, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a name
     * @param name The name to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByName(String name, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a name
     * @param name The name to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByName(String name, By locator, Boolean wait);

    /**
     * Finds a WebElement whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement FindElementByPartialLinkText(String linkText, Boolean wait);

    /**
     * Finds a list of elements whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindElementsByPartialLinkText(String linkText, Boolean wait);

    /**
     * Finds the child elements of a given WebElement whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByPartialLinkText(String linkText, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByPartialLinkText(String linkText, By locator, Boolean wait);

    /**
     * Finds a WebElement that possesses a tag
     * @param tagName The tag to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement FindElementByTag(String tagName, Boolean wait);

    /**
     * Finds a list of elements that share a tag
     * @param tagName The tag to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindElementsByTag(String tagName, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a tag
     * @param tagName The tag to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByTag(String tagName, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a tag
     * @param tagName The tag to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByTag(String tagName, By locator, Boolean wait);

    /**
     * Finds a Web Elements by its xpath
     * @param xpath The xpath to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement FindElementByXPath(String xpath, Boolean wait);

    /**
     * Finds a list of elements that share an xpath
     * @param xpath The xpath to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindElementsByXPath(String xpath, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share an xpath
     * @param xpath The xpath to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByXPath(String xpath, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share an xpath
     * @param xpath The xpath to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> FindSubElementsByXPath(String xpath, By locator, Boolean wait);

    /**
     * Finds a WebElement identified by an attribute value from a collection of WebElements sharing a parent
     * @param parentElement The parent element for the process
     * @param type The type of locator to use to fetch the collection
     * @param locator The locator value for items in the collection
     * @param attribute The HTML attribute to use to find the unique item
     * @param value The value of the attribute of the unique item
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A web element identified by a locator type and an attribute value
     */
    WebElement ExtractElementFromCollectionByAttribute(WebElement parentElement, LocatorType type, String locator, String attribute, String value, Boolean wait);

    /**
     * Finds a WebElement identified by an attribute value from a collection of WebElements sharing a parent
     * @param parentLocator The locator for the parent element for the process
     * @param type The type of locator to use to fetch the collection
     * @param locator The locator value for items in the collection
     * @param attribute The HTML attribute to use to find the unique item
     * @param value The value of the attribute of the unique item
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A web element identified by a locator type and an attribute value
     */
    WebElement ExtractElementFromCollectionByAttribute(By parentLocator, LocatorType type, String locator, String attribute, String value, Boolean wait);

    //endregion

    //region Additional Methods

    /**
     * Takes a screenshot of the active web page
     * @param path The path and name under which to save the image
     */
    void TakeScreenshot(String path);

    /**
     * Returns a JavaScript Executor to the end user for custom JavaScript
     * @return A JavaScript Executor
     */
    JavascriptExecutor Scripts();

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     */
    void ExecuteJavaScript(String script);

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     * @param parameters The parameters for the passed JavaScript
     */
    void ExecuteJavaScript(String script, Object[] parameters);

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     */
    void ExecuteAsyncJavaScript(String script);

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     * @param parameters The parameters for the passed JavaScript
     */
    void ExecuteAsyncJavaScript(String script, Object[] parameters);

    /**
     * Scrolls to an element using JavaScript
     * @param webElement The Web element
     */
    void ScrollToElement(WebElement webElement);

    /**
     * Scrolls to an element using JavaScript
     * @param locator The the locator for the Web Element.
     */
    void ScrollToElement(By locator);

    /**
     * Adds an access key to a web element.
     * @param webElement The Web Element to receive the access key.
     * @param key The key to be used for access.
     */
    void AddAccessKeyToElement(WebElement webElement, String key);

    /**
     * Adds an access key to a web element.
     * @param locator The the locator for the Web Element to receive the access key.
     * @param key The key to be used for access.
     */
    void AddAccessKeyToElement(By locator, String key);

    /**
     * Gets an access key from a web element.
     * @param webElement The Web Element for which to retrieve the access key.
     */
    void GetAccessKeyForElement(WebElement webElement);

    /**
     * Gets an access key from a web element.
     * @param locator The locator for the Web Element for which to retrieve the access key.
     */
    void GetAccessKeyForElement(By locator);

    /**
     * Returns the number of web elements.
     * @param webElement The web element for which a child element count is required.
     * @return The number of child elements that the web element possesses.
     */
    int ChildElementCount(WebElement webElement);

    /**
     * Returns the number of web elements
     * @param locator The locator for the web element for which a child element count is required.
     * @return The number of web element
     */
    int ChildElementCount(By locator);

    /**
     * Gets the viewable area measurements of the element passed. This does not include borders, scrollbars or margins.
     * @param webElement The web element for which a child element count is required.
     * @return The viewable area measurements of the web element.
     */
    ElementSize GetElementSize(WebElement webElement);

    /**
     * Gets the viewable area measurements of the element passed. This does not include borders, scrollbars or margins.
     * @param locator The locator for the web element for which a child element count is required.
     * @return The viewable area measurements of the web element.
     */
    ElementSize GetElementSize(By locator);

    /**
     * Compares the positions for a pair of elements.
     * @param firstElement The first element of the pair.
     * @param secondElement The second element of the pair.
     * @return An enumerated value for the relative positions of the elements.
     */
    ElementRelationships CompareElementPositions(WebElement firstElement, WebElement secondElement);

    /**
     * Compares the positions for a pair of elements.
     * @param firstLocator The locator for the first element of the pair.
     * @param secondLocator The locator for the second element of the pair.
     * @return An enumerated value for the relative positions of the elements.
     */
    ElementRelationships CompareElementPositions(By firstLocator, By secondLocator);

    /**
     * Checks to see if an element is contained by another element.
     * @param firstElement The first element of the pair.
     * @param secondElement The second element of the pair.
     * @return True if the second element is a descendant of the first.
     */
    Boolean Contains(WebElement firstElement, WebElement secondElement);

    /**
     * Checks to see if an element is contained by another element.
     * @param firstLocator The locator for the first element of the pair.
     * @param secondLocator The locator for the second element of the pair.
     * @return True if the second element is a descendant of the first.
     */
    Boolean Contains(By firstLocator, By secondLocator);

    /**
     * Gives the focus to an element
     * @param webElement The Web Element
     */
    void GiveFocus(WebElement webElement);

    /**
     * Gives the focus to an element
     * @param locator The locator for the Web Element
     */
    void GiveFocus(By locator);

    /**
     * Gets the bounding rectangle for the element
     * @param webElement The web element
     * @return An object representing the bounding rectangle
     */
    DomRectangle GetBoundingRectangle(WebElement webElement);

    /**
     * Gets the bounding rectangle for the element
     * @param locator The locator for the web element
     * @return An object representing the bounding rectangle
     */
    DomRectangle GetBoundingRectangle(By locator);

    /**
     * Checks if a Web Element has a particular attribute
     * @param webElement The web element
     * @param attribute The attribute to check for.
     * @return True if the element has the given attribute.
     */
    Boolean HasAttribute(WebElement webElement, String attribute);

    /**
     * Checks if a Web Element has a particular attribute
     * @param locator The locator for the web element
     * @param attribute The attribute to check for.
     * @return True if the element has the given attribute.
     */
    Boolean HasAttribute(By locator, String attribute);

    /**
     * Checks whether the web element has any attributes.
     * @param webElement The Web Element.
     * @return True if the web element has any attributes.
     */
    Boolean HasAttributes(WebElement webElement);

    /**
     * Checks whether the web element has any attributes.
     * @param locator The locator for the Web Element.
     * @return True if the web element has any attributes.
     */
    Boolean HasAttributes(By locator);

    /**
     * Checks whether the web element has any child nodes.
     * @param webElement The Web Element.
     * @return True if the web element has any child nodes.
     */
    Boolean HasChildNodes(WebElement webElement);

    /**
     * Checks whether the web element has any child nodes.
     * @param locator The locator for the Web Element.
     * @return True if the web element has any child nodes.
     */
    Boolean HasChildNodes(By locator);

    /**
     * Checks if the content of an element is editable.
     * @param webElement The Web Element
     * @return True if the content is editable, false if not. Also may return Inherit, to denote it has inherited this status.
     */
    String IsContentEditable(WebElement webElement);

    /**
     * Checks if the content of an element is editable.
     * @param locator The the locator for the Web Element.
     * @return True if the content is editable, false if not. Also may return Inherit, to denote it has inherited this status.
     */
    String IsContentEditable(By locator);

    /**
     * Gets the language assigned to a WebElement
     * @param webElement The Web Element
     * @return The ISO 639-1 code for the language.
     */
    String GetElementLanguage(WebElement webElement);

    /**
     * Gets the language assigned to a WebElement
     * @param locator The locator for the Web Element
     * @return The ISO 639-1 code for the language.
     */
    String GetElementLanguage(By locator);

    /**
     * Gets the offsets for an element.
     * @param webElement The Web Element
     * @return An object representing the offsets of the element
     */
    HeightWidth GetOffsets(WebElement webElement);

    /**
     * Gets the offsets for an element.
     * @param locator The locator for the Web Element
     * @return An object representing the offsets of the element
     */
    HeightWidth GetOffsets(By locator);

    /**
     * Checks to see if an element is equal to another element.
     * @param firstElement The first element of the pair.
     * @param secondElement The second element of the pair.
     * @return True if the second element is equal to the first.
     */
    Boolean AreNodesEqual(WebElement firstElement, WebElement secondElement);

    /**
     * Checks to see if an element is equal to another element.
     * @param firstLocator The locator for the first element of the pair.
     * @param secondLocator The locator for the second element of the pair.
     * @return True if the second element is equal to the first.
     */
    Boolean AreNodesEqual(By firstLocator, By secondLocator);

    /**
     * Gets the height and width of an element in pixels, including padding, but not the border, scrollbar or margin.
     * @param webElement The Web Element
     * @return An object representing the scroll height and width of the element, along with current positioning.
     */
    ElementSize GetScrollSize(WebElement webElement);

    /**
     * Gets the height and width of an element in pixels, including padding, but not the border, scrollbar or margin.
     * @param locator The locator for the Web Element
     * @return An object representing the scroll height and width of the element, along with current positioning.
     */
    ElementSize GetScrollSize(By locator);

    /**
     * Returns the tab index of the chosen web element.
     * @param webElement The web element for which a tab index is required.
     * @return The tab index of the chosen element.
     */
    int GetTabIndex(WebElement webElement);

    /**
     * Returns the tab index of the chosen web element.
     * @param locator The locator for the web element for which a tab index is required.
     * @return The tab index of the chosen element.
     */
    int GetTabIndex(By locator);

    //endregion

    //region Wait Methods

    /**
     * Waits for an alert style dialog to be displayed
     * @return True if the wait terminates with an alert being found
     */
    Boolean WaitForAlertToBePresent();

    /**
     * Waits for an element to reach a clickable state
     * @param element The WebElement representing the object
     * @return True if the wait is terminated by the element becoming clickable
     */
    Boolean WaitForElementToBeClickable(WebElement element);

    /**
     * Waits for an element to reach a clickable state
     * @param locator The locator for the WebElement representing the object
     * @return True if the wait is terminated by the element becoming clickable
     */
    Boolean WaitForElementToBeClickable(By locator);

    /**
     * Waits for an element to have a selected status
     * @param locator The locator for the WebElement to await
     * @return True if the wait is terminated by the element being found to be selected
     */
    Boolean WaitForElementToBeSelected(By locator);

    /**
     * Waits for an element to have a selected status
     * @param element The WebElement to await
     * @return True if the wait is terminated by the element being found to be selected
     */
    Boolean WaitForElementToBeSelected(WebElement element);

    /**
     * Waits for an element to have a visible attribute of true
     * @param locator The locator for the WebElement to await
     * @return True if the wait is terminated by the element being found to be visible
     */
    Boolean WaitForElementToBeVisible(By locator);

    /**
     * Waits for the selection of an element to reach a certain state
     * @param locator The locator for the WebElement to be used
     * @param state The selection state to check for
     * @return True if the wait is terminated by the element being found to be in a given selection state.
     */
    Boolean WaitForElementSelectionStateToBe(By locator, Boolean state);

    /**
     * Waits for the selection of an element to reach a certain state
     * @param element The WebElement to await
     * @param state The selection state to check for
     * @return True if the wait is terminated by the element being found to be in a given selection state.
     */
    Boolean WaitForElementSelectionStateToBe(WebElement element, Boolean state);

    /**
     * Waits for a given element containing text to be invisible
     * @param locator The locator for the WebElement to be used
     * @return True if the elements is invisible, false if the wait expires.
     */
    Boolean WaitForElementInvisibility(By locator);

    /**
     * Waits for a given element containing text to be invisible or to be removed from the DOM
     * @param locator The locator for the WebElement to be used
     * @param text The text to be used in comparison
     * @return True if the elements with given text is invisible, false if the wait expires
     */
    Boolean WaitForElementInvisibilityWithText(By locator, String text);

    /**
     * Checks if any elements on the page match the locator
     * @param locator The locator for the WebElement to be used
     * @return True if the elements found by a locator are present, false if the wait expires or no elements are found.
     */
    Boolean WaitForPresenceOfAllElementsLocatedBy(By locator);

    /**
     * Waits for a given element to go stale
     * @param element The WebElement to check
     * @return True if the element becomes stale, false if the wait expires.
     */
    Boolean WaitForStalenessOf(WebElement element);

    /**
     * Waits until specified text is found within a given element
     * @param element The WebElement to check
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean WaitForTextToBePresentInElement(WebElement element, String text);

    /**
     * Waits until specified text is found within a given element
     * @param locator The locator for the WebElement to check
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean WaitForTextToBePresentInElement(By locator, String text);

    /**
     * Waits until specified text is found within a given element's value attribute
     * @param locator The locator for the WebElement to check
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean WaitForTextToBePresentInElementValue(By locator, String text);

    /**
     * Waits until a given String is found in the value attribute of the given element
     * @param element The element to observe
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean WaitForTextToBePresentInElementValue(WebElement element, String text);

    /**
     * Pauses execution until the title of the page title contains a given String
     * @param text The text to be used in comparison
     * @return True if the title contains the given text, false if the wait expires.
     */
    Boolean WaitForTitleToContain(String text);

    /**
     * Pauses execution until the title of the page title matches a given String
     * @param text The text to be used in comparison
     * @return True if the title matches the given text, false if the wait expires.
     */
    Boolean WaitForTitleToBe(String text);

    /**
     * Pauses execution until the url contains a given String
     * @param text The text to use in comparison.
     * @return True if the URL contains the given text, false if the wait expires.
     */
    Boolean WaitForUrlToContain(String text);

    /**
     * Pauses execution until the url matches a given String
     * @param text The text to use in comparison.
     * @return True if the URL matches the given text, false if the wait expires.
     */
    Boolean WaitForUrlToMatch(String text);

    /**
     * Pauses execution until the url matches a given String
     * @param text The text to use in comparison.
     * @return True if the URL matches the given text, false if the wait expires.
     */
    Boolean WaitForUrlToBe(String text);

    /**
     * Waits for all of the element identified by the locator to be visible
     * @param locator The locator to use to find elements
     * @return True if all elements located are visible, false if the wait expires.
     */
    Boolean WaitForVisibilityOfAllElementsLocatedBy(By locator);

    //endregion
}
