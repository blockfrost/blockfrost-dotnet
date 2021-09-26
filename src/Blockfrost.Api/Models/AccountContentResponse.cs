using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AccountContentResponse"/>
    /// </summary>
    public partial class AccountContentResponse : IEquatable<AccountContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountContentResponse" /> class.
        /// </summary>
        public AccountContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the StakeAddress
        /// </summary>
        /// <returns>
        /// Bech32 stake address
        /// </returns>
        [Required]
        [JsonPropertyName("stake_address")]
        public string StakeAddress { get; set; }

        /// <summary>
        /// Gets or sets the Active
        /// </summary>
        /// <returns>
        /// Registration state of an account
        /// </returns>
        [Required]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the ActiveEpoch
        /// </summary>
        /// <returns>
        /// Epoch of the most recent action - registration or deregistration
        /// </returns>
        [Required]
        [JsonPropertyName("active_epoch")]
        public long ActiveEpoch { get; set; }

        /// <summary>
        /// Gets or sets the ControlledAmount
        /// </summary>
        /// <returns>
        /// Balance of the account in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("controlled_amount")]
        public string ControlledAmount { get; set; }

        /// <summary>
        /// Gets or sets the RewardsSum
        /// </summary>
        /// <returns>
        /// Sum of all rewards for the account in the Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("rewards_sum")]
        public string RewardsSum { get; set; }

        /// <summary>
        /// Gets or sets the WithdrawalsSum
        /// </summary>
        /// <returns>
        /// Sum of all the withdrawals for the account in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("withdrawals_sum")]
        public string WithdrawalsSum { get; set; }

        /// <summary>
        /// Gets or sets the ReservesSum
        /// </summary>
        /// <returns>
        /// Sum of all  funds from reserves for the account in the Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("reserves_sum")]
        public string ReservesSum { get; set; }

        /// <summary>
        /// Gets or sets the TreasurySum
        /// </summary>
        /// <returns>
        /// Sum of all funds from treasury for the account in the Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("treasury_sum")]
        public string TreasurySum { get; set; }

        /// <summary>
        /// Gets or sets the WithdrawableAmount
        /// </summary>
        /// <returns>
        /// Sum of available rewards that haven't been withdrawn yet for the account in the Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("withdrawable_amount")]
        public string WithdrawableAmount { get; set; }

        /// <summary>
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 pool ID that owns the account
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
        /// Returns true if AccountContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (StakeAddress == other.StakeAddress && Active == other.Active && ActiveEpoch == other.ActiveEpoch && ControlledAmount == other.ControlledAmount && RewardsSum == other.RewardsSum && WithdrawalsSum == other.WithdrawalsSum && ReservesSum == other.ReservesSum && TreasurySum == other.TreasurySum && WithdrawableAmount == other.WithdrawableAmount && PoolId == other.PoolId));
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
                   || (obj.GetType() != GetType() && Equals((AccountContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(StakeAddress);
            hashCode.Add(Active);
            hashCode.Add(ActiveEpoch);
            hashCode.Add(ControlledAmount);
            hashCode.Add(RewardsSum);
            hashCode.Add(WithdrawalsSum);
            hashCode.Add(ReservesSum);
            hashCode.Add(TreasurySum);
            hashCode.Add(WithdrawableAmount);
            hashCode.Add(PoolId);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AccountContentResponse left, AccountContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountContentResponse left, AccountContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

