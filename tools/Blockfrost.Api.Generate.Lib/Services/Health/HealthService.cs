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

namespace Blockfrost.Api.Services.Health
{
    public partial interface IHealthService 
    {

        /// <summary>Root endpoint</summary>
        /// <remarks>Route template: /</remarks>
        /// <returns>Information pointing to the documentation.</returns>
        [Get("/","0.1.26")]
        Task<HealthGetResponse> GetAsync();

        /// <summary>Root endpoint</summary>
        /// <remarks>Route template: /</remarks>
        /// <returns>Information pointing to the documentation.</returns>
        [Get("/","0.1.26")]
        Task<HealthGetResponse> GetAsync(CancellationToken token);

        /// <summary>Backend health status</summary>
        /// <remarks>Route template: /health</remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        [Get("/health","0.1.26")]
        Task<HealthGetResponse> GetAsync();

        /// <summary>Backend health status</summary>
        /// <remarks>Route template: /health</remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        [Get("/health","0.1.26")]
        Task<HealthGetResponse> GetAsync(CancellationToken token);

        /// <summary>Current backend time</summary>
        /// <remarks>Route template: /health/clock</remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        [Get("/health/clock","0.1.26")]
        Task<HealthGetClockResponse> GetClockAsync();

        /// <summary>Current backend time</summary>
        /// <remarks>Route template: /health/clock</remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        [Get("/health/clock","0.1.26")]
        Task<HealthGetClockResponse> GetClockAsync(CancellationToken token);
    }
    
    public partial class HealthService : IHealthService 
    {

        /// <summary>Root endpoint</summary>
        /// <remarks>Route template: /</remarks>
        /// <returns>Information pointing to the documentation.</returns>
        [Get("/","0.1.26")]
        public Task<HealthGetResponse> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>Root endpoint</summary>
        /// <remarks>Route template: /</remarks>
        /// <returns>Information pointing to the documentation.</returns>
        [Get("/","0.1.26")]
        public Task<HealthGetResponse> GetAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Backend health status</summary>
        /// <remarks>Route template: /health</remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        [Get("/health","0.1.26")]
        public Task<HealthGetResponse> GetAsync()
        {
            return GetAsync(CancellationToken.None);
        }

        /// <summary>Backend health status</summary>
        /// <remarks>Route template: /health</remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        [Get("/health","0.1.26")]
        public Task<HealthGetResponse> GetAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>Current backend time</summary>
        /// <remarks>Route template: /health/clock</remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        [Get("/health/clock","0.1.26")]
        public Task<HealthGetClockResponse> GetClockAsync()
        {
            return GetClockAsync(CancellationToken.None);
        }

        /// <summary>Current backend time</summary>
        /// <remarks>Route template: /health/clock</remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        [Get("/health/clock","0.1.26")]
        public Task<HealthGetClockResponse> GetClockAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}

