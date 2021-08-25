using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockfrost.Extensions.CardanoSharp
{
    public class CardanoSharpExtensionOptions
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public uint Amount { get; set; }
        public uint Fee { get; set; }
        public string SKey { get; set; }
        public uint SpendingLimit { get; internal set; }
        public int UtxoSpendLimit { get; internal set; }
        public string Unit { get; internal set; } = "lovelace";
        //public string Mnemonic { get; set; }
    }
}
