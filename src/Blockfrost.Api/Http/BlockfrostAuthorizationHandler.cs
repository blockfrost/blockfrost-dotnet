using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Options;
using Microsoft.Extensions.Options;

namespace Blockfrost.Api.Http
{
    public class BlockfrostAuthorizationHandler : DelegatingHandler
    {
        private readonly string _apiKey;
        private static readonly int s_count;

        static BlockfrostAuthorizationHandler()
        {
            s_count++;
        }

        public BlockfrostAuthorizationHandler(BlockfrostProject project) : this(project.ApiKey)
        {
        }

        public BlockfrostAuthorizationHandler(HttpMessageHandler innerHandler, BlockfrostProject project) : this(innerHandler, project.ApiKey)
        {
        }

        public BlockfrostAuthorizationHandler(string apiKey) : this(new HttpClientHandler(), apiKey)
        {
        }

        public BlockfrostAuthorizationHandler(HttpMessageHandler innerHandler, string apiKey) : base(innerHandler)
        {
            if (s_count > 1)
                throw new InvalidOperationException("Reuse of {nameof(BlockfrostAuthorizationHandler)} is not permitted by the SDK.");
            _apiKey = apiKey;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("project_id"))
                request.Headers.Add("project_id", _apiKey);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
