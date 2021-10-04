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
    public partial class LedgerServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Blockchain genesis <c>/genesis</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger/paths/~1genesis/get">/genesis</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/genesis", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetGenesisAsync_Not_Null()
        {
            // Arrange
            //Act
            var actual = await GetGenesisAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.GenesisContentResponse));
        }

        /// <summary>
        ///     Testing Blockchain genesis <c>/genesis</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger/paths/~1genesis/get">/genesis</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/genesis", "0.1.28")]
        private static async Task<Api.Models.GenesisContentResponse> GetGenesisAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ILedgerService>();
            sut.ReadResponseAsString = true;
            return await sut.GetGenesisAsync(cancellationToken);
        }
    }
}

