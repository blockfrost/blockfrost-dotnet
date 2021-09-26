using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AccountAddressesContentResponse"/>
    /// </summary>
    public partial class AccountAddressesContentResponse : IEquatable<AccountAddressesContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAddressesContentResponse" /> class.
        /// </summary>
        public AccountAddressesContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Address associated with the stake key
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

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
        /// Returns true if AccountAddressesContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountAddressesContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountAddressesContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address));
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
                   || (obj.GetType() != GetType() && Equals((AccountAddressesContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AccountAddressesContentResponse left, AccountAddressesContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountAddressesContentResponse left, AccountAddressesContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

