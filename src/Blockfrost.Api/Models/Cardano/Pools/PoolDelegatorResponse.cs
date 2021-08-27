// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class PoolDelegatorResponse
    {
        /// <summary>Bech32 encoded stake addresses</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Currently delegated amount</summary>
        [JsonPropertyName("live_stake")]
        [Required(AllowEmptyStrings = true)]
        public string Live_stake { get; set; }
    }
}
