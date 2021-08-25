using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blockfrost.Extensions.CardanoSharp
{
    public class CardanoSharpExtensionOptions
    {
        [JsonPropertyName("sender")]
        public string Sender { get; set; }
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }
        [JsonPropertyName("amount")]
        public uint Amount { get; set; }
        [JsonPropertyName("fee")]
        public uint Fee { get; set; }
        [JsonPropertyName("skey")]
        public string SKey { get; set; }
        [JsonPropertyName("spendingLimit")]
        public uint SpendingLimit { get; set; }
        [JsonPropertyName("utxoSpendingLimit")]
        public int UtxoSpendLimit { get;  set; }
        [JsonPropertyName("unit")]
        public string Unit { get; internal set; } = "lovelace";
        //public string Mnemonic { get; set; }
    }
}
