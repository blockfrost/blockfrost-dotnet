// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Stake
    {
        /// <summary>Current active stake in Lovelaces</summary>
        [JsonPropertyName("active")]
        [Required(AllowEmptyStrings = true)]
        public string Active { get; set; }

        /// <summary>Current live stake in Lovelaces</summary>
        [JsonPropertyName("live")]
        [Required(AllowEmptyStrings = true)]
        public string Live { get; set; }
    }
}
