using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PoolHistoryResponse"/>
    /// </summary>
    public partial class PoolHistoryResponse : IEquatable<PoolHistoryResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolHistoryResponse" /> class.
        /// </summary>
        public PoolHistoryResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Epoch
        /// </summary>
        /// <returns>
        /// Epoch number
        /// </returns>
        [Required]
        [JsonPropertyName("epoch")]
        public long Epoch { get; set; }

        /// <summary>
        /// Gets or sets the Blocks
        /// </summary>
        /// <returns>
        /// Number of blocks created by pool
        /// </returns>
        [Required]
        [JsonPropertyName("blocks")]
        public long Blocks { get; set; }

        /// <summary>
        /// Gets or sets the ActiveStake
        /// </summary>
        /// <returns>
        /// Active (Snapshot of live stake 2 epochs ago) stake in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("active_stake")]
        public string ActiveStake { get; set; }

        /// <summary>
        /// Gets or sets the ActiveSize
        /// </summary>
        /// <returns>
        /// Pool size (percentage) of overall active stake at that epoch
        /// </returns>
        [Required]
        [JsonPropertyName("active_size")]
        public double ActiveSize { get; set; }

        /// <summary>
        /// Gets or sets the DelegatorsCount
        /// </summary>
        /// <returns>
        /// Number of delegators for epoch
        /// </returns>
        [Required]
        [JsonPropertyName("delegators_count")]
        public long DelegatorsCount { get; set; }

        /// <summary>
        /// Gets or sets the Rewards
        /// </summary>
        /// <returns>
        /// Total rewards received before distribution to delegators
        /// </returns>
        [Required]
        [JsonPropertyName("rewards")]
        public string Rewards { get; set; }

        /// <summary>
        /// Gets or sets the Fees
        /// </summary>
        /// <returns>
        /// Pool operator rewards
        /// </returns>
        [Required]
        [JsonPropertyName("fees")]
        public string Fees { get; set; }

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
        /// Returns true if PoolHistoryResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PoolHistoryResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PoolHistoryResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Epoch == other.Epoch && Blocks == other.Blocks && ActiveStake == other.ActiveStake && ActiveSize == other.ActiveSize && DelegatorsCount == other.DelegatorsCount && Rewards == other.Rewards && Fees == other.Fees));
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
                   || (obj.GetType() != GetType() && Equals((PoolHistoryResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Epoch);
            hashCode.Add(Blocks);
            hashCode.Add(ActiveStake);
            hashCode.Add(ActiveSize);
            hashCode.Add(DelegatorsCount);
            hashCode.Add(Rewards);
            hashCode.Add(Fees);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PoolHistoryResponse left, PoolHistoryResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PoolHistoryResponse left, PoolHistoryResponse right)
        {
            return !Equals(left, right);
        }
    }
}

