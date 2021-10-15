using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Transactions
{
    public class TransactionsCommand : BlockfrostServiceCommand<ITransactionsService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--tx", "hash" },
            { "--txid", "hash" },
            { "--hash", "hash" },
            { "--path", "file" },
            { "--file", "file" }
        };

        [Parameter(Position = 1, Description = "Transaction id", Required = true)]
        public string Hash { get; set; }
        public string File { get; set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                if (string.IsNullOrEmpty(Hash))
                {
                    return await ValueTask.FromResult(
                        CommandResult.FailureInvalidOptions("Hash not supplied"));
                }

                if (Hash.Equals("submit", StringComparison.OrdinalIgnoreCase))
                {

                }

                if (IsSubcommand("--utxos"))
                {
                    var utxos = await Service.GetUtxosAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--stakes"))
                {
                    var utxos = await Service.GetStakesAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--delegations"))
                {
                    var utxos = await Service.GetDelegationsAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--withdrawals"))
                {
                    var utxos = await Service.GetWithdrawalsAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--mirs"))
                {
                    var utxos = await Service.GetMirsAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--pool-updates"))
                {
                    var utxos = await Service.GetPoolUpdatesAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--pool-retries"))
                {
                    var utxos = await Service.GetPoolRetiresAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--metadata"))
                {
                    var utxos = await Service.GetMetadataAsync(Hash, ct);
                    return await Success(utxos);
                }

                if (IsSubcommand("--redeemers"))
                {
                    var utxos = await Service.GetRedeemersAsync(Hash, ct);
                    return await Success(utxos);
                }

                var response = await Service.GetAsync(Hash, ct);
                return await Success(response);
            }
            //catch (CommandParametersException ex)
            //{
            //    return await ValueTask.FromResult(
            //        CommandResult.FailureInvalidOptions(ex.Message));
            //}
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
