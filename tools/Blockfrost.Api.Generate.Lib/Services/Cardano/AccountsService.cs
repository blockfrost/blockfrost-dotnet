using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services.Cardano
{
    public partial interface IAccountsService 
    {

        /// <summary>Specific account address</summary>
        /// <remarks>Route template: /accounts/{stake_address}</remarks>
        /// <param name="stake_address">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}","0.1.26")]
        Task<AccountsGetResponse> GetAsync(string stake_address);

        /// <summary>Specific account address</summary>
        /// <remarks>Route template: /accounts/{stake_address}</remarks>
        /// <param name="stake_address">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}","0.1.26")]
        Task<AccountsGetResponse> GetAsync(string stake_address, CancellationToken token);

        /// <summary>Account reward history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/rewards</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/rewards","0.1.26")]
        Task<AccountsGetRewardsResponse> GetRewardsAsync(string stake_address, long count, long page, string order);

        /// <summary>Account reward history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/rewards</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/rewards","0.1.26")]
        Task<AccountsGetRewardsResponse> GetRewardsAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Account history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/history</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/history","0.1.26")]
        Task<AccountsGetHistoryResponse> GetHistoryAsync(string stake_address, long count, long page, string order);

        /// <summary>Account history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/history</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/history","0.1.26")]
        Task<AccountsGetHistoryResponse> GetHistoryAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Account delegation history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/delegations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/accounts/{stake_address}/delegations","0.1.26")]
        Task<AccountsGetDelegationsResponse> GetDelegationsAsync(string stake_address, long count, long page, string order);

        /// <summary>Account delegation history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/delegations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/accounts/{stake_address}/delegations","0.1.26")]
        Task<AccountsGetDelegationsResponse> GetDelegationsAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Account registration history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/registrations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account registration content.</returns>
        [Get("/accounts/{stake_address}/registrations","0.1.26")]
        Task<AccountsGetRegistrationsResponse> GetRegistrationsAsync(string stake_address, long count, long page, string order);

        /// <summary>Account registration history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/registrations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account registration content.</returns>
        [Get("/accounts/{stake_address}/registrations","0.1.26")]
        Task<AccountsGetRegistrationsResponse> GetRegistrationsAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Account withdrawal history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/withdrawals</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account withdrawal content.</returns>
        [Get("/accounts/{stake_address}/withdrawals","0.1.26")]
        Task<AccountsGetWithdrawalsResponse> GetWithdrawalsAsync(string stake_address, long count, long page, string order);

        /// <summary>Account withdrawal history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/withdrawals</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account withdrawal content.</returns>
        [Get("/accounts/{stake_address}/withdrawals","0.1.26")]
        Task<AccountsGetWithdrawalsResponse> GetWithdrawalsAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Account MIR history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/mirs</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account MIR content.</returns>
        [Get("/accounts/{stake_address}/mirs","0.1.26")]
        Task<AccountsGetMirsResponse> GetMirsAsync(string stake_address, long count, long page, string order);

        /// <summary>Account MIR history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/mirs</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account MIR content.</returns>
        [Get("/accounts/{stake_address}/mirs","0.1.26")]
        Task<AccountsGetMirsResponse> GetMirsAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Account associated addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses","0.1.26")]
        Task<AccountsGetAddressesResponse> GetAddressesAsync(string stake_address, long count, long page, string order);

        /// <summary>Account associated addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses","0.1.26")]
        Task<AccountsGetAddressesResponse> GetAddressesAsync(string stake_address, long count, long page, string order, CancellationToken token);

        /// <summary>Assets associated with the account addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses/assets</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses/assets","0.1.26")]
        Task<AccountsGetAddressesAssetsResponse> GetAddressesAssetsAsync(string stake_address, long count, long page, string order);

        /// <summary>Assets associated with the account addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses/assets</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses/assets","0.1.26")]
        Task<AccountsGetAddressesAssetsResponse> GetAddressesAssetsAsync(string stake_address, long count, long page, string order, CancellationToken token);
    }
    
    public partial class AccountsService : IAccountsService 
    {

        /// <summary>Specific account address</summary>
        /// <remarks>Route template: /accounts/{stake_address}</remarks>
        /// <param name="stake_address">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}","0.1.26")]
        public Task<AccountsGetResponse> GetAsync(string stake_address)
        {
            return GetAsync(stake_address, CancellationToken.None);
        }

        /// <summary>Specific account address</summary>
        /// <remarks>Route template: /accounts/{stake_address}</remarks>
        /// <param name="stake_address">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}","0.1.26")]
        public Task<AccountsGetResponse> GetAsync(string stake_address, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account reward history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/rewards</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/rewards","0.1.26")]
        public Task<AccountsGetRewardsResponse> GetRewardsAsync(string stake_address, long count, long page, string order)
        {
            return GetRewardsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account reward history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/rewards</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/rewards","0.1.26")]
        public Task<AccountsGetRewardsResponse> GetRewardsAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/history</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/history","0.1.26")]
        public Task<AccountsGetHistoryResponse> GetHistoryAsync(string stake_address, long count, long page, string order)
        {
            return GetHistoryAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/history</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account content.</returns>
        [Get("/accounts/{stake_address}/history","0.1.26")]
        public Task<AccountsGetHistoryResponse> GetHistoryAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account delegation history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/delegations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/accounts/{stake_address}/delegations","0.1.26")]
        public Task<AccountsGetDelegationsResponse> GetDelegationsAsync(string stake_address, long count, long page, string order)
        {
            return GetDelegationsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account delegation history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/delegations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/accounts/{stake_address}/delegations","0.1.26")]
        public Task<AccountsGetDelegationsResponse> GetDelegationsAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account registration history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/registrations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account registration content.</returns>
        [Get("/accounts/{stake_address}/registrations","0.1.26")]
        public Task<AccountsGetRegistrationsResponse> GetRegistrationsAsync(string stake_address, long count, long page, string order)
        {
            return GetRegistrationsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account registration history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/registrations</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account registration content.</returns>
        [Get("/accounts/{stake_address}/registrations","0.1.26")]
        public Task<AccountsGetRegistrationsResponse> GetRegistrationsAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account withdrawal history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/withdrawals</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account withdrawal content.</returns>
        [Get("/accounts/{stake_address}/withdrawals","0.1.26")]
        public Task<AccountsGetWithdrawalsResponse> GetWithdrawalsAsync(string stake_address, long count, long page, string order)
        {
            return GetWithdrawalsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account withdrawal history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/withdrawals</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account withdrawal content.</returns>
        [Get("/accounts/{stake_address}/withdrawals","0.1.26")]
        public Task<AccountsGetWithdrawalsResponse> GetWithdrawalsAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account MIR history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/mirs</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account MIR content.</returns>
        [Get("/accounts/{stake_address}/mirs","0.1.26")]
        public Task<AccountsGetMirsResponse> GetMirsAsync(string stake_address, long count, long page, string order)
        {
            return GetMirsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account MIR history</summary>
        /// <remarks>Route template: /accounts/{stake_address}/mirs</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account MIR content.</returns>
        [Get("/accounts/{stake_address}/mirs","0.1.26")]
        public Task<AccountsGetMirsResponse> GetMirsAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Account associated addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses","0.1.26")]
        public Task<AccountsGetAddressesResponse> GetAddressesAsync(string stake_address, long count, long page, string order)
        {
            return GetAddressesAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Account associated addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses","0.1.26")]
        public Task<AccountsGetAddressesResponse> GetAddressesAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Assets associated with the account addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses/assets</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses/assets","0.1.26")]
        public Task<AccountsGetAddressesAssetsResponse> GetAddressesAssetsAsync(string stake_address, long count, long page, string order)
        {
            return GetAddressesAssetsAsync(stake_address, count, page, order, CancellationToken.None);
        }

        /// <summary>Assets associated with the account addresses</summary>
        /// <remarks>Route template: /accounts/{stake_address}/addresses/assets</remarks>
        /// <param name="stake_address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account addresses content</returns>
        [Get("/accounts/{stake_address}/addresses/assets","0.1.26")]
        public Task<AccountsGetAddressesAssetsResponse> GetAddressesAssetsAsync(string stake_address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

