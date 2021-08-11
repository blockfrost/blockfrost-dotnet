using Blockfrost.Api.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class IpfsService : ABlockfrostService, IIpfsService
    {
        public IpfsService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order)
        {
            return ListAllAsync(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/list/?");
            if (count != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(count), count);
            }
            if (page != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(page), page);
            }
            if (order != null)
            {
                urlBuilder_.AppendQueryParameter(nameof(order), order);
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<Anonymous32>>(urlBuilder_, cancellationToken); //var disposeClient_ = false;
        }

        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsPinListResponse> ListAsync(string iPFS_path)
        {
            return ListAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsPinListResponse> ListAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
                throw new System.ArgumentNullException("iPFS_path");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/list/{IPFS_path}");
            urlBuilder_.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<IpfsPinListResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Pin an object</summary>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path)
        {
            return PostPinAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Pin an object</summary>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
                throw new System.ArgumentNullException("iPFS_path");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/add/{IPFS_path}");
            urlBuilder_.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));
            //POST

            return await SendPostRequestAsync<IpfsPinAddResponse>(urlBuilder_, cancellationToken);
        }

        /// <returns>Returns the pins removed</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path)
        {
            return RemoveAsync(iPFS_path, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the pins removed</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path, CancellationToken cancellationToken)
        {
            if (iPFS_path == null)
                throw new System.ArgumentNullException("iPFS_path");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/ipfs/pin/remove/{IPFS_path}");
            urlBuilder_.Replace("{IPFS_path}", System.Uri.EscapeDataString(ConvertToString(iPFS_path, System.Globalization.CultureInfo.InvariantCulture)));
            //POST

            return await SendPostRequestAsync<IpfsPinRemoveResponse>(urlBuilder_, cancellationToken);
        }
    }
}
