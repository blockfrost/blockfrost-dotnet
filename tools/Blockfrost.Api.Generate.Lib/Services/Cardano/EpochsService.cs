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
    public partial interface IEpochsService 
    {

        /// <summary>Latest epoch</summary>
        /// <remarks>Route template: /epochs/latest</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest","0.1.26")]
        Task<EpochsGetLatestResponse> GetLatestAsync();

        /// <summary>Latest epoch</summary>
        /// <remarks>Route template: /epochs/latest</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest","0.1.26")]
        Task<EpochsGetLatestResponse> GetLatestAsync(CancellationToken token);

        /// <summary>Latest epoch protocol parameters</summary>
        /// <remarks>Route template: /epochs/latest/parameters</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest/parameters","0.1.26")]
        Task<EpochsGetLatestParametersResponse> GetLatestParametersAsync();

        /// <summary>Latest epoch protocol parameters</summary>
        /// <remarks>Route template: /epochs/latest/parameters</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest/parameters","0.1.26")]
        Task<EpochsGetLatestParametersResponse> GetLatestParametersAsync(CancellationToken token);

        /// <summary>Specific epoch</summary>
        /// <remarks>Route template: /epochs/{number}</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the epoch data.</returns>
        [Get("/epochs/{number}","0.1.26")]
        Task<EpochsGetResponse> GetAsync(long number);

        /// <summary>Specific epoch</summary>
        /// <remarks>Route template: /epochs/{number}</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the epoch data.</returns>
        [Get("/epochs/{number}","0.1.26")]
        Task<EpochsGetResponse> GetAsync(long number, CancellationToken token);

        /// <summary>Listing of next epochs</summary>
        /// <remarks>Route template: /epochs/{number}/next</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/next","0.1.26")]
        Task<EpochsGetNextResponse> GetNextAsync(long number, long count, long page);

        /// <summary>Listing of next epochs</summary>
        /// <remarks>Route template: /epochs/{number}/next</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/next","0.1.26")]
        Task<EpochsGetNextResponse> GetNextAsync(long number, long count, long page, CancellationToken token);

        /// <summary>Listing of previous epochs</summary>
        /// <remarks>Route template: /epochs/{number}/previous</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the epoch data</returns>
        [Get("/epochs/{number}/previous","0.1.26")]
        Task<EpochsGetPreviousResponse> GetPreviousAsync(long number, long count, long page);

        /// <summary>Listing of previous epochs</summary>
        /// <remarks>Route template: /epochs/{number}/previous</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the epoch data</returns>
        [Get("/epochs/{number}/previous","0.1.26")]
        Task<EpochsGetPreviousResponse> GetPreviousAsync(long number, long count, long page, CancellationToken token);

        /// <summary>Stake distribution</summary>
        /// <remarks>Route template: /epochs/{number}/stakes</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes","0.1.26")]
        Task<EpochsGetStakesResponse> GetStakesAsync(long number, long count, long page);

        /// <summary>Stake distribution</summary>
        /// <remarks>Route template: /epochs/{number}/stakes</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes","0.1.26")]
        Task<EpochsGetStakesResponse> GetStakesAsync(long number, long count, long page, CancellationToken token);

        /// <summary>Stake distribution by pool</summary>
        /// <remarks>Route template: /epochs/{number}/stakes/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes/{pool_id}","0.1.26")]
        Task<EpochsGetStakesResponse> GetStakesAsync(long number, string pool_id, long count, long page);

        /// <summary>Stake distribution by pool</summary>
        /// <remarks>Route template: /epochs/{number}/stakes/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes/{pool_id}","0.1.26")]
        Task<EpochsGetStakesResponse> GetStakesAsync(long number, string pool_id, long count, long page, CancellationToken token);

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks","0.1.26")]
        Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, long count, long page, string order);

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks","0.1.26")]
        Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, long count, long page, string order, CancellationToken token);

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks/{pool_id}","0.1.26")]
        Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, string pool_id, long count, long page, string order);

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks/{pool_id}","0.1.26")]
        Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, string pool_id, long count, long page, string order, CancellationToken token);

        /// <summary>Protocol parameters</summary>
        /// <remarks>Route template: /epochs/{number}/parameters</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/parameters","0.1.26")]
        Task<EpochsGetParametersResponse> GetParametersAsync(long number);

        /// <summary>Protocol parameters</summary>
        /// <remarks>Route template: /epochs/{number}/parameters</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/parameters","0.1.26")]
        Task<EpochsGetParametersResponse> GetParametersAsync(long number, CancellationToken token);
    }
    
    public partial class EpochsService : IEpochsService 
    {

        /// <summary>Latest epoch</summary>
        /// <remarks>Route template: /epochs/latest</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest","0.1.26")]
        public Task<EpochsGetLatestResponse> GetLatestAsync()
        {
            return GetLatestAsync(CancellationToken.None);
        }

        /// <summary>Latest epoch</summary>
        /// <remarks>Route template: /epochs/latest</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest","0.1.26")]
        public Task<EpochsGetLatestResponse> GetLatestAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Latest epoch protocol parameters</summary>
        /// <remarks>Route template: /epochs/latest/parameters</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest/parameters","0.1.26")]
        public Task<EpochsGetLatestParametersResponse> GetLatestParametersAsync()
        {
            return GetLatestParametersAsync(CancellationToken.None);
        }

        /// <summary>Latest epoch protocol parameters</summary>
        /// <remarks>Route template: /epochs/latest/parameters</remarks>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/latest/parameters","0.1.26")]
        public Task<EpochsGetLatestParametersResponse> GetLatestParametersAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Specific epoch</summary>
        /// <remarks>Route template: /epochs/{number}</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the epoch data.</returns>
        [Get("/epochs/{number}","0.1.26")]
        public Task<EpochsGetResponse> GetAsync(long number)
        {
            return GetAsync(number, CancellationToken.None);
        }

        /// <summary>Specific epoch</summary>
        /// <remarks>Route template: /epochs/{number}</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the epoch data.</returns>
        [Get("/epochs/{number}","0.1.26")]
        public Task<EpochsGetResponse> GetAsync(long number, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Listing of next epochs</summary>
        /// <remarks>Route template: /epochs/{number}/next</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/next","0.1.26")]
        public Task<EpochsGetNextResponse> GetNextAsync(long number, long count, long page)
        {
            return GetNextAsync(number, count, page, CancellationToken.None);
        }

        /// <summary>Listing of next epochs</summary>
        /// <remarks>Route template: /epochs/{number}/next</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/next","0.1.26")]
        public Task<EpochsGetNextResponse> GetNextAsync(long number, long count, long page, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Listing of previous epochs</summary>
        /// <remarks>Route template: /epochs/{number}/previous</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the epoch data</returns>
        [Get("/epochs/{number}/previous","0.1.26")]
        public Task<EpochsGetPreviousResponse> GetPreviousAsync(long number, long count, long page)
        {
            return GetPreviousAsync(number, count, page, CancellationToken.None);
        }

        /// <summary>Listing of previous epochs</summary>
        /// <remarks>Route template: /epochs/{number}/previous</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the epoch data</returns>
        [Get("/epochs/{number}/previous","0.1.26")]
        public Task<EpochsGetPreviousResponse> GetPreviousAsync(long number, long count, long page, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake distribution</summary>
        /// <remarks>Route template: /epochs/{number}/stakes</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes","0.1.26")]
        public Task<EpochsGetStakesResponse> GetStakesAsync(long number, long count, long page)
        {
            return GetStakesAsync(number, count, page, CancellationToken.None);
        }

        /// <summary>Stake distribution</summary>
        /// <remarks>Route template: /epochs/{number}/stakes</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes","0.1.26")]
        public Task<EpochsGetStakesResponse> GetStakesAsync(long number, long count, long page, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Stake distribution by pool</summary>
        /// <remarks>Route template: /epochs/{number}/stakes/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes/{pool_id}","0.1.26")]
        public Task<EpochsGetStakesResponse> GetStakesAsync(long number, string pool_id, long count, long page)
        {
            return GetStakesAsync(number, pool_id, count, page, CancellationToken.None);
        }

        /// <summary>Stake distribution by pool</summary>
        /// <remarks>Route template: /epochs/{number}/stakes/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/stakes/{pool_id}","0.1.26")]
        public Task<EpochsGetStakesResponse> GetStakesAsync(long number, string pool_id, long count, long page, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks","0.1.26")]
        public Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, long count, long page, string order)
        {
            return GetBlocksAsync(number, count, page, order, CancellationToken.None);
        }

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks</remarks>
        /// <param name="number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks","0.1.26")]
        public Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks/{pool_id}","0.1.26")]
        public Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, string pool_id, long count, long page, string order)
        {
            return GetBlocksAsync(number, pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Block distribution</summary>
        /// <remarks>Route template: /epochs/{number}/blocks/{pool_id}</remarks>
        /// <param name="number">Description</param>
        /// <param name="pool_id">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/blocks/{pool_id}","0.1.26")]
        public Task<EpochsGetBlocksResponse> GetBlocksAsync(long number, string pool_id, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Protocol parameters</summary>
        /// <remarks>Route template: /epochs/{number}/parameters</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/parameters","0.1.26")]
        public Task<EpochsGetParametersResponse> GetParametersAsync(long number)
        {
            return GetParametersAsync(number, CancellationToken.None);
        }

        /// <summary>Protocol parameters</summary>
        /// <remarks>Route template: /epochs/{number}/parameters</remarks>
        /// <param name="number">Description</param>
        /// <returns>Return the data about the epoch</returns>
        [Get("/epochs/{number}/parameters","0.1.26")]
        public Task<EpochsGetParametersResponse> GetParametersAsync(long number, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

