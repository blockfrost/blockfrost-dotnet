using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class EpochsService : ABlockfrostService, IEpochsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="EpochsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs">Cardano » Epochs</seealso> on docs.blockfrost.io
        /// </remarks>
        public EpochsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Latest epoch <c>/epochs/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest/get">/epochs/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest", "0.1.27")]
        public Task<Models.EpochContentResponse> GetLatestAsync()
        {
            return GetLatestAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Latest epoch <c>/epochs/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest/get">/epochs/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest", "0.1.27")]
        public async Task<Models.EpochContentResponse> GetLatestAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/latest");

            return await SendGetRequestAsync<Models.EpochContentResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Latest epoch protocol parameters <c>/epochs/latest/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest~1parameters/get">/epochs/latest/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest/parameters", "0.1.27")]
        public Task<Models.EpochParamContentResponse> GetLatestParametersAsync()
        {
            return GetLatestParametersAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Latest epoch protocol parameters <c>/epochs/latest/parameters</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Epochs/paths/~1epochs~1latest~1parameters/get">/epochs/latest/parameters</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/epochs/latest/parameters", "0.1.27")]
        public async Task<Models.EpochParamContentResponse> GetLatestParametersAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/latest/parameters");

            return await SendGetRequestAsync<Models.EpochParamContentResponse>(builder, cancellationToken);
        }
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
        public Task<Models.EpochContentResponse> GetEpochsAsync(int number)
        {
            return GetEpochsAsync(number, CancellationToken.None);
        }

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
        public async Task<Models.EpochContentResponse> GetEpochsAsync(int number, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/{number}");
            _ = builder.SetRouteParameter("{number}", number);

            return await SendGetRequestAsync<Models.EpochContentResponse>(builder, cancellationToken);
        }
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
        public Task<Models.EpochContentResponseCollection> GetNextAsync(int number, int? count, int? page)
        {
            return GetNextAsync(number, count, page, CancellationToken.None);
        }

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
        public async Task<Models.EpochContentResponseCollection> GetNextAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/{number}/next");
            _ = builder.SetRouteParameter("{number}", number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            builder.Length--;

            return await SendGetRequestAsync<Models.EpochContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.EpochContentResponseCollection> GetPreviousAsync(int number, int? count, int? page)
        {
            return GetPreviousAsync(number, count, page, CancellationToken.None);
        }

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
        public async Task<Models.EpochContentResponseCollection> GetPreviousAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/{number}/previous");
            _ = builder.SetRouteParameter("{number}", number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            builder.Length--;

            return await SendGetRequestAsync<Models.EpochContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.EpochStakeContentResponseCollection> GetStakesAsync(int number, int? count, int? page)
        {
            return GetStakesAsync(number, count, page, CancellationToken.None);
        }

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
        public async Task<Models.EpochStakeContentResponseCollection> GetStakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/{number}/stakes");
            _ = builder.SetRouteParameter("{number}", number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            builder.Length--;

            return await SendGetRequestAsync<Models.EpochStakeContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.EpochStakePoolContentResponseCollection> GetStakesAsync(int number, string pool_id, int? count, int? page)
        {
            return GetStakesAsync(number, pool_id, count, page, CancellationToken.None);
        }

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
        public async Task<Models.EpochStakePoolContentResponseCollection> GetStakesAsync(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/epochs/{number}/stakes/{pool_id}");
            _ = builder.SetRouteParameter("{number}", number);
            _ = builder.SetRouteParameter("{pool_id}", pool_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            builder.Length--;

            return await SendGetRequestAsync<Models.EpochStakePoolContentResponseCollection>(builder, cancellationToken);
        }
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
        public Task<Models.StringCollection> GetBlocksAsync(int number, int? count, int? page, ESortOrder? order)
        {
            return GetBlocksAsync(number, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.StringCollection> GetBlocksAsync(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/{number}/blocks");
            _ = builder.SetRouteParameter("{number}", number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
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
        public Task<Models.StringCollection> GetBlocksAsync(int number, string pool_id, int? count, int? page, ESortOrder? order)
        {
            return GetBlocksAsync(number, pool_id, count, page, order, CancellationToken.None);
        }

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
        public async Task<Models.StringCollection> GetBlocksAsync(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var builder = GetUrlBuilder("/epochs/{number}/blocks/{pool_id}");
            _ = builder.SetRouteParameter("{number}", number);
            _ = builder.SetRouteParameter("{pool_id}", pool_id);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
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
        public Task<Models.EpochParamContentResponse> GetParametersAsync(int number)
        {
            return GetParametersAsync(number, CancellationToken.None);
        }

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
        public async Task<Models.EpochParamContentResponse> GetParametersAsync(int number, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/epochs/{number}/parameters");
            _ = builder.SetRouteParameter("{number}", number);

            return await SendGetRequestAsync<Models.EpochParamContentResponse>(builder, cancellationToken);
        }
    }
}

