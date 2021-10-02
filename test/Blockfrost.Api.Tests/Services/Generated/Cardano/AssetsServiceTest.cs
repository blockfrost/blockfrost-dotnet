using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public partial class AssetsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Assets <c>/assets</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets/get">/assets</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetAssetsAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetAssetsAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AssetsResponseCollection));
        }

        /// <summary>
        ///     Testing Assets <c>/assets</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets/get">/assets</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets", "0.1.28")]
        private async Task<Api.Models.AssetsResponseCollection> GetAssetsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetAssetsAsync(count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Specific asset <c>/assets/{asset}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}/get">/assets/{asset}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetAssetsAsync_Not_Null(string asset)
        {
            // Arrange

            //Act
            var actual = await GetAssetsAsync(asset, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AssetResponse));
        }

        /// <summary>
        ///     Testing Specific asset <c>/assets/{asset}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}/get">/assets/{asset}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}", "0.1.28")]
        private async Task<Api.Models.AssetResponse> GetAssetsAsync(string asset, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // asset  has null check
            return await sut.GetAssetsAsync(asset,  cancellationToken);
        }
        /// <summary>
        ///     Testing Asset history <c>/assets/{asset}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1history/get">/assets/{asset}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/history", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetHistoryAsync_Not_Null(string asset, int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetHistoryAsync(asset, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AssetHistoryResponseCollection));
        }

        /// <summary>
        ///     Testing Asset history <c>/assets/{asset}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1history/get">/assets/{asset}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/history", "0.1.28")]
        private async Task<Api.Models.AssetHistoryResponseCollection> GetHistoryAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // asset  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetHistoryAsync(asset, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Asset transactions <c>/assets/{asset}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1txs/get">/assets/{asset}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/txs", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetTxsAsync_Not_Null(string asset, int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetTxsAsync(asset, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Asset transactions <c>/assets/{asset}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1txs/get">/assets/{asset}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/txs", "0.1.28")]
        private async Task<Api.Models.StringCollection> GetTxsAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // asset  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTxsAsync(asset, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Asset transactions <c>/assets/{asset}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1transactions/get">/assets/{asset}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/transactions", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetTransactionsAsync_Not_Null(string asset, int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetTransactionsAsync(asset, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AssetTransactionsResponseCollection));
        }

        /// <summary>
        ///     Testing Asset transactions <c>/assets/{asset}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1transactions/get">/assets/{asset}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/transactions", "0.1.28")]
        private async Task<Api.Models.AssetTransactionsResponseCollection> GetTransactionsAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // asset  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTransactionsAsync(asset, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Asset addresses <c>/assets/{asset}/addresses</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1addresses/get">/assets/{asset}/addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/addresses", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetAddressesAsync_Not_Null(string asset, int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetAddressesAsync(asset, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AssetAddressesResponseCollection));
        }

        /// <summary>
        ///     Testing Asset addresses <c>/assets/{asset}/addresses</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}~1addresses/get">/assets/{asset}/addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}/addresses", "0.1.28")]
        private async Task<Api.Models.AssetAddressesResponseCollection> GetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // asset  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetAddressesAsync(asset, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Assets of a specific policy <c>/assets/policy/{policy_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1policy~1{policy_id}/get">/assets/policy/{policy_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/policy/{policy_id}", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetPolicyAsync_Not_Null(string policy_id, int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetPolicyAsync(policy_id, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AssetPolicyResponseCollection));
        }

        /// <summary>
        ///     Testing Assets of a specific policy <c>/assets/policy/{policy_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1policy~1{policy_id}/get">/assets/policy/{policy_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/policy/{policy_id}", "0.1.28")]
        private async Task<Api.Models.AssetPolicyResponseCollection> GetPolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();

            // policy_id  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetPolicyAsync(policy_id, count, page, order,  cancellationToken);
        }
    }
}

