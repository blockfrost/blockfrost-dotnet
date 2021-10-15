using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// UTxO Outputs
    /// </summary>
    public partial class TxContentUtxoResponseOutputs
    {
        /// <summary>Output address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public OutputAmountCollection Amount { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [JsonPropertyName("output_index")]
        public double OutputIndex { get; set; }

        /// <summary>The hash of the transaction output datum</summary>
        [JsonPropertyName("data_hash")]
        [Required(AllowEmptyStrings = true)]
        public string DataHash { get; set; }
    }
}

