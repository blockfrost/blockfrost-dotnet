using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using CardanoSharp.Wallet.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BlockfrostHostedService : IHostedService
    {
        private const int patience = 4;
        private readonly ILogger _logger;
        private readonly IBlockService _blocks;
        private static JsonSerializerOptions __options = new JsonSerializerOptions() { WriteIndented = true };
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

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            int? slot = 0;
            int waitCount = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                var latest = await _blocks.GetLatestBlockAsync(cancellationToken);
                if (slot != latest.Slot)
                {
                    if(waitCount > Math.Pow(patience, 1.61803)) _logger.LogDebug("Finally!!");

                    waitCount = 0;

                    _logger.LogInformation(JsonSerializer.Serialize(latest, __options));
                }
                else
                {
                    waitCount++;
                    if (waitCount < patience)
                    {
                        _logger.LogDebug("Waiting for next block...");
                    }
                    else if (waitCount >= patience)
                    {
                        if (waitCount == patience)
                        {
                            _logger.LogDebug("While we wait, enjoy some transactionIds from the TIP:");
                        }
                        else
                        {
                            var txs = await _blocks.TxsAll2Async(latest.Hash, 1, waitCount - patience, ESortOrder.Asc, cancellationToken);
                            string txid = txs.FirstOrDefault();
                            if (txid != null)
                            {
                                _logger.LogInformation(txid);
                            }
                            else
                            {
                                _logger.LogDebug("Next block is coming soon...");
                            }
                        }
                    }
                    await Task.Delay(TimeSpan.FromSeconds(patience));
                }
                slot = latest.Slot;
            }
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
                var network = context.Configuration["Network"];
                var apiKey = context.Configuration["ApiKey"];

                services
                    .AddBlockfrost(network, apiKey)
                    .AddHostedService<BlockfrostHostedService>();
            });

    }
}