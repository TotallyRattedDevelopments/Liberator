package org.liberator.ratdriver.tests;

import org.junit.Assert;
import org.junit.Test;
import org.liberator.ratdriver.IRodent;
import org.liberator.ratdriver.RatDriver;
import org.liberator.ratdriver.enums.DriverType;
import org.liberator.ratdriver.enums.LocatorType;
import org.openqa.selenium.By;
import org.openqa.selenium.Dimension;
import org.openqa.selenium.Point;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.logging.LogEntry;

import java.util.List;
import java.util.Set;

public class OperaTests {

    @Test
    public void testInstantiationOpera(){
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        Assert.assertTrue(ratDriver.GetBrowserWindowUrl().contains("totallyratted"));
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testClickLinkOpera(){
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        WebElement devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        ratDriver.ClickLinkAndWait(devLink);
        Assert.assertTrue(ratDriver.GetBrowserWindowUrl().contains("developments"));
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetTextOpera(){
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        ratDriver.ClickLinkAndWait(devLink);
        ratDriver.WaitForElementToLoad(By.cssSelector(".col-md-12>h1"));
        String str = ratDriver.GetElementText(By.cssSelector(".col-md-12>h1"), true);
        ratDriver.ClosePagesAndQuitDriver();
        Assert.assertTrue(str.contains("Totally Ratted Developments"));
    }

    @Test
    public void  testCheckPageSourceOpera(){
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        ratDriver.ClickLinkAndWait(devLink);
        ratDriver.WaitForElementToLoad(By.cssSelector(".col-md-12>h1"));
        String str = ratDriver.GetPageSource();
        ratDriver.ClosePagesAndQuitDriver();
        Assert.assertTrue(str.contains("Totally Ratted Developments"));
    }


    @Test
    public void testGetAvailableLogTypesOpera(){

        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        Set<String> logTypes = ratDriver.GetAvailableLogTypes();
        Assert.assertTrue(logTypes.contains("browser"));
        Assert.assertTrue(logTypes.contains("driver"));
        Assert.assertTrue(logTypes.contains("client"));
        ratDriver.ClosePagesAndQuitDriver();
    }


    @Test
    public  void testGetBrowserLogEntriesOpera(){
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        List<LogEntry> logEntries = ratDriver.GetAvailableLogEntries("browser");
        Assert.assertNotNull(logEntries);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testSetImplicitWaitOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.SetImplicitWait(0, 5, 0);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testSetPageLoadTimeoutOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.SetPageLoadTimeout(0, 30, 0);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetWindowPositionOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        Point position = ratDriver.GetWindowPosition();
        Assert.assertTrue(position.x >= 0);
        Assert.assertTrue(position.y >= 0);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetWindowSizeOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        Dimension position = ratDriver.GetWindowSize();
        Assert.assertTrue(position.width >= 0);
        Assert.assertTrue(position.height >= 0);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testResizeWindowOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.ResizeBrowserWindow(640, 480);
        Dimension size = ratDriver.GetWindowSize();
        Assert.assertEquals(640, size.width);
        Assert.assertEquals(480, size.height);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testBrowserButtonsOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        ratDriver.ClickLinkAndWait(devLink);
        Assert.assertTrue(ratDriver.GetBrowserWindowUrl().contains("developments"));
        ratDriver.PressBackButton();
        devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        Assert.assertFalse(ratDriver.GetBrowserWindowUrl().contains("developments"));
        ratDriver.PressForwardButton();
        devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        Assert.assertTrue(ratDriver.GetBrowserWindowUrl().contains("developments"));
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetPageSourceOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, true);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement devLink = ratDriver.FindElementByLinkText("Developments", true);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        Assert.assertTrue(ratDriver.GetPageSource().length() >= 256);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testSwitchToWindowOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        String window = ratDriver.GetCurrentWindowHandle();
        ratDriver.OpenNewView();
        ratDriver.NavigateToPage("http://www.google.com");
        Assert.assertTrue(ratDriver.GetBrowserWindowUrl().contains("google"));
        ratDriver.SwitchToWindow(window);
        Assert.assertTrue(ratDriver.GetBrowserWindowUrl().contains("ratted"));
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetBrowserWindowTitleOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        String title = ratDriver.GetBrowserWindowTitle();
        Assert.assertTrue(title.contains("Totally Ratted Limited"));
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetAllWindowHandlesOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        Set<String> handles = ratDriver.GetAllWindowHandles();
        Assert.assertNotNull(handles);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testClickLinkAndWaitForPageOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement devLink = ratDriver.FindElementByLinkText("Developments", false);
        Assert.assertTrue(ratDriver.ElementExists(devLink));
        ratDriver.ClickLinkAndWaitForUrl(devLink, "developments");
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testGetElementAttributeOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement element = ratDriver.FindElementById("carousel-example", false);
        Assert.assertTrue(ratDriver.GetElementAttribute(element, "data-ride", false).contains("carousel"));
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindByClassNameOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement element = ratDriver.FindElementByClassName("carousel-inner", false);
        Assert.assertTrue(element.isDisplayed());
        Assert.assertTrue(element.isEnabled());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindElementsByClassNameOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        List<WebElement> elements = ratDriver.FindElementsByClassName("menutext", false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByClassNameOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement parent = ratDriver.FindElementByCssSelector(".nav.navbar-nav.navbar-right", false);
        List<WebElement> elements = ratDriver.FindSubElementsByClassName("menutext", parent, false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByClassNameLocatorOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        List<WebElement> elements = ratDriver.FindSubElementsByClassName("menutext", By.className("container"), false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindByIdOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement element = ratDriver.FindElementById("home", false);
        Assert.assertTrue(element.isDisplayed());
        Assert.assertTrue(element.isEnabled());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindByLinkTextOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement element = ratDriver.FindElementByLinkText("Developments", false);
        Assert.assertTrue(element.isEnabled());
        Assert.assertTrue(element.isDisplayed());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindElementsByLinkTextOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        List<WebElement> elements = ratDriver.FindElementsByLinkText("Read Details", false);
        Assert.assertEquals(6, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByLinkTextOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement parent = ratDriver.FindElementById("just-intro", false);
        List<WebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent, false);
        Assert.assertEquals(3, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByLinkTextLocatorOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        By parent = By.id("just-intro");
        List<WebElement> elements = ratDriver.FindSubElementsByLinkText("Read Details", parent, false);
        Assert.assertEquals(3, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindElementByTagNameOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement element = ratDriver.FindElementByTag("body", false);
        Assert.assertNotNull(element);
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindElementsByTagNameOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        List<WebElement> elements = ratDriver.FindElementsByTag("section", false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByTagNameOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement parent = ratDriver.FindElementById("just-intro", false);
        List<WebElement> elements = ratDriver.FindSubElementsByTag("a", parent, false);
        Assert.assertEquals(3, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByTagNameLocatorOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        By parent = By.id("just-intro");
        List<WebElement> elements = ratDriver.FindSubElementsByTag("a", parent, false);
        Assert.assertEquals(3, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindElementByXPathOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement element = ratDriver.FindElementByXPath(".//*[@id='carousel-example']", false);
        Assert.assertTrue(element.isDisplayed());
        Assert.assertTrue(element.isEnabled());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindElementsByXPathOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        List<WebElement> elements = ratDriver.FindElementsByXPath(".//section", false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByXPathOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        WebElement parent = ratDriver.FindElementByXPath("html/body", false);
        List<WebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent, false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testFindSubElementsByXPathLocatorOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        By parent = By.xpath("html/body");
        List<WebElement> elements = ratDriver.FindSubElementsByXPath(".//section", parent, false);
        Assert.assertEquals(5, elements.size());
        ratDriver.ClosePagesAndQuitDriver();
    }

    @Test
    public void testExtractElementFromCollectionByAttributeLocatorOpera()
    {
        IRodent ratDriver = new RatDriver(DriverType.OperaDriver, false);
        ratDriver.NavigateToPage("http://www.totallyratted.com");
        ratDriver.MaximiseView();
        By parent = By.xpath("html/body");
        WebElement element = ratDriver.ExtractElementFromCollectionByAttribute(parent, LocatorType.XPath, ".//section", "class", "note-sec", false);
        Assert.assertTrue(element.isDisplayed());
        Assert.assertTrue(element.isEnabled());
        ratDriver.ClosePagesAndQuitDriver();
    }
}
