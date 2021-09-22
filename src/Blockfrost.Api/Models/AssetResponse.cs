using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AssetResponse"/>
    /// </summary>
    public partial class AssetResponse : IEquatable<AssetResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetResponse" /> class.
        /// </summary>
        public AssetResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Asset
        /// </summary>
        /// <returns>
        /// Hex-encoded asset full name
        /// </returns>
        [Required]
        [JsonPropertyName("asset")]
        public string Asset { get; set; }

        /// <summary>
        /// Gets or sets the PolicyId
        /// </summary>
        /// <returns>
        /// Policy ID of the asset
        /// </returns>
        [Required]
        [JsonPropertyName("policy_id")]
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets the AssetName
        /// </summary>
        /// <returns>
        /// Hex-encoded asset name of the asset
        /// </returns>
        [Required]
        [JsonPropertyName("asset_name")]
        public string AssetName { get; set; }

        /// <summary>
        /// Gets or sets the Fingerprint
        /// </summary>
        /// <returns>
        /// CIP14 based user-facing fingerprint
        /// </returns>
        [Required]
        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        /// <returns>
        /// Current asset quantity
        /// </returns>
        [Required]
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Gets or sets the InitialMintTxHash
        /// </summary>
        /// <returns>
        /// ID of the initial minting transaction
        /// </returns>
        [Required]
        [JsonPropertyName("initial_mint_tx_hash")]
        public string InitialMintTxHash { get; set; }

        /// <summary>
        /// Gets or sets the MintOrBurnCount
        /// </summary>
        /// <returns>
        /// Count of mint and burn transactions
        /// </returns>
        [Required]
        [JsonPropertyName("mint_or_burn_count")]
        public long MintOrBurnCount { get; set; }

        /// <summary>
        /// Gets or sets the OnchainMetadata
        /// </summary>
        /// <returns>
        /// On-chain metadata stored in the minting transaction under label 721,community discussion around the standard ongoing at https://github.com/cardano-foundation/CIPs/pull/85
        /// </returns>
        [Required]
        [JsonPropertyName("onchain_metadata")]
        public object OnchainMetadata { get; set; }

        /// <summary>
        /// Gets or sets the Metadata
        /// </summary>
        /// <returns>
        /// The Metadata
        /// </returns>
        [Required]
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }

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
        /// Returns true if AssetResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Asset == other.Asset && PolicyId == other.PolicyId && AssetName == other.AssetName && Fingerprint == other.Fingerprint && Quantity == other.Quantity && InitialMintTxHash == other.InitialMintTxHash && MintOrBurnCount == other.MintOrBurnCount && Equals(OnchainMetadata,other.OnchainMetadata) && Equals(Metadata,other.Metadata)));
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
                   || (obj.GetType() != GetType() && Equals((AssetResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Asset);
            hashCode.Add(PolicyId);
            hashCode.Add(AssetName);
            hashCode.Add(Fingerprint);
            hashCode.Add(Quantity);
            hashCode.Add(InitialMintTxHash);
            hashCode.Add(MintOrBurnCount);
            hashCode.Add(OnchainMetadata);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AssetResponse left, AssetResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetResponse left, AssetResponse right)
        {
            return !Equals(left, right);
        }
    }
}

