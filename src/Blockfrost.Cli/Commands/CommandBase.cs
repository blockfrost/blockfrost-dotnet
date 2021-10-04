using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public abstract class CommandBase : ICommand
    {
        public JsonSerializerOptions Options { get; set; }
        public IEnumerable<string> Args { get; set; }

        public abstract ValueTask<CommandResult> ExecuteAsync(CancellationToken ct);

        protected bool IsSubcommand(string name)
        {
            return Args.Contains(name, StringComparer.OrdinalIgnoreCase);
        }
    }
}
