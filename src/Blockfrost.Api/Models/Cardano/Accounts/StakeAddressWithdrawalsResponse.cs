using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class StakeAddressWithdrawalsResponse
    {
        /// <summary>Withdrawal amount in Lovelaces</summary>
        [JsonPropertyName("amount")]
        [Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Hash of the transaction containing the withdrawal</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}
