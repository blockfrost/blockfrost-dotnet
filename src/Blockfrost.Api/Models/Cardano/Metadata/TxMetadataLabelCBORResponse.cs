// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class TxMetadataLabelCBORResponse
    {
        /// <summary>Content of the CBOR metadata</summary>
        [JsonPropertyName("cbor_metadata")]
        public string Cbor_metadata { get; set; }

        /// <summary>Transaction hash that contains the specific metadata</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}
