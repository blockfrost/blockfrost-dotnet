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
    public partial interface IAddressesService 
    {

        /// <summary>Specific address</summary>
        /// <remarks>Route template: /addresses/{address}</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the address content.</returns>
        [Get("/addresses/{address}","0.1.26")]
        Task<AddressesGetResponse> GetAsync(string address);

        /// <summary>Specific address</summary>
        /// <remarks>Route template: /addresses/{address}</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the address content.</returns>
        [Get("/addresses/{address}","0.1.26")]
        Task<AddressesGetResponse> GetAsync(string address, CancellationToken token);

        /// <summary>Address details</summary>
        /// <remarks>Route template: /addresses/{address}/total</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the Address details.</returns>
        [Get("/addresses/{address}/total","0.1.26")]
        Task<AddressesGetTotalResponse> GetTotalAsync(string address);

        /// <summary>Address details</summary>
        /// <remarks>Route template: /addresses/{address}/total</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the Address details.</returns>
        [Get("/addresses/{address}/total","0.1.26")]
        Task<AddressesGetTotalResponse> GetTotalAsync(string address, CancellationToken token);

        /// <summary>Address UTXOs</summary>
        /// <remarks>Route template: /addresses/{address}/utxos</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/utxos","0.1.26")]
        Task<AddressesGetUtxosResponse> GetUtxosAsync(string address, long count, long page, string order);

        /// <summary>Address UTXOs</summary>
        /// <remarks>Route template: /addresses/{address}/utxos</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/utxos","0.1.26")]
        Task<AddressesGetUtxosResponse> GetUtxosAsync(string address, long count, long page, string order, CancellationToken token);

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/txs</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/txs","0.1.26")]
        Task<AddressesGetTxsResponse> GetTxsAsync(string address, long count, long page, string order);

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/txs</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/txs","0.1.26")]
        Task<AddressesGetTxsResponse> GetTxsAsync(string address, long count, long page, string order, CancellationToken token);

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/transactions</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <param name="from">Description</param>
        /// <param name="to">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/transactions","0.1.26")]
        Task<AddressesGetTransactionsResponse> GetTransactionsAsync(string address, long count, long page, string order, string from, string to);

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/transactions</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <param name="from">Description</param>
        /// <param name="to">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/transactions","0.1.26")]
        Task<AddressesGetTransactionsResponse> GetTransactionsAsync(string address, long count, long page, string order, string from, string to, CancellationToken token);
    }
    
    public partial class AddressesService : IAddressesService 
    {

        /// <summary>Specific address</summary>
        /// <remarks>Route template: /addresses/{address}</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the address content.</returns>
        [Get("/addresses/{address}","0.1.26")]
        public Task<AddressesGetResponse> GetAsync(string address)
        {
            return GetAsync(address, CancellationToken.None);
        }

        /// <summary>Specific address</summary>
        /// <remarks>Route template: /addresses/{address}</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the address content.</returns>
        [Get("/addresses/{address}","0.1.26")]
        public Task<AddressesGetResponse> GetAsync(string address, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Address details</summary>
        /// <remarks>Route template: /addresses/{address}/total</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the Address details.</returns>
        [Get("/addresses/{address}/total","0.1.26")]
        public Task<AddressesGetTotalResponse> GetTotalAsync(string address)
        {
            return GetTotalAsync(address, CancellationToken.None);
        }

        /// <summary>Address details</summary>
        /// <remarks>Route template: /addresses/{address}/total</remarks>
        /// <param name="address">Description</param>
        /// <returns>Return the Address details.</returns>
        [Get("/addresses/{address}/total","0.1.26")]
        public Task<AddressesGetTotalResponse> GetTotalAsync(string address, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Address UTXOs</summary>
        /// <remarks>Route template: /addresses/{address}/utxos</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/utxos","0.1.26")]
        public Task<AddressesGetUtxosResponse> GetUtxosAsync(string address, long count, long page, string order)
        {
            return GetUtxosAsync(address, count, page, order, CancellationToken.None);
        }

        /// <summary>Address UTXOs</summary>
        /// <remarks>Route template: /addresses/{address}/utxos</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/utxos","0.1.26")]
        public Task<AddressesGetUtxosResponse> GetUtxosAsync(string address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/txs</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/txs","0.1.26")]
        public Task<AddressesGetTxsResponse> GetTxsAsync(string address, long count, long page, string order)
        {
            return GetTxsAsync(address, count, page, order, CancellationToken.None);
        }

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/txs</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/txs","0.1.26")]
        public Task<AddressesGetTxsResponse> GetTxsAsync(string address, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/transactions</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <param name="from">Description</param>
        /// <param name="to">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/transactions","0.1.26")]
        public Task<AddressesGetTransactionsResponse> GetTransactionsAsync(string address, long count, long page, string order, string from, string to)
        {
            return GetTransactionsAsync(address, count, page, order, from, to, CancellationToken.None);
        }

        /// <summary>Address transactions</summary>
        /// <remarks>Route template: /addresses/{address}/transactions</remarks>
        /// <param name="address">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <param name="from">Description</param>
        /// <param name="to">Description</param>
        /// <returns>Return the address content</returns>
        [Get("/addresses/{address}/transactions","0.1.26")]
        public Task<AddressesGetTransactionsResponse> GetTransactionsAsync(string address, long count, long page, string order, string from, string to, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

