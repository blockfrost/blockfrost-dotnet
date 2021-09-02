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
    public partial interface INetworkService 
    {

        /// <summary>Network information</summary>
        /// <remarks>Route template: /network</remarks>
        /// <returns>Return detailed network information.</returns>
        [Get("/network","0.1.26")]
        Task<NetworkGetResponse> GetAsync();

        /// <summary>Network information</summary>
        /// <remarks>Route template: /network</remarks>
        /// <returns>Return detailed network information.</returns>
        [Get("/network","0.1.26")]
        Task<NetworkGetResponse> GetAsync(CancellationToken token);
    }
    
    public partial class NetworkService : INetworkService 
    {

        /// <summary>Network information</summary>
        /// <remarks>Route template: /network</remarks>
        /// <returns>Return detailed network information.</returns>
        [Get("/network","0.1.26")]
        public Task<NetworkGetResponse> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>Network information</summary>
        /// <remarks>Route template: /network</remarks>
        /// <returns>Return detailed network information.</returns>
        [Get("/network","0.1.26")]
        public Task<NetworkGetResponse> GetAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

