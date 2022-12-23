using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial interface ITransactionsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Specific transaction <c>/txs/{hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}/get">/txs/{hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}", "0.1.28")]
        Task<Models.TxContentResponse> GetAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction UTXOs <c>/txs/{hash}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1utxos/get">/txs/{hash}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/utxos", "0.1.28")]
        Task<Models.TxContentUtxoResponse> GetUtxosAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction stake addresses certificates <c>/txs/{hash}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1stakes/get">/txs/{hash}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/stakes", "0.1.28")]
        Task<Models.TxContentStakeAddrResponseCollection> GetStakesAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction delegation certificates <c>/txs/{hash}/delegations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1delegations/get">/txs/{hash}/delegations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/delegations", "0.1.28")]
        Task<Models.TxContentDelegationsResponseCollection> GetDelegationsAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction withdrawal <c>/txs/{hash}/withdrawals</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1withdrawals/get">/txs/{hash}/withdrawals</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/withdrawals", "0.1.28")]
        Task<Models.TxContentWithdrawalsResponseCollection> GetWithdrawalsAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction MIRs <c>/txs/{hash}/mirs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1mirs/get">/txs/{hash}/mirs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/mirs", "0.1.28")]
        Task<Models.TxContentMirsResponseCollection> GetMirsAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction stake pool registration and update certificates <c>/txs/{hash}/pool_updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1pool_updates/get">/txs/{hash}/pool_updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/pool_updates", "0.1.28")]
        Task<Models.TxContentPoolCertsResponseCollection> GetPoolUpdatesAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction stake pool retirement certificates <c>/txs/{hash}/pool_retires</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1pool_retires/get">/txs/{hash}/pool_retires</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/pool_retires", "0.1.28")]
        Task<Models.TxContentPoolRetiresResponseCollection> GetPoolRetiresAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction metadata <c>/txs/{hash}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1metadata/get">/txs/{hash}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/metadata", "0.1.28")]
        Task<Models.TxContentMetadataResponseCollection> GetMetadataAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction metadata in CBOR <c>/txs/{hash}/metadata/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1metadata~1cbor/get">/txs/{hash}/metadata/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/metadata/cbor", "0.1.28")]
        Task<Models.TxContentMetadataCborResponseCollection> GetMetadataCborAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Transaction redeemers <c>/txs/{hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1redeemers/get">/txs/{hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about redeemers within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/redeemers", "0.1.28")]
        Task<Models.TxContentRedeemersResponseCollection> GetRedeemersAsync(string hash, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.28")]
        Task<string> PostTxSubmitAsync(System.IO.Stream content);

        /// <summary>
        ///     Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.28")]
        Task<string> PostTxSubmitAsync(System.IO.Stream content, CancellationToken cancellationToken);
    }
}

