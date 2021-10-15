using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Common.Metrics
{
    public class MetricsCommand : BlockfrostServiceCommand<IMetricsService>
    {
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetMetricsAsync(ct);
            return await Success(response);
        }
    }
}
