using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous32
    {
        /// <summary>Creation time of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_created", Required = Newtonsoft.Json.Required.Always)]
        public int Time_created { get; set; }

        /// <summary>Pin time of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_pinned", Required = Newtonsoft.Json.Required.Always)]
        public int Time_pinned { get; set; }

        /// <summary>IPFS hash of the pinned object</summary>
        [Newtonsoft.Json.JsonProperty("ipfs_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the object in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Size { get; set; }

        /// <summary>State of the pinned object, which is `queued` when we are retriving object. If this
        /// <br/>is successful the state is changed to `pinned` or `failed` if not. The state `gc` means the
        /// <br/>pinned item has been garbage collected due to account being over storage quota or after it has
        /// <br/>been moved to `unpinned` state by removing the object pin.
        /// <br/></summary>
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public EState State { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}