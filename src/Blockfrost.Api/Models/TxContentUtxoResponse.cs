using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentUtxoResponse"/>
    /// </summary>
    public partial class TxContentUtxoResponse : IEquatable<TxContentUtxoResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentUtxoResponse" /> class.
        /// </summary>
        public TxContentUtxoResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Hash
        /// </summary>
        /// <returns>
        /// Transaction hash
        /// </returns>
        [Required]
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Gets or sets the Inputs
        /// </summary>
        /// <returns>
        /// The Inputs
        /// </returns>
        [Required]
        [JsonPropertyName("inputs")]
        public object Inputs { get; set; }

        /// <summary>
        /// Gets or sets the Outputs
        /// </summary>
        /// <returns>
        /// The Outputs
        /// </returns>
        [Required]
        [JsonPropertyName("outputs")]
        public object Outputs { get; set; }

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
        /// Returns true if TxContentUtxoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentUtxoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentUtxoResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Hash == other.Hash && Equals(Inputs,other.Inputs) && Equals(Outputs,other.Outputs)));
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
                   || (obj.GetType() != GetType() && Equals((TxContentUtxoResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Hash);
            hashCode.Add(Inputs);
            hashCode.Add(Outputs);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentUtxoResponse left, TxContentUtxoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentUtxoResponse left, TxContentUtxoResponse right)
        {
            return !Equals(left, right);
        }
    }
}

