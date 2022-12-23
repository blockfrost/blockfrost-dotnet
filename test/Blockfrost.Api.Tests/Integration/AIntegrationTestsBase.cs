using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;
using Blockfrost.Api.Tests.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Integration
{
    /// <summary>
    /// We need to be aware of versioning
    /// </summary>
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Integration))]
    public abstract class AIntegrationTestsBase : AServiceTestBase
    //,
    //IAccountService,
    //IAddressService,
    //IAssetService,
    //IBlockService,
    //IEpochService,
    //IPoolService,
    //ILedgerService,
    //IMetadataService,
    //ITransactionService
    //,IIpfsService
    //,INutlinkService
    //,ICardanoService
    {
        protected string ApiVersion { get; }

        protected AIntegrationTestsBase(string apiVersion)
        {
            ApiVersion = apiVersion;
        }
        public static IAccountsService Accounts => Provider.GetRequiredService<IAccountsService>();
        public static IAddressesService Addresses => Provider.GetRequiredService<IAddressesService>();
        public static IAssetsService Assets => Provider.GetRequiredService<IAssetsService>();
        public static IBlocksService Blocks => Provider.GetRequiredService<IBlocksService>();
        public static IEpochsService Epochs => Provider.GetRequiredService<IEpochsService>();
        public static ILedgerService Ledger => Provider.GetRequiredService<ILedgerService>();
        public static IMetadataService Metadata => Provider.GetRequiredService<IMetadataService>();
        public static IPoolsService Pools => Provider.GetRequiredService<IPoolsService>();
        public static ITransactionsService Transactions => Provider.GetRequiredService<ITransactionsService>();
        public static ITransactionsService TransactionsV1 => Provider.GetRequiredService<ITransactionsService>();
        public static IHealthService Health => Provider.GetRequiredService<IHealthService>();

        //Api.Services.IAddressesService IServiceMigration<Api.Services.IAddressesService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //Api.Services.IBlocksService IServiceMigration<Api.Services.IBlocksService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //Api.Services.IEpochsService IServiceMigration<Api.Services.IEpochsService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //Api.Services.IPoolsService IServiceMigration<Api.Services.IPoolsService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //Api.Services.ILedgerService IServiceMigration<Api.Services.ILedgerService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //Api.Services.IMetadataService IServiceMigration<Api.Services.IMetadataService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //Api.Services.ITransactionsService IServiceMigration<Api.Services.ITransactionsService>.V1 { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //public IAssetsService AssetsV1 { get => Assets.V1; set => Assets.V1 = value; }

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
    }
}
