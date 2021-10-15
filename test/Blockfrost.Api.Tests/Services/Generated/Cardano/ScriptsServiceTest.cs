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
    public partial class ScriptsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Scripts <c>/scripts</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts/get">/scripts</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of scripts</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetScriptsAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange
            //Act
            var actual = await GetScriptsAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.ScriptsResponseCollection));
        }

        /// <summary>
        ///     Testing Scripts <c>/scripts</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts/get">/scripts</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of scripts</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts", "0.1.28")]
        private static async Task<Api.Models.ScriptsResponseCollection> GetScriptsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IScriptsService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetScriptsAsync(count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Specific script <c>/scripts/{script_hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}/get">/scripts/{script_hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <returns>Return the information about a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetScriptsAsync_Not_Null(string script_hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(script_hash))
            {
                var scriptsService = Provider.GetRequiredService<Api.Services.IScriptsService>();
                var script = await scriptsService.GetScriptsAsync(1, 1, ESortOrder.Asc);
                script_hash = script.First().ScriptHash;
            }

            //Act
            var actual = await GetScriptsAsync(script_hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.ScriptResponse));
        }

        /// <summary>
        ///     Testing Specific script <c>/scripts/{script_hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}/get">/scripts/{script_hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <returns>Return the information about a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}", "0.1.28")]
        private static async Task<Api.Models.ScriptResponse> GetScriptsAsync(string script_hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IScriptsService>();
            sut.ReadResponseAsString = true;
            // script_hash  has null check
            return await sut.GetScriptsAsync(script_hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Redeemers of a specific script <c>/scripts/{script_hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}~1redeemers/get">/scripts/{script_hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about redeemers of a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}/redeemers", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetRedeemersAsync_Not_Null(string script_hash, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(script_hash))
            {
                var scriptsService = Provider.GetRequiredService<Api.Services.IScriptsService>();
                var script = await scriptsService.GetScriptsAsync(1, 1, ESortOrder.Asc);
                script_hash = script.First().ScriptHash;
            }

            //Act
            var actual = await GetRedeemersAsync(script_hash, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.ScriptRedeemersResponseCollection));
        }

        /// <summary>
        ///     Testing Redeemers of a specific script <c>/scripts/{script_hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}~1redeemers/get">/scripts/{script_hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about redeemers of a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}/redeemers", "0.1.28")]
        private static async Task<Api.Models.ScriptRedeemersResponseCollection> GetRedeemersAsync(string script_hash, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IScriptsService>();
            sut.ReadResponseAsString = true;
            // script_hash  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetRedeemersAsync(script_hash, count, page, order, cancellationToken);
        }
    }
}

