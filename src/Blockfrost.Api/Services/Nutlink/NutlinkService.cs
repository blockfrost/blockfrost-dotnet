using Blockfrost.Api.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class NutlinkService : ABlockfrostService, INutlinkService
    {
        public NutlinkService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <returns>Return the metadata about metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<NutlinkAddress> NutlinkAsync(string address)
        {
            return NutlinkAsync(address, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Return the metadata about metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<NutlinkAddress> NutlinkAsync(string address, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/nutlink/{address}");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<NutlinkAddress>(urlBuilder_, cancellationToken);
        }

        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the tickers provided by the metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count, int? page, ESortOrder? order)
        {
            return Tickers2Async(address, ticker, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the tickers provided by the metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            if (ticker == null)
                throw new System.ArgumentNullException("ticker");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/nutlink/{address}/tickers/{ticker}?");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{ticker}", System.Uri.EscapeDataString(ConvertToString(ticker, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(count), count);
            }
            if (page != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(page), page);
            }
            if (order != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(order), order);
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<NutlinkAddressTickerResponse>>(urlBuilder_, cancellationToken);
        }

        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the tickers provided by the metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page, ESortOrder? order)
        {
            return Tickers3Async(ticker, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the tickers provided by the metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (ticker == null)
                throw new System.ArgumentNullException("ticker");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/nutlink/tickers/{ticker}?");
            urlBuilder_.Replace("{ticker}", System.Uri.EscapeDataString(ConvertToString(ticker, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(count), count);
            }
            if (page != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(page), page);
            }
            if (order != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(order), order);
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<NutlinkTickersTickerResponse>>(urlBuilder_, cancellationToken);
        }

        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the tickers provided by the metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return TickersAsync(address, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the tickers provided by the metadata oracle</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (address == null)
                throw new System.ArgumentNullException("address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/nutlink/{address}/tickers?");
            urlBuilder_.Replace("{address}", System.Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(count), count);
            }
            if (page != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(page), page);
            }
            if (order != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(order), order);
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<NutlinkAddressTickersResponse>>(urlBuilder_, cancellationToken);
        }
    }
}
