using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IMetricsService : IBlockfrostService
    {
        /// <summary>
        ///     Blockfrost usage metrics <c>/metrics/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1/get">/metrics/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/", "0.1.27")]
        Task<Models.MetricsResponseCollection> GetMetricsAsync();

        /// <summary>
        ///     Blockfrost usage metrics <c>/metrics/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1/get">/metrics/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/", "0.1.27")]
        Task<Models.MetricsResponseCollection> GetMetricsAsync(CancellationToken cancellationToken);
        /// <summary>
        ///     Blockfrost endpoint usage metrics <c>/metrics/endpoints</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1endpoints/get">/metrics/endpoints</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/endpoints", "0.1.27")]
        Task<Models.MetricsEndpointsResponseCollection> GetEndpointsAsync();

        /// <summary>
        ///     Blockfrost endpoint usage metrics <c>/metrics/endpoints</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1endpoints/get">/metrics/endpoints</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/endpoints", "0.1.27")]
        Task<Models.MetricsEndpointsResponseCollection> GetEndpointsAsync(CancellationToken cancellationToken);
    }
}

