using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class Account
    {
        /// <summary>Registration state of an account</summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>Epoch of the most recent action - registration or deregistration</summary>
        [JsonPropertyName("active_epoch")]
        public int Active_epoch { get; set; }

        /// <summary>Balance of the account in Lovelaces</summary>
        [JsonPropertyName("controlled_amount")]
        [Required(AllowEmptyStrings = true)]
        public string Controlled_amount { get; set; }

        /// <summary>Bech32 pool ID that owns the account</summary>
        [JsonPropertyName("pool_id")]
        public string Pool_id { get; set; }

        /// <summary>Sum of all  funds from reserves for the account in the Lovelaces</summary>
        [JsonPropertyName("reserves_sum")]
        [Required(AllowEmptyStrings = true)]
        public string Reserves_sum { get; set; }

        /// <summary>Sum of all rewards for the account in the Lovelaces</summary>
        [JsonPropertyName("rewards_sum")]
        [Required(AllowEmptyStrings = true)]
        public string Rewards_sum { get; set; }

        /// <summary>Bech32 stake address</summary>
        [JsonPropertyName("stake_address")]
        [Required(AllowEmptyStrings = true)]
        public string Stake_address { get; set; }

        /// <summary>Sum of all funds from treasury for the account in the Lovelaces</summary>
        [JsonPropertyName("treasury_sum")]
        [Required(AllowEmptyStrings = true)]
        public string Treasury_sum { get; set; }

        /// <summary>Sum of available rewards that haven't been withdrawn yet for the account in the Lovelaces</summary>
        [JsonPropertyName("withdrawable_amount")]
        [Required(AllowEmptyStrings = true)]
        public string Withdrawable_amount { get; set; }

        /// <summary>Sum of all the withdrawals for the account in Lovelaces</summary>
        [JsonPropertyName("withdrawals_sum")]
        [Required(AllowEmptyStrings = true)]
        public string Withdrawals_sum { get; set; }
    }
}
