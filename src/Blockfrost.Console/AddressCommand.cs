using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;
using Blockfrost.Api.Services;

namespace Blockfrost.ConsoleTool
{
    public class HealthCommand : ICommand
    {
        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {

            try
            {
                var service = new BlockfrostService();
                var result = CommandResult.Success($"{service.GetHealth()}");
                return ValueTask.FromResult(result);
            }
            catch (Exception ex)
            {
                return ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
    public class AddressCommand : ICommand
    {
        public const int MaxCount = 100;
        public const int DefaultCount = 10;
        public const string DefaultAddressType = "Shelley";

        public string Address { get; set; } = "";
        
        public int Count { get; init; } = DefaultCount;

        public string AddressType { get; init; } = DefaultAddressType;

        public ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            if (Count > MaxCount)
            {
                return ValueTask.FromResult(CommandResult.FailureInvalidOptions(
                    $"Invalid option --count {Count} exceeded the max count of {MaxCount}"));
            }
            if (!Enum.TryParse<EAddressType>(AddressType, out var era))
            {
                return ValueTask.FromResult(CommandResult.FailureInvalidOptions(
                    $"Invalid option --type {AddressType} is not supported"));
            }

            try
            {
                var service = new BlockfrostService();
                var result = CommandResult.Success(service.GetAddress(Address, era));
                return ValueTask.FromResult(result);
            }
            catch (Exception ex)
            {
                return ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}