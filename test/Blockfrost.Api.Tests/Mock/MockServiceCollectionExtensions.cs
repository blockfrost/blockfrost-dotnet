// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blockfrost.Api.Tests.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Blockfrost.Api.Tests.Mock
{
    internal static class MockServiceCollectionExtensions
    {
        /// <summary>
        /// Returns a <see cref="HttpResponseMessage"/> wrapping <paramref name="content"/> as <see cref="StringContent"/>
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="content"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static IServiceCollection MockHttpClient<TContent>(this IServiceCollection serviceCollection, TContent content, System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK)
        {
            return serviceCollection.MockHttpClient((HttpContent)JsonContent.Create(content, MediaTypeHeaderValue.Parse("application/json")), statusCode);
        }

        /// <summary>
        /// Returns a <see cref="HttpResponseMessage"/> wrapping <paramref name="content"/> as <see cref="JsonContent"/>
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="content"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static IServiceCollection MockHttpClient(this IServiceCollection serviceCollection, string content, System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK)
        {
            return serviceCollection.MockHttpClient<string>(content, statusCode);
        }

        public static IServiceCollection MockHttpClient(this IServiceCollection serviceCollection, HttpContent stringContent, System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK)
        {
            return serviceCollection.MockHttpClient(new HttpResponseMessage(statusCode) { Content = stringContent, });
        }

        /// <summary>
        /// Mocks every HttpClient in the <paramref name="serviceCollection"/> to return the <paramref name="response"/>
        /// </summary>
        /// <param name="serviceCollection">The serviceCollection</param>
        /// <param name="response">The response</param>
        /// <returns></returns>
        public static IServiceCollection MockHttpClient(this IServiceCollection serviceCollection, HttpResponseMessage response)
        {
            var mFactory = new Mock<IHttpClientFactory>();
            mFactory
                .Setup(_ => _.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(new HttpMessageHandlerStub((_, _) => Task.FromResult(response))));

            serviceCollection.Remove(serviceCollection.First(s => s.ServiceType == typeof(IHttpClientFactory)));
            return serviceCollection.AddSingleton(mFactory.Object);
        }
    }
}
