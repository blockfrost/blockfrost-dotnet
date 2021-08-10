using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class StakeAddressRegistrationsResponse
    {
        /// <summary>Action in the certificate</summary>
        [JsonPropertyName("action")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EAction Action { get; set; }

        /// <summary>Hash of the transaction containing the (de)registration certificate</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}
