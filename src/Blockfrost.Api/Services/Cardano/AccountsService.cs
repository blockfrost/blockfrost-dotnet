using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class AccountsService : ABlockfrostService, IAccountsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="AccountsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Accounts">Cardano » Accounts</seealso> on docs.blockfrost.io
        /// </remarks>
        public AccountsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

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
        public Task<Models.AccountContentResponse> GetAccountsAsync(string stake_address)
        {
            return GetAccountsAsync(stake_address, CancellationToken.None);
        }

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
        public async Task<Models.AccountContentResponse> GetAccountsAsync(string stake_address, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);

            return await SendGetRequestAsync<Models.AccountContentResponse>(builder, cancellationToken);
        }
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
        public Task<Models.AccountRewardContentResponseCollection> GetRewardsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetRewardsAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountRewardContentResponseCollection> GetRewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/rewards");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountRewardContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountHistoryContentResponseCollection> GetHistoryAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetHistoryAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountHistoryContentResponseCollection> GetHistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/history");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountHistoryContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountDelegationContentResponseCollection> GetDelegationsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetDelegationsAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountDelegationContentResponseCollection> GetDelegationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/delegations");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountDelegationContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountRegistrationContentResponseCollection> GetRegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetRegistrationsAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountRegistrationContentResponseCollection> GetRegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/registrations");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountRegistrationContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountWithdrawalContentResponseCollection> GetWithdrawalsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetWithdrawalsAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountWithdrawalContentResponseCollection> GetWithdrawalsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/withdrawals");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountWithdrawalContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountMirContentResponseCollection> GetMirsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetMirsAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountMirContentResponseCollection> GetMirsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/mirs");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountMirContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountAddressesContentResponseCollection> GetAddressesAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetAddressesAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountAddressesContentResponseCollection> GetAddressesAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/addresses");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountAddressesContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.AccountAddressesAssetsResponseCollection> GetAddressesAssetsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return GetAddressesAssetsAsync(stake_address, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.AccountAddressesAssetsResponseCollection> GetAddressesAssetsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
            {
                throw new System.ArgumentNullException(nameof(stake_address));
            }

            var builder = GetUrlBuilder("/accounts/{stake_address}/addresses/assets");
            _ = builder.SetRouteParameter("{stake_address}", stake_address);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.AccountAddressesAssetsResponseCollection>(builder, cancellationToken);
        }
    }
}

