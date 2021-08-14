using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Integration
{

    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Blockfrost.Api))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Integration))]
    public class MainnetServiceTests : AIntegrationTestsBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            InitializeEnvironment();
        }

        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            ConfigureServicesFromConfig(serviceCollection, Constants.PROJECT_NAME_MAINNET);
        }

        public MainnetServiceTests() : base(Constants.API_VERSION)
        {
        }

        [TestMethod]
        public void TestNetwork()
        {
            Assert.AreEqual(Constants.NETWORK_MAINNET, __service.Network);
        }
    }
}
