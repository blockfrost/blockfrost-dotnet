﻿using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services.IPFS
{
    public partial class PinsService : ABlockfrostService, IPinsService
    {
        /// <summary> 
        ///     Initializes a new <see cref="PinsService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins">IPFS » Pins</seealso> on docs.blockfrost.io
        /// </remarks>
        public PinsService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

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
        [Post("/ipfs/pin/add/{IPFS_path}", "0.1.28")]
        public async Task<PinStateContentResponse> PostPinAddAsync(string ipfsPath, CancellationToken cancellationToken)
        {
            var builder = GetUrlBuilder("/ipfs/pin/add/{IPFS_path}");
            _ = builder.SetRouteParameter("{IPFS_path}", ipfsPath);

            return await SendPostRequestAsync<PinStateContentResponse>(ipfsPath, builder, cancellationToken);
        }
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
        [Get("/ipfs/pin/list/", "0.1.28")]
        public async Task<IpfsPinListResponseCollection> GetPinListAsync(int? count = 100, int? page = 1, ESortOrder? order = ESortOrder.Asc, CancellationToken cancellationToken = default)
        {
            var builder = GetUrlBuilder("/ipfs/pin/list/");
            _ = builder.AppendQueryParameter(nameof(count), count);
            _ = builder.AppendQueryParameter(nameof(page), page);
            _ = builder.AppendQueryParameter(nameof(order), order);
            builder.Length--;

            return await SendGetRequestAsync<IpfsPinListResponseCollection>(builder, cancellationToken);
        }
        /// <summary>
        ///     Get details about pinned object <c>/ipfs/pin/list/{IPFS_path}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Pins/paths/~1ipfs~1pin~1list~1{IPFS_path}/get">/ipfs/pin/list/{IPFS_path}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="ipfsPath"></param>
        /// <returns>Returns the pins pinned</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/ipfs/pin/list/{IPFS_path}", "0.1.28")]
        public async Task<IpfsPinListIPFSPathResponse> GetPinListAsync(string ipfsPath, CancellationToken cancellationToken = default)
        {
            if (ipfsPath == null)
            {
                throw new System.ArgumentNullException(nameof(ipfsPath));
            }

            var builder = GetUrlBuilder("/ipfs/pin/list/{IPFS_path}");
            _ = builder.SetRouteParameter("{IPFS_path}", ipfsPath);

            return await SendGetRequestAsync<IpfsPinListIPFSPathResponse>(builder, cancellationToken);
        }

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
        [Post("/ipfs/pin/remove/{IPFS_path}", "0.1.28")]
        public async Task<PinStateContentResponse> PostPinRemoveAsync(string ipfsPath, CancellationToken cancellationToken = default)
        {
            var builder = GetUrlBuilder("/ipfs/pin/remove/{IPFS_path}");
            _ = builder.SetRouteParameter("{IPFS_path}", ipfsPath);

            return await SendPostRequestAsync<PinStateContentResponse>(ipfsPath, builder, cancellationToken);
        }

        protected override HttpContent PrepareHttpContent(Stream stream)
        {
            return null;
        }

        protected override void PrepareRequest(HttpClient httpClient, HttpRequestMessage request, System.Text.StringBuilder urlBuilder)
        {
            request.Content = null;
        }
    }
}

