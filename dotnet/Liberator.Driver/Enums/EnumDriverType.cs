namespace Liberator.Driver.Enums
{
    /// <summary>
    /// A list of driver types
    /// </summary>
    public enum EnumDriverType
    {
        /// <summary>
        /// Driver not specified
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Firefox web driver
        /// </summary>
        FirefoxDriver = 1,

        /// <summary>
        /// Chrome web driver
        /// </summary>
        ChromeDriver = 2,

        /// <summary>
        /// Edge web driver
        /// </summary>
        EdgeDriver = 3,

        /// <summary>
        /// PhantomJS web driver
        /// </summary>
        PhantomJSDriver = 4,

        /// <summary>
        /// Internet Explorer web driver
        /// </summary>
        InternetExplorerDriver = 5,

        /// <summary>
        /// Opera web driver
        /// </summary>
        OperaDriver = 6
    }

    /// <summary>
    /// Type of remote web driver
    /// </summary>
    public enum EnumRemoteDriver
    {
        /// <summary>
        /// No web driver specified
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Android web driver
        /// </summary>
        Android = 1,

        /// <summary>
        /// Chrome web driver
        /// </summary>
        Chrome = 2,

        /// <summary>
        /// Edge web driver
        /// </summary>
        Edge = 3,

        /// <summary>
        /// Firefox web driver
        /// </summary>
        Firefox = 4,

        /// <summary>
        /// HTML Unit web driver
        /// </summary>
        HTMLUnit = 5,

        /// <summary>
        /// HTML Unit web driver with JavaScript
        /// </summary>
        HTMLUnitJS = 6,

        /// <summary>
        /// internet Explorer web driver
        /// </summary>
        InternetExplorer = 7,

        /// <summary>
        /// iPad emulation web driver
        /// </summary>
        iPad = 8,

        /// <summary>
        /// iPhone emulation web driver
        /// </summary>
        iPhone = 9,

        /// <summary>
        /// Opera web driver
        /// </summary>
        Opera = 10,

        /// <summary>
        /// PhantomJS web driver
        /// </summary>
        PhantomJS = 11,

        /// <summary>
        /// Safari web driver
        /// </summary>
        Safari = 12
    }
}
