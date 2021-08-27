using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests.Http
{
    /// <summary>
    /// Configurable HttpHandler
    /// </summary>
    public class HttpMessageHandlerStub : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handler;

        /// <summary>
        /// Configures the <see cref="HttpMessageHandlerStub"/> to return an empty <see cref="HttpResponseMessage"/> with the given <paramref name="statusCode"/>
        /// </summary>
        /// <param name="statusCode"></param>
        public HttpMessageHandlerStub(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _handler = (_, cancellationToken) => Task.FromResult(new HttpResponseMessage(statusCode));
        }

        /// <summary>
        /// Configures the <see cref="HttpMessageHandler"/> using the <paramref name="handler"/>
        /// </summary>
        /// <param name="handler">Returns the <see cref="HttpResponseMessage"/></param>
        public HttpMessageHandlerStub(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Invokes the configured <see cref="_handler"/>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handler(request, cancellationToken);
        }
    }
}
