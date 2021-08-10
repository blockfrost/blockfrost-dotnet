using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool
{
    public class ShowVersionCommand : ICommand
    {
        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var blockfrostVersionString = Assembly.GetAssembly(typeof(Api.BlockfrostService))?.GetName().Version?.ToString();
            var cscliVersionString = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
            var versionText = $"blockfrost {cscliVersionString} | Blockfrost.Api {blockfrostVersionString}";
            return ValueTask.FromResult(CommandResult.Success(versionText));
        }
    }
}