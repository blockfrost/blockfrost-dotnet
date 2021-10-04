using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api.Models
{
    public partial class NetworkResponseSupply

    {
        /// <summary>Current circulating (UTXOs + withdrawables) supply in Lovelaces</summary>
        [JsonPropertyName("circulating")]
        [Required(AllowEmptyStrings = true)]
        public string Circulating { get; set; }

        /// <summary>Maximum supply in Lovelaces</summary>
        [JsonPropertyName("max")]
        [Required(AllowEmptyStrings = true)]
        public string Max { get; set; }

        /// <summary>Current total (max supply - reserves) supply in Lovelaces</summary>
        [JsonPropertyName("total")]
        [Required(AllowEmptyStrings = true)]
        public string Total { get; set; }
    }
}

