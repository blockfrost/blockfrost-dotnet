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
    public partial interface IPoolsService 
    {

        /// <summary>List of stake pools</summary>
        /// <remarks>Route template: /pools</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the list of pools.</returns>
        [Get("/pools","0.1.26")]
        Task<PoolsGetResponse> GetAsync(long count, long page, string order);

        /// <summary>List of stake pools</summary>
        /// <remarks>Route template: /pools</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the list of pools.</returns>
        [Get("/pools","0.1.26")]
        Task<PoolsGetResponse> GetAsync(long count, long page, string order, CancellationToken token);

        /// <summary>List of retired stake pools</summary>
        /// <remarks>Route template: /pools/retired</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retired","0.1.26")]
        Task<PoolsGetRetiredResponse> GetRetiredAsync(long count, long page, string order);

        /// <summary>List of retired stake pools</summary>
        /// <remarks>Route template: /pools/retired</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retired","0.1.26")]
        Task<PoolsGetRetiredResponse> GetRetiredAsync(long count, long page, string order, CancellationToken token);

        /// <summary>List of retiring stake pools</summary>
        /// <remarks>Route template: /pools/retiring</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retiring","0.1.26")]
        Task<PoolsGetRetiringResponse> GetRetiringAsync(long count, long page, string order);

        /// <summary>List of retiring stake pools</summary>
        /// <remarks>Route template: /pools/retiring</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retiring","0.1.26")]
        Task<PoolsGetRetiringResponse> GetRetiringAsync(long count, long page, string order, CancellationToken token);

        /// <summary>Specific stake pool</summary>
        /// <remarks>Route template: /pools/{pool_id}</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/{pool_id}","0.1.26")]
        Task<PoolsGetResponse> GetAsync(string pool_id);

        /// <summary>Specific stake pool</summary>
        /// <remarks>Route template: /pools/{pool_id}</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/{pool_id}","0.1.26")]
        Task<PoolsGetResponse> GetAsync(string pool_id, CancellationToken token);

        /// <summary>Stake pool history</summary>
        /// <remarks>Route template: /pools/{pool_id}/history</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content.</returns>
        [Get("/pools/{pool_id}/history","0.1.26")]
        Task<PoolsGetHistoryResponse> GetHistoryAsync(string pool_id, long count, long page, string order);

        /// <summary>Stake pool history</summary>
        /// <remarks>Route template: /pools/{pool_id}/history</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content.</returns>
        [Get("/pools/{pool_id}/history","0.1.26")]
        Task<PoolsGetHistoryResponse> GetHistoryAsync(string pool_id, long count, long page, string order, CancellationToken token);

        /// <summary>Stake pool metadata</summary>
        /// <remarks>Route template: /pools/{pool_id}/metadata</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool metadata content.</returns>
        [Get("/pools/{pool_id}/metadata","0.1.26")]
        Task<PoolsGetMetadataResponse> GetMetadataAsync(string pool_id);

        /// <summary>Stake pool metadata</summary>
        /// <remarks>Route template: /pools/{pool_id}/metadata</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool metadata content.</returns>
        [Get("/pools/{pool_id}/metadata","0.1.26")]
        Task<PoolsGetMetadataResponse> GetMetadataAsync(string pool_id, CancellationToken token);

        /// <summary>Stake pool relays</summary>
        /// <remarks>Route template: /pools/{pool_id}/relays</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool relays information content.</returns>
        [Get("/pools/{pool_id}/relays","0.1.26")]
        Task<PoolsGetRelaysResponse> GetRelaysAsync(string pool_id);

        /// <summary>Stake pool relays</summary>
        /// <remarks>Route template: /pools/{pool_id}/relays</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool relays information content.</returns>
        [Get("/pools/{pool_id}/relays","0.1.26")]
        Task<PoolsGetRelaysResponse> GetRelaysAsync(string pool_id, CancellationToken token);

        /// <summary>Stake pool delegators</summary>
        /// <remarks>Route template: /pools/{pool_id}/delegators</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool delegations.</returns>
        [Get("/pools/{pool_id}/delegators","0.1.26")]
        Task<PoolsGetDelegatorsResponse> GetDelegatorsAsync(string pool_id, long count, long page, string order);

        /// <summary>Stake pool delegators</summary>
        /// <remarks>Route template: /pools/{pool_id}/delegators</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool delegations.</returns>
        [Get("/pools/{pool_id}/delegators","0.1.26")]
        Task<PoolsGetDelegatorsResponse> GetDelegatorsAsync(string pool_id, long count, long page, string order, CancellationToken token);

        /// <summary>Stake pool blocks</summary>
        /// <remarks>Route template: /pools/{pool_id}/blocks</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool block list</returns>
        [Get("/pools/{pool_id}/blocks","0.1.26")]
        Task<PoolsGetBlocksResponse> GetBlocksAsync(string pool_id, long count, long page, string order);

        /// <summary>Stake pool blocks</summary>
        /// <remarks>Route template: /pools/{pool_id}/blocks</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool block list</returns>
        [Get("/pools/{pool_id}/blocks","0.1.26")]
        Task<PoolsGetBlocksResponse> GetBlocksAsync(string pool_id, long count, long page, string order, CancellationToken token);

        /// <summary>Stake pool updates</summary>
        /// <remarks>Route template: /pools/{pool_id}/updates</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool updates history</returns>
        [Get("/pools/{pool_id}/updates","0.1.26")]
        Task<PoolsGetUpdatesResponse> GetUpdatesAsync(string pool_id, long count, long page, string order);

        /// <summary>Stake pool updates</summary>
        /// <remarks>Route template: /pools/{pool_id}/updates</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool updates history</returns>
        [Get("/pools/{pool_id}/updates","0.1.26")]
        Task<PoolsGetUpdatesResponse> GetUpdatesAsync(string pool_id, long count, long page, string order, CancellationToken token);
    }
    
    public partial class PoolsService : IPoolsService 
    {

        /// <summary>List of stake pools</summary>
        /// <remarks>Route template: /pools</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the list of pools.</returns>
        [Get("/pools","0.1.26")]
        public Task<PoolsGetResponse> GetAsync(long count, long page, string order)
        {
            return GetAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>List of stake pools</summary>
        /// <remarks>Route template: /pools</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the list of pools.</returns>
        [Get("/pools","0.1.26")]
        public Task<PoolsGetResponse> GetAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>List of retired stake pools</summary>
        /// <remarks>Route template: /pools/retired</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retired","0.1.26")]
        public Task<PoolsGetRetiredResponse> GetRetiredAsync(long count, long page, string order)
        {
            return GetRetiredAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>List of retired stake pools</summary>
        /// <remarks>Route template: /pools/retired</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retired","0.1.26")]
        public Task<PoolsGetRetiredResponse> GetRetiredAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>List of retiring stake pools</summary>
        /// <remarks>Route template: /pools/retiring</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retiring","0.1.26")]
        public Task<PoolsGetRetiringResponse> GetRetiringAsync(long count, long page, string order)
        {
            return GetRetiringAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>List of retiring stake pools</summary>
        /// <remarks>Route template: /pools/retiring</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/retiring","0.1.26")]
        public Task<PoolsGetRetiringResponse> GetRetiringAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Specific stake pool</summary>
        /// <remarks>Route template: /pools/{pool_id}</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/{pool_id}","0.1.26")]
        public Task<PoolsGetResponse> GetAsync(string pool_id)
        {
            return GetAsync(pool_id, CancellationToken.None);
        }

        /// <summary>Specific stake pool</summary>
        /// <remarks>Route template: /pools/{pool_id}</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool information content</returns>
        [Get("/pools/{pool_id}","0.1.26")]
        public Task<PoolsGetResponse> GetAsync(string pool_id, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake pool history</summary>
        /// <remarks>Route template: /pools/{pool_id}/history</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content.</returns>
        [Get("/pools/{pool_id}/history","0.1.26")]
        public Task<PoolsGetHistoryResponse> GetHistoryAsync(string pool_id, long count, long page, string order)
        {
            return GetHistoryAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Stake pool history</summary>
        /// <remarks>Route template: /pools/{pool_id}/history</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool information content.</returns>
        [Get("/pools/{pool_id}/history","0.1.26")]
        public Task<PoolsGetHistoryResponse> GetHistoryAsync(string pool_id, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake pool metadata</summary>
        /// <remarks>Route template: /pools/{pool_id}/metadata</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool metadata content.</returns>
        [Get("/pools/{pool_id}/metadata","0.1.26")]
        public Task<PoolsGetMetadataResponse> GetMetadataAsync(string pool_id)
        {
            return GetMetadataAsync(pool_id, CancellationToken.None);
        }

        /// <summary>Stake pool metadata</summary>
        /// <remarks>Route template: /pools/{pool_id}/metadata</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool metadata content.</returns>
        [Get("/pools/{pool_id}/metadata","0.1.26")]
        public Task<PoolsGetMetadataResponse> GetMetadataAsync(string pool_id, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake pool relays</summary>
        /// <remarks>Route template: /pools/{pool_id}/relays</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool relays information content.</returns>
        [Get("/pools/{pool_id}/relays","0.1.26")]
        public Task<PoolsGetRelaysResponse> GetRelaysAsync(string pool_id)
        {
            return GetRelaysAsync(pool_id, CancellationToken.None);
        }

        /// <summary>Stake pool relays</summary>
        /// <remarks>Route template: /pools/{pool_id}/relays</remarks>
        /// <param name="pool_id">Description</param>
        /// <returns>Return the pool relays information content.</returns>
        [Get("/pools/{pool_id}/relays","0.1.26")]
        public Task<PoolsGetRelaysResponse> GetRelaysAsync(string pool_id, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake pool delegators</summary>
        /// <remarks>Route template: /pools/{pool_id}/delegators</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool delegations.</returns>
        [Get("/pools/{pool_id}/delegators","0.1.26")]
        public Task<PoolsGetDelegatorsResponse> GetDelegatorsAsync(string pool_id, long count, long page, string order)
        {
            return GetDelegatorsAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Stake pool delegators</summary>
        /// <remarks>Route template: /pools/{pool_id}/delegators</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool delegations.</returns>
        [Get("/pools/{pool_id}/delegators","0.1.26")]
        public Task<PoolsGetDelegatorsResponse> GetDelegatorsAsync(string pool_id, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake pool blocks</summary>
        /// <remarks>Route template: /pools/{pool_id}/blocks</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool block list</returns>
        [Get("/pools/{pool_id}/blocks","0.1.26")]
        public Task<PoolsGetBlocksResponse> GetBlocksAsync(string pool_id, long count, long page, string order)
        {
            return GetBlocksAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Stake pool blocks</summary>
        /// <remarks>Route template: /pools/{pool_id}/blocks</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool block list</returns>
        [Get("/pools/{pool_id}/blocks","0.1.26")]
        public Task<PoolsGetBlocksResponse> GetBlocksAsync(string pool_id, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake pool updates</summary>
        /// <remarks>Route template: /pools/{pool_id}/updates</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool updates history</returns>
        [Get("/pools/{pool_id}/updates","0.1.26")]
        public Task<PoolsGetUpdatesResponse> GetUpdatesAsync(string pool_id, long count, long page, string order)
        {
            return GetUpdatesAsync(pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Stake pool updates</summary>
        /// <remarks>Route template: /pools/{pool_id}/updates</remarks>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the pool updates history</returns>
        [Get("/pools/{pool_id}/updates","0.1.26")]
        public Task<PoolsGetUpdatesResponse> GetUpdatesAsync(string pool_id, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

