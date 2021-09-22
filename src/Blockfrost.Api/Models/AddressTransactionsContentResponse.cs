using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AddressTransactionsContentResponse"/>
    /// </summary>
    public partial class AddressTransactionsContentResponse : IEquatable<AddressTransactionsContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressTransactionsContentResponse" /> class.
        /// </summary>
        public AddressTransactionsContentResponse()
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
        /// Transaction index within the block
        /// </returns>
        [Required]
        [JsonPropertyName("tx_index")]
        public long TxIndex { get; set; }

        /// <summary>
        /// Gets or sets the BlockHeight
        /// </summary>
        /// <returns>
        /// Block height
        /// </returns>
        [Required]
        [JsonPropertyName("block_height")]
        public long BlockHeight { get; set; }

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
        /// Returns true if AddressTransactionsContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AddressTransactionsContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressTransactionsContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && TxIndex == other.TxIndex && BlockHeight == other.BlockHeight));
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
                   || (obj.GetType() != GetType() && Equals((AddressTransactionsContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(TxIndex);
            hashCode.Add(BlockHeight);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AddressTransactionsContentResponse left, AddressTransactionsContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressTransactionsContentResponse left, AddressTransactionsContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

