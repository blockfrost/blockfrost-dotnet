using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class NutlinkAddress
    {
        /// <summary>Bech32 encoded address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>The cached metadata of the `metadata_url` file.</summary>
        [JsonPropertyName("metadata")]
        public JsonElement Metadata { get; set; }

        /// <summary>Hash of the metadata file</summary>
        [JsonPropertyName("metadata_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Metadata_hash { get; set; }

        /// <summary>URL do specific metadata file</summary>
        [JsonPropertyName("metadata_url")]
        [Required(AllowEmptyStrings = true)]
        public string Metadata_url { get; set; }
    }
}
