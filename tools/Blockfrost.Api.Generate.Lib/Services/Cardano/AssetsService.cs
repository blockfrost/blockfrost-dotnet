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
    public partial interface IAssetsService 
    {

        /// <summary>Assets</summary>
        /// <remarks>Route template: /assets</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return list of assets</returns>
        [Get("/assets","0.1.26")]
        Task<AssetsGetResponse> GetAsync(long count, long page, string order);

        /// <summary>Assets</summary>
        /// <remarks>Route template: /assets</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return list of assets</returns>
        [Get("/assets","0.1.26")]
        Task<AssetsGetResponse> GetAsync(long count, long page, string order, CancellationToken token);

        /// <summary>Specific asset</summary>
        /// <remarks>Route template: /assets/{asset}</remarks>
        /// <param name="asset">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/{asset}","0.1.26")]
        Task<AssetsGetResponse> GetAsync(string asset);

        /// <summary>Specific asset</summary>
        /// <remarks>Route template: /assets/{asset}</remarks>
        /// <param name="asset">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/{asset}","0.1.26")]
        Task<AssetsGetResponse> GetAsync(string asset, CancellationToken token);

        /// <summary>Asset history</summary>
        /// <remarks>Route template: /assets/{asset}/history</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/history","0.1.26")]
        Task<AssetsGetHistoryResponse> GetHistoryAsync(string asset, long count, long page, string order);

        /// <summary>Asset history</summary>
        /// <remarks>Route template: /assets/{asset}/history</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/history","0.1.26")]
        Task<AssetsGetHistoryResponse> GetHistoryAsync(string asset, long count, long page, string order, CancellationToken token);

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/txs</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/txs","0.1.26")]
        Task<AssetsGetTxsResponse> GetTxsAsync(string asset, long count, long page, string order);

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/txs</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/txs","0.1.26")]
        Task<AssetsGetTxsResponse> GetTxsAsync(string asset, long count, long page, string order, CancellationToken token);

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/transactions</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/transactions","0.1.26")]
        Task<AssetsGetTransactionsResponse> GetTransactionsAsync(string asset, long count, long page, string order);

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/transactions</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/transactions","0.1.26")]
        Task<AssetsGetTransactionsResponse> GetTransactionsAsync(string asset, long count, long page, string order, CancellationToken token);

        /// <summary>Asset addresses</summary>
        /// <remarks>Route template: /assets/{asset}/addresses</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/addresses","0.1.26")]
        Task<AssetsGetAddressesResponse> GetAddressesAsync(string asset, long count, long page, string order);

        /// <summary>Asset addresses</summary>
        /// <remarks>Route template: /assets/{asset}/addresses</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/addresses","0.1.26")]
        Task<AssetsGetAddressesResponse> GetAddressesAsync(string asset, long count, long page, string order, CancellationToken token);

        /// <summary>Assets of a specific policy</summary>
        /// <remarks>Route template: /assets/policy/{policy_id}</remarks>
        /// <param name="policy_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/policy/{policy_id}","0.1.26")]
        Task<AssetsGetPolicyResponse> GetPolicyAsync(string policy_id, long count, long page, string order);

        /// <summary>Assets of a specific policy</summary>
        /// <remarks>Route template: /assets/policy/{policy_id}</remarks>
        /// <param name="policy_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/policy/{policy_id}","0.1.26")]
        Task<AssetsGetPolicyResponse> GetPolicyAsync(string policy_id, long count, long page, string order, CancellationToken token);
    }
    
    public partial class AssetsService : IAssetsService 
    {

        /// <summary>Assets</summary>
        /// <remarks>Route template: /assets</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return list of assets</returns>
        [Get("/assets","0.1.26")]
        public Task<AssetsGetResponse> GetAsync(long count, long page, string order)
        {
            return GetAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>Assets</summary>
        /// <remarks>Route template: /assets</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return list of assets</returns>
        [Get("/assets","0.1.26")]
        public Task<AssetsGetResponse> GetAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Specific asset</summary>
        /// <remarks>Route template: /assets/{asset}</remarks>
        /// <param name="asset">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/{asset}","0.1.26")]
        public Task<AssetsGetResponse> GetAsync(string asset)
        {
            return GetAsync(asset, CancellationToken.None);
        }

        /// <summary>Specific asset</summary>
        /// <remarks>Route template: /assets/{asset}</remarks>
        /// <param name="asset">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/{asset}","0.1.26")]
        public Task<AssetsGetResponse> GetAsync(string asset, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Asset history</summary>
        /// <remarks>Route template: /assets/{asset}/history</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/history","0.1.26")]
        public Task<AssetsGetHistoryResponse> GetHistoryAsync(string asset, long count, long page, string order)
        {
            return GetHistoryAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>Asset history</summary>
        /// <remarks>Route template: /assets/{asset}/history</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/history","0.1.26")]
        public Task<AssetsGetHistoryResponse> GetHistoryAsync(string asset, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/txs</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/txs","0.1.26")]
        public Task<AssetsGetTxsResponse> GetTxsAsync(string asset, long count, long page, string order)
        {
            return GetTxsAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/txs</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/txs","0.1.26")]
        public Task<AssetsGetTxsResponse> GetTxsAsync(string asset, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/transactions</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/transactions","0.1.26")]
        public Task<AssetsGetTransactionsResponse> GetTransactionsAsync(string asset, long count, long page, string order)
        {
            return GetTransactionsAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>Asset transactions</summary>
        /// <remarks>Route template: /assets/{asset}/transactions</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/transactions","0.1.26")]
        public Task<AssetsGetTransactionsResponse> GetTransactionsAsync(string asset, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Asset addresses</summary>
        /// <remarks>Route template: /assets/{asset}/addresses</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/addresses","0.1.26")]
        public Task<AssetsGetAddressesResponse> GetAddressesAsync(string asset, long count, long page, string order)
        {
            return GetAddressesAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <summary>Asset addresses</summary>
        /// <remarks>Route template: /assets/{asset}/addresses</remarks>
        /// <param name="asset">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        [Get("/assets/{asset}/addresses","0.1.26")]
        public Task<AssetsGetAddressesResponse> GetAddressesAsync(string asset, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Assets of a specific policy</summary>
        /// <remarks>Route template: /assets/policy/{policy_id}</remarks>
        /// <param name="policy_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/policy/{policy_id}","0.1.26")]
        public Task<AssetsGetPolicyResponse> GetPolicyAsync(string policy_id, long count, long page, string order)
        {
            return GetPolicyAsync(policy_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Assets of a specific policy</summary>
        /// <remarks>Route template: /assets/policy/{policy_id}</remarks>
        /// <param name="policy_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the information about a specific asset</returns>
        [Get("/assets/policy/{policy_id}","0.1.26")]
        public Task<AssetsGetPolicyResponse> GetPolicyAsync(string policy_id, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

