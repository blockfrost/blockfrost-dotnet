using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class IpfsPinAddResponse
    {
        /// <summary>IPFS hash of the pinned object</summary>
        [JsonPropertyName("ipfs_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>State of the pin action</summary>
        [JsonPropertyName("state")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EResponse12State State { get; set; }
    }
}
