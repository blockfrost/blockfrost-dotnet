using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Common.Health
{
    public class ApiInfoCommand : BlockfrostServiceCommand<IHealthService>
    {
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                var response = await Service.GetApiInfoAsync(ct);
                return await Success(response);
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
