using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="GenesisContentResponse"/>
    /// </summary>
    public partial class GenesisContentResponse : IEquatable<GenesisContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenesisContentResponse" /> class.
        /// </summary>
        public GenesisContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the ActiveSlotsCoefficient
        /// </summary>
        /// <returns>
        /// The proportion of slots in which blocks should be issued
        /// </returns>
        [Required]
        [JsonPropertyName("active_slots_coefficient")]
        public double ActiveSlotsCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the UpdateQuorum
        /// </summary>
        /// <returns>
        /// Determines the quorum needed for votes on the protocol parameter updates
        /// </returns>
        [Required]
        [JsonPropertyName("update_quorum")]
        public long UpdateQuorum { get; set; }

        /// <summary>
        /// Gets or sets the MaxLovelaceSupply
        /// </summary>
        /// <returns>
        /// The total number of lovelace in the system
        /// </returns>
        [Required]
        [JsonPropertyName("max_lovelace_supply")]
        public string MaxLovelaceSupply { get; set; }

        /// <summary>
        /// Gets or sets the NetworkMagic
        /// </summary>
        /// <returns>
        /// Network identifier
        /// </returns>
        [Required]
        [JsonPropertyName("network_magic")]
        public long NetworkMagic { get; set; }

        /// <summary>
        /// Gets or sets the EpochLength
        /// </summary>
        /// <returns>
        /// Number of slots in an epoch
        /// </returns>
        [Required]
        [JsonPropertyName("epoch_length")]
        public long EpochLength { get; set; }

        /// <summary>
        /// Gets or sets the SystemStart
        /// </summary>
        /// <returns>
        /// Time of slot 0 in UNIX time
        /// </returns>
        [Required]
        [JsonPropertyName("system_start")]
        public long SystemStart { get; set; }

        /// <summary>
        /// Gets or sets the SlotsPerKesPeriod
        /// </summary>
        /// <returns>
        /// Number of slots in an KES period
        /// </returns>
        [Required]
        [JsonPropertyName("slots_per_kes_period")]
        public long SlotsPerKesPeriod { get; set; }

        /// <summary>
        /// Gets or sets the SlotLength
        /// </summary>
        /// <returns>
        /// Duration of one slot in seconds
        /// </returns>
        [Required]
        [JsonPropertyName("slot_length")]
        public long SlotLength { get; set; }

        /// <summary>
        /// Gets or sets the MaxKesEvolutions
        /// </summary>
        /// <returns>
        /// The maximum number of time a KES key can be evolved before a pool operator must create a new operational certificate
        /// </returns>
        [Required]
        [JsonPropertyName("max_kes_evolutions")]
        public long MaxKesEvolutions { get; set; }

        /// <summary>
        /// Gets or sets the SecurityParam
        /// </summary>
        /// <returns>
        /// Security parameter k
        /// </returns>
        [Required]
        [JsonPropertyName("security_param")]
        public long SecurityParam { get; set; }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return ToJson();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson(JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(this, options);
        }
        /// <summary>
        /// Returns true if GenesisContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of GenesisContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GenesisContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (ActiveSlotsCoefficient == other.ActiveSlotsCoefficient && UpdateQuorum == other.UpdateQuorum && MaxLovelaceSupply == other.MaxLovelaceSupply && NetworkMagic == other.NetworkMagic && EpochLength == other.EpochLength && SystemStart == other.SystemStart && SlotsPerKesPeriod == other.SlotsPerKesPeriod && SlotLength == other.SlotLength && MaxKesEvolutions == other.MaxKesEvolutions && SecurityParam == other.SecurityParam));
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return obj is not null
                   && (ReferenceEquals(this, obj)
                   || (obj.GetType() != GetType() && Equals((GenesisContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(ActiveSlotsCoefficient);
            hashCode.Add(UpdateQuorum);
            hashCode.Add(MaxLovelaceSupply);
            hashCode.Add(NetworkMagic);
            hashCode.Add(EpochLength);
            hashCode.Add(SystemStart);
            hashCode.Add(SlotsPerKesPeriod);
            hashCode.Add(SlotLength);
            hashCode.Add(MaxKesEvolutions);
            hashCode.Add(SecurityParam);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(GenesisContentResponse left, GenesisContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GenesisContentResponse left, GenesisContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

