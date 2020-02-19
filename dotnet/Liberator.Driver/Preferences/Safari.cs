using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liberator.Driver.Enums;

namespace Liberator.Driver.Preferences
{
    public static class Safari
    {

        static Safari()
        {
            TechnologyPreview = false;
            AutomaticInspection = false;
            AutomaticProfiling = false;
        }

        public static TimeSpan? Timeout { get; set; }

        public static TimeSpan? AsyncJavaScript { get; set; }

        public static EnumConsoleDebugLevel? DebugLevel { get; set; }

        public static TimeSpan? ImplicitWait { get; set; }

        public static TimeSpan? PageLoad { get; set; }

        public static bool? AlertHandling { get; set; }

        public static bool? InternalTimers { get; set; }

        public static TimeSpan? MenuHoverTime { get; set; }

        public static TimeSpan? Sleep { get; set; }

        public static int? Port { get; set; }

        public static bool? TechnologyPreview { get; set; }

        public static bool? AutomaticInspection { get; set; }

        public static bool? AutomaticProfiling { get; set; }
    }

    public class SafariSettings : BasePreferences
    {

        public int? Port { get; set; }

        public bool? TechnologyPreview { get; set; }

        public bool? AutomaticInspection { get; set; }

        public bool? AutomaticProfiling { get; set; }

    }
}
