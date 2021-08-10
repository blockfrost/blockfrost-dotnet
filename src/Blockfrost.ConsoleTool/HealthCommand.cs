using System;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.ConsoleTool
{
    public class HealthCommand : BlockfrostCommandBase
    {
        public HealthCommand(IBlockfrostService service) : base(service)
        {
        }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {

            try
            {
                var result = CommandResult.Success($"{await Service.GetHealthAsync(ct)}");
                return await ValueTask.FromResult(result);
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}