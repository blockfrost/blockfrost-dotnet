using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Http
{
    public class BlockfrostAuthorizationHandler : DelegatingHandler
    {
        private string _apiKey;

        public BlockfrostAuthorizationHandler()
        {
        }

        public BlockfrostAuthorizationHandler(string apiKey) : base()
        {
            _apiKey = apiKey;
        }

        public string ApiKey { get => _apiKey; set => _apiKey = value; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(!request.Headers.Contains("project_id")) request.Headers.Add("project_id", _apiKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
