using Liberator.Excellerator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Liberator.Excellerator.Mappers
{
    internal class DataMapper<TExcelData> where TExcelData:IExcelData
    {
        #region Internal Properties

        public MSExcel.Range DataRange { get; internal set; }
        public List<string> ColumnHeaders { get; internal set; }
        public TExcelData Mapfile { get; internal set; }
        public Dictionary<string, int> ColumnMap { get; internal set; }
        public IEnumerable<PropertyInfo> PropertyList { get; internal set; }
        public object[,] DataArray { get; internal set; }

        #endregion

        #region Constructor

        public DataMapper(MSExcel.Range range, List<string> headers)
        {
            IEnumerable<PropertyInfo> propertyList = typeof(TExcelData).GetRuntimeProperties();
            MapAllColumnsToProperties(headers);
        }

        #endregion

        #region Internal Methods

        private Dictionary<string, int> MapAllColumnsToProperties(List<string> headers)
        {
            try
            {
                int column = 0;
                foreach (PropertyInfo property in PropertyList)
                {
                    ColumnAttribute att = (ColumnAttribute)property.GetCustomAttribute<ColumnAttribute>();
                    if (headers.Any(h => h.Contains(att.Name)))
                    {
                        column = headers.FindIndex(h => h.Contains(att.Name));
                        ColumnMap.Add(att.Name, column);
                    }
                }
                return ColumnMap;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not map the spreadsheet columns to the properties defined in the data class.");
                return null;
            }
        }

        private object[,] BuildDataArray()
        {
            try
            {
                int columnNumber = 0;
                string cellValue = null;
                for (int row = 0; row < DataRange.Rows.Count; row++)
                {
                    for (int column = 0; column < DataRange.Columns.Count; column++)
                    {
                        cellValue = DataRange[row, column];
                        columnNumber = ColumnHeaders.IndexOf(cellValue);
                        DataArray[row, columnNumber] = cellValue;
                    }
                }
                return DataArray;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not build the data array from the extracted range.");
                return null;
            }
        }


        #endregion
    }
}
