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
    public partial class EpochsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Latest epoch <c>/epochs/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest/get">/epochs/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetLatestAsync_Not_Null()
        {
            // Arrange
            //Act
            var actual = await GetLatestAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochContentResponse));
        }

        /// <summary>
        ///     Testing Latest epoch <c>/epochs/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest/get">/epochs/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest", "0.1.28")]
        private static async Task<Api.Models.EpochContentResponse> GetLatestAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            return await sut.GetLatestAsync(cancellationToken);
        }
        /// <summary>
        ///     Testing Latest epoch protocol parameters <c>/epochs/latest/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest~1parameters/get">/epochs/latest/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest/parameters", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetLatestParametersAsync_Not_Null()
        {
            // Arrange
            //Act
            var actual = await GetLatestParametersAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochParamContentResponse));
        }

        /// <summary>
        ///     Testing Latest epoch protocol parameters <c>/epochs/latest/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest~1parameters/get">/epochs/latest/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest/parameters", "0.1.28")]
        private static async Task<Api.Models.EpochParamContentResponse> GetLatestParametersAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            return await sut.GetLatestParametersAsync(cancellationToken);
        }
        /// <summary>
        ///     Testing Specific epoch <c>/epochs/{number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}/get">/epochs/{number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the epoch data.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}", "0.1.28")]
        [TestMethod]
        [DataRow(1)]
        public async Task GetEpochsAsync_Not_Null(int number)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            //Act
            var actual = await GetEpochsAsync(number, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochContentResponse));
        }

        /// <summary>
        ///     Testing Specific epoch <c>/epochs/{number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}/get">/epochs/{number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the epoch data.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}", "0.1.28")]
        private static async Task<Api.Models.EpochContentResponse> GetEpochsAsync(int number, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            return await sut.GetEpochsAsync(number, cancellationToken);
        }
        /// <summary>
        ///     Testing Listing of next epochs <c>/epochs/{number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1next/get">/epochs/{number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/next", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, 1)]
        public async Task GetNextAsync_Not_Null(int number, int? count, int? page)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            //Act
            var actual = await GetNextAsync(number, count, page, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochContentResponseCollection));
        }

        /// <summary>
        ///     Testing Listing of next epochs <c>/epochs/{number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1next/get">/epochs/{number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/next", "0.1.28")]
        private static async Task<Api.Models.EpochContentResponseCollection> GetNextAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            // count (optional) 
            // page (optional) 
            return await sut.GetNextAsync(number, count, page, cancellationToken);
        }
        /// <summary>
        ///     Testing Listing of previous epochs <c>/epochs/{number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1previous/get">/epochs/{number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/previous", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, 1)]
        public async Task GetPreviousAsync_Not_Null(int number, int? count, int? page)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            //Act
            var actual = await GetPreviousAsync(number, count, page, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochContentResponseCollection));
        }

        /// <summary>
        ///     Testing Listing of previous epochs <c>/epochs/{number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1previous/get">/epochs/{number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/previous", "0.1.28")]
        private static async Task<Api.Models.EpochContentResponseCollection> GetPreviousAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            // count (optional) 
            // page (optional) 
            return await sut.GetPreviousAsync(number, count, page, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake distribution <c>/epochs/{number}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes/get">/epochs/{number}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, 1)]
        public async Task GetStakesAsync_Not_Null(int number, int? count, int? page)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            //Act
            var actual = await GetStakesAsync(number, count, page, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochStakeContentResponseCollection));
        }

        /// <summary>
        ///     Testing Stake distribution <c>/epochs/{number}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes/get">/epochs/{number}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes", "0.1.28")]
        private static async Task<Api.Models.EpochStakeContentResponseCollection> GetStakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            // count (optional) 
            // page (optional) 
            return await sut.GetStakesAsync(number, count, page, cancellationToken);
        }
        /// <summary>
        ///     Testing Stake distribution by pool <c>/epochs/{number}/stakes/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes~1{pool_id}/get">/epochs/{number}/stakes/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes/{pool_id}", "0.1.28")]
        [TestMethod]
        [DataRow(1, null, 1, 1)]
        public async Task GetStakesAsync_Not_Null(int number, string pool_id, int? count, int? page)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetStakesAsync(number, pool_id, count, page, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochStakePoolContentResponseCollection));
        }

        /// <summary>
        ///     Testing Stake distribution by pool <c>/epochs/{number}/stakes/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes~1{pool_id}/get">/epochs/{number}/stakes/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes/{pool_id}", "0.1.28")]
        private static async Task<Api.Models.EpochStakePoolContentResponseCollection> GetStakesAsync(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            // pool_id  has null check
            // count (optional) 
            // page (optional) 
            return await sut.GetStakesAsync(number, pool_id, count, page, cancellationToken);
        }
        /// <summary>
        ///     Testing Block distribution <c>/epochs/{number}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks/get">/epochs/{number}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, 1, ESortOrder.Asc)]
        public async Task GetBlocksAsync_Not_Null(int number, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            //Act
            var actual = await GetBlocksAsync(number, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Block distribution <c>/epochs/{number}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks/get">/epochs/{number}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetBlocksAsync(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetBlocksAsync(number, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Block distribution by pool <c>/epochs/{number}/blocks/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks~1{pool_id}/get">/epochs/{number}/blocks/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks/{pool_id}", "0.1.28")]
        [TestMethod]
        [DataRow(1, null, 1, 1, ESortOrder.Asc)]
        public async Task GetBlocksAsync_Not_Null(int number, string pool_id, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            if (string.IsNullOrEmpty(pool_id))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                pool_id = pool.PoolId;
            }

            //Act
            var actual = await GetBlocksAsync(number, pool_id, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Block distribution by pool <c>/epochs/{number}/blocks/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks~1{pool_id}/get">/epochs/{number}/blocks/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks/{pool_id}", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetBlocksAsync(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            // pool_id  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetBlocksAsync(number, pool_id, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Protocol parameters <c>/epochs/{number}/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1parameters/get">/epochs/{number}/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/parameters", "0.1.28")]
        [TestMethod]
        [DataRow(1)]
        public async Task GetParametersAsync_Not_Null(int number)
        {
            // Arrange
            if (number == 1)
            {
                var epochsService = Provider.GetRequiredService<Api.Services.IEpochsService>();
                var latest = await epochsService.GetLatestAsync();
                number = (int)latest.Epoch;
            }

            //Act
            var actual = await GetParametersAsync(number, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.EpochParamContentResponse));
        }

        /// <summary>
        ///     Testing Protocol parameters <c>/epochs/{number}/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1parameters/get">/epochs/{number}/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/parameters", "0.1.28")]
        private static async Task<Api.Models.EpochParamContentResponse> GetParametersAsync(int number, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IEpochsService>();
            sut.ReadResponseAsString = true;
            // number  
            return await sut.GetParametersAsync(number, cancellationToken);
        }
    }
}

