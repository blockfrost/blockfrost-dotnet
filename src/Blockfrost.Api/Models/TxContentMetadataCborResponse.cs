using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentMetadataCborResponse"/>
    /// </summary>
    public partial class TxContentMetadataCborResponse : IEquatable<TxContentMetadataCborResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentMetadataCborResponse" /> class.
        /// </summary>
        public TxContentMetadataCborResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Label
        /// </summary>
        /// <returns>
        /// Metadata label
        /// </returns>
        [Required]
        [JsonPropertyName("label")]
        public string Label { get; set; }

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
        /// Returns true if TxContentMetadataCborResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentMetadataCborResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentMetadataCborResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Label == other.Label && CborMetadata == other.CborMetadata && Metadata == other.Metadata));
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
                   || (obj.GetType() != GetType() && Equals((TxContentMetadataCborResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Label);
            hashCode.Add(CborMetadata);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentMetadataCborResponse left, TxContentMetadataCborResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentMetadataCborResponse left, TxContentMetadataCborResponse right)
        {
            return !Equals(left, right);
        }
    }
}

