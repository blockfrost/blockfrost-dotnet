using System;
using System.Linq;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Options;
using Blockfrost.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlockfrostWithAzure
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                //.AddUserSecrets<Program>()
                .Build();

            var service = new ServiceCollection()
                .AddBlockfrost(config)
                .BuildServiceProvider()
                .GetHealthService();

            var health = await service.GetHealthAsync();

            Console.WriteLine(health.ToJson());
        }
    }
}
