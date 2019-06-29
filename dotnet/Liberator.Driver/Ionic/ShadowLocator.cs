using OpenQA.Selenium;

namespace Liberator.Driver.Ionic
{
    /// <summary>
    /// A custom locator class used for Shadow Root elements
    /// </summary>
    public class ShadowLocator
    {
        /// <summary>
        /// Find order when using multiple ShadowLocators to navigate a complex ShadowRoot system
        /// </summary>
        public int? FindOrder { get; set; }

        /// <summary>
        /// Defines the type of built in finder to use for shadow roots.
        /// <para>Limited to finding by ID or by CSS Selector.</para>
        /// </summary>
        public ShadowFindBy FindBy { get; set; }

        /// <summary>
        /// Locator for the shadow element required
        /// </summary>
        public string Locator { get; set; }

        /// <summary>
        /// Calculated selenium locator
        /// </summary>
        public By SeleniumLocator
        {
            get
            {
                if (FindBy == ShadowFindBy.Id) { return By.Id(Locator); }
                if (FindBy == ShadowFindBy.CssSelector) { return By.CssSelector(Locator); }
                return null;
            }
        }
    }

    /// <summary>
    /// Types of locator available for shadow elements
    /// </summary>
    public enum ShadowFindBy
    {
        /// <summary>
        /// Use ID to find shadowed objects
        /// </summary>
        Id,

        /// <summary>
        /// Use CSS Selector to find shadowed objects
        /// </summary>
        CssSelector
    }
}