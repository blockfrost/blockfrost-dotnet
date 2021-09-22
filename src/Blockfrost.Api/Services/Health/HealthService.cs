using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial class HealthService : ABlockfrostService, IHealthService
    {
        /// <summary> 
        ///     Initializes a new <see cref="HealthService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health">Health</seealso> on docs.blockfrost.io
        /// </remarks>
        public HealthService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        ///     Root endpoint <c>/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1/get">/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/", "0.1.27")]
        public Task<InfoResponse> GetApiInfoAsync()
        {
            return GetApiInfoAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Root endpoint <c>/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1/get">/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/", "0.1.27")]
        public async Task<InfoResponse> GetApiInfoAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/");

            return await SendGetRequestAsync<InfoResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Backend health status <c>/health</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health/get">/health</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health", "0.1.27")]
        public Task<HealthResponse> GetHealthAsync()
        {
            return GetHealthAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Backend health status <c>/health</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health/get">/health</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health", "0.1.27")]
        public async Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/health");

            return await SendGetRequestAsync<HealthResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Current backend time <c>/health/clock</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health~1clock/get">/health/clock</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health/clock", "0.1.27")]
        public Task<HealthClockResponse> GetClockAsync()
        {
            return GetClockAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Current backend time <c>/health/clock</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health~1clock/get">/health/clock</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health/clock", "0.1.27")]
        public async Task<HealthClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/health/clock");

            return await SendGetRequestAsync<HealthClockResponse>(builder, cancellationToken);
        }
    }
}

