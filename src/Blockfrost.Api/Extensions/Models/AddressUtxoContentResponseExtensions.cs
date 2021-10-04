using System;
using System.Globalization;
using System.Linq;

namespace Blockfrost.Api.Models.Extensions
{
    public static class AddressUtxoContentResponseExtensions
    {
        public static long SumAmounts(this AddressUtxoContentResponse model, string unit = "lovelace")
        {
            return model.Amount.Where(m => m.Unit.Equals(unit, StringComparison.OrdinalIgnoreCase)).Sum(a => long.Parse(a.Quantity, NumberStyles.Integer, CultureInfo.InvariantCulture));
        }
    }

    public static class AddressUtxoContentResponseCollectionExtensions
    {
        public static long SumAmounts(this AddressUtxoContentResponseCollection model, string unit = "lovelace")
        {
            return model.Sum(m => m.SumAmounts(unit));
        }
    }
}
