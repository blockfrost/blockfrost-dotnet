using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="NutlinkAddressResponse"/>
    /// </summary>
    public partial class NutlinkAddressResponse : IEquatable<NutlinkAddressResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NutlinkAddressResponse" /> class.
        /// </summary>
        public NutlinkAddressResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Bech32 encoded address
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the MetadataUrl
        /// </summary>
        /// <returns>
        /// URL of the specific metadata file
        /// </returns>
        [Required]
        [JsonPropertyName("metadata_url")]
        public string MetadataUrl { get; set; }

        /// <summary>
        /// Gets or sets the MetadataHash
        /// </summary>
        /// <returns>
        /// Hash of the metadata file
        /// </returns>
        [Required]
        [JsonPropertyName("metadata_hash")]
        public string MetadataHash { get; set; }

        /// <summary>
        /// Gets or sets the Metadata
        /// </summary>
        /// <returns>
        /// The cached metadata of the `metadata_url` file.
        /// </returns>
        [Required]
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }

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
        /// Returns true if NutlinkAddressResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of NutlinkAddressResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NutlinkAddressResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && MetadataUrl == other.MetadataUrl && MetadataHash == other.MetadataHash && Equals(Metadata,other.Metadata)));
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
                   || (obj.GetType() != GetType() && Equals((NutlinkAddressResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(MetadataUrl);
            hashCode.Add(MetadataHash);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(NutlinkAddressResponse left, NutlinkAddressResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NutlinkAddressResponse left, NutlinkAddressResponse right)
        {
            return !Equals(left, right);
        }
    }
}

