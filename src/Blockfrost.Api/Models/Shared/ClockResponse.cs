using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class ClockResponse
    {
        [JsonPropertyName("server_time")]
        public long ServerTime { get; set; }
    }
}
