using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface IPoolService : IBlockfrostService
    {
        Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<PoolMetadataResponse> MetadataAsync(string pool_id);

        Task<PoolMetadataResponse> MetadataAsync(string pool_id, CancellationToken cancellationToken);

        Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<PoolResponse> PoolsAsync(string pool_id);

        Task<PoolResponse> PoolsAsync(string pool_id, CancellationToken cancellationToken);

        Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id);

        Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id, CancellationToken cancellationToken);

        Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);
    }
}
