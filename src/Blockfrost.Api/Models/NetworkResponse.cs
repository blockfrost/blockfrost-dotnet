using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="NetworkResponse"/>
    /// </summary>
    public partial class NetworkResponse : IEquatable<NetworkResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkResponse" /> class.
        /// </summary>
        public NetworkResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Supply
        /// </summary>
        /// <returns>
        /// The Supply
        /// </returns>
        [Required]
        [JsonPropertyName("supply")]
        public object Supply { get; set; }

        /// <summary>
        /// Gets or sets the Stake
        /// </summary>
        /// <returns>
        /// The Stake
        /// </returns>
        [Required]
        [JsonPropertyName("stake")]
        public object Stake { get; set; }

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
        /// Returns true if NetworkResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of NetworkResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NetworkResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Equals(Supply,other.Supply) && Equals(Stake,other.Stake)));
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
                   || (obj.GetType() != GetType() && Equals((NetworkResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Supply);
            hashCode.Add(Stake);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(NetworkResponse left, NetworkResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NetworkResponse left, NetworkResponse right)
        {
            return !Equals(left, right);
        }
    }
}

