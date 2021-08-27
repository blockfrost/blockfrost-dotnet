// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class RetiredResponse
    {
        /// <summary>Retirement epoch number</summary>
        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }

        /// <summary>Bech32 encoded pool ID</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }
    }
}
