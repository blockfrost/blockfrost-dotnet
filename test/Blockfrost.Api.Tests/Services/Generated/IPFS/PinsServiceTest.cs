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
    public partial class PinsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
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
        //[Post("/ipfs/pin/add/{IPFS_path}", "0.1.28")]
        //[TestMethod]
        //[DataRow("")]
        //public async Task PostPinAddAsync_Not_Null(System.IO.Stream content)
        //{
        //    var actual = await PostPinAddAsync(content, CancellationToken.None);
        //    Assert.IsNotNull(actual);
        //    Assert.IsInstanceOfType(actual, typeof(string));
        //}

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
        //[Post("/ipfs/pin/add/{IPFS_path}", "0.1.28")]
        //private async Task<string> PostPinAddAsync(System.IO.Stream content, CancellationToken cancellationToken)
        //{
        //    var sut = Provider.GetRequiredService<Api.Services.IPinsService>();
        //
        //    
        //    // content  
        //    
        //    return await sut.PostPinAddAsync(content,  cancellationToken);
        //}
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
        //[TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetPinListAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetPinListAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.IpfsPinListResponseCollection));
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
        private static async Task<Api.Models.IpfsPinListResponseCollection> GetPinListAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
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
        //[TestMethod]
        [DataRow(null)]
        public async Task GetPinListAsync_Not_Null(string IPFS_path)
        {
            // Arrange

            //Act
            var actual = await GetPinListAsync(IPFS_path, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.IpfsPinListIPFSPathResponse));
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
        private static async Task<Api.Models.IpfsPinListIPFSPathResponse> GetPinListAsync(string IPFS_path, CancellationToken cancellationToken)
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
        //[Post("/ipfs/pin/remove/{IPFS_path}", "0.1.28")]
        //[TestMethod]
        //[DataRow("")]
        //public async Task PostPinRemoveAsync_Not_Null(System.IO.Stream content)
        //{
        //    var actual = await PostPinRemoveAsync(content, CancellationToken.None);
        //    Assert.IsNotNull(actual);
        //    Assert.IsInstanceOfType(actual, typeof(string));
        //}

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
        //[Post("/ipfs/pin/remove/{IPFS_path}", "0.1.28")]
        //private async Task<string> PostPinRemoveAsync(System.IO.Stream content, CancellationToken cancellationToken)
        //{
        //    var sut = Provider.GetRequiredService<Api.Services.IPinsService>();
        //
        //    
        //    // content  
        //    
        //    return await sut.PostPinRemoveAsync(content,  cancellationToken);
        //}
    }
}

