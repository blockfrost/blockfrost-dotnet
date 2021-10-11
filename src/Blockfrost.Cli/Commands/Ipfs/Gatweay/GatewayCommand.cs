using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Ipfs.Gateway
{
    public class GatewayCommand : BlockfrostServiceCommand<IGatewayService>
    {
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}
