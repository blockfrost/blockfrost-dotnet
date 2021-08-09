using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Relays
    {
        /// <summary>IPv4 address of the relay</summary>
        [Newtonsoft.Json.JsonProperty("ipv4", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ipv4 { get; set; }

        /// <summary>IPv6 address of the relay</summary>
        [Newtonsoft.Json.JsonProperty("ipv6", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ipv6 { get; set; }

        /// <summary>DNS name of the relay</summary>
        [Newtonsoft.Json.JsonProperty("dns", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Dns { get; set; }

        /// <summary>DNS SRV entry of the relay</summary>
        [Newtonsoft.Json.JsonProperty("dns_srv", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Dns_srv { get; set; }

        /// <summary>Network port of the relay</summary>
        [Newtonsoft.Json.JsonProperty("port", Required = Newtonsoft.Json.Required.Always)]
        public int Port { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}