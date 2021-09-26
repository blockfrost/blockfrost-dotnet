using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AssetAddressesResponse"/>
    /// </summary>
    public partial class AssetAddressesResponse : IEquatable<AssetAddressesResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetAddressesResponse" /> class.
        /// </summary>
        public AssetAddressesResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Address containing the specific asset
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        /// <returns>
        /// Asset quantity on the specific address
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
        /// Returns true if AssetAddressesResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetAddressesResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetAddressesResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && Quantity == other.Quantity));
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
                   || (obj.GetType() != GetType() && Equals((AssetAddressesResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(Quantity);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AssetAddressesResponse left, AssetAddressesResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetAddressesResponse left, AssetAddressesResponse right)
        {
            return !Equals(left, right);
        }
    }
}

