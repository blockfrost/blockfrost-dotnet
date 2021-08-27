// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Metadata
    {
        /// <summary>Number of decimal places of the asset unit</summary>
        [JsonPropertyName("decimals")]
        [System.ComponentModel.DataAnnotations.Range(int.MinValue, 255)]
        public int? Decimals { get; set; }

        /// <summary>Asset description</summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        /// <summary>Base64 encoded logo of the asset</summary>
        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        /// <summary>Asset name</summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        /// <summary>Asset website</summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
