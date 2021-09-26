using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class MetadataService : ABlockfrostService, IMetadataService
    {
        /// <summary> 
        ///     Initializes a new <see cref="MetadataService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata">Cardano » Metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        public MetadataService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Transaction metadata labels <c>/metadata/txs/labels</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels/get">/metadata/txs/labels</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels", "0.1.27")]
        public Task<Models.TxMetadataLabelsResponseCollection> GetTxsLabelsAsync(int? count, int? page, ESortOrder? order)
        {
            return GetTxsLabelsAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Transaction metadata labels <c>/metadata/txs/labels</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels/get">/metadata/txs/labels</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels", "0.1.27")]
        public async Task<Models.TxMetadataLabelsResponseCollection> GetTxsLabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/metadata/txs/labels");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.TxMetadataLabelsResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Transaction metadata content in JSON <c>/metadata/txs/labels/{label}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}/get">/metadata/txs/labels/{label}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}", "0.1.27")]
        public Task<Models.TxMetadataLabelJsonResponseCollection> GetTxsLabelsAsync(string label, int? count, int? page, ESortOrder? order)
        {
            return GetTxsLabelsAsync(label, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Transaction metadata content in JSON <c>/metadata/txs/labels/{label}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}/get">/metadata/txs/labels/{label}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}", "0.1.27")]
        public async Task<Models.TxMetadataLabelJsonResponseCollection> GetTxsLabelsAsync(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (label == null)
            {
                throw new System.ArgumentNullException(nameof(label));
            }

            var builder = GetUrlBuilder("/metadata/txs/labels/{label}");
            _ = builder.SetRouteParameter("{label}", label);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.TxMetadataLabelJsonResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Transaction metadata content in CBOR <c>/metadata/txs/labels/{label}/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}~1cbor/get">/metadata/txs/labels/{label}/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}/cbor", "0.1.27")]
        public Task<Models.TxMetadataLabelCborResponseCollection> GetTxsLabelsCborAsync(string label, int? count, int? page, ESortOrder? order)
        {
            return GetTxsLabelsCborAsync(label, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Transaction metadata content in CBOR <c>/metadata/txs/labels/{label}/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}~1cbor/get">/metadata/txs/labels/{label}/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}/cbor", "0.1.27")]
        public async Task<Models.TxMetadataLabelCborResponseCollection> GetTxsLabelsCborAsync(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (label == null)
            {
                throw new System.ArgumentNullException(nameof(label));
            }

            var builder = GetUrlBuilder("/metadata/txs/labels/{label}/cbor");
            _ = builder.SetRouteParameter("{label}", label);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.TxMetadataLabelCborResponseCollection>(builder, cancellationToken);
        }
    }
}

