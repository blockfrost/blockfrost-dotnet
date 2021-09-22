using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="HealthClockResponse"/>
    /// </summary>
    public partial class HealthClockResponse : IEquatable<HealthClockResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthClockResponse" /> class.
        /// </summary>
        public HealthClockResponse()
        {
        }

        /// <summary>
        /// Gets or sets the ServerTime
        /// </summary>
        /// <remarks>int64</remarks>
        /// <returns>
        /// The ServerTime
        /// </returns>
        [Required]
        [JsonPropertyName("server_time")]
        public long ServerTime { get; set; }

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
        /// Returns true if HealthClockResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of HealthClockResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HealthClockResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (ServerTime == other.ServerTime));
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
                   || (obj.GetType() != GetType() && Equals((HealthClockResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(ServerTime);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(HealthClockResponse left, HealthClockResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HealthClockResponse left, HealthClockResponse right)
        {
            return !Equals(left, right);
        }
    }
}

