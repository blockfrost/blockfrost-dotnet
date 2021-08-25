using Blockfrost.Api.Http;
using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;

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
        public static IHttpClientBuilder AddAccountService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IAccountService, AccountService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAddressService(this IServiceCollection services, string projectName, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            return services.AddBlockfrostService<IAddressService, AddressService>(projectName, connectionLimit);
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
        /// Adds a new <see cref="ITransactionService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddTransactionService(this IServiceCollection services, string projectName, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            return services.AddBlockfrostService<ITransactionService, TransactionService>(projectName, connectionLimit);
        }

        /// <summary>
        /// Adds a new <see cref="ITransactionService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IServiceCollection AddTransactionService(this IServiceCollection services, string projectName, IConfiguration config)
        {
            services.ConfigureBlockfrost(projectName, config);
            services.AddBlockfrostService<ITransactionService, TransactionService>(projectName);
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
        public static IHttpClientBuilder AddRootService(this IServiceCollection services, string projectName)
        {
            return services.AddBlockfrostService<IBlockfrostService, RootService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IBlockfrostService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBasicBlockfrostService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<IBlockfrostService, RootService>(projectName);
        }

        /// <summary>
        /// Adds a new <see cref="IBlockfrostService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <param name="connectionLimit">The number of connections the servie will use</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddBlockfrostService(this IServiceCollection services, string projectName, int connectionLimit)
        {
            return services.AddBlockfrostService<IBlockfrostService, RootService>(projectName);
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
            return services.AddBlockfrost(network, apiKey, Constants.CONNECTION_LIMIT);
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <param name="connectionLimit">The number of connections the services will use.</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            var projectName = $"blockfrost-{network}-project";

            services.ConfigureBlockfrost(network, apiKey, projectName, connectionLimit);
            services.AddCardanoServices(projectName);
            return services;
        }

        public static void ConfigureBlockfrost(this IServiceCollection services, string network, string apiKey, string projectName, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            if (connectionLimit > Constants.CONNECTION_LIMIT)
            {
                throw new ArgumentOutOfRangeException(nameof(connectionLimit), $"Connections are limited to {Constants.CONNECTION_LIMIT}");
            }
            
            services.TryAddSingleton<BlockfrostAuthorizationHandler>();
            services.TryAddSingleton<RequestThrottler>();
            services.TryAddSingleton(new BlockfrostProject()
            {
                ApiKey = apiKey,
                ConnectionLimit = $"{connectionLimit}",
                Name = projectName,
                Network = network
            });

            services
                .AddOptions<BlockfrostOptions>()
                .Configure<BlockfrostProject>((projects,project) =>
                {
                    projects.Add(projectName, project);
                });
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
            services.AddCardanoServices(projectName);
            return services;
        }

        /// <summary>
        /// Adds a new <see cref="IAddressService"/> and related services to the the service collection and configures a named <see cref="HttpClient"/> for this project
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="projectName">The name of the project for which to configure a HttpClient</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string projectName)
        {
            var environment = Environment.GetEnvironmentVariable(Constants.ENV_ENVIRONMENT) ?? "development";
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            services.ConfigureBlockfrost(projectName, configuration);
            services.AddCardanoServices(projectName);
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
#if NET
        public static IHttpClientBuilder AddBlockfrostService<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string name, Action<IServiceProvider, HttpClient> configureClient)
#else
        public static IHttpClientBuilder AddBlockfrostService<TClient, TImplementation>(this IServiceCollection services, string name, Action<IServiceProvider, HttpClient> configureClient)
#endif
            where TClient : class
            where TImplementation : class, TClient
        {

            return services.AddHttpClient<TClient, TImplementation>($"{name}:{typeof(TImplementation).Name}", configureClient)
                .AddBlockfrostMessageHandlers();
        }

        /// <summary>
        /// Adds the IHttpClientFactory and related services to the IServiceCollection and configures a binding between the TClient type and a named HttpClient.
        /// </summary>
        /// <typeparam name="TClient">The type of the typed blockfrost service. They type specified will be registered in the service collection as a transient service. See ITypedHttpClientFactory<TClient> for more details about authoring typed clients.</typeparam>
        /// <typeparam name="TImplementation">The implementation type of the typed blockfrost service. They type specified will be instantiated by the ITypedHttpClientFactory<TClient>.</typeparam>
        /// <param name="services">The IServiceCollection.</param>
        /// <param name="name">The logical name of the HttpClient to configure.</param>
#if NET
        public static IHttpClientBuilder AddBlockfrostService<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string name, int connectionLimit = Constants.CONNECTION_LIMIT)
#else
        public static IHttpClientBuilder AddBlockfrostService<TClient, TImplementation>(this IServiceCollection services, string name, int connectionLimit = Constants.CONNECTION_LIMIT)
#endif
            where TClient : class
            where TImplementation : ABlockfrostService, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>($"{name}:{typeof(TImplementation).Name}", (client, provider) =>
            {
                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                var service = ServiceFactory<TImplementation>(client, options.Value[name].Network, connectionLimit);
                return service;
            }).AddBlockfrostMessageHandlers();
        }

        public static IHttpClientBuilder AddBlockfrostMessageHandlers(this IHttpClientBuilder builder, int retries = 3, int timeoutMilliseconds = 600)
        {
            return builder
                .ConfigurePrimaryHttpMessageHandler<RequestThrottler>()
                .SetHandlerLifetime(Timeout.InfiniteTimeSpan)
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(retries, _ => TimeSpan.FromMilliseconds(timeoutMilliseconds))); ;
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
        public static IServiceCollection AddCardanoServices(this IServiceCollection services, string projectName)
        {
            //services.TryAddSingleton(provider =>
            //{
            //    var options = provider.GetService<IOptions<BlockfrostOptions>>();
            //    return new BlockfrostAuthorizationHandler(options.Value[projectName].ApiKey);
            //});

            services.AddAccountService(projectName); 
            
            services.AddAddressService(projectName);
            
            services.AddAssetService(projectName);
            
            services.AddAssetService(projectName);
            
            services.AddBlockService(projectName);
            
            services.AddEpochService(projectName);
            
            services.AddLedgerService(projectName);
            
            services.AddMetadataService(projectName);
            
            services.AddNetworkService(projectName);
            
            services.AddPoolService(projectName);
            
            services.AddRootService(projectName);
            
            services.AddTransactionService(projectName);

            return services;
        }


        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddCardanoServices(this IServiceCollection services, string network, string apiKey, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            var projectName = $"Anonymous.Blockfrost.{network}.Project"; 
            
            services.ConfigureBlockfrost(network, apiKey, projectName, connectionLimit);
            
            services.AddBasicBlockfrostService(projectName, connectionLimit);
            services.AddAddressService(projectName, connectionLimit);
            services.AddTransactionService(projectName, connectionLimit);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="projectName"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            if (!services.Any(s => s.ServiceType.FullName.Contains(typeof(IOptions<BlockfrostOptions>).Name)))
            {
                services.Configure<BlockfrostOptions>(configuration.GetSection($"Blockfrost"));
                BlockfrostProject project = configuration.GetSection($"Blockfrost:{projectName}").Get<BlockfrostProject>();
                if(project == null)
                {
                    throw new InvalidOperationException($"The specified project '{projectName}' is not configured in the 'Blockfrost' section of the appsettings");
                }

                if (string.IsNullOrEmpty(project.ApiKey))
                {
                    project.ApiKey = Environment.GetEnvironmentVariable(Constants.ENV_BFCLI_API_KEY);
                }

                if (string.IsNullOrEmpty(project.Network))
                {
                    project.Network = Environment.GetEnvironmentVariable(Constants.ENV_BFCLI_NETWORK);
                }

                services.TryAddSingleton(project);
            }

            services.TryAddSingleton<BlockfrostAuthorizationHandler>();
            services.TryAddSingleton<RequestThrottler>();
            return services;
        }

        /// <summary>
        /// Helper to configure the BaseAddress of the HttpClient used in the BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="network"></param>
        private static void ConfigureHttpClient(HttpClient client, string network, int sockets)
        {
            client.DefaultRequestHeaders.Add("User-Agent", $"blockfrost-dotnet / v0.0.3 {network}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (sockets > Constants.CONNECTION_LIMIT)
                sockets = Constants.CONNECTION_LIMIT;

            switch (network)
            {
                case "testnet":
                    client.BaseAddress = new Uri(Constants.API_URL_TESTNET);
                    break;

                case "mainnet":
                    client.BaseAddress = new Uri(Constants.API_URL_MAINNET);
                    break;

                case "ipfs":
                    client.BaseAddress = new Uri(Constants.API_URL_IPFS);
                    break;

                default:
                    throw new NotSupportedException($"The specified network '{network}' is not supported");
            }

            ServicePointManager.FindServicePoint(address: client.BaseAddress).ConnectionLimit = sockets;
        }

        /// <summary>
        /// Helper factory to configure the requested BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="client"></param>
        /// <param name="network"></param>
        /// <returns></returns>
        private static TService ServiceFactory<TService>(HttpClient client, string network, int sockets = Constants.CONNECTION_LIMIT) where TService : ABlockfrostService
        {
            ConfigureHttpClient(client, network, sockets);
            TService blockfrostService = (TService)Activator.CreateInstance(typeof(TService), new object[] { client });
            blockfrostService.Network = network;
            return blockfrostService;
        }
    }
}
