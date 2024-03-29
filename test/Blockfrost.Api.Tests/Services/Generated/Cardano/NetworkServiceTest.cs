﻿using System.Linq;
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
    public partial class NetworkServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Network information <c>/network</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network/paths/~1network/get">/network</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/network", "0.1.28")]
        [TestMethod]
        [DataRow()]
        public async Task GetNetworkAsync_Not_Null()
        {
            // Arrange
            //Act
            var actual = await GetNetworkAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.NetworkResponse));
        }

        /// <summary>
        ///     Testing Network information <c>/network</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network/paths/~1network/get">/network</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/network", "0.1.28")]
        private static async Task<Api.Models.NetworkResponse> GetNetworkAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.INetworkService>();
            sut.ReadResponseAsString = true;
            return await sut.GetNetworkAsync(cancellationToken);
        }
    }
}

