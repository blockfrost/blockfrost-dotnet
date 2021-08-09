using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MetricResponse
    {
        /// <summary>Starting time of the call count interval (ends midnight UTC) in UNIX time</summary>
        [Newtonsoft.Json.JsonProperty("time", Required = Newtonsoft.Json.Required.Always)]
        public int Time { get; set; }

        /// <summary>Sum of all calls for a particular day</summary>
        [Newtonsoft.Json.JsonProperty("calls", Required = Newtonsoft.Json.Required.Always)]
        public int Calls { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}