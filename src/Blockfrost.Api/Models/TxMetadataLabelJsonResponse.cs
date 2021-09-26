using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxMetadataLabelJsonResponse"/>
    /// </summary>
    public partial class TxMetadataLabelJsonResponse : IEquatable<TxMetadataLabelJsonResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxMetadataLabelJsonResponse" /> class.
        /// </summary>
        public TxMetadataLabelJsonResponse()
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
        /// Gets or sets the JsonMetadata
        /// </summary>
        /// <returns>
        /// Content of the JSON metadata
        /// </returns>
        [Required]
        [JsonPropertyName("json_metadata")]
        public object JsonMetadata { get; set; }

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
        /// Returns true if TxMetadataLabelJsonResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxMetadataLabelJsonResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxMetadataLabelJsonResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && Equals(JsonMetadata,other.JsonMetadata)));
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
                   || (obj.GetType() != GetType() && Equals((TxMetadataLabelJsonResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(JsonMetadata);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxMetadataLabelJsonResponse left, TxMetadataLabelJsonResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxMetadataLabelJsonResponse left, TxMetadataLabelJsonResponse right)
        {
            return !Equals(left, right);
        }
    }
}

