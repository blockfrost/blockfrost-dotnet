using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Ledger
{
    public class LedgerCommand : BlockfrostServiceCommand<ILedgerService>
    {
        public static Dictionary<string, string> SwitchMappings { get; internal set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetGenesisAsync(ct);
            return await Success(response);
        }
    }
}
