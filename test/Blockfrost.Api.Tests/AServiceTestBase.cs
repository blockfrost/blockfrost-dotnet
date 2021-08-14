using Blockfrost.Api.Extensions;
using Blockfrost.Api.Tests.Integration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public abstract class AServiceTestBase : IBlockfrostService
    {
        protected static IServiceProvider __provider;
        protected static IConfiguration __configuration;

        protected static IBlockfrostService __service => __provider.GetRequiredService<IBlockfrostService>();

        public static IEnumerable<Type> AvailableServiceTypes => Assembly.GetAssembly(typeof(IBlockfrostService)).GetTypes().Where(t => t == typeof(IBlockfrostService));
        public string BaseUrl => Constants.API_URL;
        public string Network { get; private set; }
        public bool ReadResponseAsString { get; set; }

        public static void InitializeEnvironment() 
        {
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.test.json")
                .AddEnvironmentVariables();

            // Load environment
            var environmentName = Environment.GetEnvironmentVariable(Constants.ENV_ENVIRONMENT);

            if (string.IsNullOrWhiteSpace(environmentName))
            {
                IConfigurationRoot configurationRoot = config.Build();
                environmentName = configurationRoot[Constants.ENV_ENVIRONMENT] ?? "test";
            }
            
            // tell the builder to look for the appsettings.json file
            config
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            //only add secrets in development
            if (string.IsNullOrEmpty(environmentName) || Environments.Development.Equals(environmentName, StringComparison.InvariantCultureIgnoreCase))
            {
                config.AddUserSecrets<TestnetServiceIntegrationTests>();
            }

            __configuration = config.Build();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);
        }

        public virtual Task<ICollection<MetricsEndpointResponse>> EndpointsAsync()
        {
            return __service.EndpointsAsync();
        }

        public virtual Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken)
        {
            return __service.EndpointsAsync(cancellationToken);
        }

        public virtual Task<ClockResponse> GetClockAsync()
        {
            return __service.GetClockAsync();
        }

        public virtual Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            return __service.GetClockAsync(cancellationToken);
        }

        public virtual Task<HealthResponse> GetHealthAsync()
        {
            return __service.GetHealthAsync();
        }

        public virtual Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            return __service.GetHealthAsync(cancellationToken);
        }

        public virtual Task<InfoResponse> GetInfoAsync()
        {
            return __service.GetInfoAsync();
        }

        public virtual Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken)
        {
            return __service.GetInfoAsync(cancellationToken);
        }

        public virtual Task<ICollection<MetricResponse>> GetMetricsAsync()
        {
            return __service.GetMetricsAsync();
        }

        public virtual Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken)
        {
            return __service.GetMetricsAsync(cancellationToken);
        }

        protected static void AssertServiceNetworkConfigured<TService>(string projectName, IConfiguration config, IServiceCollection services)
            where TService : IBlockfrostService
        {
            var provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<TService>();
            Assert.AreEqual(service.Network, config[$"Blockfrost:{projectName}:Network"]);
        }

        protected static void AssertServiceNetworkConfigured(string projectName, Type serviceType, IConfiguration config, IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var service = (IBlockfrostService)provider.GetRequiredService(serviceType);
            Assert.AreEqual(service.Network, config[$"Blockfrost:{projectName}:Network"]);
        }

        protected static void AssertServiceNotConfigured<TService>(IServiceCollection services)
            where TService : IBlockfrostService
        {
            AssertServiceNotConfigured(services, typeof(TService));
        }

        protected static void AssertServiceNotConfigured(IServiceCollection services, Type type)
        {
            Assert.IsFalse(services.Any(t => t.ServiceType == type));
        }


        protected abstract void ConfigureServices(IServiceCollection serviceCollection);
        
        protected virtual void ConfigureServicesFromConfig(IServiceCollection serviceCollection, string projectName)
        {
            if(__configuration == null)
            {
                throw new InvalidOperationException($"The implemnting TestClass did not explicitly call {nameof(AServiceTestBase.InitializeEnvironment)}().");
            }

            var apiKey = __configuration[$"Blockfrost:{projectName}:ApiKey"] ?? __configuration[Constants.ENV_BFCLI_API_KEY];
            var network = __configuration[$"Blockfrost:{projectName}:Network"] ?? __configuration[Constants.ENV_BFCLI_NETWORK];
            var connectionLimit = __configuration[$"Blockfrost:{projectName}:ConnectionLimit"] ?? __configuration[Constants.ENV_BF_RATE_LIMIT]; 

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException($"Could not read '{nameof(apiKey)}' from config. This usually happens if the implemnting TestClass does not explicitly calls {nameof(AServiceTestBase.InitializeEnvironment)}().");
            }

            if (string.IsNullOrEmpty(network))
            {
                throw new InvalidOperationException($"Could not read '{nameof(network)}' from config. This usually happens if the implemnting TestClass does not explicitly calls {nameof(AServiceTestBase.InitializeEnvironment)}().");
            }
            Network = network;

            OnBuildServiceProvider(serviceCollection.AddBlockfrost(network, apiKey, int.Parse(connectionLimit)));
            __provider = serviceCollection.BuildServiceProvider();
        }

        protected virtual void OnBuildServiceProvider(IServiceCollection serviceCollection) { }

        protected Uri GetNetworkApiBaseAddress()
        {
            if (Network.Equals(Constants.NETWORK_TESTNET))
            {
                return new  Uri(Constants.API_URL_TESTNET);
            }

            if (Network.Equals(Constants.NETWORK_MAINNET))
            {
                return new Uri(Constants.API_URL_MAINNET);
            }

            if (Network.Equals(Constants.NETWORK_IPFS))
            {
                return new Uri(Constants.API_URL_IPFS);
            }

            throw new NotSupportedException(nameof(Network));
        }
    }
}
