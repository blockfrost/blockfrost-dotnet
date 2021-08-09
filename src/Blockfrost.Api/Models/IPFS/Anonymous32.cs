using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Anonymous32
    {
        /// <summary>Creation time of the IPFS object on our backends</summary>
        [JsonPropertyName("time_created")]
        public int Time_created { get; set; }

        /// <summary>Pin time of the IPFS object on our backends</summary>
        [JsonPropertyName("time_pinned")]
        public int Time_pinned { get; set; }

        /// <summary>IPFS hash of the pinned object</summary>
        [JsonPropertyName("ipfs_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the object in Bytes</summary>
        [JsonPropertyName("size")]
        [Required(AllowEmptyStrings = true)]
        public string Size { get; set; }

        /// <summary>State of the pinned object, which is `queued` when we are retriving object. If this
        /// <br/>is successful the state is changed to `pinned` or `failed` if not. The state `gc` means the
        /// <br/>pinned item has been garbage collected due to account being over storage quota or after it has
        /// <br/>been moved to `unpinned` state by removing the object pin.
        /// <br/></summary>
        [JsonPropertyName("state")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EState State { get; set; }
    }
}
