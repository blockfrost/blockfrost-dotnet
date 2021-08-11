using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class IpfsService : ABlockfrostService, IIpfsService
    {
        /// <summary>Add a file or directory to IPFS</summary>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsAddResponse> AddIpfsAsync()
        {
            return AddIpfsAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Add a file or directory to IPFS</summary>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsAddResponse> AddIpfsAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/add");

            return await SendPostRequestAsync<IpfsAddResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<string> SubmitAsync(EContentType content_Type)
        {
            return SubmitAsync(content_Type, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<string> SubmitAsync(EContentType content_Type, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/tx/submit");

            return await SendPostRequestAsync<string>(urlBuilder_, cancellationToken);
        }
    }
}
