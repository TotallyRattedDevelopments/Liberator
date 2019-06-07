using OpenQA.Selenium;

namespace Liberator.Driver.Ionic
{
    /// <summary>
    /// A custom locator class used for Shadow Root elements
    /// </summary>
    public class ShadowLocator
    {
        internal By FindBy { get; set; }

        internal IWebElement Child { get; set; }

        internal IWebElement Ancestor { get; set; }
    }
}
