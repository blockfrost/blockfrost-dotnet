using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class EpochParamContent
    {
        /// <summary>Pool pledge influence</summary>
        [JsonPropertyName("a0")]
        public double A0 { get; set; }

        /// <summary>Percentage of blocks produced by federated nodes</summary>
        [JsonPropertyName("decentralisation_param")]
        public double Decentralisation_param { get; set; }

        /// <summary>Epoch bound on pool retirement</summary>
        [JsonPropertyName("e_max")]
        public int E_max { get; set; }

        /// <summary>Epoch number</summary>
        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }

        /// <summary>Seed for extra entropy</summary>
        [JsonPropertyName("extra_entropy")]
        public object Extra_entropy { get; set; }

        /// <summary>The amount of a key registration deposit in Lovelaces</summary>
        [JsonPropertyName("key_deposit")]
        [Required(AllowEmptyStrings = true)]
        public string Key_deposit { get; set; }

        /// <summary>Maximum block header size</summary>
        [JsonPropertyName("max_block_header_size")]
        public int Max_block_header_size { get; set; }

        /// <summary>Maximum block body size in Bytes</summary>
        [JsonPropertyName("max_block_size")]
        public int Max_block_size { get; set; }

        /// <summary>Maximum transaction size</summary>
        [JsonPropertyName("max_tx_size")]
        public int Max_tx_size { get; set; }

        /// <summary>The linear factor for the minimum fee calculation for given epoch</summary>
        [JsonPropertyName("min_fee_a")]
        public int Min_fee_a { get; set; }

        /// <summary>The constant factor for the minimum fee calculation</summary>
        [JsonPropertyName("min_fee_b")]
        public int Min_fee_b { get; set; }

        /// <summary>Minimum stake cost forced on the pool</summary>
        [JsonPropertyName("min_pool_cost")]
        [Required(AllowEmptyStrings = true)]
        public string Min_pool_cost { get; set; }

        /// <summary>Minimum UTXO value</summary>
        [JsonPropertyName("min_utxo")]
        [Required(AllowEmptyStrings = true)]
        public string Min_utxo { get; set; }

        /// <summary>Desired number of pools</summary>
        [JsonPropertyName("n_opt")]
        public int N_opt { get; set; }

        /// <summary>Epoch number only used once</summary>
        [JsonPropertyName("nonce")]
        [Required(AllowEmptyStrings = true)]
        public string Nonce { get; set; }

        /// <summary>The amount of a pool registration deposit in Lovelaces</summary>
        [JsonPropertyName("pool_deposit")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_deposit { get; set; }

        /// <summary>Accepted protocol major version</summary>
        [JsonPropertyName("protocol_major_ver")]
        public int Protocol_major_ver { get; set; }

        /// <summary>Accepted protocol minor version</summary>
        [JsonPropertyName("protocol_minor_ver")]
        public int Protocol_minor_ver { get; set; }

        /// <summary>Monetary expansion</summary>
        [JsonPropertyName("rho")]
        public double Rho { get; set; }

        /// <summary>Treasury expansion</summary>
        [JsonPropertyName("tau")]
        public double Tau { get; set; }
    }
}
