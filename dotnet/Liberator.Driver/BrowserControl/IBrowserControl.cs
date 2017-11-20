using OpenQA.Selenium;

namespace Liberator.Driver.BrowserControl
{
    /// <summary>
    /// Root interface for browser control classes
    /// </summary>
    public interface IBrowserControl
    {
        /// <summary>
        /// Driver implementation under test
        /// </summary>
        IWebDriver Driver { get; set; }

        /// <summary>
        /// Starts a web driver
        /// </summary>
        /// <returns>A web driver instance</returns>
        IWebDriver StartDriver();
    }
}
