using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial class EpochService : ABlockfrostService, IEpochService
    {
        public EpochService(HttpClient httpClient) : base(httpClient)
        {
        }

        public EpochService(IEpochsService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }
        public IEpochsService V1 { get; set; }

        /// <summary>Block distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order)
        {
            return EpochBlocksByPool(number, pool_id, count, page, order, CancellationToken.None);
        }

        /// <summary>Block distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order)
        {
            return EpochBlocks(number, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Block distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<string>> EpochBlocks(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/blocks?");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (order != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(order), order);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Block distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<string>> EpochBlocksByPool(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/blocks/{pool_id}?");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
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

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Protocol parameters</summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<EpochParamContent> EpochParameters(int number, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/parameters");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<EpochParamContent>(urlBuilder_, cancellationToken);
        }

        /// <summary>Specific epoch</summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the epoch data.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<EpochContentResponse> EpochsAsync(int number)
        {
            return EpochsAsync(number, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific epoch</summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the epoch data.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<EpochContentResponse> EpochsAsync(int number, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<EpochContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<EpochStakesResponse>> EpochStakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/stakes?");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<EpochStakesResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Stake distribution by pool</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page)
        {
            return EpochStakesByPool(number, pool_id, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake distribution by pool</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            if (pool_id == null)
            {
                throw new System.ArgumentNullException(nameof(pool_id));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/stakes/{pool_id}?");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            _ = urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<Anonymous2>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Latest epoch</summary>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<EpochContentResponse> Latest2Async()
        {
            return Latest2Async(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Latest epoch</summary>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<EpochContentResponse> Latest2Async(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/latest");

            return await SendGetRequestAsync<EpochContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Listing of next epochs</summary>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page)
        {
            return NextEpochAsync(number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Listing of next epochs</summary>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<EpochContentResponse>> NextEpochAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/next?");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<EpochContentResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Protocol parameters</summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<EpochParamContent> Parameters2Async(int number)
        {
            return EpochParameters(number, CancellationToken.None);
        }

        /// <summary>Latest epoch protocol parameters</summary>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<EpochParamContent> ParametersAsync()
        {
            return ParametersAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Latest epoch protocol parameters</summary>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<EpochParamContent> ParametersAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/latest/parameters");

            return await SendGetRequestAsync<EpochParamContent>(urlBuilder_, cancellationToken);
        }

        /// <summary>Listing of previous epochs</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page)
        {
            return PreviousEpochAsync(number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Listing of previous epochs</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<EpochContentResponse>> PreviousEpochAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number < 0)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/previous?");
            _ = urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(count), count);
            }

            if (page != null)
            {
                _ = urlBuilder_.AppendQueryParameter(nameof(page), page);
            }

            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<EpochContentResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Stake distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page)
        {
            return EpochStakesAsync(number, count, page, CancellationToken.None);
        }
    }
}
