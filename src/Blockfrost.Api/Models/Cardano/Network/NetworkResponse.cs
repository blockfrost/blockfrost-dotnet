// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class NetworkResponse
    {
        [JsonPropertyName("stake")]
        [Required]
        public Stake Stake { get; set; } = new Stake();

        [JsonPropertyName("supply")]
        [Required]
        public Supply Supply { get; set; } = new Supply();
    }
}
