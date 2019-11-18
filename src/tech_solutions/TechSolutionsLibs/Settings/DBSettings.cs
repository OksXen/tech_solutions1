using Microsoft.Extensions.Configuration;
using TechSolutionsLibs.Settings.Interface;

namespace TechSolutionsLibs.Settings
{
    public class DBSettings : IDBSettings
    {
        string _connectionString;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }

        public DBSettings()
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = config["Data:DefaultConnection:ConnectionString"];
            _connectionString = connectionString;
        }
    }
}
