using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PoolDelegatorsResponse"/>
    /// </summary>
    public partial class PoolDelegatorsResponse : IEquatable<PoolDelegatorsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolDelegatorsResponse" /> class.
        /// </summary>
        public PoolDelegatorsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Bech32 encoded stake addresses
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the LiveStake
        /// </summary>
        /// <returns>
        /// Currently delegated amount
        /// </returns>
        [Required]
        [JsonPropertyName("live_stake")]
        public string LiveStake { get; set; }

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
        /// Returns true if PoolDelegatorsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PoolDelegatorsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PoolDelegatorsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && LiveStake == other.LiveStake));
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
                   || (obj.GetType() != GetType() && Equals((PoolDelegatorsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(LiveStake);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PoolDelegatorsResponse left, PoolDelegatorsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PoolDelegatorsResponse left, PoolDelegatorsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

