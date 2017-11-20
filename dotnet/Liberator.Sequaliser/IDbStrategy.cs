using System.Data;

namespace Liberator.Sequaliser
{
    public interface IDbStrategy
    {
        /// <summary>
        /// The connection string to communicate with the database
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// The type of database to connect to
        /// </summary>
        EnumDatabaseType DatabaseType { get; }

        /// <summary>
        /// Sends an update query to the database, requesting changes to the associated records
        /// </summary>
        /// <param name="command">The data set containing the records to edit</param>
        void UpdateRecords(IDbCommand command);

        /// <summary>
        /// Requests a select query be performed against the current database
        /// </summary>
        /// <param name="command">The command used to fetch the data</param>
        /// <returns>A data set containing the selected records</returns>
        DataSet QueryDatabase(IDbCommand command);
    }
}
