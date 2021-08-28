using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class IpfsService : ABlockfrostService, IIpfsService
    {
        /// <summary>Add a file or directory to IPFS</summary>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsAddResponse> AddIpfsAsync(string file_or_directory)
        {
            return AddIpfsAsync(file_or_directory, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Add a file or directory to IPFS</summary>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsAddResponse> AddIpfsAsync(string file_or_directory, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/add");

            throw new NotImplementedException();
            //return await SendPostRequestAsync<IpfsAddResponse>(urlBuilder_, cancellationToken);
        }
    }
}
