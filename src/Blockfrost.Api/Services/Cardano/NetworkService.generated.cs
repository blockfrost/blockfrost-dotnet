using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial class NetworkService : ABlockfrostService, INetworkService
    {
        /// <summary> 
        ///     Initializes a new <see cref="NetworkService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network">Cardano » Network</seealso> on docs.blockfrost.io
        /// </remarks>
        public NetworkService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        ///     Network information <c>/network</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network/paths/~1network/get">/network</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/network", "0.1.27")]
        public Task<NetworkResponse> GetNetworkAsync()
        {
            return GetNetworkAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Network information <c>/network</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Network/paths/~1network/get">/network</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/network", "0.1.27")]
        public async Task<NetworkResponse> GetNetworkAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/network");

            return await SendGetRequestAsync<NetworkResponse>(builder, cancellationToken);
        }
    }
}

