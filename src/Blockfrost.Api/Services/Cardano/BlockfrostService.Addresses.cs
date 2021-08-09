#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService
    {
        /// <summary>Transaction stake addresses certificates</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxStakeAddress>> Stakes3Async(string hash)
        {
            return Stakes3Async(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction stake addresses certificates</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxStakeAddress>> Stakes3Async(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
                throw new System.ArgumentNullException("hash");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/stakes");
            urlBuilder_.Replace("{hash}", System.Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxStakeAddress>>(urlBuilder_, cancellationToken);
          
        }


        /// <summary>Specific address</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AddressResponse> AddressesAsync(string address)
        {
            return AddressesAsync(address, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific address</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AddressResponse> AddressesAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AddressResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Address details</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AddressContentTotal> TotalAsync(string address)
        {
            return TotalAsync(address, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Address details</summary>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AddressContentTotal> TotalAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/total");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AddressContentTotal>(urlBuilder_, cancellationToken);
         
        } /// <summary>Address UTXOs</summary>
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
            return UtxosAllAsync(address, count, page, order, CancellationToken.None);
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
        public async Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/utxos?");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AddressUTxOResponse>>(urlBuilder_, cancellationToken);
        
        } /// <summary>Address transactions</summary>
          /// <param name="address">Bech32 address.</param>
          /// <param name="count">The number of transactions per page.</param>
          /// <param name="page">The page number for listing the results.</param>
          /// <param name="order">The ordering of items from the point of view of the blockchain,
          /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
          /// <returns>Return the address content</returns>
          /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete]
        public Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order)
        {
            return TxsAll3Async(address, count, page, order, CancellationToken.None);
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
        [System.Obsolete]
        public async Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/txs?");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
            
        }
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
            return TransactionsAsync(address, count, page, order, from, to, CancellationToken.None);
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
        public async Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/addresses/{address}/transactions?");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (from != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("from") + "=").Append(System.Uri.EscapeDataString(ConvertToString(from, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (to != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("to") + "=").Append(System.Uri.EscapeDataString(ConvertToString(to, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AddressTransactionResponse>>(urlBuilder_, cancellationToken);
           
        }
    }
}


#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016