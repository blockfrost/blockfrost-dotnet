using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class AddressesService : ABlockfrostService, IAddressesService
    {
        /// <summary> 
        ///     Initializes a new <see cref="AddressesService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses">Cardano » Addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        public AddressesService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

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
        public Task<Models.AddressContentResponse> GetAddressesAsync(string address)
        {
            return GetAddressesAsync(address, CancellationToken.None);
        }

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
        public async Task<Models.AddressContentResponse> GetAddressesAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var builder = GetUrlBuilder("/addresses/{address}");
            _ = builder.SetRouteParameter("{address}", address);

            return await SendGetRequestAsync<Models.AddressContentResponse>(builder, cancellationToken);
        }
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
        public Task<Models.AddressContentTotalResponse> GetTotalAsync(string address)
        {
            return GetTotalAsync(address, CancellationToken.None);
        }

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
        public async Task<Models.AddressContentTotalResponse> GetTotalAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var builder = GetUrlBuilder("/addresses/{address}/total");
            _ = builder.SetRouteParameter("{address}", address);

            return await SendGetRequestAsync<Models.AddressContentTotalResponse>(builder, cancellationToken);
        }
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
        public Task<Models.AddressUtxoContentResponseCollection> GetUtxosAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return GetUtxosAsync(address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AddressUtxoContentResponseCollection> GetUtxosAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var builder = GetUrlBuilder("/addresses/{address}/utxos");
            _ = builder.SetRouteParameter("{address}", address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AddressUtxoContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.StringCollection> GetTxsAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return GetTxsAsync(address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.StringCollection> GetTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var builder = GetUrlBuilder("/addresses/{address}/txs");
            _ = builder.SetRouteParameter("{address}", address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AddressTransactionsContentResponseCollection> GetTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to)
        {
            return GetTransactionsAsync(address, count, page, order, from, to, CancellationToken.None);
        }

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
        public async Task<Models.AddressTransactionsContentResponseCollection> GetTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var builder = GetUrlBuilder("/addresses/{address}/transactions");
            _ = builder.SetRouteParameter("{address}", address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            _ = builder.AppendQueryParameter(nameof(from), from);
            _ = builder.AppendQueryParameter(nameof(to), to);
            builder.Length--;

            return await SendGetRequestAsync<Models.AddressTransactionsContentResponseCollection>(builder, cancellationToken);
        }
    }
}

