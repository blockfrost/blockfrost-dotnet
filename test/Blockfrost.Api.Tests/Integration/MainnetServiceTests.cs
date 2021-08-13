using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests
{
    [IntegrationTestClass("staging")]
    public class MainnetServiceTests : AIntegrationTestsBase
    {
        public MainnetServiceTests() : base(Constants.API_VERSION)
        {
        }

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            SetupEnvironment("Blockfrost.Net.Sdk-mainnet");
        }

        [TestMethod]
        public void TestNetwork()
        {
            Assert.AreEqual(Constants.NETWORK_MAINNET, Service.Network);
        }
    }
}
