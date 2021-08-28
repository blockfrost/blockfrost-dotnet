// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class BlockContentResponse
    {
        /// <summary>VRF key of the block</summary>
        [JsonPropertyName("block_vrf")]
        [StringLength(65, MinimumLength = 65)]
        public string BlockVrf { get; set; }

        /// <summary>Number of block confirmations</summary>
        [JsonPropertyName("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>Epoch number</summary>
        [JsonPropertyName("epoch")]
        public int? Epoch { get; set; }

        /// <summary>Slot within the epoch</summary>
        [JsonPropertyName("epoch_slot")]
        public int? EpochSlot { get; set; }

        /// <summary>Total fees within the block in Lovelaces</summary>
        [JsonPropertyName("fees")]
        public string Fees { get; set; }

        /// <summary>Hash of the block</summary>
        [JsonPropertyName("hash")]
        [Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        /// <summary>Block number</summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>Hash of the next block</summary>
        [JsonPropertyName("next_block")]
        public string NextBlock { get; set; }

        /// <summary>Total output within the block in Lovelaces</summary>
        [JsonPropertyName("output")]
        public string Output { get; set; }

        /// <summary>Hash of the previous block</summary>
        [JsonPropertyName("previous_block")]
        public string PreviousBlock { get; set; }

        /// <summary>Block size in Bytes</summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>Slot number</summary>
        [JsonPropertyName("slot")]
        public int? Slot { get; set; }

        /// <summary>Bech32 ID of the slot leader or specific block description in case there is no slot leader</summary>
        [JsonPropertyName("slot_leader")]
        [Required(AllowEmptyStrings = true)]
        public string SlotLeader { get; set; }

        /// <summary>Block creation time in UNIX time</summary>
        [JsonPropertyName("time")]
        public int Time { get; set; }

        /// <summary>Number of transactions in the block</summary>
        [JsonPropertyName("tx_count")]
        public int TxCount { get; set; }
    }
}
