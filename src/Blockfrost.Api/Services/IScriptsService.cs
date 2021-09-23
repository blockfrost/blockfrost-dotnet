using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IScriptsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Scripts <c>/scripts</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts/get">/scripts</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of scripts</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts", "0.1.27")]
        Task<Models.ScriptsResponseCollection> GetScriptsAsync(int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Scripts <c>/scripts</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts/get">/scripts</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of scripts</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts", "0.1.27")]
        Task<Models.ScriptsResponseCollection> GetScriptsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Specific script <c>/scripts/{script_hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}/get">/scripts/{script_hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <returns>Return the information about a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}", "0.1.27")]
        Task<Models.ScriptResponse> GetScriptsAsync(string script_hash);

        /// <summary>
        ///     Specific script <c>/scripts/{script_hash}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}/get">/scripts/{script_hash}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <returns>Return the information about a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}", "0.1.27")]
        Task<Models.ScriptResponse> GetScriptsAsync(string script_hash, CancellationToken cancellationToken);
        /// <summary>
        ///     Redeemers of a specific script <c>/scripts/{script_hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}~1redeemers/get">/scripts/{script_hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about redeemers of a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}/redeemers", "0.1.27")]
        Task<Models.ScriptRedeemersResponseCollection> GetRedeemersAsync(string script_hash, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Redeemers of a specific script <c>/scripts/{script_hash}/redeemers</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts/paths/~1scripts~1{script_hash}~1redeemers/get">/scripts/{script_hash}/redeemers</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="script_hash">Hash of the script</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about redeemers of a specific script</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/scripts/{script_hash}/redeemers", "0.1.27")]
        Task<Models.ScriptRedeemersResponseCollection> GetRedeemersAsync(string script_hash, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}

