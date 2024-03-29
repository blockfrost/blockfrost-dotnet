﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;

namespace Blockfrost.Api
{
    public partial class ABlockfrostService : IBlockfrostService
    {
        private readonly Lazy<JsonSerializerOptions> _options;

        private JsonSerializerOptions TextJsonSerializerSettings => _options.Value;

        protected HttpClient HttpClient { get; set; }

        public string Name { get; set; }

        public string Network { get; set; }

        public string BaseUrl
        {
            get => HttpClient.BaseAddress?.AbsoluteUri;
            set => HttpClient.BaseAddress = new Uri(value);
        }

        public bool ReadResponseAsString { get; set; }

        protected ABlockfrostService(HttpClient httpClient)
        {
            HttpClient = httpClient;
            _options = new Lazy<JsonSerializerOptions>(CreateSerializerOptions);
        }

        protected StringBuilder GetUrlBuilder(string template)
        {
            return new StringBuilder().SetRouteTemplate(BaseUrl, template);
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

        /// <summary>
        /// Sends the request using the configured httpClient
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="builder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<TResponse> SendGetRequestAsync<TResponse>(StringBuilder builder, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage();
            request.Method = new HttpMethod("GET");
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            return await SendRequestAsync<TResponse>(builder, request, cancellationToken).ConfigureAwait(false);
        }

        private async Task<TResponse> SendRequestAsync<TResponse>(StringBuilder builder, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string url = builder.ToString();
            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

            PrepareRequest(HttpClient, request, builder);

            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            bool disposeResponse = true;
            try
            {
                var headers = ProcessResponseHeaders(response);

                ProcessResponse(HttpClient, response);

                return await ReadResponseAsync<TResponse>(response, headers, cancellationToken);
            }
            finally
            {
                if (disposeResponse)
                {
                    response.Dispose();
                }
            }
        }

        protected async Task<TResponse> SendPostRequestAsync<TResponse>(string content, StringBuilder builder, CancellationToken cancellationToken)
        {
            return await SendPostRequestAsync<TResponse>(new StringContent(content, Encoding.UTF8, "application/cbor"), builder, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Prepares the HttpContent by loading the stream and setting application/cbor
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        protected virtual HttpContent PrepareHttpContent(Stream stream)
        {
            var content = new StreamContent(stream);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/cbor");
            return content;
        }

        protected async Task<TResponse> SendPostRequestAsync<TResponse>(Stream content, StringBuilder builder, CancellationToken cancellationToken)
        {
            var httpContent = PrepareHttpContent(content);
            return await SendPostRequestAsync<TResponse>(httpContent, builder, cancellationToken).ConfigureAwait(false);
        }

        protected async Task<TResponse> SendPostRequestAsync<TResponse>(HttpContent content, StringBuilder builder, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage();
            request.Content = content;
            request.Method = new HttpMethod("POST");
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            return await SendRequestAsync<TResponse>(builder, request, cancellationToken).ConfigureAwait(false);
        }

        private static Dictionary<string, IEnumerable<string>> ProcessResponseHeaders(HttpResponseMessage response)
        {
            var headers = System.Linq.Enumerable.ToDictionary(response.Headers, header => header.Key, header => header.Value);

            if (response.Content == null || response.Content.Headers == null)
            {
                return headers;
            }

            foreach (var item in response.Content.Headers)
            {
                headers[item.Key] = item.Value;
            }

            return headers;
        }

        private async Task<TResponse> ReadResponseAsync<TResponse>(HttpResponseMessage response, Dictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            int statusCode = (int)response.StatusCode;
            switch (statusCode) // ok
            {
                case 200:
                    {
                        var objectResponse = await ReadObjectResponseAsync<TResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        return objectResponse.Value == null
                            ? throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null)
                            : objectResponse.Value;
                    }

                case 202:
                    {
                        var objectResponse = await ReadObjectResponseAsync<TResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        return objectResponse.Value == null
                            ? throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null)
                            : objectResponse.Value;
                    }

                case 400:
                    {
                        var objectResponse = await ReadObjectResponseAsync<BadRequestResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        if (objectResponse.Value == null)
                        {
                            throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                        }

                        throw new ApiException<BadRequestResponse>("Bad request", statusCode, objectResponse.Text, headers, objectResponse.Value, null);
                    }

                case 403:
                    {
                        var objectResponse = await ReadObjectResponseAsync<ForbiddenResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        if (objectResponse.Value == null)
                        {
                            throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                        }

                        throw new ApiException<ForbiddenResponse>("Authentication secret is missing or invalid", statusCode, objectResponse.Text, headers, objectResponse.Value, null);
                    }

                case 404:
                    {
                        var objectResponse = await ReadObjectResponseAsync<NotFoundResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        if (objectResponse.Value == null)
                        {
                            throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                        }

                        throw new ApiException<NotFoundResponse>("Component not found", statusCode, objectResponse.Text, headers, objectResponse.Value, null);
                    }

                case 418:
                    {
                        var objectResponse = await ReadObjectResponseAsync<UnsupportedMediaTypeResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        if (objectResponse.Value == null)
                        {
                            throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                        }

                        throw new ApiException<UnsupportedMediaTypeResponse>("IP has been auto-banned for extensive sending of requests after usage limit has been reached", statusCode, objectResponse.Text, headers, objectResponse.Value, null);
                    }

                case 429:
                    {
                        var objectResponse = await ReadObjectResponseAsync<TooManyRequestsResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        if (objectResponse.Value == null)
                        {
                            throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                        }

                        throw new ApiException<TooManyRequestsResponse>("Usage limit reached", statusCode, objectResponse.Text, headers, objectResponse.Value, null);
                    }

                case 500:
                    {
                        var objectResponse = await ReadObjectResponseAsync<InternalServerErrorResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                        if (objectResponse.Value == null)
                        {
                            throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                        }

                        throw new ApiException<InternalServerErrorResponse>("Internal Server Error", statusCode, objectResponse.Text, headers, objectResponse.Value, null);
                    }

                default:
                    {
                        string responseData = response.Content == null ? null : await response.Content
#if NET5_0_OR_GREATER
                            .ReadAsStringAsync(cancellationToken)
#else
                            .ReadAsStringAsync()
#endif
                            .ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + statusCode + ").", statusCode, responseData, headers, null);
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

        private JsonSerializerOptions CreateSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            UpdateJsonSerializerOptions(options);
            return options;
        }
    }
}

