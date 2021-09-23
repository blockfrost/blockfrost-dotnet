using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class PoolsService : ABlockfrostService, IPoolsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="PoolsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools">Cardano » Pools</seealso> on docs.blockfrost.io
        /// </remarks>
        public PoolsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     List of stake pools <c>/pools</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools/get">/pools</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the list of pools.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools", "0.1.27")]
        public Task<Models.StringCollection> GetPoolsAsync(int? count, int? page, ESortOrder? order)
        {
            return GetPoolsAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     List of stake pools <c>/pools</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools/get">/pools</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the list of pools.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools", "0.1.27")]
        public async Task<Models.StringCollection> GetPoolsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/pools");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     List of retired stake pools <c>/pools/retired</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retired/get">/pools/retired</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retired", "0.1.27")]
        public Task<Models.PoolListRetireResponseCollection> GetRetiredAsync(int? count, int? page, ESortOrder? order)
        {
            return GetRetiredAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     List of retired stake pools <c>/pools/retired</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retired/get">/pools/retired</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retired", "0.1.27")]
        public async Task<Models.PoolListRetireResponseCollection> GetRetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/pools/retired");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.PoolListRetireResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     List of retiring stake pools <c>/pools/retiring</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retiring/get">/pools/retiring</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retiring", "0.1.27")]
        public Task<Models.PoolListRetireResponseCollection> GetRetiringAsync(int? count, int? page, ESortOrder? order)
        {
            return GetRetiringAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     List of retiring stake pools <c>/pools/retiring</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retiring/get">/pools/retiring</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retiring", "0.1.27")]
        public async Task<Models.PoolListRetireResponseCollection> GetRetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/pools/retiring");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.PoolListRetireResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Specific stake pool <c>/pools/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}/get">/pools/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}", "0.1.27")]
        public Task<Models.PoolResponse> GetPoolsAsync(string pool_id)
        {
            return GetPoolsAsync(pool_id, CancellationToken.None);
        }

        /// <summary>
        ///     Specific stake pool <c>/pools/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}/get">/pools/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}", "0.1.27")]
        public async Task<Models.PoolResponse> GetPoolsAsync(string pool_id, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);

            return await SendGetRequestAsync<Models.PoolResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Stake pool history <c>/pools/{pool_id}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1history/get">/pools/{pool_id}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/history", "0.1.27")]
        public Task<Models.PoolHistoryResponseCollection> GetHistoryAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return GetHistoryAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Stake pool history <c>/pools/{pool_id}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1history/get">/pools/{pool_id}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/history", "0.1.27")]
        public async Task<Models.PoolHistoryResponseCollection> GetHistoryAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}/history");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.PoolHistoryResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Stake pool metadata <c>/pools/{pool_id}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1metadata/get">/pools/{pool_id}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool metadata content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/metadata", "0.1.27")]
        public Task<Models.PoolMetadataResponse> GetMetadataAsync(string pool_id)
        {
            return GetMetadataAsync(pool_id, CancellationToken.None);
        }

        /// <summary>
        ///     Stake pool metadata <c>/pools/{pool_id}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1metadata/get">/pools/{pool_id}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool metadata content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/metadata", "0.1.27")]
        public async Task<Models.PoolMetadataResponse> GetMetadataAsync(string pool_id, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}/metadata");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);

            return await SendGetRequestAsync<Models.PoolMetadataResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Stake pool relays <c>/pools/{pool_id}/relays</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1relays/get">/pools/{pool_id}/relays</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool relays information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/relays", "0.1.27")]
        public Task<Models.PoolRelaysResponseCollection> GetRelaysAsync(string pool_id)
        {
            return GetRelaysAsync(pool_id, CancellationToken.None);
        }

        /// <summary>
        ///     Stake pool relays <c>/pools/{pool_id}/relays</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1relays/get">/pools/{pool_id}/relays</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool relays information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/relays", "0.1.27")]
        public async Task<Models.PoolRelaysResponseCollection> GetRelaysAsync(string pool_id, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}/relays");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);

            return await SendGetRequestAsync<Models.PoolRelaysResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Stake pool delegators <c>/pools/{pool_id}/delegators</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1delegators/get">/pools/{pool_id}/delegators</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool delegations.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/delegators", "0.1.27")]
        public Task<Models.PoolDelegatorsResponseCollection> GetDelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return GetDelegatorsAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Stake pool delegators <c>/pools/{pool_id}/delegators</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1delegators/get">/pools/{pool_id}/delegators</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool delegations.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/delegators", "0.1.27")]
        public async Task<Models.PoolDelegatorsResponseCollection> GetDelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}/delegators");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.PoolDelegatorsResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Stake pool blocks <c>/pools/{pool_id}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1blocks/get">/pools/{pool_id}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool block list</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/blocks", "0.1.27")]
        public Task<Models.StringCollection> GetBlocksAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return GetBlocksAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Stake pool blocks <c>/pools/{pool_id}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1blocks/get">/pools/{pool_id}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool block list</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/blocks", "0.1.27")]
        public async Task<Models.StringCollection> GetBlocksAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}/blocks");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Stake pool updates <c>/pools/{pool_id}/updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1updates/get">/pools/{pool_id}/updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool updates history</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/updates", "0.1.27")]
        public Task<Models.PoolUpdatesResponseCollection> GetUpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return GetUpdatesAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Stake pool updates <c>/pools/{pool_id}/updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1updates/get">/pools/{pool_id}/updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool updates history</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/updates", "0.1.27")]
        public async Task<Models.PoolUpdatesResponseCollection> GetUpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/pools/{pool_id}/updates");
            _ = builder.SetRouteParameter("{pool_id}", pool_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.PoolUpdatesResponseCollection>(builder, cancellationToken);
        }
    }
}

