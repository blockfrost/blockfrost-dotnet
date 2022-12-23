using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// UTxO inputs
    /// </summary>
    public partial class TxContentUtxoResponseInputs

    {
        /// <summary>Input address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public InputAmountCollection Amount { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [JsonPropertyName("output_index")]
        public double OutputIndex { get; set; }

        /// <summary>Hash of the UTXO transaction</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string TxHash { get; set; }

        /// <summary>The hash of the transaction output datum</summary>
        [JsonPropertyName("data_hash")]
        [Required(AllowEmptyStrings = true)]
        public string DataHash { get; set; }

        /// <summary>Whether the input is a collateral consumed on script validation failure</summary>
        [JsonPropertyName("collateral")]
        [Required(AllowEmptyStrings = true)]
        public bool Collateral { get; set; }
    }
}

