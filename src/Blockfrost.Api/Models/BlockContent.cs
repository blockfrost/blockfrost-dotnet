using System.Collections.Generic;

namespace Blockfrost.Api
{
    // TODO: review (obsolete?)
    public partial class BlockContentCollection : System.Collections.ObjectModel.Collection<BlockContent>
    {
    }

    // TODO: review (obsolete?)
    public partial class BlockContentTransactionIds : System.Collections.ObjectModel.Collection<string>
    {
    }


    public partial class BlockContent
    {
        /// <summary>Block creation time in UNIX time</summary>
        [Newtonsoft.Json.JsonProperty("time", Required = Newtonsoft.Json.Required.Always)]
        public int Time { get; set; }

        /// <summary>Block number</summary>
        [Newtonsoft.Json.JsonProperty("height", Required = Newtonsoft.Json.Required.AllowNull)]
        public int? Height { get; set; }

        /// <summary>Hash of the block</summary>
        [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Hash { get; set; }

        /// <summary>Slot number</summary>
        [Newtonsoft.Json.JsonProperty("slot", Required = Newtonsoft.Json.Required.AllowNull)]
        public int? Slot { get; set; }

        /// <summary>Epoch number</summary>
        [Newtonsoft.Json.JsonProperty("epoch", Required = Newtonsoft.Json.Required.AllowNull)]
        public int? Epoch { get; set; }

        /// <summary>Slot within the epoch</summary>
        [Newtonsoft.Json.JsonProperty("epoch_slot", Required = Newtonsoft.Json.Required.AllowNull)]
        public int? EpochSlot { get; set; }

        /// <summary>Bech32 ID of the slot leader or specific block description in case there is no slot leader</summary>
        [Newtonsoft.Json.JsonProperty("slot_leader", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string SlotLeader { get; set; }

        /// <summary>Block size in Bytes</summary>
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
        public int Size { get; set; }

        /// <summary>Number of transactions in the block</summary>
        [Newtonsoft.Json.JsonProperty("tx_count", Required = Newtonsoft.Json.Required.Always)]
        public int TxCount { get; set; }

        /// <summary>Total output within the block in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("output", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Output { get; set; }

        /// <summary>Total fees within the block in Lovelaces</summary>
        [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Fees { get; set; }

        /// <summary>VRF key of the block</summary>
        [Newtonsoft.Json.JsonProperty("block_vrf", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.StringLength(65, MinimumLength = 65)]
        public string BlockVrf { get; set; }

        /// <summary>Hash of the previous block</summary>
        [Newtonsoft.Json.JsonProperty("previous_block", Required = Newtonsoft.Json.Required.AllowNull)]
        public string PreviousBlock { get; set; }

        /// <summary>Hash of the next block</summary>
        [Newtonsoft.Json.JsonProperty("next_block", Required = Newtonsoft.Json.Required.AllowNull)]
        public string NextBlock { get; set; }

        /// <summary>Number of block confirmations</summary>
        [Newtonsoft.Json.JsonProperty("confirmations", Required = Newtonsoft.Json.Required.Always)]
        public int Confirmations { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}
