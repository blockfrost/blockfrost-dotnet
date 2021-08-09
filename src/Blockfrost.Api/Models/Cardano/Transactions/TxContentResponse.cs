using System.Collections.Generic;

namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class TxContentResponse
    {
        /// <summary>Transaction hash</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        /// <summary>Block hash</summary>
        [Newtonsoft.Json.JsonProperty("block", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Block { get; set; }

        /// <summary>Block number</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        /// <summary>Slot number</summary>
        [Newtonsoft.Json.JsonProperty("slot", Required = Newtonsoft.Json.Required.Always)]
        public int Slot { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
        public int Index { get; set; }

        [Newtonsoft.Json.JsonProperty("output_amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Output_amount> Output_amount { get; set; } = new System.Collections.ObjectModel.Collection<Output_amount>();

        /// <summary>Fees of the transaction in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        /// <summary>Deposit within the transaction in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("deposit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Deposit { get; set; }

        /// <summary>Size of the transaction in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
        public int Size { get; set; }

        /// <summary>Left (included) endpoint of the timelock validity intervals</summary>
        [Newtonsoft.Json.JsonProperty("invalid_before", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Invalid_before { get; set; }

        /// <summary>Right (excluded) endpoint of the timelock validity intervals</summary>
        [Newtonsoft.Json.JsonProperty("invalid_hereafter", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Invalid_hereafter { get; set; }

        /// <summary>Count of UTXOs within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("utxo_count", Required = Newtonsoft.Json.Required.Always)]
        public int Utxo_count { get; set; }

        /// <summary>Count of the withdrawal within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("withdrawal_count", Required = Newtonsoft.Json.Required.Always)]
        public int Withdrawal_count { get; set; }

        /// <summary>Count of the MIR certificates within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("mir_cert_count", Required = Newtonsoft.Json.Required.Always)]
        public int Mir_cert_count { get; set; }

        /// <summary>Count of the delegations within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("delegation_count", Required = Newtonsoft.Json.Required.Always)]
        public int Delegation_count { get; set; }

        /// <summary>Count of the stake keys (de)registration and delegation certificates within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("stake_cert_count", Required = Newtonsoft.Json.Required.Always)]
        public int Stake_cert_count { get; set; }

        /// <summary>Count of the stake pool registration and update certificates within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("pool_update_count", Required = Newtonsoft.Json.Required.Always)]
        public int Pool_update_count { get; set; }

        /// <summary>Count of the stake pool retirement certificates within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("pool_retire_count", Required = Newtonsoft.Json.Required.Always)]
        public int Pool_retire_count { get; set; }

        /// <summary>Count of asset mints and burns within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("asset_mint_or_burn_count", Required = Newtonsoft.Json.Required.Always)]
        public int Asset_mint_or_burn_count { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}