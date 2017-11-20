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
}
