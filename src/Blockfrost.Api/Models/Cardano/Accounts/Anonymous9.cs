using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class Anonymous9
    {
        /// <summary>Rewards for given epoch in Lovelaces</summary>
        [JsonPropertyName("amount")]
        [Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Epoch of the associated reward</summary>
        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }

        /// <summary>Bech32 pool ID being delegated to</summary>
        [JsonPropertyName("pool_id")]
        [Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }
    }
}
