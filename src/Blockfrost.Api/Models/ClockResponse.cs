// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class ClockResponse
    {
        [JsonPropertyName("server_time")]
        public long ServerTime { get; set; }
    }
}
