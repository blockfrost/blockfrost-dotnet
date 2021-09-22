using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial interface IAccountService : IServiceMigration<IAccountsService>
    {
        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count,
            int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<Account> GetAccountsAsync(string stake_address);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<Account> GetAccountsAsync(string stake_address, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page,
            ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page,
            ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count,
            int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}
