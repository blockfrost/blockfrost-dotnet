using Blockfrost.Api.Extensions;
using CardanoSharp.Wallet.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Program
    {
        static Task Main(string[] args) =>
           CreateHostBuilder(args).RunConsoleAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                var network = context.Configuration["Network"];
                var apiKey = context.Configuration["ApiKey"];

                if (string.IsNullOrEmpty(apiKey))
                {
                    System.Console.Error.WriteLine("if you run this sample outside of you development environment, please set the 'ApiKey' in the appsettings.json.");
                    System.Console.Error.WriteLine("Press any key to close this window.");
                    System.Console.ReadKey();
                } 
                else
                {
                    services
                        .AddBlockfrost(network, apiKey)
                        .AddHostedService<BlockfrostHostedService>();
                }
            });
    }
}