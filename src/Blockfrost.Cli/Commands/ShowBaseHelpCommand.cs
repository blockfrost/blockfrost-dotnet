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
   
Cardano commands:
    accounts <hash> (--total | --utxos | --txs | --transactions)
    addresses <address> (--total | --utxos | --txs | --transactions)
    assets <asset> (--total | --utxos | --txs | --transactions)
    blocks <hash_or_number> (--total | --utxos | --txs | --transactions)
    epochs <number> (--total | --utxos | --txs | --transactions)
    ledger 
    metadata <hash> (--total | --utxos | --txs | --transactions)
    network <slot_or_number> --()
    pools <pool_id> --()
    scripts <script_hash> --()
    transactions <txId>

Ipfs commands:
    add <slot_or_number> --()
    ipfs <slot_or_number> --()
    gateway <slot_or_number> --()
    
General commands:
    metrics <slot_or_number> --()
    health (--clock)

";

            return ValueTask.FromResult(CommandResult.Success(helpText));
        }
    }
}
