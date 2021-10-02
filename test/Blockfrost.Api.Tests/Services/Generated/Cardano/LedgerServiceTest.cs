using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
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
        private async Task<Api.Models.GenesisContentResponse> GetGenesisAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ILedgerService>();

            return await sut.GetGenesisAsync( cancellationToken);
        }
    }
}

