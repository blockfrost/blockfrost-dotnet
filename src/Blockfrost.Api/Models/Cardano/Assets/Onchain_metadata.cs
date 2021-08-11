//namespace Blockfrost.Api.Models.Cardano.Assets
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Onchain_metadata
    {
        /// <summary>URI of the associated asset</summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>Name of the asset</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
