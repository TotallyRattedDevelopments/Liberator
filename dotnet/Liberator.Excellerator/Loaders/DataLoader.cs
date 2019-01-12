using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Liberator.Excellerator.Loaders
{
    /// <summary>
    /// Bass class for loading excel files in table form
    /// </summary>
    public class DataLoader : Loader
    {
        #region Instance Variables

        MSExcel.Application _app = null;
        MSExcel.Workbook _wkBook = null;
        MSExcel.Worksheet _wkSheet = null;
        MSExcel.Range _colRange = null;
        MSExcel.Range _dataRange = null;
        List<string> _headers = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// A reference to a Microsoft Excel Workbook
        /// </summary>
        public MSExcel.Workbook Workbook
        {
            get { return _wkBook; }
            set { _wkBook = value; }
        }

        /// <summary>
        /// A reference to a Microsoft Excel Worksheet
        /// </summary>
        public MSExcel.Worksheet Worksheet
        {
            get { return _wkSheet; }
            set { _wkSheet = value; }
        }

        /// <summary>
        /// A reference to a column range
        /// </summary>
        public MSExcel.Range ColumnRange
        {
            get { return _colRange; }
            set { _colRange = value; }
        }

        /// <summary>
        /// A reference to a data range
        /// </summary>
        public MSExcel.Range DataRange
        {
            get { return _dataRange; }
            set { _dataRange = value; }
        }

        /// <summary>
        /// A list of the column headers found
        /// </summary>
        public List<string> ColumnHeaders
        {
            get { return _headers; }
            set { _headers = value; }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// Initialises the object
        /// </summary>
        public DataLoader()
        {
            _app = new MSExcel.Application();
            ColumnHeaders = new List<string>();
        }

        #endregion

        /// <summary>
        /// Opens the named workbook
        /// </summary>
        /// <param name="wkBook">The path to the workbook</param>
        /// <param name="password">The password for the workbook</param>
        /// <param name="writeRes">The write reservation password</param>
        /// <returns>A reference to the opened workbook</returns>
        public override MSExcel.Workbook OpenWorkbook(string wkBook, string password = null, string writeRes = null)
        {
            _wkBook = base.OpenWorkbook(wkBook, password, writeRes);
            return _wkBook;
        }


        /// <summary>
        /// Selects the named worksheet
        /// </summary>
        /// <param name="_sheet">The name of the worksheet</param>
        /// <returns>A reference to the named worksheet</returns>
        public override MSExcel.Worksheet SelectWorksheet(string _sheet)
        {
            try
            {
                _wkSheet = base.SelectWorksheet(_sheet);
                GetColumnHeaders();
                GetHeaderTitles();
                return _wkSheet;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot retrieve Worksheet object.");
                return null;
            }
        }

        /// <summary>
        /// Gets the list of rows from excel
        /// </summary>
        /// <returns>A collection of range objects representing rows</returns>
        public IEnumerable<MSExcel.Range> GetDataRows()
        {
            try
            {
                List<MSExcel.Range> _range = new List<MSExcel.Range>();
                GetDataRange();
                foreach (MSExcel.Range row in _dataRange.Rows)
                {
                    _range.Add(row);
                }
                return _range;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all column headers
        /// </summary>
        /// <returns>A list of all row 1 column contents</returns>
        internal MSExcel.Range GetColumnHeaders()
        {
            try
            {
                _wkBook.Activate();
                _wkSheet.Select(false);
                _colRange = (MSExcel.Range)_wkSheet.Rows[1];
                return _colRange;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot get requested colum headers.");
                return null;
            }
        }

        /// <summary>
        /// Extracts a list of the available column titles
        /// </summary>
        /// <returns>A list of column titles</returns>
        internal List<string> GetHeaderTitles()
        {
            try
            {
                foreach (MSExcel.Range cell in _colRange.Cells)
                {
                    if (cell.Value == null || cell.Value.ToString() == "") { break; }
                    ColumnHeaders.Add(cell.Value.ToString());
                }
                return ColumnHeaders;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not get the names of the columns requested.");
                return null;
            }
        }

        /// <summary>
        /// Fetches the data range from the selected worksheet
        /// </summary>
        /// <returns>A series of Row objects</returns>
        internal MSExcel.Range GetDataRange()
        {
            try
            {
                int lastRow = _wkSheet.UsedRange.Rows.Count;
                int lastCol = _wkSheet.UsedRange.Columns.Count;
                _dataRange = _wkSheet.Range[_wkSheet.Cells[2, 1], _wkSheet.Cells[lastRow, lastCol]];
                return _dataRange;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not get the data range requested.");
                return null;
            }
        }
    }
}
