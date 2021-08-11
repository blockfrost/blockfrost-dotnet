using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests
{
    [IntegrationTestClass("staging")]
    public class TestnetServiceIntegrationTests : IntegrationTestsBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            SetupEnvironment("Blockfrost.Net.Sdk-testnet");
        }

        private const string addr_test = "addr_test1qzxug2wcch4gqu6squcx4ffuhsppvrsk7edxv0y0uwqn0xvtcm6l3yfqa9j7swygrgh2k2g7kd7jgvkwxkew2uclhssqgp9f83";
        private const string stake_test = "stake_test1uz9uda0cjyswje0g8zyp5t4t9y0txlfyxt8rtvh9wv0mcgqphtf6d";
    }
}
