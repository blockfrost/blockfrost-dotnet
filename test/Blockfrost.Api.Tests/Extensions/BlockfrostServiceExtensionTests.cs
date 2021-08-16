using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests.Extensions
{
    [TestClass]
    public class BlockfrostServiceExtensionTests : AServiceTestBase
    {

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET);
        }

        [TestMethod]
        public async Task AddBlockfrost_With_NetworkAndApiKey()
        {
            IServiceCollection services = new ServiceCollection();
            var apiKey = __configuration["ApiKey"] ?? __configuration[Constants.ENV_BFCLI_API_KEY];
            var network = __configuration["Network"] ?? __configuration[Constants.ENV_BFCLI_NETWORK];

            services.AddBlockfrost(network, apiKey);
            var provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<IBlockfrostService>();
            
            Assert.IsNotNull(await service.EndpointsAsync());
        }
    }
}
