using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class NetworkResponse
    {
        [JsonPropertyName("stake")]
        [Required]
        public Stake Stake { get; set; } = new Stake();

        [JsonPropertyName("supply")]
        [Required]
        public Supply Supply { get; set; } = new Supply();
    }
}
