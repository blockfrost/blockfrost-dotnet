using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public abstract class ABlockfrostCommandBase : ICommand
    {
        protected ABlockfrostCommandBase(IBlockfrostService service)
        {
            Service = service;
        }

        protected IBlockfrostService Service { get; }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}
