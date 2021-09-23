// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Api.Migrate.Extensions
{
    public static class HealthMigrationExtensions
    {
        public static Task<Models.HealthResponse> GetHealthAsync<T>(this IServiceMigration<T> service)
            where T : IBlockfrostService
        {
            return GetHealthAsync(service, CancellationToken.None);
        }

        public static Task<Models.HealthResponse> GetHealthAsync<T>(this IServiceMigration<T> service, CancellationToken cancellationToken)
                    where T : IBlockfrostService
        {
            return HealthFrom(service).GetHealthAsync(cancellationToken);
        }

        public static Task<Models.HealthClockResponse> GetClockAsync<T>(this IServiceMigration<T> service)
            where T : IBlockfrostService
        {
            return GetClockAsync(service, CancellationToken.None);
        }

        public static Task<Models.HealthClockResponse> GetClockAsync<T>(this IServiceMigration<T> service, CancellationToken cancellationToken)
                    where T : IBlockfrostService
        {
            return HealthFrom(service).GetClockAsync(cancellationToken);
        }

        public static Task<Models.InfoResponse> GetInfoAsync<T>(this IServiceMigration<T> service)
            where T : IBlockfrostService
        {
            return GetInfoAsync(service, CancellationToken.None);
        }

        public static Task<Models.InfoResponse> GetInfoAsync<T>(this IServiceMigration<T> service, CancellationToken cancellationToken)
            where T : IBlockfrostService
        {
            return HealthFrom(service).GetApiInfoAsync(cancellationToken);
        }

        private static IHealthService HealthFrom<T>(IServiceMigration<T> service) where T : IBlockfrostService
        {
            return service switch
            {
                IAddressService => (service as IAddressService).V1.Health,
                IAccountService => (service as IAccountService).V1.Health,
                IAssetService => (service as IAssetService).V1.Health,
                IBlockService => (service as IBlockService).V1.Health,
                IEpochService => (service as IEpochService).V1.Health,
                ILedgerService => (service as ILedgerService).V1.Health,
                IMetadataService => (service as IMetadataService).V1.Health,
                INetworkService => (service as INetworkService).V1.Health,
                IPoolService => (service as IPoolService).V1.Health,
                ITransactionService => (service as ITransactionService).V1.Health,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
