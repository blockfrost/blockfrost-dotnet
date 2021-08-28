using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class TxContentUTxOResponse
    {
        /// <summary>Transaction hash</summary>
        [JsonPropertyName("hash")]
        [Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        [JsonPropertyName("inputs")]
        [Required]
        public ICollection<Inputs> Inputs { get; set; } = new System.Collections.ObjectModel.Collection<Inputs>();

        [JsonPropertyName("outputs")]
        [Required]
        public ICollection<Outputs> Outputs { get; set; } = new System.Collections.ObjectModel.Collection<Outputs>();
    }
}
