using System.IO;
using Microsoft.Extensions.Configuration;

namespace AutoService.DAL
{
    public class DalConfiguration
    {
        public DalConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSetting.Value;
        }

        public string sqlConnectionString { get; set; }
    }
}
