using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="NutlinkTickersTickerResponse"/>
    /// </summary>
    public partial class NutlinkTickersTickerResponse : IEquatable<NutlinkTickersTickerResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NutlinkTickersTickerResponse" /> class.
        /// </summary>
        public NutlinkTickersTickerResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        /// <returns>
        /// Address of a metadata oracle
        /// </returns>
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

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
        /// Gets or sets the BlockHeight
        /// </summary>
        /// <returns>
        /// Block height of the record
        /// </returns>
        [Required]
        [JsonPropertyName("block_height")]
        public long BlockHeight { get; set; }

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
        /// Gets or sets the Payload
        /// </summary>
        /// <returns>
        /// Content of the ticker
        /// </returns>
        [Required]
        [JsonPropertyName("payload")]
        public object Payload { get; set; }

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
        /// Returns true if NutlinkTickersTickerResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of NutlinkTickersTickerResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NutlinkTickersTickerResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Address == other.Address && TxHash == other.TxHash && BlockHeight == other.BlockHeight && TxIndex == other.TxIndex && Equals(Payload,other.Payload)));
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
                   || (obj.GetType() != GetType() && Equals((NutlinkTickersTickerResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Address);
            hashCode.Add(TxHash);
            hashCode.Add(BlockHeight);
            hashCode.Add(TxIndex);
            hashCode.Add(Payload);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(NutlinkTickersTickerResponse left, NutlinkTickersTickerResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NutlinkTickersTickerResponse left, NutlinkTickersTickerResponse right)
        {
            return !Equals(left, right);
        }
    }
}

