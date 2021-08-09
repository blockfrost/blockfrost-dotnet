using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AddressContentTotal
    {
        /// <summary>Bech32 encoded address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("received_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Received_sum> Received_sum { get; set; } = new System.Collections.ObjectModel.Collection<Received_sum>();

        [Newtonsoft.Json.JsonProperty("sent_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Sent_sum> Sent_sum { get; set; } = new System.Collections.ObjectModel.Collection<Sent_sum>();

        /// <summary>Count of all transactions on the address</summary>
        [Newtonsoft.Json.JsonProperty("tx_count", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_count { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}