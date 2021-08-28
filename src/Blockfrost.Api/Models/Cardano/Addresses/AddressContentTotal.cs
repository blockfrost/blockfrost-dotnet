using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    public partial class AddressContentTotal
    {
        /// <summary>Bech32 encoded address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("received_sum")]
        [Required]
        public ICollection<Received_sum> Received_sum { get; set; } = new System.Collections.ObjectModel.Collection<Received_sum>();

        [JsonPropertyName("sent_sum")]
        [Required]
        public ICollection<Sent_sum> Sent_sum { get; set; } = new System.Collections.ObjectModel.Collection<Sent_sum>();

        /// <summary>Count of all transactions on the address</summary>
        [JsonPropertyName("tx_count")]
        public int Tx_count { get; set; }
    }
}
