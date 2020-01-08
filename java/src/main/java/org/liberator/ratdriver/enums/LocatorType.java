package org.liberator.ratdriver.enums;

/**
 * A list of locator types
 */
public enum LocatorType {

    /**
     * Locator type not specified
     */
    NotSpecified,

    /**
     * Locates using a CSS Class Name
     */
    ClassName,

    /**
     * Locates using a CSS Selector
     */
    CssSelector,

    /**
     * Locates using the Id of an HTML element
     */
    Id,

    /**
     * Locate using text from an anchor tag
     */
    LinkText,

    /**
     * Locates using a Name attribute
     */
    Name,

    /**
     * Use partial text from an anchor tag
     */
    PartialLinkText,

    /**
     * Locate using an HTML tag name
     */
    TagName,

    /**
     * Use an XPath locator
     */
    XPath
}
