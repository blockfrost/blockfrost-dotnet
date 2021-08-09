using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class RetiredResponse
    {
        /// <summary>Bech32 encoded pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Retirement epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}