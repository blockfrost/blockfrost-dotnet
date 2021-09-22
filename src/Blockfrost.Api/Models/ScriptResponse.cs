using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="ScriptResponse"/>
    /// </summary>
    public partial class ScriptResponse : IEquatable<ScriptResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptResponse" /> class.
        /// </summary>
        public ScriptResponse()
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
        /// Gets or sets the Type
        /// </summary>
        /// <returns>
        /// Type of the script language
        /// </returns>
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the SerialisedSize
        /// </summary>
        /// <returns>
        /// The size of the CBOR serialised script, if a Plutus script
        /// </returns>
        [Required]
        [JsonPropertyName("serialised_size")]
        public long SerialisedSize { get; set; }

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
        /// Returns true if ScriptResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ScriptResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScriptResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (ScriptHash == other.ScriptHash && Type == other.Type && SerialisedSize == other.SerialisedSize));
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
                   || (obj.GetType() != GetType() && Equals((ScriptResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(ScriptHash);
            hashCode.Add(Type);
            hashCode.Add(SerialisedSize);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(ScriptResponse left, ScriptResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScriptResponse left, ScriptResponse right)
        {
            return !Equals(left, right);
        }
    }
}

