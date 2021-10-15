using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Epochs
{
    public class EpochsCommand : BlockfrostServiceCommand<IEpochsService>
    {
        public static Dictionary<string, string> SwitchMappings { get; internal set; }

        [Parameter(Position = 1, Required = false)]
        public int Number { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetEpochsAsync(Number, ct);
            return await Success(response);
        }
    }
}
