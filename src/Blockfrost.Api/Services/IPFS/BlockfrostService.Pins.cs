using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;using System.ComponentModel.DataAnnotations;using System.Text.Json.Serialization;
using Blockfrost.Api.Extensions;

namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService
    {

        /// <summary>Pin an object</summary>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path)
        {
            return PostPinAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Pin an object</summary>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
                throw new System.ArgumentNullException("iPFS_path");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/add/{IPFS_path}");
            urlBuilder_.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));
            //POST

            return await SendPostRequestAsync<IpfsPinAddResponse>(urlBuilder_, cancellationToken);
        }

        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order)
        {
            return ListAllAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/list/?");
            if (count != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(count), count);
            }
            if (page != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(page), page);
            }
            if (order != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(order), order);
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<Anonymous32>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
          
        }


        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsPinListResponse> ListAsync(string iPFS_path)
        {
            return ListAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsPinListResponse> ListAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
                throw new System.ArgumentNullException("iPFS_path");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/list/{IPFS_path}");
            urlBuilder_.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<IpfsPinListResponse>(urlBuilder_, cancellationToken);
            
        }

        /// <returns>Returns the pins removed</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path)
        {
            return RemoveAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the pins removed</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
                throw new System.ArgumentNullException("iPFS_path");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/remove/{IPFS_path}");
            urlBuilder_.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));
            //POST

            return await SendPostRequestAsync<IpfsPinRemoveResponse>(urlBuilder_, cancellationToken);
        }

        private async Task<TResponse> SendPostRequestAsync<TResponse>(System.Text.StringBuilder urlBuilder_, CancellationToken cancellationToken)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Content = new StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                request_.Method = new HttpMethod("POST");
                request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(_httpClient, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(_httpClient, request_, url_);

                var response_ = await _httpClient.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(_httpClient, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == 400)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<BadRequestResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<BadRequestResponse>("Bad request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 403)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ForbiddenResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 404)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<NotFoundResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<NotFoundResponse>("Component not found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 418)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 429)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TooManyRequestsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<TooManyRequestsResponse>("Usage limit reached", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == 500)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        throw new ApiException<InternalServerErrorResponse>("Internal Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
            
        }
    }
}
