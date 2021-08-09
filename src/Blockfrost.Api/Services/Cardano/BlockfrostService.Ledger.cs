using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;using System.ComponentModel.DataAnnotations;using System.Text.Json.Serialization;
namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService
    {

        /// <summary>Blockchain genesis</summary>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<GenesisContentResponse> GenesisAsync()
        {
            return GenesisAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockchain genesis</summary>
        /// <returns>Return the genesis parameters.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/genesis");

            return await SendGetRequestAsync<GenesisContentResponse>(urlBuilder_, cancellationToken);
           
        }
    }
}
