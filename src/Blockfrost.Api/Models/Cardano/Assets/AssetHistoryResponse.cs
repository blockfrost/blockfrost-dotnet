using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Assets
namespace Blockfrost.Api
{
    public partial class AssetHistoryResponse
    {
        /// <summary>Action executed upon the asset policy</summary>
        [JsonPropertyName("action")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EAction3 Action { get; set; }

        /// <summary>Asset amount of the specific action</summary>
        [JsonPropertyName("amount")]
        [Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Hash of the transaction containing the asset action</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}
