using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Console.Test
{
    public class BlockfrostHostedService : IHostedService
    {
        static readonly JsonSerializerOptions s_options = new() { WriteIndented = true };

        private readonly ILogger _logger;
        private readonly IBlockService _blocks;

        public BlockfrostHostedService(
            IBlockService blockService,
            ILogger<BlockfrostHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _blocks = blockService;
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartAsync has been called.");
            
            return Task.Run(async () =>
            {
                int? slot = 0;
                while (true)
                {
                    var latest = await _blocks.GetLatestBlockAsync();
                    if (slot != latest.Slot)
                    {
                        slot = latest.Slot;
                        _logger.LogInformation(JsonSerializer.Serialize(latest, s_options));
                    } else
                    {
                        _logger.LogDebug("No new block...");
                    }

                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("4. StopAsync has been called.");

            return Task.CompletedTask;
        }

        

        private void OnStarted()
        {
            _logger.LogInformation("2. OnStarted has been called.");
        }

        private void OnStopping()
        {
            _logger.LogInformation("3. OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("5. OnStopped has been called.");
        }
    }

    class Program
    {
        static Task Main(string[] args) =>
           CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                string network = context.Configuration["Network"];
                string apiKey = context.Configuration["ApiKey"];

                services
                    .AddBlockfrost(network, apiKey)
                    .AddHostedService<BlockfrostHostedService>();
            });

    }
}
