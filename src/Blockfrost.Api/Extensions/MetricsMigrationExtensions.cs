// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Api.Migrate
{
    public static class MetricsMigrationExtensions
    {
        public static Task<Models.MetricsResponseCollection> GetMetricsAsync<T>(this IServiceMigration<T> service)
            where T : IBlockfrostService
        {
            return GetMetricsAsync(service, CancellationToken.None);
        }

        public static Task<Models.MetricsResponseCollection> GetMetricsAsync<T>(this IServiceMigration<T> service, CancellationToken cancellationToken)
            where T : IBlockfrostService
        {
            return MetricsFrom(service).GetMetricsAsync(cancellationToken);
        }

        public static Task<Models.MetricsEndpointsResponseCollection> EndpointAsync<T>(this IServiceMigration<T> service)
            where T : IBlockfrostService
        {
            return EndpointAsync(service, CancellationToken.None);
        }

        public static Task<Models.MetricsEndpointsResponseCollection> EndpointAsync<T>(this IServiceMigration<T> service, CancellationToken cancellationToken)
            where T : IBlockfrostService
        {
            return MetricsFrom(service).GetEndpointsAsync(cancellationToken);
        }

        private static IMetricsService MetricsFrom<T>(IServiceMigration<T> service)
            where T : IBlockfrostService
        {
            return service switch
            {
                IAddressService => (service as IAddressService).V1.Metrics,
                IAccountService => (service as IAccountService).V1.Metrics,
                IAssetService => (service as IAssetService).V1.Metrics,
                IBlockService => (service as IBlockService).V1.Metrics,
                IEpochService => (service as IEpochService).V1.Metrics,
                ILedgerService => (service as ILedgerService).V1.Metrics,
                IMetadataService => (service as IMetadataService).V1.Metrics,
                INetworkService => (service as INetworkService).V1.Metrics,
                IPoolService => (service as IPoolService).V1.Metrics,
                ITransactionService => (service as ITransactionService).V1.Metrics,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
