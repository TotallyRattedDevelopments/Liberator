namespace Liberator.Sequaliser
{
    /// <summary>
    /// Type of database used
    /// </summary>
    public enum EnumDatabaseType
    {
        /// <summary>
        /// No database type specified
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// Microsoft SQL Server
        /// </summary>
        MsSql = 1,

        /// <summary>
        /// MySQL
        /// </summary>
        MySql = 2,

        /// <summary>
        /// Oracle DB
        /// </summary>
        Oracle = 3,

        /// <summary>
        /// PostrgesDB and its variance
        /// </summary>
        Postgres = 4
    }
}
