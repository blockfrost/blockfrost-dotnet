using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EpochContentResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        /// <summary>Sum of all the active stakes within the epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("active_stake", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Active_stake { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Number of blocks within the epoch</summary>
        [Newtonsoft.Json.JsonProperty("block_count", Required = Newtonsoft.Json.Required.Always)]
        public int Block_count { get; set; }

        /// <summary>Unix time of the end of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("end_time", Required = Newtonsoft.Json.Required.Always)]
        public int End_time { get; set; }

        /// <summary>Epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        /// <summary>Sum of all the fees within the epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        /// <summary>Unix time of the first block of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("first_block_time", Required = Newtonsoft.Json.Required.Always)]
        public int First_block_time { get; set; }

        /// <summary>Unix time of the last block of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("last_block_time", Required = Newtonsoft.Json.Required.Always)]
        public int Last_block_time { get; set; }

        /// <summary>Sum of all the transactions within the epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("output", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Output { get; set; }

        /// <summary>Unix time of the start of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("start_time", Required = Newtonsoft.Json.Required.Always)]
        public int Start_time { get; set; }

        /// <summary>Number of transactions within the epoch</summary>
        [Newtonsoft.Json.JsonProperty("tx_count", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_count { get; set; }
    }
}