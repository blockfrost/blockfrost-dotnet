using System.Linq;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Extensions
{
    [TestClass]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Extensions))]
    public class AppSettingsConfigurationTests : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        [TestMethod]
        public void BlockfrostConfigSection_WithoutDictionary()
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile($"appsettings.single.json", optional: false, reloadOnChange: true)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .Build();

            IServiceCollection services = new ServiceCollection();
            var provider = services.AddBlockfrost(config).BuildServiceProvider();
            var ledgerService = provider.GetRequiredService<ILedgerService>();
            Assert.IsNotNull(ledgerService);
            Assert.AreEqual("testnet", ledgerService.Network);
        }

        [TestMethod]
        [DataRow(Constants.PROJECT_NAME_TESTNET)]
        [DataRow(Constants.PROJECT_NAME_MAINNET)]
        [DataRow(Constants.PROJECT_NAME_IPFS)]
        public void AddAddressService_Configures_Only_AddressService(string projectName)
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();

            // Act
            _ = services.AddAddressService(projectName, CreateTestSpecificConfiguration());

            // Assert
            AssertServiceNetworkConfigured<IAddressService>(projectName, CreateTestSpecificConfiguration(), services);
            foreach (var serviceType in AvailableServiceTypes.Except(new[] { typeof(IAddressService) }))
            {
                AssertServiceNotConfigured(services, serviceType);
            }
        }

        [TestMethod]
        [DataRow(Constants.PROJECT_NAME_TESTNET)]
        [DataRow(Constants.PROJECT_NAME_MAINNET)]
        [DataRow(Constants.PROJECT_NAME_IPFS)]
        public void AddBlockfrost_Configures_All(string projectName)
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            var config = CreateTestSpecificConfiguration();

            // Act
            _ = services.AddBlockfrost(projectName, config);

            // Assert
            foreach (var serviceType in AvailableServiceTypes)
            {
                AssertServiceNetworkConfigured(projectName, serviceType, config, services);
            }
        }

        private static IConfiguration CreateTestSpecificConfiguration()
        {
            var testSettings = new ConfigurationBuilder()
                            .AddJsonFile(Constants.APPSETTINGS_TEST_FILENAME, optional: false, reloadOnChange: true)
                            .Build();

            string configuredTestEnvironment = testSettings[Constants.ENV_ENVIRONMENT];

            var configurationRoot1 = new ConfigurationBuilder()
                            .AddJsonFile($"appsettings.{configuredTestEnvironment}.json", optional: true, reloadOnChange: true)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .Build();

            return configurationRoot1;
        }
    }
}
