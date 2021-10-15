using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Cli.Commands
{
    public class ShowCommandHelpCommand<TCommand> : ICommand where TCommand : CommandBase
    {
        private readonly Type _command;
        public string CommandName => _command.Name[0..^7].ToLowerInvariant();
        public ShowCommandHelpCommand()
        {
            _command = typeof(TCommand);
        }

        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            string helpText = $@"bfcli {CommandName} (PARAMETERS) (SUBCOMMAND)

Required parameters:
--hash          the bech32 encoded address

Available subcommands:
--total 
--utxos 
--txs 
--transactions 
";
            return ValueTask.FromResult(CommandResult.Success(helpText));
        }
    }
}
