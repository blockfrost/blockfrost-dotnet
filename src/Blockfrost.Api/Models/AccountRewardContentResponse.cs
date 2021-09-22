using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AccountRewardContentResponse"/>
    /// </summary>
    public partial class AccountRewardContentResponse : IEquatable<AccountRewardContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRewardContentResponse" /> class.
        /// </summary>
        public AccountRewardContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Epoch
        /// </summary>
        /// <returns>
        /// Epoch of the associated reward
        /// </returns>
        [Required]
        [JsonPropertyName("epoch")]
        public long Epoch { get; set; }

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
        /// Bech32 pool ID being delegated to
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
        /// Returns true if AccountRewardContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountRewardContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountRewardContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Epoch == other.Epoch && Amount == other.Amount && PoolId == other.PoolId));
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
                   || (obj.GetType() != GetType() && Equals((AccountRewardContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Epoch);
            hashCode.Add(Amount);
            hashCode.Add(PoolId);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AccountRewardContentResponse left, AccountRewardContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountRewardContentResponse left, AccountRewardContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

