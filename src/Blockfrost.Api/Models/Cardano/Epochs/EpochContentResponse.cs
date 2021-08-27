// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class EpochContentResponse
    {
        /// <summary>Sum of all the active stakes within the epoch in Lovelaces</summary>
        [JsonPropertyName("active_stake")]
        public string Active_stake { get; set; }

        /// <summary>Number of blocks within the epoch</summary>
        [JsonPropertyName("block_count")]
        public int Block_count { get; set; }

        /// <summary>Unix time of the end of the epoch</summary>
        [JsonPropertyName("end_time")]
        public int End_time { get; set; }

        /// <summary>Epoch number</summary>
        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }

        /// <summary>Sum of all the fees within the epoch in Lovelaces</summary>
        [JsonPropertyName("fees")]
        [Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        /// <summary>Unix time of the first block of the epoch</summary>
        [JsonPropertyName("first_block_time")]
        public int First_block_time { get; set; }

        /// <summary>Unix time of the last block of the epoch</summary>
        [JsonPropertyName("last_block_time")]
        public int Last_block_time { get; set; }

        /// <summary>Sum of all the transactions within the epoch in Lovelaces</summary>
        [JsonPropertyName("output")]
        [Required(AllowEmptyStrings = true)]
        public string Output { get; set; }

        /// <summary>Unix time of the start of the epoch</summary>
        [JsonPropertyName("start_time")]
        public int Start_time { get; set; }

        /// <summary>Number of transactions within the epoch</summary>
        [JsonPropertyName("tx_count")]
        public int Tx_count { get; set; }
    }
}
