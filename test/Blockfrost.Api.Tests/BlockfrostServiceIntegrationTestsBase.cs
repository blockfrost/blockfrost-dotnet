using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    /// <summary>
    /// We need to be aware of versioning
    /// </summary>
    [TestClass]
    public abstract class BlockfrostServiceIntegrationTestsBase : ICardanoService, IIpfsService, INutlinkService
    {
        private const string DerivingClassesMustImplementErrorMessage = "Deriving classes must implement this test explicitly";
        protected static CancellationToken EmptyToken => CancellationToken.None;

        private const string _version = "0.8.4";

        private const string IPFS_Add = "IPFS";
        private const string Cardano_Accounts = "Cardano.Accounts";
        private const string Cardano_Addresses = "Cardano.Addresses";
        private const string Cardano_Blocks = "Cardano.Blocks";
        private const string Cardano_Epochs= "Cardano.Epochs";
        private const string Cardano_Ledger= "Cardano.Ledger";
        private const string Cardano_Metadata= "Cardano.Metadata";
        private const string Cardano_Network= "Cardano.Network";
        private const string Cardano_Pools= "Cardano.Pools";
        private const string Cardano_Transactions= "Cardano.Transactions";
        private const string Misc = "Misc";

        private const string Nutlink = "Nutlink";

        protected static IConfiguration configuration;
        protected static IBlockfrostService _service;

        public string BaseUrl { get; set; }
        public bool ReadResponseAsString { get; set; }
        
        [TestInitialize]
        public void PassInStaging()
        {
            var env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isStaging = string.IsNullOrEmpty(env) || env.ToLower() == "staging";
            
        }

        //[TestMethod]
        //public async Task AssetsAll2AsyncTest()
        //{
        //    var response = await Test.AssetsAll2Async(10, 0, ESortOrder.Desc);
        //    Assert.AreEqual(10, response.Count);
        //}

        //[TestMethod]
        //[TestCategory(Cardano_Addresses)]
        //[TestProperty("method", nameof(IAddressService.AddressesAsync))]
        //public virtual async Task GetAddressTest(string address)
        //{
        //    var response = await Test.AddressesAsync(address);
        //    Assert.IsNotNull(response);
        //}

        //[TestMethod]
        //[TestCategory(Cardano_Addresses)]
        //[TestProperty("method", nameof(IAddressService.AddressesAsync))]
        //public virtual async Task GetStakeAddressTest(string address, string stake)
        //{
        //    var response = await Test.AddressesAsync(address);
        //    Assert.IsNotNull(response);
        //    Assert.AreEqual(stake, response.StakeAddress);
        //}

        //[TestMethod]
        //[TestCategory(Cardano_Addresses)]
        //[TestProperty("method", nameof(IAddressService.AddressesAsync))]
        //public virtual async Task GetAddressEraTest(string address, EAddressType era)
        //{
        //    var response = await Test.AddressesAsync(address);
        //    Assert.IsNotNull(response);
        //    Assert.AreEqual(era, response.Type);
        //}

        //[TestMethod]
        //public async Task PoolsAllAsyncTest()
        //{
        //    var response = await _service.PoolsAllAsync(10, 0, ESortOrder.Asc);
        //    Assert.AreEqual(response.Count, 10);
        //}

        //[TestCategory("Move to base (network parameter)")]
        //[TestMethod]
        //[DataRow("pool1adur9jcn0dkjpm3v8ayf94yn3fe5xfk2rqfz7rfpuh6cw6evd7w")]
        //public async Task PoolsAsyncTest(string poolId)
        //{
        //    var response = await _service.PoolsAsync("pool1adur9jcn0dkjpm3v8ayf94yn3fe5xfk2rqfz7rfpuh6cw6evd7w");
        //    Assert.AreEqual(poolId, response.Pool_id);
        //}

        [TestMethod]
        public async Task GetClockAsyncTest()
        {
            var response = await _service.GetClockAsync();
            Assert.AreNotEqual(0, response.ServerTime);
        }

        [TestMethod]
        [TestCategory(Misc)]
        //[TestProperty("method", nameof(IBlockfrostService.GetInfoAsync))]
        public async Task GetInfoAsyncTest()
        {
            var response = await _service.GetInfoAsync();
            Assert.AreEqual(_version, response.Version);
        }

        [TestMethod]
        [TestCategory(Misc)]
        public async Task GetHealthAsyncTest()
        {
            //await Test.GetHealthAsync();
        }


        protected static void SetupEnvironment(string projectName)
        {            
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            var env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(env) || env.ToLower() == "development";

            if (isDevelopment)
            {
                builder.AddUserSecrets<TestnetServiceIntegrationTests>();
            }
            
            configuration = builder.Build();

            //_service = GetService(projectName);

            var apiKey = configuration["BFCLI_API_KEY"];
            var network = configuration["BFCLI_NETWORK"];
            IServiceCollection services = new ServiceCollection();
            services.AddBlockfrost(network, apiKey);

            var provider = services.BuildServiceProvider();
            _service = provider.GetRequiredService<IBlockfrostService>();
        }

        //private static IBlockfrostService GetService(string projectName)
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddBlockfrost(projectName, configuration);

        //    var provider = services.BuildServiceProvider();
        //    _service = provider.GetRequiredService<IBlockfrostService>();
        //    return _service;
        //}

        public IAccountService Accounts { get; set; }
        public IAddressService Addresses { get; set; }
        public IAssetService Assets { get; set; }
        public IBlockService Blocks { get; }
        public IEpochService Epochs { get; }

        public async Task<Account> GetAccountsAsync(string stake_address)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccountsAsync(string stake_address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> AddressTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressContentTotal> TotalAsync(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressContentTotal> AddressTotalAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressResponse> AddressesAsync(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressResponse> AddressAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page, ESortOrder? order, string @from, string to)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AddressTransactionResponse>> AddressTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string @from, string to,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AddressUTxOResponse>> AddressUtxoAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AssetResponse> AssetsAsync(string asset)
        {
            throw new NotImplementedException();
        }

        public async Task<AssetResponse> AssetsAsync(string asset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> EpochBlocksByPool(int number, string pool_id, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> EpochBlocks(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<EpochContentResponse> EpochsAsync(int number)
        {
            throw new NotImplementedException();
        }

        public async Task<EpochContentResponse> EpochsAsync(int number, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<EpochContentResponse> Latest2Async()
        {
            throw new NotImplementedException();
        }

        public async Task<EpochContentResponse> Latest2Async(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<EpochParamContent> Parameters2Async(int number)
        {
            throw new NotImplementedException();
        }

        public async Task<EpochParamContent> EpochParameters(int number, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<EpochParamContent> ParametersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EpochParamContent> ParametersAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EpochContentResponse>> NextEpochAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EpochContentResponse>> PreviousEpochAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EpochStakesResponse>> EpochStakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<PoolResponse> PoolsAsync(string pool_id)
        {
            throw new NotImplementedException();
        }

        public async Task<PoolResponse> PoolsAsync(string pool_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<GenesisContentResponse> GenesisAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<PoolMetadataResponse> MetadataAsync(string pool_id)
        {
            throw new NotImplementedException();
        }

        public async Task<PoolMetadataResponse> MetadataAsync(string pool_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<TxContentResponse> TxsAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<TxContentResponse> TxsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<TxContentUTxOResponse> UtxosAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<TxContentUTxOResponse> UtxosAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SubmitAsync(EContentType content_Type)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SubmitAsync(EContentType content_Type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxDelegation>> DelegationsAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxDelegation>> DelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMir>> MirsAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxMir>> MirsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxStakeAddress>> Stakes3Async(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxStakeAddress>> Stakes3Async(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task GatewayAsync(string iPFS_path)
        {
            throw new NotImplementedException();
        }

        public async Task GatewayAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsAddResponse> AddIpfsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsAddResponse> AddIpfsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsPinListResponse> ListAsync(string iPFS_path)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsPinListResponse> ListAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<NutlinkAddress> NutlinkAsync(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<NutlinkAddress> NutlinkAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page, ESortOrder? order)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}