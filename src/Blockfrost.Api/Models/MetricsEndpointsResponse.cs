using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="MetricsEndpointsResponse"/>
    /// </summary>
    public partial class MetricsEndpointsResponse : IEquatable<MetricsEndpointsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsEndpointsResponse" /> class.
        /// </summary>
        public MetricsEndpointsResponse()
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
        /// Sum of all calls for a particular day and endpoint
        /// </returns>
        [Required]
        [JsonPropertyName("calls")]
        public long Calls { get; set; }

        /// <summary>
        /// Gets or sets the Endpoint
        /// </summary>
        /// <returns>
        /// Endpoint parent name
        /// </returns>
        [Required]
        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; }

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
        /// Returns true if MetricsEndpointsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of MetricsEndpointsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetricsEndpointsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Time == other.Time && Calls == other.Calls && Endpoint == other.Endpoint));
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
                   || (obj.GetType() != GetType() && Equals((MetricsEndpointsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Time);
            hashCode.Add(Calls);
            hashCode.Add(Endpoint);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(MetricsEndpointsResponse left, MetricsEndpointsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MetricsEndpointsResponse left, MetricsEndpointsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

