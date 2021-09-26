using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;

namespace Blockfrost.Api
{
    public partial class MetadataService : ABlockfrostService, IMetadataService
    {
        public MetadataService(HttpClient httpClient) : base(httpClient)
        {
        }
        public MetadataService(Services.IMetadataService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }

        public Services.IMetadataService V1 { get; set; }

        /// <summary>Transaction metadata content in CBOR</summary>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page, ESortOrder? order)
        {
            return Cbor2Async(label, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction metadata content in CBOR</summary>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (label == null)
            {
                throw new System.ArgumentNullException(nameof(label));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metadata/txs/labels/{label}/cbor?");
            _ = urlBuilder_.Replace("{label}", System.Uri.EscapeDataString(ConvertToString(label, System.Globalization.CultureInfo.InvariantCulture)));
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

            return await SendGetRequestAsync<ICollection<TxMetadataLabelCBORResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction metadata content in JSON</summary>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page, ESortOrder? order)
        {
            return Labels2Async(label, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction metadata content in JSON</summary>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (label == null)
            {
                throw new System.ArgumentNullException(nameof(label));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metadata/txs/labels/{label}?");
            _ = urlBuilder_.Replace("{label}", System.Uri.EscapeDataString(ConvertToString(label, System.Globalization.CultureInfo.InvariantCulture)));
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

            return await SendGetRequestAsync<ICollection<TxMetadataLabelJsonResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction metadata labels</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order)
        {
            return LabelsAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction metadata labels</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metadata/txs/labels?");
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

            return await SendGetRequestAsync<ICollection<TxMetadataLabelResponse>>(urlBuilder_, cancellationToken);
        }
    }
}
