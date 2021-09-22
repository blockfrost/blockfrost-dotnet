using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PoolMetadataResponse"/>
    /// </summary>
    public partial class PoolMetadataResponse : IEquatable<PoolMetadataResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolMetadataResponse" /> class.
        /// </summary>
        public PoolMetadataResponse()
        {
        }

        /// <summary>
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 pool ID
        /// </returns>
        [Required]
        [JsonPropertyName("pool_id")]
        public string PoolId { get; set; }

        /// <summary>
        /// Gets or sets the Hex
        /// </summary>
        /// <returns>
        /// Hexadecimal pool ID
        /// </returns>
        [Required]
        [JsonPropertyName("hex")]
        public string Hex { get; set; }

        /// <summary>
        /// Gets or sets the Url
        /// </summary>
        /// <returns>
        /// URL to the stake pool metadata
        /// </returns>
        [Required]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Hash
        /// </summary>
        /// <returns>
        /// Hash of the metadata file
        /// </returns>
        [Required]
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Gets or sets the Ticker
        /// </summary>
        /// <returns>
        /// Ticker of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        /// <returns>
        /// Name of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        /// <returns>
        /// Description of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Homepage
        /// </summary>
        /// <returns>
        /// Home page of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

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
        /// Returns true if PoolMetadataResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PoolMetadataResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PoolMetadataResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (PoolId == other.PoolId && Hex == other.Hex && Url == other.Url && Hash == other.Hash && Ticker == other.Ticker && Name == other.Name && Description == other.Description && Homepage == other.Homepage));
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
                   || (obj.GetType() != GetType() && Equals((PoolMetadataResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(PoolId);
            hashCode.Add(Hex);
            hashCode.Add(Url);
            hashCode.Add(Hash);
            hashCode.Add(Ticker);
            hashCode.Add(Name);
            hashCode.Add(Description);
            hashCode.Add(Homepage);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PoolMetadataResponse left, PoolMetadataResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PoolMetadataResponse left, PoolMetadataResponse right)
        {
            return !Equals(left, right);
        }
    }
}

