using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Tools.Console
{
    internal class AuthHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("project_id", Environment.GetEnvironmentVariable("BFCLI_API_KEY"));
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
