using Microsoft.Extensions.Configuration;
using TechSolutionsLibs.Settings.Interface;

namespace TechSolutionsLibs.Settings
{
    public class CacheSettings : ICacheSettings
    {
        
        public int ExpiresInSeconds { get; set; }
        public bool Enable { get; set; }

        public CacheSettings()
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            var seconds = config["Caching:ExpiresInSeconds"];
            var isEnable = config["Caching:Enable"];


            var expiresInSeconds = 0;
            if (!int.TryParse(seconds, out expiresInSeconds))
            {
                expiresInSeconds = 0;
            }
            bool enable;
            if (!bool.TryParse(isEnable, out enable))
            {
                enable = false;
            }


            Enable = enable;
            ExpiresInSeconds = expiresInSeconds;            
        }
    }
}
