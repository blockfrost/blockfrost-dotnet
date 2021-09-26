using Blockfrost.Api;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BlockfrostHostedService : IHostedService
    {
        private const int PATIENCE = 3;
        private long? _latestSlot = 0;
        private int _waitCount;
        private readonly ILogger _logger;
        private readonly IBlockService _blockService;
        private readonly IPoolService _poolService;
        private static readonly JsonSerializerOptions s_options = new() { WriteIndented = true };

        public BlockfrostHostedService(
            IBlockService blockService,
            IPoolService poolService,
            ILogger<BlockfrostHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
            if (appLifetime is null)
            {
                throw new ArgumentNullException(nameof(appLifetime));
            }

            _logger = logger;
            _blockService = blockService;
            _poolService = poolService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var latest = await _blockService.V1.GetLatestAsync(cancellationToken);

                    if (_latestSlot == latest.Slot)
                    {
                        await NextBlock(latest, cancellationToken);
                    }
                    else
                    {
                        WriteBlock(latest);
                    }
                }
            }, cancellationToken);
        }

        private void WriteBlock(Blockfrost.Api.Models.BlockContentResponse latest)
        {
            if (_waitCount > Math.Pow(PATIENCE, 1.61803))
            {
                _logger.LogDebug("Finally! Behold the new TIP...");
            }

            _waitCount = 0;
            _logger.LogInformation(JsonSerializer.Serialize(latest, s_options));
            _latestSlot = latest.Slot;
        }

        private async Task NextBlock(Blockfrost.Api.Models.BlockContentResponse latest, CancellationToken cancellationToken)
        {
            _waitCount++;
            if (_waitCount < PATIENCE)
            {
                _logger.LogDebug("Waiting for next block...");
            }
            else if (_waitCount == PATIENCE)
            {
                var pool = await _poolService.V1.GetPoolsAsync(latest.SlotLeader, cancellationToken);
                var metadata = await _poolService.V1.GetMetadataAsync(latest.SlotLeader, cancellationToken);
                var recent_blocks = await _poolService.V1.GetBlocksAsync(latest.SlotLeader, 10, 1, ESortOrder.Desc, cancellationToken);
                string json = JsonSerializer.Serialize(new { pool, metadata, recent_blocks }, s_options);
                _logger.LogInformation("The latest block is brought to you by:\n      {json}", json);
            }
            else
            {
                _logger.LogDebug("Next block is coming soon...");
            }
            await Task.Delay(TimeSpan.FromSeconds(PATIENCE), cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Have a nice day!");
            return Task.CompletedTask;
        }
    }
}
