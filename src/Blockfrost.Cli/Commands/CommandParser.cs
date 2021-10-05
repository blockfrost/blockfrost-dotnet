using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;
using Blockfrost.Cli.Commands.Cardano.Addresses;
using Blockfrost.Cli.Commands.Cardano.Blocks;
using Blockfrost.Cli.Commands.Cardano.Transactions;
using Blockfrost.Cli.Commands.Common.Health;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Cli.Commands
{

    public static class CommandParser
    {
        private const StringComparison OIC = StringComparison.OrdinalIgnoreCase;

        public static ICommand Parse(string[] args)
        {
            if (args.Length == 0 || IsHelpOption(args[0]))
            {
                return new ShowBaseHelpCommand();
            }

            if (IsVersionOption(args[0]))
            {
                return new ShowVersionCommand();
            }

            string input = string.Join(' ', args);

            if (Regex.IsMatch(input, @"^addr(ess)?(es)?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IAddressesService, AddressesCommand>(args, AddressesCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^t(ransaction|x)s?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<ITransactionsService, TransactionsCommand>(args, TransactionsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^bl(ock|k)s?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IBlocksService, BlocksCommand>(args, BlocksCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^(health|<3)\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IHealthService, HealthCommand>(args, null);
            }

            return new ShowInvalidArgumentCommand(input);
        }

        private static TCommand BuildCommand<TService, TCommand>(string[] args, Dictionary<string, string> switchMappings = null)
            where TService : IBlockfrostService
            where TCommand : BlockfrostServiceCommand<TService>
        {
            string env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            bool isDevelopment = string.IsNullOrEmpty(env) || env.ToLower(System.Globalization.CultureInfo.InvariantCulture) == "development";

            var builder = new ConfigurationBuilder();
            _ = builder.AddEnvironmentVariables();

            _ = switchMappings == null
                ? builder.AddCommandLine(args)
                : builder.AddCommandLine(args, switchMappings);

            if (isDevelopment)
            {
                _ = builder.AddUserSecrets<CliSettings>();
            }

            string network = Environment.GetEnvironmentVariable("BFCLI_NETWORK");
            string apikey = Environment.GetEnvironmentVariable("BFCLI_APIKEY");

            var config = builder.Build();

            if (isDevelopment)
            {
                apikey ??= config["CliSettings:ApiKey"];
            }

            var provider = new ServiceCollection()
                .AddBlockfrost(network, apikey)
                .AddSingleton(_ => new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault })
                .AddSingleton(provider =>
                {
                    var cmd = config.Get<TCommand>();
                    cmd.Options = provider.GetRequiredService<JsonSerializerOptions>();
                    cmd.Service = provider.GetRequiredService<TService>();
                    cmd.SetCommandLineArguments(args);
                    return cmd;
                })
                .BuildServiceProvider();

            return provider.GetRequiredService<TCommand>();
        }

        private static bool IsHelpOption(string arg)
        {
            return arg
                is "help"
                or "-h"
                or "--help";
        }

        private static bool IsVersionOption(string arg)
        {
            return arg
                is "version"
                or "-v"
                or "--version";
        }
    }
}
