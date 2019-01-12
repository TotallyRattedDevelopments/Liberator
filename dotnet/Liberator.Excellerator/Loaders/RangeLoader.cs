using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Liberator.Excellerator.Loaders
{
    /// <summary>
    /// Bass class for loading excel files in tabular form
    /// </summary>
    public class RangeLoader : Loader
    {
        #region Internal

        MSExcel.Application _app = null;
        MSExcel.Workbook _wkBook = null;
        MSExcel.Worksheet _wkSheet = null;
        string _sheetName = null;
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
        /// Name of the sheet that is to be, or already is, selected
        /// </summary>
        public string SheetName
        {
            get { return _sheetName; }
            set { _sheetName = value; }
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
        public RangeLoader()
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
            return base.OpenWorkbook(wkBook, password, writeRes);
        }


        /// <summary>
        /// Selects the named worksheet
        /// </summary>
        /// <param name="sheet">The name of the worksheet</param>
        /// <returns>A reference to the named worksheet</returns>
        public override MSExcel.Worksheet SelectWorksheet(string sheet)
        {
            try
            {
                _sheetName = sheet;
                _wkSheet = base.SelectWorksheet(sheet);
                return _wkSheet;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot retrieve Worksheet object.");
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MSExcel.Range GetDataRange(string range)
        {
            try
            {
                MSExcel.Range returnRange = null;
                int rowLeft = 0, rowRight = 0, colLeft = 0, colRight = 0;
                var sheet = base.SelectWorksheet(_sheetName);

                MatchCollection columnCollection = Regex.Matches(range, @"([A-Za-z]{1,3})");
                MatchCollection rowCollection = Regex.Matches(range, @"\d{1,7}");
                

                if (Regex.IsMatch(range, @":"))
                {
                    colLeft = (columnCollection[0].Value).ToOneBasedIndex();
                    rowLeft = Convert.ToInt32(rowCollection[0].Value);
                    colRight = (columnCollection[1].Value).ToOneBasedIndex();
                    rowRight = Convert.ToInt32(rowCollection[1].Value);

                    returnRange = _wkSheet.Range[_wkSheet.Cells[rowLeft, colLeft], _wkSheet.Cells[rowRight, colRight]];
                }
                else
                {
                    colLeft = (columnCollection[0].Value).ToOneBasedIndex();
                    rowLeft = Convert.ToInt32(rowCollection[0].Value);
                    
                    returnRange = _wkSheet.Range[rowLeft, colLeft];
                }
                return returnRange;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot retrieve get the data range specified.");
                return null;
            }
        }

        /// <summary>
        /// Sets a data range using an array of data
        /// </summary>
        public void SetDataRange(string range, object[,] dataArray)
        {
            try
            {
                MSExcel.Range rng = null;
                int rowLeft = 0, rowRight = 0, colLeft = 0, colRight = 0;
                var sheet = base.SelectWorksheet(_sheetName);

                MatchCollection columnCollection = Regex.Matches(range, @"\w{1,3}");
                MatchCollection rowCollection = Regex.Matches(range, @"\d{1,7}");

                if (Regex.IsMatch(range, @":"))
                {
                    colLeft = (columnCollection[0].Value).ToOneBasedIndex();
                    rowLeft = Convert.ToInt32(rowCollection[0].Value);
                    colRight = (columnCollection[1].Value).ToOneBasedIndex();
                    rowRight = Convert.ToInt32(rowCollection[1].Value);

                    rng = _wkSheet.Range[_wkSheet.Cells[rowLeft, colLeft], _wkSheet.Cells[rowRight, colRight]];
                    rng.Value = dataArray;
                }
                else
                {
                    colLeft = (columnCollection[0].Value).ToOneBasedIndex();
                    rowLeft = Convert.ToInt32(rowCollection[0].Value);

                    rng = _wkSheet.Range[rowLeft, colLeft];
                    rng.Value = dataArray;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot retrieve set the data range specified.");
            }
        }
        

    }
}
