using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial class AddressService : ABlockfrostService, IAddressService
    {
        public AddressService(HttpClient httpClient) : base(httpClient)
        {
        }

        public AddressService(IAddressesService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }

        public IAddressesService V1 { get; set; }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific address</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AddressResponse> AddressAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}");
            _ = urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AddressResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Specific address</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AddressResponse> AddressesAsync(string address)
        {
            return AddressAsync(address, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Address details</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AddressContentTotal> AddressTotalAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/total");
            _ = urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AddressContentTotal>(urlBuilder_, cancellationToken);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Address transactions</summary>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <param name="from">The block number and optionally also index from which (inclusive) to start search for results, concatenated using colon.
        /// <br/>Has to be lower than or equal to `to` parameter.</param>
        /// <param name="to">The block number and optionally also index where (inclusive) to end the search for results, concatenated using colon.
        /// <br/>Has to be higher than or equal to `from` parameter.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AddressTransactionResponse>> AddressTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/transactions?");
            _ = urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
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

            if (from != null)
            {
                _ = urlBuilder_.Append(System.Uri.EscapeDataString(nameof(from)) + "=").Append(System.Uri.EscapeDataString(ConvertToString(from, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
            }

            if (to != null)
            {
                _ = urlBuilder_.Append(System.Uri.EscapeDataString(nameof(to)) + "=").Append(System.Uri.EscapeDataString(ConvertToString(to, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AddressTransactionResponse>>(urlBuilder_, cancellationToken);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Address transactions</summary>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of transactions per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete("No longer supported by blockfrost and may be removed in future releases")]
        public async Task<ICollection<string>> AddressTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/txs?");
            _ = urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
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

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Address UTXOs</summary>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.
        /// <br/>The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AddressUTxOResponse>> AddressUtxoAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
            {
                throw new System.ArgumentNullException(nameof(address));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/utxos?");
            _ = urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter("page", page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AddressUTxOResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Address details</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AddressContentTotal> TotalAsync(string address)
        {
            return AddressTotalAsync(address, CancellationToken.None);
        }

        /// <summary>Address UTXOs</summary>

        /// <summary>Address transactions</summary>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <param name="from">The block number and optionally also index from which (inclusive) to start search for results, concatenated using colon.
        /// <br/>Has to be lower than or equal to `to` parameter.</param>
        /// <param name="to">The block number and optionally also index where (inclusive) to end the search for results, concatenated using colon.
        /// <br/>Has to be higher than or equal to `from` parameter.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to)
        {
            return AddressTransactionsAsync(address, count, page, order, from, to, CancellationToken.None);
        }

        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of transactions per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete("No longer supported and may be removed in future releases")]
        public Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order)
        {
            return AddressTxsAsync(address, count, page, order, CancellationToken.None);
        }

        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.
        /// <br/>The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return AddressUtxoAsync(address, count, page, order, CancellationToken.None);
        }

        /// <summary>Address transactions</summary>
    }
}
