using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PoolListRetireResponse"/>
    /// </summary>
    public partial class PoolListRetireResponse : IEquatable<PoolListRetireResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolListRetireResponse" /> class.
        /// </summary>
        public PoolListRetireResponse()
        {
        }

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
        /// Gets or sets the Epoch
        /// </summary>
        /// <returns>
        /// Retirement epoch number
        /// </returns>
        [Required]
        [JsonPropertyName("epoch")]
        public long Epoch { get; set; }

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
        /// Returns true if PoolListRetireResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PoolListRetireResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PoolListRetireResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (PoolId == other.PoolId && Epoch == other.Epoch));
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
                   || (obj.GetType() != GetType() && Equals((PoolListRetireResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(PoolId);
            hashCode.Add(Epoch);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PoolListRetireResponse left, PoolListRetireResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PoolListRetireResponse left, PoolListRetireResponse right)
        {
            return !Equals(left, right);
        }
    }
}

