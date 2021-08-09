using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PoolHistoryResponse
    {
        /// <summary>Epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        /// <summary>Number of blocks created by pool</summary>
        [Newtonsoft.Json.JsonProperty("blocks", Required = Newtonsoft.Json.Required.Always)]
        public int Blocks { get; set; }

        /// <summary>Active (Snapshot of live stake 2 epochs ago) stake in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("active_stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Active_stake { get; set; }

        /// <summary>Pool size (percentage) of overall active stake at that epoch</summary>
        [Newtonsoft.Json.JsonProperty("active_size", Required = Newtonsoft.Json.Required.Always)]
        public double Active_size { get; set; }

        /// <summary>Number of delegators for epoch</summary>
        [Newtonsoft.Json.JsonProperty("delegators_count", Required = Newtonsoft.Json.Required.Always)]
        public int Delegators_count { get; set; }

        /// <summary>Total rewards received before distribution to delegators</summary>
        [Newtonsoft.Json.JsonProperty("rewards", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Rewards { get; set; }

        /// <summary>Pool operator rewards</summary>
        [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}