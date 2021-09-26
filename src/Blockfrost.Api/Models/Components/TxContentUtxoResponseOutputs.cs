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
        public AmountCollection Amount { get; set; }
    }
}

