using Liberator.Excellerator.Loaders;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Liberator.ExcelleratorTests.Workbooks
{
    [TestFixture]
    public class WorkbookTests
    {
        [Test]
        [Category("ExcelLoaderTests")]
        public void OpenExcelWorkbook()
        {
            MSExcel.Workbook wkBook = null;

            using (DataLoader loader = new DataLoader())
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                wkBook = loader.OpenWorkbook(path + "\\Workbooks\\AttributeTestFile.xlsx");
                Assert.That(wkBook != null, Is.True);
            }
            
            wkBook.Close();
            wkBook = null;
        }

        [Test]
        [Category("ExcelLoaderTests")]
        public void SelectWorksheet()
        {
            MSExcel.Workbook wkbook = null;
            MSExcel.Worksheet wkSheet = null;

            using (DataLoader loader = new DataLoader())
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                wkbook = loader.OpenWorkbook(path + "\\Workbooks\\AttributeTestFile.xlsx");
                wkSheet = loader.SelectWorksheet("Data");
                Assert.That(wkSheet != null, Is.True);
            }
            
            wkbook.Close();
            wkbook = null;
        }

        [Test]
        [Category("ExcelLoaderTests")]
        public void GetDataRows()
        {
            MSExcel.Workbook wkbook = null;
            MSExcel.Worksheet wkSheet = null;

            using (DataLoader loader = new DataLoader())
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                wkbook = loader.OpenWorkbook(path + "\\Workbooks\\AttributeTestFile.xlsx");
                wkSheet = loader.SelectWorksheet("Data");
                IEnumerable<MSExcel.Range> data = loader.GetDataRows();
                Assert.That(data != null, Is.True);
                Assert.That(data.Count() == 1);
            }
            
            wkbook.Close();
            wkbook = null;
        }

        [Test]
        [Category("ExcelLoaderTests")]
        public void GetColumnHeaders()
        {
            MSExcel.Workbook wkbook = null;
            MSExcel.Worksheet wkSheet = null;

            using (DataLoader loader = new DataLoader())
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                wkbook = loader.OpenWorkbook(path + "\\Workbooks\\AttributeTestFile.xlsx");
                wkSheet = loader.SelectWorksheet("Data");
                IEnumerable<string> headers = loader.ColumnHeaders;
                Assert.That(headers != null, Is.True);
            }
            
            wkbook = null;
        }

        [Test]
        [Category("ExcelLoaderTests")]
        public void GetColumnHeadersValues()
        {
            MSExcel.Workbook wkbook = null;
            MSExcel.Worksheet wkSheet = null;

            using (DataLoader loader = new DataLoader())
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                wkbook = loader.OpenWorkbook(path + "\\Workbooks\\AttributeTestFile.xlsx");
                wkSheet = loader.SelectWorksheet("Data");
                IEnumerable<string> headers = loader.ColumnHeaders;
                Assert.That(headers.ElementAt(0).Contains("ID"), Is.True);
                Assert.That(headers.ElementAt(1).Contains("Name"), Is.True);
                Assert.That(headers.ElementAt(2).Contains("Address"), Is.True);
                Assert.That(headers.ElementAt(3).Contains("Preference"), Is.True);
            }
            
            wkbook.Close();
            wkbook = null;
        }


        [Test]
        [Category("ExcelLoaderTests")]
        public void GetSpecificRange()
        {
            MSExcel.Workbook wkBook = null;
            MSExcel.Worksheet wkSheet = null;

            using (RangeLoader loader = new RangeLoader())
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                wkBook = loader.OpenWorkbook(path + "\\Workbooks\\AttributeTestFile.xlsx");
                wkSheet = loader.SelectWorksheet("Data");
                MSExcel.Range range = loader.GetDataRange("A1:D2");
                Assert.That(range != null, Is.True);
                string cellValue = (string)(range.Cells[1, 1] as MSExcel.Range).Value;
                Assert.That(cellValue.Contains("ID"));
            }
            
            wkBook.Close();
            wkBook = null;
        }


    }
}
