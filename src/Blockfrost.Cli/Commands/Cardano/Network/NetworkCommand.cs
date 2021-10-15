using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Network
{
    public class NetworkCommand : BlockfrostServiceCommand<INetworkService>
    {
        public static Dictionary<string, string> SwitchMappings { get; internal set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetNetworkAsync(ct);
            return await Success(response);
        }
    }
}
