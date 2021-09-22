using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentMirsResponse"/>
    /// </summary>
    public partial class TxContentMirsResponse : IEquatable<TxContentMirsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentMirsResponse" /> class.
        /// </summary>
        public TxContentMirsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Pot
        /// </summary>
        /// <returns>
        /// Source of MIR funds
        /// </returns>
        [Required]
        [JsonPropertyName("pot")]
        public string Pot { get; set; }

        /// <summary>
        /// Gets or sets the CertIndex
        /// </summary>
        /// <returns>
        /// Index of the certificate within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("cert_index")]
        public long CertIndex { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Bech32 stake address
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// MIR amount in Lovelaces
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
        /// Returns true if TxContentMirsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentMirsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentMirsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Pot == other.Pot && CertIndex == other.CertIndex && Address == other.Address && Amount == other.Amount));
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
                   || (obj.GetType() != GetType() && Equals((TxContentMirsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Pot);
            hashCode.Add(CertIndex);
            hashCode.Add(Address);
            hashCode.Add(Amount);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentMirsResponse left, TxContentMirsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentMirsResponse left, TxContentMirsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

