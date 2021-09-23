using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class ScriptsService : ABlockfrostService, IScriptsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="ScriptsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Scripts">Cardano » Scripts</seealso> on docs.blockfrost.io
        /// </remarks>
        public ScriptsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

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
        public Task<Models.ScriptsResponseCollection> GetScriptsAsync(int? count, int? page, ESortOrder? order)
        {
            return GetScriptsAsync(count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.ScriptsResponseCollection> GetScriptsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/scripts");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.ScriptsResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.ScriptResponse> GetScriptsAsync(string script_hash)
        {
            return GetScriptsAsync(script_hash, CancellationToken.None);
        }

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
        public async Task<Models.ScriptResponse> GetScriptsAsync(string script_hash, CancellationToken cancellationToken)
        {
            if (script_hash == null)
            {
                throw new System.ArgumentNullException(nameof(script_hash));
            }

            var builder = GetUrlBuilder("/scripts/{script_hash}");
            _ = builder.SetRouteParameter("{script_hash}", script_hash);

            return await SendGetRequestAsync<Models.ScriptResponse>(builder, cancellationToken);
        }
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
        public Task<Models.ScriptRedeemersResponseCollection> GetRedeemersAsync(string script_hash, int? count, int? page, ESortOrder? order)
        {
            return GetRedeemersAsync(script_hash, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.ScriptRedeemersResponseCollection> GetRedeemersAsync(string script_hash, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (script_hash == null)
            {
                throw new System.ArgumentNullException(nameof(script_hash));
            }

            var builder = GetUrlBuilder("/scripts/{script_hash}/redeemers");
            _ = builder.SetRouteParameter("{script_hash}", script_hash);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.ScriptRedeemersResponseCollection>(builder, cancellationToken);
        }
    }
}

