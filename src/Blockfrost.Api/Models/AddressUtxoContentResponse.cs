using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AddressUtxoContentResponse"/>
    /// </summary>
    public partial class AddressUtxoContentResponse : IEquatable<AddressUtxoContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressUtxoContentResponse" /> class.
        /// </summary>
        public AddressUtxoContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TxHash
        /// </summary>
        /// <returns>
        /// Transaction hash of the UTXO
        /// </returns>
        [Required]
        [JsonPropertyName("tx_hash")]
        public string TxHash { get; set; }

        /// <summary>
        /// Gets or sets the TxIndex
        /// </summary>
        /// <returns>
        /// UTXO index in the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("tx_index")]
        public long TxIndex { get; set; }

        /// <summary>
        /// Gets or sets the OutputIndex
        /// </summary>
        /// <returns>
        /// UTXO index in the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("output_index")]
        public long OutputIndex { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        /// <returns>
        /// The Amount
        /// </returns>
        [Required]
        [JsonPropertyName("amount")]
        public object Amount { get; set; }

        /// <summary>
        /// Gets or sets the Block
        /// </summary>
        /// <returns>
        /// Block hash of the UTXO
        /// </returns>
        [Required]
        [JsonPropertyName("block")]
        public string Block { get; set; }

        /// <summary>
        /// Gets or sets the DataHash
        /// </summary>
        /// <returns>
        /// The hash of the transaction output datum
        /// </returns>
        [Required]
        [JsonPropertyName("data_hash")]
        public string DataHash { get; set; }

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
        /// Returns true if AddressUtxoContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AddressUtxoContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressUtxoContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && TxIndex == other.TxIndex && OutputIndex == other.OutputIndex && Equals(Amount,other.Amount) && Block == other.Block && DataHash == other.DataHash));
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
                   || (obj.GetType() != GetType() && Equals((AddressUtxoContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(TxIndex);
            hashCode.Add(OutputIndex);
            hashCode.Add(Amount);
            hashCode.Add(Block);
            hashCode.Add(DataHash);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AddressUtxoContentResponse left, AddressUtxoContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressUtxoContentResponse left, AddressUtxoContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

