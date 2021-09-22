using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial class PoolService : ABlockfrostService, IPoolService
    {
        public PoolService(HttpClient httpClient) : base(httpClient)
        {
        }

        public IPoolsService V1 { get; set; }

        public PoolService(IPoolsService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }

        /// <summary>Stake pool blocks</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool block list</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return BlocksAll3Async(pool_id, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake pool blocks</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool block list</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}/blocks?");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
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

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }

        /// <summary>Stake pool delegators</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool delegations.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return DelegatorsAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake pool delegators</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool delegations.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}/delegators?");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
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

            return await SendGetRequestAsync<ICollection<PoolDelegatorResponse>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }

        /// <summary>Stake pool history</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return History2Async(pool_id, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake pool history</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}/history?");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
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

            return await SendGetRequestAsync<ICollection<PoolHistoryResponse>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }

        /// <summary>Stake pool metadata</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool metadata content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<PoolMetadataResponse> MetadataAsync(string pool_id)
        {
            return MetadataAsync(pool_id, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake pool metadata</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool metadata content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<PoolMetadataResponse> MetadataAsync(string pool_id, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}/metadata");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<PoolMetadataResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>List of stake pools</summary>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the list of pools.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order)
        {
            return PoolsAllAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>List of stake pools</summary>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the list of pools.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools?");
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
        }

        /// <summary>Specific stake pool</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<PoolResponse> PoolsAsync(string pool_id)
        {
            return PoolsAsync(pool_id, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific stake pool</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<PoolResponse> PoolsAsync(string pool_id, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<PoolResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Stake pool relays</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool relays information content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id)
        {
            return RelaysAsync(pool_id, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake pool relays</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool relays information content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}/relays");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<PoolRelayResponse>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }

        /// <summary>List of retired stake pools</summary>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order)
        {
            return RetiredAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>List of retired stake pools</summary>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/retired?");
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

            return await SendGetRequestAsync<ICollection<RetiredResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>List of retiring stake pools</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order)
        {
            return RetiringAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>List of retiring stake pools</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/retiring?");
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

            return await SendGetRequestAsync<ICollection<RetiredResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Stake pool updates</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool updates history</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return UpdatesAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake pool updates</summary>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool updates history</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/pools/{pool_id}/updates?");
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
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

            return await SendGetRequestAsync<ICollection<PoolUpdateResponse>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }
    }
}
