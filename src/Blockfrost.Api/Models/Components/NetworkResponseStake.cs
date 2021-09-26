using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api.Models
{
    public partial class NetworkResponseStake

    {
        /// <summary>Current active stake in Lovelaces</summary>
        [JsonPropertyName("active")]
        [Required(AllowEmptyStrings = true)]
        public string Active { get; set; }

        /// <summary>Current live stake in Lovelaces</summary>
        [JsonPropertyName("live")]
        [Required(AllowEmptyStrings = true)]
        public string Live { get; set; }
    }
}

