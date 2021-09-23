using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IGatewayService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Relay to an IPFS gateway <c>/ipfs/gateway/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway/paths/~1ipfs~1gateway~1{IPFS_path}/get">/ipfs/gateway/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the object content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/gateway/{IPFS_path}", "0.1.27")]
        Task<object> GetGatewayAsync(string IPFS_path);

        /// <summary>
        ///     Relay to an IPFS gateway <c>/ipfs/gateway/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway/paths/~1ipfs~1gateway~1{IPFS_path}/get">/ipfs/gateway/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the object content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/gateway/{IPFS_path}", "0.1.27")]
        Task<object> GetGatewayAsync(string IPFS_path, CancellationToken cancellationToken);
    }
}

