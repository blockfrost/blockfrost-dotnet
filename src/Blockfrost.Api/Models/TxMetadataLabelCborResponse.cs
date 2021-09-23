using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxMetadataLabelCborResponse"/>
    /// </summary>
    public partial class TxMetadataLabelCborResponse : IEquatable<TxMetadataLabelCborResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxMetadataLabelCborResponse" /> class.
        /// </summary>
        public TxMetadataLabelCborResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TxHash
        /// </summary>
        /// <returns>
        /// Transaction hash that contains the specific metadata
        /// </returns>
        [Required]
        [JsonPropertyName("tx_hash")]
        public string TxHash { get; set; }

        /// <summary>
        /// Gets or sets the CborMetadata
        /// </summary>
        /// <returns>
        /// Content of the CBOR metadata
        /// </returns>
        [Required]
        [JsonPropertyName("cbor_metadata")]
        public string CborMetadata { get; set; }

        /// <summary>
        /// Gets or sets the Metadata
        /// </summary>
        /// <returns>
        /// Content of the CBOR metadata in hex
        /// </returns>
        [Required]
        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

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
        /// Returns true if TxMetadataLabelCborResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxMetadataLabelCborResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxMetadataLabelCborResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && CborMetadata == other.CborMetadata && Metadata == other.Metadata));
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
                   || (obj.GetType() != GetType() && Equals((TxMetadataLabelCborResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(CborMetadata);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxMetadataLabelCborResponse left, TxMetadataLabelCborResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxMetadataLabelCborResponse left, TxMetadataLabelCborResponse right)
        {
            return !Equals(left, right);
        }
    }
}

