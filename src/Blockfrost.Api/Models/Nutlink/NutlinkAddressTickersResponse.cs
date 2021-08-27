// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class NutlinkAddressTickersResponse
    {
        /// <summary>Number of ticker records</summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>Block height of the latest record</summary>
        [JsonPropertyName("latest_block")]
        public int Latest_block { get; set; }

        /// <summary>Name of the ticker</summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
    }
}
