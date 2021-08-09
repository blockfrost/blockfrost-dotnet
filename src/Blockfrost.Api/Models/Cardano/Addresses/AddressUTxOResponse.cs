using System.Collections.Generic;

//namespace Blockfrost.Api.Models.Cardano.Addresses
namespace Blockfrost.Api
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AddressUTxOResponse
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
}