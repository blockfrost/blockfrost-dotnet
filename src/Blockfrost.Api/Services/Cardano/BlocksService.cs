using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services
{
    public partial class BlocksService : ABlockfrostService, IBlocksService
    {
        /// <summary> 
        ///     Initializes a new <see cref="BlocksService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks">Cardano » Blocks</seealso> on docs.blockfrost.io
        /// </remarks>
        public BlocksService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Latest block <c>/blocks/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest/get">/blocks/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest", "0.1.27")]
        public Task<Models.BlockContentResponse> GetLatestAsync()
        {
            return GetLatestAsync(CancellationToken.None);
        }

        /// <summary>
        ///     Latest block <c>/blocks/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest/get">/blocks/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest", "0.1.27")]
        public async Task<Models.BlockContentResponse> GetLatestAsync(CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/blocks/latest");

            return await SendGetRequestAsync<Models.BlockContentResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Latest block transactions <c>/blocks/latest/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest~1txs/get">/blocks/latest/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest/txs", "0.1.27")]
        public Task<Models.StringCollection> GetLatestTxsAsync(int? count, int? page, ESortOrder? order)
        {
            return GetLatestTxsAsync(count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Latest block transactions <c>/blocks/latest/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest~1txs/get">/blocks/latest/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest/txs", "0.1.27")]
        public async Task<Models.StringCollection> GetLatestTxsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/blocks/latest/txs");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Specific block <c>/blocks/{hash_or_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}/get">/blocks/{hash_or_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash or number of the requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}", "0.1.27")]
        public Task<Models.BlockContentResponse> GetBlocksAsync(string hash_or_number)
        {
            return GetBlocksAsync(hash_or_number, CancellationToken.None);
        }

        /// <summary>
        ///     Specific block <c>/blocks/{hash_or_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}/get">/blocks/{hash_or_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash or number of the requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}", "0.1.27")]
        public async Task<Models.BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var builder = GetUrlBuilder("/blocks/{hash_or_number}");
            _ = builder.SetRouteParameter("{hash_or_number}", hash_or_number);

            return await SendGetRequestAsync<Models.BlockContentResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Specific block in a slot <c>/blocks/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1slot~1{slot_number}/get">/blocks/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/slot/{slot_number}", "0.1.27")]
        public Task<Models.BlockContentResponse> GetSlotAsync(int slot_number)
        {
            return GetSlotAsync(slot_number, CancellationToken.None);
        }

        /// <summary>
        ///     Specific block in a slot <c>/blocks/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1slot~1{slot_number}/get">/blocks/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/slot/{slot_number}", "0.1.27")]
        public async Task<Models.BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/blocks/slot/{slot_number}");
            _ = builder.SetRouteParameter("{slot_number}", slot_number);

            return await SendGetRequestAsync<Models.BlockContentResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Specific block in a slot in an epoch <c>/blocks/epoch/{epoch_number}/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1epoch~1{epoch_number}~1slot~1{slot_number}/get">/blocks/epoch/{epoch_number}/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="epoch_number">Epoch for specific epoch slot.</param>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}", "0.1.27")]
        public Task<Models.BlockContentResponse> GetEpochSlotAsync(int epoch_number, int slot_number)
        {
            return GetEpochSlotAsync(epoch_number, slot_number, CancellationToken.None);
        }

        /// <summary>
        ///     Specific block in a slot in an epoch <c>/blocks/epoch/{epoch_number}/slot/{slot_number}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1epoch~1{epoch_number}~1slot~1{slot_number}/get">/blocks/epoch/{epoch_number}/slot/{slot_number}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="epoch_number">Epoch for specific epoch slot.</param>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/epoch/{epoch_number}/slot/{slot_number}", "0.1.27")]
        public async Task<Models.BlockContentResponse> GetEpochSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/blocks/epoch/{epoch_number}/slot/{slot_number}");
            _ = builder.SetRouteParameter("{epoch_number}", epoch_number);
            _ = builder.SetRouteParameter("{slot_number}", slot_number);

            return await SendGetRequestAsync<Models.BlockContentResponse>(builder, cancellationToken);
        }
        /// <summary>
        ///     Listing of next blocks <c>/blocks/{hash_or_number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1next/get">/blocks/{hash_or_number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/next", "0.1.27")]
        public Task<Models.BlockContentResponseCollection> GetNextAsync(string hash_or_number, int? count, int? page)
        {
            return GetNextAsync(hash_or_number, count, page, CancellationToken.None);
        }

        /// <summary>
        ///     Listing of next blocks <c>/blocks/{hash_or_number}/next</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1next/get">/blocks/{hash_or_number}/next</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/next", "0.1.27")]
        public async Task<Models.BlockContentResponseCollection> GetNextAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var builder = GetUrlBuilder("/blocks/{hash_or_number}/next");
            _ = builder.SetRouteParameter("{hash_or_number}", hash_or_number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            builder.Length--;

            return await SendGetRequestAsync<Models.BlockContentResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Listing of previous blocks <c>/blocks/{hash_or_number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1previous/get">/blocks/{hash_or_number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/previous", "0.1.27")]
        public Task<Models.BlockContentResponseCollection> GetPreviousAsync(string hash_or_number, int? count, int? page)
        {
            return GetPreviousAsync(hash_or_number, count, page, CancellationToken.None);
        }

        /// <summary>
        ///     Listing of previous blocks <c>/blocks/{hash_or_number}/previous</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1previous/get">/blocks/{hash_or_number}/previous</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/previous", "0.1.27")]
        public async Task<Models.BlockContentResponseCollection> GetPreviousAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var builder = GetUrlBuilder("/blocks/{hash_or_number}/previous");
            _ = builder.SetRouteParameter("{hash_or_number}", hash_or_number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            builder.Length--;

            return await SendGetRequestAsync<Models.BlockContentResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Block transactions <c>/blocks/{hash_or_number}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1txs/get">/blocks/{hash_or_number}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/txs", "0.1.27")]
        public Task<Models.StringCollection> GetTxsAsync(string hash_or_number, int? count, int? page, ESortOrder? order)
        {
            return GetTxsAsync(hash_or_number, count, page, order, CancellationToken.None);
        }

        /// <summary>
        ///     Block transactions <c>/blocks/{hash_or_number}/txs</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1{hash_or_number}~1txs/get">/blocks/{hash_or_number}/txs</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/{hash_or_number}/txs", "0.1.27")]
        public async Task<Models.StringCollection> GetTxsAsync(string hash_or_number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var builder = GetUrlBuilder("/blocks/{hash_or_number}/txs");
            _ = builder.SetRouteParameter("{hash_or_number}", hash_or_number);
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<Models.StringCollection>(builder, cancellationToken);
        }
    }
}

