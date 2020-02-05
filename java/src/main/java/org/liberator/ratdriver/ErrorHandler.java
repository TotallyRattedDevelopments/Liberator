package org.liberator.ratdriver;

import com.sun.javafx.PlatformUtil;

public class ErrorHandler {

    public static void HandleErrors(Exception ex) {
        String classname = ex.getClass().getName();
        System.out.format("An exception of type '%s' was thrown.", classname);

        switch (classname) {
            case "UnhandledAlertException":
                System.out.println("An alert has been detected but has not been handled.");
                break;
            case "ElementClickInterceptedException":
                System.out.println("The element cannot be clicked as the click was intercepted.");
                break;
            case "ElementNotInteractableException":
                System.out.println("The element chosen has reported as being non-interactable.");
                break;
            case "ElementNotSelectableException":
                System.out.println("The element cannot be selected.");
                break;
            case "ElementNotVisibleException":
                System.out.println("The element requested is not visible.");
                break;
            case "ImeActivationFailedException":
                System.out.println("Activation of the input method engine has failed.");
                break;
            case "ImeNotAvailableException":
                System.out.println("The Input method engine is not available.");
                break;
            case "InvalidArgumentException":
                System.out.println("An invalid argument was passed");
                break;
            case "InvalidCookieDomainException":
                System.out.println("An invalid cookie domain was requested.");
                break;
            case "InvalidElementStateException":
                System.out.println("The element state is invalid.");
                break;
            case "InvalidSelectorException":
                System.out.println("An invalid selector has been used and has caused an exception");
                break;
            case "JavascriptException":
                System.out.println("There has been an exception thrown in JavaScript execution.");
                break;
            case "NoAlertPresentException":
                System.out.println("An alert was expected but has not been detected.");
                break;
            case "NoSuchContextException":
                System.out.println("");
                break;
            case "NoSuchCookieException":
                System.out.println("No such cookie has been found.");
                break;
            case "NoSuchElementException":
                System.out.println("There is no element meeting the definition provided.");
                break;
            case "NoSuchFrameException":
                System.out.println("There is no frame meeting the definition provided.");
                break;
            case "NoSuchSessionException":
                System.out.println("The required session does not exist.");
                break;
            case "NoSuchWindowException":
                System.out.println("There is no window meeting the definition provided.");
                break;
            case "NotFoundException":
                System.out.println("The element was not found.");
                break;
            case "ScriptTimeoutException":
                System.out.println("A JavaScript has timed out.");
                break;
            case "SessionNotCreatedException":
                System.out.println("The required session was not created.");
                break;
            case "StaleElementReferenceException":
                System.out.println("Element has a stale reference.");
                break;
            case "TimeoutException":
                System.out.println("The driver has encountered a timeout.");
                break;
            case "UnableToSetCookieException":
                System.out.println("Unable to set the required cookie.");
                break;
            case "UnsupportedCommandException":
                System.out.println("The command sent was unsupported.");
                break;
            case "WebDriverException":
                System.out.println("The WebDriver has encountered an exception.");
                break;
            case "MoveTargetOutOfBoundsException":
                System.out.println("The requested action results in the cursor moving off screen.");
                if (PlatformUtil.isWindows()) {
                    System.out.println("If using Internet Explorer, please check that zoom settings are set to 100%.");
                    System.out.println("If using Parallels, please change the resolution setting to 'Scaled'.");
                }
                break;
            case "InvalidCoordinatesException":
                System.out.println("The coordinates passed are invalid.");
        }
    }
}
