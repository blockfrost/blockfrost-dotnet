using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Extensions
{
    public class BlockfrostAuthorizationHandler : DelegatingHandler
    {
        private readonly string _apiKey;

        public BlockfrostAuthorizationHandler(string apiKey) : base()
        {
            _apiKey   = apiKey;
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("project_id", _apiKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}