using System.Collections.Generic;
using System.Threading.Tasks;
using Blockfrost.Api.Services;
using Blockfrost.Api.Tests.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public class CardanoServiceTest : AServiceTestBase
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
            var cardanoService = Provider.GetRequiredService<ICardanoService>();

            // Assert
            Assert.IsNotNull(cardanoService);
            Assert.IsNotNull(cardanoService.Health);
            Assert.IsNotNull(cardanoService.Metrics);
            Assert.IsNotNull(cardanoService.Accounts);
            Assert.IsNotNull(cardanoService.Addresses);
            Assert.IsNotNull(cardanoService.Assets);
            Assert.IsNotNull(cardanoService.Blocks);
            Assert.IsNotNull(cardanoService.Epochs);
            Assert.IsNotNull(cardanoService.Ledger);
            Assert.IsNotNull(cardanoService.Metadata);
            Assert.IsNotNull(cardanoService.Pools);
            Assert.IsNotNull(cardanoService.Transactions);

            Assert.AreEqual(cardanoService.Blocks.Health, cardanoService.Accounts.Health);
            Assert.AreEqual(cardanoService.Metadata.Metrics, cardanoService.Transactions.Metrics);
        }
    }
}
