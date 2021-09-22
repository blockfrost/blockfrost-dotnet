using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentStakeAddrResponse"/>
    /// </summary>
    public partial class TxContentStakeAddrResponse : IEquatable<TxContentStakeAddrResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentStakeAddrResponse" /> class.
        /// </summary>
        public TxContentStakeAddrResponse()
        {
        }

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
        /// Delegation stake address
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Registration
        /// </summary>
        /// <returns>
        /// Registration boolean, false if deregistration
        /// </returns>
        [Required]
        [JsonPropertyName("registration")]
        public bool Registration { get; set; }

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
        /// Returns true if TxContentStakeAddrResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentStakeAddrResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentStakeAddrResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (CertIndex == other.CertIndex && Address == other.Address && Registration == other.Registration));
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
                   || (obj.GetType() != GetType() && Equals((TxContentStakeAddrResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(CertIndex);
            hashCode.Add(Address);
            hashCode.Add(Registration);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentStakeAddrResponse left, TxContentStakeAddrResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentStakeAddrResponse left, TxContentStakeAddrResponse right)
        {
            return !Equals(left, right);
        }
    }
}

