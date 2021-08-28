// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
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
            var service = provider.GetRequiredService<IBlockfrostService>();

            Assert.IsNotNull(await service.EndpointsAsync());
        }
    }
}
