#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;using System.ComponentModel.DataAnnotations;using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService
    {
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
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/latest");

            return await SendGetRequestAsync<EpochContentResponse>(urlBuilder_, cancellationToken);
           
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
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/latest/parameters");

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
            if (number == null)
                throw new System.ArgumentNullException("number");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));

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
            return Next2Async(number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Listing of next epochs</summary>
        /// <param name="number">Number of the requested epoch.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/next?");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<EpochContentResponse>>(urlBuilder_, cancellationToken);
          
        }

        /// <summary>Listing of previous epochs</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page)
        {
            return Previous2Async(number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Listing of previous epochs</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results</param>
        /// <returns>Return the epoch data</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/previous?");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
            return StakesAsync(number, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake distribution</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/stakes?");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
        public Task<ICollection<Anonymous2>> Stakes2Async(int number, string pool_id, int? count, int? page)
        {
            return Stakes2Async(number, pool_id, count, page, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Stake distribution by pool</summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="pool_id">Stake pool ID to filter</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<Anonymous2>> Stakes2Async(int number, string pool_id, int? count, int? page, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            if (pool_id == null)
                throw new System.ArgumentNullException("pool_id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/stakes/{pool_id}?");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<Anonymous2>>(urlBuilder_, cancellationToken);
            
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
            return BlocksAllAsync(number, count, page, order, CancellationToken.None);
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
        public async Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/blocks?");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
          
        }

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
            return BlocksAll2Async(number, pool_id, count, page, order, CancellationToken.None);
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
        public async Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            if (pool_id == null)
                throw new System.ArgumentNullException("pool_id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/blocks/{pool_id}?");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{pool_id}", System.Uri.EscapeDataString(ConvertToString(pool_id, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
           
        }

        /// <summary>Protocol parameters</summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<EpochParamContent> Parameters2Async(int number)
        {
            return Parameters2Async(number, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Protocol parameters</summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Return the data about the epoch</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<EpochParamContent> Parameters2Async(int number, CancellationToken cancellationToken)
        {
            if (number == null)
                throw new System.ArgumentNullException("number");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/epochs/{number}/parameters");
            urlBuilder_.Replace("{number}", System.Uri.EscapeDataString(ConvertToString(number, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<EpochParamContent>(urlBuilder_, cancellationToken);
            
        }
    }
}


#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016