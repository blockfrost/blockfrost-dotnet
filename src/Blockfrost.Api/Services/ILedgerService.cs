using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface ILedgerService : IBlockfrostService
    {
        Task<GenesisContentResponse> GenesisAsync();

        Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken);
    }
}
