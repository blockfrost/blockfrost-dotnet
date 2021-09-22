using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="InfoResponse"/>
    /// </summary>
    public partial class InfoResponse : IEquatable<InfoResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoResponse" /> class.
        /// </summary>
        public InfoResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Url
        /// </summary>
        /// <returns>
        /// The Url
        /// </returns>
        [Required]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Version
        /// </summary>
        /// <returns>
        /// The Version
        /// </returns>
        [Required]
        [JsonPropertyName("version")]
        public string Version { get; set; }

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
        /// Returns true if InfoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of InfoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InfoResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Url == other.Url && Version == other.Version));
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
                   || (obj.GetType() != GetType() && Equals((InfoResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Url);
            hashCode.Add(Version);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(InfoResponse left, InfoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InfoResponse left, InfoResponse right)
        {
            return !Equals(left, right);
        }
    }
}

