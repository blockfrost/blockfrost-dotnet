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
    public partial class HealthServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Root endpoint <c>/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1/get">/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetApiInfoAsync_Not_Null()
        {
            // Arrange

            //Act
            var actual = await GetApiInfoAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.InfoResponse));
        }

        /// <summary>
        ///     Testing Root endpoint <c>/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1/get">/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/", "0.1.28")]
        private static async Task<Api.Models.InfoResponse> GetApiInfoAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IHealthService>();
            sut.ReadResponseAsString = true;
            return await sut.GetApiInfoAsync(cancellationToken);
        }
        /// <summary>
        ///     Testing Backend health status <c>/health</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health/get">/health</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetHealthAsync_Not_Null()
        {
            // Arrange

            //Act
            var actual = await GetHealthAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.HealthResponse));
        }

        /// <summary>
        ///     Testing Backend health status <c>/health</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health/get">/health</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health", "0.1.28")]
        private static async Task<Api.Models.HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IHealthService>();
            sut.ReadResponseAsString = true;
            return await sut.GetHealthAsync(cancellationToken);
        }
        /// <summary>
        ///     Testing Current backend time <c>/health/clock</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health~1clock/get">/health/clock</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health/clock", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetClockAsync_Not_Null()
        {
            // Arrange

            //Act
            var actual = await GetClockAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.HealthClockResponse));
        }

        /// <summary>
        ///     Testing Current backend time <c>/health/clock</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health~1clock/get">/health/clock</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health/clock", "0.1.28")]
        private static async Task<Api.Models.HealthClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IHealthService>();
            sut.ReadResponseAsString = true;
            return await sut.GetClockAsync(cancellationToken);
        }
    }
}

