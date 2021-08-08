using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Health
    {
        [Newtonsoft.Json.JsonProperty("is_healthy", Required = Newtonsoft.Json.Required.Always)]
        public bool IsHealthy { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}
