using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IpfsPinListResponse
    {
        /// <summary>Time of the creation of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_created", Required = Newtonsoft.Json.Required.Always)]
        public int Time_created { get; set; }

        /// <summary>Time of the pin of the IPFS object on our backends</summary>
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

        /// <summary>State of the pinned object. We define 5 states: `queued`, `pinned`, `unpinned`, `failed`, `gc`.
        /// <br/>When the object is pending retrieval (i.e. after `/ipfs/pin/add/{IPFS_path}`), the state is `queued`.
        /// <br/>If the object is already successfully retrieved, state is changed to `pinned` or `failed` otherwise.
        /// <br/>When object is unpinned (i.e. after `/ipfs/pin/remove/{IPFS_path}`) it is marked for garbage collection.
        /// <br/>State `gc` means that a previously `unpinned` item has been garbage collected due to account being over storage quota.
        /// <br/></summary>
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public EResponse13State State { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}