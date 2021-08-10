using Microsoft.Extensions.Configuration;

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
            if (flattenedArgs.StartsWith("blockfrost address"))
            {
                return BuildCommand<AddressCommand>(args);
            }
            
            if (flattenedArgs.StartsWith("blockfrost health"))
            {
                return BuildCommand<HealthCommand>(args);
            }

            return new ShowInvalidArgumentCommand(flattenedArgs);
        }

        private static ICommand BuildCommand<T>(string[] args)
            where T : ICommand
        {
            var command = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build()
                .Get<T>();

            return command;
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