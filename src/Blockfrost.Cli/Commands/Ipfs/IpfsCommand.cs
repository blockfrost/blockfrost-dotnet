using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Ipfs
{
    public class IpfsCommand : BlockfrostServiceCommand<IIPFSService>
    {
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var result = await Service.Pins.GetPinListAsync("", ct);
            return await Success(result);
        }
    }
}
