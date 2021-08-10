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
            var cardanoSharpVersion = "";
            var version = Assembly.GetAssembly(typeof(Blockfrost.Api.Version))?.GetName().Version;
            if (version is not null)
                version.ToString();
            var cscliVersionString = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
            var versionText = $"blockfrost {cscliVersionString} | Blockfrost.Api {cardanoSharpVersion}";
            return ValueTask.FromResult(CommandResult.Success(versionText));
        }
    }
}