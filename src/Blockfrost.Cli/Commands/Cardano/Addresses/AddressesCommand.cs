using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Addresses
{
    [Command(Name = "addresses", Description = "Information related to cardano addresses.")]
    public class AddressesCommand : BlockfrostServiceCommand<IAddressesService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--addr", "address" }
        };

        [Parameter(Position = 1, Description = "The address hash.", Required = true)]
        public string Address { get; set; }

        [Switch(Position = 2, Description = "A specific subcommand [--total|--utxos|--txs|--transactions]", Required = false)]
        public string Subcommand { get; set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                //if (string.IsNullOrEmpty(Address))
                //{
                //    var usage = new ShowCommandHelpCommand<AddressesCommand>();
                //    return await usage.ExecuteAsync(ct);
                //}

                if (Count < 0)
                {
                    return await ValueTask.FromResult(CommandResult.FailureInvalidOptions(
                        $"Invalid option --count. '{Count}' must positive integer"));
                }

                //if (!Enum.TryParse<EContentType>(AddressType, out _))
                //{
                //    return await ValueTask.FromResult(CommandResult.FailureInvalidOptions(
                //        $"Invalid option --type {AddressType} is not supported"));
                //}

                if (IsSubcommand("--total"))
                {
                    var total = await Service.GetAddressesAsync(Address, ct);
                    return await Success(total);
                }
                else if (IsSubcommand("--utxos"))
                {
                    var utxos = await Service.GetUtxosAsync(Address, Count, Page, Order, ct);
                    return await Success(utxos);
                }
                else if (IsSubcommand("--txs"))
                {
                    var txs = await Service.GetTxsAsync(Address, Count, Page, Order, ct);
                    return await Success(txs);
                }
                else if (IsSubcommand("--transactions"))
                {
                    var transactions = await Service.GetTransactionsAsync(Address, From, To, Count, Page, Order, ct);
                    return await Success(transactions);
                }
                else
                {
                    var response = await Service.GetAddressesAsync(Address, ct);
                    return await Success(response);
                }
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
