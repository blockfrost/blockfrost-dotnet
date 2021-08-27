// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class NutlinkTickersTickerResponse
    {
        /// <summary>Address of a metadata oracle</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Block height of the record</summary>
        [JsonPropertyName("block_height")]
        public int Block_height { get; set; }

        /// <summary>Content of the ticker</summary>
        [JsonPropertyName("payload")]
        public Payload2 Payload { get; set; }

        /// <summary>Hash of the transaction</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Transaction index within the block</summary>
        [JsonPropertyName("tx_index")]
        public int Tx_index { get; set; }
    }
}
