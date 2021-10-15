using Blockfrost.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Services))]
    public class IpfsServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        [TestMethod]
        public void CanResolve()
        {
            // arrange

            // Act
            var cardanoService = Provider.GetRequiredService<IIPFSService>();

            // Assert
            Assert.IsNotNull(cardanoService);
            Assert.IsNotNull(cardanoService.Health);
            Assert.IsNotNull(cardanoService.Metrics);
            Assert.IsNotNull(cardanoService.Add);
            Assert.IsNotNull(cardanoService.Pins);
            Assert.IsNotNull(cardanoService.Gateway);

            Assert.AreEqual(cardanoService.Add.Health, cardanoService.Gateway.Health);
            Assert.AreEqual(cardanoService.Pins.Metrics, cardanoService.Gateway.Metrics);
        }
    }
}
