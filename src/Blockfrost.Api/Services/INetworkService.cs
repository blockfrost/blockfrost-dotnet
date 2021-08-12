using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    internal interface INetworkService
    {
        Task<NetworkResponse> NetworkAsync();

        Task<NetworkResponse> NetworkAsync(CancellationToken cancellationToken);
    }
}
