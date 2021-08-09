using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metadata2
    {
        /// <summary>URL to the stake pool metadata</summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Url { get; set; }

        /// <summary>Hash of the metadata file</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Hash { get; set; }

        /// <summary>Ticker of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("ticker", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ticker { get; set; }

        /// <summary>Name of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Name { get; set; }

        /// <summary>Description of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Description { get; set; }

        /// <summary>Home page of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("homepage", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Homepage { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}