using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class PoolResponse
    {
        /// <summary>Bech32 pool ID</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Hexadecimal pool ID.</summary>
        [JsonPropertyName("hex")]
        [Required(AllowEmptyStrings = true)]
        public string Hex { get; set; }

        /// <summary>VRF key hash</summary>
        [JsonPropertyName("vrf_key")]
        [Required(AllowEmptyStrings = true)]
        public string Vrf_key { get; set; }

        /// <summary>Total minted blocks</summary>
        [JsonPropertyName("blocks_minted")]
        public int Blocks_minted { get; set; }

        [JsonPropertyName("live_stake")]
        [Required(AllowEmptyStrings = true)]
        public string Live_stake { get; set; }

        [JsonPropertyName("live_size")]
        public double Live_size { get; set; }

        [JsonPropertyName("live_saturation")]
        public double Live_saturation { get; set; }

        [JsonPropertyName("live_delegators")]
        public double Live_delegators { get; set; }

        [JsonPropertyName("active_stake")]
        [Required(AllowEmptyStrings = true)]
        public string Active_stake { get; set; }

        [JsonPropertyName("active_size")]
        public double Active_size { get; set; }

        /// <summary>Stake pool certificate pledge</summary>
        [JsonPropertyName("declared_pledge")]
        [Required(AllowEmptyStrings = true)]
        public string Declared_pledge { get; set; }

        /// <summary>Stake pool current pledge</summary>
        [JsonPropertyName("live_pledge")]
        [Required(AllowEmptyStrings = true)]
        public string Live_pledge { get; set; }

        /// <summary>Margin tax cost of the stake pool</summary>
        [JsonPropertyName("margin_cost")]
        public double Margin_cost { get; set; }

        /// <summary>Fixed tax cost of the stake pool</summary>
        [JsonPropertyName("fixed_cost")]
        [Required(AllowEmptyStrings = true)]
        public string Fixed_cost { get; set; }

        /// <summary>Bech32 reward account of the stake pool</summary>
        [JsonPropertyName("reward_account")]
        [Required(AllowEmptyStrings = true)]
        public string Reward_account { get; set; }

        [JsonPropertyName("owners")]
        [Required]
        public ICollection<string> Owners { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [JsonPropertyName("registration")]
        [Required]
        public ICollection<string> Registration { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [JsonPropertyName("retirement")]
        [Required]
        public ICollection<string> Retirement { get; set; } = new System.Collections.ObjectModel.Collection<string>();
    }
}
