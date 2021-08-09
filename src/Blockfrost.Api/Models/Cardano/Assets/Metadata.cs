//namespace Blockfrost.Api.Models.Cardano.Assets
using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metadata
    {
        /// <summary>Asset name</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        /// <summary>Asset description</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("ticker", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ticker { get; set; }

        /// <summary>Asset website</summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Url { get; set; }

        /// <summary>Base64 encoded logo of the asset</summary>
        [Newtonsoft.Json.JsonProperty("logo", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Logo { get; set; }

        /// <summary>Number of decimal places of the asset unit</summary>
        [Newtonsoft.Json.JsonProperty("decimals", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.Range(int.MinValue, 255)]
        public int? Decimals { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}