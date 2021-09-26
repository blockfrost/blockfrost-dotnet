using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api.Models
{
    public partial class TxContentUtxoResponseInputs

    {
        /// <summary>Input address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public AmountCollection Amount { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [JsonPropertyName("output_index")]
        public double OutputIndex { get; set; }

        /// <summary>Hash of the UTXO transaction</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string TxHash { get; set; }
    }
}

