using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Api.Tests.Services
{
    public partial class AssetsServiceTest
    {
        /// <summary>
        ///     Testing Specific asset <c>/assets/{asset}</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Assets/paths/~1assets~1{asset}/get">/assets/{asset}</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/assets/{asset}", "0.1.28")]
        public static async Task<Api.Models.AssetResponse> GetAssetsAsync_With_Generic_Metadata(string asset, CancellationToken cancellationToken)
        {
            var sut = Provider.GetRequiredService<Api.Services.IAssetsService>();
            sut.ReadResponseAsString = true;

            // asset  has null check
            return await sut.GetAssetsAsync(asset, cancellationToken);
        }
    }
}
