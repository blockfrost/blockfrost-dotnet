using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;
using Blockfrost.Api.Tests.Attributes;
using System.IO;
using Blockfrost.Api.Models;
using Blockfrost.Api.Services;

namespace Blockfrost.Api.Tests.Services
{
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Services))]
    [TestCategory(nameof(Integration))]
    [TestCategory(Constants.NETWORK_IPFS)]
    public partial class AddServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_IPFS, context);
        }

        /// <summary>
        ///     Testing Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/add", "0.1.28")]
        [VectorTestMethod("99", "sunset.jpg")]
        public async Task PostAddAsync_Not_Null(FileInfo info)
        {
            using var stream = info.OpenRead();
            var response = await PostAddAsync(stream, CancellationToken.None);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(AddContentResponse));
            Assert.AreEqual(response.IpfsHash, "QmR8x7pEQUr1CGxstkd48ZPKi2y1bBBtq7ozZRJWLpbA1M");
        }

        /// <summary>
        ///     Testing Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/add", "0.1.28")]
        private async Task<AddContentResponse> PostAddAsync(FileStream stream, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<IIPFSService>();
            sut.ReadResponseAsString = true;
            return await sut.Add.PostAddAsync(stream, cancellationToken);
        }
    }
}

