using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liberator.Excellerator.Attributes;

namespace Liberator.ExcelleratorTests.Attributes
{
    [ExcelDataRow]
    public class AttributeTestFile
    {
        [Column(name:"ID", mandatory: true)]
        public string ID { get; set; }

        [Column(name:"Name", def:"John Smith")]
        public string Name { get; set; }

        [Column(name: "Address")]
        public string Address { get; set; }

        [Column(name: "Preference", mandatory: true, def: true)]
        public string Preference { get; set; }
    }
}
