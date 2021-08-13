using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public interface ICommand
    {
        ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}