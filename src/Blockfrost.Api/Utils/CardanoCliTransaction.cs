using System.Text.Json.Serialization;

namespace Blockfrost.Api.Utils
{
    /// <summary>
    /// Serializable cardano-cli transaction body
    /// </summary>
    public class CardanoCliTransaction : ICardanoCliTransaction
    {

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cborHex")]
        public string CBORHex { get; set; }
    }
}
