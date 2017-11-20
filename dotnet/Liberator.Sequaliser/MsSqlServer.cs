using Microsoft.Win32.SafeHandles;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Liberator.Sequaliser
{
    public class MsSqlServer : IDbStrategy, IDisposable
    {
        string _connectionString;

        /// <summary>
        /// The connection string for the database being used
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// Returns the type of database being used, i.e., MS SQL
        /// </summary>
        public EnumDatabaseType DatabaseType
        {
            get { return EnumDatabaseType.MsSql; }
        }

        /// <summary>
        /// Updates a set of reccords as specified in the SQL Command object
        /// </summary>
        /// <param name="command">The command to be executed</param>
        public void UpdateRecords(IDbCommand command)
        {
            _connectionString = command.Connection.ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Executes a select query on an associated database
        /// </summary>
        /// <param name="sProcName">The name of the stored procedure being used</param>
        /// <param name="command">The SQL Command object that contains the query parameters</param>
        /// <returns>A dataset resulting from the query</returns>
        public DataSet QueryDatabase(IDbCommand command)
        {
            DataSet dataSet = new DataSet();
            _connectionString = command.Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter((SqlCommand)command))
                {
                    dataAdapter.Fill(dataSet);
                }
                connection.Close();
            }
            return dataSet;
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
