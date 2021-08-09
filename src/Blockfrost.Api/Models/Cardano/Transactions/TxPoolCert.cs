using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxPoolCert
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Bech32 encoded pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>VRF key hash</summary>
        [Newtonsoft.Json.JsonProperty("vrf_key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Vrf_key { get; set; }

        /// <summary>Stake pool certificate pledge in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("pledge", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pledge { get; set; }

        /// <summary>Margin tax cost of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("margin_cost", Required = Newtonsoft.Json.Required.Always)]
        public double Margin_cost { get; set; }

        /// <summary>Fixed tax cost of the stake pool in Lovelaces</summary>
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

        [Newtonsoft.Json.JsonProperty("metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Metadata2 Metadata { get; set; }

        [Newtonsoft.Json.JsonProperty("relays", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Relays> Relays { get; set; } = new System.Collections.ObjectModel.Collection<Relays>();

        /// <summary>Epoch that the delegation becomes active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}