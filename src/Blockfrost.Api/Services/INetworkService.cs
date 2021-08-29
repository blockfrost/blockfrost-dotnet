using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface INetworkService
    {
        Task<NetworkResponse> NetworkAsync();

        Task<NetworkResponse> NetworkAsync(CancellationToken cancellationToken);
    }
}
