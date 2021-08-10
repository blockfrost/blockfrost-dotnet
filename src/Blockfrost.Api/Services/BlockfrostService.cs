
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Blockfrost.Api
{
    public partial class BlockfrostService
    {
        private HttpClient _httpClient;
        private System.Lazy<System.Text.Json.JsonSerializerOptions> _options;
        

        public BlockfrostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerOptions);
            
        }

        private System.Text.Json.JsonSerializerOptions CreateSerializerOptions()
        {
            var options = new System.Text.Json.JsonSerializerOptions();
            UpdateJsonSerializerOptions(options);
            return options;
        }

        
        public string BaseUrl
        {
            get { return _httpClient.BaseAddress.AbsoluteUri; }
            set { _httpClient.BaseAddress = new Uri(value); }
        }

        private System.Text.Json.JsonSerializerOptions TextJsonSerializerSettings { get { return _options.Value; } }
       

        
        partial void UpdateJsonSerializerOptions(System.Text.Json.JsonSerializerOptions options);

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url);
        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(HttpClient client, HttpResponseMessage response);

        /// <summary>
        /// Sends the request using the configured httpClient
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="urlBuilder_"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<TResponse> SendGetRequestAsync<TResponse>(System.Text.StringBuilder urlBuilder_, CancellationToken cancellationToken)
        {
            using HttpRequestMessage request_ = new();

            request_.Method = new HttpMethod("GET");
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
        
        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, TextJsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception) 
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    var typedBody = await response.Content.ReadFromJsonAsync<T>(TextJsonSerializerSettings, cancellationToken);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        public bool GetHealth()
        {
            return true;
        }
    }
}
