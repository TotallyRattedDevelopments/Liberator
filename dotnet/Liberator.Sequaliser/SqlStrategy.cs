using System;
using System.Data;

namespace Liberator.Sequaliser
{
    public class SqlStrategy : IDbStrategy
    {
        public string ConnectionString { get; set; }

        public EnumDatabaseType DatabaseType { get; set; }

        public DataSet QueryDatabase(IDbCommand command)
        {
            switch (command.GetType().Name)
            {
                case "SqlCommand":
                    using (var mss = new MsSqlServer()) { return mss.QueryDatabase(command); }
                case "MySqlCommand":
                    using (var mys = new MySqlServer() ) { return mys.QueryDatabase(command); }
                case "OracleCommand":
                    using (var os = new OracleServer()) { return os.QueryDatabase(command); }
                case "NpgsqlCommand":
                    using (var ps = new PostgresServer()) { return ps.QueryDatabase(command); }
            }
            return null;
        }

        public void UpdateRecords(IDbCommand command)
        {
            switch (command.GetType().Name)
            {
                case "SqlCommand":
                    using (var mss = new MsSqlServer()) { mss.UpdateRecords(command); }
                    break;
                case "MySqlCommand":
                    using (var mys = new MySqlServer()) { mys.UpdateRecords(command); }
                    break;
                case "OracleCommand":
                    using (var os = new OracleServer()) { os.UpdateRecords(command); }
                    break;
                case "NpgsqlCommand":
                    using (var ps = new PostgresServer()) { ps.UpdateRecords(command); }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(command.ToString());
            }
        }
    }
}
