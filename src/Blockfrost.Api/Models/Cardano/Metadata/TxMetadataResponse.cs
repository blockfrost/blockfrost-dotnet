using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    public partial class TxMetadataResponse
    {
        /// <summary>Content of the metadata</summary>
        [JsonPropertyName("json_metadata")]
        [Required(AllowEmptyStrings = true)]
        public string Json_metadata { get; set; }

        /// <summary>Metadata label</summary>
        [JsonPropertyName("label")]
        [Required(AllowEmptyStrings = true)]
        public string Label { get; set; }
    }
}
