using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// A collection of <see cref="AccountAddressesAssetsItem"/>
    /// </summary>
    public partial class AccountAddressesAssetsCollection : Collection<AccountAddressesAssetsItem>
    {
    }
    /// <summary>
    /// The sum of all assets of all addresses associated with a given account
    /// </summary>
    public partial class AccountAddressesAssetsItem : IEquatable<AccountAddressesAssetsItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAddressesAssetsItem" /> class.
        /// </summary>
        public AccountAddressesAssetsItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAddressesAssetsItem" /> class.
        /// </summary>
        /// <param name="unit"> (required).</param>
        /// <param name="quantity"> (required).</param>
        public AccountAddressesAssetsItem(string unit = default, string quantity = default)
        {
            Unit = unit ?? throw new InvalidDataException($"{nameof(unit)} is a required property for  and cannot be null");
            Quantity = quantity ?? throw new InvalidDataException($"{nameof(quantity)} is a required property for  and cannot be null");
        }
        /// <summary>
        /// Gets or sets the Unit
        /// </summary>
        /// <remarks>Concatenation of asset policy_id and hex-encoded asset_name</remarks>
        /// <returns>The unit of the value</returns>
        [Required]
        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        /// <returns>The quantity of the unit</returns>
        [Required]
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return ToJson();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson(JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as AccountAddressesAssetsItem);
        }

        /// <summary>
        /// Returns true if AccountAddressesAssetsItem instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountAddressesAssetsItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountAddressesAssetsItem other)
        {
            return other != null &&
                (
                    Unit == other.Unit ||
                    (Unit != null &&
                    other.Unit != null &&
                    Unit.SequenceEqual(other.Unit))
                ) &&
                (
                    Quantity == other.Quantity ||
                    (Quantity != null &&
                    other.Quantity != null &&
                    Quantity.SequenceEqual(other.Quantity))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;

                if (Unit != null)
                {
                    hashCode = (hashCode * 59) + Unit.GetHashCode();
                }

                if (Quantity != null)
                {
                    hashCode = (hashCode * 59) + Quantity.GetHashCode();
                }

                return hashCode;
            }
        }
    }

}