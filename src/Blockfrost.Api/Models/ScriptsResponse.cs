using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="ScriptsResponse"/>
    /// </summary>
    public partial class ScriptsResponse : IEquatable<ScriptsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptsResponse" /> class.
        /// </summary>
        public ScriptsResponse()
        {
        }

        /// <summary>
        /// Gets or sets the ScriptHash
        /// </summary>
        /// <returns>
        /// Script hash
        /// </returns>
        [Required]
        [JsonPropertyName("script_hash")]
        public string ScriptHash { get; set; }

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
        /// Returns true if ScriptsResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ScriptsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScriptsResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (ScriptHash == other.ScriptHash));
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
                   || (obj.GetType() != GetType() && Equals((ScriptsResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(ScriptHash);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(ScriptsResponse left, ScriptsResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScriptsResponse left, ScriptsResponse right)
        {
            return !Equals(left, right);
        }
    }
}

