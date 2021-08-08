#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blockfrost.Api
{


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Genesis_content
    {
        /// <summary>The proportion of slots in which blocks should be issued</summary>
        [Newtonsoft.Json.JsonProperty("active_slots_coefficient", Required = Newtonsoft.Json.Required.Always)]
        public double Active_slots_coefficient { get; set; }

        /// <summary>Determines the quorum needed for votes on the protocol parameter updates</summary>
        [Newtonsoft.Json.JsonProperty("update_quorum", Required = Newtonsoft.Json.Required.Always)]
        public int Update_quorum { get; set; }

        /// <summary>The total number of lovelace in the system</summary>
        [Newtonsoft.Json.JsonProperty("max_lovelace_supply", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Max_lovelace_supply { get; set; }

        /// <summary>Network identifier</summary>
        [Newtonsoft.Json.JsonProperty("network_magic", Required = Newtonsoft.Json.Required.Always)]
        public int Network_magic { get; set; }

        /// <summary>Number of slots in an epoch</summary>
        [Newtonsoft.Json.JsonProperty("epoch_length", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch_length { get; set; }

        /// <summary>Time of slot 0 in UNIX time</summary>
        [Newtonsoft.Json.JsonProperty("system_start", Required = Newtonsoft.Json.Required.Always)]
        public int System_start { get; set; }

        /// <summary>Number of slots in an KES period</summary>
        [Newtonsoft.Json.JsonProperty("slots_per_kes_period", Required = Newtonsoft.Json.Required.Always)]
        public int Slots_per_kes_period { get; set; }

        /// <summary>Duration of one slot in seconds</summary>
        [Newtonsoft.Json.JsonProperty("slot_length", Required = Newtonsoft.Json.Required.Always)]
        public int Slot_length { get; set; }

        /// <summary>The maximum number of time a KES key can be evolved before a pool operator must create a new operational certificate</summary>
        [Newtonsoft.Json.JsonProperty("max_kes_evolutions", Required = Newtonsoft.Json.Required.Always)]
        public int Max_kes_evolutions { get; set; }

        /// <summary>Security parameter k</summary>
        [Newtonsoft.Json.JsonProperty("security_param", Required = Newtonsoft.Json.Required.Always)]
        public int Security_param { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Epoch_content_array : System.Collections.ObjectModel.Collection<Epoch_content>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Epoch_content
    {
        /// <summary>Epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        /// <summary>Unix time of the start of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("start_time", Required = Newtonsoft.Json.Required.Always)]
        public int Start_time { get; set; }

        /// <summary>Unix time of the end of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("end_time", Required = Newtonsoft.Json.Required.Always)]
        public int End_time { get; set; }

        /// <summary>Unix time of the first block of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("first_block_time", Required = Newtonsoft.Json.Required.Always)]
        public int First_block_time { get; set; }

        /// <summary>Unix time of the last block of the epoch</summary>
        [Newtonsoft.Json.JsonProperty("last_block_time", Required = Newtonsoft.Json.Required.Always)]
        public int Last_block_time { get; set; }

        /// <summary>Number of blocks within the epoch</summary>
        [Newtonsoft.Json.JsonProperty("block_count", Required = Newtonsoft.Json.Required.Always)]
        public int Block_count { get; set; }

        /// <summary>Number of transactions within the epoch</summary>
        [Newtonsoft.Json.JsonProperty("tx_count", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_count { get; set; }

        /// <summary>Sum of all the transactions within the epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("output", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Output { get; set; }

        /// <summary>Sum of all the fees within the epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fees { get; set; }

        /// <summary>Sum of all the active stakes within the epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("active_stake", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Active_stake { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Epoch_stake_content : System.Collections.ObjectModel.Collection<Anonymous>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Epoch_stake_pool_content : System.Collections.ObjectModel.Collection<Anonymous2>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Epoch_block_content : System.Collections.ObjectModel.Collection<string>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Epoch_param_content
    {
        /// <summary>Epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        /// <summary>The linear factor for the minimum fee calculation for given epoch</summary>
        [Newtonsoft.Json.JsonProperty("min_fee_a", Required = Newtonsoft.Json.Required.Always)]
        public int Min_fee_a { get; set; }

        /// <summary>The constant factor for the minimum fee calculation</summary>
        [Newtonsoft.Json.JsonProperty("min_fee_b", Required = Newtonsoft.Json.Required.Always)]
        public int Min_fee_b { get; set; }

        /// <summary>Maximum block body size in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("max_block_size", Required = Newtonsoft.Json.Required.Always)]
        public int Max_block_size { get; set; }

        /// <summary>Maximum transaction size</summary>
        [Newtonsoft.Json.JsonProperty("max_tx_size", Required = Newtonsoft.Json.Required.Always)]
        public int Max_tx_size { get; set; }

        /// <summary>Maximum block header size</summary>
        [Newtonsoft.Json.JsonProperty("max_block_header_size", Required = Newtonsoft.Json.Required.Always)]
        public int Max_block_header_size { get; set; }

        /// <summary>The amount of a key registration deposit in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("key_deposit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Key_deposit { get; set; }

        /// <summary>The amount of a pool registration deposit in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("pool_deposit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_deposit { get; set; }

        /// <summary>Epoch bound on pool retirement</summary>
        [Newtonsoft.Json.JsonProperty("e_max", Required = Newtonsoft.Json.Required.Always)]
        public int E_max { get; set; }

        /// <summary>Desired number of pools</summary>
        [Newtonsoft.Json.JsonProperty("n_opt", Required = Newtonsoft.Json.Required.Always)]
        public int N_opt { get; set; }

        /// <summary>Pool pledge influence</summary>
        [Newtonsoft.Json.JsonProperty("a0", Required = Newtonsoft.Json.Required.Always)]
        public double A0 { get; set; }

        /// <summary>Monetary expansion</summary>
        [Newtonsoft.Json.JsonProperty("rho", Required = Newtonsoft.Json.Required.Always)]
        public double Rho { get; set; }

        /// <summary>Treasury expansion</summary>
        [Newtonsoft.Json.JsonProperty("tau", Required = Newtonsoft.Json.Required.Always)]
        public double Tau { get; set; }

        /// <summary>Percentage of blocks produced by federated nodes</summary>
        [Newtonsoft.Json.JsonProperty("decentralisation_param", Required = Newtonsoft.Json.Required.Always)]
        public double Decentralisation_param { get; set; }

        /// <summary>Seed for extra entropy</summary>
        [Newtonsoft.Json.JsonProperty("extra_entropy", Required = Newtonsoft.Json.Required.AllowNull)]
        public object Extra_entropy { get; set; }

        /// <summary>Accepted protocol major version</summary>
        [Newtonsoft.Json.JsonProperty("protocol_major_ver", Required = Newtonsoft.Json.Required.Always)]
        public int Protocol_major_ver { get; set; }

        /// <summary>Accepted protocol minor version</summary>
        [Newtonsoft.Json.JsonProperty("protocol_minor_ver", Required = Newtonsoft.Json.Required.Always)]
        public int Protocol_minor_ver { get; set; }

        /// <summary>Minimum UTXO value</summary>
        [Newtonsoft.Json.JsonProperty("min_utxo", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Min_utxo { get; set; }

        /// <summary>Minimum stake cost forced on the pool</summary>
        [Newtonsoft.Json.JsonProperty("min_pool_cost", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Min_pool_cost { get; set; }

        /// <summary>Epoch number only used once</summary>
        [Newtonsoft.Json.JsonProperty("nonce", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Nonce { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content
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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_utxo
    {
        /// <summary>Transaction hash</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("inputs", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Inputs> Inputs { get; set; } = new System.Collections.ObjectModel.Collection<Inputs>();

        [Newtonsoft.Json.JsonProperty("outputs", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Outputs> Outputs { get; set; } = new System.Collections.ObjectModel.Collection<Outputs>();

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_stake_addr : System.Collections.ObjectModel.Collection<Anonymous3>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_delegations : System.Collections.ObjectModel.Collection<Anonymous4>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_withdrawals : System.Collections.ObjectModel.Collection<Anonymous5>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_mirs : System.Collections.ObjectModel.Collection<Anonymous6>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_pool_certs : System.Collections.ObjectModel.Collection<Anonymous38>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_pool_retires : System.Collections.ObjectModel.Collection<Anonymous39>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_metadata : System.Collections.ObjectModel.Collection<Anonymous7>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_content_metadata_cbor : System.Collections.ObjectModel.Collection<Anonymous8>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_content
    {
        /// <summary>Bech32 stake address</summary>
        [Newtonsoft.Json.JsonProperty("stake_address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Stake_address { get; set; }

        /// <summary>Registration state of an account</summary>
        [Newtonsoft.Json.JsonProperty("active", Required = Newtonsoft.Json.Required.Always)]
        public bool Active { get; set; }

        /// <summary>Epoch of the most recent action - registration or deregistration</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        /// <summary>Balance of the account in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("controlled_amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Controlled_amount { get; set; }

        /// <summary>Sum of all rewards for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("rewards_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Rewards_sum { get; set; }

        /// <summary>Sum of all the withdrawals for the account in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("withdrawals_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Withdrawals_sum { get; set; }

        /// <summary>Sum of all  funds from reserves for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("reserves_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Reserves_sum { get; set; }

        /// <summary>Sum of all funds from treasury for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("treasury_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Treasury_sum { get; set; }

        /// <summary>Sum of available rewards that haven't been withdrawn yet for the account in the Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("withdrawable_amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Withdrawable_amount { get; set; }

        /// <summary>Bech32 pool ID that owns the account</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Pool_id { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_addresses_content : System.Collections.ObjectModel.Collection<Anonymous15>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_addresses_assets : System.Collections.ObjectModel.Collection<Anonymous16>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_reward_content : System.Collections.ObjectModel.Collection<Anonymous9>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_delegation_content : System.Collections.ObjectModel.Collection<Anonymous11>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_history_content : System.Collections.ObjectModel.Collection<Anonymous10>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_registration_content : System.Collections.ObjectModel.Collection<Anonymous12>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_withdrawal_content : System.Collections.ObjectModel.Collection<Anonymous13>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Account_mir_content : System.Collections.ObjectModel.Collection<Anonymous14>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Address_content
    {
        /// <summary>Bech32 encoded addresses</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Amount> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount>();

        /// <summary>Stake address that controls the key</summary>
        [Newtonsoft.Json.JsonProperty("stake_address", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Stake_address { get; set; }

        /// <summary>Address era</summary>
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Address_contentType Type { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Address_content_total
    {
        /// <summary>Bech32 encoded address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("received_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Received_sum> Received_sum { get; set; } = new System.Collections.ObjectModel.Collection<Received_sum>();

        [Newtonsoft.Json.JsonProperty("sent_sum", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Sent_sum> Sent_sum { get; set; } = new System.Collections.ObjectModel.Collection<Sent_sum>();

        /// <summary>Count of all transactions on the address</summary>
        [Newtonsoft.Json.JsonProperty("tx_count", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_count { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Address_utxo_content : System.Collections.ObjectModel.Collection<Anonymous20>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Address_txs_content : System.Collections.ObjectModel.Collection<string>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Address_transactions_content : System.Collections.ObjectModel.Collection<Anonymous21>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_metadata_labels : System.Collections.ObjectModel.Collection<Anonymous17>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_metadata_label_json : System.Collections.ObjectModel.Collection<Anonymous18>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Tx_metadata_label_cbor : System.Collections.ObjectModel.Collection<Anonymous19>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_list : System.Collections.ObjectModel.Collection<string>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_list_retire : System.Collections.ObjectModel.Collection<Anonymous22>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_history : System.Collections.ObjectModel.Collection<Anonymous23>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool
    {
        /// <summary>Bech32 pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Hexadecimal pool ID.</summary>
        [Newtonsoft.Json.JsonProperty("hex", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hex { get; set; }

        /// <summary>VRF key hash</summary>
        [Newtonsoft.Json.JsonProperty("vrf_key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Vrf_key { get; set; }

        /// <summary>Total minted blocks</summary>
        [Newtonsoft.Json.JsonProperty("blocks_minted", Required = Newtonsoft.Json.Required.Always)]
        public int Blocks_minted { get; set; }

        [Newtonsoft.Json.JsonProperty("live_stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Live_stake { get; set; }

        [Newtonsoft.Json.JsonProperty("live_size", Required = Newtonsoft.Json.Required.Always)]
        public double Live_size { get; set; }

        [Newtonsoft.Json.JsonProperty("live_saturation", Required = Newtonsoft.Json.Required.Always)]
        public double Live_saturation { get; set; }

        [Newtonsoft.Json.JsonProperty("live_delegators", Required = Newtonsoft.Json.Required.Always)]
        public double Live_delegators { get; set; }

        [Newtonsoft.Json.JsonProperty("active_stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Active_stake { get; set; }

        [Newtonsoft.Json.JsonProperty("active_size", Required = Newtonsoft.Json.Required.Always)]
        public double Active_size { get; set; }

        /// <summary>Stake pool certificate pledge</summary>
        [Newtonsoft.Json.JsonProperty("declared_pledge", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Declared_pledge { get; set; }

        /// <summary>Stake pool current pledge</summary>
        [Newtonsoft.Json.JsonProperty("live_pledge", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Live_pledge { get; set; }

        /// <summary>Margin tax cost of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("margin_cost", Required = Newtonsoft.Json.Required.Always)]
        public double Margin_cost { get; set; }

        /// <summary>Fixed tax cost of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("fixed_cost", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fixed_cost { get; set; }

        /// <summary>Bech32 reward account of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("reward_account", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Reward_account { get; set; }

        [Newtonsoft.Json.JsonProperty("owners", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Owners { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [Newtonsoft.Json.JsonProperty("registration", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Registration { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [Newtonsoft.Json.JsonProperty("retirement", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Retirement { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_metadata
    {
        /// <summary>Bech32 pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Hexadecimal pool ID</summary>
        [Newtonsoft.Json.JsonProperty("hex", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hex { get; set; }

        /// <summary>URL to the stake pool metadata</summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Url { get; set; }

        /// <summary>Hash of the metadata file</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Hash { get; set; }

        /// <summary>Ticker of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("ticker", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ticker { get; set; }

        /// <summary>Name of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Name { get; set; }

        /// <summary>Description of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Description { get; set; }

        /// <summary>Home page of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("homepage", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Homepage { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_relays : System.Collections.ObjectModel.Collection<Anonymous24>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_delegations : System.Collections.ObjectModel.Collection<Anonymous40>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_blocks : System.Collections.ObjectModel.Collection<string>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_updates : System.Collections.ObjectModel.Collection<Anonymous26>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Pool_delegators : System.Collections.ObjectModel.Collection<Anonymous25>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Assets : System.Collections.ObjectModel.Collection<Anonymous27>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Asset
    {
        /// <summary>Hex-encoded asset full name</summary>
        [Newtonsoft.Json.JsonProperty("asset", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Asset1 { get; set; }

        /// <summary>Policy ID of the asset</summary>
        [Newtonsoft.Json.JsonProperty("policy_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Policy_id { get; set; }

        /// <summary>Hex-encoded asset name of the asset</summary>
        [Newtonsoft.Json.JsonProperty("asset_name", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Asset_name { get; set; }

        /// <summary>CIP14 based user-facing fingerprint</summary>
        [Newtonsoft.Json.JsonProperty("fingerprint", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fingerprint { get; set; }

        /// <summary>Current asset quantity</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        /// <summary>ID of the initial minting transaction</summary>
        [Newtonsoft.Json.JsonProperty("initial_mint_tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Initial_mint_tx_hash { get; set; }

        /// <summary>Count of mint and burn transactions</summary>
        [Newtonsoft.Json.JsonProperty("mint_or_burn_count", Required = Newtonsoft.Json.Required.Always)]
        public int Mint_or_burn_count { get; set; }

        /// <summary>On-chain metadata stored in the minting transaction under label 721,
        /// <br/>community discussion around the standard ongoing at https://github.com/cardano-foundation/CIPs/pull/85
        /// <br/></summary>
        [Newtonsoft.Json.JsonProperty("onchain_metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Onchain_metadata Onchain_metadata { get; set; }

        [Newtonsoft.Json.JsonProperty("metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Metadata Metadata { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Asset_history : System.Collections.ObjectModel.Collection<Anonymous28>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Asset_txs : System.Collections.ObjectModel.Collection<string>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Asset_transactions : System.Collections.ObjectModel.Collection<Anonymous29>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Asset_addresses : System.Collections.ObjectModel.Collection<Anonymous30>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Asset_policy : System.Collections.ObjectModel.Collection<Anonymous31>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metrics : System.Collections.ObjectModel.Collection<Anonymous33>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metrics_endpoints : System.Collections.ObjectModel.Collection<Anonymous34>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Nutlink_address
    {
        /// <summary>Bech32 encoded address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>URL do specific metadata file</summary>
        [Newtonsoft.Json.JsonProperty("metadata_url", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Metadata_url { get; set; }

        /// <summary>Hash of the metadata file</summary>
        [Newtonsoft.Json.JsonProperty("metadata_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Metadata_hash { get; set; }

        /// <summary>The cached metadata of the `metadata_url` file.</summary>
        [Newtonsoft.Json.JsonProperty("metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public object Metadata { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Nutlink_address_ticker : System.Collections.ObjectModel.Collection<Anonymous36>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Nutlink_address_tickers : System.Collections.ObjectModel.Collection<Anonymous35>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Nutlink_tickers_ticker : System.Collections.ObjectModel.Collection<Anonymous37>
    {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Network
    {
        [Newtonsoft.Json.JsonProperty("supply", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Supply Supply { get; set; } = new Supply();

        [Newtonsoft.Json.JsonProperty("stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Stake Stake { get; set; } = new Stake();

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Empty_object
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order2
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order3
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order4
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum ContentType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"application/cbor")]
        Application_cbor = 0,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order5
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order6
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order7
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order8
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order9
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order10
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order11
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order12
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order13
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order14
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order15
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order16
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order17
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order18
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order19
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order20
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order21
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order22
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order23
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order24
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order25
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order26
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order27
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order28
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order29
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order30
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order31
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order32
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order33
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order34
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Order35
    {
        [System.Runtime.Serialization.EnumMember(Value = @"asc")]
        Asc = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"desc")]
        Desc = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AnonymousResponse
    {
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Version { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response2
    {
        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response3
    {
        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response4
    {
        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response5
    {
        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response6
    {
        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    

    

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response9
    {
        [Newtonsoft.Json.JsonProperty("status_code", Required = Newtonsoft.Json.Required.Always)]
        public int Status_code { get; set; }

        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous
    {
        /// <summary>Stake address</summary>
        [Newtonsoft.Json.JsonProperty("stake_address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Stake_address { get; set; }

        /// <summary>Bech32 prefix of the pool delegated to</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Amount of active delegated stake in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous2
    {
        /// <summary>Stake address</summary>
        [Newtonsoft.Json.JsonProperty("stake_address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Stake_address { get; set; }

        /// <summary>Amount of active delegated stake in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous3
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Delegation stake address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Registration boolean, false if deregistration</summary>
        [Newtonsoft.Json.JsonProperty("registration", Required = Newtonsoft.Json.Required.Always)]
        public bool Registration { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous4
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
        [System.Obsolete]
        public int Index { get; set; }

        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Bech32 delegation stake address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Bech32 ID of delegated stake pool</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Epoch in which the delegation becomes active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous5
    {
        /// <summary>Bech32 withdrawal address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Withdrawal amount in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous6
    {
        /// <summary>Source of MIR funds</summary>
        [Newtonsoft.Json.JsonProperty("pot", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Pot Pot { get; set; }

        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Bech32 stake address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>MIR amount in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous7
    {
        /// <summary>Metadata label</summary>
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Label { get; set; }

        /// <summary>Content of the metadata</summary>
        [Newtonsoft.Json.JsonProperty("json_metadata", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Json_metadata { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous8
    {
        /// <summary>Metadata label</summary>
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Label { get; set; }

        /// <summary>Content of the CBOR metadata</summary>
        [Newtonsoft.Json.JsonProperty("cbor_metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Cbor_metadata { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous9
    {
        /// <summary>Epoch of the associated reward</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        /// <summary>Rewards for given epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Bech32 pool ID being delegated to</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous10
    {
        /// <summary>Epoch in which the stake was active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        /// <summary>Stake amount in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Bech32 ID of pool being delegated to</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous11
    {
        /// <summary>Epoch in which the delegation becomes active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        /// <summary>Hash of the transaction containing the delegation</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Rewards for given epoch in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        /// <summary>Bech32 ID of pool being delegated to</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous12
    {
        /// <summary>Hash of the transaction containing the (de)registration certificate</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Action in the certificate</summary>
        [Newtonsoft.Json.JsonProperty("action", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Action Action { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous13
    {
        /// <summary>Hash of the transaction containing the withdrawal</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Withdrawal amount in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous14
    {
        /// <summary>Hash of the transaction containing the MIR</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>MIR amount in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous15
    {
        /// <summary>Address associated with the stake key</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all assets of all addresses associated with a given account</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous16
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous17
    {
        /// <summary>Metadata label</summary>
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Label { get; set; }

        /// <summary>CIP10 defined description</summary>
        [Newtonsoft.Json.JsonProperty("cip10", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Cip10 { get; set; }

        /// <summary>The count of metadata entries with a specific label</summary>
        [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Count { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous18
    {
        /// <summary>Transaction hash that contains the specific metadata</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Content of the JSON metadata</summary>
        [Newtonsoft.Json.JsonProperty("json_metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Json_metadata Json_metadata { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous19
    {
        /// <summary>Transaction hash that contains the specific metadata</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Content of the CBOR metadata</summary>
        [Newtonsoft.Json.JsonProperty("cbor_metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Cbor_metadata { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous20
    {
        /// <summary>Transaction hash of the UTXO</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        [System.Obsolete]
        public int Tx_index { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [Newtonsoft.Json.JsonProperty("output_index", Required = Newtonsoft.Json.Required.Always)]
        public int Output_index { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Amount2> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount2>();

        /// <summary>Block number of the UTXO</summary>
        [Newtonsoft.Json.JsonProperty("block", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Block { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous21
    {
        /// <summary>Hash of the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_index { get; set; }

        /// <summary>Block height</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous22
    {
        /// <summary>Bech32 encoded pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Retirement epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous23
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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response10
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous24
    {
        /// <summary>IPv4 address of the relay</summary>
        [Newtonsoft.Json.JsonProperty("ipv4", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ipv4 { get; set; }

        /// <summary>IPv6 address of the relay</summary>
        [Newtonsoft.Json.JsonProperty("ipv6", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ipv6 { get; set; }

        /// <summary>DNS name of the relay</summary>
        [Newtonsoft.Json.JsonProperty("dns", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Dns { get; set; }

        /// <summary>DNS SRV entry of the relay</summary>
        [Newtonsoft.Json.JsonProperty("dns_srv", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Dns_srv { get; set; }

        /// <summary>Network port of the relay</summary>
        [Newtonsoft.Json.JsonProperty("port", Required = Newtonsoft.Json.Required.Always)]
        public int Port { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous25
    {
        /// <summary>Bech32 encoded stake addresses</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Currently delegated amount</summary>
        [Newtonsoft.Json.JsonProperty("live_stake", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Live_stake { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous26
    {
        /// <summary>Transaction ID</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Action in the certificate</summary>
        [Newtonsoft.Json.JsonProperty("action", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Action2 Action { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous27
    {
        /// <summary>Asset identifier</summary>
        [Newtonsoft.Json.JsonProperty("asset", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Asset { get; set; }

        /// <summary>Current asset quantity</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous28
    {
        /// <summary>Hash of the transaction containing the asset action</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Action executed upon the asset policy</summary>
        [Newtonsoft.Json.JsonProperty("action", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Action3 Action { get; set; }

        /// <summary>Asset amount of the specific action</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Amount { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous29
    {
        /// <summary>Hash of the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_index { get; set; }

        /// <summary>Block height</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous30
    {
        /// <summary>Address containing the specific asset</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Asset quantity on the specific address</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous31
    {
        /// <summary>Concatenation of the policy_id and hex-encoded asset_name</summary>
        [Newtonsoft.Json.JsonProperty("asset", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Asset { get; set; }

        /// <summary>Current asset quantity</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response11
    {
        /// <summary>Name of the file</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        /// <summary>IPFS hash of the file</summary>
        [Newtonsoft.Json.JsonProperty("ipfs_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the file</summary>
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
        public int Size { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response12
    {
        /// <summary>IPFS hash of the pinned object</summary>
        [Newtonsoft.Json.JsonProperty("ipfs_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>State of the pin action</summary>
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Response12State State { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous32
    {
        /// <summary>Creation time of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_created", Required = Newtonsoft.Json.Required.Always)]
        public int Time_created { get; set; }

        /// <summary>Pin time of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_pinned", Required = Newtonsoft.Json.Required.Always)]
        public int Time_pinned { get; set; }

        /// <summary>IPFS hash of the pinned object</summary>
        [Newtonsoft.Json.JsonProperty("ipfs_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the object in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Size { get; set; }

        /// <summary>State of the pinned object, which is `queued` when we are retriving object. If this
        /// <br/>is successful the state is changed to `pinned` or `failed` if not. The state `gc` means the
        /// <br/>pinned item has been garbage collected due to account being over storage quota or after it has
        /// <br/>been moved to `unpinned` state by removing the object pin.
        /// <br/></summary>
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public State State { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response13
    {
        /// <summary>Time of the creation of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_created", Required = Newtonsoft.Json.Required.Always)]
        public int Time_created { get; set; }

        /// <summary>Time of the pin of the IPFS object on our backends</summary>
        [Newtonsoft.Json.JsonProperty("time_pinned", Required = Newtonsoft.Json.Required.Always)]
        public int Time_pinned { get; set; }

        /// <summary>IPFS hash of the pinned object</summary>
        [Newtonsoft.Json.JsonProperty("ipfs_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>Size of the object in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Size { get; set; }

        /// <summary>State of the pinned object. We define 5 states: `queued`, `pinned`, `unpinned`, `failed`, `gc`.
        /// <br/>When the object is pending retrieval (i.e. after `/ipfs/pin/add/{IPFS_path}`), the state is `queued`.
        /// <br/>If the object is already successfully retrieved, state is changed to `pinned` or `failed` otherwise.
        /// <br/>When object is unpinned (i.e. after `/ipfs/pin/remove/{IPFS_path}`) it is marked for garbage collection.
        /// <br/>State `gc` means that a previously `unpinned` item has been garbage collected due to account being over storage quota.
        /// <br/></summary>
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Response13State State { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Response14
    {
        /// <summary>IPFS hash of the pinned object</summary>
        [Newtonsoft.Json.JsonProperty("ipfs_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ipfs_hash { get; set; }

        /// <summary>State of the pin action</summary>
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Response14State State { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous33
    {
        /// <summary>Starting time of the call count interval (ends midnight UTC) in UNIX time</summary>
        [Newtonsoft.Json.JsonProperty("time", Required = Newtonsoft.Json.Required.Always)]
        public int Time { get; set; }

        /// <summary>Sum of all calls for a particular day</summary>
        [Newtonsoft.Json.JsonProperty("calls", Required = Newtonsoft.Json.Required.Always)]
        public int Calls { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous34
    {
        /// <summary>Starting time of the call count interval (ends midnight UTC) in UNIX time</summary>
        [Newtonsoft.Json.JsonProperty("time", Required = Newtonsoft.Json.Required.Always)]
        public int Time { get; set; }

        /// <summary>Sum of all calls for a particular day and endpoint</summary>
        [Newtonsoft.Json.JsonProperty("calls", Required = Newtonsoft.Json.Required.Always)]
        public int Calls { get; set; }

        /// <summary>Endpoint parent name</summary>
        [Newtonsoft.Json.JsonProperty("endpoint", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Endpoint { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous35
    {
        /// <summary>Name of the ticker</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        /// <summary>Number of ticker records</summary>
        [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Always)]
        public int Count { get; set; }

        /// <summary>Block height of the latest record</summary>
        [Newtonsoft.Json.JsonProperty("latest_block", Required = Newtonsoft.Json.Required.Always)]
        public int Latest_block { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous36
    {
        /// <summary>Hash of the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Block height of the record</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_index { get; set; }

        /// <summary>Content of the ticker</summary>
        [Newtonsoft.Json.JsonProperty("payload", Required = Newtonsoft.Json.Required.Always)]
        public Payload Payload { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous37
    {
        /// <summary>Address of a metadata oracle</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>Hash of the transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Block height of the record</summary>
        [Newtonsoft.Json.JsonProperty("block_height", Required = Newtonsoft.Json.Required.Always)]
        public int Block_height { get; set; }

        /// <summary>Transaction index within the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_index", Required = Newtonsoft.Json.Required.Always)]
        public int Tx_index { get; set; }

        /// <summary>Content of the ticker</summary>
        [Newtonsoft.Json.JsonProperty("payload", Required = Newtonsoft.Json.Required.Always)]
        public Payload2 Payload { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous38
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Bech32 encoded pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>VRF key hash</summary>
        [Newtonsoft.Json.JsonProperty("vrf_key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Vrf_key { get; set; }

        /// <summary>Stake pool certificate pledge in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("pledge", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pledge { get; set; }

        /// <summary>Margin tax cost of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("margin_cost", Required = Newtonsoft.Json.Required.Always)]
        public double Margin_cost { get; set; }

        /// <summary>Fixed tax cost of the stake pool in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("fixed_cost", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fixed_cost { get; set; }

        /// <summary>Bech32 reward account of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("reward_account", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Reward_account { get; set; }

        [Newtonsoft.Json.JsonProperty("owners", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<string> Owners { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [Newtonsoft.Json.JsonProperty("metadata", Required = Newtonsoft.Json.Required.AllowNull)]
        public Metadata2 Metadata { get; set; }

        [Newtonsoft.Json.JsonProperty("relays", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Relays> Relays { get; set; } = new System.Collections.ObjectModel.Collection<Relays>();

        /// <summary>Epoch that the delegation becomes active</summary>
        [Newtonsoft.Json.JsonProperty("active_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Active_epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous39
    {
        /// <summary>Index of the certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        /// <summary>Bech32 stake pool ID</summary>
        [Newtonsoft.Json.JsonProperty("pool_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Pool_id { get; set; }

        /// <summary>Retiring epoch</summary>
        [Newtonsoft.Json.JsonProperty("retiring_epoch", Required = Newtonsoft.Json.Required.Always)]
        public int Retiring_epoch { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Output_amount
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Inputs
    {
        /// <summary>Input address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Amount3> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount3>();

        /// <summary>Hash of the UTXO transaction</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>UTXO index in the transaction</summary>
        [Newtonsoft.Json.JsonProperty("output_index", Required = Newtonsoft.Json.Required.Always)]
        public double Output_index { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Outputs
    {
        /// <summary>Output address</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ICollection<Amount4> Amount { get; set; } = new System.Collections.ObjectModel.Collection<Amount4>();

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Amount
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Address_contentType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"byron")]
        Byron = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"shelley")]
        Shelley = 1,

    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Received_sum
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Sent_sum
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous40
    {
        /// <summary>Transaction ID</summary>
        [Newtonsoft.Json.JsonProperty("tx_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tx_hash { get; set; }

        /// <summary>Certificate within the transaction</summary>
        [Newtonsoft.Json.JsonProperty("cert_index", Required = Newtonsoft.Json.Required.Always)]
        public int Cert_index { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Onchain_metadata
    {
        /// <summary>Name of the asset</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>URI of the associated asset</summary>
        [Newtonsoft.Json.JsonProperty("image", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Image { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metadata
    {
        /// <summary>Asset name</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        /// <summary>Asset description</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("ticker", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ticker { get; set; }

        /// <summary>Asset website</summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Url { get; set; }

        /// <summary>Base64 encoded logo of the asset</summary>
        [Newtonsoft.Json.JsonProperty("logo", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Logo { get; set; }

        /// <summary>Number of decimal places of the asset unit</summary>
        [Newtonsoft.Json.JsonProperty("decimals", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.Range(int.MinValue, 255)]
        public int? Decimals { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Supply
    {
        /// <summary>Maximum supply in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("max", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Max { get; set; }

        /// <summary>Current total (max supply - reserves) supply in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Total { get; set; }

        /// <summary>Current circulating (UTXOs + withdrawables) supply in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("circulating", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Circulating { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Stake
    {
        /// <summary>Current live stake in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("live", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Live { get; set; }

        /// <summary>Current active stake in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("active", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Active { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Pot
    {
        [System.Runtime.Serialization.EnumMember(Value = @"reserve")]
        Reserve = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"treasury")]
        Treasury = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Action
    {
        [System.Runtime.Serialization.EnumMember(Value = @"registered")]
        Registered = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"deregistered")]
        Deregistered = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Json_metadata
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Amount2
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Action2
    {
        [System.Runtime.Serialization.EnumMember(Value = @"registered")]
        Registered = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"deregistered")]
        Deregistered = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Action3
    {
        [System.Runtime.Serialization.EnumMember(Value = @"minted")]
        Minted = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"burned")]
        Burned = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Response12State
    {
        [System.Runtime.Serialization.EnumMember(Value = @"queued|pinned|unpinned|failed|gc")]
        Queued_pinned_unpinned_failed_gc = 0,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum State
    {
        [System.Runtime.Serialization.EnumMember(Value = @"queued|pinned|unpinned|failed|gc")]
        Queued_pinned_unpinned_failed_gc = 0,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Response13State
    {
        [System.Runtime.Serialization.EnumMember(Value = @"queued|pinned|unpinned|failed|gc")]
        Queued_pinned_unpinned_failed_gc = 0,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum Response14State
    {
        [System.Runtime.Serialization.EnumMember(Value = @"queued|pinned|unpinned|failed|gc")]
        Queued_pinned_unpinned_failed_gc = 0,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Payload
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Payload2
    {
        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metadata2
    {
        /// <summary>URL to the stake pool metadata</summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Url { get; set; }

        /// <summary>Hash of the metadata file</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Hash { get; set; }

        /// <summary>Ticker of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("ticker", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ticker { get; set; }

        /// <summary>Name of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Name { get; set; }

        /// <summary>Description of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Description { get; set; }

        /// <summary>Home page of the stake pool</summary>
        [Newtonsoft.Json.JsonProperty("homepage", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Homepage { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Relays
    {
        /// <summary>IPv4 address of the relay</summary>
        [Newtonsoft.Json.JsonProperty("ipv4", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ipv4 { get; set; }

        /// <summary>IPv6 address of the relay</summary>
        [Newtonsoft.Json.JsonProperty("ipv6", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Ipv6 { get; set; }

        /// <summary>DNS name of the relay</summary>
        [Newtonsoft.Json.JsonProperty("dns", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Dns { get; set; }

        /// <summary>DNS SRV entry of the relay</summary>
        [Newtonsoft.Json.JsonProperty("dns_srv", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Dns_srv { get; set; }

        /// <summary>Network port of the relay</summary>
        [Newtonsoft.Json.JsonProperty("port", Required = Newtonsoft.Json.Required.Always)]
        public int Port { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Amount3
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    /// <summary>The sum of all the UTXO per asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Amount4
    {
        /// <summary>The unit of the value</summary>
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The quantity of the unit</summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016