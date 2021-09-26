
namespace Blockfrost.Api.Services
{
    public partial interface ICardanoService :
        IBlockfrostService,
        IAccountService,
        IAddressService,
        IAssetService,
        IBlockService,
        IEpochService,
        IPoolService,
        ILedgerService,
        IMetadataService,
        ITransactionService
    {
        IAccountsService Accounts { get; }
        IAddressesService Addresses { get; }
        IAssetsService Assets { get; }
        IBlocksService Blocks { get; }
        IEpochsService Epochs { get; }
        ILedgerService Ledger { get; }
        IMetadataService Metadata { get; }
        IPoolsService Pools { get; }
        ITransactionsService Transactions { get; }
    }
}
