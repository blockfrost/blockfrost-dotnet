using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class IpfsPinListResponse
    {
        /// <summary>IPFS hash of the pinned object</summary>
        [JsonPropertyName("ipfs_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the object in Bytes</summary>
        [JsonPropertyName("size")]
        [Required(AllowEmptyStrings = true)]
        public string Size { get; set; }

        /// <summary>State of the pinned object. We define 5 states: `queued`, `pinned`, `unpinned`, `failed`, `gc`.
        /// <br/>When the object is pending retrieval (i.e. after `/ipfs/pin/add/{IPFS_path}`), the state is `queued`.
        /// <br/>If the object is already successfully retrieved, state is changed to `pinned` or `failed` otherwise.
        /// <br/>When object is unpinned (i.e. after `/ipfs/pin/remove/{IPFS_path}`) it is marked for garbage collection.
        /// <br/>State `gc` means that a previously `unpinned` item has been garbage collected due to account being over storage quota.
        /// <br/></summary>
        [JsonPropertyName("state")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EResponse13State State { get; set; }

        /// <summary>Time of the creation of the IPFS object on our backends</summary>
        [JsonPropertyName("time_created")]
        public int Time_created { get; set; }

        /// <summary>Time of the pin of the IPFS object on our backends</summary>
        [JsonPropertyName("time_pinned")]
        public int Time_pinned { get; set; }
    }
}
