using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class MetricsService : ABlockfrostService, IMetricsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="MetricsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics">Metrics</seealso> on docs.blockfrost.io
        /// </remarks>
        public MetricsService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        ///     Blockfrost usage metrics <c>/metrics/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1/get">/metrics/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/", "0.1.28")]
        public async Task<Models.MetricsResponseCollection> GetMetricsAsync(CancellationToken cancellationToken = default)
        {
            var builder = GetUrlBuilder("/metrics/");

            return await SendGetRequestAsync<Models.MetricsResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Blockfrost endpoint usage metrics <c>/metrics/endpoints</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Metrics/paths/~1metrics~1endpoints/get">/metrics/endpoints</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/metrics/endpoints", "0.1.28")]
        public async Task<Models.MetricsEndpointsResponseCollection> GetEndpointsAsync(CancellationToken cancellationToken = default)
        {
            var builder = GetUrlBuilder("/metrics/endpoints");

            return await SendGetRequestAsync<Models.MetricsEndpointsResponseCollection>(builder, cancellationToken);
        }
    }
}

