// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

namespace Blockfrost.Api
{
    public interface ICardanoService :
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
