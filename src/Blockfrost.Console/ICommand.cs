using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool
{
    public interface ICommand
    {
        ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);
    }
}