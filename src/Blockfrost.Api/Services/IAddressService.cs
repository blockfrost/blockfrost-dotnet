using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface IAddressService : IBlockfrostService
    {
        Task<AddressResponse> AddressAsync(string address, CancellationToken cancellationToken);

        Task<AddressResponse> AddressesAsync(string address);

        Task<AddressContentTotal> AddressTotalAsync(string address, CancellationToken cancellationToken);

        Task<ICollection<AddressTransactionResponse>> AddressTransactionsAsync(string address, int? count, int? page,
            ESortOrder? order, string from, string to, CancellationToken cancellationToken);

        Task<ICollection<string>> AddressTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<AddressUTxOResponse>> AddressUtxoAsync(string address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<AddressContentTotal> TotalAsync(string address);

        Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page,
            ESortOrder? order, string from, string to);

        Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order);

        Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order);
    }
}
