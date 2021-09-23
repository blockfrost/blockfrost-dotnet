using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IAccountsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Specific account address <c>/accounts/{stake_address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}/get">/accounts/{stake_address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}", "0.1.27")]
        Task<Models.AccountContentResponse> GetAccountsAsync(string stake_address);

        /// <summary>
        ///     Specific account address <c>/accounts/{stake_address}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts/paths/~1accounts~1{stake_address}/get">/accounts/{stake_address}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/accounts/{stake_address}", "0.1.27")]
        Task<Models.AccountContentResponse> GetAccountsAsync(string stake_address, CancellationToken cancellationToken);
        /// <summary>
        ///     Account reward history <c>/accounts/{stake_address}/rewards</c>
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
        [Get("/accounts/{stake_address}/rewards", "0.1.27")]
        Task<Models.AccountRewardContentResponseCollection> GetRewardsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account reward history <c>/accounts/{stake_address}/rewards</c>
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
        [Get("/accounts/{stake_address}/rewards", "0.1.27")]
        Task<Models.AccountRewardContentResponseCollection> GetRewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Account history <c>/accounts/{stake_address}/history</c>
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
        [Get("/accounts/{stake_address}/history", "0.1.27")]
        Task<Models.AccountHistoryContentResponseCollection> GetHistoryAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account history <c>/accounts/{stake_address}/history</c>
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
        [Get("/accounts/{stake_address}/history", "0.1.27")]
        Task<Models.AccountHistoryContentResponseCollection> GetHistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Account delegation history <c>/accounts/{stake_address}/delegations</c>
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
        [Get("/accounts/{stake_address}/delegations", "0.1.27")]
        Task<Models.AccountDelegationContentResponseCollection> GetDelegationsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account delegation history <c>/accounts/{stake_address}/delegations</c>
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
        [Get("/accounts/{stake_address}/delegations", "0.1.27")]
        Task<Models.AccountDelegationContentResponseCollection> GetDelegationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Account registration history <c>/accounts/{stake_address}/registrations</c>
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
        [Get("/accounts/{stake_address}/registrations", "0.1.27")]
        Task<Models.AccountRegistrationContentResponseCollection> GetRegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account registration history <c>/accounts/{stake_address}/registrations</c>
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
        [Get("/accounts/{stake_address}/registrations", "0.1.27")]
        Task<Models.AccountRegistrationContentResponseCollection> GetRegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Account withdrawal history <c>/accounts/{stake_address}/withdrawals</c>
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
        [Get("/accounts/{stake_address}/withdrawals", "0.1.27")]
        Task<Models.AccountWithdrawalContentResponseCollection> GetWithdrawalsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account withdrawal history <c>/accounts/{stake_address}/withdrawals</c>
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
        [Get("/accounts/{stake_address}/withdrawals", "0.1.27")]
        Task<Models.AccountWithdrawalContentResponseCollection> GetWithdrawalsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Account MIR history <c>/accounts/{stake_address}/mirs</c>
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
        [Get("/accounts/{stake_address}/mirs", "0.1.27")]
        Task<Models.AccountMirContentResponseCollection> GetMirsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account MIR history <c>/accounts/{stake_address}/mirs</c>
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
        [Get("/accounts/{stake_address}/mirs", "0.1.27")]
        Task<Models.AccountMirContentResponseCollection> GetMirsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Account associated addresses <c>/accounts/{stake_address}/addresses</c>
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
        [Get("/accounts/{stake_address}/addresses", "0.1.27")]
        Task<Models.AccountAddressesContentResponseCollection> GetAddressesAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Account associated addresses <c>/accounts/{stake_address}/addresses</c>
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
        [Get("/accounts/{stake_address}/addresses", "0.1.27")]
        Task<Models.AccountAddressesContentResponseCollection> GetAddressesAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Assets associated with the account addresses <c>/accounts/{stake_address}/addresses/assets</c>
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
        [Get("/accounts/{stake_address}/addresses/assets", "0.1.27")]
        Task<Models.AccountAddressesAssetsResponseCollection> GetAddressesAssetsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Assets associated with the account addresses <c>/accounts/{stake_address}/addresses/assets</c>
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
        [Get("/accounts/{stake_address}/addresses/assets", "0.1.27")]
        Task<Models.AccountAddressesAssetsResponseCollection> GetAddressesAssetsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}

