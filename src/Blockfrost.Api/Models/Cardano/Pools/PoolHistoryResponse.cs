// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class PoolHistoryResponse
    {
        /// <summary>Pool size (percentage) of overall active stake at that epoch</summary>
        [JsonPropertyName("active_size")]
        public double Active_size { get; set; }

        /// <summary>Active (Snapshot of live stake 2 epochs ago) stake in Lovelaces</summary>
        [JsonPropertyName("active_stake")]
        [Required(AllowEmptyStrings = true)]
        public string Active_stake { get; set; }

        /// <summary>Number of blocks created by pool</summary>
        [JsonPropertyName("blocks")]
        public int Blocks { get; set; }

        /// <summary>Number of delegators for epoch</summary>
        [JsonPropertyName("delegators_count")]
        public int Delegators_count { get; set; }

        /// <summary>Epoch number</summary>
        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }

        /// <summary>Pool operator rewards</summary>
        [JsonPropertyName("fees")]
        [Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        /// <summary>Total rewards received before distribution to delegators</summary>
        [JsonPropertyName("rewards")]
        [Required(AllowEmptyStrings = true)]
        public string Rewards { get; set; }
    }
}
