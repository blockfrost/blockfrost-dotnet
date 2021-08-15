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
           CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                var network = context.Configuration["Network"];
                var apiKey = context.Configuration["ApiKey"];

                services
                    .AddBlockfrost(network, apiKey)
                    .AddHostedService<BlockfrostHostedService>();
            });
    }
}