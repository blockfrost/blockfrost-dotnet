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

namespace Blockfrost.Api.Services.Metrics
{
    public partial interface IMetricsService 
    {

        /// <summary>Blockfrost usage metrics</summary>
        /// <remarks>Route template: /metrics/</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/","0.1.26")]
        Task<MetricsGetResponse> GetAsync();

        /// <summary>Blockfrost usage metrics</summary>
        /// <remarks>Route template: /metrics/</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/","0.1.26")]
        Task<MetricsGetResponse> GetAsync(CancellationToken token);

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <remarks>Route template: /metrics/endpoints</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/endpoints","0.1.26")]
        Task<MetricsGetEndpointsResponse> GetEndpointsAsync();

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <remarks>Route template: /metrics/endpoints</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/endpoints","0.1.26")]
        Task<MetricsGetEndpointsResponse> GetEndpointsAsync(CancellationToken token);
    }
    
    public partial class MetricsService : IMetricsService 
    {

        /// <summary>Blockfrost usage metrics</summary>
        /// <remarks>Route template: /metrics/</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/","0.1.26")]
        public Task<MetricsGetResponse> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>Blockfrost usage metrics</summary>
        /// <remarks>Route template: /metrics/</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/","0.1.26")]
        public Task<MetricsGetResponse> GetAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <remarks>Route template: /metrics/endpoints</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/endpoints","0.1.26")]
        public Task<MetricsGetEndpointsResponse> GetEndpointsAsync()
        {
            return GetEndpointsAsync(CancellationToken.None);
        }

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <remarks>Route template: /metrics/endpoints</remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        [Get("/metrics/endpoints","0.1.26")]
        public Task<MetricsGetEndpointsResponse> GetEndpointsAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

