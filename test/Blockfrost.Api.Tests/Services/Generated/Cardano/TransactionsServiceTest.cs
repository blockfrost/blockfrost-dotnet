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
    public partial class TransactionsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Specific transaction <c>/txs/{hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}/get">/txs/{hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentResponse));
        }

        /// <summary>
        ///     Testing Specific transaction <c>/txs/{hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}/get">/txs/{hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}", "0.1.28")]
        private static async Task<Api.Models.TxContentResponse> GetAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction UTXOs <c>/txs/{hash}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1utxos/get">/txs/{hash}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/utxos", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetUtxosAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetUtxosAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentUtxoResponse));
        }

        /// <summary>
        ///     Testing Transaction UTXOs <c>/txs/{hash}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1utxos/get">/txs/{hash}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/utxos", "0.1.28")]
        private static async Task<Api.Models.TxContentUtxoResponse> GetUtxosAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetUtxosAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction stake addresses certificates <c>/txs/{hash}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1stakes/get">/txs/{hash}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/stakes", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetStakesAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetStakesAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentStakeAddrResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction stake addresses certificates <c>/txs/{hash}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1stakes/get">/txs/{hash}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/stakes", "0.1.28")]
        private static async Task<Api.Models.TxContentStakeAddrResponseCollection> GetStakesAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetStakesAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction delegation certificates <c>/txs/{hash}/delegations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1delegations/get">/txs/{hash}/delegations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/delegations", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetDelegationsAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetDelegationsAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentDelegationsResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction delegation certificates <c>/txs/{hash}/delegations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1delegations/get">/txs/{hash}/delegations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/delegations", "0.1.28")]
        private static async Task<Api.Models.TxContentDelegationsResponseCollection> GetDelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetDelegationsAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction withdrawal <c>/txs/{hash}/withdrawals</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1withdrawals/get">/txs/{hash}/withdrawals</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/withdrawals", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetWithdrawalsAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetWithdrawalsAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentWithdrawalsResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction withdrawal <c>/txs/{hash}/withdrawals</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1withdrawals/get">/txs/{hash}/withdrawals</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/withdrawals", "0.1.28")]
        private static async Task<Api.Models.TxContentWithdrawalsResponseCollection> GetWithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetWithdrawalsAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction MIRs <c>/txs/{hash}/mirs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1mirs/get">/txs/{hash}/mirs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/mirs", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetMirsAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetMirsAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentMirsResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction MIRs <c>/txs/{hash}/mirs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1mirs/get">/txs/{hash}/mirs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/mirs", "0.1.28")]
        private static async Task<Api.Models.TxContentMirsResponseCollection> GetMirsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetMirsAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction stake pool registration and update certificates <c>/txs/{hash}/pool_updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1pool_updates/get">/txs/{hash}/pool_updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/pool_updates", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetPoolUpdatesAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetPoolUpdatesAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentPoolCertsResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction stake pool registration and update certificates <c>/txs/{hash}/pool_updates</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1pool_updates/get">/txs/{hash}/pool_updates</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/pool_updates", "0.1.28")]
        private static async Task<Api.Models.TxContentPoolCertsResponseCollection> GetPoolUpdatesAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetPoolUpdatesAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction stake pool retirement certificates <c>/txs/{hash}/pool_retires</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1pool_retires/get">/txs/{hash}/pool_retires</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/pool_retires", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetPoolRetiresAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetPoolRetiresAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentPoolRetiresResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction stake pool retirement certificates <c>/txs/{hash}/pool_retires</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1pool_retires/get">/txs/{hash}/pool_retires</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/pool_retires", "0.1.28")]
        private static async Task<Api.Models.TxContentPoolRetiresResponseCollection> GetPoolRetiresAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetPoolRetiresAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction metadata <c>/txs/{hash}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1metadata/get">/txs/{hash}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/metadata", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetMetadataAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetMetadataAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentMetadataResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction metadata <c>/txs/{hash}/metadata</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1metadata/get">/txs/{hash}/metadata</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/metadata", "0.1.28")]
        private static async Task<Api.Models.TxContentMetadataResponseCollection> GetMetadataAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetMetadataAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction metadata in CBOR <c>/txs/{hash}/metadata/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1metadata~1cbor/get">/txs/{hash}/metadata/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/metadata/cbor", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetMetadataCborAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetMetadataCborAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentMetadataCborResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction metadata in CBOR <c>/txs/{hash}/metadata/cbor</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1metadata~1cbor/get">/txs/{hash}/metadata/cbor</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/metadata/cbor", "0.1.28")]
        private static async Task<Api.Models.TxContentMetadataCborResponseCollection> GetMetadataCborAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetMetadataCborAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Transaction redeemers <c>/txs/{hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1redeemers/get">/txs/{hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about redeemers within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/redeemers", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetRedeemersAsync_Not_Null(string hash)
        {
            // Arrange
            if (string.IsNullOrEmpty(hash))
            {
                var transactionsService = Provider.GetRequiredService<Api.Services.ITransactionsService>();
                var blocksService = Provider.GetRequiredService<Api.Services.IBlocksService>();
                var latest = await blocksService.GetLatestAsync();

                while (latest.TxCount == 0)
                {
                    latest = await blocksService.GetBlocksAsync(latest.PreviousBlock);
                }

                var txs = await blocksService.GetTxsAsync(latest.Hash, 1, 1, ESortOrder.Desc);
                var tx = await transactionsService.GetUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetRedeemersAsync(hash, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.TxContentRedeemersResponseCollection));
        }

        /// <summary>
        ///     Testing Transaction redeemers <c>/txs/{hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1redeemers/get">/txs/{hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about redeemers within a specific transaction.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/redeemers", "0.1.28")]
        private static async Task<Api.Models.TxContentRedeemersResponseCollection> GetRedeemersAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetRedeemersAsync(hash, cancellationToken);
        }
        /// <summary>
        ///     Testing Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.28")]
        [TestMethod]
        [Ignore("Needs specific input")]
        [DataRow()]
        public async Task PostTxSubmitAsync_Not_Null()
        {
            var actual = await PostTxSubmitAsync(CancellationToken.None);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(string));
        }

        /// <summary>
        ///     Testing Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/tx/submit", "0.1.28")]
        private async Task<string> PostTxSubmitAsync(CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            var stream = new System.IO.MemoryStream();
            return await sut.PostTxSubmitAsync(stream, cancellationToken);
        }
    }
}

