using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool.Commands
{
    public interface ICommand
    {
        ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}