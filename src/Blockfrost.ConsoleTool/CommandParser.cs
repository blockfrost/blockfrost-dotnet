using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blockfrost.ConsoleTool
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

            var flattenedArgs = string.Join(' ', args);
            if (flattenedArgs.StartsWith("address"))
            {
                return BuildCommand<AddressCommand>(args);
            }
            
            if (flattenedArgs.StartsWith("health"))
            {
                return BuildCommand<HealthCommand>(args);
            }

            return new ShowInvalidArgumentCommand(flattenedArgs);
        }

        private static ICommand BuildCommand<T>(string[] args)
            where T : class, ICommand 
        {
            var env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(env) || env.ToLower() == "development";

            var builder = new ConfigurationBuilder();
            builder.AddEnvironmentVariables().AddCommandLine(args);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<CliSettings>();
            }

            var network = Environment.GetEnvironmentVariable("BFCLI_NETWORK");
            var apikey = Environment.GetEnvironmentVariable("BFCLI_APIKEY");

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
            return arg == "help" || arg == "-h" || arg == "--help";
        }

        private static bool IsVersionOption(string arg)
        {
            return arg == "version" || arg == "-v" || arg == "--version";
        }
    }
}