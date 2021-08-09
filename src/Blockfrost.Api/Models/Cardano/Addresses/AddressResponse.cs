using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    public partial class AddressResponse
    {
        /// <summary>Bech32 encoded addresses</summary>
        [Required(AllowEmptyStrings = true)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// The sum of all the UTXO per asset
        /// </summary>
        [Required]
        [JsonPropertyName("amount")]
        public ICollection<Amount> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount>();

        /// <summary>Stake address that controls the key</summary>
        [JsonPropertyName("stake_address")]
        public string StakeAddress { get; set; }

        /// <summary>Address era</summary>
        [Required(AllowEmptyStrings = true)]
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EAddressType Type { get; set; }
    }
}