using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial interface IAddressService : IServiceMigration<IAddressesService>
    {
        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<AddressResponse> AddressAsync(string address, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<AddressResponse> AddressesAsync(string address);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<AddressContentTotal> AddressTotalAsync(string address, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<AddressTransactionResponse>> AddressTransactionsAsync(string address, int? count, int? page,
            ESortOrder? order, string from, string to, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<string>> AddressTxsAsync(string address, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<AddressUTxOResponse>> AddressUtxoAsync(string address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<AddressContentTotal> TotalAsync(string address);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<AddressTransactionResponse>> TransactionsAsync(string address, int? count, int? page,
            ESortOrder? order, string from, string to);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<string>> TxsAll3Async(string address, int? count, int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<AddressUTxOResponse>> UtxosAllAsync(string address, int? count, int? page, ESortOrder? order);
    }
}
