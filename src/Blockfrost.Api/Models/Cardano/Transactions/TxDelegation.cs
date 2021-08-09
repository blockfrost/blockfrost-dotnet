using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxDelegation
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
        [System.Obsolete]
        public int Index { get; set; }

        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Bech32 delegation stake address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Bech32 ID of delegated stake pool</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Epoch in which the delegation becomes active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}