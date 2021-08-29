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
        private int? _latestSlot = 0;
        private int _waitCount = 0;
        private readonly ILogger _logger;
        private readonly IBlockService _blockService;
        private readonly IPoolService _poolService;
        private static JsonSerializerOptions __options = new JsonSerializerOptions() { WriteIndented = true };

        public BlockfrostHostedService(
            IBlockService blockService,
            IPoolService poolService,
            ILogger<BlockfrostHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
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
                    var latest = await _blockService.GetLatestBlockAsync(cancellationToken);
                    if (_latestSlot != latest.Slot) WriteBlock(latest);
                    else await NextBlock(latest, cancellationToken);
                }
            }, cancellationToken);
        }

        private void WriteBlock(BlockContentResponse latest)
        {
            if (_waitCount > Math.Pow(PATIENCE, 1.61803)) _logger.LogDebug("Finally! Behold the new TIP...");
            _waitCount = 0;
            _logger.LogInformation(JsonSerializer.Serialize(latest, __options));
            _latestSlot = latest.Slot;
        }

        private async Task NextBlock(BlockContentResponse latest, CancellationToken cancellationToken)
        {
            _waitCount++;
            if (_waitCount < PATIENCE)
            {
                _logger.LogDebug("Waiting for next block...");
            }
            else if (_waitCount == PATIENCE)
            {
                var pool = await _poolService.PoolsAsync(latest.SlotLeader, cancellationToken);
                var metadata = await _poolService.MetadataAsync(latest.SlotLeader, cancellationToken);
                var recent_blocks = await _poolService.BlocksAll3Async(latest.SlotLeader, 10, 1, ESortOrder.Desc, cancellationToken);
                var json = JsonSerializer.Serialize(new { pool, metadata, recent_blocks }, __options);
                _logger.LogInformation("The latest block is brought to you by:\n      {json}", json);
            }
            else
            {
                _logger.LogDebug("Next block is coming soon...");
            }
            await Task.Delay(TimeSpan.FromSeconds(PATIENCE), cancellationToken);
        }

        private async Task WriteTx(BlockContentResponse latest, int txIx, CancellationToken cancellationToken)
        {
            var txs = await _blockService.TxsAll2Async(latest.Hash, 1, txIx, ESortOrder.Asc, cancellationToken);
            string txid = txs.FirstOrDefault();
            _logger.LogInformation(txid);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Have a nice day!");
            return Task.CompletedTask;
        }
    }
}