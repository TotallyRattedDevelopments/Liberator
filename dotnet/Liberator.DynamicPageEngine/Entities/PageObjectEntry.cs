using System.Collections.Generic;

namespace Liberator.DynamicPageEngine.Entities
{
    public class PageObjectEntry
    {
        public string Id { get; set; }

        public string Link { get; set; }

        public string TagName { get; set; }

        public string NameAttribute { get; set; }

        public string ObjectName { get; set; }

        public IEnumerable<string> ClassNames { get; set; }

        public string CssSelector { get; set; }

        public string XPath { get; set; }
    }
}
