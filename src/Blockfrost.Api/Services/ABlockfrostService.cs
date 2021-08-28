// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public abstract class ABlockfrostService : IBlockfrostService
    {
        public string Network { get; set; }

        public string BaseUrl
        {
            get => HttpClient.BaseAddress?.AbsoluteUri;
            set => HttpClient.BaseAddress = new Uri(value);
        }

        public bool ReadResponseAsString { get; set; }

        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<MetricsEndpointResponse>> EndpointsAsync()
        {
            return EndpointsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost endpoint usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metrics/endpoints");

            return await SendGetRequestAsync<ICollection<MetricsEndpointResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ClockResponse> GetClockAsync()
        {
            return GetClockAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Current backend time</summary>
        /// <returns>Return the current UNIX time in milliseconds.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/health/clock");

            return await SendGetRequestAsync<ClockResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<HealthResponse> GetHealthAsync()
        {
            return GetHealthAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Backend health status</summary>
        /// <returns>Return the boolean indicating the health of the backend.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/health");

            return await SendGetRequestAsync<HealthResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<InfoResponse> GetInfoAsync()
        {
            return GetInfoAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Root endpoint</summary>
        /// <returns>Information pointing to the documentation.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append('/');

            return await SendGetRequestAsync<InfoResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<MetricResponse>> GetMetricsAsync()
        {
            return GetMetricsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/metrics/");

            return await SendGetRequestAsync<ICollection<MetricResponse>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }

        protected ABlockfrostService(HttpClient httpClient)
        {
            HttpClient = httpClient;
            _options = new Lazy<JsonSerializerOptions>(CreateSerializerOptions);
        }

        protected string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is Enum)
            {
                string name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        if (System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) is System.Runtime.Serialization.EnumMemberAttribute attribute)
                        {
                            return attribute.Value ?? name;
                        }
                    }

                    string converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo), cultureInfo);
                    return converted ?? string.Empty;
                }
            }
            else if (value is bool boolean)
            {
                return Convert.ToString(boolean, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[] bytes)
            {
                return Convert.ToBase64String(bytes);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            string result = Convert.ToString(value, cultureInfo);
            return result ?? "";
        }

        protected virtual void PrepareRequest(HttpClient httpClient, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        protected virtual void ProcessResponse(HttpClient httpClient, HttpResponseMessage response)
        {
        }

        protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default, string.Empty);
            }

            if (ReadResponseAsString)
            {
#if NET
                string responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
                string responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                try
                {
                    var typedBody = JsonSerializer.Deserialize<T>(responseText, TextJsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception)
                {
                    string message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
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
                    string message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        //partial void UpdateJsonSerializerOptions(System.Text.Json.JsonSerializerOptions options);
        //partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url);
        //partial void PrepareRequest(HttpClient client, HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        //partial void ProcessResponse(HttpClient client, HttpResponseMessage response);
        /// <summary>
        /// Sends the request using the configured httpClient
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="urlBuilder_"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<TResponse> SendGetRequestAsync<TResponse>(StringBuilder urlBuilder_, CancellationToken cancellationToken)
        {
            using var request_ = new HttpRequestMessage();
            request_.Method = new HttpMethod("GET");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            PrepareRequest(HttpClient, request_, urlBuilder_);

            string url_ = urlBuilder_.ToString();
            request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

            PrepareRequest(HttpClient, request_, urlBuilder_);

            var response_ = await HttpClient.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            bool disposeResponse_ = true;
            try
            {
                var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                if (response_.Content != null && response_.Content.Headers != null)
                {
                    foreach (var item_ in response_.Content.Headers)
                    {
                        headers_[item_.Key] = item_.Value;
                    }
                }

                ProcessResponse(HttpClient, response_);

                int status_ = (int)response_.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    return objectResponse_.Value == null
                        ? throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null)
                        : objectResponse_.Value;
                }
                else
                if (status_ == 400)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<BadRequestResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<BadRequestResponse>("Bad request", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 403)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<ForbiddenResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 418)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 429)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TooManyRequestsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<TooManyRequestsResponse>("Usage limit reached", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 500)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<InternalServerErrorResponse>("Internal Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                {
                    string responseData_ = response_.Content == null ? null : await response_.Content
#if NET5_0_OR_GREATER
                            .ReadAsStringAsync(cancellationToken)
#else
                            .ReadAsStringAsync()
#endif
                            .ConfigureAwait(false);
                    throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                }
            }
            finally
            {
                if (disposeResponse_)
                {
                    response_.Dispose();
                }
            }
        }

        protected async Task<TResponse> SendPostRequestAsync<TResponse>(string content, StringBuilder urlBuilder_, CancellationToken cancellationToken)
        {
            using var request_ = new HttpRequestMessage();
            request_.Content = new StringContent(content, Encoding.UTF8, "application/cbor");
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            PrepareRequest(HttpClient, request_, urlBuilder_);

            string url_ = urlBuilder_.ToString();
            request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

            PrepareRequest(HttpClient, request_, urlBuilder_);

            var response_ = await HttpClient.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            bool disposeResponse_ = true;
            try
            {
                var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                if (response_.Content != null && response_.Content.Headers != null)
                {
                    foreach (var item_ in response_.Content.Headers)
                    {
                        headers_[item_.Key] = item_.Value;
                    }
                }

                ProcessResponse(HttpClient, response_);

                int status_ = (int)response_.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    return objectResponse_.Value == null
                        ? throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null)
                        : objectResponse_.Value;
                }
                else
                if (status_ == 400)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<BadRequestResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<BadRequestResponse>("Bad request", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 403)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<ForbiddenResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 404)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<NotFoundResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<NotFoundResponse>("Component not found", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 418)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 429)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TooManyRequestsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<TooManyRequestsResponse>("Usage limit reached", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 500)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<InternalServerErrorResponse>("Internal Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                {
                    string responseData_ = response_.Content == null ? null : await response_.Content
#if NET5_0_OR_GREATER
                            .ReadAsStringAsync(cancellationToken)
#else
                            .ReadAsStringAsync()
#endif
                            .ConfigureAwait(false);
                    throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                }
            }
            finally
            {
                if (disposeResponse_)
                {
                    response_.Dispose();
                }
            }
        }

        protected async Task<TResponse> SendPostRequestAsync<TResponse>(Stream content, StringBuilder urlBuilder_, CancellationToken cancellationToken)
        {
            using var request_ = new HttpRequestMessage();
            request_.Content = new StreamContent(content);
            request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/cbor");
            request_.Method = new HttpMethod("POST");
            request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            PrepareRequest(HttpClient, request_, urlBuilder_);

            string url_ = urlBuilder_.ToString();
            request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

            PrepareRequest(HttpClient, request_, urlBuilder_);

            var response_ = await HttpClient.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            bool disposeResponse_ = true;
            try
            {
                var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                if (response_.Content != null && response_.Content.Headers != null)
                {
                    foreach (var item_ in response_.Content.Headers)
                    {
                        headers_[item_.Key] = item_.Value;
                    }
                }

                ProcessResponse(HttpClient, response_);

                int status_ = (int)response_.StatusCode;
                if (status_ == 200) // ok
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    return objectResponse_.Value == null
                        ? throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null)
                        : objectResponse_.Value;
                }
                else
                if (status_ == 202) // accepted
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    return objectResponse_.Value == null
                        ? throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null)
                        : objectResponse_.Value;
                }
                else
                if (status_ == 400) // bad request
                {
                    var objectResponse_ = await ReadObjectResponseAsync<BadRequestResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<BadRequestResponse>("Bad request", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 403) // forbidden
                {
                    var objectResponse_ = await ReadObjectResponseAsync<ForbiddenResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 404) // unauthorized
                {
                    var objectResponse_ = await ReadObjectResponseAsync<NotFoundResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<NotFoundResponse>("Component not found", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 418) // i am a teapot
                {
                    var objectResponse_ = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 429) // enhance your calm (twitter rate limiting)
                {
                    var objectResponse_ = await ReadObjectResponseAsync<TooManyRequestsResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<TooManyRequestsResponse>("Usage limit reached", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                if (status_ == 500) // internal server error
                {
                    var objectResponse_ = await ReadObjectResponseAsync<InternalServerErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse_.Value == null)
                    {
                        throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                    }

                    throw new ApiException<InternalServerErrorResponse>("Internal Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Value, null);
                }
                else
                {
                    string responseData_ = response_.Content == null ? null : await response_.Content
#if NET5_0_OR_GREATER
                            .ReadAsStringAsync(cancellationToken)
#else
                            .ReadAsStringAsync()
#endif
                            .ConfigureAwait(false);
                    throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                }
            }
            finally
            {
                if (disposeResponse_)
                {
                    response_.Dispose();
                }
            }
        }

        protected virtual void UpdateJsonSerializerOptions(JsonSerializerOptions options)
        {
        }

        protected readonly struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                Value = responseObject;
                Text = responseText;
            }

            public T Value { get; }

            public string Text { get; }
        }

        private readonly Lazy<JsonSerializerOptions> _options;

        private JsonSerializerOptions TextJsonSerializerSettings => _options.Value;

        protected HttpClient HttpClient { get; set; }

        private JsonSerializerOptions CreateSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            UpdateJsonSerializerOptions(options);
            return options;
        }
    }
}
