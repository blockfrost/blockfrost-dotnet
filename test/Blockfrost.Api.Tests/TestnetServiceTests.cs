using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public class TestnetServiceTests : BlockfrostServiceTestsBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            SetupEnvironment("Blockfrost.Net.Sdk-testnet");
        }

        [TestMethod]
        [DataRow("addr_test1qzxug2wcch4gqu6squcx4ffuhsppvrsk7edxv0y0uwqn0xvtcm6l3yfqa9j7swygrgh2k2g7kd7jgvkwxkew2uclhssqgp9f83")]
        public override async Task GetAddressTest(string address)
        {
            await base.GetAddressTest(address);
        }
    }
}
