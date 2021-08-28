using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Assets
namespace Blockfrost.Api
{
    public partial class AssetTransactionResponse
    {
        /// <summary>Block height</summary>
        [JsonPropertyName("block_height")]
        public int Block_height { get; set; }

        /// <summary>Hash of the transaction</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Transaction index within the block</summary>
        [JsonPropertyName("tx_index")]
        public int Tx_index { get; set; }
    }
}
