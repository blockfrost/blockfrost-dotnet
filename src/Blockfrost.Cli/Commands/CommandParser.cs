// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Cli.Commands
{

    public static class CommandParser
    {
        public static ICommand ParseArgsToCommand(string[] args)
        {
            if (args.Length == 0 || IsHelpOption(args[0]))
            {
                return new ShowBaseHelpCommand();
            }

            if (IsVersionOption(args[0]))
            {
                return new ShowVersionCommand();
            }

            string flattenedArgs = string.Join(' ', args);
            return flattenedArgs.StartsWith("address", StringComparison.OrdinalIgnoreCase)
                ? BuildCommand<AddressCommand>(args)
                : flattenedArgs.StartsWith("health", StringComparison.OrdinalIgnoreCase)
                ? BuildCommand<HealthCommand>(args)
                : new ShowInvalidArgumentCommand(flattenedArgs);
        }

        private static ICommand BuildCommand<T>(string[] args)
            where T : class, ICommand
        {
            string env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            bool isDevelopment = string.IsNullOrEmpty(env) || env.ToLower(System.Globalization.CultureInfo.InvariantCulture) == "development";

            var builder = new ConfigurationBuilder();
            _ = builder.AddEnvironmentVariables().AddCommandLine(args);

            //only add secrets in development
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
                .AddSingleton(_ => new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault })
                .AddSingleton<T>()
                .AddBlockfrost(network, apikey)
                .BuildServiceProvider();

            return provider.GetRequiredService<T>();
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
