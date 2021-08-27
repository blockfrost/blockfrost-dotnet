// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace Blockfrost.Api.Utils
{
    public class ProtocolVersion
    {
        [JsonPropertyName("minor")]
        public int Minor { get; set; }
        [JsonPropertyName("major")]
        public int Major { get; set; }
    }
}
