// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class PoolDelegationResponse
    {
        /// <summary>Certificate within the transaction</summary>
        [JsonPropertyName("cert_index")]
        public int Cert_index { get; set; }

        /// <summary>Transaction ID</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}
