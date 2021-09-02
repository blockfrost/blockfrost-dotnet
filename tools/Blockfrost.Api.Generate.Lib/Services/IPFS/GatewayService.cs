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
    public partial interface IGatewayService 
    {

        /// <summary>Relay to an IPFS gateway</summary>
        /// <remarks>Route template: /ipfs/gateway/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the object content</returns>
        [Get("/ipfs/gateway/{IPFS_path}","0.1.26")]
        Task<GatewayGetResponse> GetAsync(string IPFS_path);

        /// <summary>Relay to an IPFS gateway</summary>
        /// <remarks>Route template: /ipfs/gateway/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the object content</returns>
        [Get("/ipfs/gateway/{IPFS_path}","0.1.26")]
        Task<GatewayGetResponse> GetAsync(string IPFS_path, CancellationToken token);
    }
    
    public partial class GatewayService : IGatewayService 
    {

        /// <summary>Relay to an IPFS gateway</summary>
        /// <remarks>Route template: /ipfs/gateway/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the object content</returns>
        [Get("/ipfs/gateway/{IPFS_path}","0.1.26")]
        public Task<GatewayGetResponse> GetAsync(string IPFS_path)
        {
            return GetAsync(IPFS_path, CancellationToken.None);
        }

        /// <summary>Relay to an IPFS gateway</summary>
        /// <remarks>Route template: /ipfs/gateway/{IPFS_path}</remarks>
        /// <param name="IPFS_path">Description</param>
        /// <returns>Returns the object content</returns>
        [Get("/ipfs/gateway/{IPFS_path}","0.1.26")]
        public Task<GatewayGetResponse> GetAsync(string IPFS_path, CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

