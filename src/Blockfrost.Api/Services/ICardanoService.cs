
namespace Blockfrost.Api.Services
{
    public partial interface ICardanoService : IBlockfrostService
    {
        IHealthService Health { get; }
        IMetricsService Metrics { get; }
        IAccountsService Accounts { get; }
        IAddressesService Addresses { get; }
        IAssetsService Assets { get; }
        IBlocksService Blocks { get; }
        IEpochsService Epochs { get; }
        Services.ILedgerService Ledger { get; }
        Services.IMetadataService Metadata { get; }
        IPoolsService Pools { get; }
        ITransactionsService Transactions { get; }
    }
}
