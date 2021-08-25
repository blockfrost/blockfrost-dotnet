using System.Text.Json.Serialization;

namespace Blockfrost.Api.Utils
{
    public class ProtocolVersion
    {
        [JsonPropertyName("minor")]
        public int Minor { get; set; }
        [JsonPropertyName("major")]
        public int Major { get; set; }
    }
}