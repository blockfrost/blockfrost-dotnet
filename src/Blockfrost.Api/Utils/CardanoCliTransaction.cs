// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
