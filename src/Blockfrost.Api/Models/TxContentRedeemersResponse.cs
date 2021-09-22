using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentRedeemersResponse"/>
    /// </summary>
    public partial class TxContentRedeemersResponse : IEquatable<TxContentRedeemersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentRedeemersResponse" /> class.
        /// </summary>
        public TxContentRedeemersResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TxIndex
        /// </summary>
        /// <returns>
        /// Index of the redeemer within the transaction
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
        /// Returns true if TxContentRedeemersResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentRedeemersResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentRedeemersResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxIndex == other.TxIndex && Purpose == other.Purpose && UnitMem == other.UnitMem && UnitSteps == other.UnitSteps && Fee == other.Fee));
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
                   || (obj.GetType() != GetType() && Equals((TxContentRedeemersResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxIndex);
            hashCode.Add(Purpose);
            hashCode.Add(UnitMem);
            hashCode.Add(UnitSteps);
            hashCode.Add(Fee);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentRedeemersResponse left, TxContentRedeemersResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentRedeemersResponse left, TxContentRedeemersResponse right)
        {
            return !Equals(left, right);
        }
    }
}

