using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Transactions
{
    //public class CommandParametersException : Exception
    //{
    //    public CommandParametersException(string message) : base(message)
    //    {
    //    }
    //}

    //public class CommandParameters<TCommand> where TCommand : ICommand
    //{
    //    private readonly IConfigurationProvider _args;

    //    public CommandParameters(CommandLineConfigurationSource args)
    //    {
    //        _args = args.Build();
    //    }

    //    internal string Get(string name)
    //    {
    //        if (!_args.TryGet(name, out string value))
    //        {
    //            throw new CommandParametersException(name + " was not found");
    //        }
    //        return value;
    //    }
    //}
    public class TransactionsCommand : BlockfrostServiceCommand<ITransactionsService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--tx", "hash" },
            { "--txid", "hash" },
            { "--hash", "hash" }
        };

        public string Hash { get; set; }

        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                if (IsSubcommand("utxos"))
                {
                    var utxos = await Service.GetUtxosAsync(Hash, ct);
                    return await Success(utxos);
                }
                else
                {
                    var response = await Service.GetAsync(Hash, ct);
                    return await Success(response);
                }
            }
            //catch (CommandParametersException ex)
            //{
            //    return await ValueTask.FromResult(
            //        CommandResult.FailureInvalidOptions(ex.Message));
            //}
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
