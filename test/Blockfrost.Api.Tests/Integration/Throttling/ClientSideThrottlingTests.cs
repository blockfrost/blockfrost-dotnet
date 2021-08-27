using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockfrost.Api.Tests.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Integration.Throttling
{
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Blockfrost.Api))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Integration))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Integration.Throttling))]
    public class ClientSideThrottlingTests : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET);
        }

        [TestMethod]
        public async Task RequestThrottling_550Requests_NoRequestRejectedByServer()
        {
            // After 500 requests the burst limit is reached.
            // The next 50 requests need to be throttled, otherwise the server will return an error.
            int requestCount = 550;
            var results = new Dictionary<int, bool>();

            foreach (int requestNr in Enumerable.Range(1, requestCount))
            {
                try
                {
                    // If the rate limit is reached, this will throw an exception.
                    await __service.EndpointsAsync();
                    results.Add(requestNr, true);
                }
                catch (Exception)
                {
                    results.Add(requestNr, false);
                }
            }

            Assert.IsTrue(results.All(r => r.Value));
        }

    }
}
