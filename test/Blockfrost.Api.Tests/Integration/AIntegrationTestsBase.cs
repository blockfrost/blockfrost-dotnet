using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    /// <summary>
    /// We need to be aware of versioning
    /// </summary>
    [TestClass]
    public abstract class AIntegrationTestsBase : AServiceTestBase,
        IAccountService,
        IAddressService,
        IAssetService,
        IBlockService,
        IEpochService,
        IPoolService,
        ILedgerService,
        IMetadataService,
        ITransactionService
    //,IIpfsService
    //,INutlinkService
    //,ICardanoService
    {
        protected string ApiVersion;

        public AIntegrationTestsBase(string apiVersion)
        {
            ApiVersion = apiVersion;
        }

        public IAccountService Accounts => _provider.GetRequiredService<IAccountService>();
        public IAddressService Addresses => _provider.GetRequiredService<IAddressService>();
        public IAssetService Assets => _provider.GetRequiredService<IAssetService>();
        public IBlockService Blocks => _provider.GetRequiredService<IBlockService>();
        public IEpochService Epochs => _provider.GetRequiredService<IEpochService>();
        public ILedgerService Ledger => _provider.GetRequiredService<ILedgerService>();
        public IMetadataService Metadata => _provider.GetRequiredService<IMetadataService>();
        public IPoolService Pools => _provider.GetRequiredService<IPoolService>();
        public ITransactionService Transactions => _provider.GetRequiredService<ITransactionService>();
        //private static IBlockfrostService GetService(string projectName)
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddBlockfrost(projectName, configuration);

        //    var provider = services.BuildServiceProvider();
        //    _service = provider.GetRequiredService<IBlockfrostService>();
        //    return _service;
        //}

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

        //[TestMethod]
        //public async Task GetClockAsyncTest()
        //{
        //    var response = await _service.GetClockAsync();
        //    Assert.AreNotEqual(0, response.ServerTime);
        //}

        //[TestMethod]
        //[TestCategory(Misc)]
        ////[TestProperty("method", nameof(IBlockfrostService.GetInfoAsync))]
        //public async Task GetInfoAsyncTest()
        //{
        //    var response = await _service.GetInfoAsync();
        //    Assert.AreEqual(_version, response.Version);
        //}

        //[TestMethod]
        //[TestCategory(Misc)]
        //public async Task GetHealthAsyncTest()
        //{
        //    //await Test.GetHealthAsync();
        //}

        #region Service Methods

        /*
        * This region is for utility purposes only!
        * Don't add or remove any methods to it
        */

        public Task<AddressResponse> AddressAsync(string address, CancellationToken cancellationToken)
        {
            return Addresses.AddressAsync(address, cancellationToken);
        }

        public Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.AddressesAllAsync(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.AddressesAllAsync(stake_address, count, page, order, cancellationToken);
        }

        public Task<AddressResponse> AddressesAsync(string address)
        {
            return Addresses.AddressesAsync(address);
        }

        public Task<AddressContentTotal> AddressTotalAsync(string address, CancellationToken cancellationToken)
        {
            return Addresses.AddressTotalAsync(address, cancellationToken);
        }

        public Task<ICollection<AddressTransactionResponse>> AddressTransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to, CancellationToken cancellationToken)
        {
            return Addresses.AddressTransactionsAsync(address, count, page, order, from, to, cancellationToken);
        }

        public Task<ICollection<string>> AddressTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Addresses.AddressTxsAsync(address, count, page, order, cancellationToken);
        }

        public Task<ICollection<AddressUTxOResponse>> AddressUtxoAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Addresses.AddressUtxoAsync(address, count, page, order, cancellationToken);
        }

        public Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order)
        {
            return Assets.AssetsAll2Async(count, page, order);
        }

        public Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Assets.AssetsAll2Async(count, page, order, cancellationToken);
        }

        public Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.AssetsAllAsync(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.AssetsAllAsync(stake_address, count, page, order, cancellationToken);
        }

        public Task<AssetResponse> AssetsAsync(string asset)
        {
            return Assets.AssetsAsync(asset);
        }

        public Task<AssetResponse> AssetsAsync(string asset, CancellationToken cancellationToken)
        {
            return Assets.AssetsAsync(asset, cancellationToken);
        }

        public Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Epochs.BlocksAll2Async(number, pool_id, count, page, order);
        }

        public Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Pools.BlocksAll3Async(pool_id, count, page, order);
        }

        public Task<ICollection<string>> BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.BlocksAll3Async(pool_id, count, page, order, cancellationToken);
        }

        public Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order)
        {
            return Epochs.BlocksAllAsync(number, count, page, order);
        }

        public Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page, ESortOrder? order)
        {
            return Metadata.Cbor2Async(label, count, page, order);
        }

        public Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Metadata.Cbor2Async(label, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash)
        {
            return Transactions.CborAsync(hash);
        }

        public Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.CborAsync(hash, cancellationToken);
        }

        public Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.Delegations2Async(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.Delegations2Async(stake_address, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxDelegation>> DelegationsAsync(string hash)
        {
            return Transactions.DelegationsAsync(hash);
        }

        public Task<ICollection<TxDelegation>> DelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.DelegationsAsync(hash, cancellationToken);
        }

        public Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Pools.DelegatorsAsync(pool_id, count, page, order);
        }

        public Task<ICollection<PoolDelegatorResponse>> DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.DelegatorsAsync(pool_id, count, page, order, cancellationToken);
        }

        public Task<ICollection<MetricsEndpointResponse>> EndpointsAsync()
        {
            return Blocks.EndpointsAsync();
        }

        public Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken)
        {
            return Blocks.EndpointsAsync(cancellationToken);
        }

        public Task<ICollection<string>> EpochBlocks(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Epochs.EpochBlocks(number, count, page, order, cancellationToken);
        }

        public Task<ICollection<string>> EpochBlocksByPool(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Epochs.EpochBlocksByPool(number, pool_id, count, page, order, cancellationToken);
        }

        public Task<EpochParamContent> EpochParameters(int number, CancellationToken cancellationToken)
        {
            return Epochs.EpochParameters(number, cancellationToken);
        }

        public Task<EpochContentResponse> EpochsAsync(int number)
        {
            return Epochs.EpochsAsync(number);
        }

        public Task<EpochContentResponse> EpochsAsync(int number, CancellationToken cancellationToken)
        {
            return Epochs.EpochsAsync(number, cancellationToken);
        }

        public Task<ICollection<EpochStakesResponse>> EpochStakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            return Epochs.EpochStakesAsync(number, count, page, cancellationToken);
        }

        public Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page)
        {
            return Epochs.EpochStakesByPool(number, pool_id, count, page);
        }

        public Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            return Epochs.EpochStakesByPool(number, pool_id, count, page, cancellationToken);
        }

        public Task<GenesisContentResponse> GenesisAsync()
        {
            return Ledger.GenesisAsync();
        }

        public Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken)
        {
            return Ledger.GenesisAsync(cancellationToken);
        }

        public Task<Account> GetAccountsAsync(string stake_address)
        {
            return Accounts.GetAccountsAsync(stake_address);
        }

        public Task<Account> GetAccountsAsync(string stake_address, CancellationToken cancellationToken)
        {
            return Accounts.GetAccountsAsync(stake_address, cancellationToken);
        }

        public Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return Assets.GetAssetAddressesAsync(asset, count, page, order);
        }

        public Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Assets.GetAssetAddressesAsync(asset, count, page, order, cancellationToken);
        }

        public Task<BlockContentResponse> GetBlocksAsync(string hash_or_number)
        {
            return Blocks.GetBlocksAsync(hash_or_number);
        }

        public Task<BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken)
        {
            return Blocks.GetBlocksAsync(hash_or_number, cancellationToken);
        }

        public Task<ClockResponse> GetClockAsync()
        {
            return Blocks.GetClockAsync();
        }

        public Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            return Blocks.GetClockAsync(cancellationToken);
        }

        public Task<HealthResponse> GetHealthAsync()
        {
            return Blocks.GetHealthAsync();
        }

        public Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            return Blocks.GetHealthAsync(cancellationToken);
        }

        public Task<InfoResponse> GetInfoAsync()
        {
            return Blocks.GetInfoAsync();
        }

        public Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken)
        {
            return Blocks.GetInfoAsync(cancellationToken);
        }

        public Task<BlockContentResponse> GetLatestBlockAsync()
        {
            return Blocks.GetLatestBlockAsync();
        }

        public Task<BlockContentResponse> GetLatestBlockAsync(CancellationToken cancellationToken)
        {
            return Blocks.GetLatestBlockAsync(cancellationToken);
        }

        public Task<ICollection<MetricResponse>> GetMetricsAsync()
        {
            return Blocks.GetMetricsAsync();
        }

        public Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken)
        {
            return Blocks.GetMetricsAsync(cancellationToken);
        }

        public Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page)
        {
            return Blocks.GetNextBlockAsync(hash_or_number, count, page);
        }

        public Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            return Blocks.GetNextBlockAsync(hash_or_number, count, page, cancellationToken);
        }

        public Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number)
        {
            return Blocks.GetSlotAsync(epoch_number, slot_number);
        }

        public Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken)
        {
            return Blocks.GetSlotAsync(epoch_number, slot_number, cancellationToken);
        }

        public Task<BlockContentResponse> GetSlotAsync(int slot_number)
        {
            return Blocks.GetSlotAsync(slot_number);
        }

        public Task<BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken)
        {
            return Blocks.GetSlotAsync(slot_number, cancellationToken);
        }

        public Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Pools.History2Async(pool_id, count, page, order);
        }

        public Task<ICollection<PoolHistoryResponse>> History2Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.History2Async(pool_id, count, page, order, cancellationToken);
        }

        public Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Assets.History3Async(asset, count, page, order);
        }

        public Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Assets.History3Async(asset, count, page, order, cancellationToken);
        }

        public Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.HistoryAsync(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.HistoryAsync(stake_address, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page, ESortOrder? order)
        {
            return Metadata.Labels2Async(label, count, page, order);
        }

        public Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Metadata.Labels2Async(label, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order)
        {
            return Metadata.LabelsAsync(count, page, order);
        }

        public Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Metadata.LabelsAsync(count, page, order, cancellationToken);
        }

        public Task<EpochContentResponse> Latest2Async()
        {
            return Epochs.Latest2Async();
        }

        public Task<EpochContentResponse> Latest2Async(CancellationToken cancellationToken)
        {
            return Epochs.Latest2Async(cancellationToken);
        }

        public Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash)
        {
            return Transactions.MetadataAllAsync(hash);
        }

        public Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.MetadataAllAsync(hash, cancellationToken);
        }

        public Task<PoolMetadataResponse> MetadataAsync(string pool_id)
        {
            return Pools.MetadataAsync(pool_id);
        }

        public Task<PoolMetadataResponse> MetadataAsync(string pool_id, CancellationToken cancellationToken)
        {
            return Pools.MetadataAsync(pool_id, cancellationToken);
        }

        public Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.Mirs2Async(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.Mirs2Async(stake_address, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxMir>> MirsAsync(string hash)
        {
            return Transactions.MirsAsync(hash);
        }

        public Task<ICollection<TxMir>> MirsAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.MirsAsync(hash, cancellationToken);
        }

        public Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page)
        {
            return Epochs.Next2Async(number, count, page);
        }

        public Task<ICollection<EpochContentResponse>> NextEpochAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            return Epochs.NextEpochAsync(number, count, page, cancellationToken);
        }

        public Task<EpochParamContent> Parameters2Async(int number)
        {
            return Epochs.Parameters2Async(number);
        }

        public Task<EpochParamContent> ParametersAsync()
        {
            return Epochs.ParametersAsync();
        }

        public Task<EpochParamContent> ParametersAsync(CancellationToken cancellationToken)
        {
            return Epochs.ParametersAsync(cancellationToken);
        }

        public Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order)
        {
            return Assets.PolicyAsync(policy_id, count, page, order);
        }

        public Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Assets.PolicyAsync(policy_id, count, page, order, cancellationToken);
        }

        public Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order)
        {
            return Pools.PoolsAllAsync(count, page, order);
        }

        public Task<ICollection<string>> PoolsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.PoolsAllAsync(count, page, order, cancellationToken);
        }

        public Task<PoolResponse> PoolsAsync(string pool_id)
        {
            return Pools.PoolsAsync(pool_id);
        }

        public Task<PoolResponse> PoolsAsync(string pool_id, CancellationToken cancellationToken)
        {
            return Pools.PoolsAsync(pool_id, cancellationToken);
        }

        public Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page)
        {
            return Epochs.Previous2Async(number, count, page);
        }

        public Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page)
        {
            return Blocks.PreviousAsync(hash_or_number, count, page);
        }

        public Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            return Blocks.PreviousAsync(hash_or_number, count, page, cancellationToken);
        }

        public Task<ICollection<EpochContentResponse>> PreviousEpochAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            return Epochs.PreviousEpochAsync(number, count, page, cancellationToken);
        }

        public Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.RegistrationsAsync(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.RegistrationsAsync(stake_address, count, page, order, cancellationToken);
        }

        public Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id)
        {
            return Pools.RelaysAsync(pool_id);
        }

        public Task<ICollection<PoolRelayResponse>> RelaysAsync(string pool_id, CancellationToken cancellationToken)
        {
            return Pools.RelaysAsync(pool_id, cancellationToken);
        }

        public Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order)
        {
            return Pools.RetiredAsync(count, page, order);
        }

        public Task<ICollection<RetiredResponse>> RetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.RetiredAsync(count, page, order, cancellationToken);
        }

        public Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order)
        {
            return Pools.RetiringAsync(count, page, order);
        }

        public Task<ICollection<RetiredResponse>> RetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.RetiringAsync(count, page, order, cancellationToken);
        }

        public Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.RewardsAsync(stake_address, count, page, order);
        }

        public Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.RewardsAsync(stake_address, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxStakeAddress>> Stakes3Async(string hash)
        {
            return Transactions.Stakes3Async(hash);
        }

        public Task<ICollection<TxStakeAddress>> Stakes3Async(string hash, CancellationToken cancellationToken)
        {
            return Transactions.Stakes3Async(hash, cancellationToken);
        }

        public Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page)
        {
            return Epochs.StakesAsync(number, count, page);
        }

        public Task<AddressContentTotal> TotalAsync(string address)
        {
            return Addresses.TotalAsync(address);
        }

        public Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Assets.Transactions2Async(asset, count, page, order);
        }

        public Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Assets.Transactions2Async(asset, count, page, order, cancellationToken);
        }

        public Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to)
        {
            return Addresses.TransactionsAsync(address, count, page, order, from, to);
        }

        public Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order)
        {
            return Blocks.TxsAll2Async(hash_or_number, count, page, order);
        }

        public Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Blocks.TxsAll2Async(hash_or_number, count, page, order, cancellationToken);
        }

        public Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order)
        {
            return Addresses.TxsAll3Async(address, count, page, order);
        }

        public Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Assets.TxsAll4Async(asset, count, page, order);
        }

        public Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Assets.TxsAll4Async(asset, count, page, order, cancellationToken);
        }

        public Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order)
        {
            return Blocks.TxsAllAsync(count, page, order);
        }

        public Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Blocks.TxsAllAsync(count, page, order, cancellationToken);
        }

        public Task<TxContentResponse> TxsAsync(string hash)
        {
            return Transactions.TxsAsync(hash);
        }

        public Task<TxContentResponse> TxsAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.TxsAsync(hash, cancellationToken);
        }

        public Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Pools.UpdatesAsync(pool_id, count, page, order);
        }

        public Task<ICollection<PoolUpdateResponse>> UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Pools.UpdatesAsync(pool_id, count, page, order, cancellationToken);
        }

        public Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return Addresses.UtxosAllAsync(address, count, page, order);
        }

        public Task<TxContentUTxOResponse> UtxosAsync(string hash)
        {
            return Transactions.UtxosAsync(hash);
        }

        public Task<TxContentUTxOResponse> UtxosAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.UtxosAsync(hash, cancellationToken);
        }

        public Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Accounts.Withdrawals2Async(stake_address, count, page, order);
        }

        public Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return Accounts.Withdrawals2Async(stake_address, count, page, order, cancellationToken);
        }

        public Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash)
        {
            return Transactions.WithdrawalsAsync(hash);
        }

        public Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            return Transactions.WithdrawalsAsync(hash, cancellationToken);
        }

        #endregion Service Methods
    }
}
