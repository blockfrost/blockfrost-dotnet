using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class MetricResponse
    {
        /// <summary>Sum of all calls for a particular day</summary>
        [JsonPropertyName("calls")]
        public int Calls { get; set; }

        /// <summary>Starting time of the call count interval (ends midnight UTC) in UNIX time</summary>
        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
