using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Blockfrost.Console.Test
{
    public class BlockfrostHostedService : IHostedService
    {
        private static readonly JsonSerializerOptions s_options = new() { WriteIndented = true };

        private readonly ILogger _logger;
        private readonly IBlockService _blocks;

        public BlockfrostHostedService(
            IBlockService blockService,
            ILogger<BlockfrostHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _blocks = blockService;
            _ = appLifetime.ApplicationStarted.Register(OnStarted);
            _ = appLifetime.ApplicationStopping.Register(OnStopping);
            _ = appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StartAsync has been called.");

            return Task.Run(async () =>
            {
                long slot = 0;
                while (true)
                {
                    var latest = await _blocks.V1.GetLatestAsync();
                    if (slot != latest.Slot)
                    {
                        slot = latest.Slot;
                        _logger.LogInformation(JsonSerializer.Serialize(latest, s_options));
                    }
                    else
                    {
                        _logger.LogDebug("Waiting for next block...");
                    }

                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("5. OnStopped has been called.");
        }
    }

    internal class Program
    {
        private static Task Main(string[] args) =>
           CreateHostBuilder(args).Build().RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                string network = context.Configuration["Network"];
                string apiKey = context.Configuration["ApiKey"];

                _ = services
                    .AddBlockfrost(network, apiKey)
                    .AddHostedService<BlockfrostHostedService>();
            });

    }
}
