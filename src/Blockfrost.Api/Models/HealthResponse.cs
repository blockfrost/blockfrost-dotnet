using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class HealthResponse
    {
        [JsonPropertyName("is_healthy")]
        public bool IsHealthy { get; set; }
    }
}
