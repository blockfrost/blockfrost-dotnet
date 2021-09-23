using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IMetadataService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
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
        Task<Models.TxMetadataLabelsResponseCollection> GetTxsLabelsAsync(int? count, int? page, ESortOrder? order);

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
        Task<Models.TxMetadataLabelsResponseCollection> GetTxsLabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.TxMetadataLabelJsonResponseCollection> GetTxsLabelsAsync(string label, int? count, int? page, ESortOrder? order);

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
        Task<Models.TxMetadataLabelJsonResponseCollection> GetTxsLabelsAsync(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.TxMetadataLabelCborResponseCollection> GetTxsLabelsCborAsync(string label, int? count, int? page, ESortOrder? order);

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
        Task<Models.TxMetadataLabelCborResponseCollection> GetTxsLabelsCborAsync(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}

