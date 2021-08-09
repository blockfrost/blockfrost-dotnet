using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Assets
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AssetResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Hex-encoded asset name of the asset</summary>
        [Newtonsoft.Json.JsonProperty("asset_name", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Asset_name { get; set; }

        /// <summary>Hex-encoded asset full name</summary>
        [Newtonsoft.Json.JsonProperty("asset", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Asset1 { get; set; }

        /// <summary>CIP14 based user-facing fingerprint</summary>
        [Newtonsoft.Json.JsonProperty("fingerprint", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fingerprint { get; set; }

        /// <summary>ID of the initial minting transaction</summary>
        [Newtonsoft.Json.JsonProperty("initial_mint_tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Initial_mint_tx_hash { get; set; }

        [Newtonsoft.Json.JsonProperty("metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Metadata Metadata { get; set; }

        /// <summary>Count of mint and burn transactions</summary>
        [Newtonsoft.Json.JsonProperty("mint_or_burn_count", Required = Newtonsoft.Json.Required.Always)]
        public int Mint_or_burn_count { get; set; }

        /// <summary>On-chain metadata stored in the minting transaction under label 721,
        /// <br/>community discussion around the standard ongoing at https://github.com/cardano-foundation/CIPs/pull/85
        /// <br/></summary>
        [Newtonsoft.Json.JsonProperty("onchain_metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Onchain_metadata Onchain_metadata { get; set; }

        /// <summary>Policy ID of the asset</summary>
        [Newtonsoft.Json.JsonProperty("policy_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Policy_id { get; set; }

        /// <summary>Current asset quantity</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }
    }
}