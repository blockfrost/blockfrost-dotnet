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
    public partial interface IBlocksService 
    {

        /// <summary>Latest block</summary>
        /// <remarks>Route template: /blocks/latest</remarks>
        /// <returns>Return the contents of the latest block.</returns>
        [Get("/blocks/latest","0.1.26")]
        Task<BlocksGetLatestResponse> GetLatestAsync();

        /// <summary>Latest block</summary>
        /// <remarks>Route template: /blocks/latest</remarks>
        /// <returns>Return the contents of the latest block.</returns>
        [Get("/blocks/latest","0.1.26")]
        Task<BlocksGetLatestResponse> GetLatestAsync(CancellationToken token);

        /// <summary>Latest block transactions</summary>
        /// <remarks>Route template: /blocks/latest/txs</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/latest/txs","0.1.26")]
        Task<BlocksGetLatestTxsResponse> GetLatestTxsAsync(long count, long page, string order);

        /// <summary>Latest block transactions</summary>
        /// <remarks>Route template: /blocks/latest/txs</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/latest/txs","0.1.26")]
        Task<BlocksGetLatestTxsResponse> GetLatestTxsAsync(long count, long page, string order, CancellationToken token);

        /// <summary>Specific block</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}","0.1.26")]
        Task<BlocksGetResponse> GetAsync(string hash_or_number);

        /// <summary>Specific block</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}","0.1.26")]
        Task<BlocksGetResponse> GetAsync(string hash_or_number, CancellationToken token);

        /// <summary>Specific block in a slot</summary>
        /// <remarks>Route template: /blocks/slot/{slot_number}</remarks>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/slot/{slot_number}","0.1.26")]
        Task<BlocksGetSlotResponse> GetSlotAsync(long slot_number);

        /// <summary>Specific block in a slot</summary>
        /// <remarks>Route template: /blocks/slot/{slot_number}</remarks>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/slot/{slot_number}","0.1.26")]
        Task<BlocksGetSlotResponse> GetSlotAsync(long slot_number, CancellationToken token);

        /// <summary>Specific block in a slot in an epoch</summary>
        /// <remarks>Route template: /blocks/epoch/{epoch_number}/slot/{slot_number}</remarks>
        /// <param name="epoch_number">Description</param>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}","0.1.26")]
        Task<BlocksGetEpochSlotResponse> GetEpochSlotAsync(long epoch_number, long slot_number);

        /// <summary>Specific block in a slot in an epoch</summary>
        /// <remarks>Route template: /blocks/epoch/{epoch_number}/slot/{slot_number}</remarks>
        /// <param name="epoch_number">Description</param>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}","0.1.26")]
        Task<BlocksGetEpochSlotResponse> GetEpochSlotAsync(long epoch_number, long slot_number, CancellationToken token);

        /// <summary>Listing of next blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/next</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block.</returns>
        [Get("/blocks/{hash_or_number}/next","0.1.26")]
        Task<BlocksGetNextResponse> GetNextAsync(string hash_or_number, long count, long page);

        /// <summary>Listing of next blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/next</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block.</returns>
        [Get("/blocks/{hash_or_number}/next","0.1.26")]
        Task<BlocksGetNextResponse> GetNextAsync(string hash_or_number, long count, long page, CancellationToken token);

        /// <summary>Listing of previous blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/previous</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}/previous","0.1.26")]
        Task<BlocksGetPreviousResponse> GetPreviousAsync(string hash_or_number, long count, long page);

        /// <summary>Listing of previous blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/previous</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}/previous","0.1.26")]
        Task<BlocksGetPreviousResponse> GetPreviousAsync(string hash_or_number, long count, long page, CancellationToken token);

        /// <summary>Block transactions</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/txs</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/{hash_or_number}/txs","0.1.26")]
        Task<BlocksGetTxsResponse> GetTxsAsync(string hash_or_number, long count, long page, string order);

        /// <summary>Block transactions</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/txs</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/{hash_or_number}/txs","0.1.26")]
        Task<BlocksGetTxsResponse> GetTxsAsync(string hash_or_number, long count, long page, string order, CancellationToken token);
    }
    
    public partial class BlocksService : IBlocksService 
    {

        /// <summary>Latest block</summary>
        /// <remarks>Route template: /blocks/latest</remarks>
        /// <returns>Return the contents of the latest block.</returns>
        [Get("/blocks/latest","0.1.26")]
        public Task<BlocksGetLatestResponse> GetLatestAsync()
        {
            return GetLatestAsync(CancellationToken.None);
        }

        /// <summary>Latest block</summary>
        /// <remarks>Route template: /blocks/latest</remarks>
        /// <returns>Return the contents of the latest block.</returns>
        [Get("/blocks/latest","0.1.26")]
        public Task<BlocksGetLatestResponse> GetLatestAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Latest block transactions</summary>
        /// <remarks>Route template: /blocks/latest/txs</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/latest/txs","0.1.26")]
        public Task<BlocksGetLatestTxsResponse> GetLatestTxsAsync(long count, long page, string order)
        {
            return GetLatestTxsAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>Latest block transactions</summary>
        /// <remarks>Route template: /blocks/latest/txs</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/latest/txs","0.1.26")]
        public Task<BlocksGetLatestTxsResponse> GetLatestTxsAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Specific block</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}","0.1.26")]
        public Task<BlocksGetResponse> GetAsync(string hash_or_number)
        {
            return GetAsync(hash_or_number, CancellationToken.None);
        }

        /// <summary>Specific block</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}","0.1.26")]
        public Task<BlocksGetResponse> GetAsync(string hash_or_number, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Specific block in a slot</summary>
        /// <remarks>Route template: /blocks/slot/{slot_number}</remarks>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/slot/{slot_number}","0.1.26")]
        public Task<BlocksGetSlotResponse> GetSlotAsync(long slot_number)
        {
            return GetSlotAsync(slot_number, CancellationToken.None);
        }

        /// <summary>Specific block in a slot</summary>
        /// <remarks>Route template: /blocks/slot/{slot_number}</remarks>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/slot/{slot_number}","0.1.26")]
        public Task<BlocksGetSlotResponse> GetSlotAsync(long slot_number, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Specific block in a slot in an epoch</summary>
        /// <remarks>Route template: /blocks/epoch/{epoch_number}/slot/{slot_number}</remarks>
        /// <param name="epoch_number">Description</param>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}","0.1.26")]
        public Task<BlocksGetEpochSlotResponse> GetEpochSlotAsync(long epoch_number, long slot_number)
        {
            return GetEpochSlotAsync(epoch_number, slot_number, CancellationToken.None);
        }

        /// <summary>Specific block in a slot in an epoch</summary>
        /// <remarks>Route template: /blocks/epoch/{epoch_number}/slot/{slot_number}</remarks>
        /// <param name="epoch_number">Description</param>
        /// <param name="slot_number">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}","0.1.26")]
        public Task<BlocksGetEpochSlotResponse> GetEpochSlotAsync(long epoch_number, long slot_number, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Listing of next blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/next</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block.</returns>
        [Get("/blocks/{hash_or_number}/next","0.1.26")]
        public Task<BlocksGetNextResponse> GetNextAsync(string hash_or_number, long count, long page)
        {
            return GetNextAsync(hash_or_number, count, page, CancellationToken.None);
        }

        /// <summary>Listing of next blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/next</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block.</returns>
        [Get("/blocks/{hash_or_number}/next","0.1.26")]
        public Task<BlocksGetNextResponse> GetNextAsync(string hash_or_number, long count, long page, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Listing of previous blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/previous</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}/previous","0.1.26")]
        public Task<BlocksGetPreviousResponse> GetPreviousAsync(string hash_or_number, long count, long page)
        {
            return GetPreviousAsync(hash_or_number, count, page, CancellationToken.None);
        }

        /// <summary>Listing of previous blocks</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/previous</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <returns>Return the contents of the block</returns>
        [Get("/blocks/{hash_or_number}/previous","0.1.26")]
        public Task<BlocksGetPreviousResponse> GetPreviousAsync(string hash_or_number, long count, long page, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Block transactions</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/txs</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/{hash_or_number}/txs","0.1.26")]
        public Task<BlocksGetTxsResponse> GetTxsAsync(string hash_or_number, long count, long page, string order)
        {
            return GetTxsAsync(hash_or_number, count, page, order, CancellationToken.None);
        }

        /// <summary>Block transactions</summary>
        /// <remarks>Route template: /blocks/{hash_or_number}/txs</remarks>
        /// <param name="hash_or_number">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the transactions within the block.</returns>
        [Get("/blocks/{hash_or_number}/txs","0.1.26")]
        public Task<BlocksGetTxsResponse> GetTxsAsync(string hash_or_number, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

