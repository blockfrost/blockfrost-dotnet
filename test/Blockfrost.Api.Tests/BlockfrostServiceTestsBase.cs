using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    /// <summary>
    /// We need to be aware of versioning
    /// </summary>
    [TestClass]
    public abstract class BlockfrostServiceTestsBase : IBlockfrostService
    {
        private const string DerivingClassesMustImplementErrorMessage = "Deriving classes must implement this test explicitly";
        
        protected IBlockfrostService Test => this;
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
        string IBlockfrostService.BaseUrl { get; set; }
        bool IBlockfrostService.ReadResponseAsString { get; set; }

        [TestMethod]
        public async Task AssetsAll2AsyncTest()
        {
            var response = await Test.AssetsAll2Async(10, 0, ESortOrder.Desc);
            Assert.AreEqual(10, response.Count);
        }

        [TestMethod]
        [TestCategory(Cardano_Addresses)]
        [TestProperty("method", nameof(IBlockfrostService.AddressesAsync))]
        public virtual async Task GetAddressTest(string address)
        {
            var response = await Test.AddressesAsync(address);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PoolsAllAsyncTest()
        {
            var response = await _service.PoolsAllAsync(10, 0, ESortOrder.Asc);
            Assert.AreEqual(response.Count, 10);
        }

        [TestCategory("Move to base (network parameter)")]
        [TestMethod]
        [DataRow("pool1adur9jcn0dkjpm3v8ayf94yn3fe5xfk2rqfz7rfpuh6cw6evd7w")]
        public async Task PoolsAsyncTest(string poolId)
        {
            var response = await _service.PoolsAsync("pool1adur9jcn0dkjpm3v8ayf94yn3fe5xfk2rqfz7rfpuh6cw6evd7w");
            Assert.AreEqual(poolId, response.Pool_id);
        }

        [TestMethod]
        public async Task GetClockAsyncTest()
        {
            var response = await _service.GetClockAsync();
            Assert.AreNotEqual(0, response.ServerTime);
        }

        [TestMethod]
        [TestCategory(Misc)]
        [TestProperty("method", nameof(IBlockfrostService.GetInfoAsync))]
        public async Task GetInfoAsyncTest()
        {
            var response = await Test.GetInfoAsync();
            Assert.AreEqual(_version, response.Version);
        }

        [TestMethod]
        [TestCategory(Misc)]
        public async Task GetHealthAsyncTest()
        {
            await Test.GetHealthAsync();
        }
        Task<AddressResponse> IBlockfrostService.AddressesAsync(string address)
        {
            return Test.AddressesAsync(address, EmptyToken);
        }

        Task<AddressResponse> IBlockfrostService.AddressesAsync(string address, CancellationToken cancellationToken)
        {
            return _service.AddressesAsync(address, cancellationToken);
        }
        Task<InfoResponse> IBlockfrostService.GetInfoAsync()
        {
            return Test.GetInfoAsync(EmptyToken);
        }

        Task<InfoResponse> IBlockfrostService.GetInfoAsync(CancellationToken cancellationToken)
        {
            return _service.GetInfoAsync(cancellationToken);
        }


        Task<HealthResponse> IBlockfrostService.GetHealthAsync()
        {
            return Test.GetHealthAsync(EmptyToken);
        }

        Task<HealthResponse> IBlockfrostService.GetHealthAsync(CancellationToken cancellationToken)
        {
            return _service.GetHealthAsync(cancellationToken);
        }


        Task<AccountContentResponse> IBlockfrostService.GetAccountsAsync(string stake_address)
        {
            return Test.GetAccountsAsync(stake_address, EmptyToken);
        }

        Task<AccountContentResponse> IBlockfrostService.GetAccountsAsync(string stake_address, CancellationToken cancellationToken)
        {
            return _service.GetAccountsAsync(stake_address, cancellationToken);
        }

        Task<IpfsPinAddResponse> IBlockfrostService.PostPinAsync(string iPFS_path)
        {
            return Test.PostPinAsync(iPFS_path, EmptyToken);
        }

        Task<IpfsPinAddResponse> IBlockfrostService.PostPinAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IpfsAddResponse> IBlockfrostService.AddIpfsAsync()
        {
            return Test.AddIpfsAsync(EmptyToken);
        }

        Task<IpfsAddResponse> IBlockfrostService.AddIpfsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AssetAddressesResponse>> IBlockfrostService.GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return Test.GetAssetAddressesAsync(asset, count, page, order, EmptyToken);
        }

        Task<ICollection<AssetAddressesResponse>> IBlockfrostService.GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<StakeAddressesAddressesResponse>> IBlockfrostService.AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.AddressesAllAsync(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressesAddressesResponse>> IBlockfrostService.AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        Task<ICollection<AssetsResponse>> IBlockfrostService.AssetsAll2Async(int? count, int? page, ESortOrder? order)
        {
            return Test.AssetsAll2Async(count, page, order, EmptyToken);
        }

        Task<ICollection<AssetsResponse>> IBlockfrostService.AssetsAll2Async(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            return _service.AssetsAll2Async(count, page, order, cancellationToken);
        }

        Task<ICollection<StakeAddressAddressesAssetsResponse>> IBlockfrostService.AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.AssetsAllAsync(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressAddressesAssetsResponse>> IBlockfrostService.AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<AssetResponse> IBlockfrostService.AssetsAsync(string asset)
        {
            return Test.AssetsAsync(asset, EmptyToken);
        }

        Task<AssetResponse> IBlockfrostService.AssetsAsync(string asset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Test.BlocksAll2Async(number, pool_id, count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Test.BlocksAll3Async(pool_id, count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.BlocksAll3Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.BlocksAllAsync(int number, int? count, int? page, ESortOrder? order)
        {
            return Test.BlocksAllAsync(number, count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.BlocksAllAsync(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxMetadataLabelCBORResponse>> IBlockfrostService.Cbor2Async(string label, int? count, int? page, ESortOrder? order)
        {
            return Test.Cbor2Async(label, count, page, order, EmptyToken);
        }

        Task<ICollection<TxMetadataLabelCBORResponse>> IBlockfrostService.Cbor2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxMetadataCborResponse>> IBlockfrostService.CborAsync(string hash)
        {
            return Test.CborAsync(hash, EmptyToken);
        }

        Task<ICollection<TxMetadataCborResponse>> IBlockfrostService.CborAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ClockResponse> IBlockfrostService.GetClockAsync()
        {
            return Test.GetClockAsync(EmptyToken);
        }

        Task<ICollection<StakeAddressDelegationsResponse>> IBlockfrostService.Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.Delegations2Async(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressDelegationsResponse>> IBlockfrostService.Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxDelegation>> IBlockfrostService.DelegationsAsync(string hash)
        {
            return Test.DelegationsAsync(hash, EmptyToken);
        }

        Task<ICollection<TxDelegation>> IBlockfrostService.DelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<PoolDelegatorResponse>> IBlockfrostService.DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Test.DelegatorsAsync(pool_id, count, page, order, EmptyToken);
        }

        Task<ICollection<PoolDelegatorResponse>> IBlockfrostService.DelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<MetricsEndpointResponse>> IBlockfrostService.EndpointsAsync()
        {
            return Test.EndpointsAsync(EmptyToken);
        }

        Task<ICollection<MetricsEndpointResponse>> IBlockfrostService.EndpointsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<EpochContentResponse> IBlockfrostService.EpochsAsync(int number)
        {
            return Test.EpochsAsync(number, EmptyToken);
        }

        Task<EpochContentResponse> IBlockfrostService.EpochsAsync(int number, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IBlockfrostService.GatewayAsync(string iPFS_path)
        {
            return Test.GatewayAsync(iPFS_path, EmptyToken);
        }

        Task IBlockfrostService.GatewayAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<GenesisContentResponse> IBlockfrostService.GenesisAsync()
        {
            return Test.GenesisAsync( EmptyToken);
        }

        Task<GenesisContentResponse> IBlockfrostService.GenesisAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<BlockContentResponse> IBlockfrostService.GetBlocksAsync(string hash_or_number)
        {
            return Test.GetBlocksAsync(hash_or_number, EmptyToken);
        }

        Task<BlockContentResponse> IBlockfrostService.GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken)
        {
            return _service.GetBlocksAsync(hash_or_number, cancellationToken);
        }

        Task<ClockResponse> IBlockfrostService.GetClockAsync(CancellationToken cancellationToken)
        {
            return _service.GetClockAsync(cancellationToken);
        }

        Task<BlockContentResponse> IBlockfrostService.GetLatestBlockAsync()
        {
            return Test.GetLatestBlockAsync(EmptyToken);
        }

        Task<BlockContentResponse> IBlockfrostService.GetLatestBlockAsync(CancellationToken cancellationToken)
        {
            return Test.GetLatestBlockAsync(EmptyToken);
        }

        Task<ICollection<BlockContentResponse>> IBlockfrostService.GetNextBlockAsync(string hash_or_number, int? count, int? page)
        {
            return Test.GetNextBlockAsync(hash_or_number, count, page, EmptyToken);
        }

        Task<ICollection<BlockContentResponse>> IBlockfrostService.GetNextBlockAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<BlockContentResponse> IBlockfrostService.GetSlotAsync(int slot_number, CancellationToken cancellationToken)
        {
            return Test.GetSlotAsync(slot_number, EmptyToken);
        }

        Task<BlockContentResponse> IBlockfrostService.GetSlotAsync(int epoch_number, int slot_number)
        {
            return Test.GetSlotAsync(epoch_number, slot_number, EmptyToken);
        }

        Task<BlockContentResponse> IBlockfrostService.GetSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken)
        {
            return _service.GetSlotAsync(epoch_number, slot_number, cancellationToken);
        }



        Task<ICollection<PoolHistoryResponse>> IBlockfrostService.History2Async(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Test.History2Async(pool_id, count, page, order, EmptyToken);
        }

        Task<ICollection<PoolHistoryResponse>> IBlockfrostService.History2Async(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AssetHistoryResponse>> IBlockfrostService.History3Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Test.History3Async(asset, count, page, order, EmptyToken);
        }

        Task<ICollection<AssetHistoryResponse>> IBlockfrostService.History3Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<StakeAddressHistoryResponse>> IBlockfrostService.HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.HistoryAsync(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressHistoryResponse>> IBlockfrostService.HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxMetadataLabelJsonResponse>> IBlockfrostService.Labels2Async(string label, int? count, int? page, ESortOrder? order)
        {
            return Test.Labels2Async(label, count, page, order, EmptyToken);
        }

        Task<ICollection<TxMetadataLabelJsonResponse>> IBlockfrostService.Labels2Async(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxMetadataLabelResponse>> IBlockfrostService.LabelsAsync(int? count, int? page, ESortOrder? order)
        {
            return Test.LabelsAsync(count, page, order, EmptyToken);
        }

        Task<ICollection<TxMetadataLabelResponse>> IBlockfrostService.LabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<EpochContentResponse> IBlockfrostService.Latest2Async()
        {
            return Test.Latest2Async(EmptyToken);
        }

        Task<EpochContentResponse> IBlockfrostService.Latest2Async(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Anonymous32>> IBlockfrostService.ListAllAsync(int? count, int? page, ESortOrder? order)
        {
            return Test.ListAllAsync(count, page, order, EmptyToken);
        }

        Task<ICollection<Anonymous32>> IBlockfrostService.ListAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IpfsPinListResponse> IBlockfrostService.ListAsync(string iPFS_path)
        {
            return Test.ListAsync(iPFS_path, EmptyToken);
        }

        Task<IpfsPinListResponse> IBlockfrostService.ListAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxMetadataResponse>> IBlockfrostService.MetadataAllAsync(string hash)
        {
            return Test.MetadataAllAsync(hash, EmptyToken);
        }

        Task<ICollection<TxMetadataResponse>> IBlockfrostService.MetadataAllAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<PoolMetadataResponse> IBlockfrostService.MetadataAsync(string pool_id)
        {
            return Test.MetadataAsync(pool_id, EmptyToken);
        }

        Task<PoolMetadataResponse> IBlockfrostService.MetadataAsync(string pool_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<MetricResponse>> IBlockfrostService.GetMetricsAsync()
        {
            return _service.GetMetricsAsync(EmptyToken);
        }

        Task<ICollection<MetricResponse>> IBlockfrostService.GetMetricsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<StakeAddressMirsResponse>> IBlockfrostService.Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.Mirs2Async(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressMirsResponse>> IBlockfrostService.Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxMir>> IBlockfrostService.MirsAsync(string hash)
        {
            return Test.MirsAsync(hash, EmptyToken);
        }

        Task<ICollection<TxMir>> IBlockfrostService.MirsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<NetworkResponse> IBlockfrostService.NetworkAsync()
        {
            return Test.NetworkAsync(EmptyToken);
        }

        Task<NetworkResponse> IBlockfrostService.NetworkAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<EpochContentResponse>> IBlockfrostService.Next2Async(int number, int? count, int? page)
        {
            return Test.Next2Async(number, count, page, EmptyToken);
        }

        Task<ICollection<EpochContentResponse>> IBlockfrostService.Next2Async(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<NutlinkAddress> IBlockfrostService.NutlinkAsync(string address)
        {
            return Test.NutlinkAsync(address, EmptyToken);
        }

        Task<NutlinkAddress> IBlockfrostService.NutlinkAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<EpochParamContent> IBlockfrostService.Parameters2Async(int number)
        {
            return Test.Parameters2Async(number, EmptyToken);
        }

        Task<EpochParamContent> IBlockfrostService.Parameters2Async(int number, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<EpochParamContent> IBlockfrostService.ParametersAsync()
        {
            return Test.ParametersAsync(EmptyToken);
        }

        Task<EpochParamContent> IBlockfrostService.ParametersAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AssetPolicyResponse>> IBlockfrostService.PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order)
        {
            return Test.PolicyAsync(policy_id, count, page, order, EmptyToken);
        }

        Task<ICollection<AssetPolicyResponse>> IBlockfrostService.PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.PoolsAllAsync(int? count, int? page, ESortOrder? order)
        {
            return Test.PoolsAllAsync(count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.PoolsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<PoolResponse> IBlockfrostService.PoolsAsync(string pool_id)
        {
            return Test.PoolsAsync(pool_id, EmptyToken);
        }

        Task<PoolResponse> IBlockfrostService.PoolsAsync(string pool_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<EpochContentResponse>> IBlockfrostService.Previous2Async(int number, int? count, int? page)
        {
            return Test.Previous2Async(number, count, page, EmptyToken);
        }

        Task<ICollection<EpochContentResponse>> IBlockfrostService.Previous2Async(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<BlockContentResponse>> IBlockfrostService.PreviousAsync(string hash_or_number, int? count, int? page)
        {
            return Test.PreviousAsync(hash_or_number, count, page, EmptyToken);
        }

        Task<ICollection<BlockContentResponse>> IBlockfrostService.PreviousAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<StakeAddressRegistrationsResponse>> IBlockfrostService.RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.RegistrationsAsync(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressRegistrationsResponse>> IBlockfrostService.RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<PoolRelayResponse>> IBlockfrostService.RelaysAsync(string pool_id)
        {
            return Test.RelaysAsync(pool_id, EmptyToken);
        }

        Task<ICollection<PoolRelayResponse>> IBlockfrostService.RelaysAsync(string pool_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IpfsPinRemoveResponse> IBlockfrostService.RemoveAsync(string iPFS_path)
        {
            return Test.RemoveAsync(iPFS_path, EmptyToken);
        }

        Task<IpfsPinRemoveResponse> IBlockfrostService.RemoveAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<RetiredResponse>> IBlockfrostService.RetiredAsync(int? count, int? page, ESortOrder? order)
        {
            return Test.RetiredAsync(count, page, order, EmptyToken);
        }

        Task<ICollection<RetiredResponse>> IBlockfrostService.RetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<RetiredResponse>> IBlockfrostService.RetiringAsync(int? count, int? page, ESortOrder? order)
        {
            return Test.RetiringAsync(count, page, order, EmptyToken);
        }

        Task<ICollection<RetiredResponse>> IBlockfrostService.RetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Anonymous9>> IBlockfrostService.RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.RewardsAsync(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<Anonymous9>> IBlockfrostService.RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<BlockContentResponse> IBlockfrostService.GetSlotAsync(int slot_number)
        {
            return Test.GetSlotAsync(slot_number, EmptyToken);
        }

        Task<ICollection<Anonymous2>> IBlockfrostService.Stakes2Async(int number, string pool_id, int? count, int? page)
        {
            return Test.Stakes2Async(number, pool_id, count, page, EmptyToken);
        }

        Task<ICollection<Anonymous2>> IBlockfrostService.Stakes2Async(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            return _service.Stakes2Async(number, pool_id, count, page, EmptyToken);
        }

        Task<ICollection<TxStakeAddress>> IBlockfrostService.Stakes3Async(string hash)
        {
            return Test.Stakes3Async(hash, EmptyToken);
        }

        Task<ICollection<TxStakeAddress>> IBlockfrostService.Stakes3Async(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<EpochStakesResponse>> IBlockfrostService.StakesAsync(int number, int? count, int? page)
        {
            return Test.StakesAsync(number, count, page, EmptyToken);
        }

        Task<ICollection<EpochStakesResponse>> IBlockfrostService.StakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IBlockfrostService.SubmitAsync(EContentType content_Type)
        {
            return Test.SubmitAsync(content_Type, EmptyToken);
        }

        Task<string> IBlockfrostService.SubmitAsync(EContentType content_Type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<NutlinkAddressTickerResponse>> IBlockfrostService.Tickers2Async(string address, string ticker, int? count, int? page, ESortOrder? order)
        {
            return Test.Tickers2Async(address, ticker, count, page, order, EmptyToken);
        }

        Task<ICollection<NutlinkAddressTickerResponse>> IBlockfrostService.Tickers2Async(string address, string ticker, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<NutlinkTickersTickerResponse>> IBlockfrostService.Tickers3Async(string ticker, int? count, int? page, ESortOrder? order)
        {
            return Test.Tickers3Async(ticker, count, page, order, EmptyToken); ;
        }

        Task<ICollection<NutlinkTickersTickerResponse>> IBlockfrostService.Tickers3Async(string ticker, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<NutlinkAddressTickersResponse>> IBlockfrostService.TickersAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return Test.TickersAsync(address, count, page, order, EmptyToken);
        }

        Task<ICollection<NutlinkAddressTickersResponse>> IBlockfrostService.TickersAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<AddressContentTotal> IBlockfrostService.TotalAsync(string address)
        {
            return Test.TotalAsync(address, EmptyToken);
        }

        Task<AddressContentTotal> IBlockfrostService.TotalAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AssetTransactionResponse>> IBlockfrostService.Transactions2Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Test.Transactions2Async(asset, count, page, order, EmptyToken);
        }

        Task<ICollection<AssetTransactionResponse>> IBlockfrostService.Transactions2Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AddressTransactionResponse>> IBlockfrostService.TransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to)
        {
            return Test.TransactionsAsync(address, count, page, order, from, to, EmptyToken);
        }

        Task<ICollection<AddressTransactionResponse>> IBlockfrostService.TransactionsAsync(string address, int? count, int? page, ESortOrder? order, string from, string to, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order)
        {
            return Test.TxsAll2Async(hash_or_number, count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.TxsAll3Async(string address, int? count, int? page, ESortOrder? order)
        {
            return Test.TxsAll3Async(address, count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.TxsAll3Async(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.TxsAll4Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Test.TxsAll4Async(asset, count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<string>> IBlockfrostService.TxsAllAsync(int? count, int? page, ESortOrder? order)
        {
            return Test.TxsAllAsync(count, page, order, EmptyToken);
        }

        Task<ICollection<string>> IBlockfrostService.TxsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<TxContentResponse> IBlockfrostService.TxsAsync(string hash)
        {
            return Test.TxsAsync(hash, EmptyToken);
        }

        Task<TxContentResponse> IBlockfrostService.TxsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<PoolUpdateResponse>> IBlockfrostService.UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order)
        {
            return Test.UpdatesAsync(pool_id, count, page, order, EmptyToken);
        }

        Task<ICollection<PoolUpdateResponse>> IBlockfrostService.UpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AddressUTxOResponse>> IBlockfrostService.UtxosAllAsync(string address, int? count, int? page, ESortOrder? order)
        {
            return Test.UtxosAllAsync(address, count, page, order, EmptyToken);
        }

        Task<ICollection<AddressUTxOResponse>> IBlockfrostService.UtxosAllAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<TxContentUTxOResponse> IBlockfrostService.UtxosAsync(string hash)
        {
            return Test.UtxosAsync(hash, EmptyToken);
        }

        Task<TxContentUTxOResponse> IBlockfrostService.UtxosAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<StakeAddressWithdrawalsResponse>> IBlockfrostService.Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Test.Withdrawals2Async(stake_address, count, page, order, EmptyToken);
        }

        Task<ICollection<StakeAddressWithdrawalsResponse>> IBlockfrostService.Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<TxWithdawal>> IBlockfrostService.WithdrawalsAsync(string hash)
        {
            return Test.WithdrawalsAsync(hash, EmptyToken);
        }

        Task<ICollection<TxWithdawal>> IBlockfrostService.WithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected static void SetupEnvironment(string projectName)
        {

            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<TestnetServiceTests>();
            }

            configuration = builder.Build();
            _service = GetService(projectName);

            IServiceCollection services = new ServiceCollection();

            services.AddBlockfrost(projectName, configuration);

            var provider = services.BuildServiceProvider();
            _service = provider.GetRequiredService<IBlockfrostService>();
        }
        private static IBlockfrostService GetService(string projectName)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddBlockfrost(projectName, configuration);

            var provider = services.BuildServiceProvider();
            _service = provider.GetRequiredService<IBlockfrostService>();
            return _service;
        }
    }
}