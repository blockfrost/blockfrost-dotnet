using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Inputs
    {
        /// <summary>Input address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public ICollection<Amount3> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount3>();

        /// <summary>Hash of the UTXO transaction</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [JsonPropertyName("output_index")]
        public double Output_index { get; set; }
    }
}
