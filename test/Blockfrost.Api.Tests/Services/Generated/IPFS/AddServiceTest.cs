using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public partial class AddServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        //[Post("/ipfs/add", "0.1.28")]
        //[TestMethod]
        //[DataRow()]
        //public async Task PostAddAsync_Not_Null()
        //{
        //    var actual = await PostAddAsync(CancellationToken.None);
        //    Assert.IsNotNull(actual);
        //    Assert.IsInstanceOfType(actual, typeof(string));
        //}

        /// <summary>
        ///     Testing Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        //[Post("/ipfs/add", "0.1.28")]
        //private async Task<string> PostAddAsync(CancellationToken cancellationToken)
        //{
        //    var sut = Provider.GetRequiredService<Api.Services.IAddService>();
        //
        //    
        //    return await sut.PostAddAsync( cancellationToken);
        //}
    }
}

