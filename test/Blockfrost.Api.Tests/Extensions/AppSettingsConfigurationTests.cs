using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Blockfrost.Api.Tests.Samples
{
    [TestClass]
    public class AppSettingsConfigurationTests : AServiceTestBase
    {
        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            SetupEnvironment("Blockfrost.Net.Sdk-mainnet");
        }

        [TestMethod]
        [DataRow(Constants.PROJECT_NAME_TESTNET)]
        //[DataRow(Constants.PROJECT_NAME_MAINNET)]
        //[DataRow(Constants.PROJECT_NAME_IPFS)]
        public void AddAddressService_Configures_Only_AddressService(string projectName)
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Constants.APPSETTINGS_FILENAME).Build();

            // Act
            services.AddAddressService(projectName, config);

            // Assert
            AssertServiceNetworkConfigured<IAddressService>(projectName, config, services);

            foreach (var serviceType in AvailableServiceTypes.Except(new[] { typeof(IAddressService) }))
            {
                AssertServiceNotConfigured(services, serviceType);
            }
        }

        [TestMethod]
        [DataRow(Constants.PROJECT_NAME_TESTNET)]
        //[DataRow(Constants.PROJECT_NAME_MAINNET)]
        //[DataRow(Constants.PROJECT_NAME_IPFS)]
        public void AddBlockfrost_Configures_All(string projectName)
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Constants.APPSETTINGS_FILENAME).Build();

            // Act
            services.AddBlockfrost(projectName, config);

            // Assert
            foreach (var serviceType in AvailableServiceTypes)
            {
                AssertServiceNetworkConfigured(projectName, serviceType, config, services);
            }
        }
    }
}
