using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Assets
{
    public class AssetsCommand : BlockfrostServiceCommand<IAssetsService>
    {
        internal static readonly Dictionary<string, string> SwitchMappings;

        [Parameter(Position = 1, Required = true)]
        public string Asset { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetAssetsAsync(Asset, ct);
            return await Success(response);
        }
    }
}
