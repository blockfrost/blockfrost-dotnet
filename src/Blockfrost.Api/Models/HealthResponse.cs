using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="HealthResponse"/>
    /// </summary>
    public partial class HealthResponse : IEquatable<HealthResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthResponse" /> class.
        /// </summary>
        public HealthResponse()
        {
        }

        /// <summary>
        /// Gets or sets the IsHealthy
        /// </summary>
        /// <returns>
        /// The IsHealthy
        /// </returns>
        [Required]
        [JsonPropertyName("is_healthy")]
        public bool IsHealthy { get; set; }

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
        /// Returns true if HealthResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of HealthResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HealthResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (IsHealthy == other.IsHealthy));
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
                   || (obj.GetType() != GetType() && Equals((HealthResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(IsHealthy);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(HealthResponse left, HealthResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HealthResponse left, HealthResponse right)
        {
            return !Equals(left, right);
        }
    }
}

