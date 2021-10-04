using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Addresses
{

    public class AddressesCommand : BlockfrostServiceCommand<IAddressesService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--addr", "address" }
        };

        public string Address { get; set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                if (IsSubcommand("total"))
                {
                    var total = await Service.GetAddressesAsync(Address, ct);
                    return await Success(total);
                }
                else if (IsSubcommand("utxos"))
                {
                    var utxos = await Service.GetUtxosAsync(Address, Count, Page, Order, ct);
                    return await Success(utxos);
                }
                else if (IsSubcommand("txs"))
                {
                    var txs = await Service.GetTxsAsync(Address, Count, Page, Order, ct);
                    return await Success(txs);
                }
                else if (IsSubcommand("transactions"))
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
