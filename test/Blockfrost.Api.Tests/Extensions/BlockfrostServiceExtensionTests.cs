using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Extensions
{
    [TestClass]
    public class BlockfrostServiceExtensionTests : AServiceTestBase
    {

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        [TestMethod]
        public async Task AddBlockfrost_With_NetworkAndApiKey()
        {
            IServiceCollection services = new ServiceCollection();
            string apiKey = Configuration["ApiKey"] ?? Configuration[Constants.ENV_BFCLI_API_KEY];
            string network = Configuration["Network"] ?? Configuration[Constants.ENV_BFCLI_NETWORK];

            _ = services.AddBlockfrost(network, apiKey);
            var provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<IMetricsService>();

            Assert.IsNotNull(await service.GetEndpointsAsync());
        }
    }
}
