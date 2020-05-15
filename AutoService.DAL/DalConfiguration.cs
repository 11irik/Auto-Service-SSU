using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoService.DAL
{
    public class DalConfiguration
    {
        private static string sqlConnectionString;

        public static string GetSqlConnectionString()
        {
            if (sqlConnectionString == null)
            {
                var configBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configBuilder.AddJsonFile(path, false);
                var root = configBuilder.Build();
                var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
                sqlConnectionString = appSetting.Value;
            }

            return sqlConnectionString;
        }

    }
}
