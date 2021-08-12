using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Extensions
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
            request.Headers.Add("project_id", _apiKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
