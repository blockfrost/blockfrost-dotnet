using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Cli.Commands.Cardano.Accounts
{
    public class AccountsCommand : BlockfrostServiceCommand<IAccountsService>
    {
        public static readonly Dictionary<string, string> SwitchMappings = new()
        {
            { "--stake-addr", "StakeAddress" }
        };

        [Parameter(Position = 1, Required = true)]
        public string StakeAddress { get; set; }
        public override async ValueTask<CommandResult> ExecuteAsync(CancellationToken ct)
        {
            var response = await Service.GetAccountsAsync(StakeAddress, cancellationToken: ct);
            return await Success(response);
        }
    }
}
