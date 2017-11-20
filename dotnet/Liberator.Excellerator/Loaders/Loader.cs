using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Liberator.Excellerator.Loaders
{
    /// <summary>
    /// Abstract base class for loading Excel files
    /// </summary>
    public class Loader : IDisposable
    {
        MSExcel.Application _app = new MSExcel.Application();
        MSExcel.Workbook _wkBook;
        MSExcel.Worksheet _wkSheet;

        /// <summary>
        /// Abstract base method for opening an Excel Workbook
        /// </summary>
        /// <param name="wkBook">The name of the workbook</param>
        /// <param name="password">(Optional Parameter) The password to open the file</param>
        /// <param name="writeRes">(Optional Parameter) The password for the file whe  it is write reserved</param>
        /// <returns>A Microsoft Excel workbook object</returns>
        public virtual MSExcel.Workbook OpenWorkbook(string wkBook, [Optional, DefaultParameterValue(null)] string password, [Optional, DefaultParameterValue(null)] string writeRes)
        {
            try
            {
                _wkBook = _app.Workbooks.Open(Filename: wkBook, Password: null, WriteResPassword: null);
                return _wkBook;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot open requested workbook.");
                return null;
            }
        }

        /// <summary>
        /// Abstract base method for selecting a worksheet in an open workbook
        /// </summary>
        /// <param name="_sheet">The name of the worksheet to select</param>
        /// <returns>A reference to the worksheet requested</returns>
        public virtual MSExcel.Worksheet SelectWorksheet(string _sheet)
        {
            try
            {
                _wkBook.Activate();
                _wkSheet = _app.Worksheets[_sheet];
                _wkSheet.Select(false);
                return _wkSheet;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot select requested worksheet.");
                return null;
            }
        }


        /// <summary>
        /// Disposes of the instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the instance
        /// </summary>
        /// <param name="disposing">Whether the object is disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            bool disposed = false;
            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            if (disposed) { return; }
            if (disposing) { handle.Dispose(); }
            disposed = true;
        }
    }
}
