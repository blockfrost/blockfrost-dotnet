using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;

namespace Blockfrost.Api
{
    public partial class BlockService : ABlockfrostService, IBlockService
    {
        public BlockService(HttpClient httpClient) : base(httpClient)
        {
        }
        public BlockService(Services.IBlocksService blocksService, HttpClient httpClient) : base(httpClient)
        {
            V1 = blocksService;
        }

        public Services.IBlocksService V1 { get; set; }

        /// <summary>Specific block</summary>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<BlockContentResponse> GetBlocksAsync(string hash_or_number)
        {
            return GetBlocksAsync(hash_or_number, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific block</summary>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/{hash_or_number}");
            _ = urlBuilder_.Replace("{hash_or_number}", System.Uri.EscapeDataString(ConvertToString(hash_or_number, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<BlockContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Latest block</summary>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<BlockContentResponse> GetLatestBlockAsync()
        {
            return GetLatestBlockAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Latest block</summary>
        /// <returns>Return the contents of the latest block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<BlockContentResponse> GetLatestBlockAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/latest");

            return await SendGetRequestAsync<BlockContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Listing of next blocks</summary>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page)
        {
            return GetNextBlockAsync(hash_or_number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Listing of next blocks</summary>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/{hash_or_number}/next?");
            _ = urlBuilder_.Replace("{hash_or_number}", System.Uri.EscapeDataString(ConvertToString(hash_or_number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<BlockContentResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Specific block in a slot in an epoch</summary>
        /// <param name="epoch_number">Epoch for specific epoch slot.</param>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number)
        {
            return GetSlotAsync(epoch_number, slot_number, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific block in a slot in an epoch</summary>
        /// <param name="epoch_number">Epoch for specific epoch slot.</param>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken)
        {
            if (epoch_number < 0)
            {
                throw new System.ArgumentNullException(nameof(epoch_number));
            }

            if (slot_number < 0)
            {
                throw new System.ArgumentNullException(nameof(slot_number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/epoch/{epoch_number}/slot/{slot_number}");
            _ = urlBuilder_.Replace("{epoch_number}", System.Uri.EscapeDataString(ConvertToString(epoch_number, System.Globalization.CultureInfo.InvariantCulture)));
            _ = urlBuilder_.Replace("{slot_number}", System.Uri.EscapeDataString(ConvertToString(slot_number, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<BlockContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Specific block in a slot</summary>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<BlockContentResponse> GetSlotAsync(int slot_number)
        {
            return GetSlotAsync(slot_number, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific block in a slot</summary>
        /// <param name="slot_number">Slot position for requested block.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken)
        {
            if (slot_number < 0)
            {
                throw new System.ArgumentNullException(nameof(slot_number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/slot/{slot_number}");
            _ = urlBuilder_.Replace("{slot_number}", System.Uri.EscapeDataString(ConvertToString(slot_number, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<BlockContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Listing of previous blocks</summary>
        /// <param name="hash_or_number">Hash of the requested block</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page)
        {
            return PreviousAsync(hash_or_number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Listing of previous blocks</summary>
        /// <param name="hash_or_number">Hash of the requested block</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the contents of the block</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/{hash_or_number}/previous?");
            _ = urlBuilder_.Replace("{hash_or_number}", System.Uri.EscapeDataString(ConvertToString(hash_or_number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<BlockContentResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Block transactions</summary>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.
        /// <br/>The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order)
        {
            return TxsAll2Async(hash_or_number, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Block transactions</summary>
        /// <param name="hash_or_number">Hash of the requested block.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.
        /// <br/>The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (hash_or_number == null)
            {
                throw new System.ArgumentNullException(nameof(hash_or_number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/{hash_or_number}/txs?");
            _ = urlBuilder_.Replace("{hash_or_number}", System.Uri.EscapeDataString(ConvertToString(hash_or_number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Latest block transactions</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.
        /// <br/>The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order)
        {
            return TxsAllAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Latest block transactions</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">Ordered by tx index in the block.
        /// <br/>The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the transactions within the block.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/blocks/latest/txs?");
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
        }
    }
}
