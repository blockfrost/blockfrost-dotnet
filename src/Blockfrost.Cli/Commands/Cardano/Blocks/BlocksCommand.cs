using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Blocks
{
    public class BlocksCommand : BlockfrostServiceCommand<IBlocksService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--block", "hashornumber" },
            { "--hash", "hashornumber" },
            { "--number", "hashornumber" },
            { "--hashornumber", "hashornumber" }
        };

        [Parameter(Position = 1, Description = "Hash or number", Required = false)]
        public string HashOrNumber { get; set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                if (IsSubcommand("tip", "--latest"))
                {
                    var result = await Service.GetLatestAsync(ct);
                    return await Success(result);
                }
                if (string.IsNullOrEmpty(HashOrNumber))
                {
                    return await ValueTask.FromResult(
                        CommandResult.FailureInvalidOptions(@"Usage: blocks <hash_or_number> 
    [ 
      --latest-txs 
    |
      --next 
    ]"));
                }
                if (IsSubcommand("--latest-txs"))
                {
                    var result = await Service.GetLatestTxsAsync(Count, Page, Order, ct);
                    return await Success(result);
                }

                if (IsSubcommand("--next"))
                {
                    var result = await Service.GetNextAsync(HashOrNumber, Count, Page, ct);
                    return await Success(result);
                }

                if (IsSubcommand("--previous", "--prev"))
                {
                    var result = await Service.GetPreviousAsync(HashOrNumber, Count, Page, ct);
                    return await Success(result);
                }

                if (IsSubcommand("--slot"))
                {
                    int slot = int.Parse(HashOrNumber, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
                    var utxos = await Service.GetSlotAsync(slot, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--txs"))
                {
                    var result = await Service.GetTxsAsync(HashOrNumber, Count, Page, Order, ct);
                    return await Success(result);
                }

                if (IsSubcommand("--epoch-slot"))
                {
                    string[] epochSlot = HashOrNumber.Split(':');
                    int epoch = int.Parse(epochSlot[0], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
                    int slot = int.Parse(epochSlot[1], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
                    var result = await Service.GetEpochSlotAsync(epoch, slot, ct);
                    return await Success(result);
                }

                var response = await Service.GetBlocksAsync(HashOrNumber, ct);
                return await Success(response);
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
