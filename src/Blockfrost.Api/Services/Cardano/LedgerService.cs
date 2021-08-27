// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class LedgerService : ABlockfrostService, ILedgerService
    {
        public LedgerService(HttpClient httpClient) : base(httpClient)
        {
        }

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
