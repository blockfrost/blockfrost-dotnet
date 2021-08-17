using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface ILedgerService : IBlockfrostService
    {
        Task<GenesisContentResponse> GenesisAsync();

        Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken);
    }
}
