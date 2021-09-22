using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AccountAddressesAssetsResponse"/>
    /// </summary>
    public partial class AccountAddressesAssetsResponse : IEquatable<AccountAddressesAssetsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAddressesAssetsResponse" /> class.
        /// </summary>
        public AccountAddressesAssetsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Unit
        /// </summary>
        /// <remarks>Concatenation of asset policy_id and hex-encoded asset_name</remarks>
        /// <returns>
        /// The unit of the value
        /// </returns>
        [Required]
        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        /// <returns>
        /// The quantity of the unit
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
        /// Returns true if AccountAddressesAssetsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountAddressesAssetsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountAddressesAssetsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Unit == other.Unit && Quantity == other.Quantity));
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
                   || (obj.GetType() != GetType() && Equals((AccountAddressesAssetsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Unit);
            hashCode.Add(Quantity);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AccountAddressesAssetsResponse left, AccountAddressesAssetsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountAddressesAssetsResponse left, AccountAddressesAssetsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

