using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PoolResponse"/>
    /// </summary>
    public partial class PoolResponse : IEquatable<PoolResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolResponse" /> class.
        /// </summary>
        public PoolResponse()
        {
        }

        /// <summary>
        /// Gets or sets the PoolId
        /// </summary>
        /// <returns>
        /// Bech32 pool ID
        /// </returns>
        [Required]
        [JsonPropertyName("pool_id")]
        public string PoolId { get; set; }

        /// <summary>
        /// Gets or sets the Hex
        /// </summary>
        /// <returns>
        /// Hexadecimal pool ID.
        /// </returns>
        [Required]
        [JsonPropertyName("hex")]
        public string Hex { get; set; }

        /// <summary>
        /// Gets or sets the VrfKey
        /// </summary>
        /// <returns>
        /// VRF key hash
        /// </returns>
        [Required]
        [JsonPropertyName("vrf_key")]
        public string VrfKey { get; set; }

        /// <summary>
        /// Gets or sets the BlocksMinted
        /// </summary>
        /// <returns>
        /// Total minted blocks
        /// </returns>
        [Required]
        [JsonPropertyName("blocks_minted")]
        public long BlocksMinted { get; set; }

        /// <summary>
        /// Gets or sets the LiveStake
        /// </summary>
        /// <returns>
        /// The LiveStake
        /// </returns>
        [Required]
        [JsonPropertyName("live_stake")]
        public string LiveStake { get; set; }

        /// <summary>
        /// Gets or sets the LiveSize
        /// </summary>
        /// <returns>
        /// The LiveSize
        /// </returns>
        [Required]
        [JsonPropertyName("live_size")]
        public double LiveSize { get; set; }

        /// <summary>
        /// Gets or sets the LiveSaturation
        /// </summary>
        /// <returns>
        /// The LiveSaturation
        /// </returns>
        [Required]
        [JsonPropertyName("live_saturation")]
        public double LiveSaturation { get; set; }

        /// <summary>
        /// Gets or sets the LiveDelegators
        /// </summary>
        /// <returns>
        /// The LiveDelegators
        /// </returns>
        [Required]
        [JsonPropertyName("live_delegators")]
        public double LiveDelegators { get; set; }

        /// <summary>
        /// Gets or sets the ActiveStake
        /// </summary>
        /// <returns>
        /// The ActiveStake
        /// </returns>
        [Required]
        [JsonPropertyName("active_stake")]
        public string ActiveStake { get; set; }

        /// <summary>
        /// Gets or sets the ActiveSize
        /// </summary>
        /// <returns>
        /// The ActiveSize
        /// </returns>
        [Required]
        [JsonPropertyName("active_size")]
        public double ActiveSize { get; set; }

        /// <summary>
        /// Gets or sets the DeclaredPledge
        /// </summary>
        /// <returns>
        /// Stake pool certificate pledge
        /// </returns>
        [Required]
        [JsonPropertyName("declared_pledge")]
        public string DeclaredPledge { get; set; }

        /// <summary>
        /// Gets or sets the LivePledge
        /// </summary>
        /// <returns>
        /// Stake pool current pledge
        /// </returns>
        [Required]
        [JsonPropertyName("live_pledge")]
        public string LivePledge { get; set; }

        /// <summary>
        /// Gets or sets the MarginCost
        /// </summary>
        /// <returns>
        /// Margin tax cost of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("margin_cost")]
        public double MarginCost { get; set; }

        /// <summary>
        /// Gets or sets the FixedCost
        /// </summary>
        /// <returns>
        /// Fixed tax cost of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("fixed_cost")]
        public string FixedCost { get; set; }

        /// <summary>
        /// Gets or sets the RewardAccount
        /// </summary>
        /// <returns>
        /// Bech32 reward account of the stake pool
        /// </returns>
        [Required]
        [JsonPropertyName("reward_account")]
        public string RewardAccount { get; set; }

        /// <summary>
        /// Gets or sets the Owners
        /// </summary>
        /// <returns>
        /// The Owners
        /// </returns>
        [Required]
        [JsonPropertyName("owners")]
        public object Owners { get; set; }

        /// <summary>
        /// Gets or sets the Registration
        /// </summary>
        /// <returns>
        /// The Registration
        /// </returns>
        [Required]
        [JsonPropertyName("registration")]
        public object Registration { get; set; }

        /// <summary>
        /// Gets or sets the Retirement
        /// </summary>
        /// <returns>
        /// The Retirement
        /// </returns>
        [Required]
        [JsonPropertyName("retirement")]
        public object Retirement { get; set; }

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
        /// Returns true if PoolResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PoolResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PoolResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (PoolId == other.PoolId && Hex == other.Hex && VrfKey == other.VrfKey && BlocksMinted == other.BlocksMinted && LiveStake == other.LiveStake && LiveSize == other.LiveSize && LiveSaturation == other.LiveSaturation && LiveDelegators == other.LiveDelegators && ActiveStake == other.ActiveStake && ActiveSize == other.ActiveSize && DeclaredPledge == other.DeclaredPledge && LivePledge == other.LivePledge && MarginCost == other.MarginCost && FixedCost == other.FixedCost && RewardAccount == other.RewardAccount && Equals(Owners,other.Owners) && Equals(Registration,other.Registration) && Equals(Retirement,other.Retirement)));
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
                   || (obj.GetType() != GetType() && Equals((PoolResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(PoolId);
            hashCode.Add(Hex);
            hashCode.Add(VrfKey);
            hashCode.Add(BlocksMinted);
            hashCode.Add(LiveStake);
            hashCode.Add(LiveSize);
            hashCode.Add(LiveSaturation);
            hashCode.Add(LiveDelegators);
            hashCode.Add(ActiveStake);
            hashCode.Add(ActiveSize);
            hashCode.Add(DeclaredPledge);
            hashCode.Add(LivePledge);
            hashCode.Add(MarginCost);
            hashCode.Add(FixedCost);
            hashCode.Add(RewardAccount);
            hashCode.Add(Owners);
            hashCode.Add(Registration);
            hashCode.Add(Retirement);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PoolResponse left, PoolResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PoolResponse left, PoolResponse right)
        {
            return !Equals(left, right);
        }
    }
}

