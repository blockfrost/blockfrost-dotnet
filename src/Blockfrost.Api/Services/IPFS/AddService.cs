using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class AddService : ABlockfrostService, IAddService
    {
        /// <summary> 
        ///     Initializes a new <see cref="AddService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add">IPFS » Add</seealso> on docs.blockfrost.io
        /// </remarks>
        public AddService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/add", "0.1.27")]
        public Task<string> PostAddAsync()
        {
            return PostAddAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/add", "0.1.27")]
        public async Task<string> PostAddAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/ipfs/add");

            return await SendPostRequestAsync<string>(default(System.IO.Stream), builder, cancellationToken);
        }
    }
}

