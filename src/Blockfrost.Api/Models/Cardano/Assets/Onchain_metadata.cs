// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
