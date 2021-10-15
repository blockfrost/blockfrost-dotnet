using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Pools
{
    public class PoolsCommand : BlockfrostServiceCommand<IPoolsService>
    {
        public static Dictionary<string, string> SwitchMappings { get; internal set; }
        [Parameter(Position = 1, Required = true)]
        public string PoolId { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetPoolsAsync(PoolId, ct);
            return await Success(response);
        }
    }
}
