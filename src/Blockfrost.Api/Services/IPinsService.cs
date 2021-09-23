using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services
{
    public partial interface IPinsService : IBlockfrostService
    {
        IHealthService Health { get; set; }
        IMetricsService Metrics { get; set; }
        /// <summary>
        ///     Pin an object <c>/ipfs/pin/add/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1add~1{IPFS_path}/post">/ipfs/pin/add/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="content"></param>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/add/{IPFS_path}", "0.1.27")]
        Task<string> PostPinAddAsync(System.IO.Stream content);

        /// <summary>
        ///     Pin an object <c>/ipfs/pin/add/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1add~1{IPFS_path}/post">/ipfs/pin/add/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="content"></param>
        /// <returns>Returns pinned object</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/add/{IPFS_path}", "0.1.27")]
        Task<string> PostPinAddAsync(System.IO.Stream content, CancellationToken cancellationToken);
        /// <summary>
        ///     List pinned objects <c>/ipfs/pin/list/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1/get">/ipfs/pin/list/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/", "0.1.27")]
        Task<Models.IpfsPinListResponseCollection> GetPinListAsync(int? count, int? page, ESortOrder? order);

        /// <summary>
        ///     List pinned objects <c>/ipfs/pin/list/</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1/get">/ipfs/pin/list/</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Returns pinned objects</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/", "0.1.27")]
        Task<Models.IpfsPinListResponseCollection> GetPinListAsync(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);
        /// <summary>
        ///     Get details about pinned object <c>/ipfs/pin/list/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1{IPFS_path}/get">/ipfs/pin/list/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/{IPFS_path}", "0.1.27")]
        Task<Models.IpfsPinListIPFSPathResponse> GetPinListAsync(string IPFS_path);

        /// <summary>
        ///     Get details about pinned object <c>/ipfs/pin/list/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1{IPFS_path}/get">/ipfs/pin/list/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="IPFS_path"></param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/{IPFS_path}", "0.1.27")]
        Task<Models.IpfsPinListIPFSPathResponse> GetPinListAsync(string IPFS_path, CancellationToken cancellationToken);
        /// <summary>
        ///      <c>/ipfs/pin/remove/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1remove~1{IPFS_path}/post">/ipfs/pin/remove/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="content"></param>
        /// <returns>Returns the pins removed</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/remove/{IPFS_path}", "0.1.27")]
        Task<string> PostPinRemoveAsync(System.IO.Stream content);

        /// <summary>
        ///      <c>/ipfs/pin/remove/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1remove~1{IPFS_path}/post">/ipfs/pin/remove/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="content"></param>
        /// <returns>Returns the pins removed</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/pin/remove/{IPFS_path}", "0.1.27")]
        Task<string> PostPinRemoveAsync(System.IO.Stream content, CancellationToken cancellationToken);
    }
}

