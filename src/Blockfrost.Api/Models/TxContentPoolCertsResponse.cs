using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentPoolCertsResponse"/>
    /// </summary>
    public partial class TxContentPoolCertsResponse : IEquatable<TxContentPoolCertsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentPoolCertsResponse" /> class.
        /// </summary>
        public TxContentPoolCertsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the CertIndex
        /// </summary>
        /// <returns>
        /// Index of the certificate within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("cert_index")]
        public long CertIndex { get; set; }

        /// <summary>
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 encoded pool ID
        /// </returns>
        [Required]
        [JsonPropertyName("pool_id")]
        public string PoolId { get; set; }

        /// <summary>
        /// Gets or sets the VrfKey
        /// </summary>
        /// <returns>
        /// VRF key hash
        /// </returns>
        [Required]
        [JsonPropertyName("vrf_key")]
        public string VrfKey { get; set; }

        /// <summary>
        /// Gets or sets the Pledge
        /// </summary>
        /// <returns>
        /// Stake pool certificate pledge in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("pledge")]
        public string Pledge { get; set; }

        /// <summary>
        /// Gets or sets the MarginCost
        /// </summary>
        /// <returns>
        /// Margin tax cost of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("margin_cost")]
        public double MarginCost { get; set; }

        /// <summary>
        /// Gets or sets the FixedCost
        /// </summary>
        /// <returns>
        /// Fixed tax cost of the stake pool in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("fixed_cost")]
        public string FixedCost { get; set; }

        /// <summary>
        /// Gets or sets the RewardAccount
        /// </summary>
        /// <returns>
        /// Bech32 reward account of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("reward_account")]
        public string RewardAccount { get; set; }

        /// <summary>
        /// Gets or sets the Owners
        /// </summary>
        /// <returns>
        /// The Owners
        /// </returns>
        [Required]
        [JsonPropertyName("owners")]
        public object Owners { get; set; }

        /// <summary>
        /// Gets or sets the Metadata
        /// </summary>
        /// <returns>
        /// The Metadata
        /// </returns>
        [Required]
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }

        /// <summary>
        /// Gets or sets the Relays
        /// </summary>
        /// <returns>
        /// The Relays
        /// </returns>
        [Required]
        [JsonPropertyName("relays")]
        public object Relays { get; set; }

        /// <summary>
        /// Gets or sets the ActiveEpoch
        /// </summary>
        /// <returns>
        /// Epoch that the delegation becomes active
        /// </returns>
        [Required]
        [JsonPropertyName("active_epoch")]
        public long ActiveEpoch { get; set; }

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
        /// Returns true if TxContentPoolCertsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentPoolCertsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentPoolCertsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (CertIndex == other.CertIndex && PoolId == other.PoolId && VrfKey == other.VrfKey && Pledge == other.Pledge && MarginCost == other.MarginCost && FixedCost == other.FixedCost && RewardAccount == other.RewardAccount && Equals(Owners,other.Owners) && Equals(Metadata,other.Metadata) && Equals(Relays,other.Relays) && ActiveEpoch == other.ActiveEpoch));
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
                   || (obj.GetType() != GetType() && Equals((TxContentPoolCertsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(CertIndex);
            hashCode.Add(PoolId);
            hashCode.Add(VrfKey);
            hashCode.Add(Pledge);
            hashCode.Add(MarginCost);
            hashCode.Add(FixedCost);
            hashCode.Add(RewardAccount);
            hashCode.Add(Owners);
            hashCode.Add(Metadata);
            hashCode.Add(Relays);
            hashCode.Add(ActiveEpoch);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentPoolCertsResponse left, TxContentPoolCertsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentPoolCertsResponse left, TxContentPoolCertsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

