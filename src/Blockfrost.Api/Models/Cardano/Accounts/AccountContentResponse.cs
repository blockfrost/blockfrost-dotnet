using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Accounts
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AccountContentResponse
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        /// <summary>Registration state of an account</summary>
        [Newtonsoft.Json.JsonProperty("active", Required = Newtonsoft.Json.Required.Always)]
        public bool Active { get; set; }

        /// <summary>Epoch of the most recent action - registration or deregistration</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

        /// <summary>Balance of the account in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("controlled_amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Controlled_amount { get; set; }

        /// <summary>Bech32 pool ID that owns the account</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Pool_id { get; set; }

        /// <summary>Sum of all  funds from reserves for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("reserves_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Reserves_sum { get; set; }

        /// <summary>Sum of all rewards for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("rewards_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Rewards_sum { get; set; }

        /// <summary>Bech32 stake address</summary>
        [Newtonsoft.Json.JsonProperty("stake_address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Stake_address { get; set; }

        /// <summary>Sum of all funds from treasury for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("treasury_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Treasury_sum { get; set; }

        /// <summary>Sum of available rewards that haven't been withdrawn yet for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("withdrawable_amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Withdrawable_amount { get; set; }

        /// <summary>Sum of all the withdrawals for the account in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("withdrawals_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Withdrawals_sum { get; set; }
    }
}