using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class TxPoolCert
    {
        /// <summary>Epoch that the delegation becomes active</summary>
        [JsonPropertyName("active_epoch")]
        public int Active_epoch { get; set; }

        /// <summary>Index of the certificate within the transaction</summary>
        [JsonPropertyName("cert_index")]
        public int Cert_index { get; set; }

        /// <summary>Fixed tax cost of the stake pool in Lovelaces</summary>
        [JsonPropertyName("fixed_cost")]
        [Required(AllowEmptyStrings = true)]
        public string Fixed_cost { get; set; }

        /// <summary>Margin tax cost of the stake pool</summary>
        [JsonPropertyName("margin_cost")]
        public double Margin_cost { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata2 Metadata { get; set; }

        [JsonPropertyName("owners")]
        [Required]
        public ICollection<string> Owners { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        /// <summary>Stake pool certificate pledge in Lovelaces</summary>
        [JsonPropertyName("pledge")]
        [Required(AllowEmptyStrings = true)]
        public string Pledge { get; set; }

        /// <summary>Bech32 encoded pool ID</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        [JsonPropertyName("relays")]
        [Required]
        public ICollection<Relays> Relays { get; set; } = new System.Collections.ObjectModel.Collection<Relays>();

        /// <summary>Bech32 reward account of the stake pool</summary>
        [JsonPropertyName("reward_account")]
        [Required(AllowEmptyStrings = true)]
        public string Reward_account { get; set; }

        /// <summary>VRF key hash</summary>
        [JsonPropertyName("vrf_key")]
        [Required(AllowEmptyStrings = true)]
        public string Vrf_key { get; set; }
    }
}
