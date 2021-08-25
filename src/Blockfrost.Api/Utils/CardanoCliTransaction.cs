using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Blockfrost.Api.Utils
{
    /// <summary>
    /// Serializable cardano-cli transaction body
    /// </summary>
    public class CardanoCliTransaction
    {
        [JsonPropertyName("type")]
        string Type { get; set; }

        [JsonPropertyName("description")]
        string Description { get; set; }

        [JsonPropertyName("cborHex")]
        string CBORHex { get; set; }
    }

}
