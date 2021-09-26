using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class TransactionsService : ABlockfrostService, ITransactionsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="TransactionsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions">Cardano » Transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        public TransactionsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

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
        public Task<Models.TxContentResponse> GetTxsAsync(string hash)
        {
            return GetTxsAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentResponse> GetTxsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentResponse>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentUtxoResponse> GetTxsUtxosAsync(string hash)
        {
            return GetTxsUtxosAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentUtxoResponse> GetTxsUtxosAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/utxos");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentUtxoResponse>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentStakeAddrResponseCollection> GetTxsStakesAsync(string hash)
        {
            return GetTxsStakesAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentStakeAddrResponseCollection> GetTxsStakesAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/stakes");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentStakeAddrResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentDelegationsResponseCollection> GetTxsDelegationsAsync(string hash)
        {
            return GetTxsDelegationsAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentDelegationsResponseCollection> GetTxsDelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/delegations");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentDelegationsResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentWithdrawalsResponseCollection> GetTxsWithdrawalsAsync(string hash)
        {
            return GetTxsWithdrawalsAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentWithdrawalsResponseCollection> GetTxsWithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/withdrawals");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentWithdrawalsResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentMirsResponseCollection> GetTxsMirsAsync(string hash)
        {
            return GetTxsMirsAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentMirsResponseCollection> GetTxsMirsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/mirs");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentMirsResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentPoolCertsResponseCollection> GetTxsPoolUpdatesAsync(string hash)
        {
            return GetTxsPoolUpdatesAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentPoolCertsResponseCollection> GetTxsPoolUpdatesAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/pool_updates");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentPoolCertsResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentPoolRetiresResponseCollection> GetTxsPoolRetiresAsync(string hash)
        {
            return GetTxsPoolRetiresAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentPoolRetiresResponseCollection> GetTxsPoolRetiresAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/pool_retires");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentPoolRetiresResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentMetadataResponseCollection> GetTxsMetadataAsync(string hash)
        {
            return GetTxsMetadataAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentMetadataResponseCollection> GetTxsMetadataAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/metadata");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentMetadataResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentMetadataCborResponseCollection> GetTxsMetadataCborAsync(string hash)
        {
            return GetTxsMetadataCborAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentMetadataCborResponseCollection> GetTxsMetadataCborAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/metadata/cbor");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentMetadataCborResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.TxContentRedeemersResponseCollection> GetTxsRedeemersAsync(string hash)
        {
            return GetTxsRedeemersAsync(hash, CancellationToken.None);
        }

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
        public async Task<Models.TxContentRedeemersResponseCollection> GetTxsRedeemersAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new System.ArgumentNullException(nameof(hash));
            }

            var builder = GetUrlBuilder("/txs/{hash}/redeemers");
            _ = builder.SetRouteParameter("{hash}", hash);

            return await SendGetRequestAsync<Models.TxContentRedeemersResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.27")]
        public Task<string> PostTxSubmitAsync(System.IO.Stream content)
        {
            return PostTxSubmitAsync(content, CancellationToken.None);
        }

        /// <summary>
        ///     Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.27")]
        public async Task<string> PostTxSubmitAsync(System.IO.Stream content, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/tx/submit");

            return await SendPostRequestAsync<string>(content, builder, cancellationToken);
        }
    }
}

