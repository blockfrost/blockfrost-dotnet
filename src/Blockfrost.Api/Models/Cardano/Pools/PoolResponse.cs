using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PoolResponse
    {
        /// <summary>Bech32 pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Hexadecimal pool ID.</summary>
        [Newtonsoft.Json.JsonProperty("hex", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hex { get; set; }

        /// <summary>VRF key hash</summary>
        [Newtonsoft.Json.JsonProperty("vrf_key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Vrf_key { get; set; }

        /// <summary>Total minted blocks</summary>
        [Newtonsoft.Json.JsonProperty("blocks_minted", Required = Newtonsoft.Json.Required.Always)]
        public int Blocks_minted { get; set; }

        [Newtonsoft.Json.JsonProperty("live_stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Live_stake { get; set; }

        [Newtonsoft.Json.JsonProperty("live_size", Required = Newtonsoft.Json.Required.Always)]
        public double Live_size { get; set; }

        [Newtonsoft.Json.JsonProperty("live_saturation", Required = Newtonsoft.Json.Required.Always)]
        public double Live_saturation { get; set; }

        [Newtonsoft.Json.JsonProperty("live_delegators", Required = Newtonsoft.Json.Required.Always)]
        public double Live_delegators { get; set; }

        [Newtonsoft.Json.JsonProperty("active_stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Active_stake { get; set; }

        [Newtonsoft.Json.JsonProperty("active_size", Required = Newtonsoft.Json.Required.Always)]
        public double Active_size { get; set; }

        /// <summary>Stake pool certificate pledge</summary>
        [Newtonsoft.Json.JsonProperty("declared_pledge", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Declared_pledge { get; set; }

        /// <summary>Stake pool current pledge</summary>
        [Newtonsoft.Json.JsonProperty("live_pledge", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Live_pledge { get; set; }

        /// <summary>Margin tax cost of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("margin_cost", Required = Newtonsoft.Json.Required.Always)]
        public double Margin_cost { get; set; }

        /// <summary>Fixed tax cost of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("fixed_cost", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fixed_cost { get; set; }

        /// <summary>Bech32 reward account of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("reward_account", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Reward_account { get; set; }

        [Newtonsoft.Json.JsonProperty("owners", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Owners { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [Newtonsoft.Json.JsonProperty("registration", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Registration { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [Newtonsoft.Json.JsonProperty("retirement", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Retirement { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}