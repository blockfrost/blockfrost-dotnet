using System.Collections.Generic;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    public partial class AddressResponse
    {
        /// <summary>Bech32 encoded addresses</summary>
        [JsonPropertyName("address")]
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [JsonPropertyName("amount")]
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Amount> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount>();

        /// <summary>Stake address that controls the key</summary>
        [JsonPropertyName("stake_address")]
        [Newtonsoft.Json.JsonProperty("stake_address", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Stake_address { get; set; }

        /// <summary>Address era</summary>
        [JsonPropertyName("type")]
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public EAddressContentType Type { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}