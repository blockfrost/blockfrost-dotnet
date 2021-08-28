using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public abstract class BlockfrostCommandBase : ICommand
    {
        protected BlockfrostCommandBase(IBlockfrostService service)
        {
            Service = service;
        }

        protected IBlockfrostService Service { get; }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}
