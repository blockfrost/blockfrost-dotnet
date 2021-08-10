using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool
{
    public class ShowInvalidArgumentCommand : ICommand
    {
        public ShowInvalidArgumentCommand(string invalidArg)
        {
            InvalidArg = invalidArg;
        }

        public string InvalidArg { get; }

        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var helpText = $"Invalid argument {InvalidArg}";
            var result = CommandResult.Success(helpText);
            return ValueTask.FromResult(result);
        }
    }
}