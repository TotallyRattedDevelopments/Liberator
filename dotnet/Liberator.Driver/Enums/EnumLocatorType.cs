namespace Liberator.Driver.Enums
{
    /// <summary>
    /// Type of locator being used
    /// </summary>
    public enum EnumLocatorType
    {
        /// <summary>
        /// Locator type not specified
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Locates using a CSS Class Name
        /// </summary>
        ClassName = 1,

        /// <summary>
        /// Locates using a CSS Selector
        /// </summary>
        CssSelector = 2,

        /// <summary>
        /// Locates using the Id of an HTML element
        /// </summary>
        Id = 3,

        /// <summary>
        /// Locate using text from an anchor tag
        /// </summary>
        LinkText = 4,

        /// <summary>
        /// Locates using a Name attribute
        /// </summary>
        Name = 5,

        /// <summary>
        /// Use partial text from an anchor tag
        /// </summary>
        PartialLinkText = 6,

        /// <summary>
        /// Locate using an HTML tag name
        /// </summary>
        TagName = 7,

        /// <summary>
        /// Use an XPath locator
        /// </summary>
        XPath = 8
    }
}
