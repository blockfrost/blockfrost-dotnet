using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands.Ipfs
{
    public class Ipfsommand : BlockfrostServiceCommand<IIpfsService>
    {
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}
