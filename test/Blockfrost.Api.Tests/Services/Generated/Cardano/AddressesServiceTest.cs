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
    public partial class AddressesServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Specific address <c>/addresses/{address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}/get">/addresses/{address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetAddressesAsync_Not_Null(string address)
        {
            // Arrange
            if (string.IsNullOrEmpty(address))
            {
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await Provider.GetRequiredService<Api.Services.ITransactionsService>().GetTxsUtxosAsync(txs.First());
                address = tx.Inputs.First().Address;
                //from = (latest.Slot - 100).ToString(System.Globalization.CultureInfo.InvariantCulture);
                //to = latest.Slot.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            //Act
            var actual = await GetAddressesAsync(address, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AddressContentResponse));
        }

        /// <summary>
        ///     Testing Specific address <c>/addresses/{address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}/get">/addresses/{address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the address content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}", "0.1.28")]
        private static async Task<Api.Models.AddressContentResponse> GetAddressesAsync(string address, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAddressesService>();
            sut.ReadResponseAsString = true;
            // address  has null check
            return await sut.GetAddressesAsync(address, cancellationToken);
        }
        /// <summary>
        ///     Testing Address details <c>/addresses/{address}/total</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1total/get">/addresses/{address}/total</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/total", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetTotalAsync_Not_Null(string address)
        {
            // Arrange
            if (string.IsNullOrEmpty(address))
            {
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await Provider.GetRequiredService<Api.Services.ITransactionsService>().GetTxsUtxosAsync(txs.First());
                address = tx.Inputs.First().Address;
                //from = (latest.Slot - 100).ToString(System.Globalization.CultureInfo.InvariantCulture);
                //to = latest.Slot.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            //Act
            var actual = await GetTotalAsync(address, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AddressContentTotalResponse));
        }

        /// <summary>
        ///     Testing Address details <c>/addresses/{address}/total</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1total/get">/addresses/{address}/total</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <returns>Return the Address details.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/total", "0.1.28")]
        private static async Task<Api.Models.AddressContentTotalResponse> GetTotalAsync(string address, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAddressesService>();
            sut.ReadResponseAsString = true;
            // address  has null check
            return await sut.GetTotalAsync(address, cancellationToken);
        }
        /// <summary>
        ///     Testing Address UTXOs <c>/addresses/{address}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1utxos/get">/addresses/{address}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/utxos", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetUtxosAsync_Not_Null(string address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(address))
            {
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await Provider.GetRequiredService<Api.Services.ITransactionsService>().GetTxsUtxosAsync(txs.First());
                address = tx.Inputs.First().Address;
                //from = (latest.Slot - 100).ToString(System.Globalization.CultureInfo.InvariantCulture);
                //to = latest.Slot.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            //Act
            var actual = await GetUtxosAsync(address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AddressUtxoContentResponseCollection));
        }

        /// <summary>
        ///     Testing Address UTXOs <c>/addresses/{address}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1utxos/get">/addresses/{address}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/utxos", "0.1.28")]
        private static async Task<Api.Models.AddressUtxoContentResponseCollection> GetUtxosAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAddressesService>();
            sut.ReadResponseAsString = true;
            // address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetUtxosAsync(address, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Address transactions <c>/addresses/{address}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1txs/get">/addresses/{address}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of transactions per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/txs", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetTxsAsync_Not_Null(string address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(address))
            {
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await Provider.GetRequiredService<Api.Services.ITransactionsService>().GetTxsUtxosAsync(txs.First());
                address = tx.Inputs.First().Address;
                //from = (latest.Slot - 100).ToString(System.Globalization.CultureInfo.InvariantCulture);
                //to = latest.Slot.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            //Act
            var actual = await GetTxsAsync(address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.StringCollection));
        }

        /// <summary>
        ///     Testing Address transactions <c>/addresses/{address}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1txs/get">/addresses/{address}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="count">The number of transactions per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/txs", "0.1.28")]
        private static async Task<Api.Models.StringCollection> GetTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAddressesService>();
            sut.ReadResponseAsString = true;
            // address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTxsAsync(address, count, page, order, cancellationToken);
        }
        /// <summary>
        ///     Testing Address transactions <c>/addresses/{address}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1transactions/get">/addresses/{address}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="from">The block number and optionally also index from which (inclusive) to start search for results, concatenated using colon.Has to be lower than or equal to `to` parameter.</param>
        /// <param name="to">The block number and optionally also index where (inclusive) to end the search for results, concatenated using colon.Has to be higher than or equal to `from` parameter.</param>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/transactions", "0.1.28")]
        [TestMethod]
        [Ignore("Needs specific input")]
        [DataRow(null, null, null, 1, 1, ESortOrder.Asc)]
        public async Task GetTransactionsAsync_Not_Null(string address, string from, string to, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(address))
            {
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await Provider.GetRequiredService<Api.Services.ITransactionsService>().GetTxsUtxosAsync(txs.First());
                address = tx.Inputs.First().Address;
                //from = (latest.Slot - 100).ToString(System.Globalization.CultureInfo.InvariantCulture);
                //to = latest.Slot.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            //Act
            var actual = await GetTransactionsAsync(address, from, to, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AddressTransactionsContentResponseCollection));
        }

        /// <summary>
        ///     Testing Address transactions <c>/addresses/{address}/transactions</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Addresses/paths/~1addresses~1{address}~1transactions/get">/addresses/{address}/transactions</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="from">The block number and optionally also index from which (inclusive) to start search for results, concatenated using colon.Has to be lower than or equal to `to` parameter.</param>
        /// <param name="to">The block number and optionally also index where (inclusive) to end the search for results, concatenated using colon.Has to be higher than or equal to `from` parameter.</param>
        /// <param name="count">The numbers of pools per page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the address content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/addresses/{address}/transactions", "0.1.28")]
        private static async Task<Api.Models.AddressTransactionsContentResponseCollection> GetTransactionsAsync(string address, string from, string to, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAddressesService>();
            sut.ReadResponseAsString = true;
            // address  has null check
            // from  
            // to  
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetTransactionsAsync(address, from, to, count, page, order, cancellationToken);
        }
    }
}

