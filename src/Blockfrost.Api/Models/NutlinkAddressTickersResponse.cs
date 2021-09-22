using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="NutlinkAddressTickersResponse"/>
    /// </summary>
    public partial class NutlinkAddressTickersResponse : IEquatable<NutlinkAddressTickersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NutlinkAddressTickersResponse" /> class.
        /// </summary>
        public NutlinkAddressTickersResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        /// <returns>
        /// Name of the ticker
        /// </returns>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Count
        /// </summary>
        /// <returns>
        /// Number of ticker records
        /// </returns>
        [Required]
        [JsonPropertyName("count")]
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets the LatestBlock
        /// </summary>
        /// <returns>
        /// Block height of the latest record
        /// </returns>
        [Required]
        [JsonPropertyName("latest_block")]
        public long LatestBlock { get; set; }

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
        /// Returns true if NutlinkAddressTickersResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of NutlinkAddressTickersResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NutlinkAddressTickersResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Name == other.Name && Count == other.Count && LatestBlock == other.LatestBlock));
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
                   || (obj.GetType() != GetType() && Equals((NutlinkAddressTickersResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Name);
            hashCode.Add(Count);
            hashCode.Add(LatestBlock);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(NutlinkAddressTickersResponse left, NutlinkAddressTickersResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NutlinkAddressTickersResponse left, NutlinkAddressTickersResponse right)
        {
            return !Equals(left, right);
        }
    }
}

