// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    /// <summary>The sum of all assets of all addresses associated with a given account</summary>

    public partial class StakeAddressAddressesAssetsResponse
    {
        /// <summary>The quantity of the unit</summary>
        [JsonPropertyName("quantity")]
        [Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        /// <summary>The unit of the value</summary>
        [JsonPropertyName("unit")]
        [Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }
    }
}
