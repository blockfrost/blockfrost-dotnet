using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxMetadataLabelJsonResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Content of the JSON metadata</summary>
        [Newtonsoft.Json.JsonProperty("json_metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Json_metadata Json_metadata { get; set; }

        /// <summary>Transaction hash that contains the specific metadata</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}