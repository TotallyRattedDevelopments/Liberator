using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Liberator.Driver
{
    /// <summary>
    /// 
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        public static void Activate(this IRodent driver)
        {
            var prc = Process.GetProcessesByName(BrowserProcess(driver));
            if (prc.Length > 0)
            {
                Helpers.SetForegroundWindow(prc[0].MainWindowHandle);
            }
        }

        internal static string BrowserProcess(IRodent driver)
        {
            switch (driver.DriverName)
            {
                case "ChromeDriver":
                    return "chromedriver";
                case "FirefoxDriver":
                    return "geckodriver";
                case "EdgeDriver":
                    return "";
                case "InternetExplorerDriver":
                    return "IEDriverServer";
                case "OperaDriver":
                    return "operadriver";
                case "PhantomJSDriver":
                    return "phantomjs";
            }
            return null;
        }
    }

    /// <summary>
    /// The measurements for elements
    /// </summary>
    public class ElementSize
    {
        /// <summary>
        /// Height of the element
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Leftmost edge of the element
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Topmost edge of the element
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Width of the element
        /// </summary>
        public int Width { get; set; }
    }

    /// <summary>
    /// Bounding client rectangle
    /// </summary>
    public class DomRectangle
    {
        /// <summary>
        /// Leftmost edge
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Topmost edge
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Rightmost edge
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Bottom edge
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// X Co-ordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Co-ordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Width of the element
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the element
        /// </summary>
        public int Height { get; set; }
    }

    /// <summary>
    /// Represents the offsets for the element
    /// </summary>
    public class HeightWidth
    {
        /// <summary>
        /// The offset height of the element
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The offset width of the element
        /// </summary>
        public int Width { get; set; }
    }
}
