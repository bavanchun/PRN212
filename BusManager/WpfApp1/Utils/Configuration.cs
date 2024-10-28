using Microsoft.Extensions.Configuration;

namespace WpfApp1.Utils
{
    public class Configuration
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(string.Join("\\", AppDomain.CurrentDomain.BaseDirectory.Split("\\").SkipLast(4)))
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
