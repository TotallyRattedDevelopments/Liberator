package org.liberator.ratdriver;

import org.liberator.ratdriver.entities.*;
import org.liberator.ratdriver.enums.ElementRelationships;
import org.liberator.ratdriver.enums.LocatorType;
import org.openqa.selenium.*;
import org.openqa.selenium.logging.LogEntry;

import java.util.*;

@SuppressWarnings("unused")
public interface IRodent {

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
    void hoverOverMenu(WebElement element, Boolean wait);

    /**
     * Moves the virtual cursor position to a WebElement which acts as a menu and hovers
     * @param locator The locator for the WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void hoverOverMenu(By locator, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hover
     * @param element The WebElement acting as a menu<
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickAndHoverOverMenu(WebElement element, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hover
     * @param locator The locator for the WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickAndHoverOverMenu(By locator, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hold
     * @param element The WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickAndHoldMenu(WebElement element, Boolean wait);

    /**
     * Clicks on a WebElement acting as a menu and continues to hold
     * @param locator The locator for the WebElement acting as a menu
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickAndHoldMenu(By locator, Boolean wait);

    /**
     * Clicks on an element and displays a contextual menu
     * @param element The WebElement which is the target of the contextual menu click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickContextualMenu(WebElement element, Boolean wait);

    /**
     * Clicks on an element and displays a contextual menu
     * @param locator The locator for the WebElement which is the target of the contextual menu click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickContextualMenu(By locator, Boolean wait);

    /**
     * Double clicks on a WebElement
     * @param element The WebElement on which a double click is required
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void doubleClick(WebElement element, Boolean wait);

    /**
     * Double clicks on a WebElement
     * @param locator The locator for the WebElement which is the target of a double click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void doubleClick(By locator, Boolean wait);

    /**
     * Drags a WebElement over a target WebElement and drops it
     * @param source The Web Element being dragged
     * @param target The target WebElement for the action
     * @param waitForSource Whether to wait for the source element to reach a known condition
     * @param waitForTarget Whether to wait for the target element to reach a known condition
     */
    void dragAndDrop(WebElement source, WebElement target, Boolean waitForSource, Boolean waitForTarget);

    /**
     * Drags a WebElement over a target WebElement and drops it
     * @param source The locator for the Web Element being dragged
     * @param target The locator for the target WebElement for the action
     * @param waitForSource Whether to wait for the source element to reach a known condition
     * @param waitForTarget Whether to wait for the target element to reach a known condition
     */
    void dragAndDrop(By source, By target, Boolean waitForSource, Boolean waitForTarget);

    /**
     * Drags a WebElement and drops it at an offset position
     * @param element The WebElement being dragged
     * @param xOffset The x coordinate of the offset position
     * @param yOffset The y coordinate of the offset position
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void dragAndDropToOffset(WebElement element, int xOffset, int yOffset, Boolean wait);

    /**
     * Drags a WebElement and drops it at an offset position
     * @param locator The locator for the WebElement being dragged
     * @param xOffset The x coordinate of the offset position
     * @param yOffset The y coordinate of the offset position
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void dragAndDropToOffset(By locator, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor to a WebElement and presses a key
     * @param element The WebElement on which the key is to be pressed
     * @param key The key to be pressed
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void keyDownOnElement(WebElement element, Keys key, Boolean wait);

    /**
     * Moves the virtual cursor to a WebElement and presses a key
     * @param locator The locator for the WebElement on which the key is to be pressed
     * @param key The key to be pressed
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void keyDownOnElement(By locator, Keys key, Boolean wait);

    /**
     * Releases a depressed key which a WebElement is selected
     * @param element The target WebElement for the key release
     * @param key The key to be released
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void keyUpOnElement(WebElement element, Keys key, Boolean wait);

    /**
     * Releases a depressed key which a WebElement is selected
     * @param locator The locator for the target WebElement for the key release
     * @param key The key to be released
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void keyUpOnElement(By locator, Keys key, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param element The WebElement from which the cursor will move
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void moveByOffset(WebElement element, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param locator The locator for the WebElement from which the cursor will move
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void moveByOffset(By locator, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param element The WebElement from which the cursor will move<
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void moveToElementWithOffset(WebElement element, int xOffset, int yOffset, Boolean wait);

    /**
     * Moves the virtual cursor by an offset from a WebElement
     * @param locator The locator for the WebElement from which the cursor will move
     * @param xOffset The x coordinate offset for the movement
     * @param yOffset The y coordinate offset for the movement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void moveToElementWithOffset(By locator, int xOffset, int yOffset, Boolean wait);

    /**
     * Releases the mouse button over a WebElement
     * @param element The WebElement over which to release the mouse button
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void releaseMouseButton(WebElement element, Boolean wait);

    /**
     * Releases the mouse button over a WebElement
     * @param locator The locator for the WebElement over which to release the mouse button
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void releaseMouseButton(By locator, Boolean wait);

    /**
     * Sends a sequence of keystrokes to the WebElement specified
     * @param element The WebElement that receives the keystrokes
     * @param text The keystrokes that are to be sent to the WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void sendValueToField(WebElement element, Keys text, Boolean wait);

    /**
     * Sends a sequence of keystrokes to the WebElement specified
     * @param locator The locator for the WebElement that receives the keystrokes
     * @param text The keystrokes that are to be sent to the WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void sendValueToField(By locator, Keys text, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param element The dropdown menu
     * @param item The item to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void selectItemFromDropdown(WebElement element, String item, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param locator The locator for the dropdown menu
     * @param item The item to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void selectItemFromDropdown(By locator, String item, Boolean wait);

    /**
     * Selects an item from a dropdown by row number
     * @param element The dropdown menu
     * @param row The row number to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void selectRowFromDropdown(WebElement element, int row, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param locator The locator for the dropdown menu
     * @param row The row number to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void selectRowFromDropdown(By locator, int row, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param element The dropdown menu
     * @param value The value to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state<
     */
    void selectValueFromDropdown(WebElement element, String value, Boolean wait);

    /**
     * Selects an item from a dropdown by text value
     * @param locator The locator for the dropdown menu
     * @param value The value to choose
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void selectValueFromDropdown(By locator, String value, Boolean wait);

    //endregion

    //region RatDriverManagement

    /**
     * Gets a reference to the encapsulated WebDriver
     * @return The encapsulated IWebDriver
     */
    WebDriver returnEncapsulatedDriver();

    /**
     * Checks if a cookie exists
     * @param cookieName The name of the cookie to check for
     * @return A Boolean value indicating whether the cookie exists
     */
    Boolean doesCookieExist(String cookieName);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     */
    void addCookie(String name, String value);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     * @param path The path of the cookie
     */
    void addCookie(String name, String value, String path);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void addCookie(String name, String value, String path, Date expiry);

    /**
     * Adds a cookie to the browser
     * @param name The name of the cookie to add
     * @param value The value set within the cookie
     * @param domain The domain for which the cookie is being added
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void addCookie(String name, String value, String domain, String path, Date expiry);

    /**
     * Adds a predefined cookie to the current browser session
     * @param cookie The cookie to be added
     */
    void addCookie(Cookie cookie);

    /**
     * Gets a list of cookies currently saved by the browser
     * @return The list of cookies
     */
    Set<Cookie> getCookies();

    /**
     * Deletes all cookies currently found in the browser
     */
    void deleteAllCookies();

    /**
     * Deletes a cookie, given a copy of that cookie
     * @param cookie The definition of the cookie to be deleted
     */
    void deleteCookie(Cookie cookie);

    /**
     * Deletes a named cookie
     * @param cookie The name of the cookie
     */
    void deleteCookieNamed(String cookie);

    /**
     * Gets a cookie from the browser
     * @param cookie The name of the cookie to find
     * @return The named cookie
     */
    Cookie getCookieNamed(String cookie);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     */
    void replaceCookie(String name, String value);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     * @param path The path of the cookie
     */
    void replaceCookie(String name, String value, String path);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void replaceCookie(String name, String value, String path, Date expiry);

    /**
     * Deletes and then replaces a named cookie
     * @param name The name of the cookie
     * @param value The value to set within the cookie
     * @param domain The domain for which the cookie is being added
     * @param path The path of the cookie
     * @param expiry The date and time at which the cookie expires
     */
    void replaceCookie(String name, String value, String domain, String path, Date expiry);

    /**
     * Gets a list of available log types
     * @return The list of log types
     */
    Set<String> getAvailableLogTypes();

    /**
     * Gets the available log entries for a particular log type
     * @param logKind The type of log to consult
     * @return The list of log entries
     */
    List<LogEntry> getAvailableLogEntries(String logKind);

    /**
     * Sets the implicit wait via a method.
     * @param minutes The number of minutes in the  implicit wait
     * @param seconds The number of seconds in the  implicit wait
     * @param milliseconds The number of milliseconds in the  implicit wait
     */
    void setImplicitWait(int minutes, int seconds, int milliseconds);

    /**
     * Sets the page load timeout via a method.
     * @param minutes The number of minutes in the  page load timeout
     * @param seconds The number of seconds in the  page load timeout
     * @param milliseconds The number of milliseconds in the page load timeout
     */
    void setPageLoadTimeout(int minutes, int seconds, int milliseconds);

    /**
     * Sets the script timeout via a method.
     * @param minutes The number of minutes in the script timeout
     * @param seconds The number of seconds in the script timeout
     * @param milliseconds The number of milliseconds in the script timeout
     */
    void setScriptTimeout(int minutes, int seconds, int milliseconds);

    /**
     * Maximises the current window
     */
    void maximiseView();

    /**
     * Gets the current window position
     * @return An object containing the x and y coordinates of the top left corner of the window
     */
    Point getWindowPosition();

    /**
     * Gets the current window size
     * @return An object containing the width and height of the current window
     */
    Dimension getWindowSize();

    /**
     * Resize the browser window to the assigned width and height
     * @param width The width to assign to the browser
     * @param height The height to assign to the browser
     */
    void resizeBrowserWindow(int width, int height);

    /**
     *Presses the back button of the browser
     */
    void pressBackButton();

    /**
     * Presses the forward button of the browser
     */
    void pressForwardButton();

    /**
     * Navigates to a particular website by URL
     * @param url The URL of the website to load in the browser
     */
    void navigateToPage(String url);

    /**
     * Refreshes the currently selected browser
     */
    void refreshBrowser();

    /**
     * Checks the entire html source for the page for a piece of text
     * @param text The text to search the page for
     * @return True if the page contains the text
     */
    Boolean checkPageSourceForText(String text);

    /**
     * Gets the source code for the page
     * @return The Page Source
     */
    String getPageSource();

    /**
     * Closes the browser pages and quits the driver
     */
    void closePagesAndQuitDriver();

    /**
     * Checks if a window is open, using its window handle
     * @param window The window handle to query
     * @return A true/false value
     */
    Boolean isWindowOpen(String window);

    /**
     * Switches to the currently active WebElement
     */
    void switchToActiveWebElement();

    /**
     * Switches to the currently active Alert Dialog
     */
    void switchToAlertDialog();

    /**
     * Switches to the original frame or window
     */
    void switchToDefaultContent();

    /**
     * Switches to a numbered frame by index
     * @param frameIndex The index number for the frame
     */
    void switchToFrame(int frameIndex);

    /**
     * Switches to the frame identified by the WebElement
     * @param frameElement A WebElement representing the frame to activate
     */
    void switchToFrame(WebElement frameElement);

    /**
     * Switches to the frame identified by the WebElement
     * @param frameLocator The locator for the WebElement representing the frame to activate
     */
    void switchToFrame(By frameLocator);

    /**
     * Switches to the frame identified by the WebElement
     * @param frameName The name of the frame to activate
     */
    void switchToFrame(String frameName);

    /**
     * Switches to the parent frame of a selected WebElement
     */
    void switchToParentFrame();

    /**
     * Switches to a window, given the name of that window
     * @param windowName The name of the window to switch to
     */
    void switchToWindow(String windowName);

    /**
     * Gets the title of the currently active browser
     * @return The name of the currently active window
     */
    String getBrowserWindowTitle();

    /**
     * Gets the URL in the currently active browser window
     * @return The URL for the browser
     */
    String getBrowserWindowUrl();

    /**
     * Gets the Window Handle for the currently selected page
     * @return A window handle representing a unique reference to a page
     */
    String getCurrentWindowHandle();


    /**
     * Gets a list of WindowHandles for all windows under the control of the current driver session
     * @return A collection of WindowHandles
     */
    Set<String> getAllWindowHandles();

    /**
     * Opens a new window using the send keys command
     */
    void openNewView();

    /**
     * Closes the currently selected window
     */
    void closeView();

    //endregion

    //region RatDriver Methods

    /**
     * Waits for an element to be loaded
     * @param element The element for which to wait
     */
    void waitForElementToLoad(WebElement element);

    /**
     * Waits for an element to be loaded
     * @param locator The locator for the element for which to wait
     */
    void waitForElementToLoad(By locator);

    /**
     * Waits for an element to be loaded
     * @param element The element for which to wait
     * @param seconds Maximum number of seconds to wait
     */
    void waitForElementToLoad(WebElement element, int seconds);

    /**
     * Waits for an element to be loaded
     * @param locator The locator for the element for which to wait
     * @param seconds Maximum number of seconds to wait
     */
    void waitForElementToLoad(By locator, int seconds);

    /**
     * Waits for a page to load
     * @param element An element from the previous page. If omitted, the code will wait for the body of the page to be visible
     */
    void waitForPageToLoad(WebElement element);

    /**
     * Waits for an element to disappear from the DOM
     * @param locator The locator for the element for which to wait
     */
    void waitForInvisibilityOfElement(By locator);

    /**
     * Waits for an element containing text to disappear from the DOM
     * @param locator The locator for the element for which to wait
     * @param text The text that should be found in the element
     */
    void waitForInvisibilityOfElementWithText(By locator, String text);

    /**
     * Clicks on a WebElement
     * @param element The WebElement on which to click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickLink(WebElement element, Boolean wait);

    /**
     * Clicks on a WebElement
     * @param locator The locator for the WebElement on which to click
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     */
    void clickLink(By locator, Boolean wait);

    /**
     * Clicks on a link and waits for a new page to be loaded
     * @param element The element on which to click
     */
    void clickLinkAndWait(WebElement element);

    /**
     * Clicks on a link and waits for a new page to be loaded
     * @param locator The element on which to click
     */
    void clickLinkAndWait(By locator);

    /**
     * Clicks on a link and waits for a new page to be loaded that contains a specified URL or part URL
     * @param element The element on which to click
     * @param url The partial URL to be waited for
     */
    void clickLinkAndWaitForUrl(WebElement element, String url);

    /**
     * Clicks on a link and waits for a new page to be loaded that contains a specified URL or part URL
     * @param locator The locator for the element on which to click
     * @param url The partial URL to be waited for
     */
    void clickLinkAndWaitForUrl(By locator, String url);

    /**
     * Gets the text of a WebElement
     * @param element The WebElement from which to retrieve text
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return The text of the WebElement
     */
    String getElementText(WebElement element, Boolean wait);

    /**
     * Gets the text of a WebElement
     * @param locator The WebElement from which to retrieve text
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return The text of the WebElement
     */
    String getElementText(By locator, Boolean wait);

    /**
     * Checks the browser for the presence of a particular WebElement
     * @param element The WebElement whose presence is tested
     * @return True if the WebElement is present; false if the WebElement is not present
     */
    Boolean elementExists(WebElement element);

    /**
     * Checks the browser for the presence of a particular WebElement
     * @param locator The locator for the WebElement whose presence is tested
     * @return True if the WebElement is present; false if the WebElement is not present
     */
    Boolean elementExists(By locator);

    /**
     * Gets an attribute of a WebElement and returns it as text
     * @param element The WebElement whose attributes are to be tested
     * @param attribute The attribute value to retrieve
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return True if the WebElement is present; false if the WebElement is not present
     */
    String getElementAttribute(WebElement element, String attribute, Boolean wait);

    /**
     * Gets an attribute of a WebElement and returns it as text
     * @param locator The locator for the WebElement whose attributes are to be tested
     * @param attribute The attribute value to retrieve
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return The attribute to retrieve
     */
    String getElementAttribute(By locator, String attribute, Boolean wait);

    /**
     * Finds an element with a unique CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElements that has the CSS Selector
     */
    WebElement findElementByCssSelector(String cssSelector, Boolean wait);

    /**
     * Finds a list of elements that share a CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of WebElements that share the CSS Selector
     */
    List<WebElement> findElementsByCssSelector(String cssSelector, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByCssSelector(String cssSelector, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a CSS Selector
     * @param cssSelector The CSS Selector to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByCssSelector(String cssSelector, By locator, Boolean wait);

    /**
     * Finds a WebElement that has a Class Name
     * @param className The Class Name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement described by the Class Name
     */
    WebElement findElementByClassName(String className, Boolean wait);

    /**
     * Finds a list of elements that share a Class Name
     * @param className The Class Name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findElementsByClassName(String className, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a Class Name
     * @param className The Class Name to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state<
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByClassName(String className, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a Class Name
     * @param cssSelector The Class Name to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByClassName(String cssSelector, By locator, Boolean wait);

    /**
     * Finds a WebElement whose id is as specified
     * @param id The id to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement with the specified id
     */
    WebElement findElementById(String id, Boolean wait);

    /**
     * Finds a WebElement whose link text is as specified
     * @param linkText The text to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement with the specified Link Text
     */
    WebElement findElementByLinkText(String linkText, Boolean wait);

    /**
     * Finds a list of elements that whose link text is as specified
     * @param linkText The text to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findElementsByLinkText(String linkText, Boolean wait);


    /**
     * Finds the child elements of a given WebElement whose link text is as specified
     * @param linkText The text to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByLinkText(String linkText, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement whose link text is as specified
     * @param linkText The text to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByLinkText(String linkText, By locator, Boolean wait);

    /**
     * Finds a WebElement by name
     * @param name The name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement findElementByName(String name, Boolean wait);

    /**
     * Finds a list of elements that share a name
     * @param name The name to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of WebElements
     */
    List<WebElement> findElementsByName(String name, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a name
     * @param name The name to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByName(String name, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a name
     * @param name The name to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByName(String name, By locator, Boolean wait);

    /**
     * Finds a WebElement whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement findElementByPartialLinkText(String linkText, Boolean wait);

    /**
     * Finds a list of elements whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findElementsByPartialLinkText(String linkText, Boolean wait);

    /**
     * Finds the child elements of a given WebElement whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByPartialLinkText(String linkText, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement whose link text is matched in part
     * @param linkText The text to find in whole or in part
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByPartialLinkText(String linkText, By locator, Boolean wait);

    /**
     * Finds a WebElement that possesses a tag
     * @param tagName The tag to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement findElementByTag(String tagName, Boolean wait);

    /**
     * Finds a list of elements that share a tag
     * @param tagName The tag to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findElementsByTag(String tagName, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a tag
     * @param tagName The tag to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByTag(String tagName, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share a tag
     * @param tagName The tag to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByTag(String tagName, By locator, Boolean wait);

    /**
     * Finds a Web Elements by its xpath
     * @param xpath The xpath to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A WebElement
     */
    WebElement findElementByXPath(String xpath, Boolean wait);

    /**
     * Finds a list of elements that share an xpath
     * @param xpath The xpath to search for
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findElementsByXPath(String xpath, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share an xpath
     * @param xpath The xpath to search for
     * @param element The parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByXPath(String xpath, WebElement element, Boolean wait);

    /**
     * Finds the child elements of a given WebElement that share an xpath
     * @param xpath The xpath to search for
     * @param locator The locator for the parent WebElement
     * @param wait (Optional parameter) Whether to wait for the element to reach a known state
     * @return A collection of child WebElements
     */
    List<WebElement> findSubElementsByXPath(String xpath, By locator, Boolean wait);

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
    WebElement extractElementFromCollectionByAttribute(WebElement parentElement, LocatorType type, String locator, String attribute, String value, Boolean wait);

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
    WebElement extractElementFromCollectionByAttribute(By parentLocator, LocatorType type, String locator, String attribute, String value, Boolean wait);

    //endregion

    //region Additional Methods

    /**
     * Takes a screenshot of the active web page
     * @param path The path and name under which to save the image
     */
    void takeScreenshot(String path);

    /**
     * Returns a JavaScript Executor to the end user for custom JavaScript
     * @return A JavaScript Executor
     */
    JavascriptExecutor scripts();

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     */
    void executeJavaScript(String script);

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     * @param parameters The parameters for the passed JavaScript
     */
    void executeJavaScript(String script, Object[] parameters);

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     */
    void executeAsyncJavaScript(String script);

    /**
     * Executes a JavaScript statement passed as a String
     * @param script The JavaScript to be executed
     * @param parameters The parameters for the passed JavaScript
     */
    void executeAsyncJavaScript(String script, Object[] parameters);

    /**
     * Scrolls to an element using JavaScript
     * @param webElement The Web element
     */
    void scrollToElement(WebElement webElement);

    /**
     * Scrolls to an element using JavaScript
     * @param locator The the locator for the Web Element.
     */
    void scrollToElement(By locator);

    /**
     * Adds an access key to a web element.
     * @param webElement The Web Element to receive the access key.
     * @param key The key to be used for access.
     */
    void addAccessKeyToElement(WebElement webElement, String key);

    /**
     * Adds an access key to a web element.
     * @param locator The the locator for the Web Element to receive the access key.
     * @param key The key to be used for access.
     */
    void addAccessKeyToElement(By locator, String key);

    /**
     * Gets an access key from a web element.
     * @param webElement The Web Element for which to retrieve the access key.
     */
    void getAccessKeyForElement(WebElement webElement);

    /**
     * Gets an access key from a web element.
     * @param locator The locator for the Web Element for which to retrieve the access key.
     */
    void getAccessKeyForElement(By locator);

    /**
     * Returns the number of web elements.
     * @param webElement The web element for which a child element count is required.
     * @return The number of child elements that the web element possesses.
     */
    int childElementCount(WebElement webElement);

    /**
     * Returns the number of web elements
     * @param locator The locator for the web element for which a child element count is required.
     * @return The number of web element
     */
    int childElementCount(By locator);

    /**
     * Gets the viewable area measurements of the element passed. This does not include borders, scrollbars or margins.
     * @param webElement The web element for which a child element count is required.
     * @return The viewable area measurements of the web element.
     */
    ElementSize getElementSize(WebElement webElement);

    /**
     * Gets the viewable area measurements of the element passed. This does not include borders, scrollbars or margins.
     * @param locator The locator for the web element for which a child element count is required.
     * @return The viewable area measurements of the web element.
     */
    ElementSize getElementSize(By locator);

    /**
     * Compares the positions for a pair of elements.
     * @param firstElement The first element of the pair.
     * @param secondElement The second element of the pair.
     * @return An enumerated value for the relative positions of the elements.
     */
    ElementRelationships compareElementPositions(WebElement firstElement, WebElement secondElement);

    /**
     * Compares the positions for a pair of elements.
     * @param firstLocator The locator for the first element of the pair.
     * @param secondLocator The locator for the second element of the pair.
     * @return An enumerated value for the relative positions of the elements.
     */
    ElementRelationships compareElementPositions(By firstLocator, By secondLocator);

    /**
     * Checks to see if an element is contained by another element.
     * @param firstElement The first element of the pair.
     * @param secondElement The second element of the pair.
     * @return True if the second element is a descendant of the first.
     */
    Boolean contains(WebElement firstElement, WebElement secondElement);

    /**
     * Checks to see if an element is contained by another element.
     * @param firstLocator The locator for the first element of the pair.
     * @param secondLocator The locator for the second element of the pair.
     * @return True if the second element is a descendant of the first.
     */
    Boolean contains(By firstLocator, By secondLocator);

    /**
     * Gives the focus to an element
     * @param webElement The Web Element
     */
    void giveFocus(WebElement webElement);

    /**
     * Gives the focus to an element
     * @param locator The locator for the Web Element
     */
    void giveFocus(By locator);

    /**
     * Gets the bounding rectangle for the element
     * @param webElement The web element
     * @return An object representing the bounding rectangle
     */
    DomRectangle getBoundingRectangle(WebElement webElement);

    /**
     * Gets the bounding rectangle for the element
     * @param locator The locator for the web element
     * @return An object representing the bounding rectangle
     */
    DomRectangle getBoundingRectangle(By locator);

    /**
     * Checks if a Web Element has a particular attribute
     * @param webElement The web element
     * @param attribute The attribute to check for.
     * @return True if the element has the given attribute.
     */
    Boolean hasAttribute(WebElement webElement, String attribute);

    /**
     * Checks if a Web Element has a particular attribute
     * @param locator The locator for the web element
     * @param attribute The attribute to check for.
     * @return True if the element has the given attribute.
     */
    Boolean hasAttribute(By locator, String attribute);

    /**
     * Checks whether the web element has any attributes.
     * @param webElement The Web Element.
     * @return True if the web element has any attributes.
     */
    Boolean hasAttributes(WebElement webElement);

    /**
     * Checks whether the web element has any attributes.
     * @param locator The locator for the Web Element.
     * @return True if the web element has any attributes.
     */
    Boolean hasAttributes(By locator);

    /**
     * Checks whether the web element has any child nodes.
     * @param webElement The Web Element.
     * @return True if the web element has any child nodes.
     */
    Boolean hasChildNodes(WebElement webElement);

    /**
     * Checks whether the web element has any child nodes.
     * @param locator The locator for the Web Element.
     * @return True if the web element has any child nodes.
     */
    Boolean hasChildNodes(By locator);

    /**
     * Checks if the content of an element is editable.
     * @param webElement The Web Element
     * @return True if the content is editable, false if not. Also may return Inherit, to denote it has inherited this status.
     */
    String isContentEditable(WebElement webElement);

    /**
     * Checks if the content of an element is editable.
     * @param locator The the locator for the Web Element.
     * @return True if the content is editable, false if not. Also may return Inherit, to denote it has inherited this status.
     */
    String isContentEditable(By locator);

    /**
     * Gets the language assigned to a WebElement
     * @param webElement The Web Element
     * @return The ISO 639-1 code for the language.
     */
    String getElementLanguage(WebElement webElement);

    /**
     * Gets the language assigned to a WebElement
     * @param locator The locator for the Web Element
     * @return The ISO 639-1 code for the language.
     */
    String getElementLanguage(By locator);

    /**
     * Gets the offsets for an element.
     * @param webElement The Web Element
     * @return An object representing the offsets of the element
     */
    HeightWidth getOffsets(WebElement webElement);

    /**
     * Gets the offsets for an element.
     * @param locator The locator for the Web Element
     * @return An object representing the offsets of the element
     */
    HeightWidth getOffsets(By locator);

    /**
     * Checks to see if an element is equal to another element.
     * @param firstElement The first element of the pair.
     * @param secondElement The second element of the pair.
     * @return True if the second element is equal to the first.
     */
    Boolean areNodesEqual(WebElement firstElement, WebElement secondElement);

    /**
     * Checks to see if an element is equal to another element.
     * @param firstLocator The locator for the first element of the pair.
     * @param secondLocator The locator for the second element of the pair.
     * @return True if the second element is equal to the first.
     */
    Boolean areNodesEqual(By firstLocator, By secondLocator);

    /**
     * Gets the height and width of an element in pixels, including padding, but not the border, scrollbar or margin.
     * @param webElement The Web Element
     * @return An object representing the scroll height and width of the element, along with current positioning.
     */
    ElementSize getScrollSize(WebElement webElement);

    /**
     * Gets the height and width of an element in pixels, including padding, but not the border, scrollbar or margin.
     * @param locator The locator for the Web Element
     * @return An object representing the scroll height and width of the element, along with current positioning.
     */
    ElementSize getScrollSize(By locator);

    /**
     * Returns the tab index of the chosen web element.
     * @param webElement The web element for which a tab index is required.
     * @return The tab index of the chosen element.
     */
    int getTabIndex(WebElement webElement);

    /**
     * Returns the tab index of the chosen web element.
     * @param locator The locator for the web element for which a tab index is required.
     * @return The tab index of the chosen element.
     */
    int getTabIndex(By locator);

    //endregion

    //region Wait Methods

    /**
     * Waits for an alert style dialog to be displayed
     * @return True if the wait terminates with an alert being found
     */
    Boolean waitForAlertToBePresent();

    /**
     * Waits for an element to reach a clickable state
     * @param element The WebElement representing the object
     * @return True if the wait is terminated by the element becoming clickable
     */
    Boolean waitForElementToBeClickable(WebElement element);

    /**
     * Waits for an element to reach a clickable state
     * @param locator The locator for the WebElement representing the object
     * @return True if the wait is terminated by the element becoming clickable
     */
    Boolean waitForElementToBeClickable(By locator);

    /**
     * Waits for an element to have a selected status
     * @param locator The locator for the WebElement to await
     * @return True if the wait is terminated by the element being found to be selected
     */
    Boolean waitForElementToBeSelected(By locator);

    /**
     * Waits for an element to have a selected status
     * @param element The WebElement to await
     * @return True if the wait is terminated by the element being found to be selected
     */
    Boolean waitForElementToBeSelected(WebElement element);

    /**
     * Waits for an element to have a visible attribute of true
     * @param locator The locator for the WebElement to await
     * @return True if the wait is terminated by the element being found to be visible
     */
    Boolean waitForElementToBeVisible(By locator);

    /**
     * Waits for the selection of an element to reach a certain state
     * @param locator The locator for the WebElement to be used
     * @param state The selection state to check for
     * @return True if the wait is terminated by the element being found to be in a given selection state.
     */
    Boolean waitForElementSelectionStateToBe(By locator, Boolean state);

    /**
     * Waits for the selection of an element to reach a certain state
     * @param element The WebElement to await
     * @param state The selection state to check for
     * @return True if the wait is terminated by the element being found to be in a given selection state.
     */
    Boolean waitForElementSelectionStateToBe(WebElement element, Boolean state);

    /**
     * Waits for a given element containing text to be invisible
     * @param locator The locator for the WebElement to be used
     * @return True if the elements is invisible, false if the wait expires.
     */
    Boolean waitForElementInvisibility(By locator);

    /**
     * Waits for a given element containing text to be invisible or to be removed from the DOM
     * @param locator The locator for the WebElement to be used
     * @param text The text to be used in comparison
     * @return True if the elements with given text is invisible, false if the wait expires
     */
    Boolean waitForElementInvisibilityWithText(By locator, String text);

    /**
     * Checks if any elements on the page match the locator
     * @param locator The locator for the WebElement to be used
     * @return True if the elements found by a locator are present, false if the wait expires or no elements are found.
     */
    Boolean waitForPresenceOfAllElementsLocatedBy(By locator);

    /**
     * Waits for a given element to go stale
     * @param element The WebElement to check
     * @return True if the element becomes stale, false if the wait expires.
     */
    Boolean waitForStalenessOf(WebElement element);

    /**
     * Waits until specified text is found within a given element
     * @param element The WebElement to check
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean waitForTextToBePresentInElement(WebElement element, String text);

    /**
     * Waits until specified text is found within a given element
     * @param locator The locator for the WebElement to check
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean waitForTextToBePresentInElement(By locator, String text);

    /**
     * Waits until specified text is found within a given element's value attribute
     * @param locator The locator for the WebElement to check
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean waitForTextToBePresentInElementValue(By locator, String text);

    /**
     * Waits until a given String is found in the value attribute of the given element
     * @param element The element to observe
     * @param text The text to be used in comparison
     * @return True if the element contains the given text, false if the wait expires.
     */
    Boolean waitForTextToBePresentInElementValue(WebElement element, String text);

    /**
     * Pauses execution until the title of the page title contains a given String
     * @param text The text to be used in comparison
     * @return True if the title contains the given text, false if the wait expires.
     */
    Boolean waitForTitleToContain(String text);

    /**
     * Pauses execution until the title of the page title matches a given String
     * @param text The text to be used in comparison
     * @return True if the title matches the given text, false if the wait expires.
     */
    Boolean waitForTitleToBe(String text);

    /**
     * Pauses execution until the url contains a given String
     * @param text The text to use in comparison.
     * @return True if the URL contains the given text, false if the wait expires.
     */
    Boolean waitForUrlToContain(String text);

    /**
     * Pauses execution until the url matches a given String
     * @param text The text to use in comparison.
     * @return True if the URL matches the given text, false if the wait expires.
     */
    Boolean waitForUrlToMatch(String text);

    /**
     * Pauses execution until the url matches a given String
     * @param text The text to use in comparison.
     * @return True if the URL matches the given text, false if the wait expires.
     */
    Boolean waitForUrlToBe(String text);

    /**
     * Waits for all of the element identified by the locator to be visible
     * @param locator The locator to use to find elements
     * @return True if all elements located are visible, false if the wait expires.
     */
    Boolean waitForVisibilityOfAllElementsLocatedBy(By locator);

    //endregion
}
