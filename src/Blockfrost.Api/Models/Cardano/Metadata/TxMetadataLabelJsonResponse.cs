using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class TxMetadataLabelJsonResponse
    {
        /// <summary>Content of the JSON metadata</summary>
        [JsonPropertyName("json_metadata")]
        public Json_metadata Json_metadata { get; set; }

        /// <summary>Transaction hash that contains the specific metadata</summary>
        [JsonPropertyName("tx_hash")]
        [Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }
    }
}
