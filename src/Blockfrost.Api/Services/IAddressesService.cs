using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IAddressesService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Specific address <c>/addresses/{address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}/get">/addresses/{address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}", "0.1.27")]
        Task<Models.AddressContentResponse> GetAddressesAsync(string address);

        /// <summary>
        ///     Specific address <c>/addresses/{address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}/get">/addresses/{address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}", "0.1.27")]
        Task<Models.AddressContentResponse> GetAddressesAsync(string address, CancellationToken cancellationToken);
        /// <summary>
        ///     Address details <c>/addresses/{address}/total</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1total/get">/addresses/{address}/total</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/total", "0.1.27")]
        Task<Models.AddressContentTotalResponse> GetTotalAsync(string address);

        /// <summary>
        ///     Address details <c>/addresses/{address}/total</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1total/get">/addresses/{address}/total</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/total", "0.1.27")]
        Task<Models.AddressContentTotalResponse> GetTotalAsync(string address, CancellationToken cancellationToken);
        /// <summary>
        ///     Address UTXOs <c>/addresses/{address}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1utxos/get">/addresses/{address}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/utxos", "0.1.27")]
        Task<Models.AddressUtxoContentResponseCollection> GetUtxosAsync(string address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Address UTXOs <c>/addresses/{address}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1utxos/get">/addresses/{address}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/utxos", "0.1.27")]
        Task<Models.AddressUtxoContentResponseCollection> GetUtxosAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Address transactions <c>/addresses/{address}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1txs/get">/addresses/{address}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of transactions per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/txs", "0.1.27")]
        Task<Models.StringCollection> GetTxsAsync(string address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Address transactions <c>/addresses/{address}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1txs/get">/addresses/{address}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of transactions per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/txs", "0.1.27")]
        Task<Models.StringCollection> GetTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Address transactions <c>/addresses/{address}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1transactions/get">/addresses/{address}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <param name="from">The block number and optionally also index from which (inclusive) to start search for results, concatenated using colon.Has to be lower than or equal to `to` parameter.</param>
        /// <param name="to">The block number and optionally also index where (inclusive) to end the search for results, concatenated using colon.Has to be higher than or equal to `from` parameter.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/transactions", "0.1.27")]
        Task<Models.AddressTransactionsContentResponseCollection> GetTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to);

        /// <summary>
        ///     Address transactions <c>/addresses/{address}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1transactions/get">/addresses/{address}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <param name="from">The block number and optionally also index from which (inclusive) to start search for results, concatenated using colon.Has to be lower than or equal to `to` parameter.</param>
        /// <param name="to">The block number and optionally also index where (inclusive) to end the search for results, concatenated using colon.Has to be higher than or equal to `from` parameter.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/transactions", "0.1.27")]
        Task<Models.AddressTransactionsContentResponseCollection> GetTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to, CancellationToken cancellationToken);
    }
}

