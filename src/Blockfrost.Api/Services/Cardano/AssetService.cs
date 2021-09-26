using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial class AssetService : ABlockfrostService, IAssetService
    {
        public AssetService(HttpClient httpClient) : base(httpClient)
        {
        }
        public AssetService(IAssetsService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }
        public IAssetsService V1 { get; set; }

        /// <summary>Assets</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order)
        {
            return AssetsAll2Async(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Assets</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets?");
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetsResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Specific asset</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AssetResponse> AssetsAsync(string asset)
        {
            return AssetsAsync(asset, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific asset</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AssetResponse> AssetsAsync(string asset, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}");
            _ = urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AssetResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Asset addresses</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return GetAssetAddressesAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset addresses</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/addresses?");
            _ = urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetAddressesResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Asset history</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return History3Async(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset history</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/history?");
            _ = urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetHistoryResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Assets of a specific policy</summary>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order)
        {
            return PolicyAsync(policy_id, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Assets of a specific policy</summary>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (policy_id == null)
            {
                throw new System.ArgumentNullException(nameof(policy_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/policy/{policy_id}?");
            _ = urlBuilder_.Replace("{policy_id}", System.Uri.EscapeDataString(ConvertToString(policy_id, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetPolicyResponse>>(urlBuilder_, cancellationToken);
        }

        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Transactions2Async(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset transactions</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/transactions?");
            _ = urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetTransactionResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Asset transactions</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete("No longer supported and may be removed")]
        public Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return TxsAll4Async(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset transactions</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete("No longer supported and may be removed")]
        public async Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/txs?");
            _ = urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
        }/// <summary>Asset transactions</summary>
    }
}
