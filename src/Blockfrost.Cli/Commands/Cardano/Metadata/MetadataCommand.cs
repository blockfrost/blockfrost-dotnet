using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Metadata
{
    public class MetadataCommand : BlockfrostServiceCommand<IMetadataService>
    {
        public static Dictionary<string, string> SwitchMappings { get; internal set; }

        [Parameter(Position = 1, Required = false)]
        public string Label { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetTxsLabelsAsync(Count, Page, Order, ct);
            return await Success(response);
        }
    }
}
