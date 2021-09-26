using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="EpochStakePoolContentResponse"/>
    /// </summary>
    public partial class EpochStakePoolContentResponse : IEquatable<EpochStakePoolContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpochStakePoolContentResponse" /> class.
        /// </summary>
        public EpochStakePoolContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the StakeAddress
        /// </summary>
        /// <returns>
        /// Stake address
        /// </returns>
        [Required]
        [JsonPropertyName("stake_address")]
        public string StakeAddress { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// Amount of active delegated stake in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

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
        /// Returns true if EpochStakePoolContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of EpochStakePoolContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EpochStakePoolContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (StakeAddress == other.StakeAddress && Amount == other.Amount));
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
                   || (obj.GetType() != GetType() && Equals((EpochStakePoolContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(StakeAddress);
            hashCode.Add(Amount);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(EpochStakePoolContentResponse left, EpochStakePoolContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EpochStakePoolContentResponse left, EpochStakePoolContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

