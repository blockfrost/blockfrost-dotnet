using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxStakeAddress
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Delegation stake address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Registration boolean, false if deregistration</summary>
        [Newtonsoft.Json.JsonProperty("registration", Required = Newtonsoft.Json.Required.Always)]
        public bool Registration { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}