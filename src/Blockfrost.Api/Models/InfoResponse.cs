using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class InfoResponse
    {
        [JsonPropertyName("url")]
        [Required(AllowEmptyStrings = true)]
        public string Url { get; set; }

        [JsonPropertyName("version")]
        [Required(AllowEmptyStrings = true)]
        public string Version { get; set; }
    }
}
