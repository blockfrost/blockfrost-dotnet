using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Scripts
{
    public class ScriptsCommand : BlockfrostServiceCommand<IScriptsService>
    {
        public static Dictionary<string, string> SwitchMappings { get; internal set; }

        [Parameter(Position = 1, Required = true)]
        public string ScriptHash { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            if (IsSubcommand("--redeemers"))
            {
                var response = await Service.GetRedeemersAsync(ScriptHash, Count, Page, Order, ct);
                return await Success(response);
            }
            else
            {
                var response = await Service.GetScriptsAsync(ScriptHash, ct);
                return await Success(response);
            }
        }
    }
}
