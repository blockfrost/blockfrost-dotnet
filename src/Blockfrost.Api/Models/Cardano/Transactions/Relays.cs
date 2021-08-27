// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class Relays
    {
        /// <summary>DNS name of the relay</summary>
        [JsonPropertyName("dns")]
        public string Dns { get; set; }

        /// <summary>DNS SRV entry of the relay</summary>
        [JsonPropertyName("dns_srv")]
        public string Dns_srv { get; set; }

        /// <summary>IPv4 address of the relay</summary>
        [JsonPropertyName("ipv4")]
        public string Ipv4 { get; set; }

        /// <summary>IPv6 address of the relay</summary>
        [JsonPropertyName("ipv6")]
        public string Ipv6 { get; set; }

        /// <summary>Network port of the relay</summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }
    }
}
