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
    public partial class MetadataServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Transaction metadata labels <c>/metadata/txs/labels</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels/get">/metadata/txs/labels</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels", "0.1.28")]
        [TestMethod]
        [DataRow(1, 1, ESortOrder.Asc)]
        public async Task GetTxsLabelsAsync_Not_Null(int? count, int? page, ESortOrder? order)
        {
            // Arrange

            //Act
            var actual = await GetTxsLabelsAsync(count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxMetadataLabelsResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction metadata labels <c>/metadata/txs/labels</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels/get">/metadata/txs/labels</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels", "0.1.28")]
        private static async Task<Api.Models.TxMetadataLabelsResponseCollection> GetTxsLabelsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IMetadataService>();
            sut.ReadResponseAsString = true;
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTxsLabelsAsync(count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction metadata content in JSON <c>/metadata/txs/labels/{label}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}/get">/metadata/txs/labels/{label}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetTxsLabelsAsync_Not_Null(string label, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(label))
            {
                label = "1990";
            }

            //Act
            var actual = await GetTxsLabelsAsync(label, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxMetadataLabelJsonResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction metadata content in JSON <c>/metadata/txs/labels/{label}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}/get">/metadata/txs/labels/{label}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}", "0.1.28")]
        private static async Task<Api.Models.TxMetadataLabelJsonResponseCollection> GetTxsLabelsAsync(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IMetadataService>();
            sut.ReadResponseAsString = true;
            // label  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTxsLabelsAsync(label, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction metadata content in CBOR <c>/metadata/txs/labels/{label}/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}~1cbor/get">/metadata/txs/labels/{label}/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}/cbor", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetTxsLabelsCborAsync_Not_Null(string label, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(label))
            {
                label = "1990";
            }

            //Act
            var actual = await GetTxsLabelsCborAsync(label, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxMetadataLabelCborResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction metadata content in CBOR <c>/metadata/txs/labels/{label}/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Metadata/paths/~1metadata~1txs~1labels~1{label}~1cbor/get">/metadata/txs/labels/{label}/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="label">Metadata label</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metadata/txs/labels/{label}/cbor", "0.1.28")]
        private static async Task<Api.Models.TxMetadataLabelCborResponseCollection> GetTxsLabelsCborAsync(string label, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IMetadataService>();
            sut.ReadResponseAsString = true;
            // label  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTxsLabelsCborAsync(label, count, page, order,  cancellationToken);
        }
    }
}

