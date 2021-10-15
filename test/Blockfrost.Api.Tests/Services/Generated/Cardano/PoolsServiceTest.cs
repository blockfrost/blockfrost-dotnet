using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;
using Blockfrost.Api.Tests.Attributes;

namespace Blockfrost.Api.Tests.Services
{
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Services))]
    [TestCategory(nameof(Integration))]
    [TestCategory(Constants.NETWORK_TESTNET)]
    public partial class PoolsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing List of stake pools <c>/pools</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools/get">/pools</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the list of pools.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetPoolsAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange
            //Act
            var actual = await GetPoolsAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing List of stake pools <c>/pools</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools/get">/pools</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the list of pools.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetPoolsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetPoolsAsync(count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing List of retired stake pools <c>/pools/retired</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retired/get">/pools/retired</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retired", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetRetiredAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange
            //Act
            var actual = await GetRetiredAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolListRetireResponseCollection));
        }

        /// <summary>
        ///     Testing List of retired stake pools <c>/pools/retired</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retired/get">/pools/retired</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retired", "0.1.28")]
        private static async Task<Api.Models.PoolListRetireResponseCollection> GetRetiredAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetRetiredAsync(count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing List of retiring stake pools <c>/pools/retiring</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retiring/get">/pools/retiring</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retiring", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetRetiringAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange
            //Act
            var actual = await GetRetiringAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolListRetireResponseCollection));
        }

        /// <summary>
        ///     Testing List of retiring stake pools <c>/pools/retiring</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1retiring/get">/pools/retiring</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/retiring", "0.1.28")]
        private static async Task<Api.Models.PoolListRetireResponseCollection> GetRetiringAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetRetiringAsync(count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Specific stake pool <c>/pools/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}/get">/pools/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetPoolsAsync_Not_Null(string pool_id)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetPoolsAsync(pool_id, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolResponse));
        }

        /// <summary>
        ///     Testing Specific stake pool <c>/pools/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}/get">/pools/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool information content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}", "0.1.28")]
        private static async Task<Api.Models.PoolResponse> GetPoolsAsync(string pool_id, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            return await sut.GetPoolsAsync(pool_id, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake pool history <c>/pools/{pool_id}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1history/get">/pools/{pool_id}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/history", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetHistoryAsync_Not_Null(string pool_id, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetHistoryAsync(pool_id, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolHistoryResponseCollection));
        }

        /// <summary>
        ///     Testing Stake pool history <c>/pools/{pool_id}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1history/get">/pools/{pool_id}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/history", "0.1.28")]
        private static async Task<Api.Models.PoolHistoryResponseCollection> GetHistoryAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetHistoryAsync(pool_id, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake pool metadata <c>/pools/{pool_id}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1metadata/get">/pools/{pool_id}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool metadata content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/metadata", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetMetadataAsync_Not_Null(string pool_id)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetMetadataAsync(pool_id, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolMetadataResponse));
        }

        /// <summary>
        ///     Testing Stake pool metadata <c>/pools/{pool_id}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1metadata/get">/pools/{pool_id}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool metadata content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/metadata", "0.1.28")]
        private static async Task<Api.Models.PoolMetadataResponse> GetMetadataAsync(string pool_id, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            return await sut.GetMetadataAsync(pool_id, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake pool relays <c>/pools/{pool_id}/relays</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1relays/get">/pools/{pool_id}/relays</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool relays information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/relays", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetRelaysAsync_Not_Null(string pool_id)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetRelaysAsync(pool_id, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolRelaysResponseCollection));
        }

        /// <summary>
        ///     Testing Stake pool relays <c>/pools/{pool_id}/relays</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1relays/get">/pools/{pool_id}/relays</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <returns>Return the pool relays information content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/relays", "0.1.28")]
        private static async Task<Api.Models.PoolRelaysResponseCollection> GetRelaysAsync(string pool_id, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            return await sut.GetRelaysAsync(pool_id, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake pool delegators <c>/pools/{pool_id}/delegators</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1delegators/get">/pools/{pool_id}/delegators</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool delegations.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/delegators", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetDelegatorsAsync_Not_Null(string pool_id, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetDelegatorsAsync(pool_id, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolDelegatorsResponseCollection));
        }

        /// <summary>
        ///     Testing Stake pool delegators <c>/pools/{pool_id}/delegators</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1delegators/get">/pools/{pool_id}/delegators</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool delegations.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/delegators", "0.1.28")]
        private static async Task<Api.Models.PoolDelegatorsResponseCollection> GetDelegatorsAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetDelegatorsAsync(pool_id, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake pool blocks <c>/pools/{pool_id}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1blocks/get">/pools/{pool_id}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool block list</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/blocks", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetBlocksAsync_Not_Null(string pool_id, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetBlocksAsync(pool_id, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Stake pool blocks <c>/pools/{pool_id}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1blocks/get">/pools/{pool_id}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool block list</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/blocks", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetBlocksAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetBlocksAsync(pool_id, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake pool updates <c>/pools/{pool_id}/updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1updates/get">/pools/{pool_id}/updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool updates history</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/updates", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetUpdatesAsync_Not_Null(string pool_id, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetUpdatesAsync(pool_id, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.PoolUpdatesResponseCollection));
        }

        /// <summary>
        ///     Testing Stake pool updates <c>/pools/{pool_id}/updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Pools/paths/~1pools~1{pool_id}~1updates/get">/pools/{pool_id}/updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="pool_id">Bech32 or hexadecimal pool ID.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the pool updates history</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/pools/{pool_id}/updates", "0.1.28")]
        private static async Task<Api.Models.PoolUpdatesResponseCollection> GetUpdatesAsync(string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPoolsService>();
            sut.ReadResponseAsString = true;
            // pool_id  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetUpdatesAsync(pool_id, count, page, order, cancellationToken);
        }
    }
}

