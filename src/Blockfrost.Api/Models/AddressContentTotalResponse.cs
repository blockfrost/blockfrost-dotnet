using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AddressContentTotalResponse"/>
    /// </summary>
    public partial class AddressContentTotalResponse : IEquatable<AddressContentTotalResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressContentTotalResponse" /> class.
        /// </summary>
        public AddressContentTotalResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Bech32 encoded address
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the ReceivedSum
        /// </summary>
        /// <returns>
        /// The ReceivedSum
        /// </returns>
        [Required]
        [JsonPropertyName("received_sum")]
        public object ReceivedSum { get; set; }

        /// <summary>
        /// Gets or sets the SentSum
        /// </summary>
        /// <returns>
        /// The SentSum
        /// </returns>
        [Required]
        [JsonPropertyName("sent_sum")]
        public object SentSum { get; set; }

        /// <summary>
        /// Gets or sets the TxCount
        /// </summary>
        /// <returns>
        /// Count of all transactions on the address
        /// </returns>
        [Required]
        [JsonPropertyName("tx_count")]
        public long TxCount { get; set; }

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
        /// Returns true if AddressContentTotalResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AddressContentTotalResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressContentTotalResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && Equals(ReceivedSum,other.ReceivedSum) && Equals(SentSum,other.SentSum) && TxCount == other.TxCount));
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
                   || (obj.GetType() != GetType() && Equals((AddressContentTotalResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(ReceivedSum);
            hashCode.Add(SentSum);
            hashCode.Add(TxCount);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AddressContentTotalResponse left, AddressContentTotalResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressContentTotalResponse left, AddressContentTotalResponse right)
        {
            return !Equals(left, right);
        }
    }
}

