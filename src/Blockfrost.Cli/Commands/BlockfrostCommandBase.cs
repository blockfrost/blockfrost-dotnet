using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;

namespace Blockfrost.Cli.Commands
{
    public abstract class BlockfrostCommandBase<TService> : ICommand where TService : IBlockfrostService
    {
        protected BlockfrostCommandBase(TService service)
        {
            Service = service;
        }

        protected TService Service { get; }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}
