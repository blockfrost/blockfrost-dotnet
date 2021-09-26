using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxMetadataLabelsResponse"/>
    /// </summary>
    public partial class TxMetadataLabelsResponse : IEquatable<TxMetadataLabelsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxMetadataLabelsResponse" /> class.
        /// </summary>
        public TxMetadataLabelsResponse()
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
        /// Gets or sets the Cip10
        /// </summary>
        /// <returns>
        /// CIP10 defined description
        /// </returns>
        [Required]
        [JsonPropertyName("cip10")]
        public string Cip10 { get; set; }

        /// <summary>
        /// Gets or sets the Count
        /// </summary>
        /// <returns>
        /// The count of metadata entries with a specific label
        /// </returns>
        [Required]
        [JsonPropertyName("count")]
        public string Count { get; set; }

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
        /// Returns true if TxMetadataLabelsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxMetadataLabelsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxMetadataLabelsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Label == other.Label && Cip10 == other.Cip10 && Count == other.Count));
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
                   || (obj.GetType() != GetType() && Equals((TxMetadataLabelsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Label);
            hashCode.Add(Cip10);
            hashCode.Add(Count);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxMetadataLabelsResponse left, TxMetadataLabelsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxMetadataLabelsResponse left, TxMetadataLabelsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

