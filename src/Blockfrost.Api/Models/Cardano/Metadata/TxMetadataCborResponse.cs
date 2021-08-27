// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class TxMetadataCborResponse
    {
        /// <summary>Content of the CBOR metadata</summary>
        [JsonPropertyName("cbor_metadata")]
        public string Cbor_metadata { get; set; }

        /// <summary>Metadata label</summary>
        [JsonPropertyName("label")]
        [Required(AllowEmptyStrings = true)]
        public string Label { get; set; }
    }
}
