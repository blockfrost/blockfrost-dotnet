using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="EpochParamContentResponse"/>
    /// </summary>
    public partial class EpochParamContentResponse : IEquatable<EpochParamContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpochParamContentResponse" /> class.
        /// </summary>
        public EpochParamContentResponse()
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
        /// Gets or sets the MinFeeA
        /// </summary>
        /// <returns>
        /// The linear factor for the minimum fee calculation for given epoch
        /// </returns>
        [Required]
        [JsonPropertyName("min_fee_a")]
        public long MinFeeA { get; set; }

        /// <summary>
        /// Gets or sets the MinFeeB
        /// </summary>
        /// <returns>
        /// The constant factor for the minimum fee calculation
        /// </returns>
        [Required]
        [JsonPropertyName("min_fee_b")]
        public long MinFeeB { get; set; }

        /// <summary>
        /// Gets or sets the MaxBlockSize
        /// </summary>
        /// <returns>
        /// Maximum block body size in Bytes
        /// </returns>
        [Required]
        [JsonPropertyName("max_block_size")]
        public long MaxBlockSize { get; set; }

        /// <summary>
        /// Gets or sets the MaxTxSize
        /// </summary>
        /// <returns>
        /// Maximum transaction size
        /// </returns>
        [Required]
        [JsonPropertyName("max_tx_size")]
        public long MaxTxSize { get; set; }

        /// <summary>
        /// Gets or sets the MaxBlockHeaderSize
        /// </summary>
        /// <returns>
        /// Maximum block header size
        /// </returns>
        [Required]
        [JsonPropertyName("max_block_header_size")]
        public long MaxBlockHeaderSize { get; set; }

        /// <summary>
        /// Gets or sets the KeyDeposit
        /// </summary>
        /// <returns>
        /// The amount of a key registration deposit in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("key_deposit")]
        public string KeyDeposit { get; set; }

        /// <summary>
        /// Gets or sets the PoolDeposit
        /// </summary>
        /// <returns>
        /// The amount of a pool registration deposit in Lovelaces
        /// </returns>
        [Required]
        [JsonPropertyName("pool_deposit")]
        public string PoolDeposit { get; set; }

        /// <summary>
        /// Gets or sets the EMax
        /// </summary>
        /// <returns>
        /// Epoch bound on pool retirement
        /// </returns>
        [Required]
        [JsonPropertyName("e_max")]
        public long EMax { get; set; }

        /// <summary>
        /// Gets or sets the NOpt
        /// </summary>
        /// <returns>
        /// Desired number of pools
        /// </returns>
        [Required]
        [JsonPropertyName("n_opt")]
        public long NOpt { get; set; }

        /// <summary>
        /// Gets or sets the A0
        /// </summary>
        /// <returns>
        /// Pool pledge influence
        /// </returns>
        [Required]
        [JsonPropertyName("a0")]
        public double A0 { get; set; }

        /// <summary>
        /// Gets or sets the Rho
        /// </summary>
        /// <returns>
        /// Monetary expansion
        /// </returns>
        [Required]
        [JsonPropertyName("rho")]
        public double Rho { get; set; }

        /// <summary>
        /// Gets or sets the Tau
        /// </summary>
        /// <returns>
        /// Treasury expansion
        /// </returns>
        [Required]
        [JsonPropertyName("tau")]
        public double Tau { get; set; }

        /// <summary>
        /// Gets or sets the DecentralisationParam
        /// </summary>
        /// <returns>
        /// Percentage of blocks produced by federated nodes
        /// </returns>
        [Required]
        [JsonPropertyName("decentralisation_param")]
        public double DecentralisationParam { get; set; }

        /// <summary>
        /// Gets or sets the ExtraEntropy
        /// </summary>
        /// <returns>
        /// Seed for extra entropy
        /// </returns>
        [Required]
        [JsonPropertyName("extra_entropy")]
        public object ExtraEntropy { get; set; }

        /// <summary>
        /// Gets or sets the ProtocolMajorVer
        /// </summary>
        /// <returns>
        /// Accepted protocol major version
        /// </returns>
        [Required]
        [JsonPropertyName("protocol_major_ver")]
        public long ProtocolMajorVer { get; set; }

        /// <summary>
        /// Gets or sets the ProtocolMinorVer
        /// </summary>
        /// <returns>
        /// Accepted protocol minor version
        /// </returns>
        [Required]
        [JsonPropertyName("protocol_minor_ver")]
        public long ProtocolMinorVer { get; set; }

        /// <summary>
        /// Gets or sets the MinUtxo
        /// </summary>
        /// <returns>
        /// Minimum UTXO value
        /// </returns>
        [Required]
        [JsonPropertyName("min_utxo")]
        public string MinUtxo { get; set; }

        /// <summary>
        /// Gets or sets the MinPoolCost
        /// </summary>
        /// <returns>
        /// Minimum stake cost forced on the pool
        /// </returns>
        [Required]
        [JsonPropertyName("min_pool_cost")]
        public string MinPoolCost { get; set; }

        /// <summary>
        /// Gets or sets the Nonce
        /// </summary>
        /// <returns>
        /// Epoch number only used once
        /// </returns>
        [Required]
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        /// <summary>
        /// Gets or sets the PriceMem
        /// </summary>
        /// <returns>
        /// The per word cost of script memory usage
        /// </returns>
        [Required]
        [JsonPropertyName("price_mem")]
        public double PriceMem { get; set; }

        /// <summary>
        /// Gets or sets the PriceStep
        /// </summary>
        /// <returns>
        /// The cost of script execution step usage
        /// </returns>
        [Required]
        [JsonPropertyName("price_step")]
        public double PriceStep { get; set; }

        /// <summary>
        /// Gets or sets the MaxTxExMem
        /// </summary>
        /// <returns>
        /// The maximum number of execution memory allowed to be used in a single transaction
        /// </returns>
        [Required]
        [JsonPropertyName("max_tx_ex_mem")]
        public string MaxTxExMem { get; set; }

        /// <summary>
        /// Gets or sets the MaxTxExSteps
        /// </summary>
        /// <returns>
        /// The maximum number of execution steps allowed to be used in a single transaction
        /// </returns>
        [Required]
        [JsonPropertyName("max_tx_ex_steps")]
        public string MaxTxExSteps { get; set; }

        /// <summary>
        /// Gets or sets the MaxBlockExMem
        /// </summary>
        /// <returns>
        /// The maximum number of execution memory allowed to be used in a single block
        /// </returns>
        [Required]
        [JsonPropertyName("max_block_ex_mem")]
        public string MaxBlockExMem { get; set; }

        /// <summary>
        /// Gets or sets the MaxBlockExSteps
        /// </summary>
        /// <returns>
        /// The maximum number of execution steps allowed to be used in a single block
        /// </returns>
        [Required]
        [JsonPropertyName("max_block_ex_steps")]
        public string MaxBlockExSteps { get; set; }

        /// <summary>
        /// Gets or sets the MaxValSize
        /// </summary>
        /// <returns>
        /// The maximum Val size
        /// </returns>
        [Required]
        [JsonPropertyName("max_val_size")]
        public string MaxValSize { get; set; }

        /// <summary>
        /// Gets or sets the CollateralPercent
        /// </summary>
        /// <returns>
        /// The percentage of the transactions fee which must be provided as collateral when including non-native scripts
        /// </returns>
        [Required]
        [JsonPropertyName("collateral_percent")]
        public double CollateralPercent { get; set; }

        /// <summary>
        /// Gets or sets the MaxCollateralInputs
        /// </summary>
        /// <returns>
        /// The maximum number of collateral inputs allowed in a transaction
        /// </returns>
        [Required]
        [JsonPropertyName("max_collateral_inputs")]
        public long MaxCollateralInputs { get; set; }

        /// <summary>
        /// Gets or sets the CoinsPerUtxoWord
        /// </summary>
        /// <returns>
        /// The cost per UTxO word
        /// </returns>
        [Required]
        [JsonPropertyName("coins_per_utxo_word")]
        public string CoinsPerUtxoWord { get; set; }

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
        /// Returns true if EpochParamContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of EpochParamContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EpochParamContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Epoch == other.Epoch && MinFeeA == other.MinFeeA && MinFeeB == other.MinFeeB && MaxBlockSize == other.MaxBlockSize && MaxTxSize == other.MaxTxSize && MaxBlockHeaderSize == other.MaxBlockHeaderSize && KeyDeposit == other.KeyDeposit && PoolDeposit == other.PoolDeposit && EMax == other.EMax && NOpt == other.NOpt && A0 == other.A0 && Rho == other.Rho && Tau == other.Tau && DecentralisationParam == other.DecentralisationParam && Equals(ExtraEntropy,other.ExtraEntropy) && ProtocolMajorVer == other.ProtocolMajorVer && ProtocolMinorVer == other.ProtocolMinorVer && MinUtxo == other.MinUtxo && MinPoolCost == other.MinPoolCost && Nonce == other.Nonce && PriceMem == other.PriceMem && PriceStep == other.PriceStep && MaxTxExMem == other.MaxTxExMem && MaxTxExSteps == other.MaxTxExSteps && MaxBlockExMem == other.MaxBlockExMem && MaxBlockExSteps == other.MaxBlockExSteps && MaxValSize == other.MaxValSize && CollateralPercent == other.CollateralPercent && MaxCollateralInputs == other.MaxCollateralInputs && CoinsPerUtxoWord == other.CoinsPerUtxoWord));
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
                   || (obj.GetType() != GetType() && Equals((EpochParamContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Epoch);
            hashCode.Add(MinFeeA);
            hashCode.Add(MinFeeB);
            hashCode.Add(MaxBlockSize);
            hashCode.Add(MaxTxSize);
            hashCode.Add(MaxBlockHeaderSize);
            hashCode.Add(KeyDeposit);
            hashCode.Add(PoolDeposit);
            hashCode.Add(EMax);
            hashCode.Add(NOpt);
            hashCode.Add(A0);
            hashCode.Add(Rho);
            hashCode.Add(Tau);
            hashCode.Add(DecentralisationParam);
            hashCode.Add(ExtraEntropy);
            hashCode.Add(ProtocolMajorVer);
            hashCode.Add(ProtocolMinorVer);
            hashCode.Add(MinUtxo);
            hashCode.Add(MinPoolCost);
            hashCode.Add(Nonce);
            hashCode.Add(PriceMem);
            hashCode.Add(PriceStep);
            hashCode.Add(MaxTxExMem);
            hashCode.Add(MaxTxExSteps);
            hashCode.Add(MaxBlockExMem);
            hashCode.Add(MaxBlockExSteps);
            hashCode.Add(MaxValSize);
            hashCode.Add(CollateralPercent);
            hashCode.Add(MaxCollateralInputs);
            hashCode.Add(CoinsPerUtxoWord);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(EpochParamContentResponse left, EpochParamContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EpochParamContentResponse left, EpochParamContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}

