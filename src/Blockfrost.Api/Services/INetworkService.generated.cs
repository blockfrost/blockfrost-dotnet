using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface INetworkService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Network information <c>/network</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network/paths/~1network/get">/network</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/network", "0.1.27")]
        Task<Models.NetworkResponse> GetNetworkAsync();

        /// <summary>
        ///     Network information <c>/network</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network/paths/~1network/get">/network</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/network", "0.1.27")]
        Task<Models.NetworkResponse> GetNetworkAsync(CancellationToken cancellationToken);
    }
}

