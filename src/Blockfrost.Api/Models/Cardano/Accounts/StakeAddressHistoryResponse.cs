using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class StakeAddressHistoryResponse
    {
        /// <summary>Epoch in which the stake was active</summary>
        [JsonPropertyName("active_epoch")]
        public int Active_epoch { get; set; }

        /// <summary>Stake amount in Lovelaces</summary>
        [JsonPropertyName("amount")]
        [Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Bech32 ID of pool being delegated to</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }
    }
}
