using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.ConsoleTool
{
    /// <summary>
    /// Based on https://github.com/CardanoSharp/cscli
    /// </summary>
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var cts = SetupUserInputCancellationTokenSource();
            var command = CommandParser.ParseArgsToCommand(args);
            var commandResult = await command.ExecuteAsync(cts.Token).ConfigureAwait(false);
            if (commandResult.Outcome == CommandOutcome.Success)
            {
                await Console.Out.WriteLineAsync(commandResult.Result);
            }
            else
            {
                await Console.Error.WriteLineAsync(commandResult.Result);
                return (int)commandResult.Outcome;
            }
            return 0;
        }

        private static CancellationTokenSource SetupUserInputCancellationTokenSource()
        {
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };
            return cts;
        }
    }
}
