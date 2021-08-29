namespace Blockfrost.Api
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
        IAccountService Accounts { get; }
        IAddressService Addresses { get; }
        IAssetService Assets { get; }
        IBlockService Blocks { get; }
        IEpochService Epochs { get; }
        ILedgerService Ledger { get; }
        IMetadataService Metadata { get; }
        IPoolService Pools { get; }
        ITransactionService Transactions { get; }
    }
}
