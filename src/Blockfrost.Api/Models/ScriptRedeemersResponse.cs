using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="ScriptRedeemersResponse"/>
    /// </summary>
    public partial class ScriptRedeemersResponse : IEquatable<ScriptRedeemersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptRedeemersResponse" /> class.
        /// </summary>
        public ScriptRedeemersResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TxHash
        /// </summary>
        /// <returns>
        /// Hash of the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("tx_hash")]
        public string TxHash { get; set; }

        /// <summary>
        /// Gets or sets the TxIndex
        /// </summary>
        /// <returns>
        /// The index of the redeemer pointer in the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("tx_index")]
        public long TxIndex { get; set; }

        /// <summary>
        /// Gets or sets the Purpose
        /// </summary>
        /// <returns>
        /// Validation purpose
        /// </returns>
        [Required]
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// Gets or sets the UnitMem
        /// </summary>
        /// <returns>
        /// The budget in Memory to run a script
        /// </returns>
        [Required]
        [JsonPropertyName("unit_mem")]
        public string UnitMem { get; set; }

        /// <summary>
        /// Gets or sets the UnitSteps
        /// </summary>
        /// <returns>
        /// The budget in CPU steps to run a script
        /// </returns>
        [Required]
        [JsonPropertyName("unit_steps")]
        public string UnitSteps { get; set; }

        /// <summary>
        /// Gets or sets the Fee
        /// </summary>
        /// <returns>
        /// The fee consumed to run the script
        /// </returns>
        [Required]
        [JsonPropertyName("fee")]
        public string Fee { get; set; }

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
        /// Returns true if ScriptRedeemersResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ScriptRedeemersResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScriptRedeemersResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && TxIndex == other.TxIndex && Purpose == other.Purpose && UnitMem == other.UnitMem && UnitSteps == other.UnitSteps && Fee == other.Fee));
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
                   || (obj.GetType() != GetType() && Equals((ScriptRedeemersResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(TxIndex);
            hashCode.Add(Purpose);
            hashCode.Add(UnitMem);
            hashCode.Add(UnitSteps);
            hashCode.Add(Fee);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(ScriptRedeemersResponse left, ScriptRedeemersResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScriptRedeemersResponse left, ScriptRedeemersResponse right)
        {
            return !Equals(left, right);
        }
    }
}

