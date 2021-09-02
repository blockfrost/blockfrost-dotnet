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
    public partial interface ITransactionsService 
    {

        /// <summary>Specific transaction</summary>
        /// <remarks>Route template: /txs/{hash}</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}","0.1.26")]
        Task<TransactionsGetTxsResponse> GetTxsAsync(string hash);

        /// <summary>Specific transaction</summary>
        /// <remarks>Route template: /txs/{hash}</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}","0.1.26")]
        Task<TransactionsGetTxsResponse> GetTxsAsync(string hash, CancellationToken token);

        /// <summary>Transaction UTXOs</summary>
        /// <remarks>Route template: /txs/{hash}/utxos</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}/utxos","0.1.26")]
        Task<TransactionsGetTxsUtxosResponse> GetTxsUtxosAsync(string hash);

        /// <summary>Transaction UTXOs</summary>
        /// <remarks>Route template: /txs/{hash}/utxos</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}/utxos","0.1.26")]
        Task<TransactionsGetTxsUtxosResponse> GetTxsUtxosAsync(string hash, CancellationToken token);

        /// <summary>Transaction stake addresses certificates</summary>
        /// <remarks>Route template: /txs/{hash}/stakes</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        [Get("/txs/{hash}/stakes","0.1.26")]
        Task<TransactionsGetTxsStakesResponse> GetTxsStakesAsync(string hash);

        /// <summary>Transaction stake addresses certificates</summary>
        /// <remarks>Route template: /txs/{hash}/stakes</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        [Get("/txs/{hash}/stakes","0.1.26")]
        Task<TransactionsGetTxsStakesResponse> GetTxsStakesAsync(string hash, CancellationToken token);

        /// <summary>Transaction delegation certificates</summary>
        /// <remarks>Route template: /txs/{hash}/delegations</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        [Get("/txs/{hash}/delegations","0.1.26")]
        Task<TransactionsGetTxsDelegationsResponse> GetTxsDelegationsAsync(string hash);

        /// <summary>Transaction delegation certificates</summary>
        /// <remarks>Route template: /txs/{hash}/delegations</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        [Get("/txs/{hash}/delegations","0.1.26")]
        Task<TransactionsGetTxsDelegationsResponse> GetTxsDelegationsAsync(string hash, CancellationToken token);

        /// <summary>Transaction withdrawal</summary>
        /// <remarks>Route template: /txs/{hash}/withdrawals</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        [Get("/txs/{hash}/withdrawals","0.1.26")]
        Task<TransactionsGetTxsWithdrawalsResponse> GetTxsWithdrawalsAsync(string hash);

        /// <summary>Transaction withdrawal</summary>
        /// <remarks>Route template: /txs/{hash}/withdrawals</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        [Get("/txs/{hash}/withdrawals","0.1.26")]
        Task<TransactionsGetTxsWithdrawalsResponse> GetTxsWithdrawalsAsync(string hash, CancellationToken token);

        /// <summary>Transaction MIRs</summary>
        /// <remarks>Route template: /txs/{hash}/mirs</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        [Get("/txs/{hash}/mirs","0.1.26")]
        Task<TransactionsGetTxsMirsResponse> GetTxsMirsAsync(string hash);

        /// <summary>Transaction MIRs</summary>
        /// <remarks>Route template: /txs/{hash}/mirs</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        [Get("/txs/{hash}/mirs","0.1.26")]
        Task<TransactionsGetTxsMirsResponse> GetTxsMirsAsync(string hash, CancellationToken token);

        /// <summary>Transaction stake pool registration and update certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_updates</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        [Get("/txs/{hash}/pool_updates","0.1.26")]
        Task<TransactionsGetTxsPoolUpdatesResponse> GetTxsPoolUpdatesAsync(string hash);

        /// <summary>Transaction stake pool registration and update certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_updates</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        [Get("/txs/{hash}/pool_updates","0.1.26")]
        Task<TransactionsGetTxsPoolUpdatesResponse> GetTxsPoolUpdatesAsync(string hash, CancellationToken token);

        /// <summary>Transaction stake pool retirement certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_retires</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/pool_retires","0.1.26")]
        Task<TransactionsGetTxsPoolRetiresResponse> GetTxsPoolRetiresAsync(string hash);

        /// <summary>Transaction stake pool retirement certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_retires</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/pool_retires","0.1.26")]
        Task<TransactionsGetTxsPoolRetiresResponse> GetTxsPoolRetiresAsync(string hash, CancellationToken token);

        /// <summary>Transaction metadata</summary>
        /// <remarks>Route template: /txs/{hash}/metadata</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata","0.1.26")]
        Task<TransactionsGetTxsMetadataResponse> GetTxsMetadataAsync(string hash);

        /// <summary>Transaction metadata</summary>
        /// <remarks>Route template: /txs/{hash}/metadata</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata","0.1.26")]
        Task<TransactionsGetTxsMetadataResponse> GetTxsMetadataAsync(string hash, CancellationToken token);

        /// <summary>Transaction metadata in CBOR</summary>
        /// <remarks>Route template: /txs/{hash}/metadata/cbor</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata/cbor","0.1.26")]
        Task<TransactionsGetTxsMetadataCborResponse> GetTxsMetadataCborAsync(string hash);

        /// <summary>Transaction metadata in CBOR</summary>
        /// <remarks>Route template: /txs/{hash}/metadata/cbor</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata/cbor","0.1.26")]
        Task<TransactionsGetTxsMetadataCborResponse> GetTxsMetadataCborAsync(string hash, CancellationToken token);
    }
    
    public partial class TransactionsService : ITransactionsService 
    {

        /// <summary>Specific transaction</summary>
        /// <remarks>Route template: /txs/{hash}</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}","0.1.26")]
        public Task<TransactionsGetTxsResponse> GetTxsAsync(string hash)
        {
            return GetTxsAsync(hash, CancellationToken.None);
        }

        /// <summary>Specific transaction</summary>
        /// <remarks>Route template: /txs/{hash}</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}","0.1.26")]
        public Task<TransactionsGetTxsResponse> GetTxsAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction UTXOs</summary>
        /// <remarks>Route template: /txs/{hash}/utxos</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}/utxos","0.1.26")]
        public Task<TransactionsGetTxsUtxosResponse> GetTxsUtxosAsync(string hash)
        {
            return GetTxsUtxosAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction UTXOs</summary>
        /// <remarks>Route template: /txs/{hash}/utxos</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Return the contents of the transaction.</returns>
        [Get("/txs/{hash}/utxos","0.1.26")]
        public Task<TransactionsGetTxsUtxosResponse> GetTxsUtxosAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction stake addresses certificates</summary>
        /// <remarks>Route template: /txs/{hash}/stakes</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        [Get("/txs/{hash}/stakes","0.1.26")]
        public Task<TransactionsGetTxsStakesResponse> GetTxsStakesAsync(string hash)
        {
            return GetTxsStakesAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction stake addresses certificates</summary>
        /// <remarks>Route template: /txs/{hash}/stakes</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        [Get("/txs/{hash}/stakes","0.1.26")]
        public Task<TransactionsGetTxsStakesResponse> GetTxsStakesAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction delegation certificates</summary>
        /// <remarks>Route template: /txs/{hash}/delegations</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        [Get("/txs/{hash}/delegations","0.1.26")]
        public Task<TransactionsGetTxsDelegationsResponse> GetTxsDelegationsAsync(string hash)
        {
            return GetTxsDelegationsAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction delegation certificates</summary>
        /// <remarks>Route template: /txs/{hash}/delegations</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        [Get("/txs/{hash}/delegations","0.1.26")]
        public Task<TransactionsGetTxsDelegationsResponse> GetTxsDelegationsAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction withdrawal</summary>
        /// <remarks>Route template: /txs/{hash}/withdrawals</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        [Get("/txs/{hash}/withdrawals","0.1.26")]
        public Task<TransactionsGetTxsWithdrawalsResponse> GetTxsWithdrawalsAsync(string hash)
        {
            return GetTxsWithdrawalsAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction withdrawal</summary>
        /// <remarks>Route template: /txs/{hash}/withdrawals</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        [Get("/txs/{hash}/withdrawals","0.1.26")]
        public Task<TransactionsGetTxsWithdrawalsResponse> GetTxsWithdrawalsAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction MIRs</summary>
        /// <remarks>Route template: /txs/{hash}/mirs</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        [Get("/txs/{hash}/mirs","0.1.26")]
        public Task<TransactionsGetTxsMirsResponse> GetTxsMirsAsync(string hash)
        {
            return GetTxsMirsAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction MIRs</summary>
        /// <remarks>Route template: /txs/{hash}/mirs</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        [Get("/txs/{hash}/mirs","0.1.26")]
        public Task<TransactionsGetTxsMirsResponse> GetTxsMirsAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction stake pool registration and update certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_updates</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        [Get("/txs/{hash}/pool_updates","0.1.26")]
        public Task<TransactionsGetTxsPoolUpdatesResponse> GetTxsPoolUpdatesAsync(string hash)
        {
            return GetTxsPoolUpdatesAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction stake pool registration and update certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_updates</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool certificates of a specific transaction</returns>
        [Get("/txs/{hash}/pool_updates","0.1.26")]
        public Task<TransactionsGetTxsPoolUpdatesResponse> GetTxsPoolUpdatesAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction stake pool retirement certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_retires</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/pool_retires","0.1.26")]
        public Task<TransactionsGetTxsPoolRetiresResponse> GetTxsPoolRetiresAsync(string hash)
        {
            return GetTxsPoolRetiresAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction stake pool retirement certificates</summary>
        /// <remarks>Route template: /txs/{hash}/pool_retires</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/pool_retires","0.1.26")]
        public Task<TransactionsGetTxsPoolRetiresResponse> GetTxsPoolRetiresAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction metadata</summary>
        /// <remarks>Route template: /txs/{hash}/metadata</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata","0.1.26")]
        public Task<TransactionsGetTxsMetadataResponse> GetTxsMetadataAsync(string hash)
        {
            return GetTxsMetadataAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction metadata</summary>
        /// <remarks>Route template: /txs/{hash}/metadata</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata","0.1.26")]
        public Task<TransactionsGetTxsMetadataResponse> GetTxsMetadataAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction metadata in CBOR</summary>
        /// <remarks>Route template: /txs/{hash}/metadata/cbor</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata/cbor","0.1.26")]
        public Task<TransactionsGetTxsMetadataCborResponse> GetTxsMetadataCborAsync(string hash)
        {
            return GetTxsMetadataCborAsync(hash, CancellationToken.None);
        }

        /// <summary>Transaction metadata in CBOR</summary>
        /// <remarks>Route template: /txs/{hash}/metadata/cbor</remarks>
        /// <param name="hash">Description</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        [Get("/txs/{hash}/metadata/cbor","0.1.26")]
        public Task<TransactionsGetTxsMetadataCborResponse> GetTxsMetadataCborAsync(string hash, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

