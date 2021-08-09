using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EpochParamContent
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        /// <summary>Pool pledge influence</summary>
        [Newtonsoft.Json.JsonProperty("a0", Required = Newtonsoft.Json.Required.Always)]
        public double A0 { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Percentage of blocks produced by federated nodes</summary>
        [Newtonsoft.Json.JsonProperty("decentralisation_param", Required = Newtonsoft.Json.Required.Always)]
        public double Decentralisation_param { get; set; }

        /// <summary>Epoch bound on pool retirement</summary>
        [Newtonsoft.Json.JsonProperty("e_max", Required = Newtonsoft.Json.Required.Always)]
        public int E_max { get; set; }

        /// <summary>Epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        /// <summary>Seed for extra entropy</summary>
        [Newtonsoft.Json.JsonProperty("extra_entropy", Required = Newtonsoft.Json.Required.AllowNull)]
        public object Extra_entropy { get; set; }

        /// <summary>The amount of a key registration deposit in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("key_deposit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Key_deposit { get; set; }

        /// <summary>Maximum block header size</summary>
        [Newtonsoft.Json.JsonProperty("max_block_header_size", Required = Newtonsoft.Json.Required.Always)]
        public int Max_block_header_size { get; set; }

        /// <summary>Maximum block body size in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("max_block_size", Required = Newtonsoft.Json.Required.Always)]
        public int Max_block_size { get; set; }

        /// <summary>Maximum transaction size</summary>
        [Newtonsoft.Json.JsonProperty("max_tx_size", Required = Newtonsoft.Json.Required.Always)]
        public int Max_tx_size { get; set; }

        /// <summary>The linear factor for the minimum fee calculation for given epoch</summary>
        [Newtonsoft.Json.JsonProperty("min_fee_a", Required = Newtonsoft.Json.Required.Always)]
        public int Min_fee_a { get; set; }

        /// <summary>The constant factor for the minimum fee calculation</summary>
        [Newtonsoft.Json.JsonProperty("min_fee_b", Required = Newtonsoft.Json.Required.Always)]
        public int Min_fee_b { get; set; }

        /// <summary>Minimum stake cost forced on the pool</summary>
        [Newtonsoft.Json.JsonProperty("min_pool_cost", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Min_pool_cost { get; set; }

        /// <summary>Minimum UTXO value</summary>
        [Newtonsoft.Json.JsonProperty("min_utxo", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Min_utxo { get; set; }

        /// <summary>Desired number of pools</summary>
        [Newtonsoft.Json.JsonProperty("n_opt", Required = Newtonsoft.Json.Required.Always)]
        public int N_opt { get; set; }

        /// <summary>Epoch number only used once</summary>
        [Newtonsoft.Json.JsonProperty("nonce", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Nonce { get; set; }

        /// <summary>The amount of a pool registration deposit in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("pool_deposit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_deposit { get; set; }

        /// <summary>Accepted protocol major version</summary>
        [Newtonsoft.Json.JsonProperty("protocol_major_ver", Required = Newtonsoft.Json.Required.Always)]
        public int Protocol_major_ver { get; set; }

        /// <summary>Accepted protocol minor version</summary>
        [Newtonsoft.Json.JsonProperty("protocol_minor_ver", Required = Newtonsoft.Json.Required.Always)]
        public int Protocol_minor_ver { get; set; }

        /// <summary>Monetary expansion</summary>
        [Newtonsoft.Json.JsonProperty("rho", Required = Newtonsoft.Json.Required.Always)]
        public double Rho { get; set; }

        /// <summary>Treasury expansion</summary>
        [Newtonsoft.Json.JsonProperty("tau", Required = Newtonsoft.Json.Required.Always)]
        public double Tau { get; set; }
    }
}