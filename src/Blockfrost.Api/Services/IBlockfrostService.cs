using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    /// <summary>
    /// Specifies basic functionality for services interacting with the Blockfrost API
    /// </summary>
    public partial interface IBlockfrostService
    {
        string Network { get; }

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricsEndpointResponse>> EndpointsAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken);

        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ClockResponse> GetClockAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken);

        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<HealthResponse> GetHealthAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken);

        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<InfoResponse> GetInfoAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken);

        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricResponse>> GetMetricsAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken);

    }
}
