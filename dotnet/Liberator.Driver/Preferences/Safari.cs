using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liberator.Driver.Enums;

namespace Liberator.Driver.Preferences
{
    /// <summary>
    /// Holds the preferences for the Safari Driver on MacOS
    /// </summary>
    public static class Safari
    {
        static Safari()
        {
            TechnologyPreview = false;
            AutomaticInspection = false;
            AutomaticProfiling = false;
        }

        /// <summary>
        /// Standard timeout time span for the browser
        /// </summary>
        public static TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Timeout for asynchronous java script
        /// </summary>
        public static TimeSpan? AsyncJavaScript { get; set; }

        /// <summary>
        /// The debug level for RatDriver
        /// </summary>
        public static EnumConsoleDebugLevel? DebugLevel { get; set; }

        /// <summary>
        /// Selenium based Implicit Wait setting
        /// </summary>
        public static TimeSpan? ImplicitWait { get; set; }

        /// <summary>
        /// Page load time as a time span
        /// </summary>
        public static TimeSpan? PageLoad { get; set; }

        /// <summary>
        /// Whether to automatically handle alerts
        /// </summary>
        public static bool? AlertHandling { get; set; }

        /// <summary>
        /// Whether to use the internal timers
        /// </summary>
        public static bool? InternalTimers { get; set; }

        /// <summary>
        /// The time span to hover over a menu
        /// </summary>
        public static TimeSpan? MenuHoverTime { get; set; }

        /// <summary>
        /// The standard time span for driver sleep
        /// </summary>
        public static TimeSpan? Sleep { get; set; }

        /// <summary>
        /// The port for the driver connection to the network
        /// </summary>
        public static int? Port { get; set; }

        /// <summary>
        /// Whether to use the Safari technology preview
        /// </summary>
        public static bool? TechnologyPreview { get; set; }

        /// <summary>
        /// Whether to use automatic inspection
        /// </summary>
        public static bool? AutomaticInspection { get; set; }

        /// <summary>
        /// Whether to use automatic profiling
        /// </summary>
        public static bool? AutomaticProfiling { get; set; }
    }

    /// <summary>
    /// Settings for the instantiation of a Safari Driver
    /// </summary>
    public class SafariSettings : BasePreferences
    {
        /// <summary>
        /// The port for the driver connection to the network
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Whether to use the Safari technology preview
        /// </summary>
        public bool? TechnologyPreview { get; set; }

        /// <summary>
        /// Whether to use automatic inspection
        /// </summary>
        public bool? AutomaticInspection { get; set; }

        /// <summary>
        /// Whether to use automatic profiling
        /// </summary>
        public bool? AutomaticProfiling { get; set; }

    }
}
