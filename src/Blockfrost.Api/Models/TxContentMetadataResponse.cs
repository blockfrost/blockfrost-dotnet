using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentMetadataResponse"/>
    /// </summary>
    public partial class TxContentMetadataResponse : IEquatable<TxContentMetadataResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentMetadataResponse" /> class.
        /// </summary>
        public TxContentMetadataResponse()
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
        /// Gets or sets the JsonMetadata
        /// </summary>
        /// <returns>
        /// Content of the metadata
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
        /// Returns true if TxContentMetadataResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentMetadataResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentMetadataResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Label == other.Label && JsonMetadata == other.JsonMetadata));
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
                   || (obj.GetType() != GetType() && Equals((TxContentMetadataResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Label);
            hashCode.Add(JsonMetadata);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentMetadataResponse left, TxContentMetadataResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentMetadataResponse left, TxContentMetadataResponse right)
        {
            return !Equals(left, right);
        }
    }
}

