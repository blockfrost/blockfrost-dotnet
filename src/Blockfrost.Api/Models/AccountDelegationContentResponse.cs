using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AccountDelegationContentResponse"/>
    /// </summary>
    public partial class AccountDelegationContentResponse : IEquatable<AccountDelegationContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDelegationContentResponse" /> class.
        /// </summary>
        public AccountDelegationContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the ActiveEpoch
        /// </summary>
        /// <returns>
        /// Epoch in which the delegation becomes active
        /// </returns>
        [Required]
        [JsonPropertyName("active_epoch")]
        public long ActiveEpoch { get; set; }

        /// <summary>
        /// Gets or sets the TxHash
        /// </summary>
        /// <returns>
        /// Hash of the transaction containing the delegation
        /// </returns>
        [Required]
        [JsonPropertyName("tx_hash")]
        public string TxHash { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// Rewards for given epoch in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 ID of pool being delegated to
        /// </returns>
        [Required]
        [JsonPropertyName("pool_id")]
        public string PoolId { get; set; }

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
        /// Returns true if AccountDelegationContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountDelegationContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountDelegationContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (ActiveEpoch == other.ActiveEpoch && TxHash == other.TxHash && Amount == other.Amount && PoolId == other.PoolId));
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
                   || (obj.GetType() != GetType() && Equals((AccountDelegationContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(ActiveEpoch);
            hashCode.Add(TxHash);
            hashCode.Add(Amount);
            hashCode.Add(PoolId);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AccountDelegationContentResponse left, AccountDelegationContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountDelegationContentResponse left, AccountDelegationContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

