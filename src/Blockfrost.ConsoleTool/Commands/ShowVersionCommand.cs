using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool.Commands
{
    public class ShowVersionCommand : ICommand
    {
        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var blockfrostVersionString = (Assembly.GetAssembly(typeof(Api.IBlockfrostService)) ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            var bfcliVersionString = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            var versionText = $"bfcli {bfcliVersionString} | Blockfrost.Api {blockfrostVersionString}";
            return ValueTask.FromResult(CommandResult.Success(versionText));
        }
    }
}