// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class TxMetadataLabelResponse
    {
        /// <summary>CIP10 defined description</summary>
        [JsonPropertyName("cip10")]
        public string Cip10 { get; set; }

        /// <summary>The count of metadata entries with a specific label</summary>
        [JsonPropertyName("count")]
        [Required(AllowEmptyStrings = true)]
        public string Count { get; set; }

        /// <summary>Metadata label</summary>
        [JsonPropertyName("label")]
        [Required(AllowEmptyStrings = true)]
        public string Label { get; set; }
    }
}
