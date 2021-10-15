using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Models;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial class CardanoService : ICardanoService
    {
        public CardanoService(
            IHealthService health,
            IMetricsService metrics,
            IAccountsService accounts,
            IAddressesService addresses,
            IAssetsService assets,
            IBlocksService blocks,
            IEpochsService epochs,
            ILedgerService ledger,
            IMetadataService metadata,
            IPoolsService pools,
            ITransactionsService transactions)
        {
            Health = health;
            Metrics = metrics;
            Accounts = accounts;
            Addresses = addresses;
            Assets = assets;
            Blocks = blocks;
            Epochs = epochs;
            Ledger = ledger;
            Metadata = metadata;
            Pools = pools;
            Transactions = transactions;
        }

        public IAccountsService Accounts { get; }
        public IAddressesService Addresses { get; }
        public IAssetsService Assets { get; }
        public IBlocksService Blocks { get; }
        public IEpochsService Epochs { get; }
        public ILedgerService Ledger { get; }
        public IMetadataService Metadata { get; }
        public IPoolsService Pools { get; }
        public ITransactionsService Transactions { get; }
        public IHealthService Health { get; }
        public IMetricsService Metrics { get; }

        public string Network { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public bool ReadResponseAsString { get; set; }
    }
}
