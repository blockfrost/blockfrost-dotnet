using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="BlockContentResponse"/>
    /// </summary>
    public partial class BlockContentResponse : IEquatable<BlockContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockContentResponse" /> class.
        /// </summary>
        public BlockContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Time
        /// </summary>
        /// <returns>
        /// Block creation time in UNIX time
        /// </returns>
        [Required]
        [JsonPropertyName("time")]
        public long Time { get; set; }

        /// <summary>
        /// Gets or sets the Height
        /// </summary>
        /// <returns>
        /// Block number
        /// </returns>
        [Required]
        [JsonPropertyName("height")]
        public long Height { get; set; }

        /// <summary>
        /// Gets or sets the Hash
        /// </summary>
        /// <returns>
        /// Hash of the block
        /// </returns>
        [Required]
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Gets or sets the Slot
        /// </summary>
        /// <returns>
        /// Slot number
        /// </returns>
        [Required]
        [JsonPropertyName("slot")]
        public long Slot { get; set; }

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
        /// Gets or sets the EpochSlot
        /// </summary>
        /// <returns>
        /// Slot within the epoch
        /// </returns>
        [Required]
        [JsonPropertyName("epoch_slot")]
        public long EpochSlot { get; set; }

        /// <summary>
        /// Gets or sets the SlotLeader
        /// </summary>
        /// <returns>
        /// Bech32 ID of the slot leader or specific block description in case there is no slot leader
        /// </returns>
        [Required]
        [JsonPropertyName("slot_leader")]
        public string SlotLeader { get; set; }

        /// <summary>
        /// Gets or sets the Size
        /// </summary>
        /// <returns>
        /// Block size in Bytes
        /// </returns>
        [Required]
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets the TxCount
        /// </summary>
        /// <returns>
        /// Number of transactions in the block
        /// </returns>
        [Required]
        [JsonPropertyName("tx_count")]
        public long TxCount { get; set; }

        /// <summary>
        /// Gets or sets the Output
        /// </summary>
        /// <returns>
        /// Total output within the block in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("output")]
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the Fees
        /// </summary>
        /// <returns>
        /// Total fees within the block in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("fees")]
        public string Fees { get; set; }

        /// <summary>
        /// Gets or sets the BlockVrf
        /// </summary>
        /// <returns>
        /// VRF key of the block
        /// </returns>
        [Required]
        [JsonPropertyName("block_vrf")]
        public string BlockVrf { get; set; }

        /// <summary>
        /// Gets or sets the PreviousBlock
        /// </summary>
        /// <returns>
        /// Hash of the previous block
        /// </returns>
        [Required]
        [JsonPropertyName("previous_block")]
        public string PreviousBlock { get; set; }

        /// <summary>
        /// Gets or sets the NextBlock
        /// </summary>
        /// <returns>
        /// Hash of the next block
        /// </returns>
        [Required]
        [JsonPropertyName("next_block")]
        public string NextBlock { get; set; }

        /// <summary>
        /// Gets or sets the Confirmations
        /// </summary>
        /// <returns>
        /// Number of block confirmations
        /// </returns>
        [Required]
        [JsonPropertyName("confirmations")]
        public long Confirmations { get; set; }

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
        /// Returns true if BlockContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of BlockContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BlockContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Time == other.Time && Height == other.Height && Hash == other.Hash && Slot == other.Slot && Epoch == other.Epoch && EpochSlot == other.EpochSlot && SlotLeader == other.SlotLeader && Size == other.Size && TxCount == other.TxCount && Output == other.Output && Fees == other.Fees && BlockVrf == other.BlockVrf && PreviousBlock == other.PreviousBlock && NextBlock == other.NextBlock && Confirmations == other.Confirmations));
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
                   || (obj.GetType() != GetType() && Equals((BlockContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Time);
            hashCode.Add(Height);
            hashCode.Add(Hash);
            hashCode.Add(Slot);
            hashCode.Add(Epoch);
            hashCode.Add(EpochSlot);
            hashCode.Add(SlotLeader);
            hashCode.Add(Size);
            hashCode.Add(TxCount);
            hashCode.Add(Output);
            hashCode.Add(Fees);
            hashCode.Add(BlockVrf);
            hashCode.Add(PreviousBlock);
            hashCode.Add(NextBlock);
            hashCode.Add(Confirmations);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(BlockContentResponse left, BlockContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BlockContentResponse left, BlockContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

