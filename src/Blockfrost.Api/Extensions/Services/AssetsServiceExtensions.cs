using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Models;

namespace Blockfrost.Api.Services.Extensions
{
    public static class AssetsServiceExtensions
    {
        public static async Task<AssetResponse<TOnchainMetadata>> GetAssetsAsync<TOnchainMetadata>(this IAssetsService service, string asset, CancellationToken cancellationToken = default)
        {
            var response = await service.GetAssetsAsync(asset, cancellationToken);
            string json = JsonSerializer.Serialize(response);
            return JsonSerializer.Deserialize<AssetResponse<TOnchainMetadata>>(json);
        }
    }
}
