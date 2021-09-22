using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentDelegationsResponse"/>
    /// </summary>
    public partial class TxContentDelegationsResponse : IEquatable<TxContentDelegationsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentDelegationsResponse" /> class.
        /// </summary>
        public TxContentDelegationsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Index
        /// </summary>
        /// <returns>
        /// Index of the certificate within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("index")]
        public long Index { get; set; }

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
        /// Bech32 delegation stake address
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 ID of delegated stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("pool_id")]
        public string PoolId { get; set; }

        /// <summary>
        /// Gets or sets the ActiveEpoch
        /// </summary>
        /// <returns>
        /// Epoch in which the delegation becomes active
        /// </returns>
        [Required]
        [JsonPropertyName("active_epoch")]
        public long ActiveEpoch { get; set; }

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
        /// Returns true if TxContentDelegationsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentDelegationsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentDelegationsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Index == other.Index && CertIndex == other.CertIndex && Address == other.Address && PoolId == other.PoolId && ActiveEpoch == other.ActiveEpoch));
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
                   || (obj.GetType() != GetType() && Equals((TxContentDelegationsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Index);
            hashCode.Add(CertIndex);
            hashCode.Add(Address);
            hashCode.Add(PoolId);
            hashCode.Add(ActiveEpoch);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentDelegationsResponse left, TxContentDelegationsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentDelegationsResponse left, TxContentDelegationsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

