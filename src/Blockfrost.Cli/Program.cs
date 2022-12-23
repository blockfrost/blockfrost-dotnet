using System;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Cli.Commands;

namespace Blockfrost.Cli
{
    /// <summary>
    /// Based on https://github.com/CardanoSharp/cscli
    /// </summary>
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var command = CommandParser.Parse(args);

            var commandResult = await command.ExecuteAsync(SetupCTS().Token);
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

        private static CancellationTokenSource SetupCTS()
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
