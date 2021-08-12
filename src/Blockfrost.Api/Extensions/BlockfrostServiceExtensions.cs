using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;

namespace Blockfrost.Api.Extensions
{
    public static class BlockfrostServiceExtensions
    {
        /// <summary>
        /// Adds a new <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAAccountService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IAccountService, AccountService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IAddressService, AddressService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IServiceCollection AddAddressService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            services.ConfigureBlockfrost(projectName, config);
            services.AddBlockfrostService<IAddressService, AddressService>(projectName);
            return services;
        }

        /// <summary>
        /// Adds a new <see cref="IAssetService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAssetService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IAssetService, AssetService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IBlockfrostService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBasicBlockfrostService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IBlockfrostService, BasicBlockfrostService>(projectName);
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey)
        {
            services.TryAddScoped(_ => new BlockfrostAuthorizationHandler(apiKey));
            services.AddHttpClient<IBlockfrostService, BasicBlockfrostService>(client => ServiceFactory<BasicBlockfrostService>(client, network))
                .AddHttpMessageHandler<BlockfrostAuthorizationHandler>();

            return services;
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            services.ConfigureBlockfrost(projectName, configuration);
            services.AddCardanoServices(projectName, configuration);
            return services;
        }

        /// <summary>
        /// Adds the IHttpClientFactory and related services to the IServiceCollection and configures a binding between the TClient type and a named HttpClient.
        /// </summary>
        /// <typeparam name="TClient">The type of the typed blockfrost service. They type specified will be registered in the service collection as a transient service. See ITypedHttpClientFactory<TClient> for more details about authoring typed clients.</typeparam>
        /// <typeparam name="TImplementation">The implementation type of the typed blockfrost service. They type specified will be instantiated by the ITypedHttpClientFactory<TClient>.</typeparam>
        /// <param name="services">The IServiceCollection.</param>
        /// <param name="name">The logical name of the HttpClient to configure.</param>
        /// <param name="configureClient">A delegate that is used to configure an HttpClient.</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockfrostService<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string name, Action<IServiceProvider, HttpClient> configureClient)
            where TClient : class
            where TImplementation : class, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>(name, configureClient)
                           .AddHttpMessageHandler<BlockfrostAuthorizationHandler>();
        }

        /// <summary>
        /// Adds the IHttpClientFactory and related services to the IServiceCollection and configures a binding between the TClient type and a named HttpClient.
        /// </summary>
        /// <typeparam name="TClient">The type of the typed blockfrost service. They type specified will be registered in the service collection as a transient service. See ITypedHttpClientFactory<TClient> for more details about authoring typed clients.</typeparam>
        /// <typeparam name="TImplementation">The implementation type of the typed blockfrost service. They type specified will be instantiated by the ITypedHttpClientFactory<TClient>.</typeparam>
        /// <param name="services">The IServiceCollection.</param>
        /// <param name="name">The logical name of the HttpClient to configure.</param>
        public static IHttpClientBuilder AddBlockfrostService<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string name)
            where TClient : class
            where TImplementation : ABlockfrostService, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>(name, (client, provider) =>
            {
                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                var service = ServiceFactory<TImplementation>(client, options.Value[name].Network);
                return service;
            });
        }

        /// <summary>
        /// Adds a new <see cref="IBlockService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IBlockService, BlockService>(projectName);
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddCardanoServices(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            services.TryAddTransient(provider =>
            {
                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                return new BlockfrostAuthorizationHandler(options.Value[projectName].ApiKey);
            });

            services.AddBasicBlockfrostService(projectName);
            services.AddAddressService(projectName);

            return services;
        }

        /// <summary>
        /// Adds a new <see cref="IEpochService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddEpochService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IEpochService, EpochService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="ILedgerService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddLedgerService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<ILedgerService, LedgerService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IMetadataService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddMetadataService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IMetadataService, MetadataService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="INetworkService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddNetworkService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<INetworkService, NetworkService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IPoolService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddPoolService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IPoolService, PoolService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="ITransactionService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<ITransactionService, TransactionService>(projectName);
        }

        public static IServiceCollection ConfigureBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            if (!services.Any(s => s.ServiceType.FullName.Contains(typeof(IOptions<BlockfrostOptions>).Name)))
            {
                services.Configure<BlockfrostOptions>(configuration.GetSection("Blockfrost"));
            }

            services.TryAddTransient(provider =>
            {
                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                return new BlockfrostAuthorizationHandler(options.Value[projectName].ApiKey);
            });
            return services;
        }

        /// <summary>
        /// Helper to configure the BaseAddress of the HttpClient used in the BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="network"></param>
        private static void ConfigureHttpClient(HttpClient client, string network)
        {
            switch (network)
            {
                case "testnet":
                    client.BaseAddress = new Uri("https://cardano-testnet.blockfrost.io/api/v0/");
                    break;

                case "mainnet":
                    client.BaseAddress = new Uri("https://cardano-mainnet.blockfrost.io/api/v0/");
                    break;

                case "ipfs":
                    client.BaseAddress = new Uri("https://ipfs.blockfrost.io/api/v0/");
                    break;

                default:
                    throw new NotSupportedException($"The specified network '{network}' is not supported");
            }
        }

        /// <summary>
        /// Helper factory to configure the requested BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="client"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        private static TService ServiceFactory<TService>(HttpClient client, string network) where TService : ABlockfrostService
        {
            ConfigureHttpClient(client, network);
            TService blockfrostService = (TService)Activator.CreateInstance(typeof(TService), new object[] { client });
            blockfrostService.Network = network;
            return blockfrostService;
        }
    }
}
