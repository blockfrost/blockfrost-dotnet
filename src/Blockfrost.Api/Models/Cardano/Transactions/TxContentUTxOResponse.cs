// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class TxContentUTxOResponse
    {
        /// <summary>Transaction hash</summary>
        [JsonPropertyName("hash")]
        [Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        [JsonPropertyName("inputs")]
        [Required]
        public ICollection<Inputs> Inputs { get; set; } = new System.Collections.ObjectModel.Collection<Inputs>();

        [JsonPropertyName("outputs")]
        [Required]
        public ICollection<Outputs> Outputs { get; set; } = new System.Collections.ObjectModel.Collection<Outputs>();
    }
}
