using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Assets
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AssetTransactionResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Block height</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        /// <summary>Hash of the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_index { get; set; }
    }
}