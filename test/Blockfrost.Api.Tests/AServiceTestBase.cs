using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Tests.Integration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public abstract class AServiceTestBase : IBlockfrostService
    {
        private static readonly string s_providerNotConfiguredErrorMessage = $"The {nameof(Provider)}` has not been configured. Call '{nameof(ConfigureServicesFromConfig)}' inside '{nameof(ConfigureServices)}' or configure the backing field '{nameof(s_provider)}' yourself.";
        private static string s_configureProjectName = "";

        private static IServiceProvider s_provider;

        protected static Api.Services.IHealthService HealthService => Provider.GetRequiredService<Api.Services.IHealthService>();
        protected static Api.Services.IAccountsService AccountsService => Provider.GetRequiredService<Api.Services.IAccountsService>();

        public static IEnumerable<Type> AvailableServiceTypes => Assembly.GetAssembly(typeof(IBlockfrostService)).GetTypes().Where(t => t == typeof(IBlockfrostService));
        public string BaseUrl { get; set; } = Constants.API_URL;
        public string Network { get; set; }
        public bool ReadResponseAsString { get; set; }
        protected static IServiceProvider Provider
        {
            get => s_provider ?? throw new InvalidOperationException(s_providerNotConfiguredErrorMessage);
            set => s_provider = value;
        }

        public static IConfiguration Configuration { get; set; }

        private IServiceCollection _services;

        public static void InitializeEnvironment()
        {
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.test.json")
                .AddEnvironmentVariables();

            // Load environment
            string environmentName = Environment.GetEnvironmentVariable(Constants.ENV_ENVIRONMENT);

            if (string.IsNullOrWhiteSpace(environmentName))
            {
                var configurationRoot = config.Build();
                environmentName = configurationRoot[Constants.ENV_ENVIRONMENT] ?? "development";
            }

            // tell the builder to look for the appsettings.json file
            _ = config
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //only add secrets in development
            if (Environments.Development.Equals(environmentName, StringComparison.OrdinalIgnoreCase))
            {
                _ = config.AddUserSecrets<TestnetServiceIntegrationTests>();
            }

            Configuration = config.Build();
        }

        [Obsolete("Use ConfigureEnvironment(string projectName, TestContext context) instead")]
        public static void ConfigureEnvironment(string projectName)
        {
            s_configureProjectName = projectName;
            InitializeEnvironment();
        }

        public static void ConfigureEnvironment(string projectName, TestContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            s_configureProjectName = projectName;
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
            if (string.IsNullOrEmpty(s_configureProjectName))
            {
                ConfigureServices(services);
            }
            else
            {
                ConfigureServicesFromConfig(services, s_configureProjectName);
            }
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
            if (!string.IsNullOrEmpty(s_configureProjectName))
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
            if (Configuration == null)
            {
                throw new InvalidOperationException($"The implemnting TestClass did not explicitly call {nameof(AServiceTestBase.InitializeEnvironment)}().");
            }

            string apiKey = Configuration[$"Blockfrost:{projectName}:ApiKey"] ?? Configuration[Constants.ENV_BFCLI_API_KEY];
            string network = Configuration[$"Blockfrost:{projectName}:Network"] ?? Configuration[Constants.ENV_BFCLI_NETWORK];
            string connectionLimit = Configuration[$"Blockfrost:{projectName}:ConnectionLimit"] ?? Configuration[Constants.ENV_BF_RATE_LIMIT];

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

            OnBuildServiceProvider(serviceCollection.AddBlockfrost(projectName, Configuration));

            Provider = serviceCollection.BuildServiceProvider();
            _services = serviceCollection;
        }

        protected virtual void OnBuildServiceProvider(IServiceCollection serviceCollection) { }

        protected Uri GetNetworkApiBaseAddress()
        {
            return Network.Equals(Constants.NETWORK_TESTNET, StringComparison.OrdinalIgnoreCase)
                ? new Uri(Constants.API_URL_TESTNET)
                : Network.Equals(Constants.NETWORK_MAINNET, StringComparison.OrdinalIgnoreCase)
                ? new Uri(Constants.API_URL_MAINNET)
                : Network.Equals(Constants.NETWORK_IPFS, StringComparison.OrdinalIgnoreCase)
                ? new Uri(Constants.API_URL_IPFS)
                : throw new NotSupportedException(nameof(Network));
        }

        protected async IAsyncEnumerable<ServiceDescriptor> GetClientsAsync()
        {
            foreach (var descriptor in _services)
            {
                await Task.CompletedTask;
                if (descriptor.ServiceType == typeof(IBlockfrostService)
                    || descriptor.ServiceType.GetInterface(nameof(IBlockfrostService)) != null)
                {
                    yield return descriptor;
                }
            }
        }
    }
}
