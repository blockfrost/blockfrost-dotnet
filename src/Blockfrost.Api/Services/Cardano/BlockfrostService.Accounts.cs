using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService 
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/history?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressHistoryResponse>>(urlBuilder_, cancellationToken);
           
        }
        /// <summary>Account delegation history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Delegations2Async(stake_address, count, page, order, CancellationToken.None);
        }
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account delegation history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account delegations content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/delegations?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressDelegationsResponse>>(urlBuilder_, cancellationToken);
          
        }
        /// <summary>Account registration history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account registration content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return RegistrationsAsync(stake_address, count, page, order, CancellationToken.None);
        }
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account registration history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account registration content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/registrations?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressRegistrationsResponse>>(urlBuilder_, cancellationToken);
            
        }
        /// <summary>Account withdrawal history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account withdrawal content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Withdrawals2Async(stake_address, count, page, order, CancellationToken.None);
        }
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account withdrawal history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account withdrawal content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/withdrawals?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressWithdrawalsResponse>>(urlBuilder_, cancellationToken);
           
        }
        /// <summary>Account MIR history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account MIR content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return Mirs2Async(stake_address, count, page, order, CancellationToken.None);
        }
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account MIR history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account MIR content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/mirs?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressMirsResponse>>(urlBuilder_, cancellationToken);
            
        }/// <summary>Account associated addresses</summary>
         /// <param name="stake_address">Bech32 stake address.</param>
         /// <param name="count">The number of results displayed on one page.</param>
         /// <param name="page">The page number for listing the results.</param>
         /// <param name="order">The ordering of items from the point of view of the blockchain,
         /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
         /// <returns>Return the account addresses content</returns>
         /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return AddressesAllAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account associated addresses</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/addresses?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressesAddressesResponse>>(urlBuilder_, cancellationToken);
           
        }

        /// <summary>Assets associated with the account addresses</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return AssetsAllAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Assets associated with the account addresses</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account addresses content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/addresses/assets?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<StakeAddressAddressesAssetsResponse>>(urlBuilder_, cancellationToken);

        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Account reward history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}/rewards?");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<Anonymous9>>(urlBuilder_, cancellationToken);
            
        }

        /// <summary>Account history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return HistoryAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account reward history</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order)
        {
            return RewardsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Specific account address</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AccountContentResponse> GetAccountsAsync(string stake_address)
        {
            return GetAccountsAsync(stake_address, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific account address</summary>
        /// <param name="stake_address">Bech32 stake address.</param>
        /// <returns>Return the account content.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AccountContentResponse> GetAccountsAsync(string stake_address, CancellationToken cancellationToken)
        {
            if (stake_address == null)
                throw new System.ArgumentNullException("stake_address");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/accounts/{stake_address}");
            urlBuilder_.Replace("{stake_address}", System.Uri.EscapeDataString(ConvertToString(stake_address, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AccountContentResponse>(urlBuilder_, cancellationToken);
        }
    }
}
