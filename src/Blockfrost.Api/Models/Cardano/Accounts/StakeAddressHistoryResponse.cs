using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class StakeAddressHistoryResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        /// <summary>Epoch in which the stake was active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Stake amount in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Bech32 ID of pool being delegated to</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }
    }
}