using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AssetPolicyResponse"/>
    /// </summary>
    public partial class AssetPolicyResponse : IEquatable<AssetPolicyResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetPolicyResponse" /> class.
        /// </summary>
        public AssetPolicyResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Asset
        /// </summary>
        /// <returns>
        /// Concatenation of the policy_id and hex-encoded asset_name
        /// </returns>
        [Required]
        [JsonPropertyName("asset")]
        public string Asset { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        /// <returns>
        /// Current asset quantity
        /// </returns>
        [Required]
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

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
        /// Returns true if AssetPolicyResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetPolicyResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetPolicyResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Asset == other.Asset && Quantity == other.Quantity));
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
                   || (obj.GetType() != GetType() && Equals((AssetPolicyResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Asset);
            hashCode.Add(Quantity);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AssetPolicyResponse left, AssetPolicyResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetPolicyResponse left, AssetPolicyResponse right)
        {
            return !Equals(left, right);
        }
    }
}

