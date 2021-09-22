using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AddressContentResponse"/>
    /// </summary>
    public partial class AddressContentResponse : IEquatable<AddressContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressContentResponse" /> class.
        /// </summary>
        public AddressContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Bech32 encoded addresses
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// The Amount
        /// </returns>
        [Required]
        [JsonPropertyName("amount")]
        public object Amount { get; set; }

        /// <summary>
        /// Gets or sets the StakeAddress
        /// </summary>
        /// <returns>
        /// Stake address that controls the key
        /// </returns>
        [Required]
        [JsonPropertyName("stake_address")]
        public string StakeAddress { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        /// <returns>
        /// Address era
        /// </returns>
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Script
        /// </summary>
        /// <returns>
        /// True if this is a script address
        /// </returns>
        [Required]
        [JsonPropertyName("script")]
        public bool Script { get; set; }

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
        /// Returns true if AddressContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AddressContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && Equals(Amount,other.Amount) && StakeAddress == other.StakeAddress && Type == other.Type && Script == other.Script));
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
                   || (obj.GetType() != GetType() && Equals((AddressContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(Amount);
            hashCode.Add(StakeAddress);
            hashCode.Add(Type);
            hashCode.Add(Script);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AddressContentResponse left, AddressContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressContentResponse left, AddressContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

