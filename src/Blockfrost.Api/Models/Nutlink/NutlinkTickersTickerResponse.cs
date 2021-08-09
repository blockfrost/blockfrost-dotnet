using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class NutlinkTickersTickerResponse
    {
        /// <summary>Address of a metadata oracle</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Hash of the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Block height of the record</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_index { get; set; }

        /// <summary>Content of the ticker</summary>
        [Newtonsoft.Json.JsonProperty("payload", Required = Newtonsoft.Json.Required.Always)]
        public Payload2 Payload { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}