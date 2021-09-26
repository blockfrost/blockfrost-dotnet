using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="EpochContentResponse"/>
    /// </summary>
    public partial class EpochContentResponse : IEquatable<EpochContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpochContentResponse" /> class.
        /// </summary>
        public EpochContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Epoch
        /// </summary>
        /// <returns>
        /// Epoch number
        /// </returns>
        [Required]
        [JsonPropertyName("epoch")]
        public long Epoch { get; set; }

        /// <summary>
        /// Gets or sets the StartTime
        /// </summary>
        /// <returns>
        /// Unix time of the start of the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("start_time")]
        public long StartTime { get; set; }

        /// <summary>
        /// Gets or sets the EndTime
        /// </summary>
        /// <returns>
        /// Unix time of the end of the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("end_time")]
        public long EndTime { get; set; }

        /// <summary>
        /// Gets or sets the FirstBlockTime
        /// </summary>
        /// <returns>
        /// Unix time of the first block of the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("first_block_time")]
        public long FirstBlockTime { get; set; }

        /// <summary>
        /// Gets or sets the LastBlockTime
        /// </summary>
        /// <returns>
        /// Unix time of the last block of the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("last_block_time")]
        public long LastBlockTime { get; set; }

        /// <summary>
        /// Gets or sets the BlockCount
        /// </summary>
        /// <returns>
        /// Number of blocks within the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("block_count")]
        public long BlockCount { get; set; }

        /// <summary>
        /// Gets or sets the TxCount
        /// </summary>
        /// <returns>
        /// Number of transactions within the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("tx_count")]
        public long TxCount { get; set; }

        /// <summary>
        /// Gets or sets the Output
        /// </summary>
        /// <returns>
        /// Sum of all the transactions within the epoch in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("output")]
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the Fees
        /// </summary>
        /// <returns>
        /// Sum of all the fees within the epoch in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("fees")]
        public string Fees { get; set; }

        /// <summary>
        /// Gets or sets the ActiveStake
        /// </summary>
        /// <returns>
        /// Sum of all the active stakes within the epoch in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("active_stake")]
        public string ActiveStake { get; set; }

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
        /// Returns true if EpochContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of EpochContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EpochContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Epoch == other.Epoch && StartTime == other.StartTime && EndTime == other.EndTime && FirstBlockTime == other.FirstBlockTime && LastBlockTime == other.LastBlockTime && BlockCount == other.BlockCount && TxCount == other.TxCount && Output == other.Output && Fees == other.Fees && ActiveStake == other.ActiveStake));
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
                   || (obj.GetType() != GetType() && Equals((EpochContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Epoch);
            hashCode.Add(StartTime);
            hashCode.Add(EndTime);
            hashCode.Add(FirstBlockTime);
            hashCode.Add(LastBlockTime);
            hashCode.Add(BlockCount);
            hashCode.Add(TxCount);
            hashCode.Add(Output);
            hashCode.Add(Fees);
            hashCode.Add(ActiveStake);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(EpochContentResponse left, EpochContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EpochContentResponse left, EpochContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

