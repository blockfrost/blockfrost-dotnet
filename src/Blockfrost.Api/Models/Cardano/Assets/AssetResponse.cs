// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Assets
namespace Blockfrost.Api
{
    public partial class AssetResponse
    {
        /// <summary>Hex-encoded asset name of the asset</summary>
        [JsonPropertyName("asset_name")]
        public string Asset_name { get; set; }

        /// <summary>Hex-encoded asset full name</summary>
        [JsonPropertyName("asset")]
        [Required(AllowEmptyStrings = true)]
        public string Asset1 { get; set; }

        /// <summary>CIP14 based user-facing fingerprint</summary>
        [JsonPropertyName("fingerprint")]
        [Required(AllowEmptyStrings = true)]
        public string Fingerprint { get; set; }

        /// <summary>ID of the initial minting transaction</summary>
        [JsonPropertyName("initial_mint_tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Initial_mint_tx_hash { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        /// <summary>Count of mint and burn transactions</summary>
        [JsonPropertyName("mint_or_burn_count")]
        public int Mint_or_burn_count { get; set; }

        /// <summary>On-chain metadata stored in the minting transaction under label 721,
        /// <br/>community discussion around the standard ongoing at https://github.com/cardano-foundation/CIPs/pull/85
        /// <br/></summary>
        [JsonPropertyName("onchain_metadata")]
        public Onchain_metadata Onchain_metadata { get; set; }

        /// <summary>Policy ID of the asset</summary>
        [JsonPropertyName("policy_id")]
        [Required(AllowEmptyStrings = true)]
        public string Policy_id { get; set; }

        /// <summary>Current asset quantity</summary>
        [JsonPropertyName("quantity")]
        [Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }
    }
}
