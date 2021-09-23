using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IHealthService : IBlockfrostService
    {
        /// <summary>
        ///     Root endpoint <c>/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1/get">/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/", "0.1.27")]
        Task<Models.InfoResponse> GetApiInfoAsync();

        /// <summary>
        ///     Root endpoint <c>/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1/get">/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/", "0.1.27")]
        Task<Models.InfoResponse> GetApiInfoAsync(CancellationToken cancellationToken);
        /// <summary>
        ///     Backend health status <c>/health</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health/get">/health</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health", "0.1.27")]
        Task<Models.HealthResponse> GetHealthAsync();

        /// <summary>
        ///     Backend health status <c>/health</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health/get">/health</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health", "0.1.27")]
        Task<Models.HealthResponse> GetHealthAsync(CancellationToken cancellationToken);
        /// <summary>
        ///     Current backend time <c>/health/clock</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health~1clock/get">/health/clock</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health/clock", "0.1.27")]
        Task<Models.HealthClockResponse> GetClockAsync();

        /// <summary>
        ///     Current backend time <c>/health/clock</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Health/paths/~1health~1clock/get">/health/clock</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/health/clock", "0.1.27")]
        Task<Models.HealthClockResponse> GetClockAsync(CancellationToken cancellationToken);
    }
}

