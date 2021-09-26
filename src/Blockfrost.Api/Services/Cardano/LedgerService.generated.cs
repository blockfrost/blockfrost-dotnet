using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class LedgerService : ABlockfrostService, ILedgerService
    {
        /// <summary> 
        ///     Initializes a new <see cref="LedgerService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger">Cardano » Ledger</seealso> on docs.blockfrost.io
        /// </remarks>
        public LedgerService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Blockchain genesis <c>/genesis</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger/paths/~1genesis/get">/genesis</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/genesis", "0.1.27")]
        public Task<Models.GenesisContentResponse> GetGenesisAsync()
        {
            return GetGenesisAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Blockchain genesis <c>/genesis</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger/paths/~1genesis/get">/genesis</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/genesis", "0.1.27")]
        public async Task<Models.GenesisContentResponse> GetGenesisAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/genesis");

            return await SendGetRequestAsync<Models.GenesisContentResponse>(builder, cancellationToken);
        }
    }
}

