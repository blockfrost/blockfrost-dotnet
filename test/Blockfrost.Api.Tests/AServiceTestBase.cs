using Blockfrost.Api.Extensions;
using Blockfrost.Api.Tests.Integration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public abstract class AServiceTestBase : IBlockfrostService
    {
        private static string __providerNotConfiguredErrorMessage = $"The {nameof(Provider)}` has not been configured. Call '{nameof(ConfigureServicesFromConfig)}' inside '{nameof(ConfigureServices)}' or configure the backing field '{nameof(__provider)}' yourself.";
        private static string __configureProjectName = "";

        protected static IServiceProvider __provider;
        protected static IConfiguration __configuration;

        protected static IBlockfrostService __service => Provider.GetRequiredService<IBlockfrostService>();

        public static IEnumerable<Type> AvailableServiceTypes => Assembly.GetAssembly(typeof(IBlockfrostService)).GetTypes().Where(t => t == typeof(IBlockfrostService));
        public string BaseUrl => Constants.API_URL;
        public string Network { get; private set; }
        public bool ReadResponseAsString { get; set; }
        protected static IServiceProvider Provider
        {
            get
            {
                if (__provider == null)
                {
                    throw new InvalidOperationException(__providerNotConfiguredErrorMessage);
                }
                else return __provider;
            }
            set => __provider = value;
        }

        private IServiceCollection __services;

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
                environmentName = configurationRoot[Constants.ENV_ENVIRONMENT] ?? "development";
            }

            // tell the builder to look for the appsettings.json file
            config
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //only add secrets in development
            if (Environments.Development.Equals(environmentName, StringComparison.InvariantCultureIgnoreCase))
            {
                config.AddUserSecrets<TestnetServiceIntegrationTests>();
            }

            __configuration = config.Build();
        }

        public static void ConfigureEnvironment(string projectName)
        {
            __configureProjectName = projectName;
            InitializeEnvironment();
        }

        /// <summary>
        /// Initializes the service collection.
        /// <para>
        /// If <see cref="InitializeEnvironment"/> was used to setup the environment, <see cref="ConfigureServices(IServiceCollection)"/> gets called and the implementing class gets to configure the services. 
        /// </para>
        /// <para>
        /// If <see cref="ConfigureEnvironment(string)"/> was used to setup the environment, <see cref="ConfigureServicesFromConfig(IServiceCollection, string)"/> gets called and the app settings determine the service configuration
        /// </para>
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            var services = new ServiceCollection();
            if (string.IsNullOrEmpty(__configureProjectName)) ConfigureServices(services);
            else ConfigureServicesFromConfig(services, __configureProjectName);
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


        protected virtual void ConfigureServices(IServiceCollection serviceCollection)
        {
            if (!string.IsNullOrEmpty(__configureProjectName))
            {
                throw new NotImplementedException(
                    $"{nameof(ConfigureServices)} must not be called explicitly!  " +
                    $"Override {nameof(ConfigureServices)} in the TestClas and do not call " +
                    $"base.{nameof(ConfigureServices)}(IServiceCollection)");
            }

            throw new InvalidOperationException(
                "The test environment has not been configured! " +
                "Make sure your TestClass defines a [ClassInitialize] method " +
                "with the method signature 'public static void Setup(TestContext)' " +
                "that calls ConfigureEnvironment(projectName)");
        }

        protected virtual void ConfigureServicesFromConfig(IServiceCollection serviceCollection, string projectName)
        {
            if (__configuration == null)
            {
                throw new InvalidOperationException($"The implemnting TestClass did not explicitly call {nameof(AServiceTestBase.InitializeEnvironment)}().");
            }

            var apiKey = __configuration[$"Blockfrost:{projectName}:ApiKey"] ?? __configuration[Constants.ENV_BFCLI_API_KEY];
            var network = __configuration[$"Blockfrost:{projectName}:Network"] ?? __configuration[Constants.ENV_BFCLI_NETWORK];
            var connectionLimit = __configuration[$"Blockfrost:{projectName}:ConnectionLimit"] ?? __configuration[Constants.ENV_BF_RATE_LIMIT];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException(
                    $"Could not read '{nameof(apiKey)}' from config. " +
                    $"This usually happens if the implemnting TestClass does not call {nameof(AServiceTestBase.ConfigureEnvironment)}(projectName) explicitly" +
                    $"or the '{Constants.ENV_BFCLI_API_KEY}' environment variable is not configured on the host.");
            }

            if (string.IsNullOrEmpty(network))
            {
                throw new InvalidOperationException(
                    $"Could not read '{nameof(apiKey)}' from config. " +
                    $"This usually happens if the implemnting TestClass does not call {nameof(AServiceTestBase.ConfigureEnvironment)}(projectName) explicitly" +
                    $"or the '{Constants.ENV_BFCLI_NETWORK}' environment variable is not configured on the host.");
            }

            Network = network;

            OnBuildServiceProvider(serviceCollection.AddBlockfrost(projectName, __configuration));

            Provider = serviceCollection.BuildServiceProvider();
            __services = serviceCollection;
        }

        protected virtual void OnBuildServiceProvider(IServiceCollection serviceCollection) { }

        protected Uri GetNetworkApiBaseAddress()
        {
            if (Network.Equals(Constants.NETWORK_TESTNET))
            {
                return new Uri(Constants.API_URL_TESTNET);
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

        protected async IAsyncEnumerable<ServiceDescriptor> GetClientsAsync()
        {
            foreach (var descriptor in __services)
            {
                await Task.CompletedTask;
                if (descriptor.ServiceType == typeof(IBlockfrostService)
                    || descriptor.ServiceType.GetInterface(nameof(IBlockfrostService)) != null)
                    yield return descriptor;
            }
        }
    }
}
