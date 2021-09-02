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

namespace Blockfrost.Api.Services.IPFS
{
    public partial interface IPinsService 
    {

        /// <summary>List pinned objects</summary>
        /// <remarks>Route template: /ipfs/pin/list/</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Returns pinned objects</returns>
        [Get("/ipfs/pin/list/","0.1.26")]
        Task<PinsGetPinListResponse> GetPinListAsync(long count, long page, string order);

        /// <summary>List pinned objects</summary>
        /// <remarks>Route template: /ipfs/pin/list/</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Returns pinned objects</returns>
        [Get("/ipfs/pin/list/","0.1.26")]
        Task<PinsGetPinListResponse> GetPinListAsync(long count, long page, string order, CancellationToken token);

        /// <summary>Get details about pinned object</summary>
        /// <remarks>Route template: /ipfs/pin/list/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the pins pinned</returns>
        [Get("/ipfs/pin/list/{IPFS_path}","0.1.26")]
        Task<PinsGetPinListResponse> GetPinListAsync(string IPFS_path);

        /// <summary>Get details about pinned object</summary>
        /// <remarks>Route template: /ipfs/pin/list/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the pins pinned</returns>
        [Get("/ipfs/pin/list/{IPFS_path}","0.1.26")]
        Task<PinsGetPinListResponse> GetPinListAsync(string IPFS_path, CancellationToken token);
    }
    
    public partial class PinsService : IPinsService 
    {

        /// <summary>List pinned objects</summary>
        /// <remarks>Route template: /ipfs/pin/list/</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Returns pinned objects</returns>
        [Get("/ipfs/pin/list/","0.1.26")]
        public Task<PinsGetPinListResponse> GetPinListAsync(long count, long page, string order)
        {
            return GetPinListAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>List pinned objects</summary>
        /// <remarks>Route template: /ipfs/pin/list/</remarks>
        /// <param name="count">Description</param>
        /// <param name="page">Description</param>
        /// <param name="order">Description</param>
        /// <returns>Returns pinned objects</returns>
        [Get("/ipfs/pin/list/","0.1.26")]
        public Task<PinsGetPinListResponse> GetPinListAsync(long count, long page, string order, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Get details about pinned object</summary>
        /// <remarks>Route template: /ipfs/pin/list/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the pins pinned</returns>
        [Get("/ipfs/pin/list/{IPFS_path}","0.1.26")]
        public Task<PinsGetPinListResponse> GetPinListAsync(string IPFS_path)
        {
            return GetPinListAsync(IPFS_path, CancellationToken.None);
        }

        /// <summary>Get details about pinned object</summary>
        /// <remarks>Route template: /ipfs/pin/list/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the pins pinned</returns>
        [Get("/ipfs/pin/list/{IPFS_path}","0.1.26")]
        public Task<PinsGetPinListResponse> GetPinListAsync(string IPFS_path, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

