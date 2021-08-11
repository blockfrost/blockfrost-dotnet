using System;
using System.Collections.Generic;using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface INutlinkService
    {
        Task<NutlinkAddress> NutlinkAsync(string address);
        Task<NutlinkAddress> NutlinkAsync(string address, CancellationToken cancellationToken);
        Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);
    }

    public interface IAccountService
    {
        Task<Account> GetAccountsAsync(string stake_address);
        Task<Account> GetAccountsAsync(string stake_address, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

    }

    public interface IAddressService
    {
        Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order);
        Task<ICollection<string>> AddressTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<AddressContentTotal> TotalAsync(string address);
        Task<AddressContentTotal> AddressTotalAsync(string address, CancellationToken cancellationToken);
        Task<AddressResponse> AddressesAsync(string address);
        Task<AddressResponse> AddressAsync(string address, CancellationToken cancellationToken);

        Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page,
            ESortOrder? order, string from, string to);

        Task<ICollection<AddressTransactionResponse>> AddressTransactionsAsync(string address, int? count, int? page,
            ESortOrder? order, string from, string to, CancellationToken cancellationToken);

        Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order);

        Task<ICollection<AddressUTxOResponse>> AddressUtxoAsync(string address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

    }

    public interface IAssetService
    {
        Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order);
        Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<AssetResponse> AssetsAsync(string asset);
        Task<AssetResponse> AssetsAsync(string asset, CancellationToken cancellationToken);

        Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order);

        Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order);

        Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);
    }

    public interface IPoolService
    {
        Task<PoolResponse> PoolsAsync(string pool_id);
        Task<PoolResponse> PoolsAsync(string pool_id, CancellationToken cancellationToken);

        Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id);
        Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id, CancellationToken cancellationToken);
        Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

    }

    public interface IBlockService
    {
        Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<BlockContentResponse> GetBlocksAsync(string hash_or_number);
        Task<BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken);
        Task<BlockContentResponse> GetLatestBlockAsync();
        Task<BlockContentResponse> GetLatestBlockAsync(CancellationToken cancellationToken);
        Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number);
        Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken);
        Task<BlockContentResponse> GetSlotAsync(int slot_number);
        Task<BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken);
        Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page);

        Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page);

        Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page,
            CancellationToken cancellationToken);
    }

    public interface IEpochService
    {
        
        Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> EpochBlocksByPool(int number, string pool_id, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> EpochBlocks(int number, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<EpochContentResponse> EpochsAsync(int number);
        Task<EpochContentResponse> EpochsAsync(int number, CancellationToken cancellationToken);
        Task<EpochContentResponse> Latest2Async();
        Task<EpochContentResponse> Latest2Async(CancellationToken cancellationToken);
        Task<EpochParamContent> Parameters2Async(int number);
        Task<EpochParamContent> EpochParameters(int number, CancellationToken cancellationToken);
        Task<EpochParamContent> ParametersAsync();
        Task<EpochParamContent> ParametersAsync(CancellationToken cancellationToken);
        Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page);

        Task<ICollection<EpochContentResponse>> NextEpochAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page);

        Task<ICollection<EpochContentResponse>> PreviousEpochAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page);

        Task<ICollection<EpochStakesResponse>> EpochStakesAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

    }

    public interface ITransactionService
    {
        Task<TxContentResponse> TxsAsync(string hash);
        Task<TxContentResponse> TxsAsync(string hash, CancellationToken cancellationToken);
        Task<TxContentUTxOResponse> UtxosAsync(string hash);
        Task<TxContentUTxOResponse> UtxosAsync(string hash, CancellationToken cancellationToken);
        Task<string> SubmitAsync(EContentType content_Type);
        Task<string> SubmitAsync(EContentType content_Type, CancellationToken cancellationToken);
        Task<ICollection<TxDelegation>> DelegationsAsync(string hash);
        Task<ICollection<TxDelegation>> DelegationsAsync(string hash, CancellationToken cancellationToken);
        Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash);
        Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash, CancellationToken cancellationToken);
        Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash);
        Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash, CancellationToken cancellationToken);

        Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<TxMir>> MirsAsync(string hash);
        Task<ICollection<TxMir>> MirsAsync(string hash, CancellationToken cancellationToken);
        Task<ICollection<TxStakeAddress>> Stakes3Async(string hash);
        Task<ICollection<TxStakeAddress>> Stakes3Async(string hash, CancellationToken cancellationToken);
        Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash);
        Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash, CancellationToken cancellationToken);

    }

    public interface IMetadataService
    {
        Task<PoolMetadataResponse> MetadataAsync(string pool_id);
        Task<PoolMetadataResponse> MetadataAsync(string pool_id, CancellationToken cancellationToken);
    }

    public interface IIpfsService
    {
        Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page);

        Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task GatewayAsync(string iPFS_path);
        Task GatewayAsync(string iPFS_path, CancellationToken cancellationToken);
        Task<IpfsAddResponse> AddIpfsAsync();
        Task<IpfsAddResponse> AddIpfsAsync(CancellationToken cancellationToken);
        Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path);
        Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path, CancellationToken cancellationToken);
        Task<IpfsPinListResponse> ListAsync(string iPFS_path);
        Task<IpfsPinListResponse> ListAsync(string iPFS_path, CancellationToken cancellationToken);
        Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path);
        Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path, CancellationToken cancellationToken);
    }

    public interface ILedgerService
    {
        Task<GenesisContentResponse> GenesisAsync();
        Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken);
    }

    public interface ICardanoService :
        IAccountService,
        IAddressService,
        IAssetService,
        IEpochService,
        IPoolService,
        ILedgerService,
        IMetadataService,
        ITransactionService
    {
        IAccountService Accounts { get; }
        IAddressService Addresses { get; }
        IAssetService Assets { get; }
        IBlockService Blocks { get; }
        IEpochService Epochs { get; }
    }

    public interface IBlockfrostService
    {
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricResponse>> GetMetricsAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken);

        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<HealthResponse> GetHealthAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken);

        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ClockResponse> GetClockAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken);

        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<InfoResponse> GetInfoAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken);

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricsEndpointResponse>> EndpointsAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken);
    }

    public abstract class ABlockfrostService : IBlockfrostService
    {
        protected ABlockfrostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerOptions);
        }

        private System.Text.Json.JsonSerializerOptions CreateSerializerOptions()
        {
            var options = new System.Text.Json.JsonSerializerOptions();
            UpdateJsonSerializerOptions(options);
            return options;
        }

        protected virtual void UpdateJsonSerializerOptions(JsonSerializerOptions options)
        {
        }

        public string BaseUrl
        {
            get => _httpClient.BaseAddress?.AbsoluteUri;
            set => _httpClient.BaseAddress = new Uri(value);
        }

        //partial void UpdateJsonSerializerOptions(System.Text.Json.JsonSerializerOptions options);
        //partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url);
        //partial void PrepareRequest(HttpClient client, HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        //partial void ProcessResponse(HttpClient client, HttpResponseMessage response);
        /// <summary>
        /// Sends the request using the configured httpClient
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="urlBuilder_"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<TResponse> SendGetRequestAsync<TResponse>(System.Text.StringBuilder urlBuilder_, CancellationToken cancellationToken)
        {
            using HttpRequestMessage request_ = new();

            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            PrepareRequest(_httpClient, request_, urlBuilder_);

            var url_ = urlBuilder_.ToString();
            request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

            PrepareRequest(_httpClient, request_, urlBuilder_);

            var response_ = await _httpClient.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            var disposeResponse_ = true;
            try
            {
                var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                if (response_.Content != null && response_.Content.Headers != null)
                {
                    foreach (var item_ in response_.Content.Headers)
                        headers_[item_.Key] = item_.Value;
                }

                ProcessResponse(_httpClient, response_);

                var status_ = (int)response_.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }
                    return objectResponse_.Object;
                }
                else
                if (status_ == 400)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<BadRequestResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }
                    throw new ApiException<BadRequestResponse>("Bad request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                }
                else
                if (status_ == 403)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<ForbiddenResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }
                    throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                }
                else
                if (status_ == 418)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }
                    throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                }
                else
                if (status_ == 429)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TooManyRequestsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }
                    throw new ApiException<TooManyRequestsResponse>("Usage limit reached", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                }
                else
                if (status_ == 500)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }
                    throw new ApiException<InternalServerErrorResponse>("Internal Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                }
                else
                {
                    var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                }
            }
            finally
            {
                if (disposeResponse_)
                    response_.Dispose();
            }
        }

        protected virtual void ProcessResponse(HttpClient httpClient, HttpResponseMessage response)
        {
        }

        protected virtual void PrepareRequest(HttpClient httpClient, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        protected readonly struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }
        protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, TextJsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    var typedBody = await response.Content.ReadFromJsonAsync<T>(TextJsonSerializerSettings, cancellationToken);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        protected string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }

        private System.Text.Json.JsonSerializerOptions TextJsonSerializerSettings { get { return _options.Value; } }

        protected HttpClient _httpClient;
        private System.Lazy<System.Text.Json.JsonSerializerOptions> _options;
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<MetricResponse>> GetMetricsAsync()
        {
            return GetMetricsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metrics/");

            return await SendGetRequestAsync<ICollection<MetricResponse>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }


        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<HealthResponse> GetHealthAsync()
        {
            return GetHealthAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/health");

            return await SendGetRequestAsync<HealthResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ClockResponse> GetClockAsync()
        {
            return GetClockAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/health/clock");

            return await SendGetRequestAsync<ClockResponse>(urlBuilder_, cancellationToken);
        }
        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<InfoResponse> GetInfoAsync()
        {
            return GetInfoAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/");

            return await SendGetRequestAsync<InfoResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<MetricsEndpointResponse>> EndpointsAsync()
        {
            return EndpointsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metrics/endpoints");

            return await SendGetRequestAsync<ICollection<MetricsEndpointResponse>>(urlBuilder_, cancellationToken);

        }
    }
}