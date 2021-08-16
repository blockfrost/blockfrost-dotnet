using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    public partial class TxStakeAddress
    {
        /// <summary>Delegation stake address</summary>
        [JsonPropertyName("address")]
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Index of the certificate within the transaction</summary>
        [JsonPropertyName("cert_index")]
        public int Cert_index { get; set; }

        /// <summary>Registration boolean, false if deregistration</summary>
        [JsonPropertyName("registration")]
        public bool Registration { get; set; }
    }
}
