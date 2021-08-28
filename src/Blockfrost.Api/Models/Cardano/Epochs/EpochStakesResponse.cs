using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class EpochStakesResponse
    {
        /// <summary>Amount of active delegated stake in Lovelaces</summary>
        [JsonPropertyName("amount")]
        [Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Bech32 prefix of the pool delegated to</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Stake address</summary>
        [JsonPropertyName("stake_address")]
        [Required(AllowEmptyStrings = true)]
        public string Stake_address { get; set; }
    }
}
