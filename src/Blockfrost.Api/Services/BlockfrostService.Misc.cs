using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService
    {
        public Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<HealthResponse> GetHealthAsync()
        {
            return GetHealthAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/health");

            return await SendGetRequestAsync<HealthResponse>(urlBuilder_, cancellationToken);
        }

        public Task<NetworkResponse> NetworkAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<NetworkResponse> NetworkAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ClockResponse> GetClockAsync()
        {
            return GetClockAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/health/clock");

            return await SendGetRequestAsync<ClockResponse>(urlBuilder_, cancellationToken);
        }

        public Task<GenesisContentResponse> GenesisAsync()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<InfoResponse> GetInfoAsync()
        {
            return GetInfoAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/");

            return await SendGetRequestAsync<InfoResponse>(urlBuilder_, cancellationToken);
        }
    }
}