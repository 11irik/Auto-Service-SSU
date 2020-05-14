using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class DbConnection
    {
        private static DalConfiguration configuration;
        private static SqlConnection sqlConnection;

        public static SqlConnection GetSqlConnection()
        {
            if (configuration == null)
            {
                configuration = new DalConfiguration();
                sqlConnection = new SqlConnection(configuration.sqlConnectionString);
            }

            return sqlConnection;
        }
    }
}