using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class PoolDelegationResponse
    {
        /// <summary>Transaction ID</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Certificate within the transaction</summary>
        [JsonPropertyName("cert_index")]
        public int Cert_index { get; set; }
    }
}
