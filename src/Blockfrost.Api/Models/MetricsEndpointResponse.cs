// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class MetricsEndpointResponse
    {
        /// <summary>Sum of all calls for a particular day and endpoint</summary>
        [JsonPropertyName("calls")]
        public int Calls { get; set; }

        /// <summary>Endpoint parent name</summary>
        [JsonPropertyName("endpoint")]
        [Required(AllowEmptyStrings = true)]
        public string Endpoint { get; set; }

        /// <summary>Starting time of the call count interval (ends midnight UTC) in UNIX time</summary>
        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
