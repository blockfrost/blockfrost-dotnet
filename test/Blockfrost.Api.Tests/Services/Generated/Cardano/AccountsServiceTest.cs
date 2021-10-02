using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public partial class AccountsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        /// <summary>
        ///     Testing Specific account address <c>/accounts/{stake_address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}/get">/accounts/{stake_address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}", "0.1.28")]
        [TestMethod]
        [DataRow(null)]
        public async Task GetAccountsAsync_Not_Null(string stake_address)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetAccountsAsync(stake_address, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountContentResponse));
        }

        /// <summary>
        ///     Testing Specific account address <c>/accounts/{stake_address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}/get">/accounts/{stake_address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}", "0.1.28")]
        private async Task<Api.Models.AccountContentResponse> GetAccountsAsync(string stake_address, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            return await sut.GetAccountsAsync(stake_address,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account reward history <c>/accounts/{stake_address}/rewards</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1rewards/get">/accounts/{stake_address}/rewards</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/rewards", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetRewardsAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetRewardsAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountRewardContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account reward history <c>/accounts/{stake_address}/rewards</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1rewards/get">/accounts/{stake_address}/rewards</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/rewards", "0.1.28")]
        private async Task<Api.Models.AccountRewardContentResponseCollection> GetRewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetRewardsAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account history <c>/accounts/{stake_address}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1history/get">/accounts/{stake_address}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/history", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetHistoryAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetHistoryAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountHistoryContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account history <c>/accounts/{stake_address}/history</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1history/get">/accounts/{stake_address}/history</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/history", "0.1.28")]
        private async Task<Api.Models.AccountHistoryContentResponseCollection> GetHistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetHistoryAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account delegation history <c>/accounts/{stake_address}/delegations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1delegations/get">/accounts/{stake_address}/delegations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/delegations", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetDelegationsAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetDelegationsAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountDelegationContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account delegation history <c>/accounts/{stake_address}/delegations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1delegations/get">/accounts/{stake_address}/delegations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/delegations", "0.1.28")]
        private async Task<Api.Models.AccountDelegationContentResponseCollection> GetDelegationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetDelegationsAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account registration history <c>/accounts/{stake_address}/registrations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1registrations/get">/accounts/{stake_address}/registrations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account registration content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/registrations", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetRegistrationsAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetRegistrationsAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountRegistrationContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account registration history <c>/accounts/{stake_address}/registrations</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1registrations/get">/accounts/{stake_address}/registrations</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account registration content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/registrations", "0.1.28")]
        private async Task<Api.Models.AccountRegistrationContentResponseCollection> GetRegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetRegistrationsAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account withdrawal history <c>/accounts/{stake_address}/withdrawals</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1withdrawals/get">/accounts/{stake_address}/withdrawals</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account withdrawal content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/withdrawals", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetWithdrawalsAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetWithdrawalsAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountWithdrawalContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account withdrawal history <c>/accounts/{stake_address}/withdrawals</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1withdrawals/get">/accounts/{stake_address}/withdrawals</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account withdrawal content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/withdrawals", "0.1.28")]
        private async Task<Api.Models.AccountWithdrawalContentResponseCollection> GetWithdrawalsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetWithdrawalsAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account MIR history <c>/accounts/{stake_address}/mirs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1mirs/get">/accounts/{stake_address}/mirs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account MIR content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/mirs", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetMirsAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetMirsAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountMirContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account MIR history <c>/accounts/{stake_address}/mirs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1mirs/get">/accounts/{stake_address}/mirs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account MIR content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/mirs", "0.1.28")]
        private async Task<Api.Models.AccountMirContentResponseCollection> GetMirsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetMirsAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Account associated addresses <c>/accounts/{stake_address}/addresses</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1addresses/get">/accounts/{stake_address}/addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/addresses", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetAddressesAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetAddressesAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountAddressesContentResponseCollection));
        }

        /// <summary>
        ///     Testing Account associated addresses <c>/accounts/{stake_address}/addresses</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1addresses/get">/accounts/{stake_address}/addresses</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/addresses", "0.1.28")]
        private async Task<Api.Models.AccountAddressesContentResponseCollection> GetAddressesAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetAddressesAsync(stake_address, count, page, order,  cancellationToken);
        }
        /// <summary>
        ///     Testing Assets associated with the account addresses <c>/accounts/{stake_address}/addresses/assets</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1addresses~1assets/get">/accounts/{stake_address}/addresses/assets</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/addresses/assets", "0.1.28")]
        [TestMethod]
        [DataRow(null, 1, 1, ESortOrder.Asc)]
        public async Task GetAddressesAssetsAsync_Not_Null(string stake_address, int? count, int? page, ESortOrder? order)
        {
            // Arrange
            if (string.IsNullOrEmpty(stake_address))
            {
                var block = await Provider.GetRequiredService<Api.Services.IBlocksService>().GetLatestAsync();
                var pool = await Provider.GetRequiredService<Api.Services.IPoolsService>().GetPoolsAsync(block.SlotLeader);
                stake_address = pool.RewardAccount;
            }

            //Act
            var actual = await GetAddressesAssetsAsync(stake_address, count, page, order, CancellationToken.None);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Api.Models.AccountAddressesAssetsResponseCollection));
        }

        /// <summary>
        ///     Testing Assets associated with the account addresses <c>/accounts/{stake_address}/addresses/assets</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}~1addresses~1assets/get">/accounts/{stake_address}/addresses/assets</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}/addresses/assets", "0.1.28")]
        private async Task<Api.Models.AccountAddressesAssetsResponseCollection> GetAddressesAssetsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAccountsService>();

            // stake_address  has null check
            // count (optional) 
            // page (optional) 
            // order (optional) 
            return await sut.GetAddressesAssetsAsync(stake_address, count, page, order,  cancellationToken);
        }
    }
}

