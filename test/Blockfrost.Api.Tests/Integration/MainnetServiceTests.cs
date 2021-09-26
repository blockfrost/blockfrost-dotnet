using Blockfrost.Api.Tests.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Integration
{

    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Integration))]
    [TestCategory(Constants.NETWORK_MAINNET)]
    public class MainnetServiceTests : AIntegrationTestsBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_MAINNET, context);
        }

        public MainnetServiceTests() : base(Constants.API_VERSION)
        {
        }

        [TestMethod]
        public void Network_Is_Mainnet()
        {
            Assert.AreEqual(Constants.NETWORK_MAINNET, HealthService.Network);
        }
    }
}
