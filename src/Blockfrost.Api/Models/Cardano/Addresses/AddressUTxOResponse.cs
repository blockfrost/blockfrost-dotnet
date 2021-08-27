// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    public partial class AddressUTxOResponse
    {
        [JsonPropertyName("amount")]
        [Required]
        public ICollection<Amount2> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount2>();

        /// <summary>Block number of the UTXO</summary>
        [JsonPropertyName("block")]
        [Required(AllowEmptyStrings = true)]
        public string Block { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [JsonPropertyName("output_index")]
        public int Output_index { get; set; }

        /// <summary>Transaction hash of the UTXO</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [JsonPropertyName("tx_index")]
        [System.Obsolete("No longer supported by blockfrost and may be removed in future releases")]
        public int Tx_index { get; set; }
    }
}
