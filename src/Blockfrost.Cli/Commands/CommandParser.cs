using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;
using Blockfrost.Cli.Commands.Cardano.Accounts;
using Blockfrost.Cli.Commands.Cardano.Addresses;
using Blockfrost.Cli.Commands.Cardano.Assets;
using Blockfrost.Cli.Commands.Cardano.Blocks;
using Blockfrost.Cli.Commands.Cardano.Epochs;
using Blockfrost.Cli.Commands.Cardano.Ledger;
using Blockfrost.Cli.Commands.Cardano.Metadata;
using Blockfrost.Cli.Commands.Cardano.Network;
using Blockfrost.Cli.Commands.Cardano.Pools;
using Blockfrost.Cli.Commands.Cardano.Scripts;
using Blockfrost.Cli.Commands.Cardano.Transactions;
using Blockfrost.Cli.Commands.Common.Health;
using Blockfrost.Cli.Commands.Common.Metrics;
using Blockfrost.Cli.Commands.Ipfs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Cli.Commands
{

    public static class CommandParser
    {
        private const StringComparison OIC = StringComparison.OrdinalIgnoreCase;
        public static string Network { get; set; } = Environment.GetEnvironmentVariable("BFCLI_NETWORK");
        public static string ApiKey { get; set; } = Environment.GetEnvironmentVariable("BFCLI_API_KEY");

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

            if (Regex.IsMatch(input, @"^acc(oun)?ts?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IAccountsService, AccountsCommand>(args, AccountsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^addr(ess)?(es)?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IAddressesService, AddressesCommand>(args, AddressesCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^assets?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IAssetsService, AssetsCommand>(args, AssetsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^(bl(ock|k)s?|🧊)\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IBlocksService, BlocksCommand>(args, BlocksCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^ep(och)?s?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IEpochsService, EpochsCommand>(args, EpochsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^le?dge?r?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<ILedgerService, LedgerCommand>(args, LedgerCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^meta(data)?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IMetadataService, MetadataCommand>(args, MetadataCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^network\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<INetworkService, NetworkCommand>(args, NetworkCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^pools?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IPoolsService, PoolsCommand>(args, PoolsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^scripts?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IScriptsService, ScriptsCommand>(args, ScriptsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^t(ransaction|r?xn?)s?\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<ITransactionsService, TransactionsCommand>(args, TransactionsCommand.SwitchMappings);
            }

            if (Regex.IsMatch(input, @"^(health|<3)\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IHealthService, HealthCommand>(args, null);
            }

            if (Regex.IsMatch(input, @"^(metric|stat)s\b", RegexOptions.IgnoreCase))
            {
                return BuildCommand<IMetricsService, MetricsCommand>(args, null);
            }

            if (Regex.IsMatch(input, @"^ipfs\b", RegexOptions.IgnoreCase))
            {
                return Network.Equals("ipfs", StringComparison.OrdinalIgnoreCase)
                    ? BuildCommand<IIPFSService, IpfsCommand>(args, IpfsCommand.SwitchMappings)
                    : throw new InvalidOperationException($"Set Network and ApiKey to ipfs");
            }

            return new ShowInvalidArgumentCommand(input);
        }

        private static ICommand BuildCommand<TService, TCommand>(string[] args, Dictionary<string, string> switchMappings = null)
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
                _ = builder.AddUserSecrets("f8c41451-ff2e-4834-af6f-5a563a133d25");
            }

            var config = builder.Build();

            if (isDevelopment)
            {
                // managed in Blockfrost.Cli secret store
                ApiKey = config[$"CliSettings:ApiKey:{Network}"];
            }

            var provider = new ServiceCollection()
                .AddBlockfrost(Network, ApiKey)
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

            try
            {
                return provider.GetRequiredService<TCommand>();
            }
            catch (Exception)
            {
                // invalid arguments
                return new ShowCommandHelpCommand<TCommand>();
            }
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
