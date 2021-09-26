using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="TxContentResponse"/>
    /// </summary>
    public partial class TxContentResponse : IEquatable<TxContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TxContentResponse" /> class.
        /// </summary>
        public TxContentResponse()
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
        /// Gets or sets the Block
        /// </summary>
        /// <returns>
        /// Block hash
        /// </returns>
        [Required]
        [JsonPropertyName("block")]
        public string Block { get; set; }

        /// <summary>
        /// Gets or sets the BlockHeight
        /// </summary>
        /// <returns>
        /// Block number
        /// </returns>
        [Required]
        [JsonPropertyName("block_height")]
        public long BlockHeight { get; set; }

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
        /// Gets or sets the Index
        /// </summary>
        /// <returns>
        /// Transaction index within the block
        /// </returns>
        [Required]
        [JsonPropertyName("index")]
        public long Index { get; set; }

        /// <summary>
        /// Gets or sets the OutputAmount
        /// </summary>
        /// <returns>
        /// The OutputAmount
        /// </returns>
        [Required]
        [JsonPropertyName("output_amount")]
        public object OutputAmount { get; set; }

        /// <summary>
        /// Gets or sets the Fees
        /// </summary>
        /// <returns>
        /// Fees of the transaction in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("fees")]
        public string Fees { get; set; }

        /// <summary>
        /// Gets or sets the Deposit
        /// </summary>
        /// <returns>
        /// Deposit within the transaction in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("deposit")]
        public string Deposit { get; set; }

        /// <summary>
        /// Gets or sets the Size
        /// </summary>
        /// <returns>
        /// Size of the transaction in Bytes
        /// </returns>
        [Required]
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets the InvalidBefore
        /// </summary>
        /// <returns>
        /// Left (included) endpoint of the timelock validity intervals
        /// </returns>
        [Required]
        [JsonPropertyName("invalid_before")]
        public string InvalidBefore { get; set; }

        /// <summary>
        /// Gets or sets the InvalidHereafter
        /// </summary>
        /// <returns>
        /// Right (excluded) endpoint of the timelock validity intervals
        /// </returns>
        [Required]
        [JsonPropertyName("invalid_hereafter")]
        public string InvalidHereafter { get; set; }

        /// <summary>
        /// Gets or sets the UtxoCount
        /// </summary>
        /// <returns>
        /// Count of UTXOs within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("utxo_count")]
        public long UtxoCount { get; set; }

        /// <summary>
        /// Gets or sets the WithdrawalCount
        /// </summary>
        /// <returns>
        /// Count of the withdrawals within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("withdrawal_count")]
        public long WithdrawalCount { get; set; }

        /// <summary>
        /// Gets or sets the MirCertCount
        /// </summary>
        /// <returns>
        /// Count of the MIR certificates within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("mir_cert_count")]
        public long MirCertCount { get; set; }

        /// <summary>
        /// Gets or sets the DelegationCount
        /// </summary>
        /// <returns>
        /// Count of the delegations within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("delegation_count")]
        public long DelegationCount { get; set; }

        /// <summary>
        /// Gets or sets the StakeCertCount
        /// </summary>
        /// <returns>
        /// Count of the stake keys (de)registration and delegation certificates within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("stake_cert_count")]
        public long StakeCertCount { get; set; }

        /// <summary>
        /// Gets or sets the PoolUpdateCount
        /// </summary>
        /// <returns>
        /// Count of the stake pool registration and update certificates within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("pool_update_count")]
        public long PoolUpdateCount { get; set; }

        /// <summary>
        /// Gets or sets the PoolRetireCount
        /// </summary>
        /// <returns>
        /// Count of the stake pool retirement certificates within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("pool_retire_count")]
        public long PoolRetireCount { get; set; }

        /// <summary>
        /// Gets or sets the AssetMintOrBurnCount
        /// </summary>
        /// <returns>
        /// Count of asset mints and burns within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("asset_mint_or_burn_count")]
        public long AssetMintOrBurnCount { get; set; }

        /// <summary>
        /// Gets or sets the RedeemerCount
        /// </summary>
        /// <returns>
        /// Count of redeemers within the transaction
        /// </returns>
        [Required]
        [JsonPropertyName("redeemer_count")]
        public long RedeemerCount { get; set; }

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
        /// Returns true if TxContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TxContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TxContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Hash == other.Hash && Block == other.Block && BlockHeight == other.BlockHeight && Slot == other.Slot && Index == other.Index && Equals(OutputAmount,other.OutputAmount) && Fees == other.Fees && Deposit == other.Deposit && Size == other.Size && InvalidBefore == other.InvalidBefore && InvalidHereafter == other.InvalidHereafter && UtxoCount == other.UtxoCount && WithdrawalCount == other.WithdrawalCount && MirCertCount == other.MirCertCount && DelegationCount == other.DelegationCount && StakeCertCount == other.StakeCertCount && PoolUpdateCount == other.PoolUpdateCount && PoolRetireCount == other.PoolRetireCount && AssetMintOrBurnCount == other.AssetMintOrBurnCount && RedeemerCount == other.RedeemerCount));
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
                   || (obj.GetType() != GetType() && Equals((TxContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Hash);
            hashCode.Add(Block);
            hashCode.Add(BlockHeight);
            hashCode.Add(Slot);
            hashCode.Add(Index);
            hashCode.Add(OutputAmount);
            hashCode.Add(Fees);
            hashCode.Add(Deposit);
            hashCode.Add(Size);
            hashCode.Add(InvalidBefore);
            hashCode.Add(InvalidHereafter);
            hashCode.Add(UtxoCount);
            hashCode.Add(WithdrawalCount);
            hashCode.Add(MirCertCount);
            hashCode.Add(DelegationCount);
            hashCode.Add(StakeCertCount);
            hashCode.Add(PoolUpdateCount);
            hashCode.Add(PoolRetireCount);
            hashCode.Add(AssetMintOrBurnCount);
            hashCode.Add(RedeemerCount);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(TxContentResponse left, TxContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TxContentResponse left, TxContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

