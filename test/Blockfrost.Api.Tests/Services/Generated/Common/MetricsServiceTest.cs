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
    public partial class MetricsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Blockfrost usage metrics <c>/metrics/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1/get">/metrics/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetMetricsAsync_Not_Null()
        {
            // Arrange
            //Act
            var actual = await GetMetricsAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.MetricsResponseCollection));
        }

        /// <summary>
        ///     Testing Blockfrost usage metrics <c>/metrics/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1/get">/metrics/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/", "0.1.28")]
        private static async Task<Api.Models.MetricsResponseCollection> GetMetricsAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IMetricsService>();
            sut.ReadResponseAsString = true;
            return await sut.GetMetricsAsync(cancellationToken);
        }
        /// <summary>
        ///     Testing Blockfrost endpoint usage metrics <c>/metrics/endpoints</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1endpoints/get">/metrics/endpoints</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/endpoints", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetEndpointsAsync_Not_Null()
        {
            // Arrange
            //Act
            var actual = await GetEndpointsAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.MetricsEndpointsResponseCollection));
        }

        /// <summary>
        ///     Testing Blockfrost endpoint usage metrics <c>/metrics/endpoints</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1endpoints/get">/metrics/endpoints</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/endpoints", "0.1.28")]
        private static async Task<Api.Models.MetricsEndpointsResponseCollection> GetEndpointsAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IMetricsService>();
            sut.ReadResponseAsString = true;
            return await sut.GetEndpointsAsync(cancellationToken);
        }
    }
}

