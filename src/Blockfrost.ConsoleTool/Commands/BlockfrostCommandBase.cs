using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.ConsoleTool.Commands
{
    public abstract class BlockfrostCommandBase : ICommand
    {
        protected readonly IBlockfrostService Service;

        protected BlockfrostCommandBase(IBlockfrostService service)
        {
            Service = service;
        }
        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}