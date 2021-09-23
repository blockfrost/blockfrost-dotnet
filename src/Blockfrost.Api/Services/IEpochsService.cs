using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IEpochsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Latest epoch <c>/epochs/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest/get">/epochs/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest", "0.1.27")]
        Task<Models.EpochContentResponse> GetLatestAsync();

        /// <summary>
        ///     Latest epoch <c>/epochs/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest/get">/epochs/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest", "0.1.27")]
        Task<Models.EpochContentResponse> GetLatestAsync(CancellationToken cancellationToken);
        /// <summary>
        ///     Latest epoch protocol parameters <c>/epochs/latest/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest~1parameters/get">/epochs/latest/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest/parameters", "0.1.27")]
        Task<Models.EpochParamContentResponse> GetLatestParametersAsync();

        /// <summary>
        ///     Latest epoch protocol parameters <c>/epochs/latest/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest~1parameters/get">/epochs/latest/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest/parameters", "0.1.27")]
        Task<Models.EpochParamContentResponse> GetLatestParametersAsync(CancellationToken cancellationToken);
        /// <summary>
        ///     Specific epoch <c>/epochs/{number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}/get">/epochs/{number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the epoch data.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}", "0.1.27")]
        Task<Models.EpochContentResponse> GetEpochsAsync(int number);

        /// <summary>
        ///     Specific epoch <c>/epochs/{number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}/get">/epochs/{number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the epoch data.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}", "0.1.27")]
        Task<Models.EpochContentResponse> GetEpochsAsync(int number, CancellationToken cancellationToken);
        /// <summary>
        ///     Listing of next epochs <c>/epochs/{number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1next/get">/epochs/{number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/next", "0.1.27")]
        Task<Models.EpochContentResponseCollection> GetNextAsync(int number, int? count, int? page);

        /// <summary>
        ///     Listing of next epochs <c>/epochs/{number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1next/get">/epochs/{number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/next", "0.1.27")]
        Task<Models.EpochContentResponseCollection> GetNextAsync(int number, int? count, int? page, CancellationToken cancellationToken);
        /// <summary>
        ///     Listing of previous epochs <c>/epochs/{number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1previous/get">/epochs/{number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/previous", "0.1.27")]
        Task<Models.EpochContentResponseCollection> GetPreviousAsync(int number, int? count, int? page);

        /// <summary>
        ///     Listing of previous epochs <c>/epochs/{number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1previous/get">/epochs/{number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/previous", "0.1.27")]
        Task<Models.EpochContentResponseCollection> GetPreviousAsync(int number, int? count, int? page, CancellationToken cancellationToken);
        /// <summary>
        ///     Stake distribution <c>/epochs/{number}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes/get">/epochs/{number}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes", "0.1.27")]
        Task<Models.EpochStakeContentResponseCollection> GetStakesAsync(int number, int? count, int? page);

        /// <summary>
        ///     Stake distribution <c>/epochs/{number}/stakes</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes/get">/epochs/{number}/stakes</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes", "0.1.27")]
        Task<Models.EpochStakeContentResponseCollection> GetStakesAsync(int number, int? count, int? page, CancellationToken cancellationToken);
        /// <summary>
        ///     Stake distribution by pool <c>/epochs/{number}/stakes/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes~1{pool_id}/get">/epochs/{number}/stakes/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes/{pool_id}", "0.1.27")]
        Task<Models.EpochStakePoolContentResponseCollection> GetStakesAsync(int number, string pool_id, int? count, int? page);

        /// <summary>
        ///     Stake distribution by pool <c>/epochs/{number}/stakes/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1stakes~1{pool_id}/get">/epochs/{number}/stakes/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/stakes/{pool_id}", "0.1.27")]
        Task<Models.EpochStakePoolContentResponseCollection> GetStakesAsync(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken);
        /// <summary>
        ///     Block distribution <c>/epochs/{number}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks/get">/epochs/{number}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks", "0.1.27")]
        Task<Models.StringCollection> GetBlocksAsync(int number, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Block distribution <c>/epochs/{number}/blocks</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks/get">/epochs/{number}/blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks", "0.1.27")]
        Task<Models.StringCollection> GetBlocksAsync(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Block distribution by pool <c>/epochs/{number}/blocks/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks~1{pool_id}/get">/epochs/{number}/blocks/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks/{pool_id}", "0.1.27")]
        Task<Models.StringCollection> GetBlocksAsync(int number, string pool_id, int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     Block distribution by pool <c>/epochs/{number}/blocks/{pool_id}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1blocks~1{pool_id}/get">/epochs/{number}/blocks/{pool_id}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/blocks/{pool_id}", "0.1.27")]
        Task<Models.StringCollection> GetBlocksAsync(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Protocol parameters <c>/epochs/{number}/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1parameters/get">/epochs/{number}/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/parameters", "0.1.27")]
        Task<Models.EpochParamContentResponse> GetParametersAsync(int number);

        /// <summary>
        ///     Protocol parameters <c>/epochs/{number}/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1{number}~1parameters/get">/epochs/{number}/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/{number}/parameters", "0.1.27")]
        Task<Models.EpochParamContentResponse> GetParametersAsync(int number, CancellationToken cancellationToken);
    }
}

