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
    public partial interface IMetadataService 
    {

        /// <summary>Transaction metadata labels</summary>
        /// <remarks>Route template: /metadata/txs/labels</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels","0.1.26")]
        Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(long count, long page, string order);

        /// <summary>Transaction metadata labels</summary>
        /// <remarks>Route template: /metadata/txs/labels</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels","0.1.26")]
        Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(long count, long page, string order, CancellationToken token);

        /// <summary>Transaction metadata content in JSON</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels/{label}","0.1.26")]
        Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(string label, long count, long page, string order);

        /// <summary>Transaction metadata content in JSON</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels/{label}","0.1.26")]
        Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(string label, long count, long page, string order, CancellationToken token);

        /// <summary>Transaction metadata content in CBOR</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}/cbor</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        [Get("/metadata/txs/labels/{label}/cbor","0.1.26")]
        Task<MetadataGetTxsLabelsCborResponse> GetTxsLabelsCborAsync(string label, long count, long page, string order);

        /// <summary>Transaction metadata content in CBOR</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}/cbor</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        [Get("/metadata/txs/labels/{label}/cbor","0.1.26")]
        Task<MetadataGetTxsLabelsCborResponse> GetTxsLabelsCborAsync(string label, long count, long page, string order, CancellationToken token);
    }
    
    public partial class MetadataService : IMetadataService 
    {

        /// <summary>Transaction metadata labels</summary>
        /// <remarks>Route template: /metadata/txs/labels</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels","0.1.26")]
        public Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(long count, long page, string order)
        {
            return GetTxsLabelsAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>Transaction metadata labels</summary>
        /// <remarks>Route template: /metadata/txs/labels</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels","0.1.26")]
        public Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction metadata content in JSON</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels/{label}","0.1.26")]
        public Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(string label, long count, long page, string order)
        {
            return GetTxsLabelsAsync(label, count, page, order, CancellationToken.None);
        }

        /// <summary>Transaction metadata content in JSON</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content</returns>
        [Get("/metadata/txs/labels/{label}","0.1.26")]
        public Task<MetadataGetTxsLabelsResponse> GetTxsLabelsAsync(string label, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Transaction metadata content in CBOR</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}/cbor</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        [Get("/metadata/txs/labels/{label}/cbor","0.1.26")]
        public Task<MetadataGetTxsLabelsCborResponse> GetTxsLabelsCborAsync(string label, long count, long page, string order)
        {
            return GetTxsLabelsCborAsync(label, count, page, order, CancellationToken.None);
        }

        /// <summary>Transaction metadata content in CBOR</summary>
        /// <remarks>Route template: /metadata/txs/labels/{label}/cbor</remarks>
        /// <param name="label">Description</param>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Return the account delegations content in CBOR</returns>
        [Get("/metadata/txs/labels/{label}/cbor","0.1.26")]
        public Task<MetadataGetTxsLabelsCborResponse> GetTxsLabelsCborAsync(string label, long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

