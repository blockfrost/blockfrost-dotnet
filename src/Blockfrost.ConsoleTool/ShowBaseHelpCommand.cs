using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool
{
    public class ShowBaseHelpCommand : ICommand
    {
        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var versionString = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyFileVersionAttribute>()
                .Version;
            var helpText = $@"cscli v{versionString}
A .NET Cross Platform Tool / Console App for generating Cardano keys, addresses and transactions.

USAGE: cscli (OPTION | COMMAND)

Available options:
    -v, --version   Show the cscli version
    -h, --help      Show this help text

Available commands:
    wallethd mnemonic gen --size (9|12|15|18|21|24) --language (English|ChineseSimplified|ChineseTraditional|French|Italian|Japanese|Korean|Spanish|Czech|Portuguese)
    (WIP) wallethd key payment derive --mnemonic ""$MNEMONIC"" [--account-index ACCT_IX] --address-index ADDR_IX --verification-key-file VKEY --signing-key-file SKEY --output-format (HEX|CBOR|BECH32|JSON)
    (WIP) wallethd key stake derive --mnemonic ""$MNEMONIC"" [--account-index ACCT_IX] --address-index ADDR_IX --verification-key-file VKEY --signing-key-file SKEY --output-format (HEX|CBOR|BECH32|JSON)
    (WIP) wallethd address payment derive --mnemonic ""$MNEMONIC"" [--account-index ACCT_IX] --address-index ADDR_IX --output-format (HEX|CBOR|BECH32|JSON) (--mainnet | --testnet-magic MAGIC)
    (WIP) wallethd address stake derive --mnemonic ""$MNEMONIC"" [--account-index ACCT_IX] --address-index ADDR_IX --output-format (HEX|CBOR|BECH32|JSON) (--mainnet | --testnet-magic MAGIC)";
            return ValueTask.FromResult(CommandResult.Success(helpText));
        }
    }
}