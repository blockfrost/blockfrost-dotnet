using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface IAssetService : IBlockfrostService
    {
        Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order);

        Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<AssetResponse> AssetsAsync(string asset);

        Task<AssetResponse> AssetsAsync(string asset, CancellationToken cancellationToken);

        Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order);

        Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}
