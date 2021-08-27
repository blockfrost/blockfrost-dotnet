// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class GenesisContentResponse
    {
        /// <summary>The proportion of slots in which blocks should be issued</summary>
        [JsonPropertyName("active_slots_coefficient")]
        public double ActiveSlotsCoefficient { get; set; }

        /// <summary>Number of slots in an epoch</summary>
        [JsonPropertyName("epoch_length")]
        public int EpochLength { get; set; }

        /// <summary>The maximum number of time a KES key can be evolved before a pool operator must create a new operational certificate</summary>
        [JsonPropertyName("max_kes_evolutions")]
        public int MaxKesEvolutions { get; set; }

        /// <summary>The total number of lovelace in the system</summary>
        [JsonPropertyName("max_lovelace_supply")]
        [Required(AllowEmptyStrings = true)]
        public string MaxLovelaceSupply { get; set; }

        /// <summary>Network identifier</summary>
        [JsonPropertyName("network_magic")]
        public int NetworkMagic { get; set; }

        /// <summary>Security parameter k</summary>
        [JsonPropertyName("security_param")]
        public int SecurityParam { get; set; }

        /// <summary>Duration of one slot in seconds</summary>
        [JsonPropertyName("slot_length")]
        public int SlotLength { get; set; }

        /// <summary>Number of slots in an KES period</summary>
        [JsonPropertyName("slots_per_kes_period")]
        public int SlotsPerKesPeriod { get; set; }

        /// <summary>Time of slot 0 in UNIX time</summary>
        [JsonPropertyName("system_start")]
        public int SystemStart { get; set; }

        /// <summary>Determines the quorum needed for votes on the protocol parameter updates</summary>
        [JsonPropertyName("update_quorum")]
        public int UpdateQuorum { get; set; }
    }
}
