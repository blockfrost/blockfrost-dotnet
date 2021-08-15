using Blockfrost.Api.Options;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Http
{
    public class BlockfrostAuthorizationHandler : DelegatingHandler
    {
        private readonly string _apiKey;

        public BlockfrostAuthorizationHandler(BlockfrostProject project) : this(project.ApiKey)
        {
        }

        public BlockfrostAuthorizationHandler(string apiKey)
        {
            _apiKey = apiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(!request.Headers.Contains("project_id")) request.Headers.Add("project_id", _apiKey);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
