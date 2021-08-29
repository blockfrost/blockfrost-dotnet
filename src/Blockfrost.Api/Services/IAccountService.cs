using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface IAccountService : IBlockfrostService
    {
        Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressesAddressesResponse>> AddressesAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressAddressesAssetsResponse>> AssetsAllAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressDelegationsResponse>> Delegations2Async(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<Account> GetAccountsAsync(string stake_address);

        Task<Account> GetAccountsAsync(string stake_address, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<StakeAddressHistoryResponse>> HistoryAsync(string stake_address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<StakeAddressMirsResponse>> Mirs2Async(string stake_address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressRegistrationsResponse>> RegistrationsAsync(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order);

        Task<ICollection<Anonymous9>> RewardsAsync(string stake_address, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<StakeAddressWithdrawalsResponse>> Withdrawals2Async(string stake_address, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);
    }
}
