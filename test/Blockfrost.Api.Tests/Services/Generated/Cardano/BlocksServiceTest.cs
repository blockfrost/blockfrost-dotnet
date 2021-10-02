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
    [TestCategory(nameof(Integration))]
    [TestCategory(Constants.NETWORK_TESTNET)]
    public partial class BlocksServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Latest block <c>/blocks/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest/get">/blocks/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetLatestAsync_Not_Null()
        {
            // Arrange

            //Act
            var actual = await GetLatestAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.BlockContentResponse));
        }

        /// <summary>
        ///     Testing Latest block <c>/blocks/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest/get">/blocks/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest", "0.1.28")]
        private static async Task<Api.Models.BlockContentResponse> GetLatestAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            return await sut.GetLatestAsync( cancellationToken);
        }
        /// <summary>
        ///     Testing Latest block transactions <c>/blocks/latest/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest~1txs/get">/blocks/latest/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest/txs", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetLatestTxsAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetLatestTxsAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Latest block transactions <c>/blocks/latest/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest~1txs/get">/blocks/latest/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest/txs", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetLatestTxsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetLatestTxsAsync(count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Specific block <c>/blocks/{hash_or_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}/get">/blocks/{hash_or_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash or number of the requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetBlocksAsync_Not_Null(string hash_or_number)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash_or_number))
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                hash_or_number = latest.Hash;
            }

            //Act
            var actual = await GetBlocksAsync(hash_or_number, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.BlockContentResponse));
        }

        /// <summary>
        ///     Testing Specific block <c>/blocks/{hash_or_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}/get">/blocks/{hash_or_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash or number of the requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}", "0.1.28")]
        private static async Task<Api.Models.BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // hash_or_number  has null check
            return await sut.GetBlocksAsync(hash_or_number,  cancellationToken);
        }
        /// <summary>
        ///     Testing Specific block in a slot <c>/blocks/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1slot~1{slot_number}/get">/blocks/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/slot/{slot_number}", "0.1.28")]
        [TestMethod]
        [DataRow(1)]
        public async Task GetSlotAsync_Not_Null(int slot_number)
        {
            // Arrange
            if (slot_number == 1)
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                slot_number = (int)latest.Slot;
            }

            //Act
            var actual = await GetSlotAsync(slot_number, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.BlockContentResponse));
        }

        /// <summary>
        ///     Testing Specific block in a slot <c>/blocks/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1slot~1{slot_number}/get">/blocks/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/slot/{slot_number}", "0.1.28")]
        private static async Task<Api.Models.BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // slot_number  
            return await sut.GetSlotAsync(slot_number,  cancellationToken);
        }
        /// <summary>
        ///     Testing Specific block in a slot in an epoch <c>/blocks/epoch/{epoch_number}/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1epoch~1{epoch_number}~1slot~1{slot_number}/get">/blocks/epoch/{epoch_number}/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="epoch_number">Epoch for specific epoch slot.</param>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}", "0.1.28")]
        //[TestMethod]
        [DataRow(1, 1)]
        public async Task GetEpochSlotAsync_Not_Null(int epoch_number, int slot_number)
        {
            // Arrange
            if (epoch_number == 1)
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                epoch_number = (int)latest.Epoch;
            }
            if (slot_number == 1)
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                slot_number = (int)latest.Slot;
            }

            //Act
            var actual = await GetEpochSlotAsync(epoch_number, slot_number, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.BlockContentResponse));
        }

        /// <summary>
        ///     Testing Specific block in a slot in an epoch <c>/blocks/epoch/{epoch_number}/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1epoch~1{epoch_number}~1slot~1{slot_number}/get">/blocks/epoch/{epoch_number}/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="epoch_number">Epoch for specific epoch slot.</param>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}", "0.1.28")]
        private static async Task<Api.Models.BlockContentResponse> GetEpochSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // epoch_number  
            // slot_number  
            return await sut.GetEpochSlotAsync(epoch_number, slot_number,  cancellationToken);
        }
        /// <summary>
        ///     Testing Listing of next blocks <c>/blocks/{hash_or_number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1next/get">/blocks/{hash_or_number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/next", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1)]
        public async Task GetNextAsync_Not_Null(string hash_or_number, int? count, int? page)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash_or_number))
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                hash_or_number = latest.Hash;
            }

            //Act
            var actual = await GetNextAsync(hash_or_number, count, page, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.BlockContentResponseCollection));
        }

        /// <summary>
        ///     Testing Listing of next blocks <c>/blocks/{hash_or_number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1next/get">/blocks/{hash_or_number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/next", "0.1.28")]
        private static async Task<Api.Models.BlockContentResponseCollection> GetNextAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // hash_or_number  has null check
            // count (optional) 
            // page (optional) 
            return await sut.GetNextAsync(hash_or_number, count, page,  cancellationToken);
        }
        /// <summary>
        ///     Testing Listing of previous blocks <c>/blocks/{hash_or_number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1previous/get">/blocks/{hash_or_number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/previous", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1)]
        public async Task GetPreviousAsync_Not_Null(string hash_or_number, int? count, int? page)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash_or_number))
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                hash_or_number = latest.Hash;
            }

            //Act
            var actual = await GetPreviousAsync(hash_or_number, count, page, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.BlockContentResponseCollection));
        }

        /// <summary>
        ///     Testing Listing of previous blocks <c>/blocks/{hash_or_number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1previous/get">/blocks/{hash_or_number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/previous", "0.1.28")]
        private static async Task<Api.Models.BlockContentResponseCollection> GetPreviousAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // hash_or_number  has null check
            // count (optional) 
            // page (optional) 
            return await sut.GetPreviousAsync(hash_or_number, count, page,  cancellationToken);
        }
        /// <summary>
        ///     Testing Block transactions <c>/blocks/{hash_or_number}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1txs/get">/blocks/{hash_or_number}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/txs", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetTxsAsync_Not_Null(string hash_or_number, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash_or_number))
            {
                var blocksService = Provider.GetRequiredService<IBlockService>();
                var latest = await blocksService.GetLatestBlockAsync();
                hash_or_number = latest.Hash;
            }

            //Act
            var actual = await GetTxsAsync(hash_or_number, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Block transactions <c>/blocks/{hash_or_number}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1txs/get">/blocks/{hash_or_number}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/txs", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetTxsAsync(string hash_or_number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IBlocksService>();
            sut.ReadResponseAsString = true;
            // hash_or_number  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTxsAsync(hash_or_number, count, page, order,  cancellationToken);
        }
    }
}

