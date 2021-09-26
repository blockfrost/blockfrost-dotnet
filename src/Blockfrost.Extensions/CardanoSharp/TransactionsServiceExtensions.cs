using System.Threading.Tasks;
using CardanoSharp.Wallet.Extensions.Models.Transactions;
using CardanoSharp.Wallet.Models.Transactions;
using Blockfrost.Api.Services;
using Blockfrost.Api.Extensions.Services;
using System.Threading;

namespace Blockfrost.Extensions.CardanoSharp
{
    public static class CardanoSharpTransactionsServiceExtensions
    {
        public static Task<string> PostTxSubmitAsync(this ITransactionsService service, Transaction transaction)
        {
            return service.PostTxSubmitAsync(transaction.Serialize());
        }

        public static Task<string> PostTxSubmitAsync(this ITransactionsService service, Transaction transaction, CancellationToken cancellationToken)
        {
            return service.PostTxSubmitAsync(transaction.Serialize(), cancellationToken);
        }
    }
}
