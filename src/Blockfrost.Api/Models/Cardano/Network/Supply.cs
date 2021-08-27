// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Supply
    {
        /// <summary>Current circulating (UTXOs + withdrawables) supply in Lovelaces</summary>
        [JsonPropertyName("circulating")]
        [Required(AllowEmptyStrings = true)]
        public string Circulating { get; set; }

        /// <summary>Maximum supply in Lovelaces</summary>
        [JsonPropertyName("max")]
        [Required(AllowEmptyStrings = true)]
        public string Max { get; set; }

        /// <summary>Current total (max supply - reserves) supply in Lovelaces</summary>
        [JsonPropertyName("total")]
        [Required(AllowEmptyStrings = true)]
        public string Total { get; set; }
    }
}
