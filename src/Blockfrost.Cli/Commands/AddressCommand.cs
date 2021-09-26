using System;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands
{
    public class AddressCommand : ICommand
    {
        private readonly IAddressesService _service;

        public AddressCommand(IAddressesService service)
        {
            _service = service;
        }
        public static readonly int MaxCount = 100;
        public static readonly int DefaultCount = 10;
        public static readonly string DefaultAddressType = "Shelley";

        public string Address { get; set; } = "";

        public int Count { get; init; } = DefaultCount;

        public string AddressType { get; init; } = DefaultAddressType;

        public async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            if (Count > MaxCount)
            {
                return await ValueTask.FromResult(CommandResult.FailureInvalidOptions(
                    $"Invalid option --count {Count} exceeded the max count of {MaxCount}"));
            }

            if (!Enum.TryParse<EContentType>(AddressType, out _))
            {
                return await ValueTask.FromResult(CommandResult.FailureInvalidOptions(
                    $"Invalid option --type {AddressType} is not supported"));
            }

            try
            {
                var response = await _service.GetAddressesAsync(Address, ct);
                var result = CommandResult.Success($"{response}");
                return await ValueTask.FromResult(result);
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
