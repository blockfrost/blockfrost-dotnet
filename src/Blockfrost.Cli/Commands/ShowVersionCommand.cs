using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public class ShowVersionCommand : ICommand
    {
        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            string blockfrostVersionString = (Assembly.GetAssembly(typeof(Api.IBlockfrostService)) ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            string bfcliVersionString = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            string versionText = $"bfcli {bfcliVersionString} | Blockfrost.Api {blockfrostVersionString}";
            return ValueTask.FromResult(CommandResult.Success(versionText));
        }
    }
}
