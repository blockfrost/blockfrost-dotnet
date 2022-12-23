using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Services.IPFS
{
    public partial class AddService : ABlockfrostService, IAddService
    {
        /// <summary> 
        ///     Initializes a new <see cref="AddService"></see> with the specified <see cref="HttpClient"></see> 
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add">IPFS » Add</seealso> on docs.blockfrost.io
        /// </remarks>
        public AddService(IHealthService health, IMetricsService metrics, HttpClient httpClient) : base(httpClient)
        {
            Health = health;
            Metrics = metrics;
        }

        public IHealthService Health { get; set; }

        public IMetricsService Metrics { get; set; }

        /// <summary>
        ///     Add a file to IPFS <c>/ipfs/add</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/IPFS-Add/paths/~1ipfs~1add/post">/ipfs/add</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <returns>Returns information about added IPFS object</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Post("/ipfs/add", "0.1.28")]
        public async Task<Models.AddContentResponse> PostAddAsync(FileStream stream, CancellationToken cancellationToken = default)
        {
            var builder = GetUrlBuilder("/ipfs/add");
            var httpContent = PrepareHttpContent(stream);
            return await SendPostRequestAsync<Models.AddContentResponse>(httpContent, builder, cancellationToken);
        }

        protected override HttpContent PrepareHttpContent(Stream stream)
        {
            if (stream is FileStream fs)
            {
                var info = new FileInfo(fs.Name);
                string boundary = new HttpRequestIdentifier().TraceIdentifier.PadLeft(42, '-');
                var content = new StreamContent(stream);

                string mimeType = MimeTypeMap.GetMimeType(info.Name);
                content.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);

                var multipartContent = new MultipartFormDataContent(boundary)
                {
                    { content, "file", info.Name }
                };
                return multipartContent;
            }
            else
            {
                throw new InvalidOperationException(stream.GetType() + " is not supported");
            }
        }
    }
}

