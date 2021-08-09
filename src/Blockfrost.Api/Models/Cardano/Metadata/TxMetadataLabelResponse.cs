using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxMetadataLabelResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>CIP10 defined description</summary>
        [Newtonsoft.Json.JsonProperty("cip10", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Cip10 { get; set; }

        /// <summary>The count of metadata entries with a specific label</summary>
        [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Count { get; set; }

        /// <summary>Metadata label</summary>
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Label { get; set; }
    }
}