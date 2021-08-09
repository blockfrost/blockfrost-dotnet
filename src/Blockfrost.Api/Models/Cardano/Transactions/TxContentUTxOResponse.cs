using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxContentUTxOResponse
    {
        /// <summary>Transaction hash</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("inputs", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Inputs> Inputs { get; set; } = new System.Collections.ObjectModel.Collection<Inputs>();

        [Newtonsoft.Json.JsonProperty("outputs", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Outputs> Outputs { get; set; } = new System.Collections.ObjectModel.Collection<Outputs>();

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}