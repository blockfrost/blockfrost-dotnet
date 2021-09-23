using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentWithdrawalsResponse"/>
    /// </summary>
    public partial class TxContentWithdrawalsResponse : IEquatable<TxContentWithdrawalsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentWithdrawalsResponse" /> class.
        /// </summary>
        public TxContentWithdrawalsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Bech32 withdrawal address
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// Withdrawal amount in Lovelaces
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
        /// Returns true if TxContentWithdrawalsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentWithdrawalsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentWithdrawalsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && Amount == other.Amount));
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
                   || (obj.GetType() != GetType() && Equals((TxContentWithdrawalsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(Amount);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentWithdrawalsResponse left, TxContentWithdrawalsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentWithdrawalsResponse left, TxContentWithdrawalsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

