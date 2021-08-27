// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
