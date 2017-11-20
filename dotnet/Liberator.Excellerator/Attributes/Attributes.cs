using System;

namespace Liberator.Excellerator.Attributes
{
    /// <summary>
    /// Used to represent a column in an Excel file containing table data
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute: Attribute
    {
        private string name = null;
        private bool mandatory = false;
        private object defaultValue = null;
        
        /// <summary>
        /// The column name found in the first row
        /// </summary>
        public virtual string Name { get { return name; } }

        /// <summary>
        /// Whether the column is mandatory for import purposes
        /// </summary>
        public virtual bool Mandatory { get { return mandatory; } }

        /// <summary>
        /// A default for the column's values
        /// </summary>
        public virtual object Default { get { return defaultValue; } }

        /// <summary>
        /// Represents a column attribute
        /// </summary>
        /// <param name="name">The name of the column</param>
        public ColumnAttribute(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Represents a column attribute
        /// </summary>
        /// <param name="name">The name of the column</param>
        /// <param name="mandatory">Whether the value is mandatory</param>
        public ColumnAttribute(string name, bool mandatory)
        {
            this.name = name;
            this.mandatory = mandatory;
        }

        /// <summary>
        /// Represents a column attribute
        /// </summary>
        /// <param name="name">The name of the column</param>
        /// <param name="def">The default value for the row</param>
        public ColumnAttribute(string name, object def)
        {
            this.name = name;
            this.defaultValue = def;
        }

        /// <summary>
        /// Represents a column attribute
        /// </summary>
        /// <param name="name">The name of the column</param>
        /// <param name="mandatory">Whether the value is mandatory</param>
        /// <param name="def">The default value for the row</param>
        public ColumnAttribute(string name, bool mandatory, object def)
        {
            this.name = name;
            this.mandatory = mandatory;
            this.defaultValue = def;
        }
    }

    /// <summary>
    /// Class used to represent a data row from an excel file
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExcelDataRowAttribute : Attribute
    {

    }
}
