using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechSolutionsLibs.Provider;

namespace TechSolutionsLibs
{
    public static class DbOptionsFactory
    {
        static DbOptionsFactory()
        {
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["Data:DefaultConnection:ConnectionString"];
            
            DbContextOptions = new DbContextOptionsBuilder<ActivityDBContext>()
                .UseSqlServer(connectionString)
                .Options;
            
        }

        public static DbContextOptions<ActivityDBContext> DbContextOptions { get; }

    }
}
