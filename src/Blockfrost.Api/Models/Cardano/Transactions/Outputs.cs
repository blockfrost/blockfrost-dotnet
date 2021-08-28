using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Outputs
    {
        /// <summary>Output address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public ICollection<Amount4> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount4>();
    }
}
