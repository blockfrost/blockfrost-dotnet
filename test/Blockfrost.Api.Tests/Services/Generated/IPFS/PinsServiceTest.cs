using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;
using Blockfrost.Api.Tests.Attributes;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Tests.Services
{
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Services))]
    [TestCategory(nameof(Integration))]
    [TestCategory(Constants.NETWORK_IPFS)]
    public partial class PinsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_IPFS, context);
        }

        /// <summary>
        ///     Testing Pin an object <c>/ipfs/pin/add/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1add~1{IPFS_path}/post">/ipfs/pin/add/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="ipfsPath"></param>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/add/{IPFS_path}", "0.1.28")]
        [TestMethod]
        [Priority(1)]
        [DataRow("QmR8x7pEQUr1CGxstkd48ZPKi2y1bBBtq7ozZRJWLpbA1M")]
        public async Task PostPinAddAsync_Not_Null(string ipfsPath)
        {
            var actual = await PostPinAddAsync(ipfsPath, CancellationToken.None);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(PinStateContentResponse));
        }

        /// <summary>
        ///     Testing Pin an object <c>/ipfs/pin/add/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1add~1{IPFS_path}/post">/ipfs/pin/add/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="content"></param>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/add/{IPFS_path}", "0.1.28")]
        private async Task<PinStateContentResponse> PostPinAddAsync(string ipfsPath, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPinsService>();
            sut.ReadResponseAsString = true;
            // content  
            return await sut.PostPinAddAsync(ipfsPath,  cancellationToken);
        }
        /// <summary>
        ///     Testing List pinned objects <c>/ipfs/pin/list/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1/get">/ipfs/pin/list/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/", "0.1.28")]
        [Priority(2)]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetPinListAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange
            //Act
            var actual = await GetPinListAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IpfsPinListResponseCollection));
        }

        /// <summary>
        ///     Testing List pinned objects <c>/ipfs/pin/list/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1/get">/ipfs/pin/list/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/", "0.1.28")]
        private static async Task<IpfsPinListResponseCollection> GetPinListAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPinsService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetPinListAsync(count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Get details about pinned object <c>/ipfs/pin/list/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1{IPFS_path}/get">/ipfs/pin/list/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/{IPFS_path}", "0.1.28")]
        [Priority(3)]
        [TestMethod]
        [DataRow("QmR8x7pEQUr1CGxstkd48ZPKi2y1bBBtq7ozZRJWLpbA1M")]
        public async Task GetPinListAsyncPath_Not_Null(string IPFS_path)
        {
            // Arrange
            //Act
            var actual = await GetPinListAsync(IPFS_path, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IpfsPinListIPFSPathResponse));
        }

        /// <summary>
        ///     Testing Get details about pinned object <c>/ipfs/pin/list/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1{IPFS_path}/get">/ipfs/pin/list/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/{IPFS_path}", "0.1.28")]
        private static async Task<IpfsPinListIPFSPathResponse> GetPinListAsync(string IPFS_path, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPinsService>();
            sut.ReadResponseAsString = true;
            // IPFS_path  has null check
            return await sut.GetPinListAsync(IPFS_path, cancellationToken);
        }
        /// <summary>
        ///     Testing  <c>/ipfs/pin/remove/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1remove~1{IPFS_path}/post">/ipfs/pin/remove/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="content"></param>
        /// <returns>Returns the pins removed</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/remove/{IPFS_path}", "0.1.28")]
        [TestMethod]
        [Priority(4)]
        [DataRow("QmR8x7pEQUr1CGxstkd48ZPKi2y1bBBtq7ozZRJWLpbA1M")]
        public async Task PostPinRemoveAsync_Not_Null(string ipfsPath)
        {
            var actual = await PostPinRemoveAsync(ipfsPath, CancellationToken.None);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(PinStateContentResponse));
        }

        /// <summary>
        ///     Testing  <c>/ipfs/pin/remove/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1remove~1{IPFS_path}/post">/ipfs/pin/remove/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="ipfsPath"></param>
        /// <returns>Returns the pins removed</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/remove/{IPFS_path}", "0.1.28")]
        private async Task<PinStateContentResponse> PostPinRemoveAsync(string ipfsPath, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IPinsService>();

            // content  
            return await sut.PostPinRemoveAsync(ipfsPath, cancellationToken);
        }
    }
}

