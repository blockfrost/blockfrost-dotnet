using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AssetHistoryResponse"/>
    /// </summary>
    public partial class AssetHistoryResponse : IEquatable<AssetHistoryResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetHistoryResponse" /> class.
        /// </summary>
        public AssetHistoryResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TxHash
        /// </summary>
        /// <returns>
        /// Hash of the transaction containing the asset action
        /// </returns>
        [Required]
        [JsonPropertyName("tx_hash")]
        public string TxHash { get; set; }

        /// <summary>
        /// Gets or sets the Action
        /// </summary>
        /// <returns>
        /// Action executed upon the asset policy
        /// </returns>
        [Required]
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// Asset amount of the specific action
        /// </returns>
        [Required]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

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
        /// Returns true if AssetHistoryResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetHistoryResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetHistoryResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && Action == other.Action && Amount == other.Amount));
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
                   || (obj.GetType() != GetType() && Equals((AssetHistoryResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(Action);
            hashCode.Add(Amount);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AssetHistoryResponse left, AssetHistoryResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetHistoryResponse left, AssetHistoryResponse right)
        {
            return !Equals(left, right);
        }
    }
}

