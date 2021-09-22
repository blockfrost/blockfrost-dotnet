using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface ILedgerService : IBlockfrostService
    {
        /// <summary>
        ///     Blockchain genesis <c>/genesis</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger/paths/~1genesis/get">/genesis</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/genesis", "0.1.27")]
        Task<GenesisContentResponse> GetGenesisAsync();

        /// <summary>
        ///     Blockchain genesis <c>/genesis</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Ledger/paths/~1genesis/get">/genesis</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/genesis", "0.1.27")]
        Task<GenesisContentResponse> GetGenesisAsync(CancellationToken cancellationToken);
    }
}

