using Blockfrost.Api;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Blockfrost.Extensions.CardanoSharp.Utils
{
    public static class AddressCollectionExtensions
    {
        public static uint SumAmounts(this ICollection<AddressUTxOResponse> collection, string unit = "lovelace")
        {
            return (uint)collection.Sum(utxo => utxo.ToUint32(unit));
        }

        /// <summary>
        /// Sums the utxo amounts of the specified unit
        /// </summary>
        /// <param name="utxo"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static uint ToUint32(this AddressUTxOResponse utxo, string unit = "lovelace")
        {
            return (uint)utxo.Amount.Where(amnt => amnt.Unit.Equals(unit, System.StringComparison.Ordinal)).Sum(amnt => uint.Parse(amnt.Quantity, NumberStyles.Integer, CultureInfo.InvariantCulture));
        }
    }
}
