using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class IpfsAddResponse
    {
        /// <summary>Name of the file</summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        /// <summary>IPFS hash of the file</summary>
        [JsonPropertyName("ipfs_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the file</summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
