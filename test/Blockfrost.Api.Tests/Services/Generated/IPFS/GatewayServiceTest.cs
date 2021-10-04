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
    public partial class GatewayServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Relay to an IPFS gateway <c>/ipfs/gateway/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway/paths/~1ipfs~1gateway~1{IPFS_path}/get">/ipfs/gateway/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the object content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/gateway/{IPFS_path}", "0.1.28")]
        [TestMethod]
        [Ignore("Needs specific input")]
        [DataRow(null)]
        public async Task GetGatewayAsync_Not_Null(string IPFS_path)
        {
            // Arrange
            //Act
            var actual = await GetGatewayAsync(IPFS_path, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(object));
        }

        /// <summary>
        ///     Testing Relay to an IPFS gateway <c>/ipfs/gateway/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway/paths/~1ipfs~1gateway~1{IPFS_path}/get">/ipfs/gateway/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the object content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/gateway/{IPFS_path}", "0.1.28")]
        private static async Task<object> GetGatewayAsync(string IPFS_path, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IGatewayService>();
            sut.ReadResponseAsString = true;
            // IPFS_path  has null check
            return await sut.GetGatewayAsync(IPFS_path, cancellationToken);
        }
    }
}

