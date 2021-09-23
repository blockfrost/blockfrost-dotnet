using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IPoolsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
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
        Task<Models.StringCollection> GetPoolsAsync(int? count, int? page, ESortOrder? order);

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
        Task<Models.StringCollection> GetPoolsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.PoolListRetireResponseCollection> GetRetiredAsync(int? count, int? page, ESortOrder? order);

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
        Task<Models.PoolListRetireResponseCollection> GetRetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.PoolListRetireResponseCollection> GetRetiringAsync(int? count, int? page, ESortOrder? order);

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
        Task<Models.PoolListRetireResponseCollection> GetRetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.PoolResponse> GetPoolsAsync(string pool_id);

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
        Task<Models.PoolResponse> GetPoolsAsync(string pool_id, CancellationToken cancellationToken);
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
        Task<Models.PoolHistoryResponseCollection> GetHistoryAsync(string pool_id, int? count, int? page, ESortOrder? order);

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
        Task<Models.PoolHistoryResponseCollection> GetHistoryAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.PoolMetadataResponse> GetMetadataAsync(string pool_id);

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
        Task<Models.PoolMetadataResponse> GetMetadataAsync(string pool_id, CancellationToken cancellationToken);
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
        Task<Models.PoolRelaysResponseCollection> GetRelaysAsync(string pool_id);

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
        Task<Models.PoolRelaysResponseCollection> GetRelaysAsync(string pool_id, CancellationToken cancellationToken);
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
        Task<Models.PoolDelegatorsResponseCollection> GetDelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order);

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
        Task<Models.PoolDelegatorsResponseCollection> GetDelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.StringCollection> GetBlocksAsync(string pool_id, int? count, int? page, ESortOrder? order);

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
        Task<Models.StringCollection> GetBlocksAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.PoolUpdatesResponseCollection> GetUpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order);

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
        Task<Models.PoolUpdatesResponseCollection> GetUpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}

