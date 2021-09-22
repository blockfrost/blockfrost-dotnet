using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class GatewayService : ABlockfrostService, IGatewayService
    {
        /// <summary> 
        ///     Initializes a new <see cref="GatewayService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway">IPFS » Gateway</seealso> on docs.blockfrost.io
        /// </remarks>
        public GatewayService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        ///     Relay to an IPFS gateway <c>/ipfs/gateway/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway/paths/~1ipfs~1gateway~1{IPFS_path}/get">/ipfs/gateway/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="ipfsPath"></param>
        /// <returns>Returns the object content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/gateway/{IPFS_path}", "0.1.27")]
        public Task<object> GetGatewayAsync(string ipfsPath)
        {
            return GetGatewayAsync(ipfsPath, CancellationToken.None);
        }

        /// <summary>
        ///     Relay to an IPFS gateway <c>/ipfs/gateway/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Gateway/paths/~1ipfs~1gateway~1{IPFS_path}/get">/ipfs/gateway/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="ipfsPath"></param>
        /// <returns>Returns the object content</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/gateway/{IPFS_path}", "0.1.27")]
        public async Task<object> GetGatewayAsync(string ipfsPath, CancellationToken cancellationToken)
        {
            if (ipfsPath == null)
            {
                throw new System.ArgumentNullException(nameof(ipfsPath));
            }

            var builder = GetUrlBuilder("/ipfs/gateway/{IPFS_path}");
            _ = builder.SetRouteParameter("{IPFS_path}", ipfsPath);

            return await SendGetRequestAsync<object>(builder, cancellationToken);
        }
    }
}

