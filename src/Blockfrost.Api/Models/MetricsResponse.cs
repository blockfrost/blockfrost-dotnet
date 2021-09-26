using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="MetricsResponse"/>
    /// </summary>
    public partial class MetricsResponse : IEquatable<MetricsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsResponse" /> class.
        /// </summary>
        public MetricsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Time
        /// </summary>
        /// <returns>
        /// Starting time of the call count interval (ends midnight UTC) in UNIX time
        /// </returns>
        [Required]
        [JsonPropertyName("time")]
        public long Time { get; set; }

        /// <summary>
        /// Gets or sets the Calls
        /// </summary>
        /// <returns>
        /// Sum of all calls for a particular day
        /// </returns>
        [Required]
        [JsonPropertyName("calls")]
        public long Calls { get; set; }

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
        /// Returns true if MetricsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of MetricsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetricsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Time == other.Time && Calls == other.Calls));
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
                   || (obj.GetType() != GetType() && Equals((MetricsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Time);
            hashCode.Add(Calls);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(MetricsResponse left, MetricsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MetricsResponse left, MetricsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

