using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Preferences for Remote Drivers
    /// </summary>
    public static class Remote
    {
        /// <summary>
        /// Default address for the Web Driver
        /// </summary>
        public static string DefaultRemoteAddress { get; set; }

        /// <summary>
        /// Capabilities of the browser that you are going to use
        /// </summary>
        public static string DesiredCapabilities { get; set; }
    }
}
