// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class TxContentResponse
    {
        /// <summary>Count of asset mints and burns within the transaction</summary>
        [JsonPropertyName("asset_mint_or_burn_count")]
        public int Asset_mint_or_burn_count { get; set; }

        /// <summary>Block hash</summary>
        [JsonPropertyName("block")]
        [Required(AllowEmptyStrings = true)]
        public string Block { get; set; }

        /// <summary>Block number</summary>
        [JsonPropertyName("block_height")]
        public int Block_height { get; set; }

        /// <summary>Count of the delegations within the transaction</summary>
        [JsonPropertyName("delegation_count")]
        public int Delegation_count { get; set; }

        /// <summary>Deposit within the transaction in Lovelaces</summary>
        [JsonPropertyName("deposit")]
        [Required(AllowEmptyStrings = true)]
        public string Deposit { get; set; }

        /// <summary>Fees of the transaction in Lovelaces</summary>
        [JsonPropertyName("fees")]
        [Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        /// <summary>Transaction hash</summary>
        [JsonPropertyName("hash")]
        [Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        /// <summary>Transaction index within the block</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>Left (included) endpoint of the timelock validity intervals</summary>
        [JsonPropertyName("invalid_before")]
        public string Invalid_before { get; set; }

        /// <summary>Right (excluded) endpoint of the timelock validity intervals</summary>
        [JsonPropertyName("invalid_hereafter")]
        public string Invalid_hereafter { get; set; }

        /// <summary>Count of the MIR certificates within the transaction</summary>
        [JsonPropertyName("mir_cert_count")]
        public int Mir_cert_count { get; set; }

        [JsonPropertyName("output_amount")]
        [Required]
        public ICollection<Output_amount> Output_amount { get; set; } = new System.Collections.ObjectModel.Collection<Output_amount>();

        /// <summary>Count of the stake pool retirement certificates within the transaction</summary>
        [JsonPropertyName("pool_retire_count")]
        public int Pool_retire_count { get; set; }

        /// <summary>Count of the stake pool registration and update certificates within the transaction</summary>
        [JsonPropertyName("pool_update_count")]
        public int Pool_update_count { get; set; }

        /// <summary>Size of the transaction in Bytes</summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>Slot number</summary>
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        /// <summary>Count of the stake keys (de)registration and delegation certificates within the transaction</summary>
        [JsonPropertyName("stake_cert_count")]
        public int Stake_cert_count { get; set; }

        /// <summary>Count of UTXOs within the transaction</summary>
        [JsonPropertyName("utxo_count")]
        public int Utxo_count { get; set; }

        /// <summary>Count of the withdrawal within the transaction</summary>
        [JsonPropertyName("withdrawal_count")]
        public int Withdrawal_count { get; set; }
    }
}
