using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public abstract class ABlockfrostCommandBase : ICommand
    {
        protected readonly IBlockfrostService _service;

        protected ABlockfrostCommandBase(IBlockfrostService service)
        {
            _service = service;
        }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}