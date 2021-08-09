using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class TxDelegation
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [JsonPropertyName("index")]
        [System.Obsolete]
        public int Index { get; set; }

        /// <summary>Index of the certificate within the transaction</summary>
        [JsonPropertyName("cert_index")]
        public int Cert_index { get; set; }

        /// <summary>Bech32 delegation stake address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Bech32 ID of delegated stake pool</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Epoch in which the delegation becomes active</summary>
        [JsonPropertyName("active_epoch")]
        public int Active_epoch { get; set; }
    }
}
