using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public class ShowBaseHelpCommand : ICommand
    {
        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            string versionString = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyFileVersionAttribute>()
                .Version;
            string helpText = $@"bfcli v{versionString}
A .NET Cross Platform Tool / Console App for interacting with Blockfrost API.

USAGE: bfcli (OPTION | COMMAND)

Available options:
    -v, --version   Show the bfcli version
    -h, --help      Show this help text

Available commands:
    health";
            return ValueTask.FromResult(CommandResult.Success(helpText));
        }
    }
}
