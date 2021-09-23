using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

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
        [Get("/txs/{hash}", "0.1.27")]
        Task<Models.TxContentResponse> GetTxsAsync(string hash);

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
        [Get("/txs/{hash}", "0.1.27")]
        Task<Models.TxContentResponse> GetTxsAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/utxos", "0.1.27")]
        Task<Models.TxContentUtxoResponse> GetTxsUtxosAsync(string hash);

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
        [Get("/txs/{hash}/utxos", "0.1.27")]
        Task<Models.TxContentUtxoResponse> GetTxsUtxosAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/stakes", "0.1.27")]
        Task<Models.TxContentStakeAddrResponseCollection> GetTxsStakesAsync(string hash);

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
        [Get("/txs/{hash}/stakes", "0.1.27")]
        Task<Models.TxContentStakeAddrResponseCollection> GetTxsStakesAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/delegations", "0.1.27")]
        Task<Models.TxContentDelegationsResponseCollection> GetTxsDelegationsAsync(string hash);

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
        [Get("/txs/{hash}/delegations", "0.1.27")]
        Task<Models.TxContentDelegationsResponseCollection> GetTxsDelegationsAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/withdrawals", "0.1.27")]
        Task<Models.TxContentWithdrawalsResponseCollection> GetTxsWithdrawalsAsync(string hash);

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
        [Get("/txs/{hash}/withdrawals", "0.1.27")]
        Task<Models.TxContentWithdrawalsResponseCollection> GetTxsWithdrawalsAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/mirs", "0.1.27")]
        Task<Models.TxContentMirsResponseCollection> GetTxsMirsAsync(string hash);

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
        [Get("/txs/{hash}/mirs", "0.1.27")]
        Task<Models.TxContentMirsResponseCollection> GetTxsMirsAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/pool_updates", "0.1.27")]
        Task<Models.TxContentPoolCertsResponseCollection> GetTxsPoolUpdatesAsync(string hash);

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
        [Get("/txs/{hash}/pool_updates", "0.1.27")]
        Task<Models.TxContentPoolCertsResponseCollection> GetTxsPoolUpdatesAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/pool_retires", "0.1.27")]
        Task<Models.TxContentPoolRetiresResponseCollection> GetTxsPoolRetiresAsync(string hash);

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
        [Get("/txs/{hash}/pool_retires", "0.1.27")]
        Task<Models.TxContentPoolRetiresResponseCollection> GetTxsPoolRetiresAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/metadata", "0.1.27")]
        Task<Models.TxContentMetadataResponseCollection> GetTxsMetadataAsync(string hash);

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
        [Get("/txs/{hash}/metadata", "0.1.27")]
        Task<Models.TxContentMetadataResponseCollection> GetTxsMetadataAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/metadata/cbor", "0.1.27")]
        Task<Models.TxContentMetadataCborResponseCollection> GetTxsMetadataCborAsync(string hash);

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
        [Get("/txs/{hash}/metadata/cbor", "0.1.27")]
        Task<Models.TxContentMetadataCborResponseCollection> GetTxsMetadataCborAsync(string hash, CancellationToken cancellationToken);
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
        [Get("/txs/{hash}/redeemers", "0.1.27")]
        Task<Models.TxContentRedeemersResponseCollection> GetTxsRedeemersAsync(string hash);

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
        [Get("/txs/{hash}/redeemers", "0.1.27")]
        Task<Models.TxContentRedeemersResponseCollection> GetTxsRedeemersAsync(string hash, CancellationToken cancellationToken);
        /// <summary>
        ///     Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.27")]
        Task<string> PostTxSubmitAsync(System.IO.Stream content);

        /// <summary>
        ///     Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.27")]
        Task<string> PostTxSubmitAsync(System.IO.Stream content, CancellationToken cancellationToken);
    }
}

