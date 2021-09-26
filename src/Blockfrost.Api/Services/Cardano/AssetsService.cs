using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class AssetsService : ABlockfrostService, IAssetsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="AssetsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets">Cardano » Assets</seealso> on docs.blockfrost.io
        /// </remarks>
        public AssetsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Assets <c>/assets</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets/get">/assets</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets", "0.1.27")]
        public Task<Models.AssetsResponseCollection> GetAssetsAsync(int? count, int? page, ESortOrder? order)
        {
            return GetAssetsAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Assets <c>/assets</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets/get">/assets</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets", "0.1.27")]
        public async Task<Models.AssetsResponseCollection> GetAssetsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/assets");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AssetsResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Specific asset <c>/assets/{asset}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}/get">/assets/{asset}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}", "0.1.27")]
        public Task<Models.AssetResponse> GetAssetsAsync(string asset)
        {
            return GetAssetsAsync(asset, CancellationToken.None);
        }

        /// <summary>
        ///     Specific asset <c>/assets/{asset}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}/get">/assets/{asset}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}", "0.1.27")]
        public async Task<Models.AssetResponse> GetAssetsAsync(string asset, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var builder = GetUrlBuilder("/assets/{asset}");
            _ = builder.SetRouteParameter("{asset}", asset);

            return await SendGetRequestAsync<Models.AssetResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Asset history <c>/assets/{asset}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1history/get">/assets/{asset}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/history", "0.1.27")]
        public Task<Models.AssetHistoryResponseCollection> GetHistoryAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return GetHistoryAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Asset history <c>/assets/{asset}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1history/get">/assets/{asset}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/history", "0.1.27")]
        public async Task<Models.AssetHistoryResponseCollection> GetHistoryAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var builder = GetUrlBuilder("/assets/{asset}/history");
            _ = builder.SetRouteParameter("{asset}", asset);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AssetHistoryResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Asset transactions <c>/assets/{asset}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1txs/get">/assets/{asset}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/txs", "0.1.27")]
        public Task<Models.StringCollection> GetTxsAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return GetTxsAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Asset transactions <c>/assets/{asset}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1txs/get">/assets/{asset}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/txs", "0.1.27")]
        public async Task<Models.StringCollection> GetTxsAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var builder = GetUrlBuilder("/assets/{asset}/txs");
            _ = builder.SetRouteParameter("{asset}", asset);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Asset transactions <c>/assets/{asset}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1transactions/get">/assets/{asset}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/transactions", "0.1.27")]
        public Task<Models.AssetTransactionsResponseCollection> GetTransactionsAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return GetTransactionsAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Asset transactions <c>/assets/{asset}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1transactions/get">/assets/{asset}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/transactions", "0.1.27")]
        public async Task<Models.AssetTransactionsResponseCollection> GetTransactionsAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var builder = GetUrlBuilder("/assets/{asset}/transactions");
            _ = builder.SetRouteParameter("{asset}", asset);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AssetTransactionsResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Asset addresses <c>/assets/{asset}/addresses</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1addresses/get">/assets/{asset}/addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/addresses", "0.1.27")]
        public Task<Models.AssetAddressesResponseCollection> GetAddressesAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return GetAddressesAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Asset addresses <c>/assets/{asset}/addresses</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1addresses/get">/assets/{asset}/addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/addresses", "0.1.27")]
        public async Task<Models.AssetAddressesResponseCollection> GetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
            {
                throw new System.ArgumentNullException(nameof(asset));
            }

            var builder = GetUrlBuilder("/assets/{asset}/addresses");
            _ = builder.SetRouteParameter("{asset}", asset);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AssetAddressesResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Assets of a specific policy <c>/assets/policy/{policy_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1policy~1{policy_id}/get">/assets/policy/{policy_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/policy/{policy_id}", "0.1.27")]
        public Task<Models.AssetPolicyResponseCollection> GetPolicyAsync(string policy_id, int? count, int? page, ESortOrder? order)
        {
            return GetPolicyAsync(policy_id, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Assets of a specific policy <c>/assets/policy/{policy_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1policy~1{policy_id}/get">/assets/policy/{policy_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/policy/{policy_id}", "0.1.27")]
        public async Task<Models.AssetPolicyResponseCollection> GetPolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (policy_id == null)
            {
                throw new System.ArgumentNullException(nameof(policy_id));
            }

            var builder = GetUrlBuilder("/assets/policy/{policy_id}");
            _ = builder.SetRouteParameter("{policy_id}", policy_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AssetPolicyResponseCollection>(builder, cancellationToken);
        }
    }
}

