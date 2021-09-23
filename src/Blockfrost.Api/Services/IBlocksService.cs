using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IBlocksService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Latest block <c>/blocks/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest/get">/blocks/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest", "0.1.27")]
        Task<Models.BlockContentResponse> GetLatestAsync();

        /// <summary>
        ///     Latest block <c>/blocks/latest</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Blocks/paths/~1blocks~1latest/get">/blocks/latest</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/blocks/latest", "0.1.27")]
        Task<Models.BlockContentResponse> GetLatestAsync(CancellationToken cancellationToken);
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
        Task<Models.StringCollection> GetLatestTxsAsync(int? count, int? page, ESortOrder? order);

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
        Task<Models.StringCollection> GetLatestTxsAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
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
        Task<Models.BlockContentResponse> GetBlocksAsync(string hash_or_number);

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
        Task<Models.BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken);
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
        Task<Models.BlockContentResponse> GetSlotAsync(int slot_number);

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
        Task<Models.BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken);
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
        Task<Models.BlockContentResponse> GetEpochSlotAsync(int epoch_number, int slot_number);

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
        Task<Models.BlockContentResponse> GetEpochSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken);
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
        Task<Models.BlockContentResponseCollection> GetNextAsync(string hash_or_number, int? count, int? page);

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
        Task<Models.BlockContentResponseCollection> GetNextAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken);
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
        Task<Models.BlockContentResponseCollection> GetPreviousAsync(string hash_or_number, int? count, int? page);

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
        Task<Models.BlockContentResponseCollection> GetPreviousAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken);
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
        Task<Models.StringCollection> GetTxsAsync(string hash_or_number, int? count, int? page, ESortOrder? order);

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
        Task<Models.StringCollection> GetTxsAsync(string hash_or_number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}

