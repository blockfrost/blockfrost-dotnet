using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class RetiredResponse
    {
        /// <summary>Bech32 encoded pool ID</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Retirement epoch number</summary>
        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }
    }
}
