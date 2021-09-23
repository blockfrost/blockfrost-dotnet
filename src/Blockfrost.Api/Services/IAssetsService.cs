using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IAssetsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
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
        Task<Models.AssetsResponseCollection> GetAssetsAsync(int? count, int? page, ESortOrder? order);

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
        Task<Models.AssetsResponseCollection> GetAssetsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.AssetResponse> GetAssetsAsync(string asset);

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
        Task<Models.AssetResponse> GetAssetsAsync(string asset, CancellationToken cancellationToken);
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
        Task<Models.AssetHistoryResponseCollection> GetHistoryAsync(string asset, int? count, int? page, ESortOrder? order);

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
        Task<Models.AssetHistoryResponseCollection> GetHistoryAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.StringCollection> GetTxsAsync(string asset, int? count, int? page, ESortOrder? order);

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
        Task<Models.StringCollection> GetTxsAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.AssetTransactionsResponseCollection> GetTransactionsAsync(string asset, int? count, int? page, ESortOrder? order);

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
        Task<Models.AssetTransactionsResponseCollection> GetTransactionsAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.AssetAddressesResponseCollection> GetAddressesAsync(string asset, int? count, int? page, ESortOrder? order);

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
        Task<Models.AssetAddressesResponseCollection> GetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.AssetPolicyResponseCollection> GetPolicyAsync(string policy_id, int? count, int? page, ESortOrder? order);

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
        Task<Models.AssetPolicyResponseCollection> GetPolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}

