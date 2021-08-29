using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class IpfsService : ABlockfrostService, IIpfsService
    {  /// <summary>Relay to an IPFS gateway</summary>
       /// <returns>Returns the object content</returns>
       /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task GatewayAsync(string iPFS_path)
        {
            return GatewayAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Relay to an IPFS gateway</summary>
        /// <returns>Returns the object content</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task GatewayAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
            {
                throw new System.ArgumentNullException(nameof(iPFS_path));
            }

            var urlBuilder = new System.Text.StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/gateway/{IPFS_path}");
            urlBuilder.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));

            using var request = new HttpRequestMessage();
            request.Method = new HttpMethod("GET");

            PrepareRequest(HttpClient, request, urlBuilder);

            string url = urlBuilder.ToString();
            request.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

            PrepareRequest(HttpClient, request, urlBuilder);

            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            try
            {
                var headers = System.Linq.Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                foreach (var item_ in response.Content.Headers)
                {
                    headers[item_.Key] = item_.Value;
                }

                ProcessResponse(HttpClient, response);

                int status = (int)response.StatusCode;
                switch (status)
                {
                    case 200:
                        return;

                    case 400:
                        {
                            var objectResponse = await ReadObjectResponseAsync<BadRequestResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Value == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }

                            throw new ApiException<BadRequestResponse>("Bad request", status, objectResponse.Text, headers, objectResponse.Value, null);
                        }
                    case 403:
                        {
                            var objectResponse = await ReadObjectResponseAsync<ForbiddenResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Value == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }

                            throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", status, objectResponse.Text, headers, objectResponse.Value, null);
                        }
                    case 404:
                        {
                            var objectResponse = await ReadObjectResponseAsync<NotFoundResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Value == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }

                            throw new ApiException<NotFoundResponse>("Component not found", status, objectResponse.Text, headers, objectResponse.Value, null);
                        }
                    case 418:
                        {
                            var objectResponse = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Value == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }

                            throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", status, objectResponse.Text, headers, objectResponse.Value, null);
                        }
                    case 429:
                        {
                            var objectResponse = await ReadObjectResponseAsync<TooManyRequestsResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Value == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }

                            throw new ApiException<TooManyRequestsResponse>("Usage limit reached", status, objectResponse.Text, headers, objectResponse.Value, null);
                        }
                    case 500:
                        {
                            var objectResponse = await ReadObjectResponseAsync<InternalServerErrorResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Value == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }

                            throw new ApiException<InternalServerErrorResponse>("Internal Server Error", status, objectResponse.Text, headers, objectResponse.Value, null);
                        }
                    default:
                        {
#if NET
                            string responseData = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
                            string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                            throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status, responseData, headers, null);
                        }
                }
            }
            finally
            {
                response.Dispose();
            }
        }
    }
}
