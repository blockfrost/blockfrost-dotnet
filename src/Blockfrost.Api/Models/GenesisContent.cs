using System.Collections.Generic;

namespace Blockfrost.Api
{
    public partial class GenesisContent
    {
        /// <summary>The proportion of slots in which blocks should be issued</summary>
        [Newtonsoft.Json.JsonProperty("active_slots_coefficient", Required = Newtonsoft.Json.Required.Always)]
        public double ActiveSlotsCoefficient { get; set; }

        /// <summary>Determines the quorum needed for votes on the protocol parameter updates</summary>
        [Newtonsoft.Json.JsonProperty("update_quorum", Required = Newtonsoft.Json.Required.Always)]
        public int UpdateQuorum { get; set; }

        /// <summary>The total number of lovelace in the system</summary>
        [Newtonsoft.Json.JsonProperty("max_lovelace_supply", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string MaxLovelaceSupply { get; set; }

        /// <summary>Network identifier</summary>
        [Newtonsoft.Json.JsonProperty("network_magic", Required = Newtonsoft.Json.Required.Always)]
        public int NetworkMagic { get; set; }

        /// <summary>Number of slots in an epoch</summary>
        [Newtonsoft.Json.JsonProperty("epoch_length", Required = Newtonsoft.Json.Required.Always)]
        public int EpochLength { get; set; }

        /// <summary>Time of slot 0 in UNIX time</summary>
        [Newtonsoft.Json.JsonProperty("system_start", Required = Newtonsoft.Json.Required.Always)]
        public int SystemStart { get; set; }

        /// <summary>Number of slots in an KES period</summary>
        [Newtonsoft.Json.JsonProperty("slots_per_kes_period", Required = Newtonsoft.Json.Required.Always)]
        public int SlotsPerKesPeriod { get; set; }

        /// <summary>Duration of one slot in seconds</summary>
        [Newtonsoft.Json.JsonProperty("slot_length", Required = Newtonsoft.Json.Required.Always)]
        public int SlotLength { get; set; }

        /// <summary>The maximum number of time a KES key can be evolved before a pool operator must create a new operational certificate</summary>
        [Newtonsoft.Json.JsonProperty("max_kes_evolutions", Required = Newtonsoft.Json.Required.Always)]
        public int MaxKesEvolutions { get; set; }

        /// <summary>Security parameter k</summary>
        [Newtonsoft.Json.JsonProperty("security_param", Required = Newtonsoft.Json.Required.Always)]
        public int SecurityParam { get; set; }

        private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}
