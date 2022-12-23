using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Ipfs
{
    public class IpfsCommand : BlockfrostServiceCommand<IIPFSService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--path", "ipfspath" },
            { "--ipfspath", "ipfspath" },
            { "--cid", "ipfspath" },
        };

        [Parameter(Position = 2, Required = false)]
        public string IpfsPath { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            try
            {
                if (IsSubcommand("pins"))
                {
                    if (string.IsNullOrEmpty(IpfsPath))
                    {
                        var result = await Service.Pins.GetPinListAsync(Count, Page, Order, ct);
                        return await Success(result);
                    }
                }
                return await new ShowCommandHelpCommand<IpfsCommand>().ExecuteAsync(ct);
            }
            catch (Exception ex)
            {
                return await ValueTask.FromResult(
                    CommandResult.FailureUnhandledException("Unexpected error", ex));
            }
        }
    }
}
