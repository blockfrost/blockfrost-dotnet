using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class NetworkService : ABlockfrostService, INetworkService
    {
        public NetworkService(HttpClient httpClient) : base(httpClient)
        {
        }

        public NetworkService(Services.INetworkService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }

        public Services.INetworkService V1 { get; set; }

        /// <summary>Network information</summary>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<NetworkResponse> NetworkAsync()
        {
            return NetworkAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Network information</summary>
        /// <returns>Return detailed network information.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<NetworkResponse> NetworkAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/network");

            return await SendGetRequestAsync<NetworkResponse>(urlBuilder_, cancellationToken);
        }
    }
}
