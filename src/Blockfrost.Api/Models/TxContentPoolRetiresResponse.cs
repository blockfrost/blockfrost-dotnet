using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentPoolRetiresResponse"/>
    /// </summary>
    public partial class TxContentPoolRetiresResponse : IEquatable<TxContentPoolRetiresResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentPoolRetiresResponse" /> class.
        /// </summary>
        public TxContentPoolRetiresResponse()
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
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 stake pool ID
        /// </returns>
        [Required]
        [JsonPropertyName("pool_id")]
        public string PoolId { get; set; }

        /// <summary>
        /// Gets or sets the RetiringEpoch
        /// </summary>
        /// <returns>
        /// Retiring epoch
        /// </returns>
        [Required]
        [JsonPropertyName("retiring_epoch")]
        public long RetiringEpoch { get; set; }

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
        /// Returns true if TxContentPoolRetiresResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentPoolRetiresResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentPoolRetiresResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (CertIndex == other.CertIndex && PoolId == other.PoolId && RetiringEpoch == other.RetiringEpoch));
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
                   || (obj.GetType() != GetType() && Equals((TxContentPoolRetiresResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(CertIndex);
            hashCode.Add(PoolId);
            hashCode.Add(RetiringEpoch);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentPoolRetiresResponse left, TxContentPoolRetiresResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentPoolRetiresResponse left, TxContentPoolRetiresResponse right)
        {
            return !Equals(left, right);
        }
    }
}

