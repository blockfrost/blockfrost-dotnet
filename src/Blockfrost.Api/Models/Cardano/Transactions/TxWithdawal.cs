using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{
    public partial class TxWithdawal
    {
        /// <summary>Bech32 withdrawal address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Withdrawal amount in Lovelaces</summary>
        [JsonPropertyName("amount")]
        [Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }
    }
}
