using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject1.Helper
{
    public static class MemoryCacheHelper
    {
        public static IMemoryCache GetMemoryCache()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetService<IMemoryCache>();
            
        }
    }
}
