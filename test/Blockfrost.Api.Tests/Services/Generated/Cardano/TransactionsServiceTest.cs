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
        public async Task GetTxsAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentResponse> GetTxsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsAsync(hash,  cancellationToken);
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
        public async Task GetTxsUtxosAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsUtxosAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentUtxoResponse> GetTxsUtxosAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsUtxosAsync(hash,  cancellationToken);
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
        public async Task GetTxsStakesAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsStakesAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentStakeAddrResponseCollection> GetTxsStakesAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsStakesAsync(hash,  cancellationToken);
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
        public async Task GetTxsDelegationsAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsDelegationsAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentDelegationsResponseCollection> GetTxsDelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsDelegationsAsync(hash,  cancellationToken);
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
        public async Task GetTxsWithdrawalsAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsWithdrawalsAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentWithdrawalsResponseCollection> GetTxsWithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsWithdrawalsAsync(hash,  cancellationToken);
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
        public async Task GetTxsMirsAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsMirsAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentMirsResponseCollection> GetTxsMirsAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsMirsAsync(hash,  cancellationToken);
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
        public async Task GetTxsPoolUpdatesAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsPoolUpdatesAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentPoolCertsResponseCollection> GetTxsPoolUpdatesAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsPoolUpdatesAsync(hash,  cancellationToken);
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
        public async Task GetTxsPoolRetiresAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsPoolRetiresAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentPoolRetiresResponseCollection> GetTxsPoolRetiresAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsPoolRetiresAsync(hash,  cancellationToken);
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
        public async Task GetTxsMetadataAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsMetadataAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentMetadataResponseCollection> GetTxsMetadataAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsMetadataAsync(hash,  cancellationToken);
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
        public async Task GetTxsMetadataCborAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsMetadataCborAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentMetadataCborResponseCollection> GetTxsMetadataCborAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsMetadataCborAsync(hash,  cancellationToken);
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
        public async Task GetTxsRedeemersAsync_Not_Null(string hash)
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
                var tx = await transactionsService.GetTxsUtxosAsync(txs.First());
                hash = tx.Hash;
            }

            //Act
            var actual = await GetTxsRedeemersAsync(hash, CancellationToken.None);

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
        private static async Task<Api.Models.TxContentRedeemersResponseCollection> GetTxsRedeemersAsync(string hash, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
            sut.ReadResponseAsString = true;
            // hash  has null check
            return await sut.GetTxsRedeemersAsync(hash,  cancellationToken);
        }
        /// <summary>
        ///     Testing Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        //[Post("/tx/submit", "0.1.28")]
        //[TestMethod]
        //[DataRow()]
        //public async Task PostTxSubmitAsync_Not_Null()
        //{
        //    var actual = await PostTxSubmitAsync(CancellationToken.None);
        //    Assert.IsNotNull(actual);
        //    Assert.IsInstanceOfType(actual, typeof(string));
        //}

        /// <summary>
        ///     Testing Submit a transaction <c>/tx/submit</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1tx~1submit/post">/tx/submit</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        //[Post("/tx/submit", "0.1.28")]
        //private async Task<string> PostTxSubmitAsync(CancellationToken cancellationToken)
        //{
        //    var sut = Provider.GetRequiredService<Api.Services.ITransactionsService>();
        //
        //    
        //    return await sut.PostTxSubmitAsync( cancellationToken);
        //}
    }
}

