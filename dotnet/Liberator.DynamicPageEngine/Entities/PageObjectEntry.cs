using Liberator.DynamicPageEngine.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberator.DynamicPageEngine.Entities
{
    public class PageObjectEntry
    {
        public string Id { get; set; }

        public string LinkText { get; set; }

        public string TagName { get; set; }

        public string ClassName { get; set; }

        public string CssSelector { get; set; }

        public string XPath { get; set; }
    }
}
